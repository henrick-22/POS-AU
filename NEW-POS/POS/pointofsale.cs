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

                        pic.Click += new EventHandler(onClick);

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




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;
                
                if (colName == "Delete")
                {

                    string pid = dataGridView1.Rows[0].Cells[0].Value.ToString();




                    int mycell = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(mycell);



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

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //////////// payment validation

            //    if (Convert.ToDouble(lbltotal.Text) <= 0)
            //    {
            //        MessageBox.Show("No Items has been found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else if (string.IsNullOrEmpty(txtdiscount.Text))
            //    {
            //        txtdiscount.Text = "0";
            //    }
            //    else
            //    {
            //        ////////////////////////////////////////// - Transaction Type
                    
            //        //////////////////////////////////////////////////////////////////
            //        cn.Open();
            //        cm = new MySqlCommand("select * from tblproduct  ", cn);
            //        dr = cm.ExecuteReader();
            //        dr.Read();

            //        payments pc = new payments(lblcount.Text, txtdiscount.Text, txtTotalCost.Text, this, username, fm, action) { TopLevel = false, TopMost = true, Dock = DockStyle.Fill };

            //        for (int a = 0; a < dataGridView1.Rows.Count; a++)
            //        {
            //            int n = pc.dgv2.Rows.Add();
            //            a = n;
            //            pc.dgv2.Rows[n].Cells[0].Value = dataGridView1.Rows[n].Cells[0].Value.ToString();
            //            pc.dgv2.Rows[n].Cells[1].Value = dataGridView1.Rows[n].Cells[1].Value.ToString();
            //            pc.dgv2.Rows[n].Cells[2].Value = dataGridView1.Rows[n].Cells[2].Value.ToString();
            //            pc.dgv2.Rows[n].Cells[3].Value = dataGridView1.Rows[n].Cells[3].Value.ToString();
            //        }

                    
            //        fm.pContainer.Controls.Add(pc);
            //        pc.BringToFront();
            //        pc.Show();
            //        cn.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
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

                    pic.Click += new EventHandler(onClick);
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
            pic.Click += new EventHandler(onClick);
        }
        private void onClick(object sender, EventArgs e)
        {
                try
                {
                    quantityform qf = new quantityform(username);
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
                    MessageBox.Show(ex.Message, "Error on On-Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }     
   
        }
    }
}
