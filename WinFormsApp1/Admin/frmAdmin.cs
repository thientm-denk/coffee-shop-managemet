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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }
        // orderd 
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            loadForm(new DrinkController());
        }
        // nhan vien
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            loadForm(new frmNhanVien());
        }
        // nuoc uong
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            loadForm(new frmProduct());
        }
        // doanh thu
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            loadForm(new frmDoanhThu());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Method
        private void loadForm(Form form)
        {
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.RemoveAt(0);
            }
            Form frm = form as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.BringToFront();
            this.panel1.Controls.Add(frm);
            this.panel1.Tag = frm;
            frm.Show();


        }

        #endregion

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            loadForm(new frmDoanhThu());
        }
    }
}
