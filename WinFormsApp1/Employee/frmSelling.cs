using BusinessObject.Models;
using DataAccess.Repository;
using DataAccess.Repository.Imple;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Employee;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WinFormsApp1
{
    public partial class frmSelling : Form
    {
        IOrderRepository orderRepository = new OrderRepository();
        int count = 0;
        public static long moneyIn { get; set; } = 0;
        long money = 0;
        public static Order order { get; set; } = null;
        List<Order> orders = new List<Order>();
        public static User loginUser { get; set; } = null;
        public frmSelling()
        {
            InitializeComponent();
        }

        private void frmSelling_Load(object sender, EventArgs e)
        {
            txtName.Text = loginUser.Name;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
            txtDate.Text = DateTime.Now.ToLongDateString();
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            frmEmployeeClose frmEmployeeClose = new frmEmployeeClose(this);
            frmEmployeeClose.moneyOut = money;
            frmEmployeeClose.moneyIn = moneyIn;
            frmEmployeeClose.ShowDialog();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            frmNewOrder frmNewOrder = new frmNewOrder(this);    
            frmNewOrder.ShowDialog();
        }
        public void RefreshGrid()
        {
            orders.Add(order);
             //Works great
            BindingSource binding = new BindingSource();
            binding.DataSource = orders;
            dataGridView1.DataSource = binding;
            count++;
            money = money + orders[orders.Count-1].Price;
            label4.Text = count.ToString();
            label6.Text = money.ToString();
            dataGridView1.Columns.Remove("OrderId");
            dataGridView1.Refresh();
            
            this.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}