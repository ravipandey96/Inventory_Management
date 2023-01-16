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

namespace ERP
{
    public partial class frmAttendance : Form
    {
        bool drag = false;
        Point Start_Point = new Point(0 , 0);
        Point Store_Location = new Point(0 , 0);
        Size Store_Size = new Size(0 , 0);
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
        string status = "add";
        //-----END
        DataSet ds
        {
            get;
            set;
        }
        DataView dv
        {
            get;
            set;
        }
        int CurrentRow = 0;
        public frmAttendance()
        {
            InitializeComponent();
            ds = new DataSet();
            dv = new DataView();
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

            if (Globals.MinFormLocation.Rows.Count - 1 == 0)
            {
                this.Location = new Point(left , top);
                Globals.MinFormLocation.Rows.Add(left , top);
            }
            else
            {
                bool exist = false;
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
                    if (exist == false)
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
                for (int i = 0 ; i < Globals.MinFormLocation.Rows.Count - 1 ; i++)
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
        private void frmUnit_Load(object sender , EventArgs e)
        {
            frmMain frm = new frmMain();
            usName.txt.Tag = "SearchList";
            uEmpCode.txt.Tag = "Number";
            uBioID.txt.Tag = "Number";
            uFrom.txt.Tag = "Text";
            uTo.txt.Tag = "Text";
            uRemark.txt.Tag = "Text";

            status = "add";
            FormMode = "Max";
            //Form Position     
            lblBorderBottom.Height = 2;
            lblBorderLeft.Width = 2;
            lblBorderRight.Width = 2;
            this.Location = new Point((x - this.Width) / 2 , (y - this.Height - frm.MainMenuStrip.Height) / 2);
            pbase.Left = (this.Width - pbase.Width) / 2;
            lblClose.Top = (lblTitleBar.Height - lblClose.Height) / 2;
            lblClose.Left = this.Width - lblClose.Width - 4;
            lblMin.Top = lblClose.Top;
            lblMin.Left = lblClose.Left - lblMin.Width - 2;
            // Panel Position
            pList.Width = this.Width - lblBorderLeft.Width * 2;
            pList.Height = this.Height - lblTitleBar.Height - lblBorderBottom.Height;
            pList.Top = lblTitleBar.Top + lblTitleBar.Height;
            pList.Left = lblBorderLeft.Width;
            pList.Visible = false;
            // Datagrid view Position
            gList.Width = pList.Width;
            gList.Height = pList.Height - btnShow.Top - btnShow.Height - 8;
            gList.Top = btnShow.Top + btnShow.Height + 8;
            gList.Left = 0;
            gList.Columns.Clear();
            // Clear All Text Box
            ClearMe();
        }

        private void frmUnit_KeyPress(object sender , KeyPressEventArgs e)
        {
        }

        private void btnSave_Click(object sender , EventArgs e)
        {
            try
            {
                if (usName.txt.Text.Trim() == "")
                {
                    Globals.msgbox(this , "Employee Name Can't be Empty.");
                    usName.Focus();
                    return;
                }

                btnSave.Enabled = false;
                if (status == "add")
                {
                    Globals.DeleteRecord("Attendance" , "empCode=" + val(uEmpCode.txt.Text) + " and VDate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "'");
                    uctxtSNo.txt.Text = Globals.MaxCode("Attendance" , "SNo").ToString();

                    if (uFrom.txt.Text.Trim().Length > 0)
                    {
                        sql = "insert into Attendance(SNo,VDate,EmpCode,BioID,StartTime,EndTime,Remark) values(" +
                        val(uctxtSNo.txt.Text)
                        + ",'" + uDate.date.Value.ToString("yyyy-MM-dd hh:mm:ss tt")
                        + "'," + val(uEmpCode.txt.Text)
                        + "," + val(uBioID.txt.Text)
                        + ",'" + uFrom.txt.Text
                        + "','" + uTo.txt.Text
                        + "','" + uRemark.txt.Text + "')";
                        cmd = new SqlCommand(sql , Globals.con);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        Globals.msgbox(this , "Attendance Saved.");
                        ClearMe();
                    }
                }
                else
                {
                    if (uTo.txt.Text.Trim().Length > 0)
                    {
                        sql = "update Attendance set StartTime='" + uFrom.txt.Text
                        + "',EndTime='" + uTo.txt.Text
                        + "',Remark='" + uRemark.txt.Text
                        + "' where SNo=" + val(uctxtSNo.txt.Text) + "";
                        cmd = new SqlCommand(sql , Globals.con);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        Globals.msgbox(this , "Attendance Updated.");
                    }
                    ClearMe();
                    btnList_Click(sender , e);
                }
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                Globals.msgbox(this , ex.Message);
            }
            btnSave.Enabled = true;

        }
        private void ClearMe()
        {
            Globals.ClearAllFields(this);
            status = "add";
            usName.Focus();
        }
        private void btnList_Click(object sender , EventArgs e)
        {
            pList.Visible = true;
            usName.txt.Tag = "Text";
            btnShow_Click(sender , e);
            uSearch.txt.Focus();
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

        private void btnShow_Click(object sender , EventArgs e)
        {
            string SNum = "Row_Number() over(order by e.EmpName) as [S.No.]";
            sql = "Select " + SNum + ",a.SNo as ASNo,e.SNo as Code,e.EmpName as [Employee Name],CONVERT(varchar,a.VDate, 103) as [Present Date],replace(CONVERT(varchar,a.StartTime,22),'01/01/00 ','') as [Start Time],replace(CONVERT(varchar,a.EndTime,22),'01/01/00 ','') as [End Time] from m_Employee e,Attendance a where (e.SNo=a.EmpCode) and e.EmpName like '%" + uSearch.txt.Text.Trim() + "%' order by e.EmpName,a.VDate,a.StartTime,a.EndTime";
            cmd = new SqlCommand(sql , Globals.con);
            ad = new SqlDataAdapter(cmd);
            ds.Clear();
            ad.Fill(ds);
            dv.Table = ds.Tables[0];
            gList.DataSource = dv;
            gFormat();
            cmd.Dispose();
            ad.Dispose();
            if (gList.Rows.Count > 0)
            {
                CurrentRow = 0;
                gList.Rows[CurrentRow].Selected = true;
            }
        }
        private void gFormat()
        {
            gList.Columns[1].Visible = false;
            gList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[0].Width = 60;
            //gList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gList.Columns[1].Width = 60;
            //gList.Columns[2].Width = 300;
            //gList.Columns[3].Width = 300;


        }
        private void gList_DoubleClick(object sender , EventArgs e)
        {
            if (gList.Rows.Count > 0 && CurrentRow >= 0)
            {
                pList.Visible = false;
                status = "edit";
                uctxtSNo.txt.Text = gList.Rows[CurrentRow].Cells[1].Value.ToString();
                PrevRec();
                usName.Focus();
            }
        }
        private void PrevRec()
        {
            sql = "Select e.SNo,e.BioID,e.EmpName,a.VDate,a.StartTime,a.EndTime,a.Remark from m_Employee e,Attendance a where (e.SNo=a.EmpCode) and (a.SNo=" + val(uctxtSNo.txt.Text) + ")";
            cmd = new SqlCommand(sql , Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                uEmpCode.txt.Text = rd["SNo"].ToString();
                uBioID.txt.Text = rd["BioID"].ToString();
                usName.txt.Text = rd["EmpName"].ToString();
                uDate.date.Value = DateTime.Parse(rd["VDate"].ToString());
                uFrom.txt.Text = DateTime.Parse(rd["StartTime"].ToString()).ToString("hh:mm:ss tt");
                uTo.txt.Text = DateTime.Parse(rd["EndTime"].ToString()).ToString("hh:mm:ss tt");
                uRemark.txt.Text = rd["Remark"].ToString();
            }
            cmd.Dispose();
            rd.Close();
        }
        private void uSearch_TextChanged(object sender , EventArgs e)
        {
            //btnSave_Click(sender , e);
            dv.RowFilter = "[code]=" + val(uSearch.txt.Text) + " or [Employee Name] like '%" + uSearch.txt.Text + "%'";
            gList.DataSource = dv;
            if (gList.Rows.Count > 0)
            {
                CurrentRow = 0;
                gList.Rows[CurrentRow].Selected = true;
            }
        }

        private void uSearch_KeyDown(object sender , KeyEventArgs e)
        {
            // ---list search up down

            if (e.KeyCode == Keys.Enter)
            {
                uSearch.SearchEnterKey = true;
                gList_DoubleClick(sender , e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (CurrentRow < gList.Rows.Count - 1)
                {
                    CurrentRow++;
                    gList.Rows[CurrentRow].Selected = true;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (CurrentRow > 0)
                {
                    CurrentRow--;
                    gList.Rows[CurrentRow].Selected = true;
                }
            }
        }

        private void gList_Click(object sender , EventArgs e)
        {
            if (gList.Rows.Count > 0)
            {
                CurrentRow = gList.CurrentRow.Index;
            }
        }

        private void utxtCUnit_KeyDown(object sender , KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender , e);
            }
        }

        private void gList_KeyDown(object sender , KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gList_DoubleClick(sender , e);
        }

        private void btnDelete_Click(object sender , EventArgs e)
        {
            if (gList.Rows.Count > 0 && (CurrentRow >= 0 && CurrentRow < gList.Rows.Count))
            {
                Globals.DeleteRecord("Attendance" , gList.Rows[CurrentRow].Cells[1].Value);
                btnShow_Click(sender , e);
            }
        }

        private void gList_CellContentClick(object sender , DataGridViewCellEventArgs e)
        {

        }

        private void frmUnit_KeyDown(object sender , KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && pList.Visible == false)
            {
                this.Dispose();
            }
            else if (e.KeyCode == Keys.Escape && pList.Visible == true)
            {
                pList.Visible = false;
                // utxtName.txt.Tag = "Text,Require";
                //utxtName.Focus();
            }
            else if (e.Control && e.KeyCode == Keys.S && pList.Visible == false)
            {
                btnSave_Click(sender , e);
            }
            else if (e.Control && e.KeyCode == Keys.L && pList.Visible == false)
            {
                btnList_Click(sender , e);
            }
            else if (e.Control && e.KeyCode == Keys.D && pList.Visible == true)
            {
                btnDelete_Click(sender , e);
            }
            else if (e.Control && e.KeyCode == Keys.W && pList.Visible == true)
            {
                btnShow_Click(sender , e);
            }
        }

        private void uFrom_Leave(object sender , EventArgs e)
        {
            DateTime tm;
            bool chk = DateTime.TryParse(uFrom.txt.Text , out tm);
            if (chk)
                uFrom.txt.Text = tm.ToString("hh:mm:ss tt");
            else
                uFrom.txt.Text = "";
        }

        private void usName_Leave(object sender , EventArgs e)
        {
            uEmpCode.txt.Text = usName.txtCode.Text;
        }

        private void uEmpCode_Leave(object sender , EventArgs e)
        {
            try
            {
                sql = "Select SNo,BioID,EmpName from m_Employee where SNo=" + val(uEmpCode.txt.Text) + "";
                cmd = new SqlCommand(sql , Globals.con);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    uBioID.txt.Text = rd["BioID"].ToString();
                    usName.txt.Text = rd["EmpName"].ToString();
                }
                else
                {
                    uEmpCode.txt.Text = "0";
                    uBioID.txt.Text = "0";
                    usName.txt.Text = "";
                }
            }
            catch (Exception ex)
            {
                Globals.msgbox(this , ex.Message);
            }
            cmd.Dispose();
            rd.Close();
        }

        private void usName_Load(object sender , EventArgs e)
        {
            try
            {
                sql = "Select SNo,EmpName from m_Employee order by EmpName";
                cmd = new SqlCommand(sql , Globals.con);
                rd = cmd.ExecuteReader();
                usName.lstName.Items.Clear();
                while (rd.Read())
                {
                    ucSearchList.MList lst = new ucSearchList.MList();
                    lst.Code = int.Parse(rd["SNo"].ToString());
                    lst.Name = rd["EmpName"].ToString();
                    usName.lstName.Items.Add(lst);
                }
                usName.lstName.ClearSelected();
            }
            catch (Exception ex)
            {
                Globals.msgbox(this , ex.Message);
            }
            cmd.Dispose();
            rd.Close();
        }

        private void uTo_Leave(object sender , EventArgs e)
        {
            DateTime tm;
            bool chk = DateTime.TryParse(uTo.txt.Text , out tm);
            if (chk)
                uTo.txt.Text = tm.ToString("hh:mm:ss tt");
            else
                uTo.txt.Text = "";
        }

        private void uSearch_Load(object sender , EventArgs e)
        {

        }
    }
}
