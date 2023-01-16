namespace ERP
{
    partial class frmExport
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
            this.lblBorderBottom = new System.Windows.Forms.Label();
            this.lblTitleBar = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblBorderRight = new System.Windows.Forms.Label();
            this.lblBorderLeft = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblWait = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.chkSale = new System.Windows.Forms.CheckBox();
            this.chkSaleReturn = new System.Windows.Forms.CheckBox();
            this.chkPurchase = new System.Windows.Forms.CheckBox();
            this.chkPurchaseReturn = new System.Windows.Forms.CheckBox();
            this.chkProduction = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uTo = new ERP.ucDate();
            this.uFrom = new ERP.ucDate();
            this.SuspendLayout();
            // 
            // lblBorderBottom
            // 
            this.lblBorderBottom.AutoEllipsis = true;
            this.lblBorderBottom.BackColor = System.Drawing.Color.Aqua;
            this.lblBorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBorderBottom.Location = new System.Drawing.Point(0, 339);
            this.lblBorderBottom.Name = "lblBorderBottom";
            this.lblBorderBottom.Size = new System.Drawing.Size(383, 2);
            this.lblBorderBottom.TabIndex = 7;
            this.lblBorderBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBorderBottom.UseCompatibleTextRendering = true;
            // 
            // lblTitleBar
            // 
            this.lblTitleBar.AutoEllipsis = true;
            this.lblTitleBar.BackColor = System.Drawing.Color.Aqua;
            this.lblTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleBar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleBar.ForeColor = System.Drawing.Color.Black;
            this.lblTitleBar.Location = new System.Drawing.Point(0, 0);
            this.lblTitleBar.Name = "lblTitleBar";
            this.lblTitleBar.Size = new System.Drawing.Size(383, 28);
            this.lblTitleBar.TabIndex = 8;
            this.lblTitleBar.Text = "Export";
            this.lblTitleBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleBar.UseCompatibleTextRendering = true;
            this.lblTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitleBar_MouseDown);
            this.lblTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitleBar_MouseMove);
            this.lblTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitleBar_MouseUp);
            // 
            // lblMin
            // 
            this.lblMin.AutoEllipsis = true;
            this.lblMin.BackColor = System.Drawing.Color.Cyan;
            this.lblMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMin.Image = global::ERP.Properties.Resources.minimize_window_32px;
            this.lblMin.Location = new System.Drawing.Point(323, 3);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(24, 24);
            this.lblMin.TabIndex = 1;
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMin.UseCompatibleTextRendering = true;
            this.lblMin.Click += new System.EventHandler(this.lblMin_Click);
            // 
            // lblBorderRight
            // 
            this.lblBorderRight.AutoEllipsis = true;
            this.lblBorderRight.BackColor = System.Drawing.Color.Aqua;
            this.lblBorderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBorderRight.Location = new System.Drawing.Point(381, 28);
            this.lblBorderRight.Name = "lblBorderRight";
            this.lblBorderRight.Size = new System.Drawing.Size(2, 311);
            this.lblBorderRight.TabIndex = 12;
            this.lblBorderRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBorderRight.UseCompatibleTextRendering = true;
            // 
            // lblBorderLeft
            // 
            this.lblBorderLeft.AutoEllipsis = true;
            this.lblBorderLeft.BackColor = System.Drawing.Color.Aqua;
            this.lblBorderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblBorderLeft.Location = new System.Drawing.Point(0, 28);
            this.lblBorderLeft.Name = "lblBorderLeft";
            this.lblBorderLeft.Size = new System.Drawing.Size(2, 311);
            this.lblBorderLeft.TabIndex = 0;
            this.lblBorderLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBorderLeft.UseCompatibleTextRendering = true;
            // 
            // lblMax
            // 
            this.lblMax.AutoEllipsis = true;
            this.lblMax.BackColor = System.Drawing.Color.Cyan;
            this.lblMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMax.Image = global::ERP.Properties.Resources.stop_32px;
            this.lblMax.Location = new System.Drawing.Point(296, 3);
            this.lblMax.Margin = new System.Windows.Forms.Padding(0);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(24, 24);
            this.lblMax.TabIndex = 0;
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMax.UseCompatibleTextRendering = true;
            this.lblMax.Visible = false;
            this.lblMax.Click += new System.EventHandler(this.lblMax_Click);
            // 
            // lblClose
            // 
            this.lblClose.AutoEllipsis = true;
            this.lblClose.BackColor = System.Drawing.Color.Cyan;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Image = global::ERP.Properties.Resources.close_window_32px;
            this.lblClose.Location = new System.Drawing.Point(353, 3);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(24, 24);
            this.lblClose.TabIndex = 2;
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.UseCompatibleTextRendering = true;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWait.Location = new System.Drawing.Point(140, 256);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(98, 16);
            this.lblWait.TabIndex = 82;
            this.lblWait.Text = "Please wait ...";
            this.lblWait.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Turquoise;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(205, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Turquoise;
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnShow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(104, 292);
            this.btnShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(72, 28);
            this.btnShow.TabIndex = 8;
            this.btnShow.Text = "Export";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // chkSale
            // 
            this.chkSale.AutoSize = true;
            this.chkSale.Checked = true;
            this.chkSale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSale.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSale.Location = new System.Drawing.Point(50, 47);
            this.chkSale.Name = "chkSale";
            this.chkSale.Size = new System.Drawing.Size(62, 20);
            this.chkSale.TabIndex = 1;
            this.chkSale.Text = "Sales";
            this.chkSale.UseVisualStyleBackColor = true;
            // 
            // chkSaleReturn
            // 
            this.chkSaleReturn.AutoSize = true;
            this.chkSaleReturn.Checked = true;
            this.chkSaleReturn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaleReturn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaleReturn.Location = new System.Drawing.Point(50, 73);
            this.chkSaleReturn.Name = "chkSaleReturn";
            this.chkSaleReturn.Size = new System.Drawing.Size(108, 20);
            this.chkSaleReturn.TabIndex = 2;
            this.chkSaleReturn.Text = "Sales Return";
            this.chkSaleReturn.UseVisualStyleBackColor = true;
            // 
            // chkPurchase
            // 
            this.chkPurchase.AutoSize = true;
            this.chkPurchase.Checked = true;
            this.chkPurchase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPurchase.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPurchase.Location = new System.Drawing.Point(50, 99);
            this.chkPurchase.Name = "chkPurchase";
            this.chkPurchase.Size = new System.Drawing.Size(86, 20);
            this.chkPurchase.TabIndex = 3;
            this.chkPurchase.Text = "Purchase";
            this.chkPurchase.UseVisualStyleBackColor = true;
            // 
            // chkPurchaseReturn
            // 
            this.chkPurchaseReturn.AutoSize = true;
            this.chkPurchaseReturn.Checked = true;
            this.chkPurchaseReturn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPurchaseReturn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPurchaseReturn.Location = new System.Drawing.Point(50, 125);
            this.chkPurchaseReturn.Name = "chkPurchaseReturn";
            this.chkPurchaseReturn.Size = new System.Drawing.Size(132, 20);
            this.chkPurchaseReturn.TabIndex = 4;
            this.chkPurchaseReturn.Text = "Purchase Return";
            this.chkPurchaseReturn.UseVisualStyleBackColor = true;
            // 
            // chkProduction
            // 
            this.chkProduction.AutoSize = true;
            this.chkProduction.Checked = true;
            this.chkProduction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProduction.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProduction.Location = new System.Drawing.Point(50, 151);
            this.chkProduction.Name = "chkProduction";
            this.chkProduction.Size = new System.Drawing.Size(96, 20);
            this.chkProduction.TabIndex = 5;
            this.chkProduction.Text = "Production";
            this.chkProduction.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(205, 205);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 16);
            this.label7.TabIndex = 91;
            this.label7.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 205);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 90;
            this.label6.Text = "From";
            // 
            // uTo
            // 
            this.uTo.BackColor = System.Drawing.Color.Cyan;
            this.uTo.Location = new System.Drawing.Point(242, 202);
            this.uTo.Margin = new System.Windows.Forms.Padding(0);
            this.uTo.Name = "uTo";
            this.uTo.Padding = new System.Windows.Forms.Padding(1);
            this.uTo.Size = new System.Drawing.Size(94, 25);
            this.uTo.TabIndex = 7;
            // 
            // uFrom
            // 
            this.uFrom.BackColor = System.Drawing.Color.Cyan;
            this.uFrom.Location = new System.Drawing.Point(97, 202);
            this.uFrom.Margin = new System.Windows.Forms.Padding(0);
            this.uFrom.Name = "uFrom";
            this.uFrom.Padding = new System.Windows.Forms.Padding(1);
            this.uFrom.Size = new System.Drawing.Size(94, 25);
            this.uFrom.TabIndex = 6;
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 341);
            this.ControlBox = false;
            this.Controls.Add(this.uTo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.uFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkProduction);
            this.Controls.Add(this.chkPurchaseReturn);
            this.Controls.Add(this.chkPurchase);
            this.Controls.Add(this.chkSaleReturn);
            this.Controls.Add(this.chkSale);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblBorderLeft);
            this.Controls.Add(this.lblBorderRight);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblBorderBottom);
            this.Controls.Add(this.lblTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Export";
            this.Load += new System.EventHandler(this.frmUnit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBrand_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmUnit_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBorderBottom;
        private System.Windows.Forms.Label lblTitleBar;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblBorderRight;
        private System.Windows.Forms.Label lblBorderLeft;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblWait;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.CheckBox chkSale;
        private System.Windows.Forms.CheckBox chkSaleReturn;
        private System.Windows.Forms.CheckBox chkPurchase;
        private System.Windows.Forms.CheckBox chkPurchaseReturn;
        private System.Windows.Forms.CheckBox chkProduction;
        private ucDate uTo;
        private System.Windows.Forms.Label label7;
        private ucDate uFrom;
        private System.Windows.Forms.Label label6;
    }
}