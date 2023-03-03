using MySql.Data.MySqlClient;
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

namespace NEW_POS.Administration_related.accounts
{
    public partial class manageaccount : Form
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
        DataTable dt;
        formmain fm;

        DateTime date = DateTime.Now;
        string username;
        string usertype;
        string selectedusername;
        public manageaccount(formmain fm,string username,string usertype)
        {
            InitializeComponent();
            con = new MySqlConnection();
            con.ConnectionString = data.getConnection();
            this.username = username;
            this.usertype = usertype;
            this.fm = fm;

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
        public int row = -1;
        private void manageaccount_Load(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                adpt = new MySqlDataAdapter("select ACCOUNT_USERNAME, ACCOUNT_PASSWORD, ACCOUNT_STATUS, ACCOUNT_USERTYPE, ACCOUNT_FULL_NAME, ACCOUNT_CONTACT_NUMBER from account", con);
                adpt.Fill(dt);
                dgvProducts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void incrementrefresh()
        {
            dt = new DataTable();
            adpt = new MySqlDataAdapter("SELECT * FROM account", con);
            adpt.Fill(dt);
            dgvProducts.DataSource = dt;
            addaccount auto = (addaccount)Application.OpenForms["addaccount"];

        }
        public void refresh()
        {
            dt = new DataTable();
            adpt = new MySqlDataAdapter("SELECT * FROM account", con);
            adpt.Fill(dt);
            dgvProducts.DataSource = dt;
        }
        public void logs()
        {
            string action = "Updated Existing Account ID:" + selectedusername.ToString() + " by: " + username.ToString();
            con.Open();
            cmd = new MySqlCommand("Insert into logs (datelog, timelog, full_name, action, module)" +
                "Values('" + date.ToString("yyyy-MM-dd") + "', '" + date.ToString("HH:mm:ss") + "', '" + username.ToString() + "', '" + action.ToString() + "', 'Account')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void dgvaccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                row = e.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                adpt = new MySqlDataAdapter("select ACCOUNT_USERNAME, ACCOUNT_PASSWORD, ACCOUNT_STATUS, ACCOUNT_USERTYPE, ACCOUNT_FULL_NAME, ACCOUNT_CONTACT_NUMBER " +
                    "FROM account WHERE ACCOUNT_USERNAME LIKE '%" + txtsearch.Text + "%' OR ACCOUNT_FULL_NAME LIKE '%" + txtsearch.Text + "%' ORDER BY ACCOUNT_USERNAME", con);
                adpt.Fill(dt);
                dgvProducts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on search by name or username", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            addaccount addacc = new addaccount("", "", "", "", username);
            addacc.ShowDialog();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            string edit_username, edit_usertype, edit_fullname, edit_cellnumber;
            try
            {
                edit_username = dgvProducts.Rows[row].Cells[0].Value.ToString();
                edit_usertype = dgvProducts.Rows[row].Cells[3].Value.ToString();
                edit_fullname = dgvProducts.Rows[row].Cells[4].Value.ToString();
                edit_cellnumber = dgvProducts.Rows[row].Cells[5].Value.ToString();
                updateaccount updateacc = new updateaccount(edit_username,edit_usertype, edit_fullname, edit_cellnumber, username);
                updateacc.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Update Button", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btndelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                selectedusername = dgvProducts.Rows[row].Cells[0].Value.ToString();
                string selectedName = dgvProducts.Rows[row].Cells[1].Value.ToString();
                if (DialogResult.Yes == MessageBox.Show("Do you want to delete this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    con.Open();
                    cmd = new MySqlCommand("DELETE FROM account WHERE ACCOUNT_USERNAME = '" + selectedusername + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Account Deleted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //insertlogs//
                    logs();

                    manageaccount delete = (manageaccount)Application.OpenForms["manageaccount"];
                    delete.refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
