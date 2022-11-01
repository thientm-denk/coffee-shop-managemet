using BusinessObject.Models;
using DataAccess.Repository;
using DataAccess.Repository.Imple;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.Admin
{
    public partial class frmDoanhThu : Form
    {
        // khai bao o day nha
        IShiftRepository shiftRepository = new ShiftRepository();
       
        IShiftDetailRepository shiftDetailRepository = new ShiftDetailRepository(); 
        BindingSource source;
        BigInteger doanhThu;

        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
        // nut Load
        private void button1_Click(object sender, EventArgs e)
        {
            var shifts = shiftRepository.GetOrdersInDateRange(DateTime.Parse(dateTimePicker1.Text),
                DateTime.Parse(dateTimePicker2.Text));

            // loc shift
            var shift = shiftRepository.GetShift(comboBox2.Text);
            doanhThu = 0;
            if (shift != null)
            {
                for (int i = 0; i < shifts.Count; i++)
                {
                    if (shift != null)
                    {
                        if (shifts[i].ShiftId != shift.ShiftId)
                        {
                            shifts.Remove(shifts[i]);
                            i--;
                        }
                    }
                }
            }
            // tinh profits
            for (int i = 0; i < shifts.Count; i++)
            {
                doanhThu += (shifts[i].CloseWallet - shifts[i].OpenWallet);
            }

            label3.Text = "Profit: " + doanhThu.ToString();


            try
            {
                FillDataGridView(shifts);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load report order list");
            }
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            
            

            var shift = shiftRepository.GetShiftsList();
            comboBox2.Items.Add("All");
            for (int i = 0; i < shift.Count; i++)
            {              
                comboBox2.Items.Add(shift[i].ShiftName);
            }
            var shifts = shiftDetailRepository.GetShiftDetailList();
            FillDataGridView(shifts);
            for (int i = 0; i < shifts.Count; i++)
            {
                doanhThu += (shifts[i].CloseWallet - shifts[i].OpenWallet);
            }

            label3.Text = "Profit: " + doanhThu.ToString();

        }


        #region method
        private void FillDataGridView(List<ShiftDetail> shift)
        {
            source = new BindingSource();
            source.DataSource = shift;

            //txtOrderId.DataBindings.Clear();
            //txtMemberId.DataBindings.Clear();
            //txtOrderDate.DataBindings.Clear();
            //txtRequiredDate.DataBindings.Clear();
            //txtShippedDate.DataBindings.Clear();
            //txtFreight.DataBindings.Clear();

            //txtOrderId.DataBindings.Add("Text", source, "OrderId");
            //txtMemberId.DataBindings.Add("Text", source, "MemberId");
            //txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
            //txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
            //txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
            //txtFreight.DataBindings.Add("Text", source, "Freight");

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = source;
            this.dataGridView1.Columns["Shift"].Visible = false;
            this.dataGridView1.Columns["User"].Visible = false;
            this.dataGridView1.Columns["Orders"].Visible = false;
            this.dataGridView1.Columns["UserId"].Visible = false;
            this.dataGridView1.Columns["ShiftDetailsId"].Visible = false;

            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
