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
    public partial class frmPurchase : Form
    {
        string CompanyStateCode = "";
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
        SqlCommand cmd;
        SqlDataReader rd;
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
        public frmPurchase()
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
        private void frmUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && pList.Visible == false)
            {
                this.Dispose();
            }
            else if (e.KeyCode == Keys.Escape && pList.Visible == true)
            {
                pList.Visible = false;
                ucRecDate.Focus();
            }
            else if (e.Control && e.KeyCode == Keys.S && pList.Visible == false)
            {
                btnSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2 && pList.Visible == false)
            {
                uctxtTCS.Focus();
                usRaw.txt.Text = "";
                usRaw.txtCode.Text = "";
                uctxtQty.txt.Text = "";
                uctxtRate.txt.Text = "";
                uctxtHSN.txt.Text = "";               
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
            else if (e.KeyCode == Keys.F3 && pList.Visible == false)
            {
                frmParty f = new frmParty(this);
                f.Show(this);
            }          
            else if (e.KeyCode == Keys.F5)
            {
                pList.Visible = false;
                ClearMe();                            
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
        private void frmUnit_Load(object sender, EventArgs e)
        {            
            uctxtHSN.txt.ReadOnly = true;
            uctxtGSTIN.txt.ReadOnly = true;
            uctxtCGST.txt.ReadOnly = true;
            uctxtIGST.txt.ReadOnly = true;
            uctxtSGST.txt.ReadOnly = true;
            uctxtCess.txt.ReadOnly = true;
            uctxtStkAbl.txt.ReadOnly = true;
            uctxtSubTotal.txt.ReadOnly = true;
            uctxtGrandTotal.txt.ReadOnly = true;
            uTotalQty.txt.ReadOnly = true;

            uctxtInvNo.txt.Tag = "Text";
            uctxtFreight.txt.Tag = "Number";
            uctxtInsurance.txt.Tag = "Number";
            uctxtTCS.txt.Tag = "Number";
            uctxtOtherCharges.txt.Tag = "Number";          
            uctxtQty.txt.Tag = "Number";
            uctxtRate.txt.Tag = "Number";
            uctxtGrandTotal.txt.Tag = "Amount";
            uctxtGrandTotal.txt.ForeColor = Color.Red;

            frmMain frm = new frmMain();
            int ht = btnSave.Top - (usSupplier.Top + usSupplier.Height);
            usSupplier.txt.Tag = "SearchList,AutoHeight:false,Height:" + ht + ",";            


            gFormat1();

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

            ClearMe();

            cmd = new SqlCommand("Select sno,StateCode from m_company where sno=1", Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                CompanyStateCode = rd["StateCode"].ToString();
                uctxtCompanyStateCode.txt.Text = rd["StateCode"].ToString();
            }
            cmd.Dispose();
            rd.Close();
        }

        private void frmUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                if (grdPurchase.Rows.Count <= 0)
                {
                    Globals.msgbox(this, "Please Enter Any Item."); usRaw.Focus(); return;
                }  
                using (SqlConnection con = new SqlConnection(Globals.iniConnectionString))
                {
                    con.Open();
                    SqlTransaction transaction;
                    transaction = con.BeginTransaction();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.Connection = con;
                    cmd.Transaction = transaction;
                    SqlDataReader rd;
                    //           try
                    //           {
                    btnSave.Enabled = false;
                    if (status == "add")
                    {
                        uctxtVno.txt.Text = Globals.MaxCode("v_purchase", "VNo").ToString();

                        if (uctxtInvNo.txt.Text.Trim() == "")
                        {
                            uctxtInvNo.txt.Text = uctxtVno.txt.Text;
                        }

                        CalcTotal();

                        for (int i = 0; i < grdPurchase.Rows.Count; ++i)
                        {
                            sql = "insert into v_purchase(SNo,VNo,RDate,Invoice_no,Inv_date,SrNo,consignee,RNo,Rate,Qty,Value,CGST,SGST,IGST,Cess,TCS,Freight,Transit_Insurance,Other_Charges,Total) values ("
                            + (i + 1)
                            + "," + val(uctxtVno.txt.Text)
                            + ",'" + ucRecDate.date.Value.ToString("yyyy-MM-dd")
                            + "','" + uctxtInvNo.txt.Text
                            + "','" + ucInvDate.date.Value.ToString("yyyy-MM-dd")
                            + "','" + uctxtPartyNo.txt.Text
                            + "','" + uctxtConsigner.txt.Text
                            + "'," + int.Parse(grdPurchase.Rows[i].Cells[2].Value.ToString().Trim())
                            + "," + float.Parse(grdPurchase.Rows[i].Cells[5].Value.ToString().Trim())
                            + "," + float.Parse(grdPurchase.Rows[i].Cells[4].Value.ToString().Trim())
                            + "," + float.Parse(grdPurchase.Rows[i].Cells[6].Value.ToString().Trim())
                            + "," + float.Parse(grdPurchase.Rows[i].Cells[7].Value.ToString().Trim())
                            + "," + float.Parse(grdPurchase.Rows[i].Cells[8].Value.ToString().Trim())
                            + "," + float.Parse(grdPurchase.Rows[i].Cells[10].Value.ToString().Trim())
                            + "," + float.Parse(grdPurchase.Rows[i].Cells[9].Value.ToString().Trim())
                            + "," + val(uctxtTCS.txt.Text)
                            + "," + val(uctxtFreight.txt.Text)
                            + "," + val(uctxtInsurance.txt.Text)
                            + "," + val(uctxtOtherCharges.txt.Text)
                            + "," + val(uctxtGrandTotal.txt.Text) + ")";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                        sql = "insert into trans_1(SNo,Inv_No,Vtype,VDate,PartySNo,NetTotal,TaxableAmount,cgst,sgst,igst) values ("
                            + val(uctxtVno.txt.Text)
                            + ",'" + uctxtInvNo.txt.Text
                            + "','purchase"
                            + "','" + ucInvDate.date.Value.ToString("yyyy-MM-dd")
                            + "'," + val(uctxtPartyNo.txt.Text)
                            + "," + val(uctxtGrandTotal.txt.Text)
                            + "," + val(uctxtSubTotal.txt.Text)
                            + "," + val(uctxtCGST.txt.Text)
                            + "," + val(uctxtSGST.txt.Text)
                            + "," + val(uctxtIGST.txt.Text) + ")";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        Globals.msgbox(this, "Record Saved.");
                        ClearMe();
                        grdPurchase.Rows.Clear();
                        ucRecDate.Focus();
                    }
                    else // -----update-----
                    {
                        CalcTotal();

                        sql = "delete from v_purchase where VNo=" + val(uctxtVno.txt.Text) + "";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        sql = "delete from trans_1 where VType='purchase' and SNo=" + val(uctxtVno.txt.Text) + "";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        long sno = long.Parse(uctxtVno.txt.Text);

                        for (int i = 0; i < grdPurchase.Rows.Count; ++i)
                        {
                            sql = "";
                            sql = "insert into v_purchase(SNo,VNo,Vtype,RDate,Invoice_no,Inv_date,SrNo,consignee,RNo,Rate,Qty,Value,CGST,SGST,IGST,Cess,TCS,Freight,Transit_Insurance,Other_Charges,Total) values("
                                + (i + 1)
                                + "," + sno
                                + ",'purchase"
                                + "','" + ucRecDate.date.Value.ToString("yyyy-MM-dd")
                                + "','" + uctxtInvNo.txt.Text
                                + "','" + ucInvDate.date.Value.ToString("yyyy-MM-dd")
                                + "'," + val(uctxtPartyNo.txt.Text)
                                + ",'" + uctxtConsigner.txt.Text
                                + "'," + int.Parse(grdPurchase.Rows[i].Cells[2].Value.ToString().Trim())
                                + "," + float.Parse(grdPurchase.Rows[i].Cells[5].Value.ToString().Trim())
                                + "," + float.Parse(grdPurchase.Rows[i].Cells[4].Value.ToString().Trim())
                                + "," + float.Parse(grdPurchase.Rows[i].Cells[6].Value.ToString().Trim())
                                + "," + float.Parse(grdPurchase.Rows[i].Cells[7].Value.ToString().Trim())
                                + "," + float.Parse(grdPurchase.Rows[i].Cells[8].Value.ToString().Trim())
                                + "," + float.Parse(grdPurchase.Rows[i].Cells[10].Value.ToString().Trim())
                                + "," + float.Parse(grdPurchase.Rows[i].Cells[9].Value.ToString().Trim())
                                + "," + val(uctxtTCS.txt.Text)
                                + "," + val(uctxtFreight.txt.Text)
                                + "," + val(uctxtInsurance.txt.Text)
                                + "," + val(uctxtOtherCharges.txt.Text)
                                + "," + val(uctxtGrandTotal.txt.Text) + ")";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                        sql = "insert into trans_1(SNo,Inv_No,Vtype,VDate,PartySNo,NetTotal,TaxableAmount) values("
                        + sno
                        + "," + val(uctxtInvNo.txt.Text)
                        + ",'purchase"
                        + "','" + ucInvDate.date.Value.ToString("yyyy-MM-dd")
                        + "'," + val(uctxtPartyNo.txt.Text)
                        + "," + val(uctxtGrandTotal.txt.Text)
                        + "," + val(uctxtSubTotal.txt.Text) + ")";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                        Globals.msgbox(this, "Record Updated.");
                        grdPurchase.Rows.Clear();
                        ClearMe();
                        btnList_Click(sender, e);
                    }
              }

            btnSave.Enabled = true;
        }

        private void ClearMe()
        {
            Globals.ClearAllFields(this);
            status = "add";
            status1 = "add";
            // Allow to changes below control value
            usSupplier.Enabled = true;
            usSupplier.txt.Text = "";
            usSupplier.txtCode.Text = "0";
            usRaw.txt.Text = "";
            usRaw.txtCode.Text = "0";
            uctxtCompanyStateCode.txt.Text = CompanyStateCode;
            grdPurchase.Rows.Clear();
            ucInvDate.Focus();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            pList.Visible = true;
     //       usUnit.txt.Tag = "Text";
            btnShow_Click(sender, e);
            grdPurchase.Rows.Clear();
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
            sql1 = "select t.Inv_No as [Invoice No],t.VDate,p.SName as [Party Name],t.NetTotal,t.SNo from m_party p,trans_1 t where p.Stype='supplier' and t.PartySNo=p.SNo and t.VType='purchase' and t.Inv_No like'%" + uSearch.txt.Text.Trim() + "%' and t.VDate between '"+ucDateFrom.date.Value.ToString("yyyy-MM-dd") + "' and '"+ucDateTo.date.Value.ToString("yyyy-MM-dd") + "' order by t.Inv_No asc";
            cmd = new SqlCommand(sql1, Globals.con);
            //rd = cmd.ExecuteReader();
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
            uSearch.Focus();
        }
        private void gFormat()
        {
            gList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[0].Width = 100;

            gList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[1].Width = 100;

            gList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[3].Width = 100;

            gList.Columns[4].Visible = false;

        }
        private void gFormat1()
        {
            grdPurchase.Columns[0].Visible = false;
            grdPurchase.Columns[1].Visible = false;
            grdPurchase.Columns[2].Visible = false;
            grdPurchase.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPurchase.Columns[2].Width = 250;
            grdPurchase.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPurchase.Columns[3].Width = 200;
            grdPurchase.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPurchase.Columns[4].Width = 150;
            grdPurchase.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPurchase.Columns[5].Width = 100;
            grdPurchase.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPurchase.Columns[6].Width = 150;
            grdPurchase.Columns[7].Visible = false;
            grdPurchase.Columns[8].Visible = false;
            grdPurchase.Columns[9].Visible = false;
            grdPurchase.Columns[10].Visible = false;
        }
        private void gList_DoubleClick(object sender, EventArgs e)
        {
            if (gList.Rows.Count > 0 && CurrentRow >= 0)
            {
                pList.Visible = false;
                status = "edit";
                uctxtVno.txt.Text = gList.Rows[CurrentRow].Cells[4].Value.ToString();
                uctxtInvNo.txt.Text = gList.Rows[CurrentRow].Cells[0].Value.ToString();
                uctxtSNo.txt.Text = "1";

                PrevRec();
                CalcTotal();
                usSupplier.Enabled = false;
                ucInvDate.Focus();
            }
        }
        private void PrevRec()
        {
            sql = "select v.*,p.SName,p.StateCode,p.GSTIN,r.Item_Name from v_purchase v left join m_party p on v.SrNo=p.SNo left join m_raw r on v.RNo=r.SNo where v.VNo=" + (uctxtVno.txt.Text)+ "";
            cmd = new SqlCommand(sql, Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
//              uDate.date.Value = DateTime.Parse(rd["vdate"].ToString());
                usSupplier.txt.Text = rd["SName"].ToString();
                usSupplier.txtCode.Text = rd["SrNo"].ToString();
                uctxtPartyStateCode.txt.Text = rd["StateCode"].ToString();
                uctxtGSTIN.txt.Text = rd["GSTIN"].ToString();
                ucRecDate.date.Value = DateTime.Parse(rd["RDate"].ToString());
                //uctxtInvNo.txt.Text = rd["Invoice_No"].ToString();
                ucInvDate.date.Value = DateTime.Parse(rd["Inv_date"].ToString());
                uctxtConsigner.txt.Text = rd["consignee"].ToString();
                uctxtPartyNo.txt.Text = rd["SrNo"].ToString();
                usRaw.txt.Text = "";// rd["Item_Name"].ToString();
                usRaw.txtCode.Text = "0";// rd["Item_Code"].ToString();
                //uctxtQty.txt.Text = rd["Qty"].ToString();
                uctxtTCS.txt.Text = rd["TCS"].ToString();
                uctxtFreight.txt.Text = rd["Freight"].ToString();
                uctxtInsurance.txt.Text = rd["Transit_Insurance"].ToString();
                uctxtOtherCharges.txt.Text = rd["Other_Charges"].ToString();
                uctxtGrandTotal.txt.Text = rd["Total"].ToString();
                //uctxtVno.txt.Text= rd["VNo"].ToString();
                uctxtCGST.txt.Text = rd["CGST"].ToString();
                uctxtSGST.txt.Text = rd["SGST"].ToString();
                uctxtIGST.txt.Text = rd["IGST"].ToString();
                uctxtCess.txt.Text = rd["CESS"].ToString();
                uctxtSubTotal.txt.Text = rd["Value"].ToString();
            }
            cmd.Dispose();
            rd.Close();
            
            sql = "select v.*,r.Item_Name as Item from v_purchase v left join m_raw r on v.RNo=r.SNo where v.VNo=" + (uctxtVno.txt.Text) + "order by SNo"; 
            cmd = new SqlCommand(sql, Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                grdPurchase.Rows.Add(rd["SNo"].ToString(), val(rd["Vno"].ToString()), val(rd["RNo"].ToString()), rd["Item"].ToString(), val(rd["Qty"].ToString()), val(rd["Rate"].ToString()), val(rd["Value"].ToString()), val(rd["CGST"].ToString()), val(rd["SGST"].ToString()), val(rd["Cess"].ToString()),val(rd["IGST"].ToString()));
            }
            
            cmd.Dispose();
            rd.Close();
        }
        private void uSearch_TextChanged(object sender, EventArgs e)
        {
            //btnSave_Click(sender , e);
            dv.RowFilter = "[Party Name] like '%" + uSearch.txt.Text + "%' or [Invoice No] like '%" + uSearch.txt.Text + "%'";
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
                uSearch.SearchEnterKey = true;
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
                if (Globals.msgbox(this,"Are You Sure To Delete Selected Record ?", "YesNo") == 1)
                {
                    sql = "Delete from v_purchase where VNo=" + gList.Rows[CurrentRow].Cells[4].Value;
                    SqlCommand cmd1 = new SqlCommand(sql, Globals.con);
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();

                    sql = "Delete from trans_1 where VType='purchase' and SNo=" + gList.Rows[CurrentRow].Cells[4].Value;
                    cmd1 = new SqlCommand(sql, Globals.con);
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();
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

        }

        private void usType_Load(object sender, EventArgs e)
        {
            Globals.LoadList(this, usSupplier.lstName, "Select SNo,SName,StateCode from m_party where Stype='supplier' order by SName");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(val(uctxtQty.txt.Text)==0)
            {
                Globals.msgbox(this, "Please Enter Quantity"); uctxtQty.Focus(); return;
            }
            if (val(uctxtRate.txt.Text) == 0)
            {
                Globals.msgbox(this, "Please Enter Rate"); uctxtRate.Focus(); return;
            }

            double Total = val(uctxtQty.txt.Text) * val(uctxtRate.txt.Text);

            if (status1 == "add")
            {
                //uctxtVno.txt.Text = Globals.MaxCode("v_purchase", "VNo").ToString();              

                //With-in State
                if (val(uctxtPartyStateCode.txt.Text) == val(uctxtCompanyStateCode.txt.Text) || uctxtPartyStateCode.txt.Text.Trim() == "")
                {
                    grdPurchase.Rows.Add(grdPurchase.Rows.Count + 1, val(uctxtVno.txt.Text), val(uctxtRno.txt.Text), usRaw.txt.Text, val(uctxtQty.txt.Text), val(uctxtRate.txt.Text), Total, Total * val(uctxtCgstval.txt.Text)/100, Total * val(uctxtSgstval.txt.Text)/100, Total * val(uctxtCessval.txt.Text)/100, 0); //igst in last
                }
                else  // Inter State
                {
                    grdPurchase.Rows.Add(grdPurchase.Rows.Count + 1, val(uctxtVno.txt.Text), val(uctxtRno.txt.Text), usRaw.txt.Text, val(uctxtQty.txt.Text), val(uctxtRate.txt.Text),Total, 0, 0, Total * val(uctxtCessval.txt.Text)/100, Total * val(uctxtIgstval.txt.Text)/100);
                }
                AutoNumber();
                CalcTotal();
            }
            else
            {
                //With-in State
                if (val(uctxtPartyStateCode.txt.Text) == val(uctxtCompanyStateCode.txt.Text) || uctxtPartyStateCode.txt.Text.Trim() == "")
                {
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[0].Value = val(uctxtSNo.txt.Text);
                    //grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[1].Value = val(uctxtVno.txt.Text);
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[2].Value = val(uctxtRno.txt.Text);
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[3].Value = usRaw.txt.Text;
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[4].Value = val(uctxtQty.txt.Text);
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[5].Value = val(uctxtRate.txt.Text);
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[6].Value = Total;
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[7].Value = Total * val(uctxtCgstval.txt.Text) / 100;
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[8].Value = Total * val(uctxtSgstval.txt.Text) / 100;
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[9].Value = Total * val(uctxtCessval.txt.Text) / 100;
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[10].Value = 0;
                }
                else  // Inter State
                {
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[0].Value = val(uctxtSNo.txt.Text);
                    //grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[1].Value = val(uctxtVno.txt.Text);
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[2].Value = val(uctxtRno.txt.Text);
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[3].Value = usRaw.txt.Text;
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[4].Value = val(uctxtQty.txt.Text);
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[5].Value = val(uctxtRate.txt.Text);
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[6].Value = Total;
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[7].Value = 0;
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[8].Value = 0;
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[9].Value = Total * val(uctxtCessval.txt.Text) / 100;
                    grdPurchase.Rows[grdPurchase.CurrentCell.RowIndex].Cells[10].Value = Total * val(uctxtIgstval.txt.Text) / 100;
                }
                    CalcTotal();
            }

            status1 = "add";
            usRaw.txt.Text = "";
            usRaw.txtCode.Text = "0";
            uctxtQty.txt.Text = "";
            uctxtRate.txt.Text = "";                
            uctxtHSN.txt.Text = "";
            usRaw.Focus();
        }
        private void CalcTotal()
        {
            double total = 0, cgst = 0, sgst = 0, cess = 0, igst = 0, qty = 0;
            for (int i = 0; i < grdPurchase.Rows.Count; ++i)
            {
                qty = qty + double.Parse(grdPurchase.Rows[i].Cells[4].Value.ToString().Trim());
                total = total + double.Parse(grdPurchase.Rows[i].Cells[6].Value.ToString().Trim());
                cgst = cgst + double.Parse(grdPurchase.Rows[i].Cells[7].Value.ToString().Trim());
                sgst = sgst + double.Parse(grdPurchase.Rows[i].Cells[8].Value.ToString().Trim());
                cess = cess + double.Parse(grdPurchase.Rows[i].Cells[9].Value.ToString().Trim());
                igst = igst + double.Parse(grdPurchase.Rows[i].Cells[10].Value.ToString().Trim());
            }

            uTotalQty.txt.Text = qty.ToString();
            uctxtSubTotal.txt.Text = total.ToString();
            uctxtCGST.txt.Text = (cgst).ToString();
            uctxtSGST.txt.Text = (sgst).ToString();
            uctxtCess.txt.Text = (cess).ToString();
            uctxtIGST.txt.Text = (igst).ToString();

            double utcs = val(uctxtTCS.txt.Text);
            double ufreight = val(uctxtFreight.txt.Text);
            double uinsurance = val(uctxtInsurance.txt.Text);
            double uot = val(uctxtOtherCharges.txt.Text);

            double gt = total + cgst + sgst + cess + igst + utcs + ufreight + uinsurance + uot;
            uctxtGrandTotal.txt.Text = string.Format("{0:#0.00}", gt);

        }
        private void AutoNumber()
        {
            
            for (int i = 0; i < grdPurchase.Rows.Count; i++)
            {
                grdPurchase.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                grdPurchase.Rows.RemoveAt(grdPurchase.CurrentRow.Index);
                AutoNumber();
                CalcTotal();
            }
            catch (Exception ex) { }
        }

        private void usDesc_Leave(object sender, EventArgs e)
        {            
            cmd = new SqlCommand("Select SNo,GSTIN,StateCode from m_party where SNo=" + val(usSupplier.txtCode.Text) + "", Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                uctxtPartyNo.txt.Text = rd["SNo"].ToString();
                uctxtGSTIN.txt.Text = rd["GSTIN"].ToString();
                uctxtPartyStateCode.txt.Text = rd["StateCode"].ToString();
            }
            cmd.Dispose();
            rd.Close();             
        }

        private void grdProduction_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = grdPurchase.CurrentCell.RowIndex;
            uctxtRno.txt.Text = grdPurchase.Rows[row].Cells[2].Value.ToString();
            usRaw.txtCode.Text = grdPurchase.Rows[row].Cells[2].Value.ToString();
            usRaw.txt.Text = grdPurchase.Rows[row].Cells[3].Value.ToString();           
            uctxtQty.txt.Text = grdPurchase.Rows[row].Cells[4].Value.ToString();
            uctxtRate.txt.Text = grdPurchase.Rows[row].Cells[5].Value.ToString();
            status1 = "edit";
            usRaw.Focus();
        }

        private void ucSearchList1_Load(object sender, EventArgs e)
        {

        }

        private void uSearchISI_TextChanged(object sender, EventArgs e)
        {
            //btnSave_Click(sender , e);
            dv.RowFilter = "[Invoice No] like '%" + uSearch.txt.Text + "%'";
            gList.DataSource = dv;
            if (gList.Rows.Count > 0)
            {
                CurrentRow = 0;
                gList.Rows[CurrentRow].Selected = true;
            }
        }

        private void grdProduction_DoubleClick(object sender, EventArgs e)
        {

        }

        private void uctxt7_Load(object sender, EventArgs e)
        {

        }

        private void ucSearchList1_Load_1(object sender, EventArgs e)
        {
            
        }

        private void usRaw_Leave(object sender, EventArgs e)
        {
            
        }

        private void grdPurchase_Leave(object sender, EventArgs e)
        {
           
        }

        private void usRaw_Load(object sender, EventArgs e)
        {
            Globals.LoadList(this, usRaw.lstName, "Select SNo,Item_Name from m_raw order by Item_Name");
        }

        private void usRaw_Leave_1(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select SNo,Rate,HSNCODE,CGST,SGST,IGST,CESS,TCS from m_raw where SNo=" + val(usRaw.txtCode.Text) + "", Globals.con);
            rd=cmd.ExecuteReader();
            if (rd.Read())
            {
                if(status1=="add")
                    uctxtRate.txt.Text = rd["Rate"].ToString();
                uctxtHSN.txt.Text = rd["HSNCODE"].ToString();
                uctxtRno.txt.Text = rd["SNo"].ToString();
                uctxtCgstval.txt.Text= rd["CGST"].ToString();
                uctxtSgstval.txt.Text = rd["SGST"].ToString();
                uctxtCessval.txt.Text = rd["CESS"].ToString();
                uctxtIgstval.txt.Text = rd["IGST"].ToString();
            }
            cmd.Dispose();
            rd.Close();

            cmd = new SqlCommand("Select FinancialDate from m_company", Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                ucFDate.date.Value= DateTime.Parse(rd["FinancialDate"].ToString());
            }
            cmd.Dispose();
            rd.Close();

            string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, op.VDate), 0))";
            string VDate1 = "(DATEADD(DAY, DATEDIFF(day, 0, p.RDate), 0))";
            string VDate2 = "(DATEADD(DAY, DATEDIFF(day, 0, pr.Date), 0))";
            string VDate3 = "(DATEADD(DAY, DATEDIFF(day, 0, c.Date), 0))";
            //            cmd = new SqlCommand("select r.SNo, r.Item_Name, isnull((select sum(op.OpStock) from m_Item_Opening op where op.Item_type = 'Raw Material' and op.INo = r.SNo and (" + VDate + " <= '" + ucRecDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "')), 0) as OPSTOCK,isnull((select sum(p.qty) from v_purchase p where p.RNo = r.SNo and(" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " <= '" + ucRecDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as PURCHASE,isnull((select sum(pr.qty) from Purchase_Return pr  where pr.RNo = r.SNo and(" + VDate2 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate2 + " <= '" + ucRecDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as purReturn,isnull((select sum(c.R_Qty) from Consumption c where C.RNo = r.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3+ " <= '" + ucRecDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as CONSUMED from m_raw r where r.Item_Name='" + usRaw.txt.Text + "' group by r.SNo,r.Item_Name order by r.SNo", Globals.con);
            string qry = "select r.SNo,r.Item_Name,isnull((select sum(op.R_Qty) from m_Item_Opening op where op.Item_type = 'Raw Material' and op.INo = r.SNo and (" + VDate + " >='" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + "<='" + ucRecDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as OPSTOCK,isnull((select sum(p.qty) from v_purchase p where p.RNo = r.SNo and (" + VDate1 + " >='" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + "<='" + ucRecDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as PURCHASE,isnull((select sum(pr.qty) from Purchase_Return pr  where pr.RNo = r.SNo and (" + VDate2 + " >='" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate2 + "<='" + ucRecDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as purReturn,isnull((select sum(c.R_Qty) from Consumption c where C.RNo = r.SNo and (" + VDate3 + " >='" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + "<='" + ucRecDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as CONSUMED from m_raw r where r.Item_Name='" + usRaw.txt.Text + "' group by r.SNo,r.Item_Name order by r.SNo";
            cmd = new SqlCommand(qry, Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                float o= float.Parse(rd["OPSTOCK"].ToString());
                float p = float.Parse(rd["Purchase"].ToString());
                float pr = float.Parse(rd["PurReturn"].ToString());
                float c= float.Parse(rd["Consumed"].ToString());
                float tt = o + p - pr - c;
                uctxtStkAbl.txt.Text = tt.ToString();
                label24.Text = usRaw.txt.Text + " =>   Stock Available on " + ucRecDate.date.Value.ToString("dd-MM-yyyy") +"  :   " + uctxtStkAbl.txt.Text;
            }
            cmd.Dispose();
            rd.Close();
        }

        private void uctxtSubTotal_Load(object sender, EventArgs e)
        {
            
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void uctxtSubTotal_EnabledChanged(object sender, EventArgs e)
        {
           
        }

        private void uctxtSubTotal_Enter(object sender, EventArgs e)
        {
            double total = 0, cgst = 0, sgst = 0, cess = 0, igst = 0;
 //           if (uctxtPartyStateCode.txt.Text == uctxtCompanyStateCode.txt.Text)
            {                
                    for (int i = 0; i < grdPurchase.Rows.Count; ++i)
                    {
                        //AutoNumber();
                        total = total + double.Parse(grdPurchase.Rows[i].Cells[6].Value.ToString().Trim());
                        cgst = cgst + double.Parse(grdPurchase.Rows[i].Cells[7].Value.ToString().Trim());
                        sgst = sgst + double.Parse(grdPurchase.Rows[i].Cells[8].Value.ToString().Trim());
                        cess = cess + double.Parse(grdPurchase.Rows[i].Cells[9].Value.ToString().Trim());
                        igst = igst + double.Parse(grdPurchase.Rows[i].Cells[10].Value.ToString().Trim());
                }
                    uctxtSubTotal.txt.Text = total.ToString();
                    uctxtCGST.txt.Text = (cgst).ToString();
                    uctxtSGST.txt.Text = (sgst).ToString();
                    uctxtCess.txt.Text = (cess).ToString();
                    uctxtIGST.txt.Text = (igst).ToString(); ;
                }                
/*                else
                {
                    for (int i = 0; i < grdPurchase.Rows.Count; ++i)
                    {
                        //AutoNumber();
                        total = total + double.Parse(grdPurchase.Rows[i].Cells[6].Value.ToString().Trim());
                        igst = igst + double.Parse(grdPurchase.Rows[i].Cells[10].Value.ToString().Trim());
                        cess = cess + double.Parse(grdPurchase.Rows[i].Cells[9].Value.ToString().Trim());

                    }
                    uctxtSubTotal.txt.Text = total.ToString();
                    uctxtIGST.txt.Text = (igst).ToString();
                    uctxtSGST.txt.Text = "0";
                    uctxtCGST.txt.Text = "0";
                    uctxtCess.txt.Text = (cess).ToString();
                }*/
            }
        

        private void usRaw_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void uctxtGrandTotal_Enter(object sender, EventArgs e)
        {            
            //double cgst = double.Parse(uctxtCGST.txt.Text);
            //double sgst = double.Parse(uctxtSGST.txt.Text);
            //double cess = double.Parse(uctxtCess.txt.Text);
            //double tcs = double.Parse(uctxtTCS.txt.Text);
            //double subtotal = double.Parse(uctxtSubTotal.txt.Text);
            //double freight = double.Parse(uctxtFreight.txt.Text);
            //double insurance = double.Parse(uctxtInsurance.txt.Text);
            //double ot = double.Parse(uctxtOtherCharges.txt.Text);
            //double igst = double.Parse(uctxtIGST.txt.Text);
            //if (uctxtCess.txt.Text == "")
            //{
            //    cess = 0;
            //    uctxtCess.txt.Text = "0";
            //}
            //if (uctxtFreight.txt.Text == "")
            //{
            //    freight = 0;
            //    uctxtFreight.txt.Text = "0";
            //}
            //if (uctxtTCS.txt.Text == "")
            //{
            //    tcs = 0;
            //    uctxtTCS.txt.Text = "0";
            //}
            //if (uctxtInsurance.txt.Text == "")
            //{
            //    insurance = 0;
            //    uctxtInsurance.txt.Text = "0";
            //}
            //if (uctxtFreight.txt.Text == "")
            //{
            //    freight = 0;
            //    uctxtFreight.txt.Text = "0";
            //}
            //if (uctxtOtherCharges.txt.Text == "")
            //{
            //    ot = 0;
            //    uctxtOtherCharges.txt.Text = "0";
            //}
            //double gt = cgst + sgst + cess + tcs + subtotal + freight + insurance + ot+igst;
            //uctxtGrandTotal.txt.Text = gt.ToString();
        }

        private void uctxtQty_KeyDown(object sender, KeyEventArgs e)
        {                        
            // if (e.KeyCode == Keys.F2)
            //{
            //    usRaw.txt.Text = "";
            //    usRaw.txtCode.Text = "";
            //    uctxtQty.txt.Text = "";
            //    uctxtFreight.Focus();
            //    uctxtHSN.txt.Text = "";
            //}
        }

        private void uctxtRno_Enter(object sender, EventArgs e)
        {

        }

        private void pbase_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pList_Paint(object sender, PaintEventArgs e)
        {

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

        private void ucRecDate_KeyDown(object sender, KeyEventArgs e)
        {
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        uctxtInvNo.Focus();
        //    }
        }

        private void uctxtInvNo_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    ucInvDate.Focus();
            //}
        }

        private void ucInvDate_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                uctxtInvNo.Focus();
            }
        }

        private void usSupplier_Enter(object sender, EventArgs e)
        {

        }

        private void usSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    uctxtConsigner.Focus();
            //}
        }

        private void uctxtConsigner_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void frmPurchase_Activated(object sender, EventArgs e)
        {
            Globals.LoadList(this, usSupplier.lstName, "Select SNo,SName,StateCode from m_party where Stype='supplier' order by SName");
        }

        private void ucRecDate_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                uctxtInvNo.Focus();
            }
        }

        private void uctxtFreight_Leave(object sender, EventArgs e)
        {
            if (val(uctxtFreight.txt.Text) != 0)
                CalcTotal();
        }

        private void uctxtInsurance_Leave(object sender, EventArgs e)
        {
            if (val(uctxtInsurance.txt.Text) != 0)
                CalcTotal();
        }

        private void uctxtOtherCharges_Leave(object sender, EventArgs e)
        {
            if (val(uctxtOtherCharges.txt.Text) != 0)
                CalcTotal();
        }

        private void uctxtTCS_Leave(object sender, EventArgs e)
        {
            if(val(uctxtTCS.txt.Text)!=0)
                CalcTotal();
        }

        private void ucInvDate_Leave(object sender, EventArgs e)
        {

        }

        private void grdPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int row = grdPurchase.CurrentCell.RowIndex;
                //  usRaw.txtCode.Text = grdPurchase.Rows[row].Cells[1].Value.ToString();
                usRaw.txt.Text = grdPurchase.Rows[row].Cells[3].Value.ToString();
                //       uctxtRno.txt.Text= grdPurchase.Rows[row].Cells[2].Value.ToString();
                uctxtQty.txt.Text = grdPurchase.Rows[row].Cells[4].Value.ToString();
                status1 = "edit";
                usRaw.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                usRaw.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                uctxtFreight.Focus();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void uctxtTCS_Load(object sender, EventArgs e)
        {

        }
    }
}
