using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_POS.Income
{
    public partial class salesreportsincome : Form
    {
        public salesreportsincome()
        {
            InitializeComponent();
        }

        private void salesreportsincome_Load(object sender, EventArgs e)
        {
            loadTheme();
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
            lblSalesReports.ForeColor = themeColor.SecondaryColor;
            lblWorking.ForeColor = themeColor.PrimaryColor;
        }
    }
}
