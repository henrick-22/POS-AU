using MySql.Data.MySqlClient;
using NEW_POS;
using NEW_POS.Administration_related.accounts;
using NEW_POS.category_settings;
using NEW_POS.POS;
using NEW_POS.Products;
using NEW_POS.Income;
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
        MySqlDataAdapter adpt;
        DataTable dt;
        MySqlCommand cmd;
        MainConnection data = new MainConnection();
        public Point mouseLocation;

        //constructor
        public formmain(string username,string usertype)
        {
            InitializeComponent();
            this.username = username;
            this.usertype = usertype;
            cn = new MySqlConnection();
            cn.ConnectionString = data.getConnection();
            random = new Random();
        }

        private void formmain_Load(object sender, EventArgs e)
        {
            loadResource();
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

        private void btnPOS_Click(object sender, EventArgs e)
        {
            
            try
            {

                pointofsale pos = new pointofsale(lblUsername.Text, lblUsertype.Text) { TopLevel = false, TopMost = true, Dock = DockStyle.Fill };
                this.pContainer.Controls.Add(pos);
                pos.BringToFront();
                
                dt = new DataTable();
                adpt = new MySqlDataAdapter("SELECT * FROM temp_pay", cn);
                adpt.Fill(dt);
                pos.dgv_Orderlist.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    pos.Show();
                    
                    DialogResult answer = MessageBox.Show("Are you sure want delete this data?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes)
                    {
                        cn.Open();
                        cmd = new MySqlCommand("DELETE FROM temp_pay", cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        pointofsale ps = (pointofsale)Application.OpenForms["pointofsale"];
                        ps.refresh();


                    }
                }
                else
                {
                    pos.Show();
                    
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error on btnpos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            formproducts prod = new formproducts(lblUsername.Text, lblUsertype.Text) { TopLevel = false, TopMost = true, Dock = DockStyle.Fill };
            this.pContainer.Controls.Add(prod);
            prod.BringToFront();
            prod.Show();
            activateButton(sender);
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            //working...
            //activateButton(sender);
            openChildForm(new salesreportsincome(), sender);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            //working...
            //activateButton(sender);
            openChildForm(new formabout(), sender);
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            manageaccount manacc = new manageaccount(this, lblUsername.Text, lblUsertype.Text) { TopLevel = false, TopMost = true, Dock = DockStyle.Fill };
            this.pContainer.Controls.Add(manacc);
            manacc.BringToFront();
            manacc.Show();
            activateButton(sender);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            formcategory cat = new formcategory(lblUsername.Text) { TopLevel = false, TopMost = true, Dock = DockStyle.Fill };
            this.pContainer.Controls.Add(cat);
            cat.BringToFront();
            cat.Show();
            activateButton(sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            formlogin login = new formlogin();
            this.Close();
            login.Show();
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
                lblUsername.Text = username;
                lblUsertype.Text = usertype;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Load Resource", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        //methods
        private Color selectThemeColor()
        {
            int index = random.Next(themeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(themeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = themeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void activateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    disableButton();
                    Color color = selectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI Black", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    pnlTitleBar.BackColor = color;
                    pnlLogo.BackColor = themeColor.ChangeColorBrightness(color, -0.3);
                    //pnlDecriptionBar.BackColor = color;
                    themeColor.PrimaryColor = color;
                    themeColor.SecondaryColor = themeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        private void disableButton()
        {
            foreach (Control previousBtn in pnlMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void openChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pContainer.Controls.Add(childForm);
            this.pContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lblTitle.Text = childForm.Text;
        }
    }
}
