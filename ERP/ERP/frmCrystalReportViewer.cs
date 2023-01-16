using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ERP
{
    public partial class frmCrystalReportViewer : Form
    {
        //public List<clsAdvance> _list;
        //string _dateRange;
        public frmCrystalReportViewer()
        {
            InitializeComponent();
        }

        private void frmCrystalReportViewer_KeyDown(object sender , KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            else if(e.Control && e.KeyCode == Keys.P)
            {
                CRV.PrintReport();
            }        
                    
            {

            }
        }

        private void frmCrystalReportViewer_Load(object sender , EventArgs e)
        {
            //ReportDocument report = new ReportDocument();
            //report.Load(@"E:\VINOD\SOFTWARES\Projects\C#.Net\ERP\WEEKLY\ERP\Report\rptAdvance.rpt");

            //report.SetDataSource(_list);
            //report.SetParameterValue("pDateRange",DateTime.Now.ToString("dd/MM/yyyy"));
            //CRV.ReportSource = report;
            //CRV.Refresh();
        }

        private void CRV_Load(object sender, EventArgs e)
        {

        }
    }
}
