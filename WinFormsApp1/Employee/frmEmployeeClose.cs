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
    public partial class frmEmployeeClose : Form
    {
        frmSelling form;

        IShiftDetailRepository shiftDetailRepository = new ShiftDetailRepository();
        public static long moneyOut { get; set; } = 0;
        public static long moneyIn { get; set; } = 0;

        public static int userId { get; set; } = 0;

        public static int shiftId { get; set; } = 0;
        public frmEmployeeClose(frmSelling selling)
        {
            InitializeComponent();
            form = selling;
        }

        private void frmEmployeeClose_Load(object sender, EventArgs e)
        {
            txtBefore.Text = moneyIn.ToString();
            txtBefore.Enabled = false;
            txtExpected.Text = (moneyOut+moneyIn).ToString();
            txtExpected.Enabled = false;
           
        }

        private void txtBefore_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShiftDetail shiftdetail = new ShiftDetail();
            string time = DateTime.Now.ToString("yyyy/MM/dd");
            shiftdetail.Date = DateTime.Parse(time);
            shiftdetail.UserId = userId;
            shiftdetail.ShiftId = shiftId;
            shiftdetail.OpenWallet = moneyIn;
            shiftdetail.CloseWallet = moneyIn+moneyOut;
            shiftDetailRepository.AddShiftDetail(shiftdetail);
            form.Close();
            this.Close();
           
        }
    }
}
