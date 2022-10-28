using BusinessObject.Models;
using DataAccess.Repository.Imple;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WinFormsApp1.Employee
{
    public partial class frmEmployeeOpen : Form
    {
        public static User loginUser { get; set; } = null;
        public frmEmployeeOpen()
        {
            InitializeComponent();
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
  
            if (int.TryParse(textMoney.Text, out var value))
            {
                Int64 money = Int64.Parse(textMoney.Text);
                if (money > 0)
                {
                    this.Hide();

                    frmSelling frmSelling = new frmSelling();

                    frmSelling.loginUser = loginUser;

                    frmSelling.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please input an positive integer!");
                }           
            }
            else
            {
                MessageBox.Show("Please input an integer!");
            }

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Login = new Login();

            Login.ShowDialog();

            this.Close();
        }
    }
}
