namespace ERP
{
    partial class uctxt
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
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt.Location = new System.Drawing.Point(1, 1);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(204, 13);
            this.txt.TabIndex = 0;
            this.txt.Tag = "Text";
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
            this.lblRequire.Location = new System.Drawing.Point(147, 1);
            this.lblRequire.Margin = new System.Windows.Forms.Padding(0);
            this.lblRequire.Name = "lblRequire";
            this.lblRequire.Size = new System.Drawing.Size(48, 18);
            this.lblRequire.TabIndex = 1;
            this.lblRequire.Text = "Need";
            this.lblRequire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uctxt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.lblRequire);
            this.Controls.Add(this.txt);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "uctxt";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(206, 26);
            this.Tag = " ";
            this.Load += new System.EventHandler(this.uctxt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txt;
        public System.Windows.Forms.Label lblRequire;
    }
}
