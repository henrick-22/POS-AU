using MySql.Data.MySqlClient;
using NEW_POS.POS;
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

namespace NEW_POS
{
    public partial class formlogin : Form
    {
        //string randomNumber;

        MySqlConnection cn;
        MySqlDataReader dr;
        MySqlCommand cmd;
        MainConnection data = new MainConnection();
        int errorCount = 0;
        string fullname, username,usertype;

        DateTime date = DateTime.Now;

        private void validateusername()
        {
            cmd = new MySqlCommand("select * from account where ACCOUNT_USERNAME = '" + txtusername.Text + "'", cn);

            if (txtusername.Text == "")
            {
                errorProvider1.SetError(txtusername, "Username is empty");
            }
            else if (txtusername.TextLength < 4)
            {
                errorProvider1.SetError(txtusername, "Username should be atleast 6 characters");
            }
            else
            {
                errorProvider1.SetError(txtusername, "");
            }
        }
        private void validatepassword()
        {
            cmd = new MySqlCommand("select * from account where ACCOUNT_PASSWORD = '" + txtpassword.Text + "'", cn);

            if (txtpassword.Text == "")
            {
                errorProvider1.SetError(txtpassword, "Password is empty");
            }
            else if (txtpassword.TextLength < 4)
            {
                errorProvider1.SetError(txtpassword, "Password should be atleast 4 characters");
            }
            else
            {
                errorProvider1.SetError(txtpassword, "");
            }
        }
        private void countErrors()
        {
            errorCount = 0;
            foreach (Control c in errorProvider1.ContainerControl.Controls)
            {
                if (errorProvider1.GetError(c) != "")
                {
                    errorCount++;
                }
            }
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                validateusername();
                validatepassword();
                countErrors();
                if (errorCount == 0)
                {
                    cn.Open();
                    cmd = new MySqlCommand("select * from account where ACCOUNT_USERNAME = '" + txtusername.Text + "' OR ACCOUNT_FULL_NAME ='"
                        + txtusername.Text + "'  AND ACCOUNT_PASSWORD = '" + txtpassword.Text + "'", cn);
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            fullname = dr["ACCOUNT_FULL_NAME"].ToString();
                            username = dr["ACCOUNT_USERNAME"].ToString();
                            usertype = dr["ACCOUNT_USERTYPE"].ToString();
                            if (usertype == "MANAGER")
                            {
                                formmain ds = new formmain(username, usertype);
                                ds.Show();
                                this.Hide();
                            }
                            else
                            {
                                pointofsale pos = new pointofsale(username, usertype);
                                pos.Show();
                                this.Hide();
                            }
                            
                        }
                        dr.Close();

                        //insert logs//

                        //insert data to tbl loggedIn//

                        //update tblaccount status

                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username and Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    cn.Close();
                }
                else
                {
                  
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Logging In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public formlogin()
        {
            InitializeComponent();
            this.ActiveControl = txtusername;
            cn = new MySqlConnection();
            cn.ConnectionString = data.getConnection();
            txtusername.Focus();
        }
        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToChar(e.KeyChar) == 13)
            {
                btnlogin_Click(sender, e);
            }
        }
        private void lblClearFields_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            txtusername.Focus();
        }
    }
}
