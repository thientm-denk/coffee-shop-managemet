using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Repository;
using DataAccess.Repository.Imple;
using System.Text.Json;
using DataAccess.DAO;
using BusinessObject.Models;
using WinFormsApp1.Employee;

namespace WinFormsApp1
{
    public partial class Login : Form
    {
        IUserRepository userRepository = new UserRepository();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            string password = Password.Text;
            string jsonString = File.ReadAllText("appsettings.json");
            User admin = JsonSerializer.Deserialize<User>(jsonString)!;

            if (userName.Equals(admin.Name) && password.Equals(admin.Password))
            {
              
            }

            else if (((UserRepository)userRepository).Login(userName, password) != null)
            {
                this.Hide();
                frmEmployeeOpen frmEmployeeOpen = new frmEmployeeOpen();

                frmEmployeeOpen.user = ((UserRepository)userRepository).Login(userName, password);

                frmEmployeeOpen.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
            }
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton.PerformClick();
            }
        }



        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.LoginButton;
        }



        private void lbLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
