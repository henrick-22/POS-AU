using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NEW_POS.Administration_related.accounts
{
    public partial class addaccount : Form
    {
        private string  Full_Name, Usertype, Status, Cell_Number;
        string username;
        MainConnection data = new MainConnection();
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter adpt;


        DateTime date = DateTime.Now;
        DataTable dt;
        string sql;
        private int errorCount;

        public addaccount(string Full_Name, string Usertype, string Status, string Cell_Number, string username)
        {
            InitializeComponent();
            con = new MySqlConnection();
            con.ConnectionString = data.getConnection();
            this.Full_Name = Full_Name;
            this.Usertype = Usertype;
            this.Status = Status;
            this.Cell_Number = Cell_Number;
            this.username = username;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                validateForm();
                if (errorCount == 0)
                {
                    string addon = "+63";
                    con.Open();
                    cmd = new MySqlCommand("INSERT INTO account (ACCOUNT_USERNAME, ACCOUNT_PASSWORD, ACCOUNT_USERTYPE, ACCOUNT_STATUS, ACCOUNT_FULL_NAME, ACCOUNT_CONTACT_NUMBER) VALUES " +
                        "('" + txtusername.Text + "', '" + txtpassword.Text + "', '" + cmbusertype.Text + "', 'ACTIVE', '" + txtfullname.Text + "', '" + (addon + txtcontact.Text) + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Account Added!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //insert logs//
                    logs();

                    this.Hide();
                    manageaccount add = (manageaccount)Application.OpenForms["manageaccount"];
                    add.incrementrefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on adding an account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public void logs()
        {
            string action = "Added New Account :" + txtusername.Text + " by: " + username.ToString();
            con.Open();
            cmd = new MySqlCommand("Insert into logs (datelog, timelog, full_name, action, module)" +
                "Values('" + date.ToString("yyyy-MM-dd") + "', '" + date.ToString("HH:mm:ss") + "', '" + username.ToString() + "', '" + action.ToString() + "', 'Account')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void validateForm()
        {
            errorProvider1.Clear();
            errorCount = 0;
            if (string.IsNullOrEmpty(txtfullname.Text))
            {
                errorProvider1.SetError(txtfullname, "Please input your full name");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtcontact.Text))
            {
                errorProvider1.SetError(txtcontact, "Please input your contact number");
                errorCount++;
            }
            if (cmbusertype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbusertype, "Please select a position");
                errorCount++;
            }
            try
            {
                dt = new DataTable();
                adpt = new MySqlDataAdapter("select * from account where ACCOUNT_USERNAME = '" + txtusername.Text + "'", con);
                adpt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtusername, "Employee Number is already existing");
                    errorCount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on search existing employee number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
