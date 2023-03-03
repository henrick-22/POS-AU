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

namespace NEW_POS.Administration_related.accounts
{
    public partial class updateaccount : Form
    {
        MainConnection data = new MainConnection();
        MySqlConnection con;
        MySqlCommand cmd;
        string username;
        private string  Username,Full_Name, Usertype, Status, Cell_Number;
        

        private void updateaccount_Load(object sender, EventArgs e)
        {
            txtusername.Text = Username;
            if (Usertype == "USER")
            {
                cmbusertype.SelectedIndex = 0;
            }
            else if (Usertype == "MANAGER")
            {
                cmbusertype.SelectedIndex = 1;
            }
            txtfullname.Text = Full_Name;
            txtcontact.Text = Cell_Number;
            
          
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public void logs()
        {
            string action = "Update Account :" + txtfullname.Text + " by: " + username.ToString();
            con.Open();
            cmd = new MySqlCommand("Insert into logs (datelog, timelog, full_name, action, module)" +
                "Values('" + date.ToString("yyyy-MM-dd") + "', '" + date.ToString("HH:mm:ss") + "', '" + username.ToString() + "', '" + action.ToString() + "', 'Account')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private int errorCount;
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                validateForm();
                if (errorCount == 0)
                {
                    string selectedusername =  username.ToString();
                    con.Open();
                    cmd = new MySqlCommand("UPDATE account SET ACCOUNT_USERNAME = '" + txtusername.Text + "', ACCOUNT_FULL_NAME = '" + txtfullname.Text + "', ACCOUNT_USERTYPE = '" + cmbusertype.Text + "'," +
                        "ACCOUNT_CONTACT_NUMBER = '" + txtcontact.Text + "' WHERE ACCOUNT_USERNAME = '" + txtusername.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Account Updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //insert logs//
                    logs();

                    this.Hide();
                    manageaccount updateacc = (manageaccount)Application.OpenForms["manageaccount"];
                    updateacc.refresh();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void validateForm()
        {
            errorProvider1.Clear();
            errorCount = 0;
            if (string.IsNullOrEmpty(txtfullname.Text))
            {
                errorProvider1.SetError(txtfullname, "This field cannot be empty");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtcontact.Text))
            {
                errorProvider1.SetError(txtcontact, "This field cannot be empty");
                errorCount++;
            }
            if (cmbusertype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbusertype, "Please select a position");
                errorCount++;
            }
        }

        DateTime date = DateTime.Now;
        public updateaccount(string Username, string Usertype, string Full_Name, string Cell_Number, string username)
        {
            InitializeComponent();
            con = new MySqlConnection();
            con.ConnectionString = data.getConnection();
            this.Username = Username;
            this.Usertype = Usertype;
            this.Full_Name = Full_Name;
            this.Cell_Number = Cell_Number;
            this.username = username;

        }
    }
}
