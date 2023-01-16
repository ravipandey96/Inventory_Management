namespace ERP
{
    partial class frmPurchase_Return
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblBorderBottom = new System.Windows.Forms.Label();
            this.lblTitleBar = new System.Windows.Forms.Label();
            this.lblBorderRight = new System.Windows.Forms.Label();
            this.lblBorderLeft = new System.Windows.Forms.Label();
            this.pbase = new System.Windows.Forms.Panel();
            this.usItem = new ERP.ucSearchList();
            this.uctxtVNo = new ERP.uctxt();
            this.uctxtRNo = new ERP.uctxt();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtNarration = new ERP.uctxt();
            this.uctxtQty = new ERP.uctxt();
            this.label2 = new System.Windows.Forms.Label();
            this.uDate = new ERP.ucDate();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.uctxtRefNo = new ERP.uctxt();
            this.label10 = new System.Windows.Forms.Label();
            this.grdReturn = new System.Windows.Forms.DataGridView();
            this.uctxtSNo = new ERP.uctxt();
            this.lblName = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pList = new System.Windows.Forms.Panel();
            this.gList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uTo = new ERP.ucDate();
            this.uFrom = new ERP.ucDate();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.uSearch = new ERP.uctxt();
            this.btnShow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReturn)).BeginInit();
            this.pList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBorderBottom
            // 
            this.lblBorderBottom.AutoEllipsis = true;
            this.lblBorderBottom.BackColor = System.Drawing.Color.Aqua;
            this.lblBorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBorderBottom.Location = new System.Drawing.Point(0, 549);
            this.lblBorderBottom.Name = "lblBorderBottom";
            this.lblBorderBottom.Size = new System.Drawing.Size(611, 2);
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
            this.lblTitleBar.Size = new System.Drawing.Size(611, 28);
            this.lblTitleBar.TabIndex = 8;
            this.lblTitleBar.Text = "Purchase Return";
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
            this.lblBorderRight.Location = new System.Drawing.Point(609, 28);
            this.lblBorderRight.Name = "lblBorderRight";
            this.lblBorderRight.Size = new System.Drawing.Size(2, 521);
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
            this.lblBorderLeft.Size = new System.Drawing.Size(2, 521);
            this.lblBorderLeft.TabIndex = 13;
            this.lblBorderLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBorderLeft.UseCompatibleTextRendering = true;
            // 
            // pbase
            // 
            this.pbase.Controls.Add(this.usItem);
            this.pbase.Controls.Add(this.uctxtVNo);
            this.pbase.Controls.Add(this.uctxtRNo);
            this.pbase.Controls.Add(this.label3);
            this.pbase.Controls.Add(this.uctxtNarration);
            this.pbase.Controls.Add(this.uctxtQty);
            this.pbase.Controls.Add(this.label2);
            this.pbase.Controls.Add(this.uDate);
            this.pbase.Controls.Add(this.label5);
            this.pbase.Controls.Add(this.btnSave);
            this.pbase.Controls.Add(this.btnList);
            this.pbase.Controls.Add(this.uctxtRefNo);
            this.pbase.Controls.Add(this.label10);
            this.pbase.Controls.Add(this.grdReturn);
            this.pbase.Controls.Add(this.uctxtSNo);
            this.pbase.Controls.Add(this.lblName);
            this.pbase.Controls.Add(this.button2);
            this.pbase.Controls.Add(this.button1);
            this.pbase.Location = new System.Drawing.Point(9, 34);
            this.pbase.Name = "pbase";
            this.pbase.Size = new System.Drawing.Size(592, 507);
            this.pbase.TabIndex = 0;
            // 
            // usItem
            // 
            this.usItem.BackColor = System.Drawing.Color.Cyan;
            this.usItem.Location = new System.Drawing.Point(7, 123);
            this.usItem.Margin = new System.Windows.Forms.Padding(0);
            this.usItem.Name = "usItem";
            this.usItem.Padding = new System.Windows.Forms.Padding(1);
            this.usItem.Size = new System.Drawing.Size(311, 21);
            this.usItem.TabIndex = 2;
            this.usItem.Tag = " ";
            this.usItem.Load += new System.EventHandler(this.usType_Load);
            this.usItem.Leave += new System.EventHandler(this.usItem_Leave);
            // 
            // uctxtVNo
            // 
            this.uctxtVNo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtVNo.Location = new System.Drawing.Point(446, 4);
            this.uctxtVNo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtVNo.Name = "uctxtVNo";
            this.uctxtVNo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtVNo.Size = new System.Drawing.Size(15, 21);
            this.uctxtVNo.TabIndex = 81;
            this.uctxtVNo.Tag = " ";
            this.uctxtVNo.Visible = false;
            // 
            // uctxtRNo
            // 
            this.uctxtRNo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtRNo.Location = new System.Drawing.Point(385, 4);
            this.uctxtRNo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtRNo.Name = "uctxtRNo";
            this.uctxtRNo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtRNo.Size = new System.Drawing.Size(15, 21);
            this.uctxtRNo.TabIndex = 80;
            this.uctxtRNo.Tag = " ";
            this.uctxtRNo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 407);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 79;
            this.label3.Text = "Narration";
            // 
            // uctxtNarration
            // 
            this.uctxtNarration.BackColor = System.Drawing.Color.Cyan;
            this.uctxtNarration.Location = new System.Drawing.Point(81, 407);
            this.uctxtNarration.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtNarration.Name = "uctxtNarration";
            this.uctxtNarration.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtNarration.Size = new System.Drawing.Size(504, 21);
            this.uctxtNarration.TabIndex = 6;
            this.uctxtNarration.Tag = " ";
            // 
            // uctxtQty
            // 
            this.uctxtQty.BackColor = System.Drawing.Color.Cyan;
            this.uctxtQty.Location = new System.Drawing.Point(331, 123);
            this.uctxtQty.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtQty.Name = "uctxtQty";
            this.uctxtQty.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtQty.Size = new System.Drawing.Size(98, 21);
            this.uctxtQty.TabIndex = 3;
            this.uctxtQty.Tag = " ";
            this.uctxtQty.Load += new System.EventHandler(this.uctxtQty_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(349, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 76;
            this.label2.Text = "Quantity";
            // 
            // uDate
            // 
            this.uDate.BackColor = System.Drawing.Color.Cyan;
            this.uDate.Location = new System.Drawing.Point(172, 21);
            this.uDate.Margin = new System.Windows.Forms.Padding(0);
            this.uDate.Name = "uDate";
            this.uDate.Padding = new System.Windows.Forms.Padding(1);
            this.uDate.Size = new System.Drawing.Size(91, 25);
            this.uDate.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(107, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 17);
            this.label5.TabIndex = 75;
            this.label5.Text = "Item Description";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Turquoise;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(203, 462);
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
            this.btnList.Location = new System.Drawing.Point(296, 462);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(77, 28);
            this.btnList.TabIndex = 8;
            this.btnList.TabStop = false;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // uctxtRefNo
            // 
            this.uctxtRefNo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtRefNo.Location = new System.Drawing.Point(172, 56);
            this.uctxtRefNo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtRefNo.Name = "uctxtRefNo";
            this.uctxtRefNo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtRefNo.Size = new System.Drawing.Size(91, 21);
            this.uctxtRefNo.TabIndex = 1;
            this.uctxtRefNo.Tag = " ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 17);
            this.label10.TabIndex = 74;
            this.label10.Text = "Reference No.";
            // 
            // grdReturn
            // 
            this.grdReturn.AllowUserToAddRows = false;
            this.grdReturn.AllowUserToDeleteRows = false;
            this.grdReturn.AllowUserToResizeColumns = false;
            this.grdReturn.AllowUserToResizeRows = false;
            this.grdReturn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdReturn.BackgroundColor = System.Drawing.Color.White;
            this.grdReturn.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.grdReturn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdReturn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdReturn.ColumnHeadersHeight = 30;
            this.grdReturn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNo,
            this.Column4,
            this.dataGridViewTextBoxColumn1,
            this.RNo,
            this.Name2,
            this.Ratio});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.NullValue = " ";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdReturn.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdReturn.GridColor = System.Drawing.Color.DarkCyan;
            this.grdReturn.Location = new System.Drawing.Point(7, 150);
            this.grdReturn.MultiSelect = false;
            this.grdReturn.Name = "grdReturn";
            this.grdReturn.ReadOnly = true;
            this.grdReturn.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdReturn.RowHeadersVisible = false;
            this.grdReturn.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdReturn.ShowEditingIcon = false;
            this.grdReturn.Size = new System.Drawing.Size(578, 247);
            this.grdReturn.TabIndex = 99;
            this.grdReturn.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdReturn_CellDoubleClick);
            // 
            // uctxtSNo
            // 
            this.uctxtSNo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtSNo.Location = new System.Drawing.Point(412, 4);
            this.uctxtSNo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtSNo.Name = "uctxtSNo";
            this.uctxtSNo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtSNo.Size = new System.Drawing.Size(15, 21);
            this.uctxtSNo.TabIndex = 0;
            this.uctxtSNo.Tag = " ";
            this.uctxtSNo.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(27, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 17);
            this.lblName.TabIndex = 58;
            this.lblName.Text = "Date";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Turquoise;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(536, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 23);
            this.button2.TabIndex = 5;
            this.button2.TabStop = false;
            this.button2.Text = "Rem";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Turquoise;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(475, 121);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pList
            // 
            this.pList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pList.Controls.Add(this.gList);
            this.pList.Controls.Add(this.uTo);
            this.pList.Controls.Add(this.uFrom);
            this.pList.Controls.Add(this.label6);
            this.pList.Controls.Add(this.label4);
            this.pList.Controls.Add(this.btnDelete);
            this.pList.Controls.Add(this.uSearch);
            this.pList.Controls.Add(this.btnShow);
            this.pList.Controls.Add(this.label1);
            this.pList.Location = new System.Drawing.Point(5, 226);
            this.pList.Margin = new System.Windows.Forms.Padding(0);
            this.pList.Name = "pList";
            this.pList.Size = new System.Drawing.Size(605, 171);
            this.pList.TabIndex = 1;
            this.pList.Visible = false;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.NullValue = " ";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gList.DefaultCellStyle = dataGridViewCellStyle8;
            this.gList.GridColor = System.Drawing.Color.DarkCyan;
            this.gList.Location = new System.Drawing.Point(4, 67);
            this.gList.MultiSelect = false;
            this.gList.Name = "gList";
            this.gList.ReadOnly = true;
            this.gList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gList.RowHeadersVisible = false;
            this.gList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gList.ShowEditingIcon = false;
            this.gList.Size = new System.Drawing.Size(585, 99);
            this.gList.TabIndex = 5;
            this.gList.TabStop = false;
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
            // uTo
            // 
            this.uTo.BackColor = System.Drawing.Color.Cyan;
            this.uTo.Location = new System.Drawing.Point(194, 7);
            this.uTo.Margin = new System.Windows.Forms.Padding(0);
            this.uTo.Name = "uTo";
            this.uTo.Padding = new System.Windows.Forms.Padding(1);
            this.uTo.Size = new System.Drawing.Size(84, 25);
            this.uTo.TabIndex = 1;
            this.uTo.Load += new System.EventHandler(this.uTo_Load);
            // 
            // uFrom
            // 
            this.uFrom.BackColor = System.Drawing.Color.Cyan;
            this.uFrom.Location = new System.Drawing.Point(67, 7);
            this.uFrom.Margin = new System.Windows.Forms.Padding(0);
            this.uFrom.Name = "uFrom";
            this.uFrom.Padding = new System.Windows.Forms.Padding(1);
            this.uFrom.Size = new System.Drawing.Size(84, 25);
            this.uFrom.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(162, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 60;
            this.label4.Text = "From";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Turquoise;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(477, 35);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 26);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // uSearch
            // 
            this.uSearch.BackColor = System.Drawing.Color.Cyan;
            this.uSearch.Location = new System.Drawing.Point(67, 37);
            this.uSearch.Margin = new System.Windows.Forms.Padding(0);
            this.uSearch.Name = "uSearch";
            this.uSearch.Padding = new System.Windows.Forms.Padding(1);
            this.uSearch.Size = new System.Drawing.Size(211, 21);
            this.uSearch.TabIndex = 3;
            this.uSearch.Tag = " ";
            this.uSearch.TextChanged += new System.EventHandler(this.uSearch_TextChanged);
            this.uSearch.Load += new System.EventHandler(this.uSearch_Load);
            this.uSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uSearch_KeyDown);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Turquoise;
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnShow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(300, 32);
            this.btnShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(63, 26);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 39);
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
            // SNo
            // 
            this.SNo.HeaderText = "SNo";
            this.SNo.Name = "SNo";
            this.SNo.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "VNo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Reference No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // RNo
            // 
            this.RNo.HeaderText = "RNo";
            this.RNo.Name = "RNo";
            this.RNo.ReadOnly = true;
            // 
            // Name2
            // 
            this.Name2.HeaderText = "Raw Material";
            this.Name2.Name = "Name2";
            this.Name2.ReadOnly = true;
            // 
            // Ratio
            // 
            this.Ratio.HeaderText = "Quantity";
            this.Ratio.Name = "Ratio";
            this.Ratio.ReadOnly = true;
            // 
            // frmPurchase_Return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(611, 551);
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
            this.Name = "frmPurchase_Return";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Purchase_Return";
            this.Load += new System.EventHandler(this.frmUnit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBrand_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmUnit_KeyPress);
            this.pbase.ResumeLayout(false);
            this.pbase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReturn)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private uctxt uctxtRefNo;
        private System.Windows.Forms.Label label10;
        private ucDate uDate;
        private System.Windows.Forms.Label label3;
        private uctxt uctxtNarration;
        private uctxt uctxtQty;
        private System.Windows.Forms.Label label2;
        private uctxt uctxtRNo;
        private ucDate uTo;
        private ucDate uFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grdReturn;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private uctxt uctxtVNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ratio;
    }
}