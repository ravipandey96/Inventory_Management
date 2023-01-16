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
using System.Collections;

namespace ERP
{
    public partial class frmProduction : Form
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
        string sql2 = null;
        string sql3 = null;
        SqlCommand cmd,cmd1,cmd2,cmd4,cmd3;
        SqlDataReader rd,rd1,rd2,rd4;
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
        public frmProduction()
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
            uDate.Focus();
            frmMain frm = new frmMain();
            int ht = btnSave.Top - (usDesc.Top + usDesc.Height);
            usDesc.txt.Tag = "SearchList,AutoHeight:false,Height:" + ht + ",";
            uctxtQty.txt.Tag = "number,Require";
            uctxtISI.txt.Tag = "number";
            gFormat1();
            status = "add";
            FormMode = "Max";
            //Form Position     
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
            /*  if (usDesc.txt.Text.Trim() == "")
              {
                  Globals.msgbox(this, " Please Enter Item Name.");
                  usDesc.Focus();
                  return;
              }*/
            //     jump:
            if (grdProduction.Rows.Count != 0)
            {
             //   Globals.msgbox(this, "Please Select Any Item");
                //grdProduction.Focus();
                //btnSave.Enabled = false;
                //             goto jump;
            
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
                    SqlDataReader rd, rd1, rd2, rd4;
                try
                {
                    btnSave.Enabled = false;
                    if (status == "add")
                    {
//                                                uctxtfpfno.txt.Text = Globals.MaxCode("sales", "VNo").ToString();
                        long sno = long.Parse(uctxtDno.txt.Text);
/*                            string fd = "Select FinancialDate from m_company";
                            cmd.CommandText = fd;
                            rd = cmd.ExecuteReader();
                            while (rd.Read())
                            {
                                ucFDate.date.Value = DateTime.Parse(rd["FinancialDate"].ToString());
                            }
                            cmd.Dispose();
                            rd.Close();
                            for (int k = 0; k < grdProduction.Rows.Count; ++k)
                            {                                                                
                                string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, op.VDate), 0))";
                                string VDate1 = "(DATEADD(DAY, DATEDIFF(day, 0, vm.date), 0))";
                                string VDate2 = "(DATEADD(DAY, DATEDIFF(day, 0, sr.Date), 0))";
                                string VDate3 = "(DATEADD(DAY, DATEDIFF(day, 0, s.SDate), 0))";
                                string qry1 = "select f.sno,f.thickness,isnull((select sum(op.regular) from m_Item_Opening op where op.Item_type = 'Finished Good' and op.INo = f.SNo and (" + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as OPStock, isnull((select sum(vm.Regular) from v_manufacturing vm where vm.FNo = f.SNo and (" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as PRODUCTION,isnull((select sum(vm.breackage) from v_manufacturing vm where vm.FNo = f.SNo and(" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as BREACKAGE,isnull((select sum(sr.qty) from Sales_Return sr where sr.FNo = f.SNo and(" + VDate2 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate2 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as SaleReturn,isnull((select sum(s.qty) from sales s where s.FNo = f.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as Sales,isnull((select sum(s.ISI)   from sales s where s.FNo = f.SNo and (" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as ISI,isnull((select sum(s.taxable_value) from sales s where s.FNo = f.SNo and (" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as Value,isnull((select sum(s.SGST) from sales s where s.FNo = f.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as SGST,isnull((select sum(s.CGST) from sales s where s.FNo = f.SNo and (" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as CGST,isnull((select sum(s.IGST) from sales s where s.FNo = f.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as IGST,'0' as CLSTOCK from finished f where Sno='" + val(grdProduction.Rows[k].Cells[2].Value.ToString().Trim()) + "' group by f.sno,f.thickness order by f.SNo";
                                cmd.CommandText = qry1;
                                rd = cmd.ExecuteReader();
                                while (rd.Read())
                                {
                                    float o = float.Parse(rd["OPSTOCK"].ToString());
                                    float p = float.Parse(rd["PRODUCTION"].ToString());
                                    float s = float.Parse(rd["Sales"].ToString());
                                    float sr = float.Parse(rd["SaleReturn"].ToString());
                                    float tt = o + p + sr - s;
                                    uctxtfptotalreg.txt.Text = tt.ToString();                             
                                }
                                cmd.Dispose();
                                rd.Close();
                                string qry2 = "select f.sno,f.thickness,isnull((select sum(op.BIS) from m_Item_Opening op where op.Item_type = 'Finished Good' and op.INo = f.SNo and (" + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as OPStock, isnull((select sum(vm.ISI) from v_manufacturing vm where vm.FNo = f.SNo and (" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as PRODUCTION,isnull((select sum(vm.breackage) from v_manufacturing vm where vm.FNo = f.SNo and(" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as BREACKAGE,isnull((select sum(sr.BIS) from Sales_Return sr where sr.FNo = f.SNo and(" + VDate2 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate2 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as SaleReturn,isnull((select sum(s.ISI) from sales s where s.FNo = f.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as Sales from finished f where SNo='" + val(grdProduction.Rows[k].Cells[2].Value.ToString().Trim()) + "' group by f.sno,f.thickness order by f.SNo";
                                cmd.CommandText = qry2;
                                rd = cmd.ExecuteReader();
                                while (rd.Read())
                                {
                                    float o = float.Parse(rd["OPSTOCK"].ToString());
                                    float p = float.Parse(rd["PRODUCTION"].ToString());
                                    //                float b = float.Parse(rd["BREACKAGE"].ToString());
                                    float s = float.Parse(rd["Sales"].ToString());
                                    float sr = float.Parse(rd["SaleReturn"].ToString());
                                    float tt = o + p + sr - s;
                                    uctxtfptotalbis.txt.Text = tt.ToString();      
                                }
                                cmd.Dispose();
                                rd.Close();
                                sql3 = "insert into sales(VNo,Sdate,Total_Regular,Total_ISI,FNo) values("
                                + val(uctxtfpfno.txt.Text)
                                + ",'" +uDate.date.Value.ToString("yyyy-MM-dd")
                                + "'," + val(uctxtfptotalreg.txt.Text)
                                + "," + val(uctxtfptotalbis.txt.Text)
                                + "," + int.Parse(grdProduction.Rows[k].Cells[2].Value.ToString().Trim()) + ")";
                                cmd1.CommandText = sql3;
                                cmd1.ExecuteNonQuery();
                                cmd1.Dispose();
                            }*/
                            for (int i = 0; i < grdProduction.Rows.Count; ++i)
                            {
                                sql = "insert into v_manufacturing(SNo,SrNo,FNo,Date,Qty,Breackage,ISI,Regular) values("
                                + (sno)
                                + "," + (i + 1)
                                + "," + int.Parse(grdProduction.Rows[i].Cells[2].Value.ToString().Trim())
                                + ",'" + uDate.date.Value.ToString("yyyy-MM-dd")
                                //                            + "','" + grdProduction.Rows[i].Cells[2].Value.ToString().Trim()
                                + "'," + float.Parse(grdProduction.Rows[i].Cells[4].Value.ToString().Trim())
                                + "," + float.Parse(grdProduction.Rows[i].Cells[5].Value.ToString().Trim())
                                + "," + float.Parse(grdProduction.Rows[i].Cells[6].Value.ToString().Trim())
                                + "," + float.Parse(grdProduction.Rows[i].Cells[7].Value.ToString().Trim()) + ")";
                                cmd.CommandText = sql;
                                string sql1 = "select Rno,Qty from Required_Ratio where FNo=" + int.Parse(grdProduction.Rows[i].Cells[2].Value.ToString().Trim()) + " and RDate <='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and TDate>='" + uDate.date.Value.ToString("yyyy-MM-dd") + "'";
                                //cmd1 = new SqlCommand(sql1, Globals.con);
                                //rd = cmd1.ExecuteReader();
                                cmd1.CommandText = sql1;
                                rd = cmd1.ExecuteReader();
                                while (rd.Read())
                                {
                                    //var temp_Rno = rd["Rno"].ToString();
                                    //var temp_qty = rd["Qty"].ToString();
                                    if (uctxtuup.txt.Text == "")
                                    {
                                        uctxtuup.txt.Text = rd["Rno"].ToString();
                                    }
                                    else
                                    {
                                        uctxtuup.txt.Text = uctxtuup.txt.Text + "," + rd["Rno"].ToString(); 
                                    }
                                    if (uctxt11.txt.Text == "")
                                    {
                                        uctxt11.txt.Text = rd["Qty"].ToString();
                                    }
                                    else
                                    {
                                        uctxt11.txt.Text = uctxt11.txt.Text + "," + rd["Qty"].ToString();
                                    }
                                }
                                cmd1.Dispose();
                                rd.Close();
                                string temp = uctxtuup.txt.Text;
                                string temp1 = uctxt11.txt.Text;
                                if (temp != "")
                                {
                                    //   string[] SNO = temp.Split('|');
                                    //   string[] SNO1 = temp1.Split('|');
                                    string[] att_rno = temp.Split(',');
                                    string[] att_qty = temp1.Split(',');
                                    for (int j = 0; j < att_rno.Length; j++)
                                    {
                                        float r_no = float.Parse(att_rno[j].ToString());
                                        float r_qty = float.Parse(att_qty[j].ToString());
                                        sql2 = "insert into consumption(SNo,RNo,FNo,Date,Qty,Ratio,R_Qty) values("
                                        + (sno)
                                        + "," + r_no
                                        + "," + int.Parse(grdProduction.Rows[i].Cells[2].Value.ToString().Trim())
                                        + ",'" + uDate.date.Value.ToString("yyyy-MM-dd")
                                        + "'," + float.Parse(grdProduction.Rows[i].Cells[4].Value.ToString().Trim())
                                        + "," + r_qty
                                        + "," + (float.Parse(grdProduction.Rows[i].Cells[4].Value.ToString().Trim()) * r_qty) + ")";
                                        cmd4.CommandText = sql2;
                                        cmd4.ExecuteNonQuery();
                                        cmd4.Dispose();
                                    }
                                    string check = "select * from v_manufacturing where date='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and fno=" + int.Parse(grdProduction.Rows[i].Cells[2].Value.ToString().Trim());
                                    // string check = "select * from v_manufacturing"; 
                                    // cmd1 = new SqlCommand(check, Globals.con);
                                    // rd1= cmd1.ExecuteReader();
                                    cmd1.CommandText = check;
                                    rd1 = cmd1.ExecuteReader();
                                    //if(rd1.Read().Equals(null) == false)
                                    if (rd1.Read())
                                    {
                                        //                                if (rd1.Read())
                                        if (rd1["FNo"].ToString() != null && rd1["Date"].ToString() != null)
                                        {
                                            uprev.date.Value = DateTime.Parse(rd1["date"].ToString());
                                            uctxtFnoTest.txt.Text = rd1["FNo"].ToString();

                                            if (uDate.date.Value.ToString("yyyy-MM-dd") == uprev.date.Value.ToString("yyyy-MM-dd") && val(uctxtFnoTest.txt.Text) == int.Parse(grdProduction.Rows[i].Cells[2].Value.ToString().Trim()))
                                            {
                                                cmd1.Dispose();
                                                rd1.Close();
                                                // string check2 = "select * from Pstock where PDate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo=" + int.Parse(grdProduction.Rows[i].Cells[1].Value.ToString().Trim());
                                                /* cmd4 = new SqlCommand(check2, Globals.con);
                                                 rd4 = cmd4.ExecuteReader();
                                                 if (rd4.Read())
                                                 {
                                                     float bis = float.Parse(rd4["BIS"].ToString());
                                                     float reg = float.Parse(rd4["Regular"].ToString());
                                                     float br = float.Parse(rd4["Breackage"].ToString());
                                                     ucpisi.txt.Text = bis.ToString();
                                                     ucpreg.txt.Text = reg.ToString();
                                                     uctxtb.txt.Text = br.ToString();
                                                 }
                                                 cmd4.Dispose();
                                                 rd4.Close();*/
                                                string u = "update Pstock set Regular=Regular+" + float.Parse(grdProduction.Rows[i].Cells[7].Value.ToString().Trim()) + ",BIS=BIS+" + float.Parse(grdProduction.Rows[i].Cells[6].Value.ToString().Trim()) + ",Breackage=Breackage+" + float.Parse(grdProduction.Rows[i].Cells[5].Value.ToString().Trim()) + " where PDate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo=" + int.Parse(grdProduction.Rows[i].Cells[2].Value.ToString().Trim()) + "";
                                                cmd2.CommandText = u;
                                                cmd2.ExecuteNonQuery();
                                                cmd2.Dispose();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        cmd1.Dispose();
                                        rd1.Close();
                                        string stock = "insert into Pstock(PDate,FNo,Regular,VNo,BIS,Breackage) values ('"
                                        + uDate.date.Value.ToString("yyyy-MM-dd")
                                        + "'," + int.Parse(grdProduction.Rows[i].Cells[2].Value.ToString().Trim())
                                        + "," + float.Parse(grdProduction.Rows[i].Cells[7].Value.ToString().Trim())
                                        + "," + val(uctxtDno.txt.Text)
                                        + "," + float.Parse(grdProduction.Rows[i].Cells[6].Value.ToString().Trim())
                                        + "," + float.Parse(grdProduction.Rows[i].Cells[5].Value.ToString().Trim()) + ")";
                                        cmd2.CommandText = stock;
                                        cmd2.ExecuteNonQuery();
                                        cmd2.Dispose();

                                    }
                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();
                                    /*                                  string check = "select * from sales where Sdate='" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo=" + int.Parse(grdSales.Rows[i].Cells[2].Value.ToString().Trim());
                                                                        cmd1.CommandText = check;
                                                                        rd = cmd1.ExecuteReader();
                                                                        if (rd.Read())
                                                                        {
                                                                            if (rd["FNo"].ToString() != null && rd["Sdate"].ToString() != null)
                                                                            {
                                                                                uprev.date.Value = DateTime.Parse(rd["Sdate"].ToString());
                                                                                uctxtFnoTest.txt.Text = rd["FNo"].ToString();

                                                                                if (ucBillDate.date.Value.ToString("yyyy-MM-dd") == uprev.date.Value.ToString("yyyy-MM-dd") && val(uctxtFnoTest.txt.Text) == int.Parse(grdSales.Rows[i].Cells[2].Value.ToString().Trim()))
                                                                                {
                                                                                    cmd1.Dispose();
                                                                                    rd.Close();
                                                                                    string u = "update Sstock set BillNo=BillNo + '," + uctxtInvNo.txt.Text + ",',CGST = CGST + " + float.Parse(grdSales.Rows[i].Cells[8].Value.ToString().Trim()) + ",SGST = SGST +" + float.Parse(grdSales.Rows[i].Cells[9].Value.ToString().Trim()) + ",IGST = IGST +" + float.Parse(grdSales.Rows[i].Cells[11].Value.ToString().Trim()) + ",Regular=Regular+" + float.Parse(grdSales.Rows[i].Cells[5].Value.ToString().Trim()) + ",BIS=BIS+" + float.Parse(grdSales.Rows[i].Cells[4].Value.ToString().Trim()) + ",value=value+" + float.Parse(grdSales.Rows[i].Cells[7].Value.ToString().Trim()) + " where SDate='" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo=" + int.Parse(grdSales.Rows[i].Cells[2].Value.ToString().Trim()) + "";
                                                                                    cmd1.CommandText = u;
                                                                                    cmd1.ExecuteNonQuery();
                                                                                    cmd1.Dispose();
                                                                                }
                                                                            }
                                                                        }*/
                                    
                                }
                                else
                                {
                                    Globals.msgbox(this, "Ratio setup for entered item is not available for date->" + uDate.date.Value.ToString("yyyy-MM-dd"));
                                    //transaction.Rollback();
                                    //if (Globals.msgbox( "Do You Want To Delete ?", "YesNo") != 1) return;
                                    //Globals.msgbox("SORRY YOU DON'T HAVE PERMISSION TO \n\n " + (status == "add" ? "'ADD NEW RECORD.'" : "'UPDATE EXISTING RECORD.'"));
                                    //Globals.msgbox(this, "Do You Want to copy previous ratio details for current month");
                                    uDate.Focus();
                                }
                            }
                            uctxtuup.txt.Text = "";
                            uctxt11.txt.Text = "";
                            transaction.Commit();
                            Globals.msgbox(this, "Record Saved.");
                            ClearMe();
                            grdProduction.Rows.Clear();
                            usDesc.Focus();
                        }
                        else // -----update-----
                    {
                        uctxtuup.txt.Text = "";
                        uctxt11.txt.Text = "";
                        long sno = long.Parse(uctxtDno.txt.Text);
                        sql = "delete from v_manufacturing where SNo=" + sno + " and date='" + uDate.date.Value.ToString("yyyy-MM-dd") + "'";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        sql = "delete from consumption where SNo=" + sno + " and date='" + uDate.date.Value.ToString("yyyy-MM-dd") + "'";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        for (int k = 0; k < grdProduction.Rows.Count; ++k)
                        {
                            sql = "insert into v_manufacturing(SNo,SrNo,FNo,Date,Qty,Breackage,ISI,Regular) values("
                            + sno
                            + "," + (k + 1)
                            + "," + int.Parse(grdProduction.Rows[k].Cells[2].Value.ToString().Trim())
                            + ",'" + uDate.date.Value.ToString("yyyy-MM-dd")
                            //                            + "','" + grdProduction.Rows[i].Cells[2].Value.ToString().Trim()
                            + "'," + float.Parse(grdProduction.Rows[k].Cells[4].Value.ToString().Trim())
                            + "," + float.Parse(grdProduction.Rows[k].Cells[5].Value.ToString().Trim())
                            + "," + float.Parse(grdProduction.Rows[k].Cells[6].Value.ToString().Trim())
                            + "," + float.Parse(grdProduction.Rows[k].Cells[7].Value.ToString().Trim()) + ")";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                                string sql1 = "select Rno,Qty from Required_Ratio where FNo=" + int.Parse(grdProduction.Rows[k].Cells[2].Value.ToString().Trim()) + " and RDate <='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and TDate>='" + uDate.date.Value.ToString("yyyy-MM-dd") + "'";
                                //cmd1 = ne                                                                             w SqlCommand(sql1, Globals.con);
                                //rd = cmd1.ExecuteReader();
                                cmd1.CommandText = sql1;
                            rd = cmd1.ExecuteReader();
                            while (rd.Read())
                            {
                                if (uctxtuup.txt.Text == "")
                                {
                                    uctxtuup.txt.Text = rd["Rno"].ToString();
                                }
                                else
                                {
                                    uctxtuup.txt.Text = uctxtuup.txt.Text + "," + rd["Rno"].ToString();
                                }
                                if (uctxt11.txt.Text == "")
                                {
                                    uctxt11.txt.Text = rd["Qty"].ToString();
                                }
                                else
                                {
                                    uctxt11.txt.Text = uctxt11.txt.Text + "," + rd["Qty"].ToString();
                                }
                            }
                            cmd1.Dispose();
                            rd.Close();
                            string utemp = uctxtuup.txt.Text;
                            string utemp1 = uctxt11.txt.Text;
                            //   string[] SNO = temp.Split('|');
                            //   string[] SNO1 = temp1.Split('|');
                            string[] att_rno = utemp.Split(',');
                            string[] att_qty = utemp1.Split(',');
                            for (int j = 0; j < att_rno.Length; j++)
                            {
                                float r_no = float.Parse(att_rno[j].ToString());
                                float r_qty = float.Parse(att_qty[j].ToString());
                                sql2 = "insert into consumption(SNo,RNo,FNo,Date,Qty,Ratio,R_Qty) values("
                                + (sno)
                                + "," + r_no
                                + "," + int.Parse(grdProduction.Rows[k].Cells[2].Value.ToString().Trim())
                                + ",'" + uDate.date.Value.ToString("yyyy-MM-dd")
                                + "'," + float.Parse(grdProduction.Rows[k].Cells[4].Value.ToString().Trim())
                                + "," + r_qty
                                + "," + (float.Parse(grdProduction.Rows[k].Cells[4].Value.ToString().Trim()) * r_qty) + ")";
                                cmd.CommandText = sql2;
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                            }
                            uctxtuup.txt.Text = "";
                            uctxt11.txt.Text = "";
                        }
                        string temp = uctxtup.txt.Text;
                        string temp1 = uctxt1.txt.Text;
                        string[] SNO = temp.Split(',');
                        string[] SNO1 = temp1.Split(',');
                        int t = 0;
                            if (uDate.date.Value != uDate.date.Value)    //Date Updation Part Start
                            {
                                string temp21="";                                
                                int vno0 = int.Parse(uctxtDno.txt.Text);
                                string check01 = "select VNo,PDate,FNo from Pstock where PDate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and VNo= " + vno0 + "";
                                cmd1.CommandText = check01;
                                rd = cmd1.ExecuteReader();
                                rd.Read();
                                while (rd["FNo"].ToString() != "")                       //
                                {
                                    float fno = float.Parse(rd["FNo"].ToString());
                                    float reg = float.Parse(rd["Regular"].ToString());
                                    float bis = float.Parse(rd["BIS"].ToString());
                                    float breakage = float.Parse(rd["Breackage"].ToString());
                                    cmd1.Dispose();
                                    rd.Close();
                                    string u = "update pstock set Regular = Regular - " + reg + ",Breackage = Breackage -" + breakage + ",BIS = BIS -" + bis + " where  FNo=" + fno + "and PDate='" + uDate.date.Value + "' and VNo=" + vno0 + "";
                                    cmd.CommandText = u;
                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();
                                }
                                    string fetch = "select FNo,VNo,PDate from Pstock where PDate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "'";
                                    cmd1.CommandText = fetch;
                                    rd = cmd1.ExecuteReader();
                                    while (rd.Read())
                                    {
                                        //float breackage = float.Parse(rd["breackage"].ToString());
                                        //float reg1 = float.Parse(rd["Regular"].ToString());
                                        //float bis1 = float.Parse(rd["BIS"].ToString());                                        
                                        temp21 = temp21 + rd["FNo"].ToString() + ",";

                                    }
                                    cmd1.Dispose();
                                    rd.Close();
                                    if (temp21 != "")    //condition to cheak wheather any entry exist in new date to sum up any particular item by fno
                                    {                                        
                                        temp21 = temp21.Remove(temp21.Length - 1, 1);
                                        string[] SN = temp21.Split(',');
                                        for (int j = 0; j < SN.Length; j++)
                                        {
                                            int f_no = int.Parse(SN[j].ToString());
                                            string u2 = "update Pstock set Regular = Regular + " + float.Parse(grdProduction.Rows[j].Cells[7].Value.ToString().Trim()) + ",BIS = BIS + " + float.Parse(grdProduction.Rows[j].Cells[6].Value.ToString().Trim()) + ",Breackage=Breackage+" +float.Parse(grdProduction.Rows[j].Cells[5].Value.ToString().Trim()) + " where PDate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo="  + int.Parse(grdProduction.Rows[j].Cells[2].Value.ToString().Trim()) + " and FNo="+ val(f_no);
                                            cmd2.CommandText = u2;
                                            cmd2.ExecuteNonQuery();
                                            cmd2.Dispose();
                                        }
                                }
                                    else
                                {
                                    for (int k = 0; k < grdProduction.Rows.Count; ++k)
                                    {
                                        string stock = "insert into Pstock(Pdate,FNo,Vno,Regular,BIS,breackage) values ('"
                                        + uDate.date.Value.ToString("yyyy-MM-dd")
                                        + "'," + int.Parse(grdProduction.Rows[k].Cells[2].Value.ToString().Trim())
                                        + "," + val(uctxtDno.txt.Text)
                                        //                                            + "," + v
                                        + "," + float.Parse(grdProduction.Rows[k].Cells[7].Value.ToString().Trim())
                                        + "," + float.Parse(grdProduction.Rows[k].Cells[6].Value.ToString().Trim())
                                        + "," + float.Parse(grdProduction.Rows[k].Cells[5].Value.ToString().Trim()) + ")";
                                        cmd.CommandText = stock;
                                        cmd.ExecuteNonQuery();
                                        cmd.Dispose();
                                    }
                                }
                            }     //date updation part exit
                            if (temp != "")
                        {
                            for (int j = 0; j < SNO.Length; j++)
                            {
                                t = int.Parse(SNO1[j].ToString()) - 1;
                                string u = "update Pstock set Regular = Regular + " + float.Parse(grdProduction.Rows[t].Cells[7].Value.ToString().Trim()) + ",BIS = BIS +" + float.Parse(grdProduction.Rows[t].Cells[6].Value.ToString().Trim()) + ",Breackage = Breackage +" + float.Parse(grdProduction.Rows[t].Cells[5].Value.ToString().Trim()) + " where PDate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo=" + val(SNO[j]) + "";
                                cmd1.CommandText = u;
                                cmd1.ExecuteNonQuery();
                                cmd1.Dispose();
                            }
                        }
                        if (uctxtSrNo.txt.Text != "")
                        {
                            int sr = int.Parse(uctxtSrNo.txt.Text);
                            int vno = int.Parse(uctxtDno.txt.Text);
                            for (int i = 0; i < grdProduction.Rows.Count; ++i)
                            {
                                string check1 = "select max(SNo) as id from NPstock where Sdate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and VNo= " + vno + " and SrNo=" + (i + 1) + "";
                                cmd1.CommandText = check1;
                                rd = cmd1.ExecuteReader();
                                rd.Read();
                                if (rd["id"].ToString() != "")                       //
                                {
                                    int num = int.Parse(rd["id"].ToString());
                                    cmd1.Dispose();
                                    rd.Close();
                                    string fetch = "select FNo,Sdate,regular,bis,breackage from NPstock where SNo=" + num;
                                    cmd1.CommandText = fetch;
                                    rd = cmd1.ExecuteReader();
                                    if (rd.Read())
                                    {
                                        float breackage = float.Parse(rd["breackage"].ToString());
                                        float reg = float.Parse(rd["Regular"].ToString());
                                        float bis = float.Parse(rd["BIS"].ToString());
                                        int fno = int.Parse(rd["FNo"].ToString());
                                        var dat = rd["Sdate"].ToString();
                                        cmd1.Dispose();
                                        rd.Close();
                                        string u = "update Pstock set Regular=Regular-" + reg + ",BIS=BIS-" + bis + ",breackage=breackage-" + breackage + " where PDate='" + dat + "' and FNo=" + fno + "";
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
                            int v = int.Parse(uctxtDno.txt.Text);
                            int ins = int.Parse(uctxtGrdProduction.txt.Text);
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
                                    string check = "select fno from Pstock where Pdate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and vno= " + val(uctxtDno.txt.Text) + " and FNo=" + val(grdProduction.Rows[i].Cells[2].Value.ToString().Trim());
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
                                            string u = "update Pstock set Regular=Regular+" + float.Parse(grdProduction.Rows[i].Cells[7].Value.ToString().Trim()) + ",BIS=BIS+" + float.Parse(grdProduction.Rows[i].Cells[6].Value.ToString().Trim()) + ",breackage=breackage+" + float.Parse(grdProduction.Rows[i].Cells[5].Value.ToString().Trim()) + " where PDate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo=" + int.Parse(grdProduction.Rows[i].Cells[2].Value.ToString().Trim()) + "";
                                            cmd2.CommandText = u;
                                            cmd2.ExecuteNonQuery();
                                            cmd2.Dispose();
                                        }
                                    }
                                    else
                                    {
                                        cmd3.Dispose();
                                        rd1.Close();
                                        string stock = "insert into Pstock(Pdate,FNo,Vno,Regular,BIS,breackage) values ('"
                                            + uDate.date.Value.ToString("yyyy-MM-dd")
                                            + "'," + int.Parse(grdProduction.Rows[i].Cells[2].Value.ToString().Trim())
                                            + "," + val(uctxtDno.txt.Text)
                                            //                                            + "," + v
                                            + "," + float.Parse(grdProduction.Rows[i].Cells[7].Value.ToString().Trim())
                                            + "," + float.Parse(grdProduction.Rows[i].Cells[6].Value.ToString().Trim())
                                            + "," + float.Parse(grdProduction.Rows[i].Cells[5].Value.ToString().Trim()) + ")";
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
                            int grid = int.Parse(uctxtGrdProduction.txt.Text);
                            string tempr = uctxtRup.txt.Text;
                            string tempr1 = uctxtR1.txt.Text;
                            string[] SNOr = tempr.Split(',');
                            string[] SNOr1 = tempr1.Split(',');
                            for (int i = 0; i < SNOr.Length; ++i)
                            {
                                string check1 = "select max(SNo) as id from RNPstock where Sdate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and VNo= " + sno + " and SrNo=" + SNOr1[i] + "";
                                cmd1.CommandText = check1;
                                rd = cmd1.ExecuteReader();
                                rd.Read();
                                if (rd["id"].ToString() != "")                       //
                                {
                                    int num = int.Parse(rd["id"].ToString());
                                    cmd1.Dispose();
                                    rd.Close();
                                    string fetch = "select FNo,Sdate,regular,bis,breackage from RNPstock where SNo=" + num;
                                    cmd1.CommandText = fetch;
                                    rd = cmd1.ExecuteReader();
                                    if (rd.Read())
                                    {
                                        float Br = float.Parse(rd["Breackage"].ToString());
                                        float reg = float.Parse(rd["Regular"].ToString());
                                        float bis = float.Parse(rd["BIS"].ToString());
                                        int fno = int.Parse(rd["FNo"].ToString());
                                        var dat = rd["Sdate"].ToString();
                                        cmd1.Dispose();
                                        rd.Close();
                                        string u = "update Pstock set Regular=Regular-" + reg + ",BIS=BIS-" + bis + ",Breackage=Breackage-" + Br + " where PDate='" + uDate.date.Value.ToString("yyyy-MM-dd") + "' and FNo=" + fno + "";
                                        cmd.CommandText = u;
                                        cmd.ExecuteNonQuery();
                                        cmd.Dispose();
                                    }
                                }
                                cmd1.Dispose();
                                rd.Close();
                            }
                        }
                        string del = "delete from npstock";
                        cmd2.CommandText = del;
                        cmd2.ExecuteNonQuery();
                        cmd2.Dispose();
                        transaction.Commit();
                        string del1 = "delete from rnpstock";
                        cmd2.CommandText = del1;
                        cmd2.ExecuteNonQuery();
                        cmd2.Dispose();
                        string del2 = "delete from pstock where Regular=0 and BIS=0 and breackage=0";
                        cmd2.CommandText = del2;
                        cmd2.ExecuteNonQuery();
                        cmd2.Dispose();
                        Globals.msgbox(this, "Record Updated.");
                        grdProduction.Rows.Clear();
                        ClearMe();
                        btnList_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    // Attempt to roll back the transaction.
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        Globals.msgbox(this, ex2.Message); // rollback error
                    }
                    Globals.msgbox(this, ex.Message); // commited error
                }
                btnSave.Enabled = true;
            }
        }
            else
            {
                Globals.msgbox(this, "Please Select Any Item");
                Globals.msgbox(this, "Can't Save Zero Value Entry");
            }
        }
        private void ClearMe()
        {
            Globals.ClearAllFields(this);
            status = "add";
            usDesc.Enabled = true;
            usDesc.txt.Text = "";
            grdProduction.Rows.Clear();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            pList.Visible = true;
     //       usUnit.txt.Tag = "Text";            
            btnShow_Click(sender, e);
            grdProduction.Rows.Clear();
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
            //int i = 0; 
            //   sql = "select m.SNo,f.Item_Name,m.date,m.Qty,m.Breackage,m.ISI from v_manufacturing m,finished f where f.SNo=m.FNo and f.Item_Name like '%" + uSearch.txt.Text.Trim() + "%' order by f.Item_Name"; 
            //       sql = "Select SNo,Row_Number() over(order by Fname) as [S.No.],Fname as [Item Name],Date,Qty,Breackage,ISI from v_manufacturing where Fname like '%" + uSearch.txt.Text.Trim() + "%' order by Fname";
            sql1 = "select m.SNo,f.sno,f.Thickness,convert(varchar,m.date,102) as date,m.Qty,m.Breackage,m.ISI,m.regular from v_manufacturing m,finished f where m.FNo=f.SNo and m.date between '" + ucDateFrom.date.Value.ToString("yyyy-MM-dd") + "' and '"+ucDateTo.date.Value.ToString("yyyy-MM-dd")+ "' and f.Item_Name like '%" + uSearch.txt.Text.Trim() + "%' order by m.sno";
            cmd = new SqlCommand(sql1, Globals.con);
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
     //       gList.Columns[0].Visible = false;
            //gList.Columns[7].Visible = false;
            //gList.Columns[8].Visible = false;
            gList.Columns[0].Width = 100;
            gList.Columns[1].Width = 100;
            gList.Columns[1].Visible = false;
            gList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           // gList.Columns[8].Visible = false;
           // gList.Columns[9].Visible = false;
            gList.Columns[1].Width = 250;

        }
        private void gFormat1()
        {
       //     grdProduction.Columns[0].Visible = false;
            grdProduction.Columns[1].Visible = false;
            grdProduction.Columns[8].Visible = false;
            grdProduction.Columns[9].Visible = false;
            grdProduction.Columns[2].Visible = false;
            grdProduction.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdProduction.Columns[3].Width = 250;
            grdProduction.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdProduction.Columns[6].Width = 100;
            grdProduction.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdProduction.Columns[4].Width = 100;
            grdProduction.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdProduction.Columns[5].Width = 100;
        }
        private void gList_DoubleClick(object sender, EventArgs e)
        {
            if (gList.Rows.Count > 0 && CurrentRow >= 0)
            {
                pList.Visible = false;
                status = "edit";
                uctxtDno.txt.Text = gList.Rows[CurrentRow].Cells[0].Value.ToString();
                //  uctxtglist.txt.Text = gList.Rows[CurrentRow].Cells[0].Value.ToString();    
  //              uDate.date.Value = "";                                             
                PrevRec();
                uDate.Enabled = false;
              //  grdProduction.Focus();
                //btnRemove.Enabled = false;
                //   uDate.Focus();
            }
        }
        private void PrevRec()
        {
            sql = "";
                 sql = "Select * from v_manufacturing where SNo=" + val(uctxtDno.txt.Text) + "";
                 //SNo,Item_Name,Unit,Qty,Rate,HSNCODE,IGST,TCS
                 cmd = new SqlCommand(sql, Globals.con);
                 rd = cmd.ExecuteReader();
                 if (rd.Read())
                 {
                     uDate.date.Value = DateTime.Parse(rd["Date"].ToString());
                     uDate.date.Value = DateTime.Parse(rd["Date"].ToString());
            }
                 cmd.Dispose();
                 rd.Close(); 

            //sql = "Select SNo,Row_Number() over(order by Fname) as [S.No.],Fname as [Item Name],Date,Qty,Breackage,ISI from v_manufacturing SNo=" + val(uctxtDno.txt.Text) + " order by SNo";
            sql = "select m.SNo,m.SrNo,m.FNo as F_no,f.Thickness,m.date,m.Qty,m.Breackage,m.ISI,m.regular from v_manufacturing m,finished f where f.SNo=m.FNo and m.SNo='" + val(uctxtDno.txt.Text) + "' order by m.SrNo"; 
            cmd = new SqlCommand(sql, Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                grdProduction.Rows.Add(val(rd["SrNo"].ToString()), val(rd["SNo"].ToString()), val(rd["F_no"].ToString()), rd["Thickness"].ToString(), val(rd["Qty"].ToString()),  val(rd["Breackage"].ToString()),val(rd["ISI"].ToString()), val(rd["Regular"].ToString()));
            }
            cmd.Dispose();
            rd.Close();
            int r = grdProduction.Rows.Count;
            uctxtGrdProduction.txt.Text = r.ToString();
        }
        private void uSearch_TextChanged(object sender, EventArgs e)
        {
            //btnSave_Click(sender , e);
            dv.RowFilter = "[Thickness] like '%" + uSearch.txt.Text + "%'";
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
            //    uSearch.SearchEnterKey = true;
                gList_DoubleClick(sender, e);
                ucDateFrom.Focus();
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
            try
            {
                if (gList.Rows.Count > 0)
                {
                    CurrentRow = gList.CurrentRow.Index;
                }
            }
            catch (Exception ex)
            {
                CurrentRow = 0;
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
            try
            {
                if (gList.Rows.Count > 0)
                {
                    CurrentRow = gList.CurrentRow.Index;
                }
            }
            catch (Exception)
            {
                CurrentRow = 0;
            }
            if (e.KeyCode == Keys.Enter)
                gList_DoubleClick(sender, e);
            else if (e.Control && e.KeyCode == Keys.D && pList.Visible == true)
            {
                btnDelete_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.W && pList.Visible == true)
            {
                btnShow_Click(sender, e);
            }
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
                    string sql = "select * from v_manufacturing where date='" + gList.Rows[CurrentRow].Cells[3].Value.ToString().Trim() + "' and SNo='" + gList.Rows[CurrentRow].Cells[0].Value.ToString().Trim() + "'";
                    cmd.CommandText = sql;
                    rd1 = cmd.ExecuteReader();
                    while (rd1.Read())
                    {
                        if (uctxtdvno.txt.Text == "")
                        {
                            uctxtdvno.txt.Text = rd1["SNo"].ToString();
                        }
                        else
                        {
                            uctxtdvno.txt.Text = uctxtdvno.txt.Text + "," + rd1["SNo"].ToString();
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
                            uctxtdreg.txt.Text = rd1["Regular"].ToString();
                        }
                        else
                        {
                            uctxtdreg.txt.Text = uctxtdreg.txt.Text + "," + rd1["Regular"].ToString(); ;
                        }
                        if (uctxtdisi.txt.Text == "")
                        {
                            uctxtdisi.txt.Text = rd1["ISI"].ToString();
                        }
                        else
                        {
                            uctxtdisi.txt.Text = uctxtdisi.txt.Text + "," + rd1["ISI"].ToString(); ;
                        }
                        if (uctxtdbreackage.txt.Text == "")
                        {
                            uctxtdbreackage.txt.Text = rd1["Breackage"].ToString();
                        }
                        else
                        {
                            uctxtdbreackage.txt.Text = uctxtdbreackage.txt.Text + "," + rd1["Breackage"].ToString(); ;
                        }
                        
                    }
                    cmd.Dispose();
                    rd1.Close();
                    string vno = uctxtdvno.txt.Text;
                    string fno = uctxtdfno.txt.Text;
                    string reg = uctxtdreg.txt.Text;
                    string isi = uctxtdisi.txt.Text;
                    string breackage = uctxtdbreackage.txt.Text;                    
                    string[] att_vno = vno.Split(',');
                    string[] att_fno = fno.Split(',');
                    string[] att_reg = reg.Split(',');
                    string[] att_isi = isi.Split(',');
                    string[] att_breackage = breackage.Split(',');
                    for (int j = 0; j < att_fno.Length; j++)
                    {
                        double dvno = val(att_vno[j].ToString());
                        double dfno = val(att_fno[j].ToString());
                        double dreg = val(att_reg[j].ToString());
                        double disi = val(att_isi[j].ToString());
                        double dbreackage = val(att_breackage[j].ToString());                        
                        string sql2 = "update Pstock set Regular=Regular-" + dreg + ",BIS=BIS-" + disi + ",breackage=breackage-" + dbreackage + " where PDate='" + gList.Rows[CurrentRow].Cells[3].Value.ToString().Trim() + "' and FNo=" + dfno + "";
                        cmd.CommandText = sql2;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    Globals.DeleteRecord("v_manufacturing", gList.Rows[CurrentRow].Cells[0].Value);
                    sql = "Delete from consumption where SNo=" + gList.Rows[CurrentRow].Cells[0].Value;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    sql = "Delete from Pstock where Regular<=0 and BIS<=0 and Breackage<=0";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();                    
/*                    sql = "Delete from sales where sdate='" + gList.Rows[CurrentRow].Cells[3].Value.ToString().Trim() + "' and bill_no IS NULL";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();*/
                    transaction.Commit();
                    uctxtdvno.txt.Text = "";
                    uctxtdfno.txt.Text = "";
                    uctxtdreg.txt.Text = "";
                    uctxtdisi.txt.Text = "";
                    uctxtdbreackage.txt.Text = "";
                    btnShow_Click(sender, e);
                }
            }
        }

        private void gLis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gList.Rows.Count > 0)
                {
                    CurrentRow = gList.CurrentRow.Index;
                }
            }
            catch (Exception ex)
            {
                CurrentRow = 0;
            }
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
                //usGroup_Leave(sender, new EventArgs());
                uDate.Enabled = true;
                uDate.Focus();                            
            }
            else if (e.Control && e.KeyCode == Keys.S && pList.Visible == false)
            {
                btnSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2 && pList.Visible == false)
            {
                uctxtBrackage.txt.Text = "";
                usDesc.txt.Text = "";
                usDesc.txtCode.Text = "";
                uctxtQty.txt.Text = "";
                uctxtISI.txt.Text = "";
                btnSave.Focus();
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
                uDate.Enabled = true;
                uctxtQty.txt.Text = "";
                uctxtBrackage.txt.Text = "";
                uctxtISI.txt.Text = "";
                uctxtDno.txt.Text = Globals.MaxCode("v_manufacturing", "SNo").ToString();
            }
            else if (e.KeyCode == Keys.F5)
            {
                pList.Visible = false;
                ClearMe();
                uctxtQty.txt.Text = "";
                uctxtBrackage.txt.Text = "";
                uctxtISI.txt.Text = "";
                uDate.Enabled = true;

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
            Globals.LoadList(this, usDesc.lstName, "Select SNo,Thickness from finished order by Thickness");
        }

        private void button1_Click(object sender, EventArgs e)
        {
             /*            cmd = new SqlCommand("Select FinancialDate from m_company", Globals.con);
                        rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            ucFDate.date.Value = DateTime.Parse(rd["FinancialDate"].ToString());
                        }
                        cmd.Dispose();
                        rd.Close();

                        uctxtFno.txt.Text = usDesc.txtCode.Text;

                        cmd.Dispose();
                        rd.Close();

                        uctxtBIS.txt.Text = "0";
                        uctxtRegular.txt.Text = "0";
                        ucpreg.txt.Text = "0";
                        ucpisi.txt.Text = "0";
                        string M = "select max(Date) as md from v_manufacturing where fno=" + uctxtFno.txt.Text;
                        cmd = new SqlCommand(M, Globals.con);
                        rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {

                            if (rd["md"].ToString().Trim() != "")
                            {
                                ucDatemd.date.Value = DateTime.Parse(rd["md"].ToString());
                                uprev.date.Value = DateTime.Parse(rd["md"].ToString()).AddDays(-1);
                            }
                        }
                        cmd.Dispose();
                        rd.Close();

                        if (uDate.date.Value.ToString("yyyy-MM-dd") == ucDatemd.date.Value.ToString("yyyy-MM-dd"))
                        {
                            string prev = "select sum(vm.Total_Regular) as TRegprev from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uprev.date.Value.ToString("yyyy-MM-dd") + "'group by vm.date";
                            //string qryr = "select sum(vm.Total_Regular) as TRegular from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "' group by vm.date";
                            //cmd = new SqlCommand("select sum(vm.Regular) as TRegular from v_manufacturing vm left join finished f on vm.FNo = f.SNo where f.Item_name='" + usDesc.txt.Text + "'  and (" + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " <= '" + ].date.Value.ToString("yyyy-MM-dd") + "'", Globals.con);
                            cmd1 = new SqlCommand(prev, Globals.con);
                            rd1 = cmd1.ExecuteReader();
                            while (rd1.Read())
                            {
                                ucpreg.txt.Text = rd1["TRegprev"].ToString();
                            }
                            cmd1.Dispose();
                            rd1.Close();

            //                val(uctxtQty.txt.Text) - val(uctxtISI.txt.Text) - val(uctxtBrackage.txt.Text)
                            float q = float.Parse(uctxtQty.txt.Text);
                            float i = float.Parse(uctxtISI.txt.Text);
                            float b = float.Parse(uctxtBrackage.txt.Text);
                            uctxtRegular.txt.Text = (q-i-b).ToString();
                            float pre = float.Parse(uctxtRegular.txt.Text);
                            float cur = float.Parse(ucpreg.txt.Text);
                            uctxtRegular.txt.Text = (pre + cur).ToString();
                        }
                        else
                        {
                            string qry = "select sum(vm.Total_Regular) as TRegular from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "' group by vm.date";
                            cmd = new SqlCommand(qry, Globals.con);
                            rd = cmd.ExecuteReader();
                            while (rd.Read())
                            {
                                uctxtRegular.txt.Text = rd["TRegular"].ToString();
                            }
                            cmd.Dispose();
                            rd.Close();
                        }
                        if (uDate.date.Value.ToString("yyyy-MM-dd") == ucDatemd.date.Value.ToString("yyyy-MM-dd"))
                        {
                            string prev = "select sum(vm.Total_ISI) as TBISprev from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uprev.date.Value.ToString("yyyy-MM-dd") + "'group by vm.date";
                            cmd1 = new SqlCommand(prev, Globals.con);
                            rd1 = cmd1.ExecuteReader();
                            while (rd1.Read())
                            {
                                ucpisi.txt.Text = rd1["TBISprev"].ToString();
                            }
                            cmd1.Dispose();
                            rd1.Close();

                            float isi = float.Parse(uctxtISI.txt.Text);
                            float pre = float.Parse(uctxtBIS.txt.Text);
                            float cur = float.Parse(ucpisi.txt.Text);
                            uctxtBIS.txt.Text = (pre + cur + isi).ToString();
                        }
                        else
                        {
                            string qry2 = "select sum(vm.Total_ISI) as TBIS from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "'  group by vm.date";
                            cmd = new SqlCommand(qry2, Globals.con);
                            rd = cmd.ExecuteReader();
                            while (rd.Read())
                            {
                                uctxtBIS.txt.Text = rd["TBIS"].ToString();
                            }
                            cmd.Dispose();
                            rd.Close();

                        }*/
            /*       cmd = new SqlCommand("Select FinancialDate from m_company", Globals.con);
                   rd = cmd.ExecuteReader();
                   while (rd.Read())
                   {
                       ucFDate.date.Value = DateTime.Parse(rd["FinancialDate"].ToString());
                   }
                   cmd.Dispose();
                   rd.Close();

                   uctxtFno.txt.Text = usDesc.txtCode.Text;

                   cmd.Dispose();
                   rd.Close();

                   uctxtBIS.txt.Text = "0";
                   uctxtRegular.txt.Text = "0";
                   ucpreg.txt.Text = "0";
                   ucpisi.txt.Text = "0";
                   string M = "select max(Date) as md from v_manufacturing where fno=" + uctxtFno.txt.Text;
                   cmd = new SqlCommand(M, Globals.con);
                   rd = cmd.ExecuteReader();
                   if (rd.Read())
                   {

                       if (rd["md"].ToString().Trim() != "")
                       {
                           ucDatemd.date.Value = DateTime.Parse(rd["md"].ToString());
                           uprev.date.Value = DateTime.Parse(rd["md"].ToString()).AddDays(-1);
                       }
                   }
                   cmd.Dispose();
                   rd.Close();

                   if (uDate.date.Value.ToString("yyyy-MM-dd") == ucDatemd.date.Value.ToString("yyyy-MM-dd"))
                   {
                       string prev = "select sum(vm.Total_Regular) as TRegprev from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uprev.date.Value.ToString("yyyy-MM-dd") + "'group by vm.date";
                       string qryr = "select sum(vm.Total_Regular) as TRegular from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and SNo<'" + uctxtSNo.txt.Text +"'  and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0))='" + ucDatemd.date.Value.ToString("yyyy-MM-dd") + "'  group by vm.Date";
                       //string qryr = "select sum(vm.Total_Regular) as TRegular from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "' group by vm.date";
                       //cmd = new SqlCommand("select sum(vm.Regular) as TRegular from v_manufacturing vm left join finished f on vm.FNo = f.SNo where f.Item_name='" + usDesc.txt.Text + "'  and (" + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "'", Globals.con);
                       cmd1 = new SqlCommand(prev, Globals.con);
                       rd1 = cmd1.ExecuteReader();
                       while (rd1.Read())
                       {
                           ucpreg.txt.Text = rd1["TRegprev"].ToString();
                       }
                       cmd1.Dispose();
                       rd1.Close();

                       cmd2 = new SqlCommand(qryr, Globals.con);
                       rd2 = cmd2.ExecuteReader();
                       while (rd2.Read())
                       {
                           uctxtRegular.txt.Text = rd2["TRegular"].ToString();
                           if(uctxtRegular.txt.Text == "")
                           {
                               uctxtRegular.txt.Text = "0";
                           }
                       }
                       cmd2.Dispose();
                       rd2.Close();

                       float pre = float.Parse(uctxtRegular.txt.Text);
                       float cur = float.Parse(ucpreg.txt.Text);
                       uctxtRegular.txt.Text = (pre + cur).ToString();
                   }
                   else
                   {
                       string qry = "select sum(vm.Total_Regular) as TRegular from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "' group by vm.date";
                       cmd = new SqlCommand(qry, Globals.con);
                       rd = cmd.ExecuteReader();
                       while (rd.Read())
                       {
                           uctxtRegular.txt.Text = rd["TRegular"].ToString();
                       }
                       cmd.Dispose();
                       rd.Close();
                   }
                   if (uDate.date.Value.ToString("yyyy-MM-dd") == ucDatemd.date.Value.ToString("yyyy-MM-dd"))
                   {
                       string prev = "select sum(vm.Total_ISI) as TBISprev from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uprev.date.Value.ToString("yyyy-MM-dd") + "'group by vm.date";
                       string qryr = "select sum(vm.Total_ISI) as TBIS from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and SNo<'" + uctxtSNo.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0))='" + ucDatemd.date.Value.ToString("yyyy-MM-dd") + "'";
                       cmd1 = new SqlCommand(prev, Globals.con);
                       rd1 = cmd1.ExecuteReader();
                       while (rd1.Read())
                       {
                           ucpisi.txt.Text = rd1["TBISprev"].ToString();
                       }
                       cmd1.Dispose();
                       rd1.Close();

                       cmd2 = new SqlCommand(qryr, Globals.con);
                       rd2 = cmd2.ExecuteReader();
                       while (rd2.Read())
                       {
                           uctxtBIS.txt.Text = rd2["TBIS"].ToString();

                       }
                       cmd2.Dispose();
                       rd2.Close();

                       float pre = float.Parse(uctxtBIS.txt.Text);
                       float cur = float.Parse(ucpisi.txt.Text);
                             uctxtBIS.txt.Text = (pre + cur).ToString();
                   }
                   else
                   {
                       string qry2 = "select sum(vm.Total_ISI) as TBIS from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "'  group by vm.date";
                       cmd = new SqlCommand(qry2, Globals.con);
                       rd = cmd.ExecuteReader();
                       while (rd.Read())
                       {
                           uctxtBIS.txt.Text = rd["TBIS"].ToString();
                       }
                       cmd.Dispose();
                       rd.Close();

                   }*/
            
            if (val(uctxtQty.txt.Text)!=0)
            {
                if (status1 == "add")
                {
                    if (uDate.Enabled != false)
                    {
                        uctxtDno.txt.Text = Globals.MaxCode("v_manufacturing", "SNo").ToString();
                    }
                    grdProduction.Rows.Add(grdProduction.Rows.Count + 1, val(uctxtDno.txt.Text), val(uctxtFno.txt.Text), usDesc.txt.Text, val(uctxtQty.txt.Text), val(uctxtBrackage.txt.Text), val(uctxtISI.txt.Text), val(uctxtQty.txt.Text) - val(uctxtISI.txt.Text) - val(uctxtBrackage.txt.Text));
                    AutoNumber();
                }
                else
                {
                    NPstock.txt.Text = Globals.MaxCode("NPstock", "SNo").ToString();
                    int vn = int.Parse(uctxtDno.txt.Text);
                    int np = int.Parse(NPstock.txt.Text);
                                 
                    sql = "insert into NPstock(SNo,SrNo,Vtype,Sdate,FNo,VNo,Regular,BIS,Breackage) values("
                   + val(np)
                   + "," + val(uctxtSrNo.txt.Text)
                   + ",'Updation"
                   + "','" + uDate.date.Value.ToString("yyyy-MM-dd")
                   + "'," + val(uctxttbfno.txt.Text)
                    + "," + val(uctxtDno.txt.Text)
                   + "," + val(uctxttbreg.txt.Text)
                   + "," + val(uctxttbBIS.txt.Text)
                   + "," + val(uctxttbbreackage.txt.Text) + ")";
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
                     
                    grdProduction.Rows[grdProduction.CurrentCell.RowIndex].Cells[0].Value = val(uctxtSN.txt.Text);
                    grdProduction.Rows[grdProduction.CurrentCell.RowIndex].Cells[2].Value = val(uctxtFno.txt.Text);
                    grdProduction.Rows[grdProduction.CurrentCell.RowIndex].Cells[3].Value = usDesc.txt.Text;
                    grdProduction.Rows[grdProduction.CurrentCell.RowIndex].Cells[4].Value = val(uctxtQty.txt.Text);
                    grdProduction.Rows[grdProduction.CurrentCell.RowIndex].Cells[5].Value = val(uctxtBrackage.txt.Text);
                    grdProduction.Rows[grdProduction.CurrentCell.RowIndex].Cells[6].Value = val(uctxtISI.txt.Text);
                    grdProduction.Rows[grdProduction.CurrentCell.RowIndex].Cells[7].Value = val(uctxtQty.txt.Text) - val(uctxtISI.txt.Text) - val(uctxtBrackage.txt.Text);            
                    }
                int ii = 0;
                for (int i = 0; i < grdProduction.Rows.Count; ++i)
                {
                    ii = i;
                }
                uctxtRcount.txt.Text = (ii + 1).ToString();
                status1 = "add";
                usDesc.txt.Text = "";
                uctxtQty.txt.Text = "";
                uctxtBrackage.txt.Text = "";
                uctxtISI.txt.Text = "";
                usDesc.Focus();
            }            
            else
            {
                Globals.msgbox(this, "Something Missing");
                usDesc.Focus();
            }
        }
        private void AutoNumber()
        {
            for (int i = 0; i < grdProduction.Rows.Count; i++)
            {
                grdProduction.Rows[i].Cells[0].Value = i + 1;
                /*                if ((grdPayList.Rows[i].Cells[2].Value.ToString().Contains("Adv") || grdPayList.Rows[i].Cells[2].Value.ToString().Contains("Advance")) && lblGuarantor.Visible == false)
                                {
                                    lblGuarantor.Visible = true;
                                    usGuarantor.Visible = true;
                                    LoadGuarantor();
                                }*/
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (uDate.Enabled == true)
                {
                    grdProduction.Rows.RemoveAt(grdProduction.CurrentRow.Index);
                    AutoNumber();
                }
                else if (uDate.Enabled == false && uctxtSrNo1.txt.Text != "")  //
                {
                    RNPstock.txt.Text = Globals.MaxCode("RNPstock", "SNo").ToString();
                    int vn = int.Parse(uctxtDno.txt.Text);
                    sql = "insert into RNPstock(SNo,SrNo,Vtype,Sdate,FNo,VNo,Regular,BIS,Breackage) values("
                   + val(RNPstock.txt.Text)
                   + "," + val(uctxtSrNo1.txt.Text)
                   + ",'Updation"
                   + "','" + uDate.date.Value.ToString("yyyy-MM-dd")
                   + "'," + val(uctxttbfno1.txt.Text)
                    + "," + vn
                   + "," + val(uctxttbreg1.txt.Text)
                   + "," + val(uctxttbBIS1.txt.Text)
                   + "," + val(uctxttbbreackage1.txt.Text) + ")";
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
                    grdProduction.Rows.RemoveAt(grdProduction.CurrentRow.Index);
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
                grdProduction.Rows.Clear();
            }
        }

        private void frmProduction_Activated(object sender, EventArgs e)
        {
            
        }

        private void uctxtBrackage_Leave(object sender, EventArgs e)
        {
            if(uctxtBrackage.txt.Text=="")
            {
                uctxtBrackage.txt.Text = "0";
            }
        }

        private void uctxtISI_Leave(object sender, EventArgs e)
        {
            if (uctxtISI.txt.Text == "")
            {
                uctxtISI.txt.Text = "0";
            }
        }

        private void grdProduction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = grdProduction.CurrentCell.RowIndex;
            uctxttbfno.txt.Text = grdProduction.Rows[row].Cells[2].Value.ToString();
            uctxtSrNo1.txt.Text = grdProduction.Rows[row].Cells[0].Value.ToString();
            uctxttbreg1.txt.Text = grdProduction.Rows[row].Cells[7].Value.ToString();
            uctxttbBIS1.txt.Text = grdProduction.Rows[row].Cells[6].Value.ToString();
            uctxttbbreackage1.txt.Text = grdProduction.Rows[row].Cells[5].Value.ToString();           
            uctxttbfno1.txt.Text = grdProduction.Rows[row].Cells[2].Value.ToString();
        }

        private void uctxtBrackage_Load(object sender, EventArgs e)
        {

        }

        private void uctxtQty_Leave(object sender, EventArgs e)
        {
            if(uctxtQty.txt.Text =="")
            {
                uctxtQty.txt.Text = "0";
            }
        }

        private void grdProduction_Click(object sender, EventArgs e)
        {
            
        }

        private void grdProduction_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (gList.Rows.Count > 0)
                {
                    CurrentRow = gList.CurrentRow.Index;
                }
            }
            catch (Exception)
            {
                CurrentRow = 0;
            }
            if (e.KeyCode == Keys.Enter)
            {
                int row = grdProduction.CurrentCell.RowIndex;
                uctxttbBIS.txt.Text = "";
                uctxttbreg.txt.Text = "";
                uctxttbbreackage.txt.Text = "";
                uctxtSN.txt.Text = grdProduction.Rows[row].Cells[0].Value.ToString();
                uctxtDno.txt.Text = grdProduction.Rows[row].Cells[1].Value.ToString();
                uctxtFno.txt.Text = grdProduction.Rows[row].Cells[2].Value.ToString();
                uctxttbfno.txt.Text = grdProduction.Rows[row].Cells[2].Value.ToString();
                uctxttbfno1.txt.Text = grdProduction.Rows[row].Cells[2].Value.ToString();
                usDesc.txt.Text = grdProduction.Rows[row].Cells[3].Value.ToString();
                uctxttbreg.txt.Text = grdProduction.Rows[row].Cells[7].Value.ToString();
                uctxttbreg1.txt.Text = grdProduction.Rows[row].Cells[7].Value.ToString();
                uctxttbBIS.txt.Text = grdProduction.Rows[row].Cells[6].Value.ToString();
                uctxttbBIS1.txt.Text = grdProduction.Rows[row].Cells[6].Value.ToString();
                uctxttbbreackage.txt.Text = grdProduction.Rows[row].Cells[5].Value.ToString();
                uctxttbbreackage1.txt.Text = grdProduction.Rows[row].Cells[5].Value.ToString();
                uctxtSrNo.txt.Text = grdProduction.Rows[row].Cells[0].Value.ToString();
                uctxtSrNo1.txt.Text = grdProduction.Rows[row].Cells[0].Value.ToString();
                uctxtQty.txt.Text = grdProduction.Rows[row].Cells[4].Value.ToString();
                uctxtBrackage.txt.Text = grdProduction.Rows[row].Cells[5].Value.ToString();
                uctxtISI.txt.Text = grdProduction.Rows[row].Cells[6].Value.ToString();
                status1 = "edit";
                usDesc.Focus();
               }
            
            else if (e.KeyCode == Keys.Left)
            {
                usDesc.Focus();
            }            
        }

        private void gList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gList.Rows.Count > 0)
                {
                    CurrentRow = gList.CurrentRow.Index;
                }
            }
            catch (Exception)
            {
                CurrentRow = 0;
            }
        }

        private void gList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gList.Rows.Count > 0)
                {
                    CurrentRow = gList.CurrentRow.Index;
                }
            }
            catch (Exception ex)
            {
                CurrentRow = 0;
            }
        }

        private void grdProduction_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gList.Rows.Count > 0)
                {
                    CurrentRow = gList.CurrentRow.Index;
                }
            }
            catch (Exception)
            {
                CurrentRow = 0;
            }
        }

        private void grdProduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void grdProduction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pbase_Paint(object sender, PaintEventArgs e)
        {

        }

        private void usDesc_Leave(object sender, EventArgs e)
        {
            
/*            cmd = new SqlCommand("Select FinancialDate from m_company", Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                ucFDate.date.Value = DateTime.Parse(rd["FinancialDate"].ToString());
            }
            cmd.Dispose();
            rd.Close();*/            
            uctxtFno.txt.Text = usDesc.txtCode.Text;
/*            
            cmd.Dispose();
            rd.Close();

            uctxtBIS.txt.Text = "0";
            uctxtRegular.txt.Text = "0";
            ucpreg.txt.Text = "0";
            ucpisi.txt.Text = "0";
            string M = "select max(Date) as md from v_manufacturing where fno=" +uctxtFno.txt.Text;
            cmd = new SqlCommand(M, Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read() )
            {
                
                if(rd["md"].ToString().Trim()!="")
                 {
                    ucDatemd.date.Value = DateTime.Parse(rd["md"].ToString());
                    uprev.date.Value = DateTime.Parse(rd["md"].ToString()).AddDays(-1);
                }
            }
            cmd.Dispose();
            rd.Close();

            if (uDate.date.Value.ToString("yyyy-MM-dd") == ucDatemd.date.Value.ToString("yyyy-MM-dd"))
                {
                    string prev = "select sum(vm.Total_Regular) as TRegprev from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uprev.date.Value.ToString("yyyy-MM-dd") + "'group by vm.date";                    
                    string qryr = "select sum(vm.Total_Regular) as TRegular from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0))='" + ucDatemd.date.Value.ToString("yyyy-MM-dd") + "' group by vm.Date";
                    //string qryr = "select sum(vm.Total_Regular) as TRegular from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "' group by vm.date";
                    //cmd = new SqlCommand("select sum(vm.Regular) as TRegular from v_manufacturing vm left join finished f on vm.FNo = f.SNo where f.Item_name='" + usDesc.txt.Text + "'  and (" + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "'", Globals.con);
                    cmd1 = new SqlCommand(prev, Globals.con);
                    rd1 = cmd1.ExecuteReader();
                    while (rd1.Read())
                    {
                        ucpreg.txt.Text = rd1["TRegprev"].ToString();
                    }
                    cmd1.Dispose();
                    rd1.Close();

                    cmd2 = new SqlCommand(qryr, Globals.con);
                    rd2 = cmd2.ExecuteReader();
                    while (rd2.Read())
                    {
                        uctxtRegular.txt.Text = rd2["TRegular"].ToString();
                    }
                    cmd2.Dispose();
                    rd2.Close();

                    float pre = float.Parse(uctxtRegular.txt.Text);
                    float cur = float.Parse(ucpreg.txt.Text);
            //        uctxtRegular.txt.Text = (pre + cur).ToString();
                }
                else
                {
                    string qry = "select sum(vm.Total_Regular) as TRegular from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "' group by vm.date";
                    cmd = new SqlCommand(qry, Globals.con);
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        uctxtRegular.txt.Text = rd["TRegular"].ToString();
                    }
                    cmd.Dispose();
                    rd.Close();
                }
                    if (uDate.date.Value.ToString("yyyy-MM-dd") == ucDatemd.date.Value.ToString("yyyy-MM-dd"))
                    {
                    string prev = "select sum(vm.Total_ISI) as TBISprev from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uprev.date.Value.ToString("yyyy-MM-dd") + "'group by vm.date";
                    string qryr = "select sum(vm.Total_ISI) as TBIS from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0))='" + ucDatemd.date.Value.ToString("yyyy-MM-dd") + "'";
                    cmd1 = new SqlCommand(prev, Globals.con);
                        rd1 = cmd1.ExecuteReader();
                        while (rd1.Read())
                        {
                            ucpisi.txt.Text = rd1["TBISprev"].ToString();
                        }
                        cmd1.Dispose();
                        rd1.Close();

                    cmd2 = new SqlCommand(qryr, Globals.con);
                    rd2 = cmd2.ExecuteReader();
                    while (rd2.Read())
                    {
                        uctxtBIS.txt.Text = rd2["TBIS"].ToString();
                    }
                    cmd2.Dispose();
                    rd2.Close();

                    float pre = float.Parse(uctxtBIS.txt.Text);
                    float cur = float.Parse(ucpisi.txt.Text);
              //      uctxtBIS.txt.Text = (pre + cur).ToString();
                }            
                    else
                    {
                    string qry2 = "select sum(vm.Total_ISI) as TBIS from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "'  group by vm.date";
                    cmd = new SqlCommand(qry2, Globals.con);
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        uctxtBIS.txt.Text = rd["TBIS"].ToString();
                    }
                    cmd.Dispose();
                    rd.Close();

                }                
                        

/*            string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0))";
            string qry2 = "select sum(vm.Regular) as TRegular from v_manufacturing vm left join finished f on vm.FNo = f.SNo where  (" + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "'" + " and f.Item_name='" + usDesc.txt.Text + "'";
            string qry = "select sum(vm.Total_Regular) as TRegular from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between'" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "' group by vm.date";
            cmd = new SqlCommand("select sum(vm.Regular) as TRegular from v_manufacturing vm left join finished f on vm.FNo = f.SNo where f.Item_name='" + usDesc.txt.Text + "'  and (" + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " <= '" + uDate.date.Value.ToString("yyyy-MM-dd") + "'", Globals.con);
            cmd = new SqlCommand(qry, Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                uctxtRegular.txt.Text = rd["TRegular"].ToString();
            }
            cmd.Dispose();
            rd.Close();

            string qry2 = "select sum(vm.Total_ISI) as TBIS from v_manufacturing vm where vm.FNo='" + uctxtFno.txt.Text + "' and (DATEADD(DAY, DATEDIFF(day, 0, vm.Date), 0)) between '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and '" + uDate.date.Value.ToString("yyyy-MM-dd") + "'  group by vm.date";
            cmd = new SqlCommand(qry2, Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                uctxtBIS.txt.Text = rd["TBIS"].ToString();
            }
            cmd.Dispose();
            rd.Close();*/
        }

        private void grdProduction_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = grdProduction.CurrentCell.RowIndex;
            uctxttbBIS.txt.Text = "";
            uctxttbreg.txt.Text = "";
            uctxttbbreackage.txt.Text = "";
            uctxtSN.txt.Text = grdProduction.Rows[row].Cells[0].Value.ToString();
            uctxtDno.txt.Text= grdProduction.Rows[row].Cells[1].Value.ToString();
            uctxtFno.txt.Text = grdProduction.Rows[row].Cells[2].Value.ToString();
            uctxttbfno.txt.Text = grdProduction.Rows[row].Cells[2].Value.ToString();
            uctxttbfno1.txt.Text = grdProduction.Rows[row].Cells[2].Value.ToString();
            usDesc.txt.Text = grdProduction.Rows[row].Cells[3].Value.ToString();
            uctxttbreg.txt.Text = grdProduction.Rows[row].Cells[7].Value.ToString();
            uctxttbreg1.txt.Text = grdProduction.Rows[row].Cells[7].Value.ToString();
            uctxttbBIS.txt.Text = grdProduction.Rows[row].Cells[6].Value.ToString();
            uctxttbBIS1.txt.Text = grdProduction.Rows[row].Cells[6].Value.ToString();
            uctxttbbreackage.txt.Text = grdProduction.Rows[row].Cells[5].Value.ToString();
            uctxttbbreackage1.txt.Text = grdProduction.Rows[row].Cells[5].Value.ToString();
            uctxtSrNo.txt.Text = grdProduction.Rows[row].Cells[0].Value.ToString();
            uctxtSrNo1.txt.Text = grdProduction.Rows[row].Cells[0].Value.ToString();
            uctxtQty.txt.Text = grdProduction.Rows[row].Cells[4].Value.ToString();
            uctxtBrackage.txt.Text = grdProduction.Rows[row].Cells[5].Value.ToString();
            uctxtISI.txt.Text = grdProduction.Rows[row].Cells[6].Value.ToString();
            status1 = "edit";
            usDesc.Focus();
        }

        private void ucSearchList1_Load(object sender, EventArgs e)
        {

        }

        private void uSearchISI_TextChanged(object sender, EventArgs e)
        {
        /*    //btnSave_Click(sender , e);
            dv.RowFilter = "[ISI] like '%" + uSearchISI.txt.Text + "%'";
            gList.DataSource = dv;
            if (gList.Rows.Count > 0)
            {
                CurrentRow = 0;
                gList.Rows[CurrentRow].Selected = true;
            }*/
        }

        private void grdProduction_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void ucDateFrom_Leave(object sender, EventArgs e)
        {

        }
    }
}
