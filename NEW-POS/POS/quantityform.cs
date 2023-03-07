using MySql.Data.MySqlClient;
using NEW_POS.Administration_related.accounts;
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
        public string quantity;

        MainConnection data = new MainConnection();

        //create variables for constructor
        String identifier, item_code, product_name, price;
        int action;
        
        public quantityform(String identifier, String item_code, String product_name, String price, int action)
        {
            InitializeComponent();
            
            //constructors setters to variable
            this.identifier = identifier;
            this.item_code = item_code;
            this.product_name = product_name;
            this.price = price;
            this.action = action;
     
        }

        // this function is to compute the quantity * price
        public String computePrice(double computed_Price)
        {
            String converted_Price;
            double c_price = Convert.ToDouble(txtnum.Text) * computed_Price;

            return converted_Price = Convert.ToString(c_price);
           
        }

        private void update_temp_pay()
        {
            try
            {
                data.executeSQL("UPDATE TEMP_PAY SET QUANTITY ='" + txtnum.Text + "', PRICE = '"+ computePrice(Convert.ToDouble(price))+"'  WHERE ITEM_CODE = '" + item_code + "'");
                if(data.rowAffected > 0)
                {
                    MessageBox.Show("Updated Quantity!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Inserting on Update_Temp_Pay Function", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //this function is to insert the items to the TEMP_PAY Table
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
                MessageBox.Show(ex.Message, "Error on Inserting on Insert_Temp_Pay Function", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void quantityform_Load(object sender, EventArgs e)
        {
            setUpdateQuantity();
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
                //TAKE NOTE!!! the last parameter 0 and 1 states that 0 is for new insert and 1 is for updating only!!
                if (action == 0)
                {
                    insert_temp_pay();
                    pointofsale ps = new pointofsale("", "");
                    pointofsale pos = (pointofsale)Application.OpenForms["pointofsale"];
                    pos.refresh();
                    ps.orderlist_Output();
                    this.Close();
                }
                else if(action == 1)
                {
                    update_temp_pay();
                    pointofsale ps = new pointofsale("", "");
                    pointofsale pos = (pointofsale)Application.OpenForms["pointofsale"];
                    pos.refresh();
                    ps.orderlist_Output();
                    this.Close();

                    action = 0;
                }
                
            }
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            quantity = null;
            this.Close();
        }

        //this function used when you update the quantity of the product, the textbox on quantity form changes by its value on temp table
        private void setUpdateQuantity()
        {
            try
            {
                //this is for update quantity only thats why action is default to 1
                if(action == 1)
                {
                    DataTable dt = data.GetData("SELECT ITEM_CODE, QUANTITY FROM TEMP_PAY WHERE ITEM_CODE ='" + item_code + "'");
                    if (dt.Rows.Count > 0)
                    {
                        txtnum.Text = dt.Rows[0][1].ToString();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error on set_Update_Quantity Function!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

    }
}
