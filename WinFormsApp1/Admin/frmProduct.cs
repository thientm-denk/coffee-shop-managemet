﻿using DataAccess.Repository.Imple;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject.Models;

namespace WinFormsApp1.Admin
{
    public partial class frmProduct : Form
    {
        BindingSource source;
        IDrinkRepository drinkRepository = new DrinkRepository();

        public frmProduct()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(label1.Text != null)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    drinkRepository.DeleteDrink(int.Parse(label1.Text));
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var listDrinks = drinkRepository.GetDrinksList();
            // loc lai
            //for (int i = 0; i < listDrinks.Count; i++)
            //{
            //    if (listDrinks[i].DrinkId == 0)
            //    {
            //        listDrinks.Remove(listDrinks[i]);
            //        i--;
            //    }
            //}


            try
            {
                FillDataGridView(listDrinks);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load report order list");
            }
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            var listDrinks = drinkRepository.GetDrinksList();
            try
            {
                FillDataGridView(listDrinks);

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

        #region method
        private void FillDataGridView(List<Drink> shift)
        {
            source = new BindingSource();
            source.DataSource = shift;

            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();


            textBox1.DataBindings.Add("Text", source, "DrinkId");
            textBox2.DataBindings.Add("Text", source, "Name");
            textBox3.DataBindings.Add("Text", source, "Price");
            textBox4.DataBindings.Add("Text", source, "TypeId");


            dataGridView1.DataSource = null;
            dataGridView1.DataSource = source;

            this.dataGridView1.Columns["Type"].Visible = false;
            this.dataGridView1.Columns["OrderDetails"].Visible = false;


            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion
    }
}
