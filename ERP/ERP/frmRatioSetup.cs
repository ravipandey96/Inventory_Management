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
    public partial class frmRatioSetup : Form
    {
        bool drag = false;
        Point Start_Point = new Point(0, 0);
        Point Store_Location = new Point(0, 0);
        Size Store_Size = new Size(0, 0);
        int left;
        int top;
        int x = Globals.ScreenWith;
        int y = Globals.ScreenHeight;
        string FormMode;
        //-----SQL Database object
        string sql = null;
        string sql1 = null;
        SqlCommand cmd,cmd1,cmd2,cmd3;
        SqlDataReader rd,rd1;
        SqlDataAdapter ad = new SqlDataAdapter();
        string status = "add";
        string status1 = "add";
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
        public frmRatioSetup()
        {
            InitializeComponent();
            ds = new DataSet();
            dv = new DataView();
        }

        private void lblTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            Start_Point = new Point(e.X, e.Y);
        }
        private void lblTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        private void lblTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point P = PointToScreen(e.Location);
                this.Location = new Point(P.X - Start_Point.X, P.Y - Start_Point.Y);
            }
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void lblMin_Click(object sender, EventArgs e)
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
                this.Location = new Point(left, top);
                Globals.MinFormLocation.Rows.Add(left, top);
            }
            else
            {
                bool exist = false;
                for (int j = 0; j < 7; j++)
                {
                    for (i = 0; i < Globals.MinFormLocation.Rows.Count - 1; i++)
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
                Globals.MinFormLocation.Rows.Add(left, top);
                this.Location = new Point(left, top);

            }
            lblTitleBar.Enabled = false;
            lblMax.Visible = true;
            lblMax.Top = (lblTitleBar.Height - lblMax.Height) / 2;
            lblMax.Left = this.Width - lblMax.Width - 2;
        }
        public void lblMax_Click(object sender, EventArgs e)
        {

            if (FormMode == "Min")
            {
                for (int i = 0; i < Globals.MinFormLocation.Rows.Count - 1; i++)
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

        private void frmUnit_Load(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();

            FormMode = "Max";
            //Form Position   
            gFormat1();
            lblBorderBottom.Height = 2;
            lblBorderLeft.Width = 2;
            lblBorderRight.Width = 2;
            this.Location = new Point((x - this.Width) / 2, (y - this.Height - frm.MainMenuStrip.Height) / 2);
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

            ClearMe();
            Rdate.date.Value = DateTime.Parse(DateTime.Now.ToString("yyyy") +"/"+ DateTime.Now.ToString("MM") + "/01");
            int DaysInMonth = DateTime.DaysInMonth(int.Parse(Rdate.date.Value.ToString("yyyy")), int.Parse(Rdate.date.Value.ToString("MM")));
            Tdate.date.Value = Rdate.date.Value.AddDays(DaysInMonth-1);
        }

        private void frmUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {        
            if(grdRatio.Rows.Count<=0)
            {
                Globals.msgbox(this, "Please Enter Raw Material with Ratio.");
                usRaw.Focus();
                return;
            }

            using (SqlConnection con = new SqlConnection(Globals.iniConnectionString))
            {
                con.Open();
                SqlTransaction transaction;
                transaction = con.BeginTransaction();
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.Transaction = transaction;
                try
                {
                    btnSave.Enabled = false;
                    if (status == "add")
                    {
                        string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, Date), 0))";
                        for (int i = 0; i < grdRatio.Rows.Count; ++i)
                        {
                            var RATIO = double.Parse(grdRatio.Rows[i].Cells[7].Value.ToString());
                            sql = "insert into Required_Ratio(Fno,SNum,Rno,Qty,RDate,TDate) values (" + int.Parse(usItem.txtCode.Text) + "," + (i + 1) + "," + int.Parse(grdRatio.Rows[i].Cells[3].Value.ToString()) + "," + RATIO + "," + "'" + Rdate.date.Value.ToString("yyyy-MM-dd") + "'," + "'" + Tdate.date.Value.ToString("yyyy-MM-dd") + "' ) ";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();

                            sql = "update consumption set Ratio=" + RATIO + ",R_Qty=Qty*" + RATIO + " where fno=" + int.Parse(usItem.txtCode.Text) + " and Rno=" + int.Parse(grdRatio.Rows[i].Cells[3].Value.ToString().Trim()) + " and "+ VDate + ">='" + Rdate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + "<='" + Tdate.date.Value.ToString("yyyy-MM-dd") + "'";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }                            
                        transaction.Commit();
                        Globals.msgbox(this, lblTitleBar.Text + " Saved.");
                        ClearMe();                           
                   }
                   else   //update
                   {
                        string RDate = "(DATEADD(DAY, DATEDIFF(day, 0, RDate), 0))";
                        string TDate = "(DATEADD(DAY, DATEDIFF(day, 0, TDate), 0))";

                        sql = "delete from Required_Ratio where Fno=" + int.Parse(usItem.txtCode.Text) + " and "+ RDate + ">='" + Rdate.date.Value.ToString("yyyy-MM-dd")  + "' and " + TDate + "<='" + Tdate.date.Value.ToString("yyyy-MM-dd") + "'";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        for (int i = 0; i < grdRatio.Rows.Count; ++i)
                        {
                            var RATIO = double.Parse(grdRatio.Rows[i].Cells[7].Value.ToString());
                            sql = "insert into Required_Ratio(Fno,SNum,Rno,Qty,RDate,TDate) values (" + int.Parse(usItem.txtCode.Text) + "," + (i + 1) + "," + int.Parse(grdRatio.Rows[i].Cells[3].Value.ToString()) + "," + RATIO + "," + "'" + Rdate.date.Value.ToString("yyyy-MM-dd") + "'," + "'" + Tdate.date.Value.ToString("yyyy-MM-dd") + "' ) ";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();

                            sql = "update consumption set Ratio=" + RATIO + ",R_Qty=Qty*" + RATIO + " where fno=" + int.Parse(usItem.txtCode.Text) + " and Rno=" + int.Parse(grdRatio.Rows[i].Cells[3].Value.ToString().Trim()) + " and Date>='" + Rdate.date.Value.ToString("yyyy-MM-dd") + "' and Date<='" + Tdate.date.Value.ToString("yyyy-MM-dd") + "'  ";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        Globals.msgbox(this, lblTitleBar.Text + " Updated.");
                        ClearMe();
                        btnList_Click(sender, e);
                    }                    
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    Globals.msgbox(this, ex.Message);
                }                    
                btnSave.Enabled = true;
            }

        }
        private void ClearMe()
        {
            Globals.ClearAllFields(this);
            status = "add";            
            grdRatio.Rows.Clear();
            Rdate.Enabled = true;
            Tdate.Enabled = true;
            usItem.Enabled = true;
            usItem.Focus();
        }
        private void btnList_Click(object sender, EventArgs e)
        {            
            pList.Visible = true;
            uFrom.date.Value = Rdate.date.Value;
            uTo.date.Value = Tdate.date.Value;
            usItem1.txt.Text = usItem.txt.Text;
            usItem1.txtCode.Text = usItem.txtCode.Text;

            btnShow_Click(sender, e);            
        }
        private double val(object value)
        {
            double Num = 0;
            if (Double.TryParse(value.ToString(), out Num))
            {
                return Num;
            }
            else
            {
                return 0;
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, rr.RDate), 0))";
            string VDate1 = "(DATEADD(DAY, DATEDIFF(day, 0, rr.TDate), 0))";
            string SNum = "Row_Number() over(order by rr.SNum) as [S.No.]";
            sql = "select " + SNum + ",rr.RNo,r.Item_Name as [Raw Material],rr.Qty as Ratio from ((Required_Ratio rr join finished f on rr.FNo=f.SNo) join m_raw r on rr.RNo=r.SNo) where (" + VDate + " ='" + uFrom.date.Value.ToString("yyyy-MM-dd") + "' and "+ VDate1 +"='" + uTo.date.Value.ToString("yyyy-MM-dd") + "') and rr.FNo=" + val(usItem1.txtCode.Text) + " order by rr.SNum";
            cmd = new SqlCommand(sql, Globals.con);
            ad = new SqlDataAdapter(cmd);
            ds.Clear();
            ad.Fill(ds);
            dv.Table = ds.Tables[0];
            gList.DataSource = null;
            gList.DataSource = dv;
            gFormat();
            gList.Refresh();
            cmd.Dispose();
            ad.Dispose();
 
            if (gList.Rows.Count > 0)
            {
                CurrentRow = 0;
                gList.Rows[CurrentRow].Selected = true;
            }
            gList.Focus();
        }
        private void gFormat()
        {
            gList.Columns[0].Width = 40;
            gList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[1].Visible = false;
            gList.Columns[3].Width = 100;
            gList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void gFormat1()
        {
            grdRatio.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void gList_DoubleClick(object sender, EventArgs e)
        {
            if (gList.Rows.Count > 0 && CurrentRow >= 0)
            {
                pList.Visible = false;
                status = "edit";
                Rdate.date.Value = uFrom.date.Value;
                Tdate.date.Value = uTo.date.Value;
                usItem.txt.Text = usItem1.txt.Text;
                usItem.txtCode.Text = usItem1.txtCode.Text;
                PrevRec();
                Rdate.Enabled = false;
                Tdate.Enabled = false;
                usItem.Enabled = false;
                grdRatio.Focus();
            }
        } 
        private void PrevRec()
        {
            string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, rr.RDate), 0))";
            string VDate1 = "(DATEADD(DAY, DATEDIFF(day, 0, rr.TDate), 0))";
            sql = "select rr.SNum,rr.RNo,r.Item_Name,rr.Qty,rr.FNo from ((Required_Ratio rr join finished f on rr.Fno=f.SNo) join m_raw r on rr.RNo=r.SNo) where (" + VDate + " ='" + Rdate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + "='" + Tdate.date.Value.ToString("yyyy-MM-dd") + "') and rr.FNo=" + val(usItem.txtCode.Text) + " order by rr.SNum";
            cmd = new SqlCommand(sql, Globals.con);
            rd = cmd.ExecuteReader();
            grdRatio.Rows.Clear();
            while (rd.Read())
            {
                grdRatio.Rows.Add(rd["SNum"].ToString(),0,0, rd["RNo"].ToString(), rd["Item_Name"].ToString(),"","", val(rd["Qty"].ToString()));
            }
            rd.Close();
            cmd.Dispose();           
        }
        
        private void uSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // ---list search up down
            if (e.KeyCode == Keys.Enter)
            {
              //  uSearch.SearchEnterKey = true;
                gList_DoubleClick(sender, e);
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

        private void gList_Click(object sender, EventArgs e)
        {

        }

        private void utxtCUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void gList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gList_DoubleClick(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gList.Rows.Count > 0 && (CurrentRow >= 0 && CurrentRow < gList.Rows.Count))
            {
                if (Globals.msgbox(this, "Are You Sure To Delete Finished Goods Ratio?", "YesNo") == 1)
                {
                    sql = "delete from Required_Ratio where (RDate='" + uFrom.date.Value.ToString("yyyy-MM-dd") + "' and TDate='" + uTo.date.Value.ToString("yyyy-MM-dd") + "') and FNo=" + int.Parse(usItem1.txtCode.Text);
                    SqlCommand cmd1 = new SqlCommand(sql, Globals.con);
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();
                    btnShow_Click(sender, e);
                }
            }
        }

        private void gList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && pList.Visible == false)
            {
                this.Dispose();
            }
            else if (e.KeyCode == Keys.Escape && pList.Visible == true)
            {
                pList.Visible = false;
                usItem.txt.Tag = "Text,Require";
                Rdate.Enabled = true;
                Rdate.Focus();
            }
            else if (e.Control && e.KeyCode == Keys.S && pList.Visible == false)
            {
                btnSave_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.L && pList.Visible == false)
            {
                btnList_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.D && pList.Visible == true)
            {
                btnDelete_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.W && pList.Visible == true)
            {
                btnShow_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                pList.Visible = false;
                ClearMe();                                
            }
            else if(e.KeyCode==Keys.F2 && pList.Visible==false)
            {
                btnSave.Focus();
                usRaw.txt.Text = "";
                usRaw.txtCode.Text = "";
                uctxtQty.txt.Text = "";
            }
            else if (e.Control && e.KeyCode == Keys.M)
            {
                lblMin_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                lblMax_Click(sender, e);
            }
        }

        private void usType_Load(object sender, EventArgs e)
        {
            Globals.LoadList(this, usItem.lstName, "Select SNo,Thickness from finished order by Thickness");     
            if(usItem.lstName.Items.Count>0)
            {             
                ucSearchList.MList lst = usItem.lstName.SelectedItem as ucSearchList.MList;
                if (lst != null)
                {
                    usItem.txt.Text = lst.Name;
                    usItem.txtCode.Text = lst.Code.ToString();
                }
                else
                {
                    usItem.txt.Text = "";
                    usItem.txtCode.Text = "0";
                }
            }
        }

        private void usItem_Leave(object sender, EventArgs e)
        {           
            
        }

        private void uctxtQty_Load(object sender, EventArgs e)
        {

        }
        private void AutoNumber()
        {
            for (int i = 0; i < grdRatio.Rows.Count; i++)
            {
                grdRatio.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (val(uctxtQty.txt.Text)==0)
            {
                Globals.msgbox(this,"Please Enter Ratio.");
                uctxtQty.Focus();
                return;
            }

            if (status1 == "add")
            {
                //grdRatio.Rows.Add(grdRatio.Rows.Count + 1, uctxtfno.txt.Text, usItem.txt.Text, uctxtRNo.txt.Text, usRaw.txt.Text, Rdate.date.Value.ToString("dd-MM-yyyy"), Tdate.date.Value.ToString("dd-MM-yyyy"), val(uctxtQty.txt.Text));
                grdRatio.Rows.Add(grdRatio.Rows.Count + 1, 0, 0, val(usRaw.txtCode.Text), usRaw.txt.Text, "", "", val(uctxtQty.txt.Text));
                AutoNumber();                    
            }
            else
            {
                //grdRatio.Rows[grdRatio.CurrentCell.RowIndex].Cells[0].Value = grdRatio.Rows.Count + 1;
                //grdRatio.Rows[grdRatio.CurrentCell.RowIndex].Cells[1].Value = val(uctxtfno.txt.Text);
                //grdRatio.Rows[grdRatio.CurrentCell.RowIndex].Cells[2].Value = usItem.txt.Text;
                grdRatio.Rows[grdRatio.CurrentCell.RowIndex].Cells[3].Value = val(usRaw.txtCode.Text);
                grdRatio.Rows[grdRatio.CurrentCell.RowIndex].Cells[4].Value = usRaw.txt.Text;
                //grdRatio.Rows[grdRatio.CurrentCell.RowIndex].Cells[5].Value = Rdate.date.Value.ToString("yyyy-MM-dd");
                //grdRatio.Rows[grdRatio.CurrentCell.RowIndex].Cells[6].Value = Tdate.date.Value.ToString("yyyy-MM-dd");
                grdRatio.Rows[grdRatio.CurrentCell.RowIndex].Cells[7].Value = val(uctxtQty.txt.Text);
            }
            status1 = "add";
            usRaw.txt.Text = "";
            usRaw.txtCode.Text = "0";
            uctxtQty.txt.Text = "";
            usRaw.Focus();                
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {               
                grdRatio.Rows.RemoveAt(grdRatio.CurrentRow.Index);
                AutoNumber();                
            }
            catch (Exception ex) {}            
        }

        private void uTo_Load(object sender, EventArgs e)
        {

        }

        private void grdReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uctxtRate_Leave(object sender, EventArgs e)
        {
//            if(uctxtRate.txt.Text == "")
//            {
//                uctxtRate.txt.Text = "0";
//            }
        }

        private void uctxtQty_Leave(object sender, EventArgs e)
        {
        }

        private void uctxtBIS_Leave(object sender, EventArgs e)
        {
//            if(uctxtBIS.txt.Text=="0")
//            {
//                uctxtBIS.txt.Text = "0";
//            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void usRaw_Load(object sender, EventArgs e)
        {            
            Globals.LoadList(this, usRaw.lstName, "Select SNo,Item_Name from m_raw order by Item_Name");
        }

        private void usRaw_Leave(object sender, EventArgs e)
        {
            //cmd = new SqlCommand("Select SNo,Item_Name from m_raw m  where Item_Name='" + usRaw.txt.Text + "'order by m.Item_Name", Globals.con);
            //rd = cmd.ExecuteReader();
            //while (rd.Read())
            //{
            //    uctxtRNo.txt.Text = rd["SNo"].ToString();                
            //}
            //cmd.Dispose();
            //rd.Close();
        }

        private void gList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gList.Rows.Count > 0)
            {
                CurrentRow = gList.CurrentRow.Index;
            }
        }

        private void gList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (gList.Rows.Count > 0 && CurrentRow >= 0)
            //{
            //    pList.Visible = false;
            //    status = "edit";
            //    Rdate.date.Value = uFrom.date.Value;
            //    Tdate.date.Value = uTo.date.Value;
            //    usItem.txt.Text = usItem1.txt.Text;
            //    usItem.txtCode.Text = usItem1.txtCode.Text;
            //    PrevRec();
            //    Rdate.Enabled = false;
            //    Tdate.Enabled = false;
            //    usItem.Enabled = false;
            //    grdRatio.Focus();
            //}
        }

        private void usItem1_Load(object sender, EventArgs e)
        {
            Globals.LoadList(this, usItem1.lstName, "Select SNo,Thickness from finished order by Thickness");
        }

        private void usItem1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (usItem1.lstName.Items.Count > 0)
                {
                    ucSearchList.MList lst = usItem1.lstName.SelectedItem as ucSearchList.MList;
                    if (lst != null)
                    {
                        usItem1.txt.Text = lst.Name;
                        usItem1.txtCode.Text = lst.Code.ToString();
                    }
                    else
                    {
                        usItem1.txt.Text = "";
                        usItem1.txtCode.Text = "0";
                    }
                }
                btnShow_Click(sender, e);
            }
        }

        private void usItem1_Leave(object sender, EventArgs e)
        {
            
        }

        private void grdRatio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = grdRatio.CurrentCell.RowIndex;
            usRaw.txtCode.Text = grdRatio.Rows[row].Cells[3].Value.ToString();
            usRaw.txt.Text = grdRatio.Rows[row].Cells[4].Value.ToString();
            uctxtQty.txt.Text = grdRatio.Rows[row].Cells[7].Value.ToString();
            status1 = "edit";
            usRaw.Focus();
        }


        private void pList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uctxt1_Load(object sender, EventArgs e)
        {

        }

        private void uctxtTBIS_Load(object sender, EventArgs e)
        {

        }
        // Ensure the form opens with no rows selected.               
        //usType.lstName.ClearSelected();
    }
    }

//}

 