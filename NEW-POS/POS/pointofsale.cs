using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using POS;
using NEW_POS.Administration_related.accounts;
using System.Linq.Expressions;
using System.Management.Instrumentation;

namespace NEW_POS.POS
{
    public partial class pointofsale : Form
    {
        double tot, price, price1;
        string filter = "";
        int count;
        int sum = 0;
        string transtype, action;
        string username;
        string usertype;
        DataTable dt;
        quantityform qf;
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter adp;
        DateTime date = DateTime.Now;
        private PictureBox pic;
        private Label pname;
        private Button del;
        MainConnection data = new MainConnection();
        formmain fm;
        private string v;

        

        private void pointofsale_Load(object sender, EventArgs e)
        {
            GetData();
            cmbCategoryData();
            timer1.Start();
            /*orderlist_Output();*/
            orderlist_Output_Final();
            refresh();
            totalAmount();
            totalcount();

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.SelectedIndex < 1000)
                {
                    filter = "COFFEE";
                    flowLayoutPanel1.Controls.Clear();
                    cn.Open();
                    cm = new MySqlCommand("Select PRODUCT_IMAGE, PRODUCT_DESCRIPTION, PRODUCT_ID, PRODUCT_NAME from products where PRODUCT_CATEGORY = '" + cmbCategory.Text + "' order by PRODUCT_NAME", cn);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        long len = dr.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                        dr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                        pic = new PictureBox();
                        pic.Width = 163;
                        pic.Height = 163;
                        pic.BackgroundImageLayout = ImageLayout.Zoom;
                        pic.Tag = dr["PRODUCT_ID"].ToString();

                        del = new Button();
                        del.Text = "X";

                        pname = new Label();
                        pname.Text = dr["PRODUCT_NAME"].ToString();
                        pname.BackColor = Color.FromArgb(255, 220, 115);
                        pname.TextAlign = ContentAlignment.MiddleCenter;
                        pname.Dock = DockStyle.Bottom;
                        pname.ForeColor = Color.FromArgb(39, 55, 70);

                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmap = new Bitmap(ms);
                        pic.BackgroundImage = bitmap;

                        pic.Controls.Add(pname);
                        flowLayoutPanel1.Controls.Add(pic);

                        pic.Click += new EventHandler(onClick_Select);

                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Selecting Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public pointofsale(string username,string usertype)
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = data.getConnection();
            this.username = username;
            this.usertype = usertype;
            
        }




        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        string colName = dgv_Orderlist.Columns[e.ColumnIndex].Name;
                
        //        if (colName == "Delete")
        //        {

        //            string pid = dgv_Orderlist.Rows[0].Cells[0].Value.ToString();




        //            int mycell = dgv_Orderlist.CurrentCell.RowIndex;
        //            dgv_Orderlist.Rows.RemoveAt(mycell);



        //            lbltotal.Text = (from DataGridViewRow row in dgv_Orderlist.Rows
        //                             where row.Cells[0].FormattedValue.ToString() != string.Empty
        //                             select Convert.ToInt32(row.Cells[3].FormattedValue)).Sum().ToString();
        //            txtTotalCost.Text = lbltotal.Text;

        //            //total quantity
        //            int[] qty = new int[dgv_Orderlist.Rows.Count];
        //            qty = (from DataGridViewRow row in dgv_Orderlist.Rows
        //                   where row.Cells[0].FormattedValue.ToString() != string.Empty
        //                   select Convert.ToInt32(row.Cells[2].FormattedValue)).ToArray();
        //            lblcount.Text = qty.Sum().ToString();
        //        }
                
            
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnPayment_Click(object sender, EventArgs e)
        {
            payments pay = new payments("", "", "", "", this,username);
            pay.ShowDialog();
        }
        public int row = -1;


        private void GetData()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                cn.Open();
                cm = new MySqlCommand("Select PRODUCT_IMAGE, PRODUCT_DESCRIPTION, PRODUCT_ID, PRODUCT_NAME,PRODUCT_PRICE from products order by PRODUCT_NAME", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    long len = dr.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                    dr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                    pic = new PictureBox();
                    pic.Width = 163;
                    pic.Height = 163;
                    pic.BackgroundImageLayout = ImageLayout.Zoom;
                    pic.Tag = dr["PRODUCT_ID"].ToString();

                    del = new Button();
                    del.Text = "X";

                    pname = new Label();
                    pname.Text = dr["PRODUCT_NAME"].ToString() + " (" + dr["PRODUCT_PRICE"].ToString() + ")";
                    pname.BackColor = Color.FromArgb(255, 220, 115);
                    pname.TextAlign = ContentAlignment.MiddleCenter;
                    pname.Dock = DockStyle.Bottom;
                    pname.ForeColor = Color.FromArgb(39, 55, 70);

                    MemoryStream ms = new MemoryStream(array);
                    Bitmap bitmap = new Bitmap(ms);
                    pic.BackgroundImage = bitmap;

                    pic.Controls.Add(pname);
                    flowLayoutPanel1.Controls.Add(pic);

                    pic.Click += new EventHandler(onClick_Select);
                }   
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void cmbCategoryData()
        {
            try
            {
                DataTable dt = new DataTable();
                cn.Open();
                adp = new MySqlDataAdapter("Select SETTINGS_CATEGORY from SETTINGS where SETTINGS_FORM = 'POScategory'", cn);
                adp.Fill(dt);

                foreach (DataRow da in dt.Rows)
                {
                    cmbCategory.Items.Add(da[0].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on cmb Category Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pic.Click += new EventHandler(onClick_Select);
        }
        /*private void onClick(object sender, EventArgs e)
        {
            try
            {
                quantityform qf = new quantityform(username, "", "", "");
                qf.ShowDialog();
                string quantity = quantityform.quantity;
                if (string.IsNullOrEmpty(quantity))
                {
                    quantity = quantity.Replace("0", String.Empty);
                }
                else
                {
                    String tag = ((PictureBox)sender).Tag.ToString();
                    cn.Open();
                    cm = new MySqlCommand("select * from products where PRODUCT_ID like '" + tag + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        int quantity1 = Convert.ToInt32(quantity);

                        String pid = dr["PRODUCT_ID"].ToString();

                        price = quantity1 * double.Parse(dr["PRODUCT_PRICE"].ToString());
                        count += 1;

                        dataGridView1.Rows.Add(dr["PRODUCT_ID"].ToString(), dr["PRODUCT_NAME"].ToString(), quantity.ToString(), price.ToString());

                        lbltotal.Text = (from DataGridViewRow row in dataGridView1.Rows
                                         where row.Cells[0].FormattedValue.ToString() != string.Empty
                                         select Convert.ToInt32(row.Cells[3].FormattedValue)).Sum().ToString();
                        txtTotalCost.Text = lbltotal.Text;
                        //total quantity
                        int[] qty = new int[dataGridView1.Rows.Count];
                        qty = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[0].FormattedValue.ToString() != string.Empty
                               select Convert.ToInt32(row.Cells[2].FormattedValue)).ToArray();
                        lblcount.Text = qty.Sum().ToString();
                    }

                }
                dr.Close();
                cn.Close();
                lbltotal.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[0].FormattedValue.ToString() != string.Empty
                                 select Convert.ToInt32(row.Cells[3].FormattedValue)).Sum().ToString();
                txtTotalCost.Text = lbltotal.Text;
            }
            catch (Exception ex)
            {

            }
        }*/

        private void onClick_Select(object sender, EventArgs e)
        {
            try
            {
                //initiate string null values
                String item_code = null;
                String product_name = null;
                String price = null;

                /**//*steps in selecting
                1.Get all the data of required fields that will be inserted to database
                   Data's are: Identifier, Item_Code, Product Name, Price , Quantity will be set on the Quantity Form
                2.Once the data was get, you need constructor to pass the data to the quantity_form *//**/

                String tag = ((PictureBox)sender).Tag.ToString();

                DataTable dt = data.GetData("SELECT * FROM PRODUCTS WHERE PRODUCT_ID LIKE '" + tag + "'");
                

                if (dt.Rows.Count > 0)
                {
                    item_code = dt.Rows[0][0].ToString();
                    product_name = dt.Rows[0][1].ToString();
                    price = dt.Rows[0][2].ToString();


                    DataTable dtExist = data.GetData("SELECT ITEM_CODE FROM TEMP_PAY WHERE ITEM_CODE ='" +item_code + "'");
                    if(dtExist.Rows.Count <= 0) 
                    {
                        //showing of form after getting the value from search query on database table product

                        //TAKE NOTE!!! the last parameter 0 and 1 states that 0 is for new insert and 1 is for updating only!!
                        quantityform qf = new quantityform(generate_Identifier(), item_code, product_name, price, 0);
                        qf.ShowDialog();
                        totalAmount();
                        totalcount();
                        
                    }
                    else
                    {
                        //TAKE NOTE!!! the last parameter 0 and 1 states that 0 is for new insert and 1 is for updating only!!
                        quantityform qf = new quantityform(generate_Identifier(), item_code, product_name, price, 1);
                        qf.ShowDialog();
                        pointofsale pos = (pointofsale)Application.OpenForms["pointofsale"];
                        pos.refresh();
                        totalAmount();
                        totalcount();
                    }

                    
                }
                else
                {
                    MessageBox.Show("No product Available!");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error on On-Click_Select", MessageBoxButtons.OK, MessageBoxIcon.Error); }


        }

        //string variable to generate Identifier
        public string generate_Identifier()
        {
            String identifier = null;
            try
            {
                //sql query to count the numbers of rows in the temp_pay table
                DataTable dt = data.GetData("SELECT COUNT(IDENTIFIER) + 1 AS COUNTER FROM TEMP_PAY");

                //set the result value to the identifier variable which will be used later
                identifier  =  dt.Rows[0][0].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error on generating identifier", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            //return statement of identifier
            return identifier;
        }

        public void orderlist_Output()
        {
            /*try
            {
                DataTable dt = data.GetData("SELECT ITEM_CODE AS ITEM_C, PRODUCT_NAME AS PROD_NAME, QUANTITY AS QTY, PRICE FROM TEMP_PAY");

                //Add Collumn Headers
                *//*dgv_Orderlist.Columns.Add("ITEM_CODE", "ITEM_C");
                dgv_Orderlist.Columns.Add("PRODUCT_NAME", "PROD_NAME");
                dgv_Orderlist.Columns.Add("QUANTITY", "QTY");
                dgv_Orderlist.Columns.Add("PRICE", "PRICE");
                dgv_Orderlist.Columns.Add("REMOVE", "REMOVE");*//*

                //creating new button for remove
                DataGridViewButtonColumn removeBtn = new DataGridViewButtonColumn();
                removeBtn.UseColumnTextForButtonValue = true;
                removeBtn.Text = "REMOVE";
                removeBtn.Name = "REMOVE";


                //set column count
                dgv_Orderlist.ColumnCount = 5;

                dgv_Orderlist.Columns[0].Name = "ITE_CDE";
                dgv_Orderlist.Columns[1].Name = "PRD_NME";
                dgv_Orderlist.Columns[2].Name = "QTY";
                dgv_Orderlist.Columns[3].Name = "PRICE";
                *//*dgv_Orderlist.Columns.Add(removeBtn);*/
                /*dgv_Orderlist.Columns.Add("ITE_CDE", "ITE_CDE");
                dgv_Orderlist.Columns.Add("PRD_NME", "PRD_NME");
                dgv_Orderlist.Columns.Add("QTY", "QTY");
                dgv_Orderlist.Columns.Add("PRICE", "PRICE");*//*

                int i = 0;
                while (i < dt.Rows.Count)
                {
                    dgv_Orderlist.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dgv_Orderlist.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dgv_Orderlist.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dgv_Orderlist.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    dgv_Orderlist.Rows[i].Cells[4].Value = dgv_Orderlist.Columns.Add(removeBtn);
                    i++;
                }

             }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error on Orderlist_Output", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { cn.Close(); }*/
        }

        public void orderlist_Output_Final()
        {
            try
            {
                DataTable dt = data.GetData("SELECT ITEM_CODE AS ITEM_C, PRODUCT_NAME AS PROD_NAME, QUANTITY AS QTY, PRICE FROM TEMP_PAY");
                dgv_Orderlist.DataSource = dt;

                //creating new button for remove
                DataGridViewButtonColumn removeBtn = new DataGridViewButtonColumn();
                removeBtn.HeaderText = "DELETE";
                removeBtn.Text = "X";
                removeBtn.Name = "X";
                removeBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                removeBtn.Width = 55;
                

                removeBtn.UseColumnTextForButtonValue = true;

                //to avoid duplications on column header name
                if (dgv_Orderlist.Columns.Contains("X") == false)
                {
                    dgv_Orderlist.Columns.Add(removeBtn);
                }
                else
                {
                    //nothing happens
                }
                pointofsale pos = (pointofsale)Application.OpenForms["pointofsale"];
                pos.refresh();
                //to get totalamount even refreshed.
                totalAmount();
                totalcount();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Orderlist_Output", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //syntax for remove button
        private void dgv_Orderlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;
            
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //finding the item_code in datagridview to use it on deleteItem Function parameter.
                String item = dgv_Orderlist.Rows[e.RowIndex].Cells[1].Value.ToString();
                deleteItem(item);
            }

        }
        //function to delete the item on database
        public void deleteItem(String item_code)
        {
            try
            {
                data.executeSQL("DELETE FROM TEMP_PAY WHERE ITEM_CODE = '" + item_code + "'");
                orderlist_Output_Final();
                totalAmount();
                totalcount();
                /*if(data.rowAffected > 0)
                {
                    MessageBox.Show("Item is Deleted");
                }*/
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error on deleteItem", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private double discount, total, result;

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void txtConfirm_Click(object sender, EventArgs e)
        {
            DataTable dt = data.GetData("SELECT IF(SUM(PRICE) > 0, SUM(PRICE), 0) AS TOTAL FROM TEMP_PAY");
            lbltotal.Text = dt.Rows[0][0].ToString();
            txtTotalCost.Text = dt.Rows[0][0].ToString();
            totalamt = Convert.ToDouble(dt.Rows[0][0].ToString());
            discount = Convert.ToDouble(txtdiscount.Text);
            result = totalamt - (totalamt * discount / 100);
            txtTotalCost.Text = result.ToString();
            pointofsale pos = (pointofsale)Application.OpenForms["pointofsale"];
            pos.refresh();
        }

        //private void txtConfirm_Click(object sender, EventArgs e)
        //{
        //    lbltotal.Text = total.ToString();
        //    txtdiscount.Text = discount.ToString();
        //    double     
        //    double result = total(total - discount / 100);
        //}


        //total amount function on the orderlist
        public double totalamt;
        public void totalAmount()
        {
            try
            {
                //baka ma confuse ka sa sql query, try mo isearch yung if statement ng sql hahaha,
                //eto yung sinasabi ko sayo na mag cocompute ka nalang thru sql hahahahaha
                DataTable dt = data.GetData("SELECT IF(SUM(PRICE) > 0, SUM(PRICE), 0) AS TOTAL FROM TEMP_PAY");
                lbltotal.Text = dt.Rows[0][0].ToString();
                txtTotalCost.Text = dt.Rows[0][0].ToString();
                


                //input

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error on deleteItem", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void totalcount()
        {
            try
            {
                //baka ma confuse ka sa sql query, try mo isearch yung if statement ng sql hahaha,
                //eto yung sinasabi ko sayo na mag cocompute ka nalang thru sql hahahahaha
                DataTable dt = data.GetData("SELECT IF(SUM(QUANTITY) > 0, SUM(QUANTITY), 0) AS TOTAL FROM TEMP_PAY");
                lblcount.Text = dt.Rows[0][0].ToString();
                

                //input




            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error on deleteItem", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void refresh()
        {
            dt = new DataTable();
            adp = new MySqlDataAdapter("select ITEM_CODE,PRODUCT_NAME,QUANTITY,PRICE from temp_pay", cn);
            adp.Fill(dt);
            dgv_Orderlist.DataSource = dt;
        }

    }
}
