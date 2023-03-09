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
    public partial class formabout : Form
    {
        public formabout()
        {
            InitializeComponent();
        }

        private void formabout_Load(object sender, EventArgs e)
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
            lblAbout.ForeColor = themeColor.SecondaryColor;
            lblWorking.ForeColor = themeColor.PrimaryColor;
        }
    }
}
