namespace ERP
{
    partial class uTime
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
            this.date.Dock = System.Windows.Forms.DockStyle.Top;
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.date.Location = new System.Drawing.Point(0, 0);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(172, 20);
            this.date.TabIndex = 1;
            // 
            // uTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.date);
            this.Name = "uTime";
            this.Size = new System.Drawing.Size(172, 27);
            this.Load += new System.EventHandler(this.uTime_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DateTimePicker date;
    }
}
