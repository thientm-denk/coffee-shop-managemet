using DataAccess.Repository.Imple;
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
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1.Admin
{
    public partial class frmProductChange : Form
    {
        IDrinkRepository drinkRepository = new DrinkRepository();
        IDrinkTypeRepository drinkTypeRepository = new DrinkTypeRepository();
        public Drink drink = null;
        public Boolean isUpdate = true; // co phai update ko?

        public frmProductChange()
        {
            InitializeComponent();
        }
        private void frmProductChange_Load(object sender, EventArgs e)
        {
            var listTpye = drinkTypeRepository.GetDrinkTypesList();
            for(int i = 0; i < listTpye.Count; i++)
            {
                comboBox1.Items.Add(listTpye[i].TypeId.ToString()+ "-" + listTpye[i].Name);
            }


            if (isUpdate)
            {
                comboBox1.SelectedIndex = drink.TypeId - 1;
                textBox3.Text = drink.Name;
                textBox4.Text = drink.Price.ToString();
                
            }
            

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                try
                {
                    drink.TypeId = int.Parse(comboBox1.Text[0].ToString());
                    drink.Name = textBox3.Text;
                    drink.Price = long.Parse(textBox4.Text);
                    drinkRepository.UpdateDrink(drink);
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
                    drink = new Drink()
                    {
                        TypeId = int.Parse(comboBox1.Text[0].ToString()),
                        Name = textBox3.Text,
                        Price = int.Parse(textBox4.Text),
                    };
                    drinkRepository.AddDrink(drink);
                    this.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString());
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
