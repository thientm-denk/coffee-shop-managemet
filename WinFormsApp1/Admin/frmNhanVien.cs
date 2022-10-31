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
    public partial class frmNhanVien : Form
    {
        BindingSource source;
        IUserRepository userRepository = new UserRepository();


        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // new
        private void button2_Click(object sender, EventArgs e)
        {
            handleNewClick();
        }
        private void handleNewClick()
        {
            frmNhanVienChange frmNhanVien = new frmNhanVienChange();
            frmNhanVien.isUpdate = false;
            frmNhanVien.ShowDialog();
            handleLoadClick();
        }


        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            var listUser = userRepository.GetUsersList();
            // loc lai
            for (int i = 0; i < listUser.Count; i++)
            {
                if (listUser[i].UserId == 0)
                {
                    listUser.Remove(listUser[i]);
                    i--;
                }
            }
            try
            {
                FillDataGridView(listUser);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load report order list");
            }
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            handleLoadClick();
        }
        private void handleLoadClick()
        {
            var listUser = userRepository.GetUsersList();
            // loc lai
            for (int i = 0; i < listUser.Count; i++)
            {
                if (listUser[i].UserId == 0)
                {
                    listUser.Remove(listUser[i]);
                    i--;
                }
            }


            try
            {
                FillDataGridView(listUser);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load report order list");
            }
        }


        #region method
        private void FillDataGridView(List<User> shift)
        {
            source = new BindingSource();
            source.DataSource = shift;

            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();


            textBox1.DataBindings.Add("Text", source, "UserId");
            textBox2.DataBindings.Add("Text", source, "Name");
            textBox3.DataBindings.Add("Text", source, "Password");
            textBox4.DataBindings.Add("Text", source, "Role");


            dataGridView1.DataSource = null;
            dataGridView1.DataSource = source;
            this.dataGridView1.Columns["ShiftDetails"].Visible = false;
            this.dataGridView1.Columns["UserId"].Visible = false;


            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            handleDeleteClick();
        }
        public void handleDeleteClick()
        {
            if (textBox4.Equals("MA"))
            {
                MessageBox.Show("Cannot delete MA");
            }
            else if (textBox1.Text != null)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    userRepository.DeleteUser(int.Parse(textBox1.Text));
                }
            }
            handleLoadClick();
        }
       

        private void dgvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmNhanVienChange frmNhanVien = new frmNhanVienChange();
            frmNhanVien.user = GetUserShowed();
            frmNhanVien.ShowDialog();
            handleLoadClick();
        }

        private void frmNhanVien_Load_1(object sender, EventArgs e)
        {

        }
        private User GetUserShowed()
        {
            User user = null;
            try
            {
                user = new User
                {
                    UserId = int.Parse(textBox1.Text),
                    Name = (textBox2.Text),
                    Password = (textBox3.Text),
                    Role = (textBox4.Text),
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order");
            }
            return user;
        }
    }
}
