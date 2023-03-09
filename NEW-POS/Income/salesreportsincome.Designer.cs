
namespace NEW_POS.Income
{
    partial class salesreportsincome
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
            this.lblSalesReports = new System.Windows.Forms.Label();
            this.lblWorking = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSalesReports
            // 
            this.lblSalesReports.AutoSize = true;
            this.lblSalesReports.BackColor = System.Drawing.Color.Transparent;
            this.lblSalesReports.Font = new System.Drawing.Font("Segoe UI Black", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesReports.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSalesReports.Location = new System.Drawing.Point(112, 120);
            this.lblSalesReports.Name = "lblSalesReports";
            this.lblSalesReports.Size = new System.Drawing.Size(540, 86);
            this.lblSalesReports.TabIndex = 10;
            this.lblSalesReports.Text = "SALES REPORTS";
            this.lblSalesReports.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorking
            // 
            this.lblWorking.AutoSize = true;
            this.lblWorking.BackColor = System.Drawing.Color.Transparent;
            this.lblWorking.Font = new System.Drawing.Font("Segoe UI Black", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorking.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWorking.Location = new System.Drawing.Point(172, 206);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(423, 86);
            this.lblWorking.TabIndex = 11;
            this.lblWorking.Text = "Working . . .";
            this.lblWorking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(200, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(365, 56);
            this.button1.TabIndex = 12;
            this.button1.Text = "BUTTON";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // salesreportsincome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(801, 500);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblWorking);
            this.Controls.Add(this.lblSalesReports);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "salesreportsincome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "salesreportsincome";
            this.Load += new System.EventHandler(this.salesreportsincome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSalesReports;
        private System.Windows.Forms.Label lblWorking;
        private System.Windows.Forms.Button button1;
    }
}