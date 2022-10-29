using BusinessObject.Models;
using DataAccess.Repository;
using DataAccess.Repository.Imple;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.Employee
{
    public partial class frmNewOrder : Form
    {
        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();

        IOrderRepository orderRepository = new OrderRepository();

        DataTable dt = new DataTable();
        Int64 money;
        IDrinkRepository drinkRepository = new DrinkRepository();
        frmSelling form { get; set; }
        IOrderDetailRepository drinkDetailRepository = new OrderDetailRepository();
        public frmNewOrder(frmSelling selling)
        {
            InitializeComponent();
            form = selling;
        }

        private void frmNewOrder_Load(object sender, EventArgs e)
        {
            List<Drink> drinks = drinkRepository.GetDrinksList();
            dgvProducts.Enabled = true;
            dgvProducts.DataSource = drinks;
            dgvProducts.Columns.Remove("TypeID");
            dgvProducts.Columns.Remove("OrderDetails");
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int drinkId = (int)dgvProducts.Rows[e.RowIndex].Cells[0].Value;
            dgvBill.Enabled = true;
            dgvBill.DataSource = createnewrow(drinkId, drinkRepository.GetDrink(drinkId).Name, 1, (int)drinkRepository.GetDrink(drinkId).Price, 0);
            money += (int)drinkRepository.GetDrink(drinkId).Price;
            label7.Text = money.ToString();
        }
        public DataTable createnewrow(int drinkId, String name, int quantity, int price, int voucherId)
        {
            if (dt.Rows.Count <= 0)
            {
                DataColumn dc1 = new DataColumn("Drink Id", typeof(int));
                DataColumn dc2 = new DataColumn("Name", typeof(string));
                DataColumn dc3 = new DataColumn("Quanity", typeof(int));
                DataColumn dc4 = new DataColumn("Price", typeof(int));
                DataColumn dc5 = new DataColumn("Voucher Id", typeof(int));
                dt.Columns.Add(dc1);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dt.Columns.Add(dc4);
                dt.Columns.Add(dc5);
                dt.Rows.Add(drinkId, name, quantity, price, voucherId);
                return dt;
            }
            else
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                    if (drinkId == Int64.Parse(dt.Rows[i][0].ToString()))
                    {
                        Int64 quanti = Int64.Parse(dt.Rows[i][2].ToString());
                        dt.Rows[i][2] = (quanti=quanti+1).ToString();
                        return dt;
                    }           
             dt.Rows.Add(drinkId, name, quantity, price,0);               
            }
            return dt;
           
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string searchValue = textSearch.Text;

                List<Drink> searchResult = drinkRepository.SearchDrink(searchValue);
                if (searchResult.Any())
                {
                    dgvProducts.DataSource = searchResult;
                }
                else
                {
                    MessageBox.Show("No result found!", "Search member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Int64 quanti = Int64.Parse(dt.Rows[e.RowIndex][2].ToString());
            dt.Rows[e.RowIndex][2] = (quanti = quanti - 1).ToString();  
            money = money - Int64.Parse(dt.Rows[e.RowIndex][3].ToString());
            label7.Text = money.ToString();
            label7.Refresh();
            dgvBill.DataSource = dt;
            if (Int64.Parse(dt.Rows[e.RowIndex][2].ToString()) == 0)
                dt.Rows.RemoveAt(e.RowIndex);
            if (dt.Rows.Count==0)
            {
                dt.Rows.Clear();
                dt.Columns.Clear();
                dgvBill.DataSource = null;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (money > 0)
            {
                Order order = new Order();
                order.Price = money;
                string time = DateTime.Now.ToString("HH:mm:ss");
                order.Time = TimeSpan.Parse(time);
                if (order.Time >= new TimeSpan(6, 0, 0) && order.Time <= new TimeSpan(12, 0, 0))
                    order.ShiftId = 1;
                else
                    if (order.Time > new TimeSpan(12, 0, 0) && order.Time <= new TimeSpan(18, 0, 0))
                    order.ShiftId = 2;
                else
                    order.ShiftId = 3;
                orderRepository.Add(order);
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.DrinkId = Int32.Parse(dt.Rows[i][0].ToString());
                    orderDetail.Quantity = Int32.Parse(dt.Rows[i][2].ToString());
                    orderDetail.VocherId = Int32.Parse(dt.Rows[i][4].ToString());
                    orderDetail.OrderId = orderRepository.GetNextOrderId()-1;
                    orderDetailRepository.AddOrderDetail(orderDetail);
                }

                DialogResult result = MessageBox.Show("Your bill has been generated!");
                if (result == DialogResult.OK)
                {
                    frmSelling.order = order;
                    form.RefreshGrid();
                    form.Refresh();
                    this.Close();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
