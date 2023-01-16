using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using System.Web;
using ERP;
using Dapper;

namespace ERP
{
    public partial class frmReportThickness: Form
    { 
        bool drag = false;
        Point Start_Point = new Point(0 , 0);
        Point Store_Location=new Point(0,0);
        Size Store_Size=new Size(0,0);
        int left;
        int top;
        int x = Globals.ScreenWith;
        int y = Globals.ScreenHeight;
        string FormMode;
        //-----SQL Database object
        string sql = null;
        SqlCommand cmd;
        SqlDataReader rd;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //-----END
        public frmReportThickness()
        {
            InitializeComponent();
        }
        private void lblTitleBar_MouseDown(object sender , MouseEventArgs e)
        {
            drag = true;
            Start_Point = new Point(e.X , e.Y);
        }
        private void lblTitleBar_MouseUp(object sender , MouseEventArgs e)
        {
            drag = false;
        }
        private void lblTitleBar_MouseMove(object sender , MouseEventArgs e)
        {
            if (drag)
            {
                Point P = PointToScreen(e.Location);
                this.Location = new Point(P.X - Start_Point.X , P.Y - Start_Point.Y);
            }
        }
        private void lblClose_Click(object sender , EventArgs e)
        {
            this.Dispose();
        }
        private void lblMin_Click(object sender , EventArgs e)
        {
            
            int i;
            FormMode = "Min";
            frmMain frm = new frmMain();

            lblTitleBar.TextAlign = ContentAlignment.MiddleLeft;
            Store_Size = this.Size;
            Store_Location = this.Location;

            this.Width = 200;
            this.Height = lblTitleBar.Height;
            left = 5;
            top = y - this.Height - frm.MainMenuStrip.Height - 6;

            if (Globals.MinFormLocation.Rows.Count-1==0) 
            {   
                this.Location = new Point(left,top);
                Globals.MinFormLocation.Rows.Add(left,top);
            }
            else
            {  
                bool exist=false;
                for (int j = 0 ; j < 7 ; j++)
                {
                    for (i = 0 ; i < Globals.MinFormLocation.Rows.Count - 1 ; i++)
                    {
                        exist = false;
                        if (Convert.ToInt32(Globals.MinFormLocation.Rows[i].Cells[0].Value) == left && Convert.ToInt32(Globals.MinFormLocation.Rows[i].Cells[1].Value) == top)
                        {
                            exist = true;
                            break;
                        }
                    }
                    if(exist == false)
                    {
                        break;
                    }
                    left = left + this.Width + 5; //5 205 405 605 805
                    //top = Convert.ToInt32(Globals.MinFormLocation.Rows[i].Cells[1].Value);
                }
                Globals.MinFormLocation.Rows.Add(left , top);
                this.Location = new Point(left , top);

            }
            lblTitleBar.Enabled = false;
            lblMax.Visible = true;
            lblMax.Top = (lblTitleBar.Height - lblMax.Height) / 2;
            lblMax.Left = this.Width - lblMax.Width - 2;
        }
        private void lblMax_Click(object sender , EventArgs e)
        {
       
            if (FormMode == "Min")
            {
                for (int i = 0 ; i < Globals.MinFormLocation.Rows.Count-1 ; i++)
                {
                    if (Convert.ToInt32(Globals.MinFormLocation.Rows[i].Cells[0].Value) == Convert.ToInt32(this.Location.X) && Convert.ToInt32(Globals.MinFormLocation.Rows[i].Cells[1].Value) == Convert.ToInt32(this.Location.Y))
                    {
                        Globals.MinFormLocation.Rows.RemoveAt(i);
                        break;
                    }
                }
                FormMode = "Max";
                lblTitleBar.Enabled = true;
                lblTitleBar.TextAlign = ContentAlignment.MiddleCenter;
                lblMax.Visible = false;
                this.Size = Store_Size;
                this.Location = Store_Location;
            }
        }

        private void frmDemo2_Load(object sender , EventArgs e)
        {
            int ht = btnShow.Top - (usName.Top + usName.Height);
            usName.txt.Tag = "SearchList,AutoHeight:false,Height:" + ht + ",";

            uEmpCode.txt.Tag = "Number";
            uEmpCode.Enabled = false;

            FormMode = "Max";
            frmMain frm = new frmMain();
            lblBorderBottom.Height = 2;
            lblBorderLeft.Width = 2;
            lblBorderRight.Width = 2;
            
            this.Size = new Size(430 , 300);
            this.Location = new Point((x - this.Width) / 2 , (y - this.Height - frm.MainMenuStrip.Height) / 2);

            pnlAdvance.Left = (this.Width - pnlAdvance.Width) / 2;
            pnlAdvance.Top = lblTitleBar.Height + ((this.Height-lblTitleBar.Height) - pnlAdvance.Height) / 2;

            pnlProduction.Left = pnlAdvance.Left;
            pnlProduction.Top = pnlAdvance.Top;

            lblClose.Top = (lblTitleBar.Height - lblClose.Height) / 2;
            lblClose.Left = this.Width - lblClose.Width - 4;
            lblMin.Top = lblClose.Top;
            lblMin.Left = lblClose.Left - lblMin.Width - 2;

            usGroup.txt.Text = "All";
            usName.txt.Text = "All";
            uEmpCode.txt.Text = "0";
            usAdvance.txt.Text = "Summary";
            usZeroBal.txt.Text = "No";
        }

        private void frmDemo2_KeyPress(object sender , KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Hide();
            }
        }

        private void btnSave_Click(object sender , EventArgs e)
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            lblWait.Visible = true;
            if (usAdvance.txt.Text == "Summary" || usAdvance.txt.Text == "")
            {
                string group = " and (e.GNo=" + val(usGroup.txtCode.Text) + ") ";
                if ((usGroup.txt.Text).Trim().ToUpper() == "ALL" || usGroup.txt.Text.Trim() == "") group = "";
                string empcode = " and (e.SNo=" + val(uEmpCode.txt.Text) + ") ";
                if ((usName.txt.Text).Trim().ToUpper() == "ALL" || usName.txt.Text.Trim() == "") empcode = "";

                using (IDbConnection db = new SqlConnection(Globals.iniConnectionString))
                {
   //                 if (db.State == ConnectionState.Closed) db.Open();

                    /*    string qry = " select e.SNo as EmpCode,(e.Title+e.EmpName) as EmpName,g.GName as GroupName,"+
                                    " isnull((select sum(tt.amount) from trans1 tt ,m_Employee ee where (tt.empcode=ee.SNo) and (tt.empcode=e.SNo) and (tt.vtype='AdvPaid')),0) as AdvPaid_Amount,"+
                                    " isnull((select sum(tt.amount) from trans1 tt ,m_Employee ee where (tt.empcode=ee.SNo) and (tt.empcode=e.SNo) and (tt.vtype='AdvRecd')),0) as AdvRecd_Amount" +
                                     " from (((m_employee e left join trans1 t on e.SNo=t.EmpCode) left join m_maingroup g on e.GNo=G.SNo) left join PayHead p on p.SNo=t.VTypeNo)" +
                                     " where (e.FAFStatus=0) " + group + empcode +
                                     " group by e.GNo,g.GName,e.SNo,e.EmpName,e.Title order by e.GNo,e.SNo,e.EmpName"; */
                    string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, io.VDate), 0))";
                    string VDate1 = "(DATEADD(DAY, DATEDIFF(day, 0, p.RDate), 0))";
                    string VDate2 = "(DATEADD(DAY, DATEDIFF(day, 0, pr.Date), 0))";
                    string VDate3 = "(DATEADD(DAY, DATEDIFF(day, 0, c.Date), 0))";
                    string qry = "select r.SNo,r.Item_Name,sum(io.opstock) as Opening_Stock from m_raw r left join m_item_opening io on r.sno=io.INo where io.Item_Type='Raw Material'(" + VDate + " >='" + uFrom5.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + "<='" + uTo5.date.Value.ToString("yyyy-MM-dd") + "') group by r.sno,r.Item_Name order by r.Item_Name";
                    string qry1 = "select sum(p.qty) from m_raw r left join v_purchase p on r.sno=p.RNo where (" + VDate1 + " >='" + uFrom5.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + "<='" + uTo5.date.Value.ToString("yyyy-MM-dd") + "') group by r.sno,r.Item_Name order by r.Item_Name";
                    string qry2 = "select sum(pr.Qty) from m_raw r left join Purchase_Return pr on r.sno=pr.RNo where(" + VDate2 + " >='" + uFrom5.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate2 + "<='" + uTo5.date.Value.ToString("yyyy-MM-dd") + "') group by r.sno,r.Item_Name order by r.Item_Name";
                    string qry3 = "select isnull(sum(c.qty),0) from m_raw r left join consumption c on r.sno=c.RNo where(" + VDate3 + " >='" + uFrom5.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + "<='" + uTo5.date.Value.ToString("yyyy-MM-dd") + "') group by r.sno,r.Item_Name order by r.Item_Name";
                    List<clsRawReport> list = db.Query<clsRawReport>(qry , commandType: CommandType.Text).ToList();
                    //List<clsAdvance> list1 = db.Query<clsAdvance>(qry1, commandType: CommandType.Text).ToList();
                    //List<clsAdvance> list2 = db.Query<clsAdvance>(qry2, commandType: CommandType.Text).ToList();
                    //List<clsAdvance> list3 = db.Query<clsAdvance>(qry3, commandType: CommandType.Text).ToList();
                    //List<clsAdvance> list4 = db.Query<clsAdvance>(qry, commandType: CommandType.Text).ToList();
                    ReportDocument report = new ReportDocument();
                    //list4 = list.Concat(list1).Concat(list2).Concat(list3).ToList();
                    report.Load(Globals.SoftPath + "\\Report\\rptAdvance.rpt");                    
                    report.SetDataSource(list);
                    report.SetParameterValue("pFirmName" , Globals.setting["FirmName"]);
                    report.SetParameterValue("pZeroBal" , usZeroBal.txt.Text=="Yes" ? true : false);

                    frmCrystalReportViewer frm = new frmCrystalReportViewer();
                    frm.CRV.ReportSource = report;
                    frm.CRV.Refresh();
                    frm.Text = lblTitleBar.Text;
                    frm.Show(new frmMain());
                }
            }
/*            else
            {
                string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, t.VDate), 0))";
                string group = " and (t.GNo=" + val(usGroup.txtCode.Text) + ") ";
                if ((usGroup.txt.Text).Trim().ToUpper() == "ALL" || usGroup.txt.Text.Trim() == "") group = "";
                string empcode = " and (t.EmpCode=" + val(uEmpCode.txt.Text) + ") ";
                if ((usName.txt.Text).Trim().ToUpper() == "ALL" || usName.txt.Text.Trim() == "") empcode = "";

                using (IDbConnection db = new SqlConnection(Globals.iniConnectionString))
                {
                    if (db.State == ConnectionState.Closed) db.Open();

                    string qry = " select t.EmpCode,(e.Title+e.EmpName) as EmpName,g.GName as GroupName,Convert(varchar,t.VDate,103) as VDate, t.VType,t.Amount,t.Remark" +
                                 " from trans1 t,m_employee e, m_maingroup g,PayHead p " +
                                 " where (e.FAFStatus=0) and (t.VTypeNo = p.SNo) and (t.vtype = 'AdvPaid' or t.vtype = 'AdvRecd') and (t.empcode = e.SNo) and (t.GNo = e.GNo) and (e.GNo = g.SNo) and (t.GNo = G.SNo) " + group + empcode +
                                 " order by t.GNo,t.EmpCode,e.SNo,e.EmpName";

                    List<clsAdvanceDetail> list = db.Query<clsAdvanceDetail>(qry , commandType: CommandType.Text).ToList();

                    ReportDocument report = new ReportDocument();
                    report.Load(Globals.SoftPath + "\\Report\\rptAdvanceDetail.rpt");

                    report.SetDataSource(list);
                    report.SetParameterValue("pFirmName" , Globals.setting["FirmName"]);
                    report.SetParameterValue("pZeroBal" , usZeroBal.txt.Text == "Yes" ? true : false);

                    frmCrystalReportViewer frm = new frmCrystalReportViewer();
                    frm.CRV.ReportSource = report;
                    frm.CRV.Refresh();
                    frm.Show(new frmMain());
                }
            }*/
            this.Enabled = true;
            this.Cursor = Cursors.Default;
            lblWait.Visible = false;
        }

        private void usGroup_Load(object sender , EventArgs e)
        {
            ////Globals.LoadList(this , usGroup.lstName , "select SNo,GName from m_maingroup order by SNo","");
        }

        private void usName_Load(object sender , EventArgs e)
        {
           // Globals.LoadList(this , usName.lstName , "Select SNo,('('+Convert(varchar,SNo)+') '+EmpName) as EName from m_Employee where (FAFStatus=0) and GNo=" + val(usGroup.txtCode.Text) + " order by SNo","");
        }
        private double val(object value)
        {
            double Num = 0;
            if (Double.TryParse(value.ToString() , out Num))
            {
                return Num;
            }
            else
            {
                return 0;
            }
        }

        private void usAdvance_Load(object sender , EventArgs e)
        {
            string[] data = { "Summary" , "Detail" };
            Globals.LoadList2(this , usAdvance.lstName , data);
        }

        private void usZeroBal_Load(object sender , EventArgs e)
        {
            string[] data = { "Yes" , "No" };
            Globals.LoadList2(this , usZeroBal.lstName , data);
        }

        private void usGroup_Leave(object sender , EventArgs e)
        {
            usName_Load(sender , e);
        }

        private void usName_Leave(object sender , EventArgs e)
        {
            try
            {
                uEmpCode.txt.Text = usName.txtCode.Text;
                sql = "Select Item_Name from m_raw where SNo=" + val(uEmpCode.txt.Text) + ""; //" and GNo=" + val(usGroup.txtCode.Text) +
                cmd = new SqlCommand(sql , Globals.con);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    usName.txt.Text = rd["Item_Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                Globals.msgbox(this , ex.Message);
            }
            cmd.Dispose();
            rd.Close();
        }

        private void btnCancel_Click(object sender , EventArgs e)
        {
            this.Dispose();
        }

       

        
        private void btnCancel5_Click(object sender , EventArgs e)
        {
            this.Dispose();
        }

        private void btnShow5_Click(object sender , EventArgs e)
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            lblWait5.Visible = true;

                using (IDbConnection db = new SqlConnection(Globals.iniConnectionString))
                {
                    if (db.State == ConnectionState.Closed) db.Open(); //(SELECT  DATENAME(month,GETDATE()) 'Month Name') as Date
                                                                       //        string qry = "select convert(varchar,m.date,103) as Date,f.thickness as Thickness,m.qty as Qty,isnull((select sum(r_qty) from Consumption c where c.RNo=1 and m.date=c.date and c.FNo=m.FNo),0) as BasePaper,isnull((select sum(r_qty) from Consumption c where c.RNo=2 and m.date=c.date and c.FNo=m.FNo),0) as BOPP,isnull((select sum(r_qty) from Consumption c where c.RNo=3 and m.date=c.date and c.FNo=m.FNo),0) as ColourInk,isnull((select sum(r_qty) from Consumption c where c.RNo=4 and m.date=c.date and c.FNo=m.FNo),0) as Formaldehyde,isnull((select sum(r_qty) from Consumption c where c.RNo=5 and m.date=c.date and c.FNo=m.FNo),0) as KraftPaper,isnull((select sum(r_qty) from Consumption c where c.RNo=6 and m.date=c.date and c.FNo=m.FNo),0) as Melamine,isnull((select sum(r_qty) from Consumption c where c.RNo=7 and m.date=c.date and c.FNo=m.FNo),0) as Methanol,isnull((select sum(r_qty) from Consumption c where c.RNo=8 and m.date=c.date and c.FNo=m.FNo),0) as Phenol from v_manufacturing m left join finished f on f.sno=m.fno";
                string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, m.date), 0))";
                string qry = "select f.thickness as Thickness,sum(m.qty) as Qty,isnull((select sum(r_qty) from Consumption c where c.RNo=1 and c.FNo=m.FNo),0) as BasePaper,isnull((select sum(r_qty) from Consumption c where c.RNo=2  and c.FNo=m.FNo),0) as BOPP,isnull((select sum(r_qty) from Consumption c where c.RNo=3 and c.FNo=m.FNo),0) as ColourInk,isnull((select sum(r_qty) from Consumption c where c.RNo=4 and c.FNo=m.FNo),0) as Formaldehyde,isnull((select sum(r_qty) from Consumption c where c.RNo=5 and c.FNo=m.FNo),0) as KraftPaper,isnull((select sum(r_qty) from Consumption c where c.RNo=6 and c.FNo=m.FNo),0) as Melamine,isnull((select sum(r_qty) from Consumption c where c.RNo=7 and c.FNo=m.FNo),0) as Methanol,isnull((select sum(r_qty) from Consumption c where c.RNo=8 and c.FNo=m.FNo),0) as Phenol from v_manufacturing m left join finished f on f.sno=m.fno where (" + VDate + " >= '" + uFrom5.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " <= '" + uTo5.date.Value.ToString("yyyy-MM-dd") + "') group by  f.Thickness,m.FNo";
                List<clsProductionReport> list = db.Query<clsProductionReport>(qry, commandType: CommandType.Text).ToList();
                    ReportDocument report = new ReportDocument();
                    //list4 = list.Concat(list1).Concat(list2).Concat(list3).ToList();
                    report.Load(Globals.SoftPath + "\\Report\\rptThickness.rpt");
                    report.SetDataSource(list);
                    report.SetParameterValue("PFrom", "Period From "+ uFrom5.date.Value.ToString("dd/MM/yyyy") + " To "+ uTo5.date.Value.ToString("dd/MM/yyyy"));
                    frmCrystalReportViewer frm = new frmCrystalReportViewer();
                    frm.CRV.ReportSource = report;
                    frm.CRV.Refresh();
                    frm.Text = lblTitleBar.Text;
                    frm.Show(new frmMain());
                }
     
            this.Enabled = true;
            this.Cursor = Cursors.Default;
            lblWait.Visible = false;
        }
    }
}
