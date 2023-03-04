using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_POS.POS
{
    public partial class quantityform : Form
    {

        //mysqlconnections


        public int a = 0;
        internal string quantity;

        //Data Table
        DataTable dt;

        MainConnection data = new MainConnection();

        //create variables for constructor
        String identifier, item_code, product_name, price;
        
        public quantityform(String identifier, String item_code, String product_name, String price)
        {
            InitializeComponent();
            
            //constructors setters to variable
            this.identifier = identifier;
            this.item_code = item_code;
            this.product_name = product_name;
            this.price = price;
     
        }

        // this function is to compute the quantity * price
        public String computePrice(double computed_Price)
        {
            String converted_Price;
            double c_price = Convert.ToDouble(txtnum.Text) * computed_Price;

            return converted_Price = Convert.ToString(c_price);
           
        }

        private void insert_temp_pay()
        {
            try
            {
                //take note txtnum.text is the quantity
                data.executeSQL("INSERT INTO temp_pay (IDENTIFIER, ITEM_CODE, PRODUCT_NAME, QUANTITY, PRICE)" +
                    "VALUES ('" + identifier + "', '" + item_code + "', '" + product_name + "', '" + txtnum.Text + "', '" + computePrice(Convert.ToDouble(price)) + "')");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Inserting on Temp_Pay Table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            a++;
            txtnum.Text = a.ToString();
        }

        private void btnsub_Click(object sender, EventArgs e)
        {

            int x = Convert.ToInt32(txtnum.Text);

            if (x <= 1)
            {

            }
            else
            {
                a--;
                txtnum.Text = a.ToString();
            }
        }
        

        private void buttonsave_Click(object sender, EventArgs e)
        {
            //validation of quantity if null or 0 value;
            if (String.IsNullOrEmpty(txtnum.Text) || Convert.ToInt32(txtnum.Text) <= 0)
            {
                MessageBox.Show("Please Input right Quantity!");
            }
            else
            {
                insert_temp_pay();
                this.Close();
            }
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            quantity = null;
            this.Close();
        }

    }
}
