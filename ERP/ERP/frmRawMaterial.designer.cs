namespace ERP
{
    partial class frmRawMaterial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblBorderBottom = new System.Windows.Forms.Label();
            this.lblTitleBar = new System.Windows.Forms.Label();
            this.lblBorderRight = new System.Windows.Forms.Label();
            this.lblBorderLeft = new System.Windows.Forms.Label();
            this.pbase = new System.Windows.Forms.Panel();
            this.usTaxType = new ERP.ucSearchList();
            this.usUnit = new ERP.ucSearchList();
            this.uctxtCess = new ERP.uctxt();
            this.label15 = new System.Windows.Forms.Label();
            this.uctxtRate = new ERP.uctxt();
            this.uctxtCgst = new ERP.uctxt();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.uctxtSgst = new ERP.uctxt();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.uctxtIgst = new ERP.uctxt();
            this.uctxtHSNCODE = new ERP.uctxt();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.uctxtGrade = new ERP.uctxt();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uctxtThickness = new ERP.uctxt();
            this.uctxtName = new ERP.uctxt();
            this.uctxtAlias = new ERP.uctxt();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uctxtPrint = new ERP.uctxt();
            this.label10 = new System.Windows.Forms.Label();
            this.uctxtSNo = new ERP.uctxt();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.pList = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.uSearch = new ERP.uctxt();
            this.gList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblBorderBottom.Location = new System.Drawing.Point(0, 406);
            this.lblBorderBottom.Name = "lblBorderBottom";
            this.lblBorderBottom.Size = new System.Drawing.Size(656, 2);
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
            this.lblTitleBar.Size = new System.Drawing.Size(656, 28);
            this.lblTitleBar.TabIndex = 8;
            this.lblTitleBar.Text = "Raw Material Creation";
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
            this.lblBorderRight.Location = new System.Drawing.Point(654, 28);
            this.lblBorderRight.Name = "lblBorderRight";
            this.lblBorderRight.Size = new System.Drawing.Size(2, 378);
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
            this.lblBorderLeft.Size = new System.Drawing.Size(2, 378);
            this.lblBorderLeft.TabIndex = 13;
            this.lblBorderLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBorderLeft.UseCompatibleTextRendering = true;
            // 
            // pbase
            // 
            this.pbase.Controls.Add(this.usTaxType);
            this.pbase.Controls.Add(this.usUnit);
            this.pbase.Controls.Add(this.uctxtCess);
            this.pbase.Controls.Add(this.label15);
            this.pbase.Controls.Add(this.uctxtRate);
            this.pbase.Controls.Add(this.uctxtCgst);
            this.pbase.Controls.Add(this.label14);
            this.pbase.Controls.Add(this.label13);
            this.pbase.Controls.Add(this.uctxtSgst);
            this.pbase.Controls.Add(this.label12);
            this.pbase.Controls.Add(this.label11);
            this.pbase.Controls.Add(this.uctxtIgst);
            this.pbase.Controls.Add(this.uctxtHSNCODE);
            this.pbase.Controls.Add(this.label9);
            this.pbase.Controls.Add(this.label7);
            this.pbase.Controls.Add(this.uctxtGrade);
            this.pbase.Controls.Add(this.label4);
            this.pbase.Controls.Add(this.label3);
            this.pbase.Controls.Add(this.uctxtThickness);
            this.pbase.Controls.Add(this.uctxtName);
            this.pbase.Controls.Add(this.uctxtAlias);
            this.pbase.Controls.Add(this.label2);
            this.pbase.Controls.Add(this.label5);
            this.pbase.Controls.Add(this.uctxtPrint);
            this.pbase.Controls.Add(this.label10);
            this.pbase.Controls.Add(this.uctxtSNo);
            this.pbase.Controls.Add(this.btnSave);
            this.pbase.Controls.Add(this.btnList);
            this.pbase.Controls.Add(this.lblName);
            this.pbase.Location = new System.Drawing.Point(14, 31);
            this.pbase.Name = "pbase";
            this.pbase.Size = new System.Drawing.Size(621, 356);
            this.pbase.TabIndex = 0;
            // 
            // usTaxType
            // 
            this.usTaxType.BackColor = System.Drawing.Color.Cyan;
            this.usTaxType.Location = new System.Drawing.Point(431, 96);
            this.usTaxType.Margin = new System.Windows.Forms.Padding(0);
            this.usTaxType.Name = "usTaxType";
            this.usTaxType.Padding = new System.Windows.Forms.Padding(1);
            this.usTaxType.Size = new System.Drawing.Size(175, 17);
            this.usTaxType.TabIndex = 9;
            this.usTaxType.Tag = " ";
            this.usTaxType.Load += new System.EventHandler(this.usTaxType_Load);
            this.usTaxType.Leave += new System.EventHandler(this.usTaxType_Leave);
            // 
            // usUnit
            // 
            this.usUnit.BackColor = System.Drawing.Color.Cyan;
            this.usUnit.Location = new System.Drawing.Point(140, 127);
            this.usUnit.Margin = new System.Windows.Forms.Padding(0);
            this.usUnit.Name = "usUnit";
            this.usUnit.Padding = new System.Windows.Forms.Padding(1);
            this.usUnit.Size = new System.Drawing.Size(194, 17);
            this.usUnit.TabIndex = 3;
            this.usUnit.Tag = " ";
            this.usUnit.Load += new System.EventHandler(this.usUnit_Load);
            // 
            // uctxtCess
            // 
            this.uctxtCess.BackColor = System.Drawing.Color.Cyan;
            this.uctxtCess.Location = new System.Drawing.Point(430, 232);
            this.uctxtCess.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtCess.Name = "uctxtCess";
            this.uctxtCess.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtCess.Size = new System.Drawing.Size(175, 17);
            this.uctxtCess.TabIndex = 13;
            this.uctxtCess.Tag = " ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(351, 232);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 17);
            this.label15.TabIndex = 97;
            this.label15.Text = "Cess";
            // 
            // uctxtRate
            // 
            this.uctxtRate.BackColor = System.Drawing.Color.Cyan;
            this.uctxtRate.Location = new System.Drawing.Point(140, 232);
            this.uctxtRate.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtRate.Name = "uctxtRate";
            this.uctxtRate.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtRate.Size = new System.Drawing.Size(194, 17);
            this.uctxtRate.TabIndex = 6;
            this.uctxtRate.Tag = " ";
            // 
            // uctxtCgst
            // 
            this.uctxtCgst.BackColor = System.Drawing.Color.Cyan;
            this.uctxtCgst.Location = new System.Drawing.Point(430, 198);
            this.uctxtCgst.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtCgst.Name = "uctxtCgst";
            this.uctxtCgst.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtCgst.Size = new System.Drawing.Size(175, 17);
            this.uctxtCgst.TabIndex = 12;
            this.uctxtCgst.TabStop = false;
            this.uctxtCgst.Tag = " ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(351, 135);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 17);
            this.label14.TabIndex = 94;
            this.label14.Text = "IGST";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(351, 167);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 17);
            this.label13.TabIndex = 93;
            this.label13.Text = "SGST";
            // 
            // uctxtSgst
            // 
            this.uctxtSgst.BackColor = System.Drawing.Color.Cyan;
            this.uctxtSgst.Location = new System.Drawing.Point(430, 165);
            this.uctxtSgst.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtSgst.Name = "uctxtSgst";
            this.uctxtSgst.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtSgst.Size = new System.Drawing.Size(175, 17);
            this.uctxtSgst.TabIndex = 11;
            this.uctxtSgst.TabStop = false;
            this.uctxtSgst.Tag = " ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(350, 201);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 17);
            this.label12.TabIndex = 91;
            this.label12.Text = "CGST";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(350, 96);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 17);
            this.label11.TabIndex = 89;
            this.label11.Text = "Tax Type";
            // 
            // uctxtIgst
            // 
            this.uctxtIgst.BackColor = System.Drawing.Color.Cyan;
            this.uctxtIgst.Location = new System.Drawing.Point(431, 127);
            this.uctxtIgst.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtIgst.Name = "uctxtIgst";
            this.uctxtIgst.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtIgst.Size = new System.Drawing.Size(175, 17);
            this.uctxtIgst.TabIndex = 10;
            this.uctxtIgst.TabStop = false;
            this.uctxtIgst.Tag = " ";
            // 
            // uctxtHSNCODE
            // 
            this.uctxtHSNCODE.BackColor = System.Drawing.Color.Cyan;
            this.uctxtHSNCODE.Location = new System.Drawing.Point(431, 58);
            this.uctxtHSNCODE.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtHSNCODE.Name = "uctxtHSNCODE";
            this.uctxtHSNCODE.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtHSNCODE.Size = new System.Drawing.Size(175, 17);
            this.uctxtHSNCODE.TabIndex = 8;
            this.uctxtHSNCODE.Tag = " ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(351, 60);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 86;
            this.label9.Text = "HSN Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 240);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 17);
            this.label7.TabIndex = 82;
            this.label7.Text = "Rate";
            // 
            // uctxtGrade
            // 
            this.uctxtGrade.BackColor = System.Drawing.Color.Cyan;
            this.uctxtGrade.Location = new System.Drawing.Point(140, 198);
            this.uctxtGrade.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtGrade.Name = "uctxtGrade";
            this.uctxtGrade.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtGrade.Size = new System.Drawing.Size(194, 17);
            this.uctxtGrade.TabIndex = 5;
            this.uctxtGrade.Tag = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 201);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Grade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 80;
            this.label3.Text = "Thickness";
            // 
            // uctxtThickness
            // 
            this.uctxtThickness.BackColor = System.Drawing.Color.Cyan;
            this.uctxtThickness.Location = new System.Drawing.Point(140, 162);
            this.uctxtThickness.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtThickness.Name = "uctxtThickness";
            this.uctxtThickness.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtThickness.Size = new System.Drawing.Size(194, 17);
            this.uctxtThickness.TabIndex = 4;
            this.uctxtThickness.Tag = " ";
            // 
            // uctxtName
            // 
            this.uctxtName.BackColor = System.Drawing.Color.Cyan;
            this.uctxtName.Location = new System.Drawing.Point(140, 23);
            this.uctxtName.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtName.Name = "uctxtName";
            this.uctxtName.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtName.Size = new System.Drawing.Size(465, 17);
            this.uctxtName.TabIndex = 0;
            this.uctxtName.Tag = " ";
            // 
            // uctxtAlias
            // 
            this.uctxtAlias.BackColor = System.Drawing.Color.Cyan;
            this.uctxtAlias.Location = new System.Drawing.Point(140, 55);
            this.uctxtAlias.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtAlias.Name = "uctxtAlias";
            this.uctxtAlias.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtAlias.Size = new System.Drawing.Size(194, 17);
            this.uctxtAlias.TabIndex = 1;
            this.uctxtAlias.Tag = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 76;
            this.label2.Text = "Alias";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 75;
            this.label5.Text = "Print Name";
            // 
            // uctxtPrint
            // 
            this.uctxtPrint.BackColor = System.Drawing.Color.Cyan;
            this.uctxtPrint.Location = new System.Drawing.Point(140, 91);
            this.uctxtPrint.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtPrint.Name = "uctxtPrint";
            this.uctxtPrint.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtPrint.Size = new System.Drawing.Size(194, 17);
            this.uctxtPrint.TabIndex = 2;
            this.uctxtPrint.Tag = " ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 17);
            this.label10.TabIndex = 74;
            this.label10.Text = "Unit";
            // 
            // uctxtSNo
            // 
            this.uctxtSNo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtSNo.Location = new System.Drawing.Point(172, 0);
            this.uctxtSNo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtSNo.Name = "uctxtSNo";
            this.uctxtSNo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtSNo.Size = new System.Drawing.Size(30, 17);
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
            this.btnSave.Location = new System.Drawing.Point(226, 305);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 28);
            this.btnSave.TabIndex = 14;
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
            this.btnList.Location = new System.Drawing.Point(322, 305);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(77, 28);
            this.btnList.TabIndex = 15;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(27, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 17);
            this.lblName.TabIndex = 58;
            this.lblName.Text = "Item Name";
            // 
            // pList
            // 
            this.pList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pList.Controls.Add(this.btnDelete);
            this.pList.Controls.Add(this.uSearch);
            this.pList.Controls.Add(this.gList);
            this.pList.Controls.Add(this.btnShow);
            this.pList.Controls.Add(this.label1);
            this.pList.Location = new System.Drawing.Point(5, 108);
            this.pList.Margin = new System.Windows.Forms.Padding(0);
            this.pList.Name = "pList";
            this.pList.Size = new System.Drawing.Size(642, 130);
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
            this.btnDelete.Location = new System.Drawing.Point(469, 10);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 26);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Delete";
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
            this.uSearch.TabIndex = 1;
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
            this.gList.Location = new System.Drawing.Point(15, 48);
            this.gList.MultiSelect = false;
            this.gList.Name = "gList";
            this.gList.ReadOnly = true;
            this.gList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gList.RowHeadersVisible = false;
            this.gList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gList.ShowEditingIcon = false;
            this.gList.Size = new System.Drawing.Size(536, 72);
            this.gList.TabIndex = 4;
            this.gList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gList_CellContentClick);
            this.gList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gList_CellContentDoubleClick);
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
            this.btnShow.Location = new System.Drawing.Point(286, 10);
            this.btnShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(82, 26);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show";
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
            // frmRawMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(656, 408);
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
            this.Name = "frmRawMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Holiday";
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
        private ucSearchList usUnit;
        private System.Windows.Forms.Label label5;
        private uctxt uctxtPrint;
        private System.Windows.Forms.Label label10;
        private uctxt uctxtCess;
        private System.Windows.Forms.Label label15;
        private uctxt uctxtRate;
        private uctxt uctxtCgst;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private uctxt uctxtSgst;
        private System.Windows.Forms.Label label12;
        private ucSearchList usTaxType;
        private System.Windows.Forms.Label label11;
        private uctxt uctxtIgst;
        private uctxt uctxtHSNCODE;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private uctxt uctxtGrade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private uctxt uctxtThickness;
        private uctxt uctxtName;
        private uctxt uctxtAlias;
        private System.Windows.Forms.Label label2;
    }
}