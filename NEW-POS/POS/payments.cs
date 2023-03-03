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

namespace NEW_POS.POS
{
    public partial class payments : Form
    {
        public String[][] Productsqty = { }; public int quantityLess = 0;

        private string totalItems, transtype, transactiontype;
        private string totalCost, discount;
        int errorCount = 0;
        string transnumber;
        DateTime date = DateTime.Now;
        MainConnection data = new MainConnection();
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        pointofsale ps;
        formmain fm;
        string username, action;
        string productname, productquantity;

        

        string qty;
        int decrement1;
        public payments(string totalItems, string discount, string totalCost, pointofsale ps, String username, formmain fm, String action)
        {
            InitializeComponent();
            //
            cn = new MySqlConnection();
            cn.ConnectionString = data.getConnection();
            //
            this.totalItems = totalItems;
            this.discount = discount;
            this.totalCost = totalCost;
            
            this.ps = ps;
            
            this.username = username;
            this.fm = fm;
            this.action = action;
            getValue();
            
        }
        public void getValue()
        {
            txtTotalItems.Text = totalItems.ToString();
            txtDiscounts.Text = discount.ToString();
            txtTotalCost.Text = totalCost.ToString();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}
