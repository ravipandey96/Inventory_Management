namespace ERP
{
    partial class frmTaxCategory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblBorderBottom = new System.Windows.Forms.Label();
            this.lblTitleBar = new System.Windows.Forms.Label();
            this.lblBorderRight = new System.Windows.Forms.Label();
            this.lblBorderLeft = new System.Windows.Forms.Label();
            this.pbase = new System.Windows.Forms.Panel();
            this.uSearchGSTType = new ERP.ucSearchList();
            this.label5 = new System.Windows.Forms.Label();
            this.uTax = new ERP.uctxt();
            this.uCess = new ERP.uctxt();
            this.uSGST = new ERP.uctxt();
            this.uIGST = new ERP.uctxt();
            this.uCGST = new ERP.uctxt();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uctxtSNo = new ERP.uctxt();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCName = new System.Windows.Forms.Label();
            this.utxtName = new ERP.uctxt();
            this.pList = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.uSearch = new ERP.uctxt();
            this.gList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
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
            this.lblBorderBottom.Size = new System.Drawing.Size(648, 2);
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
            this.lblTitleBar.Size = new System.Drawing.Size(648, 28);
            this.lblTitleBar.TabIndex = 8;
            this.lblTitleBar.Text = "Tax Category";
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
            this.lblBorderRight.Location = new System.Drawing.Point(646, 28);
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
            this.pbase.Controls.Add(this.uSearchGSTType);
            this.pbase.Controls.Add(this.label5);
            this.pbase.Controls.Add(this.uTax);
            this.pbase.Controls.Add(this.uCess);
            this.pbase.Controls.Add(this.uSGST);
            this.pbase.Controls.Add(this.uIGST);
            this.pbase.Controls.Add(this.uCGST);
            this.pbase.Controls.Add(this.label4);
            this.pbase.Controls.Add(this.label3);
            this.pbase.Controls.Add(this.label2);
            this.pbase.Controls.Add(this.uctxtSNo);
            this.pbase.Controls.Add(this.btnSave);
            this.pbase.Controls.Add(this.btnList);
            this.pbase.Controls.Add(this.label11);
            this.pbase.Controls.Add(this.label10);
            this.pbase.Controls.Add(this.lblCName);
            this.pbase.Controls.Add(this.utxtName);
            this.pbase.Location = new System.Drawing.Point(103, 57);
            this.pbase.Name = "pbase";
            this.pbase.Size = new System.Drawing.Size(446, 390);
            this.pbase.TabIndex = 0;
            // 
            // uSearchGSTType
            // 
            this.uSearchGSTType.BackColor = System.Drawing.Color.Cyan;
            this.uSearchGSTType.Location = new System.Drawing.Point(172, 59);
            this.uSearchGSTType.Margin = new System.Windows.Forms.Padding(0);
            this.uSearchGSTType.Name = "uSearchGSTType";
            this.uSearchGSTType.Padding = new System.Windows.Forms.Padding(1);
            this.uSearchGSTType.Size = new System.Drawing.Size(248, 21);
            this.uSearchGSTType.TabIndex = 2;
            this.uSearchGSTType.Tag = " ";
            this.uSearchGSTType.Load += new System.EventHandler(this.uSearchPrimary_Load);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 71;
            this.label5.Text = "Tax On MRP";
            // 
            // uTax
            // 
            this.uTax.BackColor = System.Drawing.Color.Cyan;
            this.uTax.Location = new System.Drawing.Point(172, 232);
            this.uTax.Margin = new System.Windows.Forms.Padding(0);
            this.uTax.Name = "uTax";
            this.uTax.Padding = new System.Windows.Forms.Padding(1);
            this.uTax.Size = new System.Drawing.Size(248, 21);
            this.uTax.TabIndex = 7;
            this.uTax.Tag = " ";
            // 
            // uCess
            // 
            this.uCess.BackColor = System.Drawing.Color.Cyan;
            this.uCess.Location = new System.Drawing.Point(172, 196);
            this.uCess.Margin = new System.Windows.Forms.Padding(0);
            this.uCess.Name = "uCess";
            this.uCess.Padding = new System.Windows.Forms.Padding(1);
            this.uCess.Size = new System.Drawing.Size(248, 21);
            this.uCess.TabIndex = 6;
            this.uCess.Tag = " ";
            // 
            // uSGST
            // 
            this.uSGST.BackColor = System.Drawing.Color.Cyan;
            this.uSGST.Location = new System.Drawing.Point(172, 128);
            this.uSGST.Margin = new System.Windows.Forms.Padding(0);
            this.uSGST.Name = "uSGST";
            this.uSGST.Padding = new System.Windows.Forms.Padding(1);
            this.uSGST.Size = new System.Drawing.Size(248, 21);
            this.uSGST.TabIndex = 4;
            this.uSGST.Tag = " ";
            // 
            // uIGST
            // 
            this.uIGST.BackColor = System.Drawing.Color.Cyan;
            this.uIGST.Location = new System.Drawing.Point(172, 162);
            this.uIGST.Margin = new System.Windows.Forms.Padding(0);
            this.uIGST.Name = "uIGST";
            this.uIGST.Padding = new System.Windows.Forms.Padding(1);
            this.uIGST.Size = new System.Drawing.Size(248, 21);
            this.uIGST.TabIndex = 5;
            this.uIGST.Tag = " ";
            // 
            // uCGST
            // 
            this.uCGST.BackColor = System.Drawing.Color.Cyan;
            this.uCGST.Location = new System.Drawing.Point(172, 93);
            this.uCGST.Margin = new System.Windows.Forms.Padding(0);
            this.uCGST.Name = "uCGST";
            this.uCGST.Padding = new System.Windows.Forms.Padding(1);
            this.uCGST.Size = new System.Drawing.Size(248, 21);
            this.uCGST.TabIndex = 3;
            this.uCGST.Tag = " ";
            this.uCGST.TextChanged += new System.EventHandler(this.uCGST_TextChanged);
            this.uCGST.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uCGST_KeyDown);
            this.uCGST.Leave += new System.EventHandler(this.uCGST_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 17);
            this.label4.TabIndex = 65;
            this.label4.Text = "Rate of Tax (Cess)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 64;
            this.label3.Text = "Rate of Tax (IGST)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 17);
            this.label2.TabIndex = 63;
            this.label2.Text = "Rate of Tax (SGST)";
            // 
            // uctxtSNo
            // 
            this.uctxtSNo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtSNo.Location = new System.Drawing.Point(172, 0);
            this.uctxtSNo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtSNo.Name = "uctxtSNo";
            this.uctxtSNo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtSNo.Size = new System.Drawing.Size(30, 21);
            this.uctxtSNo.TabIndex = 0;
            this.uctxtSNo.Tag = " ";
            this.uctxtSNo.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Turquoise;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(204, 333);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 28);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
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
            this.btnList.Location = new System.Drawing.Point(305, 333);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(77, 28);
            this.btnList.TabIndex = 9;
            this.btnList.Text = "&List";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 17);
            this.label11.TabIndex = 61;
            this.label11.Text = "GST Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 17);
            this.label10.TabIndex = 60;
            this.label10.Text = "Rate of Tax (CGST)";
            // 
            // lblCName
            // 
            this.lblCName.AutoSize = true;
            this.lblCName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCName.Location = new System.Drawing.Point(22, 27);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(73, 17);
            this.lblCName.TabIndex = 58;
            this.lblCName.Text = "Tax Name";
            // 
            // utxtName
            // 
            this.utxtName.BackColor = System.Drawing.Color.Cyan;
            this.utxtName.Location = new System.Drawing.Point(172, 23);
            this.utxtName.Margin = new System.Windows.Forms.Padding(0);
            this.utxtName.Name = "utxtName";
            this.utxtName.Padding = new System.Windows.Forms.Padding(1);
            this.utxtName.Size = new System.Drawing.Size(248, 21);
            this.utxtName.TabIndex = 1;
            this.utxtName.Tag = " ";
            // 
            // pList
            // 
            this.pList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pList.Controls.Add(this.btnDelete);
            this.pList.Controls.Add(this.uSearch);
            this.pList.Controls.Add(this.gList);
            this.pList.Controls.Add(this.btnShow);
            this.pList.Controls.Add(this.label1);
            this.pList.Location = new System.Drawing.Point(41, 359);
            this.pList.Margin = new System.Windows.Forms.Padding(0);
            this.pList.Name = "pList";
            this.pList.Size = new System.Drawing.Size(624, 191);
            this.pList.TabIndex = 14;
            this.pList.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Turquoise;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(469, 15);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 25);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // uSearch
            // 
            this.uSearch.BackColor = System.Drawing.Color.Cyan;
            this.uSearch.Location = new System.Drawing.Point(70, 15);
            this.uSearch.Margin = new System.Windows.Forms.Padding(0);
            this.uSearch.Name = "uSearch";
            this.uSearch.Padding = new System.Windows.Forms.Padding(1);
            this.uSearch.Size = new System.Drawing.Size(206, 21);
            this.uSearch.TabIndex = 0;
            this.uSearch.Tag = " ";
            this.uSearch.TextChanged += new System.EventHandler(this.uSearch_TextChanged);
            this.uSearch.Load += new System.EventHandler(this.uSearch_Load);
            this.uSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uSearch_KeyDown);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.NullValue = " ";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gList.DefaultCellStyle = dataGridViewCellStyle4;
            this.gList.GridColor = System.Drawing.Color.DarkCyan;
            this.gList.Location = new System.Drawing.Point(15, 60);
            this.gList.MultiSelect = false;
            this.gList.Name = "gList";
            this.gList.ReadOnly = true;
            this.gList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gList.RowHeadersVisible = false;
            this.gList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gList.ShowEditingIcon = false;
            this.gList.Size = new System.Drawing.Size(536, 110);
            this.gList.TabIndex = 3;
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
            this.Column3.HeaderText = "Short Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Full Name";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Conversion";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Turquoise;
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnShow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(286, 15);
            this.btnShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(82, 25);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Sho&w";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
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
            // frmTaxCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(648, 550);
            this.ControlBox = false;
            this.Controls.Add(this.pList);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblBorderLeft);
            this.Controls.Add(this.lblBorderRight);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblBorderBottom);
            this.Controls.Add(this.lblTitleBar);
            this.Controls.Add(this.pbase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmTaxCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TaxCategory";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmUnit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUnit_KeyDown);
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
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Panel pbase;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCName;
        private uctxt utxtName;
        private uctxt uctxtSNo;
        private System.Windows.Forms.Panel pList;
        public System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gList;
        private uctxt uSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        public System.Windows.Forms.Button btnDelete;
        private ucSearchList uSearchGSTType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private uctxt uTax;
        private uctxt uCess;
        private uctxt uSGST;
        private uctxt uIGST;
        private uctxt uCGST;
        private System.Windows.Forms.Label label5;
    }
}