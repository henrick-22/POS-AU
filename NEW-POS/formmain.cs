using MySql.Data.MySqlClient;
using NEW_POS;
using NEW_POS.Administration_related.accounts;
using NEW_POS.category_settings;
using NEW_POS.POS;
using NEW_POS.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class formmain : Form
    {
        string username,usertype;
        MySqlConnection cn;
        MySqlDataReader dr;
        MySqlCommand cmd;
        MainConnection data = new MainConnection();
        public Point mouseLocation;
        public formmain(string username,string usertype)
        {
            InitializeComponent();
            this.username = username;
            this.usertype = usertype;
            cn = new MySqlConnection();
            cn.ConnectionString = data.getConnection();

        }
        
        private void formmain_Load(object sender, EventArgs e)
        {
            loadResource();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            formlogin login = new formlogin();
            this.Close();
            login.Show();
        }

        private void btnpos_Click(object sender, EventArgs e)
        {
            //pointofsale pos = new pointofsale(username,usertype);
            //pos.Show();
            //this.Hide();
            try
            {
                DialogResult answer = MessageBox.Show("Are you sure want delete this data?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new MySqlCommand("DELETE FROM temp_pay", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    pointofsale pos = new pointofsale(username, usertype);
                    pos.Show();
                    this.Hide();
                }
                else if (answer == DialogResult.No)
                {
                    pointofsale pos = new pointofsale(username, usertype);
                    pos.Show();
                    this.Hide();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error on btnpos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnaccounts_Click(object sender, EventArgs e)
        {
            manageaccount manacc = new manageaccount(this, lblusername.Text, lblusertype.Text) { TopLevel = false, TopMost = true, Dock = DockStyle.Fill };
            this.pContainer.Controls.Add(manacc);
            manacc.BringToFront();
            manacc.Show();
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            formproducts prod = new formproducts(lblusername.Text, lblusertype.Text) { TopLevel = false, TopMost = true, Dock = DockStyle.Fill };
            this.pContainer.Controls.Add(prod);
            prod.BringToFront();
            prod.Show();
        }

        private void btncategory_Click(object sender, EventArgs e)
        {
            formcategory cat = new formcategory(lblusername.Text) { TopLevel = false, TopMost = true, Dock = DockStyle.Fill };
            this.pContainer.Controls.Add(cat);
            cat.BringToFront();
            cat.Show();
        }

        private void btnincome_Click(object sender, EventArgs e)
        {
            //working...
        }

        private void btnabout_Click(object sender, EventArgs e)
        {
            //working...
        }

        private void loadResource()
        {
            try
            {
                cn.Open();
                cmd = new MySqlCommand("Select * from account where ACCOUNT_USERNAME ='" + username + "'", cn);
                dr = cmd.ExecuteReader();
                dr.Read();
                username = dr["ACCOUNT_FULL_NAME"].ToString();
                usertype = dr["ACCOUNT_USERTYPE"].ToString();
                lblusername.Text = username;
                lblusertype.Text = usertype;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Load Resource", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
