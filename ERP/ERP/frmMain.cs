using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMain : Form
    {
        string sql = "";
        SqlCommand cmd;
        SqlDataReader rd;

        public frmMain()
        {
            InitializeComponent();
        }

        private void companyProfileToolStripMenuItem_Click(object sender , EventArgs e)
        {
            RunForm(new frmCompany());
        }

        private void frmMain_Load(object sender , EventArgs e)
        {
            this.Width = Globals.ScreenWith;
            this.Height = Globals.ScreenHeight;
            this.Top = 0;
            this.Left = 0;
            lblClose.Top = (mnuAll.Height - lblClose.Height) / 2;
            lblClose.Left = this.Width - lblClose.Width - 4;
            lblMin.Top = lblClose.Top;
            lblMin.Left = lblClose.Left - lblMin.Width-2;
            lblBorderBottom.Height = 2;
            lblBorderRight.Width = 2;
            lblBorderLeft.Width = 2;
            
            Globals.MinFormLocation.Columns.Add("left" , "left");
            Globals.MinFormLocation.Columns.Add("top" , "top");
            Globals.MinFormLocation.Rows.Clear();

            //Globals.SoftPath = @"E:\C#.NET\INVENTORY\ERP\ERP";
            //Globals.SoftPath = @"F:\C#.NET\INVENTORY_MGMT\ERP\ERP";
            Globals.SoftPath = Application.StartupPath;
            Globals.ServerName = File.ReadAllText(Globals.SoftPath + "\\Server.ini");
            Globals.DatabaseName = File.ReadAllText(Globals.SoftPath + "\\Data.ini");

            if(Globals.DatabaseName.ToUpper().Contains("MANAGEMENT"))  //Actual
            {
                mnuExport.Enabled = true;
                mnuExport.Visible = true;
                mnuImport.Enabled = true;
                mnuImport.Visible = true;
                mnuInportFromTally.Enabled = true;
                mnuInportFromTally.Visible = true;
            }
            else //Physical
            {
                mnuExport.Enabled = false;
                mnuExport.Visible = false;
                mnuImport.Enabled = false;
                mnuImport.Visible = false;
                mnuInportFromTally.Enabled = false;
                mnuInportFromTally.Visible = false;
            }

            Globals.START();

            sql = "Select CName,GetDate() as VDate from m_Company";
            cmd = new SqlCommand(sql, Globals.con);
            rd = cmd.ExecuteReader();
            rd.Read();
            Globals.ServerDateTime = DateTime.Parse(rd["VDate"].ToString()).AddSeconds(1);
            lblTitle.Text = rd["CName"].ToString();
            cmd.Dispose();
            rd.Close();

            lblTime.Text = DateTime.Now.ToString("dd MMMM yyyy hh:mm:ss tt");
            timer1.Enabled = true;
            lblTime.Left = mnuAll.Width - lblTime.Width - lblBorderLeft.Width - 10;
            lblTime.Top = mnuAll.Height + mnuAll.Top + 2;

            lblTitle.Left = (mnuAll.Width - lblTitle.Width) / 2 + 50;
            lblTitle.Top = (mnuAll.Height - lblTitle.Height) / 2 + 5;

            ShortCutBar.Items.Clear();
            ShortCutBar.Items.Add("     F2=Jump    |    F5=Refresh    |    Ctl+S=Save    |    Ctl+L=List    |    Ctl+W=Show    |    Ctl+D=Delete    |    Ctl+U=Update    |    Ctl+X=Close    |    Escape=Close    |    Ctl+P=Print    |    Ctl+V=Print Preview    |    Ctl+M=Minimize    |    Ctl+N=Maximize");
            ShortCutBar.Items[0].Width = ShortCutBar.Width;
            ShortCutBar.BackColor = Color.Cyan;                                    
            ShortCutBar.Items[0].BackColor = Color.Cyan;
            ShortCutBar.Items[0].TextAlign = ContentAlignment.MiddleCenter;
        }

        private void frmMain_Activated(object sender , EventArgs e)
        {

        }


        private void unitToolStripMenuItem_Click(object sender , EventArgs e)
        {
            RunForm(new frmUnit());

        }
        private void lblClose_Click(object sender , EventArgs e)
        {
            Application.Exit();
        }
        private void lblMin_Click(object sender , EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void itemBrandToolStripMenuItem_Click(object sender , EventArgs e)
        {
           
        }

        private void itemGroupToolStripMenuItem_Click(object sender , EventArgs e)
        {
            RunForm(new frmGroup());
        }
        private void RunForm(Form myForm)
        {
            try
            {
                if (!Application.OpenForms.Cast<Form>().Any(form => form.Name == myForm.Name))
                {
                    myForm.ShowInTaskbar = false;
                    myForm.MdiParent = this;
                    myForm.Show();
                }
            }
            catch (Exception ex)
            {
                Globals.msgbox(this,ex.Message);
            }
        }

        private void taxCategoryToolStripMenuItem_Click(object sender , EventArgs e)
        {
            RunForm(new frmTaxCategory());
        }

        private void storeLocationToolStripMenuItem_Click(object sender , EventArgs e)
        {
            RunForm(new frmExport());
        }

        private void itemsToolStripMenuItem1_Click(object sender , EventArgs e)
        {
            RunForm(new frmRawMaterial());
        }

        private void lblBorderRight_Click(object sender , EventArgs e)
        {

        }

        private void lblBorderLeft_Click(object sender , EventArgs e)
        {

        }

        private void employeeEntryToolStripMenuItem_Click(object sender , EventArgs e)
        {

        }

        private void reportToolStripMenuItem_Click(object sender , EventArgs e)
        {

        }

        private void salaryRegisterToolStripMenuItem_Click(object sender , EventArgs e)
        {

        }

        private void ManualAttendance_Click(object sender , EventArgs e)
        {
            RunForm(new frmAttendance());
        }

        private void Advance_Click(object sender , EventArgs e)
        {
           
        }

        private void mnuHoliday_Click(object sender , EventArgs e)
        {
            RunForm(new frmOpening());
        }

        private void monthlyEmployeeAttendanceToolStripMenuItem_Click(object sender , EventArgs e)
        {
            
        }

        private void salaryRegisterToolStripMenuItem1_Click(object sender , EventArgs e)
        {
         
        }

        private void ledgerGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
        }

        private void toolStripSeparator8_Click(object sender, EventArgs e)
        {

        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunForm(new frmSales());
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunForm(new frmParty());
        }

        private void itemTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunForm(new frmFinishedGood());
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunForm(new frmPurchase());
        }

        private void hSNCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunForm(new frmItem());            
        }

        private void productionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunForm(new frmProduction());
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunForm(new frmPurchase_Return());
        }

        private void saleReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunForm(new frmSales_Return());
        }

        private void itemOpeningStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunForm(new frmOpening());
        }

        private void rawMaterialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmReportRawStock frm = new frmReportRawStock();
            frm.ShowInTaskbar = false;
            frm.lblTitleBar.Text = "Raw Materials Stock Report";
            frm.pnlFStock.Visible = true;
            frm.Show(this);  
        }

        private void finishedGoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportFinished frm = new frmReportFinished();
            frm.ShowInTaskbar = false;
            frm.lblTitleBar.Text = "Finished Good Stock Report";
            frm.pnlFStock.Visible = true;
            frm.Show(this);
        }

        private void productionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReportProduction frm = new frmReportProduction();
            frm.ShowInTaskbar = false;
            frm.lblTitleBar.Text = "Production Report";
            frm.pnlProduction.Visible = true;
            frm.Show(this);
        }

        private void purchaseRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseRegister frm = new frmPurchaseRegister();
            frm.ShowInTaskbar = false;
            frm.lblTitleBar.Text = "Purchase Register";
            frm.pnlPurchaseRegister.Visible = true;
            frm.Show(this);
        }

        private void saleRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesRegister frm = new frmSalesRegister();
            frm.ShowInTaskbar = false;
            frm.lblTitleBar.Text = "Sales Register";
            frm.pnlSalesRegister.Visible = true;
            frm.Show(this);
        }

        private void itemWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFinishedParticular frm = new frmFinishedParticular();
            frm.ShowInTaskbar = false;
            frm.lblTitleBar.Text = "Daily Stock Register";
            frm.pnlParticular.Visible = true;
            frm.Show(this);
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void monthlyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportProduction frm = new frmReportProduction();
            frm.ShowInTaskbar = false;
            frm.lblTitleBar.Text = "Month WiseProduction Report";
            frm.pnlProduction.Visible = true;
            frm.Show(this);
        }

        private void dayWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportProductionday frm = new frmReportProductionday();
            frm.ShowInTaskbar = false;
            frm.lblTitleBar.Text = "Day WiseProduction Report";
            frm.pnlProduction.Visible = true;
            frm.Show(this);
        }

        private void thicknessWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportThickness frm = new frmReportThickness();
            frm.ShowInTaskbar = false;
            frm.lblTitleBar.Text = "Thickness Wise Production Report";
            frm.pnlProduction.Visible = true;
            frm.Show(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Globals.ServerDateTime = Globals.ServerDateTime.AddSeconds(1);
            lblTime.Text = Globals.ServerDateTime.ToString("dd MMMM yyyy  hh:mm:ss tt");
        }

        private void dailyStockRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFinishedDailyStock frm = new frmFinishedDailyStock();
            frm.ShowInTaskbar = false;
            frm.lblTitleBar.Text = "Daily Stock Register";
            frm.pnlParticular.Visible = true;
            frm.Show(this);
        }

        private void itemWiseSalesRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportSalesParticular frm = new frmReportSalesParticular();
            frm.ShowInTaskbar = false;
            frm.lblTitleBar.Text = "ItemWise Sales Register";
            frm.pnlsales.Visible = true;
            frm.Show(this);
        }

        private void itemWiseBISReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void laminatesRawMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void certificateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ratioSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunForm(new frmRatioSetup());
        }

        private void rawMaterialsStockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iSICertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void iSICertificateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void bISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmISI_Certificate frm = new frmISI_Certificate();
            frm.ShowInTaskbar = false;
            frm.lblTitleBar.Text = "ISI Certificate";
            frm.pnlISI.Visible = true;
            frm.Show(this);
        }

        private void mnuExport_Click(object sender, EventArgs e)
        {
            RunForm(new frmExport());
        }

        private void mnuBackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fwd = new FolderBrowserDialog();
            if (fwd.ShowDialog() == DialogResult.OK)
            {
                Application.DoEvents();
                BackupDatabase(Globals.DatabaseName, "sa", "vin0101", Globals.ServerName, fwd.SelectedPath.Trim());
            }
        }
        public void BackupDatabase(string databaseName, string userName, string password, string serverName, string destinationPath)
        {
            try
            {
                //Define a Backup object variable.
                Backup sqlBackup = new Backup();
                //Specify the type of backup, the description, the name, and the database to be backed up.

                sqlBackup.Action = BackupActionType.Database;

                sqlBackup.BackupSetDescription = "BackUp of:" + databaseName + "on" + Globals.ServerDateTime.ToShortDateString();

                sqlBackup.BackupSetName = "FullBackUp";

                sqlBackup.Database = databaseName;

                if (destinationPath.Substring(destinationPath.Length - 1, 1) == "\\") destinationPath = destinationPath.Remove(destinationPath.Length - 1, 1);
                string BackupFileName = databaseName + " on " + Globals.ServerDateTime.ToString("dd.MM.yyyy_hhmmss") + ".bak";

                //Declare a BackupDeviceItem
                BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath + "\\" + BackupFileName, DeviceType.File);

                //Define Server connection

                ServerConnection connection = new ServerConnection(serverName, userName, password);
                //To Avoid TimeOut Exception

                Server sqlServer = new Server(connection);
                sqlServer.ConnectionContext.StatementTimeout = 60 * 60;
                Database db = sqlServer.Databases[databaseName]; //(Reference Database As microsoft.sqlserver.management.smo.database, not as System.entity.database )

                sqlBackup.Initialize = true;

                sqlBackup.Checksum = true;

                sqlBackup.ContinueAfterError = true;
                //Add the device to the Backup object.

                sqlBackup.Devices.Add(deviceItem);

                //Set the Incremental property to False to specify that this is a full database backup. 
                sqlBackup.Incremental = false;
                //sqlBackup.ExpirationDate = DateTime.Now.AddDays(1);

                //Specify that the log must be truncated after the backup is complete.        
                sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
                sqlBackup.FormatMedia = false;

                Application.DoEvents();

                //Run SqlBackup to perform the full database backup on the instance of SQL Server. 
                sqlBackup.SqlBackup(sqlServer);

                //Remove the backup device from the Backup object.           
                sqlBackup.Devices.Remove(deviceItem);
                Globals.msgbox(this, "Backup Done.");
            }
            catch (Exception ex)
            {
                Globals.msgbox("ERROR:" + ex.Message);
            }
        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
