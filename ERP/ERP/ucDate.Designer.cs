namespace ERP
{
    partial class ucDate
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
            this.date = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // date
            // 
            this.date.CalendarForeColor = System.Drawing.Color.Black;
            this.date.CalendarMonthBackground = System.Drawing.Color.Cyan;
            this.date.CalendarTitleBackColor = System.Drawing.Color.Cyan;
            this.date.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.date.CalendarTrailingForeColor = System.Drawing.Color.Black;
            this.date.CustomFormat = "dd/MM/yyyy";
            this.date.Dock = System.Windows.Forms.DockStyle.Top;
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(1, 1);
            this.date.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(265, 22);
            this.date.TabIndex = 0;
            this.date.ValueChanged += new System.EventHandler(this.date_ValueChanged);
            this.date.Enter += new System.EventHandler(this.dtpFDate_Enter);
            this.date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFDate_KeyPress);
            this.date.Leave += new System.EventHandler(this.dtpFDate_Leave);
            // 
            // ucDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.date);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDate";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(267, 41);
            this.Load += new System.EventHandler(this.ucDate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DateTimePicker date;
    }
}
