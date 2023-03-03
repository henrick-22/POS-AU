using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_POS.POS
{
    public partial class quantityform : Form
    {
        
        
        public int a = 0;
        private string quantity1;
        public static string quantity;
        public quantityform(string quantity)
        {
            InitializeComponent();
            this.quantity1 = quantity;
            
            
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            a++;
            txtnum.Text = a.ToString();
        }

        private void btnsub_Click(object sender, EventArgs e)
        {

            int x = Convert.ToInt32(txtnum.Text);

            if (x <= 1)
            {

            }
            else
            {
                a--;
                txtnum.Text = a.ToString();
            }
        }
        

        private void buttonsave_Click(object sender, EventArgs e)
        {
            quantity = txtnum.Text;
            quantity = quantity.Replace("0", String.Empty);
            this.Close();
            

            
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            quantity = "";
            this.Close();
        }

    }
}
