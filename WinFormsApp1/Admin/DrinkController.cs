using Microsoft.Data.SqlClient;
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
    public partial class DrinkController : Form
    {
        public DrinkController()
        {
            InitializeComponent();
        }

        private void DrinkController_Load(object sender, EventArgs e)
        {

            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection("server =(local); database = CoffeeShop;uid=sa;pwd=12345;"))
                {

                    //retrieve the SQL Server instance version
                    string query = @"select  dbo.OrderDetails.drinkId,dbo.Drinks.name, SUM(quantity) as 'quantity'
                                    from dbo.OrderDetails 
                                    join dbo.Drinks
                                    on dbo.OrderDetails.drinkId=dbo.Drinks.drinkId
									join dbo.Orders
                                    on dbo.OrderDetails.orderId=dbo.Orders.orderId
									where dbo.Orders.date > DATEADD(Day,-30,GETDATE())
                                    group by  dbo.OrderDetails.drinkId,dbo.Drinks.name
                                    order by SUM(quantity) DESC";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(query, conn);


                    //Set the SqlDataAdapter object
                    SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);

                    //define dataset
                    DataSet ds = new DataSet();

                    //fill dataset with query results
                    dAdapter.Fill(ds);

                    //set DataGridView control to read-only
                    dataGridView1.ReadOnly = true;

                    //set the DataGridView control's data source/data table
                    dataGridView1.DataSource = ds.Tables[0];


                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                MessageBox.Show("Exception: " + ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
