using MySql.Data.MySqlClient;
using NEW_POS.Administration_related.accounts;
using POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace NEW_POS.Products
{
    public partial class formproducts : Form
    {
        private Size formOriginalSize;
        private Rectangle textboxsearch;
        private Rectangle datagrid;
        private Rectangle btn1;
        private Rectangle btn2;
        private Rectangle btn3;

        MainConnection data = new MainConnection();
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter adpt;
        MySqlDataReader dr;
        DataTable dt;
        DBconnection db = new DBconnection(); //To call class DBconnection
        DateTime date = DateTime.Now;
        private int row = 0;
        string username;
        string usertype;
        string selectedUser;
        public formproducts(string username,string usertype)
        {
            InitializeComponent();
            showImage();
            con = new MySqlConnection();
            con.ConnectionString = data.getConnection();
            this.username = username;
            this.usertype = usertype;
            
        }
        public void autosize()
        {
            formOriginalSize = this.Size;
            textboxsearch = new Rectangle(txtsearch.Location.X, txtsearch.Location.Y, txtsearch.Width, txtsearch.Height);
            datagrid = new Rectangle(dgvProducts.Location.X, dgvProducts.Location.Y, dgvProducts.Width, dgvProducts.Height);
            btn1 = new Rectangle(btnadd.Location.X, btnadd.Location.Y, btnadd.Width, btnadd.Height);
            btn2 = new Rectangle(btnupdate.Location.X, btnupdate.Location.Y, btnupdate.Width, btnupdate.Height);
            btn3 = new Rectangle(btndelete.Location.X, btndelete.Location.Y, btndelete.Width, btndelete.Height);
        }
        private void resizeControl(Rectangle OriginalControlRect, Control control)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);


            int newX = (int)(OriginalControlRect.X * xRatio);
            int newY = (int)(OriginalControlRect.Y * yRatio);

            int newWidth = (int)(OriginalControlRect.Width * xRatio);
            int newHeight = (int)(OriginalControlRect.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
        }
        private void resizeChildrenControl()
        {
            //textbox//
            resizeControl(textboxsearch, txtsearch);

            //button//
            resizeControl(btn1, btnadd);
            resizeControl(btn2, btnupdate);
            resizeControl(btn3, btndelete);

            //datagrid//
            resizeControl(datagrid, dgvProducts);
        }
        private void ManageAccount_Resize(object sender, EventArgs e)
        {
            resizeChildrenControl();
        }

        private void formproducts_Load(object sender, EventArgs e)
        {
        //    DatagridviewLoad();
          //  autosize();
            showImage();
        }
        private void Products_Resize(object sender, EventArgs e)
        {
            resizeChildrenControl();
        }
        public void logs()
        {
            string action = "Deleted An Item ID:" + selectedUser.ToString() + " by: " + username.ToString();
            con.Open();
            cmd = new MySqlCommand("Insert into logs (datelog, timelog, full_name, action, module)" +
                "Values('" + date.ToString("yyyy-MM-dd") + "', '" + date.ToString("HH:mm:ss") + "', '" + username.ToString() + "', '" + action.ToString() + "', 'products')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DatagridviewLoad()
        {
            try
            {
                dt = new DataTable();
                adpt = new MySqlDataAdapter("select PRODUCT_ID, PRODUCT_NAME, PRODUCT_PRICE, PRODUCT_DESCRIPTION, PRODUCT_STATUS, PRODUCT_CATEGORY,PRODUCT_AVAILABILITY, PRODUCT_IMAGE from products " +
                    "ORDER BY PRODUCT_ID", con);
                adpt.Fill(dt);
                dgvProducts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on loading datagridview", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            addproducts addprod = new addproducts("",username);
            addprod.ShowDialog();
        }



        private void showImage()
        {
            try
            {
                dgvProducts.Rows.Clear();
                db.connect();
                string sql = "select * from products";
                dr = db.show(sql);
                while (dr.Read())
                {

                    dgvProducts.Rows.Add(dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(4), dr.GetValue(5), dr.GetValue(6), dr.GetValue(7));
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                dr.Close();
            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedUser = dgvProducts.Rows[row].Cells[0].Value.ToString();
                updateproducts edit = new updateproducts(this, "Update", username);
                con.Open();
                cmd = new MySqlCommand("select PRODUCT_ID, PRODUCT_NAME, PRODUCT_PRICE, PRODUCT_DESCRIPTION, PRODUCT_STATUS, PRODUCT_CATEGORY, PRODUCT_IMAGE, PRODUCT_AVAILABILITY from products " +
                    "WHERE PRODUCT_ID LIKE '" + selectedUser + "' ", con);
                cmd.ExecuteNonQuery();

                edit.txtproductid.Text = dgvProducts.Rows[row].Cells[0].Value.ToString();
                edit.txtproductname.Text = dgvProducts.Rows[row].Cells[1].Value.ToString();
                edit.txtprice.Text = dgvProducts.Rows[row].Cells[2].Value.ToString();
                edit.txtdescription.Text = dgvProducts.Rows[row].Cells[3].Value.ToString();
                edit.cmbcategory.Text = dgvProducts.Rows[row].Cells[5].Value.ToString();
                edit.cmbavailability.Text = dgvProducts.Rows[row].Cells[6].Value.ToString();
                byte[] imgData = (byte[])dgvProducts.Rows[row].Cells[7].Value;
                MemoryStream ms = new MemoryStream(imgData);
                edit.pictureBox1.Image = Image.FromStream(ms);
                con.Close();
                edit.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Update button", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                row = e.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error on Cell Click datagridview", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                selectedUser = dgvProducts.Rows[row].Cells[0].Value.ToString();
                DialogResult dialog = MessageBox.Show("Are you sure you want to permanently delete this product?", "Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new MySqlCommand("DELETE FROM products WHERE PRODUCT_ID = '" + selectedUser + "'", con);
                    cmd.ExecuteReader();
                    con.Close();

                    //insert logs//
                    logs();
                    MessageBox.Show("Product Deleted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formproducts del = (formproducts)Application.OpenForms["formproducts"];
                    del.DatagridviewLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Delete Button", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
