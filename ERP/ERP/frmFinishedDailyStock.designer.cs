namespace ERP
{
    partial class frmFinishedDailyStock
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
            this.lblBorderRight = new System.Windows.Forms.Label();
            this.lblBorderLeft = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlAdvance = new System.Windows.Forms.Panel();
            this.lblWait = new System.Windows.Forms.Label();
            this.usGroup = new ERP.ucSearchList();
            this.usName = new ERP.ucSearchList();
            this.uEmpCode = new ERP.uctxt();
            this.usAdvance = new ERP.ucSearchList();
            this.usZeroBal = new ERP.ucSearchList();
            this.pnlParticular = new System.Windows.Forms.Panel();
            this.uctxtFNo = new ERP.uctxt();
            this.label1 = new System.Windows.Forms.Label();
            this.usParticular = new ERP.ucSearchList();
            this.lblWait5 = new System.Windows.Forms.Label();
            this.uFrom5 = new ERP.ucDate();
            this.uTo5 = new ERP.ucDate();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.btnCancel5 = new System.Windows.Forms.Button();
            this.btnShow5 = new System.Windows.Forms.Button();
            this.pnlAdvance.SuspendLayout();
            this.pnlParticular.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBorderBottom
            // 
            this.lblBorderBottom.AutoEllipsis = true;
            this.lblBorderBottom.BackColor = System.Drawing.Color.Aqua;
            this.lblBorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBorderBottom.Location = new System.Drawing.Point(0, 1010);
            this.lblBorderBottom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBorderBottom.Name = "lblBorderBottom";
            this.lblBorderBottom.Size = new System.Drawing.Size(1116, 2);
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
            this.lblTitleBar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleBar.Name = "lblTitleBar";
            this.lblTitleBar.Size = new System.Drawing.Size(1116, 34);
            this.lblTitleBar.TabIndex = 8;
            this.lblTitleBar.Text = "Report";
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
            this.lblBorderRight.Location = new System.Drawing.Point(1113, 34);
            this.lblBorderRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBorderRight.Name = "lblBorderRight";
            this.lblBorderRight.Size = new System.Drawing.Size(3, 976);
            this.lblBorderRight.TabIndex = 12;
            this.lblBorderRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBorderRight.UseCompatibleTextRendering = true;
            // 
            // lblBorderLeft
            // 
            this.lblBorderLeft.AutoEllipsis = true;
            this.lblBorderLeft.BackColor = System.Drawing.Color.Aqua;
            this.lblBorderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblBorderLeft.Location = new System.Drawing.Point(0, 34);
            this.lblBorderLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBorderLeft.Name = "lblBorderLeft";
            this.lblBorderLeft.Size = new System.Drawing.Size(3, 976);
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
            this.lblMax.Location = new System.Drawing.Point(660, 5);
            this.lblMax.Margin = new System.Windows.Forms.Padding(0);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(32, 30);
            this.lblMax.TabIndex = 14;
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
            this.lblClose.Location = new System.Drawing.Point(736, 5);
            this.lblClose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(32, 30);
            this.lblClose.TabIndex = 9;
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
            this.lblMin.Location = new System.Drawing.Point(696, 5);
            this.lblMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(32, 30);
            this.lblMin.TabIndex = 10;
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMin.UseCompatibleTextRendering = true;
            this.lblMin.Click += new System.EventHandler(this.lblMin_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Turquoise;
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnShow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(183, 252);
            this.btnShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(96, 34);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Turquoise;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(317, 252);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 34);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 54);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 22);
            this.label11.TabIndex = 51;
            this.label11.Text = "Employee Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 127);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 22);
            this.label10.TabIndex = 50;
            this.label10.Text = "Report Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 165);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 22);
            this.label9.TabIndex = 49;
            this.label9.Text = "Zero Balance";
            // 
            // lblCName
            // 
            this.lblCName.AutoSize = true;
            this.lblCName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCName.Location = new System.Drawing.Point(16, 17);
            this.lblCName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(63, 22);
            this.lblCName.TabIndex = 48;
            this.lblCName.Text = "Group";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 91);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 22);
            this.label6.TabIndex = 75;
            this.label6.Text = "Employee Code";
            // 
            // pnlAdvance
            // 
            this.pnlAdvance.Controls.Add(this.lblWait);
            this.pnlAdvance.Controls.Add(this.usGroup);
            this.pnlAdvance.Controls.Add(this.usName);
            this.pnlAdvance.Controls.Add(this.uEmpCode);
            this.pnlAdvance.Controls.Add(this.usAdvance);
            this.pnlAdvance.Controls.Add(this.usZeroBal);
            this.pnlAdvance.Controls.Add(this.lblCName);
            this.pnlAdvance.Controls.Add(this.label9);
            this.pnlAdvance.Controls.Add(this.label10);
            this.pnlAdvance.Controls.Add(this.label11);
            this.pnlAdvance.Controls.Add(this.label6);
            this.pnlAdvance.Controls.Add(this.btnCancel);
            this.pnlAdvance.Controls.Add(this.btnShow);
            this.pnlAdvance.Location = new System.Drawing.Point(16, 38);
            this.pnlAdvance.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAdvance.Name = "pnlAdvance";
            this.pnlAdvance.Size = new System.Drawing.Size(537, 310);
            this.pnlAdvance.TabIndex = 0;
            this.pnlAdvance.Visible = false;
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWait.Location = new System.Drawing.Point(237, 212);
            this.lblWait.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(117, 19);
            this.lblWait.TabIndex = 79;
            this.lblWait.Text = "Please wait ...";
            this.lblWait.Visible = false;
            // 
            // usGroup
            // 
            this.usGroup.AutoScroll = true;
            this.usGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.usGroup.BackColor = System.Drawing.Color.Cyan;
            this.usGroup.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usGroup.Location = new System.Drawing.Point(183, 15);
            this.usGroup.Margin = new System.Windows.Forms.Padding(0);
            this.usGroup.Name = "usGroup";
            this.usGroup.Padding = new System.Windows.Forms.Padding(1);
            this.usGroup.Size = new System.Drawing.Size(340, 25);
            this.usGroup.TabIndex = 0;
            this.usGroup.Tag = " ";
            this.usGroup.Load += new System.EventHandler(this.usGroup_Load);
            this.usGroup.Leave += new System.EventHandler(this.usGroup_Leave);
            // 
            // usName
            // 
            this.usName.AutoScroll = true;
            this.usName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.usName.BackColor = System.Drawing.Color.Cyan;
            this.usName.Location = new System.Drawing.Point(183, 52);
            this.usName.Margin = new System.Windows.Forms.Padding(0);
            this.usName.Name = "usName";
            this.usName.Padding = new System.Windows.Forms.Padding(1);
            this.usName.Size = new System.Drawing.Size(340, 25);
            this.usName.TabIndex = 1;
            this.usName.Tag = " ";
            this.usName.Load += new System.EventHandler(this.usName_Load);
            this.usName.Leave += new System.EventHandler(this.usName_Leave);
            // 
            // uEmpCode
            // 
            this.uEmpCode.BackColor = System.Drawing.Color.Cyan;
            this.uEmpCode.Location = new System.Drawing.Point(183, 90);
            this.uEmpCode.Margin = new System.Windows.Forms.Padding(0);
            this.uEmpCode.Name = "uEmpCode";
            this.uEmpCode.Padding = new System.Windows.Forms.Padding(1);
            this.uEmpCode.Size = new System.Drawing.Size(340, 25);
            this.uEmpCode.TabIndex = 2;
            this.uEmpCode.TabStop = false;
            this.uEmpCode.Tag = " ";
            // 
            // usAdvance
            // 
            this.usAdvance.AutoScroll = true;
            this.usAdvance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.usAdvance.BackColor = System.Drawing.Color.Cyan;
            this.usAdvance.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usAdvance.Location = new System.Drawing.Point(183, 127);
            this.usAdvance.Margin = new System.Windows.Forms.Padding(0);
            this.usAdvance.Name = "usAdvance";
            this.usAdvance.Padding = new System.Windows.Forms.Padding(1);
            this.usAdvance.Size = new System.Drawing.Size(340, 25);
            this.usAdvance.TabIndex = 3;
            this.usAdvance.Tag = " ";
            this.usAdvance.Load += new System.EventHandler(this.usAdvance_Load);
            // 
            // usZeroBal
            // 
            this.usZeroBal.AutoScroll = true;
            this.usZeroBal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.usZeroBal.BackColor = System.Drawing.Color.Cyan;
            this.usZeroBal.Location = new System.Drawing.Point(183, 164);
            this.usZeroBal.Margin = new System.Windows.Forms.Padding(0);
            this.usZeroBal.Name = "usZeroBal";
            this.usZeroBal.Padding = new System.Windows.Forms.Padding(1);
            this.usZeroBal.Size = new System.Drawing.Size(340, 25);
            this.usZeroBal.TabIndex = 4;
            this.usZeroBal.Tag = " ";
            this.usZeroBal.Load += new System.EventHandler(this.usZeroBal_Load);
            // 
            // pnlParticular
            // 
            this.pnlParticular.Controls.Add(this.uctxtFNo);
            this.pnlParticular.Controls.Add(this.label1);
            this.pnlParticular.Controls.Add(this.usParticular);
            this.pnlParticular.Controls.Add(this.lblWait5);
            this.pnlParticular.Controls.Add(this.uFrom5);
            this.pnlParticular.Controls.Add(this.uTo5);
            this.pnlParticular.Controls.Add(this.label28);
            this.pnlParticular.Controls.Add(this.label29);
            this.pnlParticular.Controls.Add(this.btnCancel5);
            this.pnlParticular.Controls.Add(this.btnShow5);
            this.pnlParticular.Location = new System.Drawing.Point(566, 34);
            this.pnlParticular.Margin = new System.Windows.Forms.Padding(4);
            this.pnlParticular.Name = "pnlParticular";
            this.pnlParticular.Size = new System.Drawing.Size(537, 310);
            this.pnlParticular.TabIndex = 16;
            this.pnlParticular.Visible = false;
            this.pnlParticular.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlParticular_Paint);
            // 
            // uctxtFNo
            // 
            this.uctxtFNo.BackColor = System.Drawing.Color.Cyan;
            this.uctxtFNo.Location = new System.Drawing.Point(161, 113);
            this.uctxtFNo.Margin = new System.Windows.Forms.Padding(0);
            this.uctxtFNo.Name = "uctxtFNo";
            this.uctxtFNo.Padding = new System.Windows.Forms.Padding(1);
            this.uctxtFNo.Size = new System.Drawing.Size(11, 25);
            this.uctxtFNo.TabIndex = 83;
            this.uctxtFNo.Tag = " ";
            this.uctxtFNo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 22);
            this.label1.TabIndex = 82;
            this.label1.Text = "Particular";
            // 
            // usParticular
            // 
            this.usParticular.BackColor = System.Drawing.Color.Cyan;
            this.usParticular.Location = new System.Drawing.Point(183, 113);
            this.usParticular.Margin = new System.Windows.Forms.Padding(0);
            this.usParticular.Name = "usParticular";
            this.usParticular.Padding = new System.Windows.Forms.Padding(1);
            this.usParticular.Size = new System.Drawing.Size(119, 25);
            this.usParticular.TabIndex = 2;
            this.usParticular.Tag = " ";
            this.usParticular.Leave += new System.EventHandler(this.usParticular_Leave);
            // 
            // lblWait5
            // 
            this.lblWait5.AutoSize = true;
            this.lblWait5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWait5.Location = new System.Drawing.Point(237, 183);
            this.lblWait5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWait5.Name = "lblWait5";
            this.lblWait5.Size = new System.Drawing.Size(117, 19);
            this.lblWait5.TabIndex = 80;
            this.lblWait5.Text = "Please wait ...";
            this.lblWait5.Visible = false;
            // 
            // uFrom5
            // 
            this.uFrom5.BackColor = System.Drawing.Color.Cyan;
            this.uFrom5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uFrom5.Location = new System.Drawing.Point(183, 50);
            this.uFrom5.Margin = new System.Windows.Forms.Padding(0);
            this.uFrom5.Name = "uFrom5";
            this.uFrom5.Padding = new System.Windows.Forms.Padding(1);
            this.uFrom5.Size = new System.Drawing.Size(119, 29);
            this.uFrom5.TabIndex = 0;
            // 
            // uTo5
            // 
            this.uTo5.BackColor = System.Drawing.Color.Cyan;
            this.uTo5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uTo5.Location = new System.Drawing.Point(404, 50);
            this.uTo5.Margin = new System.Windows.Forms.Padding(0);
            this.uTo5.Name = "uTo5";
            this.uTo5.Padding = new System.Windows.Forms.Padding(1);
            this.uTo5.Size = new System.Drawing.Size(119, 29);
            this.uTo5.TabIndex = 1;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(337, 55);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(31, 22);
            this.label28.TabIndex = 79;
            this.label28.Text = "To";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(16, 55);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(55, 22);
            this.label29.TabIndex = 78;
            this.label29.Text = "From";
            // 
            // btnCancel5
            // 
            this.btnCancel5.BackColor = System.Drawing.Color.Turquoise;
            this.btnCancel5.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnCancel5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnCancel5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnCancel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel5.Location = new System.Drawing.Point(321, 250);
            this.btnCancel5.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel5.Name = "btnCancel5";
            this.btnCancel5.Size = new System.Drawing.Size(96, 34);
            this.btnCancel5.TabIndex = 4;
            this.btnCancel5.TabStop = false;
            this.btnCancel5.Text = "Close";
            this.btnCancel5.UseVisualStyleBackColor = false;
            this.btnCancel5.Click += new System.EventHandler(this.btnCancel5_Click);
            // 
            // btnShow5
            // 
            this.btnShow5.BackColor = System.Drawing.Color.Turquoise;
            this.btnShow5.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnShow5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.btnShow5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnShow5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow5.Location = new System.Drawing.Point(187, 250);
            this.btnShow5.Margin = new System.Windows.Forms.Padding(0);
            this.btnShow5.Name = "btnShow5";
            this.btnShow5.Size = new System.Drawing.Size(96, 34);
            this.btnShow5.TabIndex = 3;
            this.btnShow5.Text = "Show";
            this.btnShow5.UseVisualStyleBackColor = false;
            this.btnShow5.Click += new System.EventHandler(this.btnShow5_Click);
            // 
            // frmFinishedDailyStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1116, 1012);
            this.ControlBox = false;
            this.Controls.Add(this.pnlParticular);
            this.Controls.Add(this.pnlAdvance);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblBorderLeft);
            this.Controls.Add(this.lblBorderRight);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblBorderBottom);
            this.Controls.Add(this.lblTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFinishedDailyStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Activated += new System.EventHandler(this.frmFinishedParticular_Activated);
            this.Load += new System.EventHandler(this.frmDemo2_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmDemo2_KeyPress);
            this.pnlAdvance.ResumeLayout(false);
            this.pnlAdvance.PerformLayout();
            this.pnlParticular.ResumeLayout(false);
            this.pnlParticular.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBorderBottom;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblBorderRight;
        private System.Windows.Forms.Label lblBorderLeft;
        private System.Windows.Forms.Label lblMax;
        public System.Windows.Forms.Button btnShow;
        public System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCName;
        private ucSearchList usGroup;
        private ucSearchList usName;
        private ucSearchList usAdvance;
        private ucSearchList usZeroBal;
        private System.Windows.Forms.Label label6;
        private uctxt uEmpCode;
        public System.Windows.Forms.Label lblTitleBar;
        public System.Windows.Forms.Panel pnlAdvance;
        private System.Windows.Forms.Label lblWait;
        public System.Windows.Forms.Panel pnlParticular;
        private System.Windows.Forms.Label lblWait5;
        private ucDate uFrom5;
        private ucDate uTo5;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        public System.Windows.Forms.Button btnCancel5;
        public System.Windows.Forms.Button btnShow5;
        private System.Windows.Forms.Label label1;
        private ucSearchList usParticular;
        private uctxt uctxtFNo;
    }
}