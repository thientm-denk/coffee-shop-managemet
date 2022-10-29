using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Order order { get; set; } = null;
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
            frmEmployeeClose frmEmployeeClose = new frmEmployeeClose();

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
            dataGridView1.Enabled = true;
            dataGridView1.DataSource = orders; //Works great
            dataGridView1.Rows.Add(order);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}