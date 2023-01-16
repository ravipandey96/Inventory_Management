namespace ERP
{
    partial class ucSearchList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt = new System.Windows.Forms.TextBox();
            this.lblRequire = new System.Windows.Forms.Label();
            this.lstName = new System.Windows.Forms.ListBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt.Location = new System.Drawing.Point(1, 1);
            this.txt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(273, 15);
            this.txt.TabIndex = 0;
            this.txt.Tag = " ";
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txt.Enter += new System.EventHandler(this.txt_Enter);
            this.txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txt.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // lblRequire
            // 
            this.lblRequire.BackColor = System.Drawing.Color.DeepPink;
            this.lblRequire.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequire.ForeColor = System.Drawing.Color.Transparent;
            this.lblRequire.Location = new System.Drawing.Point(196, 1);
            this.lblRequire.Margin = new System.Windows.Forms.Padding(0);
            this.lblRequire.Name = "lblRequire";
            this.lblRequire.Size = new System.Drawing.Size(64, 22);
            this.lblRequire.TabIndex = 1;
            this.lblRequire.Text = "Need";
            this.lblRequire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstName
            // 
            this.lstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstName.ItemHeight = 16;
            this.lstName.Location = new System.Drawing.Point(44, 25);
            this.lstName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstName.Name = "lstName";
            this.lstName.Size = new System.Drawing.Size(263, 210);
            this.lstName.Sorted = true;
            this.lstName.TabIndex = 72;
            this.lstName.TabStop = false;
            this.lstName.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(5, 12);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(30, 22);
            this.txtCode.TabIndex = 73;
            this.txtCode.TabStop = false;
            this.txtCode.Visible = false;
            // 
            // ucSearchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.HotPink;
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lstName);
            this.Controls.Add(this.lblRequire);
            this.Controls.Add(this.txt);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucSearchList";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(275, 43);
            this.Tag = " ";
            this.Load += new System.EventHandler(this.uctxt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txt;
        public System.Windows.Forms.ListBox lstName;
        public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.Label lblRequire;
    }
}
