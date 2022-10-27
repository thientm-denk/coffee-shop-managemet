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
            UserRepository userRepository = new UserRepository();
            User admin = userRepository.Login(userName, password);

            // dang nhap sai tra ve null
            if (admin == null)
            {
                MessageBox.Show("Wrong username or password!");
            }
            // dung thi kiem tra xem phai admin ko
            else if (admin.Role.Equals("MA"))
            {
                MessageBox.Show("Admin here");
            }
            else{ // khong dung thi chay cai nay (Canisher)

                MessageBox.Show("User");

                //this.Hide();
                //frmEmployeeOpen frmEmployeeOpen = new frmEmployeeOpen();

                //frmEmployeeOpen.user = ((UserRepository)userRepository).Login(userName, password);

                //frmEmployeeOpen.ShowDialog();

                //this.Close();
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
