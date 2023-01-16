namespace ERP
{
    partial class frmOpening
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblBorderBottom = new System.Windows.Forms.Label();
            this.lblTitleBar = new System.Windows.Forms.Label();
            this.lblBorderRight = new System.Windows.Forms.Label();
            this.lblBorderLeft = new System.Windows.Forms.Label();
            this.pbase = new System.Windows.Forms.Panel();
            this.lblRegular = new System.Windows.Forms.Label();
            this.lblBIS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.pList = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.uTo = new ERP.ucDate();
            this.uFrom = new ERP.ucDate();
            this.usTypeItem = new ERP.ucSearchList();
            this.uSearch = new ERP.uctxt();
            this.usItemType = new ERP.ucSearchList();
            this.usItem = new ERP.ucSearchList();
            this.uctxtRegular = new ERP.uctxt();
            this.uctxtBIS = new ERP.uctxt();
            this.uctxtRate = new ERP.uctxt();
            this.uctxtINo = new ERP.uctxt();
            this.uDate = new ERP.ucDate();
            this.uctxtSNo = new ERP.uctxt();
            this.pbase.SuspendLayout();
            this.pList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBorderBottom
            // 
            this.lblBorderBottom.AutoEllipsis = true;
            this.lblBorderBottom.BackColor = System.Drawing.Color.Aqua;
            this.lblBorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBorderBottom.Location = new System.Drawing.Point(0, 548);
            this.lblBorderBottom.Name = "lblBorderBottom";
            this.lblBorderBottom.Size = new System.Drawing.Size(659, 2);
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
            this.lblTitleBar.Size = new System.Drawing.Size(659, 28);
            this.lblTitleBar.TabIndex = 8;
            this.lblTitleBar.Text = "Item Opening Stock";
            this.lblTitleBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleBar.UseCompatibleTextRendering = true;
            this.lblTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitleBar_MouseDown);
            this.lblTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitleBar_MouseMove);
            this.lblTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitleBar_MouseUp);
            // 
            // lblBorderRight
            // 
            this.lblBorderRight.AutoEllipsis = true;
            this.lblBorderRight.BackColor = System.Drawing.Color.Aqua;
            this.lblBorderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBorderRight.Location = new System.Drawing.Point(657, 28);
            this.lblBorderRight.Name = "lblBorderRight";
            this.lblBorderRight.Size = new System.Drawing.Size(2, 520);
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
            this.lblBorderLeft.Size = new System.Drawing.Size(2, 520);
            this.lblBorderLeft.TabIndex = 13;
            this.lblBorderLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBorderLeft.UseCompatibleTextRendering = true;
            // 
            // pbase
            // 
            this.pbase.Controls.Add(this.usItemType);
            this.pbase.Controls.Add(this.usItem);
            this.pbase.Controls.Add(this.uctxtRegular);
            this.pbase.Controls.Add(this.lblRegular);
            this.pbase.Controls.Add(this.uctxtBIS);
            this.pbase.Controls.Add(this.lblBIS);
            this.pbase.Controls.Add(this.label3);
            this.pbase.Controls.Add(this.uctxtRate);
            this.pbase.Controls.Add(this.label2);
            this.pbase.Controls.Add(this.uctxtINo);
            this.pbase.Controls.Add(this.uDate);
            this.pbase.Controls.Add(this.label10);
            this.pbase.Controls.Add(this.uctxtSNo);
            this.pbase.Controls.Add(this.btnSave);
            this.pbase.Controls.Add(this.btnList);
            this.pbase.Controls.Add(this.lblName);
            this.pbase.Location = new System.Drawing.Point(80, 39);
            this.pbase.Name = "pbase";
            this.pbase.Size = new System.Drawing.Size(496, 311);
            this.pbase.TabIndex = 0;
            this.pbase.Paint += new System.Windows.Forms.PaintEventHandler(this.pbase_Paint);
            // 
            // lblRegular
            // 
            this.lblRegular.AutoSize = true;
            this.lblRegular.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegular.Location = new System.Drawing.Point(10, 120);
            this.lblRegular.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegular.Name = "lblRegular";
            this.lblRegular.Size = new System.Drawing.Size(59, 17);
            this.lblRegular.TabIndex = 81;
            this.lblRegular.Text = "Regular";
            // 
            // lblBIS
            // 
            this.lblBIS.AutoSize = true;
            this.lblBIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBIS.Location = new System.Drawing.Point(280, 120);
            this.lblBIS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBIS.Name = "lblBIS";
            this.lblBIS.Size = new System.Drawing.Size(74, 18);
            this.lblBIS.TabIndex = 80;
            this.lblBIS.Text = "BIS Stock";
            this.lblBIS.Click += new System.EventHandler(this.label8_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 79;
            this.label3.Text = "Item Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 77;
            this.label2.Text = "Rate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 17);
            this.label10.TabIndex = 74;
            this.label10.Text = "Item Description";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Turquoise;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(150, 243);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.Turquoise;
            this.btnList.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(258, 243);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(77, 28);
            this.btnList.TabIndex = 8;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(11, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 17);
            this.lblName.TabIndex = 58;
            this.lblName.Text = "Op.Date";
            // 
            // pList
            // 
            this.pList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pList.Controls.Add(this.uTo);
            this.pList.Controls.Add(this.uFrom);
            this.pList.Controls.Add(this.label7);
            this.pList.Controls.Add(this.label6);
            this.pList.Controls.Add(this.label4);
            this.pList.Controls.Add(this.usTypeItem);
            this.pList.Controls.Add(this.btnDelete);
            this.pList.Controls.Add(this.uSearch);
            this.pList.Controls.Add(this.gList);
            this.pList.Controls.Add(this.btnShow);
            this.pList.Controls.Add(this.label1);
            this.pList.Location = new System.Drawing.Point(7, 353);
            this.pList.Margin = new System.Windows.Forms.Padding(0);
            this.pList.Name = "pList";
            this.pList.Size = new System.Drawing.Size(641, 195);
            this.pList.TabIndex = 1;
            this.pList.Visible = false;
            this.pList.Paint += new System.Windows.Forms.PaintEventHandler(this.pList_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(183, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 17);
            this.label7.TabIndex = 63;
            this.label7.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 13);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 61;
            this.label4.Text = "Item Type";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Turquoise;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(537, 58);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 26);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gList
            // 
            this.gList.AllowUserToAddRows = false;
            this.gList.AllowUserToDeleteRows = false;
            this.gList.AllowUserToResizeColumns = false;
            this.gList.AllowUserToResizeRows = false;
            this.gList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gList.BackgroundColor = System.Drawing.Color.White;
            this.gList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.gList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = " ";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gList.DefaultCellStyle = dataGridViewCellStyle2;
            this.gList.GridColor = System.Drawing.Color.DarkCyan;
            this.gList.Location = new System.Drawing.Point(3, 87);
            this.gList.MultiSelect = false;
            this.gList.Name = "gList";
            this.gList.ReadOnly = true;
            this.gList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gList.RowHeadersVisible = false;
            this.gList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gList.ShowEditingIcon = false;
            this.gList.Size = new System.Drawing.Size(632, 99);
            this.gList.TabIndex = 5;
            this.gList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gList_CellContentClick);
            this.gList.Click += new System.EventHandler(this.gList_Click);
            this.gList.DoubleClick += new System.EventHandler(this.gList_DoubleClick);
            this.gList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gList_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "SNo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "SNo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Turquoise;
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnShow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(348, 58);
            this.btnShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(82, 26);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 59;
            this.label1.Text = "Search";
            // 
            // lblMax
            // 
            this.lblMax.AutoEllipsis = true;
            this.lblMax.BackColor = System.Drawing.Color.Cyan;
            this.lblMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMax.Image = global::ERP.Properties.Resources.stop_32px;
            this.lblMax.Location = new System.Drawing.Point(487, 0);
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
            this.lblClose.Location = new System.Drawing.Point(544, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(24, 24);
            this.lblClose.TabIndex = 2;
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.UseCompatibleTextRendering = true;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblMin
            // 
            this.lblMin.AutoEllipsis = true;
            this.lblMin.BackColor = System.Drawing.Color.Cyan;
            this.lblMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMin.Image = global::ERP.Properties.Resources.minimize_window_32px;
            this.lblMin.Location = new System.Drawing.Point(514, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(24, 24);
            this.lblMin.TabIndex = 1;
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMin.UseCompatibleTextRendering = true;
            this.lblMin.Click += new System.EventHandler(this.lblMin_Click);
            // 
            // uTo
            // 
            this.uTo.BackColor = System.Drawing.Color.Cyan;
            this.uTo.Location = new System.Drawing.Point(219, 7);
            this.uTo.Margin = new System.Windows.Forms.Padding(0);
            this.uTo.Name = "uTo";
            this.uTo.Padding = new System.Windows.Forms.Padding(1);
            this.uTo.Size = new System.Drawing.Size(86, 25);
            this.uTo.TabIndex = 1;
            // 
            // uFrom
            // 
            this.uFrom.BackColor = System.Drawing.Color.Cyan;
            this.uFrom.Location = new System.Drawing.Point(86, 7);
            this.uFrom.Margin = new System.Windows.Forms.Padding(0);
            this.uFrom.Name = "uFrom";
            this.uFrom.Padding = new System.Windows.Forms.Padding(1);
            this.uFrom.Size = new System.Drawing.Size(86, 25);
            this.uFrom.TabIndex = 0;
            // 
            // usTypeItem
            // 
            this.usTypeItem.BackColor = System.Drawing.Color.Cyan;
            this.usTypeItem.Location = new System.Drawing.Point(86, 37);
            this.usTypeItem.Margin = new System.Windows.Forms.Padding(0);
            this.usTypeItem.Name = "usTypeItem";
            this.usTypeItem.Padding = new System.Windows.Forms.Padding(1);
            this.usTypeItem.Size = new System.Drawing.Size(219, 21);
            this.usTypeItem.TabIndex = 2;
            this.usTypeItem.Tag = " ";
            this.usTypeItem.Load += new System.EventHandler(this.usTypeItem_Load);
            this.usTypeItem.Leave += new System.EventHandler(this.usTypeItem_Leave);
            // 
            // uSearch
            // 
            this.uSearch.BackColor = System.Drawing.Color.Cyan;
            this.uSearch.Location = new System.Drawing.Point(86, 63);
            this.uSearch.Margin = new System.Windows.Forms.Padding(0);
            this.uSearch.Name = "uSearch";
            this.uSearch.Padding = new System.Windows.Forms.Padding(1);
            this.uSearch.Size = new System.Drawing.Size(219, 21);
            this.uSearch.TabIndex = 4;
            this.uSearch.Tag = " ";
            this.uSearch.TextChanged += new System.EventHandler(this.uSearch_TextChanged);
            this.uSearch.Load += new System.EventHandler(this.uSearch_Load);
            this.uSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uSearch_KeyDown);
            // 
            // usItemType
            // 
            this.usItemType.BackColor = System.Drawing.Color.Cyan;
            this.usItemType.Location = new System.Drawing.Point(131, 59);
            this.usItemType.Margin = new System.Windows.Forms.Padding(0);
            this.usItemType.Name = "usItemType";
            this.usItemType.Padding = new System.Windows.Forms.Padding(1);
            this.usItemType.Size = new System.Drawing.Size(125, 21);
            this.usItemType.TabIndex = 2;
            this.usItemType.Tag = " ";
            this.usItemType.Load += new System.EventHandler(this.usItemType_Load);
            this.usItemType.Leave += new System.EventHandler(this.usItemType_Leave);
            // 
            // usItem
            // 
            this.usItem.BackColor = System.Drawing.Color.Cyan;
            this.usItem.Location = new System.Drawing.Point(131, 89);
            this.usItem.Margin = new System.Windows.Forms.Padding(0);
            this.usItem.Name = "usItem";
            this.usItem.Padding = new System.Windows.Forms.Padding(1);
            this.usItem.Size = new System.Drawing.Size(352, 21);
            this.usItem.TabIndex = 3;
            this.usItem.Tag = " ";
            this.usItem.Load += new System.EventHandler(this.usType_Load);
            this.usItem.Leave += new System.EventHandler(this.usItem_Leave);
            // 
            // uctxtRegular
            // 
            this.uctxtRegular.BackColor = System.Drawing.Color.Cyan;
            this.uctxtRegular.Location = new System.Drawing.Point(131, 119);
            this.uctxtRegular.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtRegular.Name = "uctxtRegular";
            this.uctxtRegular.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtRegular.Size = new System.Drawing.Size(125, 21);
            this.uctxtRegular.TabIndex = 4;
            this.uctxtRegular.Tag = " ";
            this.uctxtRegular.Load += new System.EventHandler(this.uctxtRegular_Load);
            // 
            // uctxtBIS
            // 
            this.uctxtBIS.BackColor = System.Drawing.Color.Cyan;
            this.uctxtBIS.Location = new System.Drawing.Point(383, 119);
            this.uctxtBIS.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtBIS.Name = "uctxtBIS";
            this.uctxtBIS.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtBIS.Size = new System.Drawing.Size(100, 21);
            this.uctxtBIS.TabIndex = 5;
            this.uctxtBIS.Tag = " ";
            this.uctxtBIS.Load += new System.EventHandler(this.uctxt1_Load);
            // 
            // uctxtRate
            // 
            this.uctxtRate.BackColor = System.Drawing.Color.Cyan;
            this.uctxtRate.Location = new System.Drawing.Point(131, 149);
            this.uctxtRate.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtRate.Name = "uctxtRate";
            this.uctxtRate.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtRate.Size = new System.Drawing.Size(125, 21);
            this.uctxtRate.TabIndex = 6;
            this.uctxtRate.Tag = " ";
            // 
            // uctxtINo
            // 
            this.uctxtINo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtINo.Location = new System.Drawing.Point(264, 59);
            this.uctxtINo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtINo.Name = "uctxtINo";
            this.uctxtINo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtINo.Size = new System.Drawing.Size(22, 21);
            this.uctxtINo.TabIndex = 76;
            this.uctxtINo.Tag = " ";
            this.uctxtINo.Visible = false;
            // 
            // uDate
            // 
            this.uDate.BackColor = System.Drawing.Color.Cyan;
            this.uDate.Location = new System.Drawing.Point(131, 26);
            this.uDate.Margin = new System.Windows.Forms.Padding(0);
            this.uDate.Name = "uDate";
            this.uDate.Padding = new System.Windows.Forms.Padding(1);
            this.uDate.Size = new System.Drawing.Size(125, 25);
            this.uDate.TabIndex = 1;
            // 
            // uctxtSNo
            // 
            this.uctxtSNo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtSNo.Location = new System.Drawing.Point(131, 5);
            this.uctxtSNo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtSNo.Name = "uctxtSNo";
            this.uctxtSNo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtSNo.Size = new System.Drawing.Size(30, 21);
            this.uctxtSNo.TabIndex = 0;
            this.uctxtSNo.Tag = " ";
            this.uctxtSNo.Visible = false;
            // 
            // frmOpening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(659, 550);
            this.ControlBox = false;
            this.Controls.Add(this.pList);
            this.Controls.Add(this.pbase);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblBorderLeft);
            this.Controls.Add(this.lblBorderRight);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblBorderBottom);
            this.Controls.Add(this.lblTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmOpening";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Activated += new System.EventHandler(this.frmOpening_Activated);
            this.Load += new System.EventHandler(this.frmUnit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBrand_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmUnit_KeyPress);
            this.pbase.ResumeLayout(false);
            this.pbase.PerformLayout();
            this.pList.ResumeLayout(false);
            this.pList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBorderBottom;
        private System.Windows.Forms.Label lblTitleBar;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblBorderRight;
        private System.Windows.Forms.Label lblBorderLeft;
        private System.Windows.Forms.Panel pbase;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Label lblName;
        private uctxt uctxtSNo;
        private System.Windows.Forms.Panel pList;
        public System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gList;
        private uctxt uSearch;
        public System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.Label lblMax;
        private ucSearchList usItem;
        private System.Windows.Forms.Label label10;
        private ucDate uDate;
        private uctxt uctxtRate;
        private System.Windows.Forms.Label label2;
        private uctxt uctxtINo;
        private ucSearchList usItemType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ucSearchList usTypeItem;
        private ucDate uTo;
        private ucDate uFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private uctxt uctxtBIS;
        private System.Windows.Forms.Label lblBIS;
        private uctxt uctxtRegular;
        private System.Windows.Forms.Label lblRegular;
    }
}