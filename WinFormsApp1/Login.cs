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
            User loginUser = userRepository.Login(userName, password);

            // dang nhap sai tra ve null
            if (loginUser == null)
            {
                MessageBox.Show("Wrong username or password!");
            }
            // dung thi kiem tra xem phai admin ko
            else if (loginUser.Role.Equals("MA"))
            {
                MessageBox.Show("Admin here");
            }
            else
            {
                frmEmployeeOpen frmEmployeeOpen = new frmEmployeeOpen();

                frmEmployeeOpen.loginUser = ((UserRepository)userRepository).Login(userName, password);

                frmEmployeeOpen.ShowDialog();

                this.Close();
            }
            }
    }
}
