using Guna.UI2.WinForms.Suite;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using NEW_POS.Administration_related.accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_POS.Products
{
    public partial class availabilityForm : Form
    {
        MainConnection data = new MainConnection();
        MySqlConnection con;
        MySqlCommand cmd;
        formproducts f;
        DateTime date = DateTime.Now;
        private string action;
        string username;


        public void logs()
        {
            string action = "Added New Item ID:" + txtproductid.Text + " by: " + username.ToString();
            con.Open();
            cmd = new MySqlCommand("Insert into logs (datelog, timelog, full_name, action, module)" +
                "Values('" + date.ToString("yyyy-MM-dd") + "', '" + date.ToString("HH:mm:ss") + "', '" + username.ToString() + "', '" + action.ToString() + "', 'products')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("UPDATE products SET PRODUCT_AVAILABILITY= '" + cmbavailability.Text + "' WHERE PRODUCT_ID = '" + txtproductid.Text + "'", con);

                
                cmd.ExecuteNonQuery();
                con.Close();
                //insert logs//
                logs();
                MessageBox.Show("Product Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                formproducts update = (formproducts)Application.OpenForms["formproducts"];
                update.DatagridviewLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on updating product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        public availabilityForm(formproducts f, string action, string username)
        {
            InitializeComponent();
            con = new MySqlConnection();
            con.ConnectionString = data.getConnection();
            this.f = f;
            this.action = action;
            this.username = username;

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
