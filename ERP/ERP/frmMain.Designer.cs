namespace ERP
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuAll = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOpeningStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ratioSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawMaterialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedGoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.finishedGoodToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemWiseReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyStockRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemWiseSalesRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productionToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayWiseReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thicknessWiseReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintainanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInportFromTally = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblBorderBottom = new System.Windows.Forms.Label();
            this.lblBorderRight = new System.Windows.Forms.Label();
            this.lblBorderLeft = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.ShortCutBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mnuAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.ShortCutBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuAll
            // 
            this.mnuAll.BackColor = System.Drawing.Color.Aqua;
            this.mnuAll.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuAll.GripMargin = new System.Windows.Forms.Padding(20);
            this.mnuAll.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuAll.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.transactionToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.maintainanceToolStripMenuItem});
            this.mnuAll.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuAll.Location = new System.Drawing.Point(0, 0);
            this.mnuAll.Name = "mnuAll";
            this.mnuAll.Padding = new System.Windows.Forms.Padding(11, 7, 0, 7);
            this.mnuAll.ShowItemToolTips = true;
            this.mnuAll.Size = new System.Drawing.Size(1170, 49);
            this.mnuAll.Stretch = false;
            this.mnuAll.TabIndex = 1;
            this.mnuAll.Text = "menuStrip1";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.AutoToolTip = true;
            this.masterToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyProfileToolStripMenuItem,
            this.ledgerToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.unitToolStripMenuItem,
            this.taxCategoryToolStripMenuItem,
            this.ratioSetupToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(104, 35);
            this.masterToolStripMenuItem.Text = "Master";
            this.masterToolStripMenuItem.Click += new System.EventHandler(this.masterToolStripMenuItem_Click);
            // 
            // companyProfileToolStripMenuItem
            // 
            this.companyProfileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.companyProfileToolStripMenuItem.Name = "companyProfileToolStripMenuItem";
            this.companyProfileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.companyProfileToolStripMenuItem.Size = new System.Drawing.Size(399, 36);
            this.companyProfileToolStripMenuItem.Text = "Company Profile";
            this.companyProfileToolStripMenuItem.Click += new System.EventHandler(this.companyProfileToolStripMenuItem_Click);
            // 
            // ledgerToolStripMenuItem
            // 
            this.ledgerToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.ledgerToolStripMenuItem.Name = "ledgerToolStripMenuItem";
            this.ledgerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.ledgerToolStripMenuItem.Size = new System.Drawing.Size(399, 36);
            this.ledgerToolStripMenuItem.Text = "Supplier/Customer";
            this.ledgerToolStripMenuItem.Click += new System.EventHandler(this.ledgerToolStripMenuItem_Click);
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.itemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsToolStripMenuItem1,
            this.itemTypeToolStripMenuItem,
            this.itemOpeningStockToolStripMenuItem});
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(399, 36);
            this.itemsToolStripMenuItem.Text = "Items";
            // 
            // itemsToolStripMenuItem1
            // 
            this.itemsToolStripMenuItem1.Name = "itemsToolStripMenuItem1";
            this.itemsToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.itemsToolStripMenuItem1.Size = new System.Drawing.Size(410, 36);
            this.itemsToolStripMenuItem1.Text = "Raw Material";
            this.itemsToolStripMenuItem1.Click += new System.EventHandler(this.itemsToolStripMenuItem1_Click);
            // 
            // itemTypeToolStripMenuItem
            // 
            this.itemTypeToolStripMenuItem.Name = "itemTypeToolStripMenuItem";
            this.itemTypeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.itemTypeToolStripMenuItem.Size = new System.Drawing.Size(410, 36);
            this.itemTypeToolStripMenuItem.Text = "Finished Good";
            this.itemTypeToolStripMenuItem.Click += new System.EventHandler(this.itemTypeToolStripMenuItem_Click);
            // 
            // itemOpeningStockToolStripMenuItem
            // 
            this.itemOpeningStockToolStripMenuItem.Name = "itemOpeningStockToolStripMenuItem";
            this.itemOpeningStockToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.itemOpeningStockToolStripMenuItem.Size = new System.Drawing.Size(410, 36);
            this.itemOpeningStockToolStripMenuItem.Text = "Item Opening Stock";
            this.itemOpeningStockToolStripMenuItem.Click += new System.EventHandler(this.itemOpeningStockToolStripMenuItem_Click);
            // 
            // unitToolStripMenuItem
            // 
            this.unitToolStripMenuItem.Name = "unitToolStripMenuItem";
            this.unitToolStripMenuItem.Size = new System.Drawing.Size(399, 36);
            this.unitToolStripMenuItem.Text = "Unit ";
            this.unitToolStripMenuItem.Click += new System.EventHandler(this.unitToolStripMenuItem_Click);
            // 
            // taxCategoryToolStripMenuItem
            // 
            this.taxCategoryToolStripMenuItem.Name = "taxCategoryToolStripMenuItem";
            this.taxCategoryToolStripMenuItem.Size = new System.Drawing.Size(399, 36);
            this.taxCategoryToolStripMenuItem.Text = "Tax Category";
            this.taxCategoryToolStripMenuItem.Click += new System.EventHandler(this.taxCategoryToolStripMenuItem_Click);
            // 
            // ratioSetupToolStripMenuItem
            // 
            this.ratioSetupToolStripMenuItem.Name = "ratioSetupToolStripMenuItem";
            this.ratioSetupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.ratioSetupToolStripMenuItem.Size = new System.Drawing.Size(399, 36);
            this.ratioSetupToolStripMenuItem.Text = "Ratio Setup";
            this.ratioSetupToolStripMenuItem.Click += new System.EventHandler(this.ratioSetupToolStripMenuItem_Click);
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saleToolStripMenuItem,
            this.purchaseToolStripMenuItem,
            this.saleReturnToolStripMenuItem,
            this.purchaseReturnToolStripMenuItem,
            this.productionToolStripMenuItem});
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(159, 35);
            this.transactionToolStripMenuItem.Text = "Transaction";
            // 
            // saleToolStripMenuItem
            // 
            this.saleToolStripMenuItem.Name = "saleToolStripMenuItem";
            this.saleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.saleToolStripMenuItem.Size = new System.Drawing.Size(440, 36);
            this.saleToolStripMenuItem.Text = "Finished Good Sale";
            this.saleToolStripMenuItem.Click += new System.EventHandler(this.saleToolStripMenuItem_Click);
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(440, 36);
            this.purchaseToolStripMenuItem.Text = "Raw MaterialPurchase";
            this.purchaseToolStripMenuItem.Click += new System.EventHandler(this.purchaseToolStripMenuItem_Click);
            // 
            // saleReturnToolStripMenuItem
            // 
            this.saleReturnToolStripMenuItem.Name = "saleReturnToolStripMenuItem";
            this.saleReturnToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.saleReturnToolStripMenuItem.Size = new System.Drawing.Size(440, 36);
            this.saleReturnToolStripMenuItem.Text = "Sale Return";
            this.saleReturnToolStripMenuItem.Click += new System.EventHandler(this.saleReturnToolStripMenuItem_Click);
            // 
            // purchaseReturnToolStripMenuItem
            // 
            this.purchaseReturnToolStripMenuItem.Name = "purchaseReturnToolStripMenuItem";
            this.purchaseReturnToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.purchaseReturnToolStripMenuItem.Size = new System.Drawing.Size(440, 36);
            this.purchaseReturnToolStripMenuItem.Text = "Purchase Return";
            this.purchaseReturnToolStripMenuItem.Click += new System.EventHandler(this.purchaseReturnToolStripMenuItem_Click);
            // 
            // productionToolStripMenuItem
            // 
            this.productionToolStripMenuItem.Name = "productionToolStripMenuItem";
            this.productionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.productionToolStripMenuItem.Size = new System.Drawing.Size(440, 36);
            this.productionToolStripMenuItem.Text = "Production";
            this.productionToolStripMenuItem.Click += new System.EventHandler(this.productionToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dayBookToolStripMenuItem,
            this.accountBookToolStripMenuItem,
            this.finishedGoodToolStripMenuItem1,
            this.productionToolStripMenuItem2,
            this.bISToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(117, 35);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // dayBookToolStripMenuItem
            // 
            this.dayBookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawMaterialsToolStripMenuItem,
            this.finishedGoodToolStripMenuItem});
            this.dayBookToolStripMenuItem.Name = "dayBookToolStripMenuItem";
            this.dayBookToolStripMenuItem.Size = new System.Drawing.Size(274, 36);
            this.dayBookToolStripMenuItem.Text = "Stock Report";
            // 
            // rawMaterialsToolStripMenuItem
            // 
            this.rawMaterialsToolStripMenuItem.Name = "rawMaterialsToolStripMenuItem";
            this.rawMaterialsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.R)));
            this.rawMaterialsToolStripMenuItem.Size = new System.Drawing.Size(405, 36);
            this.rawMaterialsToolStripMenuItem.Text = "Raw Materials";
            this.rawMaterialsToolStripMenuItem.Click += new System.EventHandler(this.rawMaterialsToolStripMenuItem_Click);
            // 
            // finishedGoodToolStripMenuItem
            // 
            this.finishedGoodToolStripMenuItem.Name = "finishedGoodToolStripMenuItem";
            this.finishedGoodToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.F)));
            this.finishedGoodToolStripMenuItem.Size = new System.Drawing.Size(405, 36);
            this.finishedGoodToolStripMenuItem.Text = "Finished Good";
            this.finishedGoodToolStripMenuItem.Click += new System.EventHandler(this.finishedGoodToolStripMenuItem_Click);
            // 
            // accountBookToolStripMenuItem
            // 
            this.accountBookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saleRegisterToolStripMenuItem,
            this.purchaseRegisterToolStripMenuItem,
            this.toolStripSeparator9});
            this.accountBookToolStripMenuItem.Name = "accountBookToolStripMenuItem";
            this.accountBookToolStripMenuItem.Size = new System.Drawing.Size(274, 36);
            this.accountBookToolStripMenuItem.Text = "Account Book";
            // 
            // saleRegisterToolStripMenuItem
            // 
            this.saleRegisterToolStripMenuItem.Name = "saleRegisterToolStripMenuItem";
            this.saleRegisterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.saleRegisterToolStripMenuItem.Size = new System.Drawing.Size(450, 36);
            this.saleRegisterToolStripMenuItem.Text = "Sale Register";
            this.saleRegisterToolStripMenuItem.Click += new System.EventHandler(this.saleRegisterToolStripMenuItem_Click);
            // 
            // purchaseRegisterToolStripMenuItem
            // 
            this.purchaseRegisterToolStripMenuItem.Name = "purchaseRegisterToolStripMenuItem";
            this.purchaseRegisterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.P)));
            this.purchaseRegisterToolStripMenuItem.Size = new System.Drawing.Size(450, 36);
            this.purchaseRegisterToolStripMenuItem.Text = "Purchase Register";
            this.purchaseRegisterToolStripMenuItem.Click += new System.EventHandler(this.purchaseRegisterToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(447, 6);
            // 
            // finishedGoodToolStripMenuItem1
            // 
            this.finishedGoodToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemWiseReportToolStripMenuItem,
            this.dailyStockRegisterToolStripMenuItem,
            this.itemWiseSalesRegisterToolStripMenuItem});
            this.finishedGoodToolStripMenuItem1.Name = "finishedGoodToolStripMenuItem1";
            this.finishedGoodToolStripMenuItem1.Size = new System.Drawing.Size(274, 36);
            this.finishedGoodToolStripMenuItem1.Text = "Finished Good";
            // 
            // itemWiseReportToolStripMenuItem
            // 
            this.itemWiseReportToolStripMenuItem.Name = "itemWiseReportToolStripMenuItem";
            this.itemWiseReportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.I)));
            this.itemWiseReportToolStripMenuItem.Size = new System.Drawing.Size(548, 36);
            this.itemWiseReportToolStripMenuItem.Text = "Item Wise Report";
            this.itemWiseReportToolStripMenuItem.Click += new System.EventHandler(this.itemWiseReportToolStripMenuItem_Click);
            // 
            // dailyStockRegisterToolStripMenuItem
            // 
            this.dailyStockRegisterToolStripMenuItem.Name = "dailyStockRegisterToolStripMenuItem";
            this.dailyStockRegisterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.D)));
            this.dailyStockRegisterToolStripMenuItem.Size = new System.Drawing.Size(548, 36);
            this.dailyStockRegisterToolStripMenuItem.Text = "Daily Stock Register";
            this.dailyStockRegisterToolStripMenuItem.Click += new System.EventHandler(this.dailyStockRegisterToolStripMenuItem_Click);
            // 
            // itemWiseSalesRegisterToolStripMenuItem
            // 
            this.itemWiseSalesRegisterToolStripMenuItem.Name = "itemWiseSalesRegisterToolStripMenuItem";
            this.itemWiseSalesRegisterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.itemWiseSalesRegisterToolStripMenuItem.Size = new System.Drawing.Size(548, 36);
            this.itemWiseSalesRegisterToolStripMenuItem.Text = "Item Wise Sales Register";
            this.itemWiseSalesRegisterToolStripMenuItem.Click += new System.EventHandler(this.itemWiseSalesRegisterToolStripMenuItem_Click);
            // 
            // productionToolStripMenuItem2
            // 
            this.productionToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monthlyReportToolStripMenuItem,
            this.dayWiseReportToolStripMenuItem,
            this.thicknessWiseReportToolStripMenuItem});
            this.productionToolStripMenuItem2.Name = "productionToolStripMenuItem2";
            this.productionToolStripMenuItem2.Size = new System.Drawing.Size(274, 36);
            this.productionToolStripMenuItem2.Text = "Production";
            // 
            // monthlyReportToolStripMenuItem
            // 
            this.monthlyReportToolStripMenuItem.Name = "monthlyReportToolStripMenuItem";
            this.monthlyReportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.M)));
            this.monthlyReportToolStripMenuItem.Size = new System.Drawing.Size(504, 36);
            this.monthlyReportToolStripMenuItem.Text = "Monthly Report";
            this.monthlyReportToolStripMenuItem.Click += new System.EventHandler(this.monthlyReportToolStripMenuItem_Click);
            // 
            // dayWiseReportToolStripMenuItem
            // 
            this.dayWiseReportToolStripMenuItem.Name = "dayWiseReportToolStripMenuItem";
            this.dayWiseReportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.dayWiseReportToolStripMenuItem.Size = new System.Drawing.Size(504, 36);
            this.dayWiseReportToolStripMenuItem.Text = "Day Wise Report";
            this.dayWiseReportToolStripMenuItem.Click += new System.EventHandler(this.dayWiseReportToolStripMenuItem_Click);
            // 
            // thicknessWiseReportToolStripMenuItem
            // 
            this.thicknessWiseReportToolStripMenuItem.Name = "thicknessWiseReportToolStripMenuItem";
            this.thicknessWiseReportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.T)));
            this.thicknessWiseReportToolStripMenuItem.Size = new System.Drawing.Size(504, 36);
            this.thicknessWiseReportToolStripMenuItem.Text = "Thickness Wise Report";
            this.thicknessWiseReportToolStripMenuItem.Click += new System.EventHandler(this.thicknessWiseReportToolStripMenuItem_Click);
            // 
            // bISToolStripMenuItem
            // 
            this.bISToolStripMenuItem.Name = "bISToolStripMenuItem";
            this.bISToolStripMenuItem.Size = new System.Drawing.Size(274, 36);
            this.bISToolStripMenuItem.Text = "BIS";
            this.bISToolStripMenuItem.Click += new System.EventHandler(this.bISToolStripMenuItem_Click);
            // 
            // maintainanceToolStripMenuItem
            // 
            this.maintainanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExport,
            this.mnuImport,
            this.mnuInportFromTally,
            this.mnuBackup});
            this.maintainanceToolStripMenuItem.Name = "maintainanceToolStripMenuItem";
            this.maintainanceToolStripMenuItem.Size = new System.Drawing.Size(177, 35);
            this.maintainanceToolStripMenuItem.Text = "Maintainance";
            // 
            // mnuExport
            // 
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(316, 36);
            this.mnuExport.Text = "Export";
            this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
            // 
            // mnuImport
            // 
            this.mnuImport.Name = "mnuImport";
            this.mnuImport.Size = new System.Drawing.Size(316, 36);
            this.mnuImport.Text = "Import";
            // 
            // mnuInportFromTally
            // 
            this.mnuInportFromTally.Name = "mnuInportFromTally";
            this.mnuInportFromTally.Size = new System.Drawing.Size(316, 36);
            this.mnuInportFromTally.Text = "Import From Excel";
            // 
            // mnuBackup
            // 
            this.mnuBackup.Name = "mnuBackup";
            this.mnuBackup.Size = new System.Drawing.Size(316, 36);
            this.mnuBackup.Text = "Backup";
            this.mnuBackup.Click += new System.EventHandler(this.mnuBackup_Click);
            // 
            // lblBorderBottom
            // 
            this.lblBorderBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(170)))), ((int)(((byte)(132)))));
            this.lblBorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBorderBottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBorderBottom.Location = new System.Drawing.Point(0, 902);
            this.lblBorderBottom.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBorderBottom.Name = "lblBorderBottom";
            this.lblBorderBottom.Size = new System.Drawing.Size(1170, 4);
            this.lblBorderBottom.TabIndex = 10;
            // 
            // lblBorderRight
            // 
            this.lblBorderRight.BackColor = System.Drawing.Color.Aqua;
            this.lblBorderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBorderRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBorderRight.Location = new System.Drawing.Point(1166, 49);
            this.lblBorderRight.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBorderRight.Name = "lblBorderRight";
            this.lblBorderRight.Size = new System.Drawing.Size(4, 853);
            this.lblBorderRight.TabIndex = 11;
            this.lblBorderRight.Click += new System.EventHandler(this.lblBorderRight_Click);
            // 
            // lblBorderLeft
            // 
            this.lblBorderLeft.BackColor = System.Drawing.Color.Aqua;
            this.lblBorderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblBorderLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBorderLeft.Location = new System.Drawing.Point(0, 49);
            this.lblBorderLeft.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBorderLeft.Name = "lblBorderLeft";
            this.lblBorderLeft.Size = new System.Drawing.Size(4, 853);
            this.lblBorderLeft.TabIndex = 12;
            this.lblBorderLeft.Click += new System.EventHandler(this.lblBorderLeft_Click);
            // 
            // lblClose
            // 
            this.lblClose.AutoEllipsis = true;
            this.lblClose.BackColor = System.Drawing.Color.Aqua;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Image = global::ERP.Properties.Resources.close_window_32px;
            this.lblClose.Location = new System.Drawing.Point(952, 2);
            this.lblClose.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(44, 44);
            this.lblClose.TabIndex = 14;
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.UseCompatibleTextRendering = true;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblMin
            // 
            this.lblMin.AutoEllipsis = true;
            this.lblMin.BackColor = System.Drawing.Color.Aqua;
            this.lblMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMin.Image = global::ERP.Properties.Resources.minimize_window_32px;
            this.lblMin.Location = new System.Drawing.Point(897, 2);
            this.lblMin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(44, 44);
            this.lblMin.TabIndex = 15;
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMin.UseCompatibleTextRendering = true;
            this.lblMin.Click += new System.EventHandler(this.lblMin_Click);
            // 
            // ShortCutBar
            // 
            this.ShortCutBar.AutoSize = false;
            this.ShortCutBar.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShortCutBar.GripMargin = new System.Windows.Forms.Padding(0);
            this.ShortCutBar.ImageScalingSize = new System.Drawing.Size(15, 15);
            this.ShortCutBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.ShortCutBar.Location = new System.Drawing.Point(4, 863);
            this.ShortCutBar.Name = "ShortCutBar";
            this.ShortCutBar.Padding = new System.Windows.Forms.Padding(2, 0, 18, 0);
            this.ShortCutBar.Size = new System.Drawing.Size(1162, 39);
            this.ShortCutBar.TabIndex = 21;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 34);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.White;
            this.lblTime.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(1113, 72);
            this.lblTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(28, 27);
            this.lblTime.TabIndex = 23;
            this.lblTime.Text = "--";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Aqua;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(1069, 72);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 32);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "--";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.BackgroundImage = global::ERP.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1170, 906);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.ShortCutBar);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblBorderLeft);
            this.Controls.Add(this.lblBorderRight);
            this.Controls.Add(this.lblBorderBottom);
            this.Controls.Add(this.mnuAll);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnuAll;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "  ";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuAll.ResumeLayout(false);
            this.mnuAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ShortCutBar.ResumeLayout(false);
            this.ShortCutBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuAll;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem itemTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemOpeningStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label lblBorderBottom;
        private System.Windows.Forms.Label lblBorderRight;
        private System.Windows.Forms.Label lblBorderLeft;
        private System.Windows.Forms.ToolStripMenuItem saleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleReturnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseReturnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleRegisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseRegisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.ToolStripMenuItem rawMaterialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finishedGoodToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem itemWiseReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finishedGoodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productionToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem monthlyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayWiseReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thicknessWiseReportToolStripMenuItem;
        public System.Windows.Forms.StatusStrip ShortCutBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem dailyStockRegisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemWiseSalesRegisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ratioSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bISToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintainanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.ToolStripMenuItem mnuImport;
        private System.Windows.Forms.ToolStripMenuItem mnuBackup;
        private System.Windows.Forms.ToolStripMenuItem mnuInportFromTally;
        public System.Windows.Forms.Label lblTime;
        public System.Windows.Forms.Label lblTitle;
    }
}

