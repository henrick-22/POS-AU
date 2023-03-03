
namespace NEW_POS.POS
{
    partial class payments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(payments));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnexit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalItems = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnExact = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.txtTotalPaying = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtDiscounts = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtTotalCost = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtRemainingBalance = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSubmit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(120)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 51);
            this.panel1.TabIndex = 6;
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.Red;
            this.btnexit.BackgroundImage = global::NEW_POS.Properties.Resources.close;
            this.btnexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Location = new System.Drawing.Point(658, 10);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(30, 25);
            this.btnexit.TabIndex = 3;
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NEW_POS.Properties.Resources.icons8_food_receiver_48;
            this.pictureBox1.Location = new System.Drawing.Point(12, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHECKOUT";
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.Location = new System.Drawing.Point(12, 99);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(307, 29);
            this.txtAmount.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtAmount.StateActive.Border.Rounding = 10;
            this.txtAmount.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 60;
            this.label3.Text = "AMOUNT";
            // 
            // txtTotalItems
            // 
            this.txtTotalItems.Enabled = false;
            this.txtTotalItems.Location = new System.Drawing.Point(13, 173);
            this.txtTotalItems.Multiline = true;
            this.txtTotalItems.Name = "txtTotalItems";
            this.txtTotalItems.Size = new System.Drawing.Size(307, 50);
            this.txtTotalItems.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtTotalItems.StateActive.Border.Rounding = 10;
            this.txtTotalItems.TabIndex = 61;
            this.txtTotalItems.Text = "Total Items";
            // 
            // btnExact
            // 
            this.btnExact.CheckedState.Parent = this.btnExact;
            this.btnExact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExact.CustomImages.Parent = this.btnExact;
            this.btnExact.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(182)))), ((int)(((byte)(33)))));
            this.btnExact.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExact.ForeColor = System.Drawing.Color.White;
            this.btnExact.HoverState.Parent = this.btnExact;
            this.btnExact.Image = ((System.Drawing.Image)(resources.GetObject("btnExact.Image")));
            this.btnExact.Location = new System.Drawing.Point(18, 139);
            this.btnExact.Name = "btnExact";
            this.btnExact.ShadowDecoration.Parent = this.btnExact;
            this.btnExact.Size = new System.Drawing.Size(100, 28);
            this.btnExact.TabIndex = 62;
            this.btnExact.Text = "Exact";
            // 
            // btnClear
            // 
            this.btnClear.CheckedState.Parent = this.btnClear;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.CustomImages.Parent = this.btnClear;
            this.btnClear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(71)))), ((int)(((byte)(72)))));
            this.btnClear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.HoverState.Parent = this.btnClear;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(126, 139);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShadowDecoration.Parent = this.btnClear;
            this.btnClear.Size = new System.Drawing.Size(100, 28);
            this.btnClear.TabIndex = 63;
            this.btnClear.Text = "Clear";
            // 
            // txtTotalPaying
            // 
            this.txtTotalPaying.Enabled = false;
            this.txtTotalPaying.Location = new System.Drawing.Point(13, 229);
            this.txtTotalPaying.Multiline = true;
            this.txtTotalPaying.Name = "txtTotalPaying";
            this.txtTotalPaying.Size = new System.Drawing.Size(307, 50);
            this.txtTotalPaying.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtTotalPaying.StateActive.Border.Rounding = 10;
            this.txtTotalPaying.TabIndex = 64;
            this.txtTotalPaying.Text = "Total Paying";
            // 
            // txtDiscounts
            // 
            this.txtDiscounts.Enabled = false;
            this.txtDiscounts.Location = new System.Drawing.Point(326, 173);
            this.txtDiscounts.Multiline = true;
            this.txtDiscounts.Name = "txtDiscounts";
            this.txtDiscounts.Size = new System.Drawing.Size(307, 50);
            this.txtDiscounts.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtDiscounts.StateActive.Border.Rounding = 10;
            this.txtDiscounts.TabIndex = 65;
            this.txtDiscounts.Text = "Discounts";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Enabled = false;
            this.txtTotalCost.Location = new System.Drawing.Point(326, 229);
            this.txtTotalCost.Multiline = true;
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Size = new System.Drawing.Size(307, 50);
            this.txtTotalCost.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtTotalCost.StateActive.Border.Rounding = 10;
            this.txtTotalCost.TabIndex = 66;
            this.txtTotalCost.Text = "Total Cost";
            // 
            // txtRemainingBalance
            // 
            this.txtRemainingBalance.Enabled = false;
            this.txtRemainingBalance.Location = new System.Drawing.Point(13, 285);
            this.txtRemainingBalance.Multiline = true;
            this.txtRemainingBalance.Name = "txtRemainingBalance";
            this.txtRemainingBalance.Size = new System.Drawing.Size(307, 38);
            this.txtRemainingBalance.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtRemainingBalance.StateActive.Border.Rounding = 10;
            this.txtRemainingBalance.TabIndex = 67;
            this.txtRemainingBalance.Text = "Remaining Balance";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(21, 340);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(97, 44);
            this.btnSubmit.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSubmit.StateCommon.Border.Rounding = 10;
            this.btnSubmit.TabIndex = 68;
            this.btnSubmit.Values.Text = "SUBMIT";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(688, 402);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtRemainingBalance);
            this.Controls.Add(this.txtTotalCost);
            this.Controls.Add(this.txtDiscounts);
            this.Controls.Add(this.txtTotalPaying);
            this.Controls.Add(this.btnExact);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtTotalItems);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "payments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "payments";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTotalItems;
        private Guna.UI2.WinForms.Guna2Button btnExact;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTotalPaying;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDiscounts;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTotalCost;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRemainingBalance;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSubmit;
        private System.Windows.Forms.Button btnexit;
    }
}