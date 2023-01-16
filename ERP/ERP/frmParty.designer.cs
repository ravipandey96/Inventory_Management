namespace ERP
{
    partial class frmParty
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
            this.usState = new ERP.ucSearchList();
            this.uctxtContactPerson = new ERP.uctxt();
            this.uctxtStateCode = new ERP.uctxt();
            this.usRType = new ERP.ucSearchList();
            this.usPartyType = new ERP.ucSearchList();
            this.uctxtAddress1 = new ERP.uctxt();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uctxtSNo = new ERP.uctxt();
            this.uctxtPanCardNo = new ERP.uctxt();
            this.uctxtEmail = new ERP.uctxt();
            this.uctxtGSTIN = new ERP.uctxt();
            this.uctxtAadharNo = new ERP.uctxt();
            this.uctxtCity = new ERP.uctxt();
            this.uctxtMobileNo = new ERP.uctxt();
            this.uctxtPinCode = new ERP.uctxt();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCName = new System.Windows.Forms.Label();
            this.uctxtAddress3 = new ERP.uctxt();
            this.uctxtAddress2 = new ERP.uctxt();
            this.uctxtSName = new ERP.uctxt();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
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
            this.lblBorderBottom.Location = new System.Drawing.Point(0, 571);
            this.lblBorderBottom.Name = "lblBorderBottom";
            this.lblBorderBottom.Size = new System.Drawing.Size(818, 2);
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
            this.lblTitleBar.Size = new System.Drawing.Size(818, 28);
            this.lblTitleBar.TabIndex = 8;
            this.lblTitleBar.Text = "Supplier/Customer Creation";
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
            this.lblBorderRight.Location = new System.Drawing.Point(816, 28);
            this.lblBorderRight.Name = "lblBorderRight";
            this.lblBorderRight.Size = new System.Drawing.Size(2, 543);
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
            this.lblBorderLeft.Size = new System.Drawing.Size(2, 543);
            this.lblBorderLeft.TabIndex = 13;
            this.lblBorderLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBorderLeft.UseCompatibleTextRendering = true;
            // 
            // pbase
            // 
            this.pbase.Controls.Add(this.usState);
            this.pbase.Controls.Add(this.uctxtContactPerson);
            this.pbase.Controls.Add(this.uctxtStateCode);
            this.pbase.Controls.Add(this.usRType);
            this.pbase.Controls.Add(this.usPartyType);
            this.pbase.Controls.Add(this.uctxtAddress1);
            this.pbase.Controls.Add(this.label7);
            this.pbase.Controls.Add(this.label2);
            this.pbase.Controls.Add(this.uctxtSNo);
            this.pbase.Controls.Add(this.uctxtPanCardNo);
            this.pbase.Controls.Add(this.uctxtEmail);
            this.pbase.Controls.Add(this.uctxtGSTIN);
            this.pbase.Controls.Add(this.uctxtAadharNo);
            this.pbase.Controls.Add(this.uctxtCity);
            this.pbase.Controls.Add(this.uctxtMobileNo);
            this.pbase.Controls.Add(this.uctxtPinCode);
            this.pbase.Controls.Add(this.label19);
            this.pbase.Controls.Add(this.label18);
            this.pbase.Controls.Add(this.label13);
            this.pbase.Controls.Add(this.label14);
            this.pbase.Controls.Add(this.label16);
            this.pbase.Controls.Add(this.label9);
            this.pbase.Controls.Add(this.label8);
            this.pbase.Controls.Add(this.label6);
            this.pbase.Controls.Add(this.label5);
            this.pbase.Controls.Add(this.label3);
            this.pbase.Controls.Add(this.label4);
            this.pbase.Controls.Add(this.lblCName);
            this.pbase.Controls.Add(this.uctxtAddress3);
            this.pbase.Controls.Add(this.uctxtAddress2);
            this.pbase.Controls.Add(this.uctxtSName);
            this.pbase.Controls.Add(this.btnSave);
            this.pbase.Controls.Add(this.btnList);
            this.pbase.Location = new System.Drawing.Point(12, 39);
            this.pbase.Name = "pbase";
            this.pbase.Size = new System.Drawing.Size(796, 522);
            this.pbase.TabIndex = 0;
            this.pbase.Paint += new System.Windows.Forms.PaintEventHandler(this.pbase_Paint);
            // 
            // usState
            // 
            this.usState.BackColor = System.Drawing.Color.Cyan;
            this.usState.Location = new System.Drawing.Point(177, 254);
            this.usState.Margin = new System.Windows.Forms.Padding(0);
            this.usState.Name = "usState";
            this.usState.Padding = new System.Windows.Forms.Padding(1);
            this.usState.Size = new System.Drawing.Size(250, 21);
            this.usState.TabIndex = 8;
            this.usState.Tag = " ";
            this.usState.Load += new System.EventHandler(this.usState_Load);
            this.usState.Leave += new System.EventHandler(this.usState_Leave);
            // 
            // uctxtContactPerson
            // 
            this.uctxtContactPerson.BackColor = System.Drawing.Color.Cyan;
            this.uctxtContactPerson.Location = new System.Drawing.Point(564, 91);
            this.uctxtContactPerson.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtContactPerson.Name = "uctxtContactPerson";
            this.uctxtContactPerson.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtContactPerson.Size = new System.Drawing.Size(179, 21);
            this.uctxtContactPerson.TabIndex = 14;
            this.uctxtContactPerson.Tag = " ";
            // 
            // uctxtStateCode
            // 
            this.uctxtStateCode.BackColor = System.Drawing.Color.Cyan;
            this.uctxtStateCode.Location = new System.Drawing.Point(177, 283);
            this.uctxtStateCode.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtStateCode.Name = "uctxtStateCode";
            this.uctxtStateCode.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtStateCode.Size = new System.Drawing.Size(250, 21);
            this.uctxtStateCode.TabIndex = 9;
            this.uctxtStateCode.Tag = " ";
            // 
            // usRType
            // 
            this.usRType.BackColor = System.Drawing.Color.Cyan;
            this.usRType.Location = new System.Drawing.Point(177, 310);
            this.usRType.Margin = new System.Windows.Forms.Padding(0);
            this.usRType.Name = "usRType";
            this.usRType.Padding = new System.Windows.Forms.Padding(1);
            this.usRType.Size = new System.Drawing.Size(250, 21);
            this.usRType.TabIndex = 10;
            this.usRType.Tag = " ";
            this.usRType.Load += new System.EventHandler(this.usRType_Load_1);
            // 
            // usPartyType
            // 
            this.usPartyType.BackColor = System.Drawing.Color.Cyan;
            this.usPartyType.Location = new System.Drawing.Point(178, 64);
            this.usPartyType.Margin = new System.Windows.Forms.Padding(0);
            this.usPartyType.Name = "usPartyType";
            this.usPartyType.Padding = new System.Windows.Forms.Padding(1);
            this.usPartyType.Size = new System.Drawing.Size(250, 21);
            this.usPartyType.TabIndex = 1;
            this.usPartyType.Tag = " ";
            this.usPartyType.Load += new System.EventHandler(this.usPartyType_Load_1);
            // 
            // uctxtAddress1
            // 
            this.uctxtAddress1.BackColor = System.Drawing.Color.Cyan;
            this.uctxtAddress1.Location = new System.Drawing.Point(178, 91);
            this.uctxtAddress1.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtAddress1.Name = "uctxtAddress1";
            this.uctxtAddress1.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtAddress1.Size = new System.Drawing.Size(249, 21);
            this.uctxtAddress1.TabIndex = 2;
            this.uctxtAddress1.Tag = " ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 229);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 17);
            this.label7.TabIndex = 152;
            this.label7.Text = "City";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 149;
            this.label2.Text = "Party Type";
            // 
            // uctxtSNo
            // 
            this.uctxtSNo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtSNo.Location = new System.Drawing.Point(177, 14);
            this.uctxtSNo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtSNo.Name = "uctxtSNo";
            this.uctxtSNo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtSNo.Size = new System.Drawing.Size(30, 21);
            this.uctxtSNo.TabIndex = 148;
            this.uctxtSNo.Tag = " ";
            this.uctxtSNo.Visible = false;
            // 
            // uctxtPanCardNo
            // 
            this.uctxtPanCardNo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtPanCardNo.Location = new System.Drawing.Point(564, 119);
            this.uctxtPanCardNo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtPanCardNo.Name = "uctxtPanCardNo";
            this.uctxtPanCardNo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtPanCardNo.Size = new System.Drawing.Size(179, 21);
            this.uctxtPanCardNo.TabIndex = 15;
            this.uctxtPanCardNo.Tag = " ";
            // 
            // uctxtEmail
            // 
            this.uctxtEmail.BackColor = System.Drawing.Color.Cyan;
            this.uctxtEmail.Location = new System.Drawing.Point(564, 64);
            this.uctxtEmail.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtEmail.Name = "uctxtEmail";
            this.uctxtEmail.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtEmail.Size = new System.Drawing.Size(179, 21);
            this.uctxtEmail.TabIndex = 13;
            this.uctxtEmail.Tag = " ";
            // 
            // uctxtGSTIN
            // 
            this.uctxtGSTIN.BackColor = System.Drawing.Color.Cyan;
            this.uctxtGSTIN.Location = new System.Drawing.Point(177, 338);
            this.uctxtGSTIN.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtGSTIN.Name = "uctxtGSTIN";
            this.uctxtGSTIN.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtGSTIN.Size = new System.Drawing.Size(250, 21);
            this.uctxtGSTIN.TabIndex = 11;
            this.uctxtGSTIN.Tag = " ";
            // 
            // uctxtAadharNo
            // 
            this.uctxtAadharNo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtAadharNo.Location = new System.Drawing.Point(564, 37);
            this.uctxtAadharNo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtAadharNo.Name = "uctxtAadharNo";
            this.uctxtAadharNo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtAadharNo.Size = new System.Drawing.Size(179, 21);
            this.uctxtAadharNo.TabIndex = 12;
            this.uctxtAadharNo.Tag = " ";
            // 
            // uctxtCity
            // 
            this.uctxtCity.BackColor = System.Drawing.Color.Cyan;
            this.uctxtCity.Location = new System.Drawing.Point(177, 227);
            this.uctxtCity.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtCity.Name = "uctxtCity";
            this.uctxtCity.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtCity.Size = new System.Drawing.Size(250, 21);
            this.uctxtCity.TabIndex = 7;
            this.uctxtCity.Tag = " ";
            // 
            // uctxtMobileNo
            // 
            this.uctxtMobileNo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtMobileNo.Location = new System.Drawing.Point(177, 199);
            this.uctxtMobileNo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtMobileNo.Name = "uctxtMobileNo";
            this.uctxtMobileNo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtMobileNo.Size = new System.Drawing.Size(250, 21);
            this.uctxtMobileNo.TabIndex = 6;
            this.uctxtMobileNo.Tag = " ";
            this.uctxtMobileNo.Load += new System.EventHandler(this.uctxtMobileNo_Load);
            // 
            // uctxtPinCode
            // 
            this.uctxtPinCode.BackColor = System.Drawing.Color.Cyan;
            this.uctxtPinCode.Location = new System.Drawing.Point(177, 173);
            this.uctxtPinCode.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtPinCode.Name = "uctxtPinCode";
            this.uctxtPinCode.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtPinCode.Size = new System.Drawing.Size(250, 21);
            this.uctxtPinCode.TabIndex = 5;
            this.uctxtPinCode.Tag = " ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(18, 285);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 17);
            this.label19.TabIndex = 147;
            this.label19.Text = "State Code";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(18, 313);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(129, 17);
            this.label18.TabIndex = 146;
            this.label18.Text = "Registeration Type";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 176);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 17);
            this.label13.TabIndex = 145;
            this.label13.Text = "Pin Code";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 202);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 17);
            this.label14.TabIndex = 144;
            this.label14.Text = "Contact Number ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(451, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 17);
            this.label16.TabIndex = 143;
            this.label16.Text = "PAN Card No";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(451, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 17);
            this.label9.TabIndex = 142;
            this.label9.Text = "Email Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 141;
            this.label8.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(451, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 140;
            this.label6.Text = "Aadhar No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 139;
            this.label5.Text = "State Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 138;
            this.label3.Text = "GSTIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(451, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 137;
            this.label4.Text = "Contact Person";
            // 
            // lblCName
            // 
            this.lblCName.AutoSize = true;
            this.lblCName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCName.Location = new System.Drawing.Point(18, 40);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(85, 17);
            this.lblCName.TabIndex = 136;
            this.lblCName.Text = "Party Name";
            // 
            // uctxtAddress3
            // 
            this.uctxtAddress3.BackColor = System.Drawing.Color.Cyan;
            this.uctxtAddress3.Location = new System.Drawing.Point(178, 145);
            this.uctxtAddress3.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtAddress3.Name = "uctxtAddress3";
            this.uctxtAddress3.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtAddress3.Size = new System.Drawing.Size(250, 21);
            this.uctxtAddress3.TabIndex = 4;
            this.uctxtAddress3.Tag = " ";
            // 
            // uctxtAddress2
            // 
            this.uctxtAddress2.BackColor = System.Drawing.Color.Cyan;
            this.uctxtAddress2.Location = new System.Drawing.Point(178, 119);
            this.uctxtAddress2.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtAddress2.Name = "uctxtAddress2";
            this.uctxtAddress2.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtAddress2.Size = new System.Drawing.Size(250, 21);
            this.uctxtAddress2.TabIndex = 3;
            this.uctxtAddress2.Tag = " ";
            // 
            // uctxtSName
            // 
            this.uctxtSName.BackColor = System.Drawing.Color.Cyan;
            this.uctxtSName.Location = new System.Drawing.Point(178, 37);
            this.uctxtSName.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtSName.Name = "uctxtSName";
            this.uctxtSName.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtSName.Size = new System.Drawing.Size(250, 21);
            this.uctxtSName.TabIndex = 0;
            this.uctxtSName.Tag = " ";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Turquoise;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(292, 444);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 28);
            this.btnSave.TabIndex = 16;
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
            this.btnList.Location = new System.Drawing.Point(411, 444);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(77, 28);
            this.btnList.TabIndex = 17;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // pList
            // 
            this.pList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pList.Controls.Add(this.btnDelete);
            this.pList.Controls.Add(this.uSearch);
            this.pList.Controls.Add(this.gList);
            this.pList.Controls.Add(this.btnShow);
            this.pList.Controls.Add(this.label1);
            this.pList.Location = new System.Drawing.Point(5, 160);
            this.pList.Margin = new System.Windows.Forms.Padding(0);
            this.pList.Name = "pList";
            this.pList.Size = new System.Drawing.Size(810, 181);
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
            this.btnDelete.Location = new System.Drawing.Point(693, 9);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 26);
            this.btnDelete.TabIndex = 1;
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
            this.gList.Location = new System.Drawing.Point(15, 51);
            this.gList.MultiSelect = false;
            this.gList.Name = "gList";
            this.gList.ReadOnly = true;
            this.gList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gList.RowHeadersVisible = false;
            this.gList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gList.ShowEditingIcon = false;
            this.gList.Size = new System.Drawing.Size(536, 110);
            this.gList.TabIndex = 2;
            this.gList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gList_CellContentClick);
            this.gList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gList_RowEnter);
            this.gList.Click += new System.EventHandler(this.gList_Click);
            this.gList.DoubleClick += new System.EventHandler(this.gList_DoubleClick);
            this.gList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gList_KeyDown);
            this.gList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gList_KeyPress);
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
            this.btnShow.Location = new System.Drawing.Point(290, 9);
            this.btnShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(82, 26);
            this.btnShow.TabIndex = 0;
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
            this.lblMax.Location = new System.Drawing.Point(508, 0);
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
            this.lblClose.Location = new System.Drawing.Point(566, 0);
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
            this.lblMin.Location = new System.Drawing.Point(536, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(24, 24);
            this.lblMin.TabIndex = 1;
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMin.UseCompatibleTextRendering = true;
            this.lblMin.Click += new System.EventHandler(this.lblMin_Click);
            // 
            // frmParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 573);
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
            this.Name = "frmParty";
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
        private ucSearchList usRType;
        private ucSearchList usPartyType;
        private System.Windows.Forms.Label label2;
        private uctxt uctxtSNo;
        private uctxt uctxtPanCardNo;
        private uctxt uctxtEmail;
        private uctxt uctxtGSTIN;
        private uctxt uctxtAadharNo;
        private uctxt uctxtCity;
        private uctxt uctxtMobileNo;
        private uctxt uctxtPinCode;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCName;
        private uctxt uctxtAddress3;
        private uctxt uctxtAddress2;
        private uctxt uctxtSName;
        private System.Windows.Forms.Label label7;
        private uctxt uctxtAddress1;
        private uctxt uctxtContactPerson;
        private uctxt uctxtStateCode;
        private ucSearchList usState;
    }
}