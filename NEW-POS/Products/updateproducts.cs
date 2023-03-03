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
using MySql.Data.MySqlClient;

namespace NEW_POS.Products
{
    public partial class updateproducts : Form
    {
        MainConnection data = new MainConnection();
        MySqlConnection con;
        MySqlCommand cmd;
        formproducts f;
        DateTime date = DateTime.Now;
        private string action;
        string username;
        public updateproducts(formproducts f, string action, string username)
        {
            InitializeComponent();
            con = new MySqlConnection();
            con.ConnectionString = data.getConnection();
            this.f = f;
            this.action = action;
            this.username = username;
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
                cmd = new MySqlCommand("UPDATE products SET PRODUCT_NAME = '" + txtproductname.Text + "', PRODUCT_PRICE = '" + txtprice.Text + "', PRODUCT_DESCRIPTION = '" + txtdescription.Text + "',PRODUCT_STATUS = 'In-Stock' , PRODUCT_CATEGORY= '" + cmbcategory.Text + "', PRODUCT_AVAILABILITY= '" + cmbavailability.Text + "', PRODUCT_IMAGE= @Image WHERE PRODUCT_ID = '" + txtproductid.Text + "'", con);

                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();
                cmd.Parameters.AddWithValue("@Image", pic);
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

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
