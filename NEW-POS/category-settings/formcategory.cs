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

namespace NEW_POS.category_settings
{
    public partial class formcategory : Form
    {
        MainConnection data = new MainConnection();
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter adpt;
        string action, category, form;
        string action1;
        DataTable dt;
        string username;

        private void formcategory_Load(object sender, EventArgs e)
        {
            loadform();
            loadTheme();
        }
        public formcategory(string username)
        {
            InitializeComponent();
            con = new MySqlConnection();
            con.ConnectionString = data.getConnection();
            this.username = username;
        }

        public void loadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = themeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = themeColor.SecondaryColor;
                }
            }
        }

        private void loadform()
        {
            try
            {
                dt = new DataTable();
                adpt = new MySqlDataAdapter("select SETTINGS_FORM,SETTINGS_CATEGORY from settings", con);
                adpt.Fill(dt);
                dgvCategory.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
