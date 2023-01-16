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
    public partial class frmSales_Return : Form
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
        public frmSales_Return()
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
            int ht = button1.Top - (usItem.Top + usItem.Height);
            usItem.txt.Tag = "SearchList,AutoHeight:false,Height:" + ht + ",";
//            usItem.txt.Tag = "SearchList,Require";
            uctxtRefNo.txt.Tag = "Text";

            status = "add";
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
        }

        private void frmUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // jump:
            if (grdReturn.Rows.Count != 0)
            {
                
                //grdReturn.Focus();
                //btnSave.Enabled = false;
                //         goto jump;
            
            using (SqlConnection con = new SqlConnection(Globals.iniConnectionString))
            {
                con.Open();
                SqlTransaction transaction;
                transaction = con.BeginTransaction();
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.Transaction = transaction;
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.Connection = con;
                cmd1.Transaction = transaction;
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.Connection = con;
                cmd2.Transaction = transaction;
                SqlCommand cmd4 = con.CreateCommand();
                cmd4.Connection = con;
                cmd4.Transaction = transaction;
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.Connection = con;
                cmd3.Transaction = transaction;
                SqlDataReader rd, rd1;
                try
                {
                    btnSave.Enabled = false;
                    if (status == "add")
                    {
                        if (uctxtBIS.txt.Text == "" || uctxtBIS.txt.Text == null)
                        {
                            uctxtBIS.txt.Text = "0";
                        }
                        if (uctxtQty.txt.Text == "" || uctxtRegular.txt.Text == null)
                        {
                            uctxtQty.txt.Text = "0";
                        }
                        if (uctxtRefNo.txt.Text.Trim() == "")
                        {
                            uctxtRefNo.txt.Text = uctxtSNo.txt.Text;
                        }
                        for (int i = 0; i < grdReturn.Rows.Count; ++i)
                        {
                            sql1 = "insert into sales_return(SNo,VNo,Ref_No,FNo,Qty,Narration,BIS,date,Total,Rate,Net_Total) values("
                                  + (i + 1)
                                  + "," + val(uctxtSNo.txt.Text)
                                  + ",'" + uctxtRefNo.txt.Text
                                  + "'," + int.Parse(grdReturn.Rows[i].Cells[3].Value.ToString().Trim())
                                  + "," + float.Parse(grdReturn.Rows[i].Cells[5].Value.ToString().Trim())
                                  + ",'" + uctxtNarration.txt.Text
                                  + "'," + float.Parse(grdReturn.Rows[i].Cells[6].Value.ToString().Trim())
                                  + ",'" + uDate.date.Value.ToString("yyyy-MM-dd")
                                  + "'," + (float.Parse(grdReturn.Rows[i].Cells[5].Value.ToString().Trim()) + float.Parse(grdReturn.Rows[i].Cells[6].Value.ToString().Trim()))                                  
                                  + "," + val(uctxtRate.txt.Text)
                                  + "," + float.Parse(grdReturn.Rows[i].Cells[9].Value.ToString().Trim()) + ")";
                                cmd = new SqlCommand(sql1, Globals.con);
                            string check = "select * from sales_return where date='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo=" + int.Parse(grdReturn.Rows[i].Cells[3].Value.ToString().Trim());
                            //                            cmd1 = new SqlCommand(check, Globals.con);
                            cmd1.CommandText = check;
                            rd = cmd1.ExecuteReader();
                            if (rd.Read())
                            {
                                if (rd["FNo"].ToString() != null && rd["Date"].ToString() != null)
                                {
                                    uprev.date.Value = DateTime.Parse(rd["Date"].ToString());
                                    uctxtFnoTest.txt.Text = rd["FNo"].ToString();

                                    if (uDate.date.Value.ToString("yyyy-MM-dd") == uprev.date.Value.ToString("yyyy-MM-dd") && val(uctxtFnoTest.txt.Text) == int.Parse(grdReturn.Rows[i].Cells[3].Value.ToString().Trim()))
                                    {
                                        cmd1.Dispose();
                                        rd.Close();
                                        string u = "update Returnstock set Regular=Regular+" + float.Parse(grdReturn.Rows[i].Cells[5].Value.ToString().Trim()) + ",BIS=BIS+" + float.Parse(grdReturn.Rows[i].Cells[6].Value.ToString().Trim()) + " where Rdate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo=" + int.Parse(grdReturn.Rows[i].Cells[3].Value.ToString().Trim()) + "";
                                        cmd1.CommandText = u;
                                        cmd1.ExecuteNonQuery();
                                        cmd1.Dispose();
                                    }
                                }
                            }
                            else
                            {
                                cmd1.Dispose();
                                rd.Close();
                                string stock = "insert into Returnstock (RDate,Fno,VNo,Regular,BIS) values ('"
                                + uDate.date.Value.ToString("yyyy-MM-dd")
                                + "'," + int.Parse(grdReturn.Rows[i].Cells[3].Value.ToString().Trim())
                                + "," + uctxtSNo.txt.Text
                                + "," + float.Parse(grdReturn.Rows[i].Cells[5].Value.ToString().Trim())
                                + "," + float.Parse(grdReturn.Rows[i].Cells[6].Value.ToString().Trim()) + ")";
                                cmd1.CommandText = stock;
                                cmd1.ExecuteNonQuery();
                                cmd1.Dispose();

                            }
                            cmd.ExecuteNonQuery();
                        }
                        cmd.Dispose();
                        transaction.Commit();
                        Globals.msgbox(this, lblTitleBar.Text + " Saved.");
                        grdReturn.Rows.Clear();
                        uctxtQty.txt.Text = "";
                        uctxtBIS.txt.Text = "";
                        //                  uctxtup.txt.Text = "";
                        //                  uctxt11.txt.Text = "";
                    }
                    else
                    {

                        //uctxtSNo.txt.Text = Globals.MaxCode("Purchase_Return", "SNo").ToString();
                        // sql = "update Purchase_Return set Date='" + uDate.date.Value.ToString("yyyy-MM-dd hh:mm:ss tt") + "', RNo='" + val(uctxtRNo.txt.Text) + "',Qty='" + val(uctxtRNo.txt.Text) + "', Narration='" + val(uctxtNarration.txt.Text) + "' where SNo=" + val(uctxtSNo.txt.Text) + "";
                        int row = grdReturn.CurrentCell.RowIndex;
                        sql = "delete from sales_return where VNo=" + val(uctxtSNo.txt.Text) + "";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        for (int k = 0; k < grdReturn.Rows.Count; ++k)
                        {
                                sql1 = "insert into sales_return(SNo,VNo,Ref_No,FNo,Qty,Narration,BIS,date,Total,Rate,Net_Total) values("
                                       + (k + 1)
                                       + "," + val(uctxtSNo.txt.Text)
                                       + ",'" + grdReturn.Rows[k].Cells[2].Value.ToString().Trim()
                                       + "'," + int.Parse(grdReturn.Rows[k].Cells[3].Value.ToString().Trim())
                                       + "," + float.Parse(grdReturn.Rows[k].Cells[5].Value.ToString().Trim())
                                       + ",'" + uctxtNarration.txt.Text
                                       + "'," + float.Parse(grdReturn.Rows[k].Cells[6].Value.ToString().Trim())
                                       + ",'" + uDate.date.Value.ToString("yyyy-MM-dd")
                                       + "'," + (float.Parse(grdReturn.Rows[k].Cells[5].Value.ToString().Trim()) + float.Parse(grdReturn.Rows[k].Cells[6].Value.ToString().Trim()))   //
                                       + "," + val(uctxtRate.txt.Text)
                                       + "," + float.Parse(grdReturn.Rows[k].Cells[9].Value.ToString().Trim()) + ")";
                                cmd.CommandText = sql1;
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        string temp = uctxtup.txt.Text;
                        string temp1 = uctxt1.txt.Text;
                        string[] SNO = temp.Split(',');
                        string[] SNO1 = temp1.Split(',');
                        int t = 0;
                        if (temp != "")
                        {
                            for (int j = 0; j < SNO.Length; j++)
                            {
                                t = int.Parse(SNO1[j].ToString()) - 1;
                                string u = "update Returnstock set Regular = Regular + " + float.Parse(grdReturn.Rows[t].Cells[5].Value.ToString().Trim()) + ",BIS = BIS +" + float.Parse(grdReturn.Rows[t].Cells[6].Value.ToString().Trim()) + " where RDate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo=" + val(SNO[j]) + "";
                                cmd1.CommandText = u;
                                cmd1.ExecuteNonQuery();
                                cmd1.Dispose();
                            }
                        }
                        if (uctxtSrNo.txt.Text != "")
                        {
                            int sr = int.Parse(uctxtSrNo.txt.Text);
                            int vno = int.Parse(uctxtSNo.txt.Text);
                            for (int i = 0; i < grdReturn.Rows.Count; ++i)
                            {
                                string check1 = "select max(SNo) as id from Srstock where Sdate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and VNo= " + (vno) + " and SrNo=" + (i + 1) + "";
                                cmd1.CommandText = check1;
                                rd = cmd1.ExecuteReader();
                                rd.Read();
                                if (rd["id"].ToString() != "")                       //
                                {
                                    int num = int.Parse(rd["id"].ToString());
                                    cmd1.Dispose();
                                    rd.Close();
                                    string fetch = "select FNo,Sdate,regular,bis from Srstock where SNo=" + num;
                                    cmd1.CommandText = fetch;
                                    rd = cmd1.ExecuteReader();
                                    if (rd.Read())
                                    {
                                        float reg = float.Parse(rd["Regular"].ToString());
                                        float bis = float.Parse(rd["BIS"].ToString());
                                        int fno = int.Parse(rd["FNo"].ToString());
                                        var dat = rd["Sdate"].ToString();
                                        cmd1.Dispose();
                                        rd.Close();
                                        string u = "update Returnstock set Regular=Regular-" + reg + ",BIS=BIS-" + bis + " where RDate='" + dat + "' and FNo=" + fno + "";
                                        cmd.CommandText = u;
                                        cmd.ExecuteNonQuery();
                                        cmd.Dispose();
                                    }
                                }
                                cmd1.Dispose();
                                rd.Close();
                            }
                        }
                        if (uctxtRcount.txt.Text != "")
                        {
                            int v = int.Parse(uctxtSNo.txt.Text);
                            int ins = int.Parse(uctxtGrdReturn.txt.Text);
                            int rc = int.Parse(uctxtRcount.txt.Text);
                            for (int i = ins; i < ins + (rc - ins); ++i)
                            {
                                //    string check = "select Fno from Sstock where Sdate='" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "' and VNo= " +(v-1);
                                //    cmd1.CommandText = check;
                                //    rd = cmd1.ExecuteReader();
                                //    rd.Read();
                                //                        if (rd["fno"].ToString() != "")
                                if (rc > ins)
                                {
                                    string temp2 = "";
                                    string check = "select fno from Returnstock where Rdate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and VNo= " + (v) + " and FNo=" + int.Parse(grdReturn.Rows[i].Cells[3].Value.ToString().Trim());
                                    cmd3.CommandText = check;
                                    rd1 = cmd3.ExecuteReader();

                                    if (rd1.Read())
                                    {
                                        while (rd1["fno"].ToString() != "")
                                            temp2 = temp2 + rd1["fno"].ToString() + ",";
                                    }

                                    if (temp2 != "")
                                    {
                                        cmd3.Dispose();
                                        rd1.Close();
                                        temp2 = temp2.Remove(temp2.Length - 1, 1);
                                        string[] SN = temp.Split(',');
                                        foreach (string sn in SN)
                                        {
                                            //int sn = int.Parse(rd1["fno"].ToString());
                                            string u = "update Returnstock set Regular=Regular+" + float.Parse(grdReturn.Rows[i].Cells[7].Value.ToString().Trim()) + ",BIS=BIS+" + float.Parse(grdReturn.Rows[i].Cells[6].Value.ToString().Trim()) + " where RDate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo=" + int.Parse(grdReturn.Rows[i].Cells[3].Value.ToString().Trim()) + "";
                                            cmd2.CommandText = u;
                                            cmd2.ExecuteNonQuery();
                                            cmd2.Dispose();
                                        }
                                    }
                                    else
                                    {
                                        cmd3.Dispose();
                                        rd1.Close();
                                        string stock = "insert into Returnstock(Rdate,Vno,FNo,Regular,BIS) values ('"
                                            + uDate.date.Value.ToString("yyyy-MM-dd")
                                            + "'," + val(uctxtSNo.txt.Text)
                                            + "," + int.Parse(grdReturn.Rows[i].Cells[3].Value.ToString().Trim())
                                            //                                            + "," + (v)
                                            + "," + float.Parse(grdReturn.Rows[i].Cells[5].Value.ToString().Trim())
                                            + "," + float.Parse(grdReturn.Rows[i].Cells[6].Value.ToString().Trim()) + ")";
                                        cmd.CommandText = stock;
                                        cmd.ExecuteNonQuery();
                                        cmd.Dispose();
                                        if ((ins + 1) == rc)
                                        {
                                            break;
                                        }
                                    }

                                }
                                //                        }

                                //          cmd1.Dispose();
                                //          rd.Close();
                            }
                        }
                        if (uctxtR1.txt.Text != "")
                        {
                            //                      int sr = int.Parse(uctxtSrNo1.txt.Text);
                            //int vno = int.Parse(uctxtVno.txt.Text);                            
                            int grid = int.Parse(uctxtGrdReturn.txt.Text);
                            string tempr = uctxtRup.txt.Text;
                            string tempr1 = uctxtR1.txt.Text;
                            string[] SNOr = tempr.Split(',');
                            string[] SNOr1 = tempr1.Split(',');
                            for (int i = 0; i < SNOr.Length; ++i)
                            {
                                string check1 = "select max(SNo) as id from RSRstock where Sdate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and VNo= " + val(uctxtSNo.txt.Text) + " and SrNo=" + SNOr1[i] + "";
                                cmd1.CommandText = check1;
                                rd = cmd1.ExecuteReader();
                                rd.Read();
                                if (rd["id"].ToString() != "")                       //
                                {
                                    int num = int.Parse(rd["id"].ToString());
                                    cmd1.Dispose();
                                    rd.Close();
                                    string fetch = "select FNo,Sdate,regular,bis from RSRstock where SNo=" + num;
                                    cmd1.CommandText = fetch;
                                    rd = cmd1.ExecuteReader();
                                    if (rd.Read())
                                    {
                                        float reg = float.Parse(rd["Regular"].ToString());
                                        float bis = float.Parse(rd["BIS"].ToString());
                                        int fno = int.Parse(rd["FNo"].ToString());
                                        var dat = rd["Sdate"].ToString();
                                        cmd1.Dispose();
                                        rd.Close();
                                        string u = "update Returnstock set Regular=Regular-" + reg + ",BIS=BIS-" + bis + " where RDate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo=" + fno + "";
                                        cmd.CommandText = u;
                                        cmd.ExecuteNonQuery();
                                        cmd.Dispose();
                                    }
                                }
                                cmd1.Dispose();
                                rd.Close();
                            }
                        }
                        string del = "delete from srstock";
                        cmd.CommandText = del;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        string del1 = "delete from rsrstock";
                        cmd2.CommandText = del1;
                        cmd2.ExecuteNonQuery();
                        cmd2.Dispose();
                        string del2 = "delete from Returnstock where Regular=0 and BIS=0";
                        cmd2.CommandText = del2;
                        cmd2.ExecuteNonQuery();
                        cmd2.Dispose();
                        transaction.Commit();
                        Globals.msgbox(this, lblTitleBar.Text + " Updated.");
                        ClearMe();
                        uctxtQty.txt.Text = "";
                        uctxtBIS.txt.Text = "";
                        grdReturn.Rows.Clear();
                        btnList_Click(sender, e);
                        btnSave.Enabled = true;
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
            else
            {
                Globals.msgbox(this, "Please Select Any Item");
                Globals.msgbox(this, "Can't save zero value entry");
            }
        }
        private void ClearMe()
        {
            Globals.ClearAllFields(this);
            status = "add";
 //           usItem.txt.Text = "Half Holiday";
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            pList.Visible = true;
            usItem.txt.Tag = "Text";
            btnShow_Click(sender, e);
            grdReturn.Rows.Clear();
            uSearch.txt.Focus();
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
            string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, pr.Date), 0))";
            //int i = 0; 
            //    sql = "Select SNo,Row_Number() over(order by VDate) as [S.No.],VDate as [Holiday Date],HolidayType,Remark from Holiday where Remark like '%" + uSearch.txt.Text.Trim() + "%' order by vdate desc";//or r.Item_Name like '%" + uSearch.txt.Text.Trim() + "%')
            sql = "select pr.Rate,pr.SNo,pr.VNo,pr.Ref_No,convert(varchar,pr.date,101) as date,r.Thickness,pr.Qty,pr.BIS,pr.Total from sales_Return pr left join finished r on pr.FNo=r.SNo where (" + VDate + " >='" + uFrom.date.Value.ToString("yyyy-MM-dd") + "' and "+ VDate +"<='" + uTo.date.Value.ToString("yyyy-MM-dd") + "') and pr.Ref_No like '%" + uSearch.txt.Text.Trim() + "%'   order by Ref_No";
            cmd = new SqlCommand(sql, Globals.con);
            //rd = cmd.ExecuteReader();
            ad = new SqlDataAdapter(cmd);
            ds.Clear();
            ad.Fill(ds);
            dv.Table = ds.Tables[0];
            gList.DataSource = dv;
            gFormat();
            //gList.Rows.Clear();
            //while (rd.Read())
            //{
            //    gList.Rows.Add(rd["SNo"].ToString() ,
            //         ++i ,
            //        rd["MName"].ToString() ,
            //        rd["Desc1"].ToString() ,
            //        rd["Unit1"].ToString());
            //}
            cmd.Dispose();
            ad.Dispose();
            //rd.Close();
            if (gList.Rows.Count > 0)
            {
                CurrentRow = 0;
                gList.Rows[CurrentRow].Selected = true;
            }
        }
        private void gFormat()
        {
            gList.Columns[0].Visible = false;
            gList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    gList.Columns[1].Visible = false;
            gList.Columns[1].Width = 75;
            gList.Columns[0].Width = 75;
            gList.Columns[2].Width = 100;
        }
        private void gFormat1()
        {
            grdReturn.Columns[0].Visible = false;
            grdReturn.Columns[1].Visible = false;
            //grdReturn.Columns[8].Visible = false;
            //grdReturn.Columns[9].Visible = false;
            grdReturn.Columns[10].Visible = false;
            grdReturn.Columns[11].Visible = false;
            grdReturn.Columns[2].Visible = false;
            grdReturn.Columns[0].Width = 75;
            grdReturn.Columns[1].Width = 75;
            grdReturn.Columns[2].Width = 100;
            grdReturn.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdReturn.Columns[3].Width = 150;
            grdReturn.Columns[3].Visible = false;
            grdReturn.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
       //     grdReturn.Columns[3].Width = 200;
            grdReturn.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
         //   grdReturn.Columns[4].Width = 150;
            grdReturn.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           // grdReturn.Columns[5].Width = 100;
            grdReturn.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           // grdReturn.Columns[6].Width = 150;          
        }
        private void gList_DoubleClick(object sender, EventArgs e)
        {
            if (gList.Rows.Count > 0 && CurrentRow >= 0)
            {
                pList.Visible = false;
                status = "edit";
                uctxtSNo.txt.Text = gList.Rows[CurrentRow].Cells[0].Value.ToString();
                uctxt2.txt.Text = gList.Rows[CurrentRow].Cells[2].Value.ToString();
                PrevRec();
                grdReturn.Focus();
                uDate.Enabled = false;
            }
        }
        private void PrevRec()
        {
            sql = "select pr.Rate,pr.Net_Total,pr.SNo,pr.VNo,pr.Date,pr.Ref_No,pr.FNo,r.Thickness,pr.Qty,pr.BIS,pr.Total from sales_return pr left join finished r on pr.FNo=r.SNo where pr.VNo=" + (uctxt2.txt.Text);  //+ "and pr.VNo=" + (uctxt2.txt.Text)
            cmd = new SqlCommand(sql, Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                uDate.date.Value = DateTime.Parse(rd["Date"].ToString());
            }
            cmd.Dispose();
            rd.Close();
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                grdReturn.Rows.Add(val(rd["SNo"].ToString()), val(rd["VNo"].ToString()), rd["Ref_No"].ToString(), val(rd["FNo"].ToString()), rd["Thickness"].ToString() , val(rd["Qty"].ToString()), val(rd["BIS"].ToString()), val(rd["Qty"].ToString()) + val(rd["BIS"].ToString()), val(rd["Rate"].ToString()), val(rd["Net_Total"].ToString()));
             //   uDate.date.Value = DateTime.Parse(rd["Date"].ToString());
            }

            cmd.Dispose();
            rd.Close();
            int r = grdReturn.Rows.Count;
            uctxtGrdReturn.txt.Text = r.ToString();
        }
        private void uSearch_TextChanged(object sender, EventArgs e)
        {
            //btnSave_Click(sender , e);
            dv.RowFilter = "[Ref_No] like '%" + uSearch.txt.Text + "%' or [Thickness] like '%" + uSearch.txt.Text + "%'";
            gList.DataSource = dv;
            if (gList.Rows.Count > 0)
            {
                CurrentRow = 0;
                gList.Rows[CurrentRow].Selected = true;
            }
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
            if (gList.Rows.Count > 0)
            {
                CurrentRow = gList.CurrentRow.Index;
            }
        }

        private void uSearch_Load(object sender, EventArgs e)
        {

        }

        private void utxtCUnit_Load(object sender, EventArgs e)
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
            using (SqlConnection con = new SqlConnection(Globals.iniConnectionString))
            {
                con.Open();
                SqlTransaction transaction;
                transaction = con.BeginTransaction();
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.Transaction = transaction;
                SqlDataReader rd1;
                if (gList.Rows.Count > 0 && (CurrentRow >= 0 && CurrentRow < gList.Rows.Count))
                {
                    int row = gList.CurrentCell.RowIndex;
                                        string sql = "select * from sales_return where Ref_No='" + gList.Rows[CurrentRow].Cells[3].Value.ToString().Trim() + "' and VNo=" + gList.Rows[CurrentRow].Cells[2].Value.ToString().Trim() + "";
//                    string sql = "select * from sales_return where VNo=" + gList.Rows[CurrentRow].Cells[2].Value.ToString().Trim() + "";
                    cmd.CommandText = sql;
                    rd1 = cmd.ExecuteReader();
                    while (rd1.Read())
                    {
                        if (uctxtdvno.txt.Text == "")
                        {
                            uctxtdvno.txt.Text = rd1["VNo"].ToString();
                        }
                        else
                        {
                            uctxtdvno.txt.Text = uctxtdvno.txt.Text + "," + rd1["VNo"].ToString();
                        }
                        if (uctxtdfno.txt.Text == "")
                        {
                            uctxtdfno.txt.Text = rd1["FNo"].ToString();
                        }
                        else
                        {
                            uctxtdfno.txt.Text = uctxtdfno.txt.Text + "," + rd1["FNo"].ToString(); ;
                        }
                        if (uctxtdreg.txt.Text == "")
                        {
                            uctxtdreg.txt.Text = rd1["Qty"].ToString();
                        }
                        else
                        {
                            uctxtdreg.txt.Text = uctxtdreg.txt.Text + "," + rd1["Qty"].ToString(); ;
                        }
                        if (uctxtdisi.txt.Text == "")
                        {
                            uctxtdisi.txt.Text = rd1["BIS"].ToString();
                        }
                        else
                        {
                            uctxtdisi.txt.Text = uctxtdisi.txt.Text + "," + rd1["BIS"].ToString(); ;
                        }                        
                    }
                    cmd.Dispose();
                    rd1.Close();
                    string vno = uctxtdvno.txt.Text;
                    string fno = uctxtdfno.txt.Text;
                    string reg = uctxtdreg.txt.Text;
                    string isi = uctxtdisi.txt.Text;                    
                    string[] att_vno = vno.Split(',');
                    string[] att_fno = fno.Split(',');
                    string[] att_reg = reg.Split(',');
                    string[] att_isi = isi.Split(',');
                    for (int j = 0; j < att_fno.Length; j++)
                    {
                        //double dvno = val(att_vno[j].ToString());
                        float dvno = float.Parse(att_vno[j].ToString());
                        float dfno = float.Parse(att_fno[j].ToString());
                        float dreg = float.Parse(att_reg[j].ToString());
                        float disi = float.Parse(att_isi[j].ToString());
                       // double dfno = val(att_fno[j].ToString());
                       // double dreg = val(att_reg[j].ToString());
                       // double disi = val(att_isi[j].ToString());
                        string sql2 = "update Returnstock set Regular=Regular-" + dreg + ",BIS=BIS-" + disi + " where RDate='" + gList.Rows[CurrentRow].Cells[4].Value.ToString().Trim() + "' and FNo=" + dfno + "";
                        cmd.CommandText = sql2;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sql = "delete from sales_return where Date='" + gList.Rows[CurrentRow].Cells[4].Value.ToString().Trim() + "' and VNo=" + int.Parse(gList.Rows[row].Cells[2].Value.ToString().Trim()) + "";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    sql = "delete from Returnstock where Regular=0 and BIS=0";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    uctxtdvno.txt.Text = "";
                    uctxtdfno.txt.Text = "";
                    uctxtdreg.txt.Text = "";
                    uctxtdisi.txt.Text = "";
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
                uDate.Enabled = true;
                uDate.Focus();
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
                uctxtQty.txt.Text = "";
                uctxtBIS.txt.Text = "";
                uctxtRefNo.txt.Text = "";
                uctxtNarration.txt.Text = "";
                uctxtRate.txt.Text = "";
                uDate.Enabled = true;
                uDate.Focus();
                grdReturn.Rows.Clear();
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
            Globals.LoadList(this, usItem.lstName, "Select SNo,Thickness from finished order by Item_Name");
        }

        private void usItem_Leave(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select FinancialDate from m_company", Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                ucFDate.date.Value = DateTime.Parse(rd["FinancialDate"].ToString());
            }
            cmd.Dispose();
            rd.Close();

            /* cmd = new SqlCommand("Select SNo from finished where Item_Name='" + usItem.txt.Text + "'", Globals.con);
             rd = cmd.ExecuteReader();
             while (rd.Read())
             {                
                 uctxtRNo.txt.Text = rd["SNo"].ToString();                               
             }*/
            uctxtRNo.txt.Text = usItem.txtCode.Text;
            //cmd.Dispose();
            //rd.Close();
            //uctxtRegular.txt.Text = "0";
            //uctxtTBIS.txt.Text = "0";
            //string qry = "select sum(vm.Total_Regular) as TRegular from Sales_Return vm where vm.FNo='" + uctxtRNo.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "' group by vm.date";
            ////cmd = new SqlCommand("select sum(vm.Regular) as TRegular from v_manufacturing vm left join finished f on vm.FNo = f.SNo where f.Item_name='" + usDesc.txt.Text + "'  and (" + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "'", Globals.con);
            //cmd = new SqlCommand(qry, Globals.con);
            //rd = cmd.ExecuteReader();
            //while (rd.Read())
            //{
            //    uctxtRegular.txt.Text = rd["TRegular"].ToString();
            //}
            //cmd.Dispose();
            //rd.Close();

            //string qry2 = "select sum(vm.Total_BIS) as TBIS from Sales_Return vm where vm.FNo='" + uctxtRNo.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "'  group by vm.date";
            //cmd = new SqlCommand(qry2, Globals.con);
            //rd = cmd.ExecuteReader();
            //while (rd.Read())
            //{
            //    uctxtTBIS.txt.Text = rd["TBIS"].ToString();
            //}
            //cmd.Dispose();
            //rd.Close();

            //if (uctxtTBIS.txt.Text == "" || uctxtTBIS.txt.Text == null)
            //{
            //    uctxtTBIS.txt.Text = "0";
            //}
            //if (uctxtRegular.txt.Text == "" || uctxtRegular.txt.Text == null)
            //{
            //    uctxtRegular.txt.Text = "0";
            //}
        }

        private void uctxtQty_Load(object sender, EventArgs e)
        {

        }
        private void AutoNumber()
        {
            for (int i = 0; i < grdReturn.Rows.Count; i++)
            {
                grdReturn.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if (!(usItem.txt.Text.Trim() == "" || val(uctxtQty.txt.Text) == 0))
            {
                if (status1 == "add")
                {
                    if(uDate.Enabled != false)
                    {
                        uctxtSNo.txt.Text = Globals.MaxCode("sales_return", "VNo").ToString();
                    }
                   
                    if (uctxtRefNo.txt.Text=="")
                    {
                        uctxtRefNo.txt.Text = uctxtSNo.txt.Text;
                    }
                    grdReturn.Rows.Add(grdReturn.Rows.Count + 1, uctxtSNo.txt.Text, uctxtRefNo.txt.Text, val(uctxtRNo.txt.Text), usItem.txt.Text, val(uctxtQty.txt.Text), val(uctxtBIS.txt.Text), val(uctxtQty.txt.Text) + val(uctxtBIS.txt.Text),val(uctxtRate.txt.Text),val(uctxtRate.txt.Text)* val(uctxtQty.txt.Text)+ val(uctxtRate.txt.Text) * val(uctxtBIS.txt.Text),0,0);
                    AutoNumber();
                    int i2 = 0;
                    for (int i = 0; i < grdReturn.Rows.Count; ++i)
                    {
                        i2 = i;
                    }
                    uctxtRcount.txt.Text = (i2+1).ToString();
                }
                else
                {
                    Srtxt.txt.Text = Globals.MaxCode("Srstock", "SNo").ToString();
                    int vn = int.Parse(uctxtSNo.txt.Text);                    
                    sql = "insert into Srstock(SNo,SrNo,Vtype,Sdate,FNo,VNo,Regular,BIS) values("
                   + val(Srtxt.txt.Text)
                   + "," + val(uctxtSrNo.txt.Text)
                   + ",'Updation"
                   + "','" + uDate.date.Value.ToString("yyyy-MM-dd")
                   + "'," + val(uctxttbfno.txt.Text)
                    + "," + (vn)
                   + "," + val(uctxttbreg.txt.Text)
                   + "," + val(uctxttbBIS.txt.Text) + ")";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    if (uctxtup.txt.Text == "")
                    {
                        uctxtup.txt.Text = uctxttbfno.txt.Text;
                    }
                    else
                    {
                        uctxtup.txt.Text = uctxtup.txt.Text + "," + uctxttbfno.txt.Text;
                    }
                    if (uctxt1.txt.Text == "")
                    {
                        uctxt1.txt.Text = uctxtSrNo.txt.Text;
                    }
                    else
                    {
                        uctxt1.txt.Text = uctxt1.txt.Text + "," + uctxtSrNo.txt.Text;
                    }
                    grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[0].Value = val(uctxtSrNo.txt.Text);
                    grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[1].Value = val(uctxtSNo.txt.Text);
                    grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[2].Value = uctxtRefNo.txt.Text;
                    grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[4].Value = usItem.txt.Text;
                    //grdRatio.Rows[grdRatio.CurrentCell.RowIndex].Cells[3].Value = uctxtRunit.txt.Text;
                    grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[5].Value = val(uctxtQty.txt.Text);
                    grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[6].Value = val(uctxtBIS.txt.Text);
                    grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[7].Value = val(uctxtQty.txt.Text) + val(uctxtBIS.txt.Text);
                    grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[8].Value = val(uctxtRate.txt.Text);
                    grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[9].Value = val(uctxtRate.txt.Text) * val(uctxtQty.txt.Text) + val(uctxtRate.txt.Text) * val(uctxtBIS.txt.Text);
                    int ii = 0;
                    for (int i = 0; i < grdReturn.Rows.Count; ++i)
                    {
                        ii = i;
                    }
                    uctxtRcount.txt.Text = (ii+1).ToString();

                }

                status1 = "add";
                uctxtRefNo.txt.Text = "";
                usItem.txtCode.Text = "";
                uctxtQty.txt.Text = "";
                uctxtBIS.txt.Text = "";                
            }
            else
            {
                Globals.msgbox(this, "Something Missing");
            }
            usItem.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (uDate.Enabled == true)
                {
                    grdReturn.Rows.RemoveAt(grdReturn.CurrentRow.Index);
                    AutoNumber();
                }
                else if (uDate.Enabled == false && uctxtSrNo1.txt.Text != "")
                {
                    RSRstock.txt.Text = Globals.MaxCode("RSRstock", "SNo").ToString();
                    int vn = int.Parse(uctxtSNo.txt.Text);
                    sql = "insert into RSRstock(SNo,SrNo,Vtype,Sdate,FNo,VNo,Regular,BIS) values("
                   + val(RSRstock.txt.Text)
                   + "," + val(uctxtSrNo1.txt.Text)
                   + ",'Updation"
                   + "','" + uDate.date.Value.ToString("yyyy-MM-dd")
                   + "'," + val(uctxttbfno1.txt.Text)
                    + "," + vn
                   + "," + val(uctxttbreg1.txt.Text)
                   + "," + val(uctxttbBIS1.txt.Text) + ")";
                    //string u = "update Sstock set CGST = CGST - " + cgst + ",SGST = SGST -" + sgst + ",IGST = IGST -" + igst + ",Regular=Regular-" + reg + ",BIS=BIS-" + bis + ",value=value-" + value + " where SDate='" + dat + "' and FNo=" + fno + "";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    if (uctxtRup.txt.Text == "")
                    {
                        uctxtRup.txt.Text = uctxttbfno1.txt.Text;
                    }
                    else
                    {
                        uctxtRup.txt.Text = uctxtRup.txt.Text + "," + uctxttbfno1.txt.Text;
                    }
                    if (uctxtR1.txt.Text == "")
                    {
                        uctxtR1.txt.Text = uctxtSrNo1.txt.Text;
                    }
                    else
                    {
                        uctxtR1.txt.Text = uctxtR1.txt.Text + "," + uctxtSrNo1.txt.Text;
                    }
                    grdReturn.Rows.RemoveAt(grdReturn.CurrentRow.Index);
                    AutoNumber();
                    uctxtSrNo1.txt.Text = "";
                }
                else
                {
                    Globals.msgbox(this, "Please Select Any Row To Delete");
                }
            }
            catch (Exception ex) { }
            uctxtremove.txt.Text = "Removed";
            if (uctxtupdate.txt.Text != "" && uctxtremove.txt.Text != "")
            {
                Globals.msgbox(this, "Updation and Deletion not allowed at same time");
                btnSave.Enabled = false;
                grdReturn.Rows.Clear();
            }
        }

        private void uTo_Load(object sender, EventArgs e)
        {

        }

        private void grdReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = grdReturn.CurrentCell.RowIndex;
            uctxttbfno1.txt.Text = grdReturn.Rows[row].Cells[3].Value.ToString();
            uctxtSrNo1.txt.Text = grdReturn.Rows[row].Cells[0].Value.ToString();
            uctxttbreg1.txt.Text = grdReturn.Rows[row].Cells[5].Value.ToString();
            uctxttbBIS1.txt.Text = grdReturn.Rows[row].Cells[6].Value.ToString();
            uctxtRate.txt.Text = grdReturn.Rows[row].Cells[7].Value.ToString();
        }

        private void uctxtRate_Leave(object sender, EventArgs e)
        {
            if(uctxtRate.txt.Text == "")
            {
                uctxtRate.txt.Text = "0";
            }
        }

        private void uctxtQty_Leave(object sender, EventArgs e)
        {
            if(uctxtQty.txt.Text == "0")
            {
                uctxtQty.txt.Text = "0";
            }
        }

        private void uctxtBIS_Leave(object sender, EventArgs e)
        {
            if(uctxtBIS.txt.Text=="0")
            {
                uctxtBIS.txt.Text = "0";
            }
        }

        private void grdReturn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = grdReturn.CurrentCell.RowIndex;
            uctxttbfno.txt.Text = grdReturn.Rows[row].Cells[3].Value.ToString();
            uctxttbfno1.txt.Text = grdReturn.Rows[row].Cells[3].Value.ToString();
            uctxtSNo.txt.Text = grdReturn.Rows[row].Cells[1].Value.ToString();
            uctxtSrNo.txt.Text = grdReturn.Rows[row].Cells[0].Value.ToString();
            uctxtSrNo1.txt.Text= grdReturn.Rows[row].Cells[0].Value.ToString();
            uctxtRefNo.txt.Text = grdReturn.Rows[row].Cells[2].Value.ToString();
            uctxtRNo.txt.Text = grdReturn.Rows[row].Cells[3].Value.ToString();
            usItem.txt.Text = grdReturn.Rows[row].Cells[4].Value.ToString();
            uctxtQty.txt.Text = grdReturn.Rows[row].Cells[5].Value.ToString();
            uctxttbreg.txt.Text = grdReturn.Rows[row].Cells[5].Value.ToString();
            uctxttbreg1.txt.Text = grdReturn.Rows[row].Cells[5].Value.ToString();
            uctxttbBIS.txt.Text = grdReturn.Rows[row].Cells[6].Value.ToString();
            uctxttbBIS1.txt.Text = grdReturn.Rows[row].Cells[6].Value.ToString();
            uctxtBIS.txt.Text = grdReturn.Rows[row].Cells[6].Value.ToString();
            uctxtRate.txt.Text = grdReturn.Rows[row].Cells[8].Value.ToString();
            uctxtRefNo.Enabled = false;
            status1 = "edit";
            usItem.Focus();
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

