using MySql.Data.MySqlClient;
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
    public partial class addproducts : Form
    {
        MainConnection data = new MainConnection();
        MySqlCommand cmd;
        MySqlConnection con;
        DataTable dt;
        MySqlDataAdapter adpt;
        private string action;
        int errorCount;
        public Point mouseLocation;
        string username = "";

        DateTime date = DateTime.Now;
        public addproducts(string action, string username)
        {
            InitializeComponent();
            con = new MySqlConnection();
            con.ConnectionString = data.getConnection();
            this.action = action;
            this.username = username;
        }
        public void validateForm()
        {
            errorProvider1.Clear();
            errorCount = 0;

            if (string.IsNullOrEmpty(txtproductid.Text))
            {
                errorProvider1.SetError(txtproductid, "Product ID is empty");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtproductname.Text))
            {
                errorProvider1.SetError(txtproductname, "Product Name is empty");
                errorCount++;
            }
            if (cmbcategory.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbcategory, "Select Category");
                errorCount++;
            }
            if (cmbavailability.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbavailability, "Select Category");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtprice.Text))
            {
                errorProvider1.SetError(txtprice, "Price is empty");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtdescription.Text))
            {
                errorProvider1.SetError(txtdescription, "Description is empty");
                errorCount++;
            }
            if (action == "add")
            {
                try
                {
                    dt = new DataTable();
                    adpt = new MySqlDataAdapter("SELECT * FROM products WHERE PRODUCT_ID = '" + txtproductid.Text + "'", con);
                    adpt.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        errorProvider1.SetError(txtproductid, "Product ID is already existing");
                        errorCount++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on searching exsiting Product ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    con.Close();
                }
            }
        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        string FileName = openFileDialog.FileName;
                        txtimagepath.Text = FileName;
                        pictureBox1.Load(FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void CategorySettings()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                adpt = new MySqlDataAdapter("Select SETTINGS_CATEGORY from settings where SETTINGS_FORM = 'POScategory'", con);
                adpt.Fill(dt);

                foreach (DataRow da in dt.Rows)
                {
                    cmbcategory.Items.Add(da[0].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                validateForm();
                if (errorCount == 0)
                {
                    con.Open();
                    cmd = new MySqlCommand("INSERT INTO products (PRODUCT_ID, PRODUCT_NAME, PRODUCT_PRICE, PRODUCT_DESCRIPTION, PRODUCT_STATUS,PRODUCT_CATEGORY,PRODUCT_AVAILABILITY,PRODUCT_IMAGE )VALUES " +
                        "('" + txtproductid.Text + "',  '" + txtproductname.Text + "', '" + txtprice.Text + "', '" + txtdescription.Text + "', 'In-Stock','" + cmbcategory.Text + "','"+ cmbavailability.Text +"',@image)", con);

                    MemoryStream stream = new MemoryStream();
                    pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = stream.ToArray();
                    cmd.Parameters.AddWithValue("@Image", pic);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //insert logs//
                    logs();

                    MessageBox.Show("Added new product", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    formproducts addP = (formproducts)Application.OpenForms["formproducts"];
                    addP.DatagridviewLoad();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on adding product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
            }
        }
        public void logs()
        {
            string action = "Added New Item ID:" + txtproductid.Text + " by: " + username.ToString();
            con.Open();
            cmd = new MySqlCommand("Insert into logs (datelog, timelog, full_name, action, module)" +
                "Values('" + date.ToString("yyyy-MM-dd") + "', '" + date.ToString("HH:mm:ss") + "', '" + username.ToString() + "', '" + action.ToString() + "', 'Products')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(e.X, e.Y);
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - mouseLocation.X;
                this.Top += e.Y - mouseLocation.Y;

            }
        }

        private void addproducts_Load(object sender, EventArgs e)
        {
            CategorySettings();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
