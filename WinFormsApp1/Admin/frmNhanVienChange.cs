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

namespace WinFormsApp1.Admin
{
    public partial class frmNhanVienChange : Form
    {
        IUserRepository userRepository = new UserRepository();
        public User user = null;
        public Boolean isUpdate = true; // co phai update ko?
        public frmNhanVienChange()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                try
                {
                    user.Name = textBox2.Text;
                    user.Password = textBox3.Text;
                    userRepository.UpdateUser(user);
                    this.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString());
                    this.Close();
                }
            }
            else
            {
                try
                {
                    user = new User()
                    {
                        
                        Name = textBox2.Text,
                        Password = textBox3.Text,
                        Role = textBox4.Text,
                    };
                    userRepository.AddUser(user);
                    this.Close();
                }
                catch(Exception x)
                {
                    MessageBox.Show(x.ToString());
                    this.Close();
                }
            }
        }

        private void frmNhanVienChange_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                
                textBox2.Text = user.Name;
                textBox3.Text = user.Password;
            }
            textBox4.Text = "EM";
            textBox4.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
