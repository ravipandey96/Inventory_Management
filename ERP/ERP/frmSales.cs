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
    public partial class frmSales: Form
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
        string sqlu =null;
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
        public frmSales()
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
                //usGroup_Leave(sender, new EventArgs());
                ucBillDate.Focus();
            }
            else if (e.Control && e.KeyCode == Keys.S && pList.Visible == false)
            {
                btnSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2 && pList.Visible == false)
            {
                usItem.txt.Text = "";
                usItem.txtCode.Text = "";
                uctxtQty.txt.Text = "";
                uctxtRate.txt.Text = "";
                uctxtISI.txt.Text = "";
                uctxtSubTotal.Focus();
            }
            else if (e.KeyCode == Keys.F3)
            {
                frmParty f = new frmParty(this);
                f.Show(this);                                           
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
            else if (e.KeyCode == Keys.F2)
            {          
                usItem.txt.Text = "";
                usItem.txtCode.Text = "";
                uctxtQty.txt.Text = "";
                uctxtSubTotal.Focus();
            }            
            else if (e.KeyCode == Keys.F5)
            {
                pList.Visible = false;
                ClearMe();
                uctxtQty.txt.Text = "";
                uctxtISI.txt.Text = "";
                uctxtBatch.txt.Text = "";
                uctxttransport.txt.Text = "";
                ucBillDate.Enabled = true;
                uctxtvhno.txt.Text = "";
                uctxtInvNo.txt.Text = "";
                uctxtConsigner.txt.Text = "";
                uctxtFreight.txt.Text = "";
                uctxtInsurance.txt.Text = "";
                uctxtOtherCharges.txt.Text = "";
                uctxtTCS.txt.Text = "";
                uctxtVno.txt.Text = Globals.MaxCode("sales", "VNo").ToString();
                Globals.LoadList(this, usCustomer.lstName, "Select SNo,SName,StateCode from m_party where Stype='customer' order by SName");
            }
            else if (e.Control && e.KeyCode == Keys.M)
            {
                lblMin_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                this.Dispose();
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                lblMax_Click(sender, e);
            }
            /*            else if (e.KeyCode == Keys.F4)
                        {
                            if(cbISI.Checked)
                                cbISI.Checked = false;
                            else
                                cbISI.Checked = true;
                        }*/
        }
        private void frmUnit_Load(object sender, EventArgs e)
        {
  //          ucBillDate.Focus();
            uctxtHSN.Enabled = false;
   //         uctxtGSTIN.Enabled = false;
   //         uctxtRate.Enabled = false;
            uctxtCGST.Enabled = false;
            uctxtIGST.Enabled = false;
            uctxtSGST.Enabled = false;
            uctxtCess.Enabled = false;
            uctxtStkAbl.txt.ReadOnly =true;
            uctxtStkAbl.txt.BackColor = Color.LightPink;

            uctxtInvNo.txt.Tag = "Text";
            uctxtFreight.txt.Tag = "Amount";
            uctxtInsurance.txt.Tag = "Amount";
            uctxtTCS.txt.Tag = "Amount";
            uctxtOtherCharges.txt.Tag = "Amount";
            uctxtISI.txt.Tag = "number";
            uctxtQty.txt.Tag = "number";
            uctxtSubTotal.Enabled = false;
            uctxtGrandTotal.Enabled = false;
            uctxtGSTIN.txt.ReadOnly= true;
            frmMain frm = new frmMain();
            int ht = btnSave.Top - (usCustomer.Top + usCustomer.Height);
            usCustomer.txt.Tag = "SearchList,AutoHeight:false,Height:" + ht + ",";            
          //  uctxtQty.txt.Tag = "Text,Require";
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
            uctxtInvNo.Focus();
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
            //  jump:
            

            if (grdSales.Rows.Count != 0)
            {
                
               // grdSales.Focus();
               // btnSave.Enabled = false;
                //          goto jump;
            


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
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.Connection = con;
                cmd3.Transaction = transaction;
                /*    transactionu = con.BeginTransaction();
                    SqlCommand cmdu = con.CreateCommand();
                    cmd.Connection = con;
                    cmd.Transaction = transactionu;*/
                SqlDataReader rd, rd1;
                //           try
                //           {
                btnSave.Enabled = false;
                if (status == "add")
                {
        //              uctxtVno.txt.Text = Globals.MaxCode("v_purchase", "VNo").ToString();
        //              long sno = long.Parse(uctxtVno.txt.Text);
                        cmd = new SqlCommand("Select Bill_no from sales where Bill_no='" + uctxtInvNo.txt.Text + "'", Globals.con);
                        rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            Globals.msgbox(this, "Please Cheak Again Invoice Already Exist");
                            uctxtInvNo.Focus();
                        }
                        cmd.Dispose();
                        rd.Close();
                        if (uctxtInvNo.txt.Text.Trim() == "")
                    {
                        uctxtInvNo.txt.Text = uctxtVno.txt.Text;
                    }
                    if (grdSales.Rows.Count == 0)
                    {
                        Globals.msgbox(this, "Please Select Any Item");
                    }
                    double total = 0, gst = 0,cgst = 0, sgst = 0, cess = 0, igst = 0,fr8 = 0;
                    //                    if (uctxtPartyStateCode.txt.Text == uctxtCompanyStateCode.txt.Text)
                    //                    {
                    for (int i = 0; i < grdSales.Rows.Count; ++i)
                    {
                        //AutoNumber();
                        total = total + double.Parse(grdSales.Rows[i].Cells[8].Value.ToString().Trim());
                        cgst = cgst + double.Parse(grdSales.Rows[i].Cells[9].Value.ToString().Trim());
                        sgst = sgst + double.Parse(grdSales.Rows[i].Cells[10].Value.ToString().Trim());
                        cess = cess + double.Parse(grdSales.Rows[i].Cells[11].Value.ToString().Trim());
                        igst = igst + double.Parse(grdSales.Rows[i].Cells[12].Value.ToString().Trim());
                    }
                        if (uctxtCess.txt.Text == "")
                        {
                            cess = 0;
                            uctxtCess.txt.Text = "0";
                        }
                        if (uctxtFreight.txt.Text == "")
                        {
                            uctxtFreight.txt.Text = "0";
                        }
                        if (uctxtTCS.txt.Text == "")
                        {
                            uctxtTCS.txt.Text = "0";
                        }
                        if (uctxtInsurance.txt.Text == "")
                        {
                            uctxtInsurance.txt.Text = "0";
                        }
                        if (uctxtOtherCharges.txt.Text == "")
                        {
                            uctxtOtherCharges.txt.Text = "0";
                        }
                        fr8 = val(uctxtFreight.txt.Text);
                        gst = val(uctxtGstRate.txt.Text); 
                        uctxtSubTotal.txt.Text = total.ToString();
                        if (uctxtGstRate.txt.Text == "")
                        {
                            uctxtCGST.txt.Text = (cgst).ToString();
                            uctxtSGST.txt.Text = (sgst).ToString();
                            uctxtIGST.txt.Text = (igst).ToString();
                        }
                        else if (uctxtGstRate.txt.Text != "")
                        {
                            if (uctxtPartyStateCode.txt.Text == uctxtCompanyStateCode.txt.Text)
                            {
                                uctxtCGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                                uctxtSGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                            }
                            else
                            {
                                uctxtIGST.txt.Text = ((gst / 100) * (total + fr8)).ToString();
                            }
                        }
                        uctxtCess.txt.Text = (cess).ToString();
                        //                    }
                        /*                    else
                                            {
                                                for (int i = 0; i < grdSales.Rows.Count; ++i)
                                                {
                                                    //AutoNumber();
                                                    total = total + double.Parse(grdSales.Rows[i].Cells[7].Value.ToString().Trim());

                                                    cess = cess + double.Parse(grdSales.Rows[i].Cells[10].Value.ToString().Trim());
                                                }
                                                uctxtSubTotal.txt.Text = total.ToString();
                                                uctxtIGST.txt.Text = (igst).ToString();
                                                uctxtSGST.txt.Text = "0";
                                                uctxtCGST.txt.Text = "0";
                                                uctxtCess.txt.Text = (cess).ToString();
                                            }*/
                        double cgst1 = double.Parse(uctxtCGST.txt.Text);
                        double sgst1 = double.Parse(uctxtSGST.txt.Text);
                        double cess1 = double.Parse(uctxtCess.txt.Text);
                        double tcs = double.Parse(uctxtTCS.txt.Text);
                        double subtotal = double.Parse(uctxtSubTotal.txt.Text);
                        double freight = double.Parse(uctxtFreight.txt.Text);
                        double insurance = double.Parse(uctxtInsurance.txt.Text);
                        double ot = double.Parse(uctxtOtherCharges.txt.Text);
                        double igst1 = double.Parse(uctxtIGST.txt.Text);
                        if (uctxtCess.txt.Text == "")
                        {
                            cess = 0;
                            uctxtCess.txt.Text = "0";
                        }
                        if (uctxtFreight.txt.Text == "")
                        {
                            freight = 0;
                            uctxtFreight.txt.Text = "0";
                        }
                        if (uctxtTCS.txt.Text == "")
                        {
                            tcs = 0;
                            uctxtTCS.txt.Text = "0";
                        }
                        if (uctxtInsurance.txt.Text == "")
                        {
                            insurance = 0;
                            uctxtInsurance.txt.Text = "0";
                        }
                        if (uctxtFreight.txt.Text == "")
                        {
                            freight = 0;
                            uctxtFreight.txt.Text = "0";
                        }
                        if (uctxtOtherCharges.txt.Text == "")
                        {
                            ot = 0;
                            uctxtOtherCharges.txt.Text = "0";
                        }
                        double gt = cgst1 + sgst1 + cess1 + tcs + subtotal + freight + insurance + ot + igst1;
                        uctxtGrandTotal.txt.Text = gt.ToString();
                        for (int i = 0; i < grdSales.Rows.Count; ++i)
                    {
                        sql = "insert into sales(SNo,VNo,Sdate,Bill_no,CNo,consignee,FNo,Rate,ISI,ISI_Rate,Qty,Taxable_Value,CGST,SGST,IGST,Cess,TCS,Freight,Transit_Insurance,Other_Charges,Total,Total_Qty,Total_Regular,Total_ISI) values("
                        + (i + 1)
                        + "," + val(uctxtVno.txt.Text)
                        + ",'" + ucBillDate.date.Value.ToString("yyyy-MM-dd")
                        + "','" + uctxtInvNo.txt.Text
                        + "'," + val(uctxtPartyNo.txt.Text)
                        + ",'" + uctxtConsigner.txt.Text
                        + "'," + int.Parse(grdSales.Rows[i].Cells[2].Value.ToString().Trim())
                        + "," + float.Parse(grdSales.Rows[i].Cells[7].Value.ToString().Trim())
                        + "," + float.Parse(grdSales.Rows[i].Cells[4].Value.ToString().Trim())
                        + "," + float.Parse(grdSales.Rows[i].Cells[5].Value.ToString().Trim())
                        + "," + float.Parse(grdSales.Rows[i].Cells[6].Value.ToString().Trim())
                        + "," + float.Parse(grdSales.Rows[i].Cells[8].Value.ToString().Trim())
                        + "," + float.Parse(grdSales.Rows[i].Cells[9].Value.ToString().Trim())
                        + "," + float.Parse(grdSales.Rows[i].Cells[10].Value.ToString().Trim())
                        + "," + float.Parse(grdSales.Rows[i].Cells[12].Value.ToString().Trim())
                        + "," + float.Parse(grdSales.Rows[i].Cells[11].Value.ToString().Trim())
                        + "," + val(uctxtTCS.txt.Text)
                        + "," + val(uctxtFreight.txt.Text)
                        + "," + val(uctxtInsurance.txt.Text)
                        + "," + val(uctxtOtherCharges.txt.Text)
                        + "," + val(uctxtGrandTotal.txt.Text)
                        + "," + float.Parse(grdSales.Rows[i].Cells[13].Value.ToString().Trim())
                        + "," + float.Parse(grdSales.Rows[i].Cells[14].Value.ToString().Trim())
                        + "," + float.Parse(grdSales.Rows[i].Cells[15].Value.ToString().Trim()) + ")";
                        cmd.CommandText = sql;                        
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }

                    sql = "insert into trans_1(SNo,Inv_No,Vtype,VDate,PartySNo,NetTotal,TaxableAmount,cgst,sgst,igst,TCS,Vehicle_No,Transport,Batch_No) values("
                        + val(uctxtVno.txt.Text)
                        + ",'" + uctxtInvNo.txt.Text
                        + "','sales"
                        + "','" + ucBillDate.date.Value.ToString("yyyy-MM-dd")
                        + "'," + val(uctxtPartyNo.txt.Text)
                        + "," + val(uctxtGrandTotal.txt.Text)
                        + "," + val(uctxtSubTotal.txt.Text)
                        + "," + val(uctxtCGST.txt.Text)
                        + "," + val(uctxtSGST.txt.Text)
                        + "," + val(uctxtIGST.txt.Text)
                        + "," + val(uctxtTCS.txt.Text)
                        + ",'" + uctxtvhno.txt.Text
                        + "','" + uctxttransport.txt.Text
                        + "','" + uctxtBatch.txt.Text + "')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    Globals.msgbox(this, "Record Saved.");
                    uctxtFreight.txt.Text = "";
                    uctxtOtherCharges.txt.Text = "";
                    uctxtQty.txt.Text = "";
                    uctxtISI.txt.Text = "";
                    uctxtTCS.txt.Text = "";
                    uctxtInsurance.txt.Text = "";
                    ClearMe(); grdSales.Rows.Clear();
                    ucBillDate.Focus();
                }
                else // -----update-----
                {
                    
                    if (grdSales.Rows.Count == 0)
                    {
                        Globals.msgbox(this, "Please Select Any Item");
                        usItem.Focus();
                        uctxtISI.txt.Text = "";
                        uctxtQty.txt.Text = "";
                        btnSave.Enabled = false;
                    }
                    int vno = int.Parse(uctxtVno.txt.Text);
                    sql = "delete from sales where Sdate='" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "' and Bill_no=" + uctxtInvNo.txt.Text;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    sql = "delete from trans_1 where Vdate='" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "' and Inv_No=" + uctxtInvNo.txt.Text;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    if (uctxtR1.txt.Text != "")
                    {
                        long a = long.Parse(uctxtVno.txt.Text) + 1;
                        uctxtVno.txt.Text = a.ToString();
                    }
                    long sno = long.Parse(uctxtVno.txt.Text);
                        double total = 0, gst = 0, cgst1 = 0, sgst1 = 0, cess1 = 0, igst1 = 0, fr8 = 0;
                        //                    if (uctxtPartyStateCode.txt.Text == uctxtCompanyStateCode.txt.Text)
                        //                    {
                        for (int i = 0; i < grdSales.Rows.Count; ++i)
                        {
                            //AutoNumber();
                            total = total + double.Parse(grdSales.Rows[i].Cells[8].Value.ToString().Trim());
                            cgst1 = cgst1 + double.Parse(grdSales.Rows[i].Cells[9].Value.ToString().Trim());
                            sgst1 = sgst1 + double.Parse(grdSales.Rows[i].Cells[10].Value.ToString().Trim());
                            cess1 = cess1 + double.Parse(grdSales.Rows[i].Cells[11].Value.ToString().Trim());
                            igst1 = igst1 + double.Parse(grdSales.Rows[i].Cells[12].Value.ToString().Trim());
                        }
                        if (uctxtCess.txt.Text == "")
                        {
                            cess1 = 0;
                            uctxtCess.txt.Text = "0";
                        }
                        if (uctxtFreight.txt.Text == "")
                        {
                            uctxtFreight.txt.Text = "0";
                        }
                        if (uctxtTCS.txt.Text == "")
                        {
                            uctxtTCS.txt.Text = "0";
                        }
                        if (uctxtInsurance.txt.Text == "")
                        {
                            uctxtInsurance.txt.Text = "0";
                        }
                        if (uctxtOtherCharges.txt.Text == "")
                        {
                            uctxtOtherCharges.txt.Text = "0";
                        }
                        fr8 = val(uctxtFreight.txt.Text);
                        gst = val(uctxtGstRate.txt.Text);
                        uctxtSubTotal.txt.Text = total.ToString();
                        if (uctxtGstRate.txt.Text == "")
                        {
                            uctxtCGST.txt.Text = (cgst1).ToString();
                            uctxtSGST.txt.Text = (sgst1).ToString();
                            uctxtIGST.txt.Text = (igst1).ToString();
                        }
                        else if (uctxtGstRate.txt.Text != "")
                        {
                            if (uctxtPartyStateCode.txt.Text == uctxtCompanyStateCode.txt.Text)
                            {
                                uctxtCGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                                uctxtSGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                            }
                            else
                            {
                                uctxtIGST.txt.Text = ((gst / 100) * (total + fr8)).ToString();
                            }
                        }
                        uctxtCess.txt.Text = (cess1).ToString();
                        //                    }
                        /*                    else
                                            {
                                                for (int i = 0; i < grdSales.Rows.Count; ++i)
                                                {
                                                    //AutoNumber();
                                                    total = total + double.Parse(grdSales.Rows[i].Cells[7].Value.ToString().Trim());

                                                    cess = cess + double.Parse(grdSales.Rows[i].Cells[10].Value.ToString().Trim());
                                                }
                                                uctxtSubTotal.txt.Text = total.ToString();
                                                uctxtIGST.txt.Text = (igst).ToString();
                                                uctxtSGST.txt.Text = "0";
                                                uctxtCGST.txt.Text = "0";
                                                uctxtCess.txt.Text = (cess).ToString();
                                            }*/
                        double cgst_ = double.Parse(uctxtCGST.txt.Text);
                        double sgst_ = double.Parse(uctxtSGST.txt.Text);
                        double cess_ = double.Parse(uctxtCess.txt.Text);
                        double tcs = double.Parse(uctxtTCS.txt.Text);
                        double subtotal = double.Parse(uctxtSubTotal.txt.Text);
                        double freight = double.Parse(uctxtFreight.txt.Text);
                        double insurance = double.Parse(uctxtInsurance.txt.Text);
                        double ot = double.Parse(uctxtOtherCharges.txt.Text);
                        double igst_ = double.Parse(uctxtIGST.txt.Text);
                        if (uctxtCess.txt.Text == "")
                        {
                            cess_ = 0;
                            uctxtCess.txt.Text = "0";
                        }
                        if (uctxtFreight.txt.Text == "")
                        {
                            freight = 0;
                            uctxtFreight.txt.Text = "0";
                        }
                        if (uctxtTCS.txt.Text == "")
                        {
                            tcs = 0;
                            uctxtTCS.txt.Text = "0";
                        }
                        if (uctxtInsurance.txt.Text == "")
                        {
                            insurance = 0;
                            uctxtInsurance.txt.Text = "0";
                        }
                        if (uctxtFreight.txt.Text == "")
                        {
                            freight = 0;
                            uctxtFreight.txt.Text = "0";
                        }
                        if (uctxtOtherCharges.txt.Text == "")
                        {
                            ot = 0;
                            uctxtOtherCharges.txt.Text = "0";
                        }
                        double gt = cgst_ + sgst_ + cess_ + tcs + subtotal + freight + insurance + ot + igst_;
                        uctxtGrandTotal.txt.Text = gt.ToString();
                        for (int i = 0; i < grdSales.Rows.Count; ++i)
                    {
                            sql = "insert into sales(SNo,VNo,Sdate,Bill_no,CNo,consignee,FNo,Rate,ISI,ISI_Rate,Qty,Taxable_Value,CGST,SGST,IGST,Cess,TCS,Freight,Transit_Insurance,Other_Charges,Total,Total_Qty,Total_Regular,Total_ISI) values("
                            + (i + 1)
                            + "," + (sno)
                            + ",'" + ucBillDate.date.Value.ToString("yyyy-MM-dd")
                            + "','" + uctxtInvNo.txt.Text
                            + "'," + val(uctxtPartyNo.txt.Text)
                            + ",'" + uctxtConsigner.txt.Text
                            + "',"+ val(grdSales.Rows[i].Cells[2].Value.ToString().Trim())
                            + "," + val(grdSales.Rows[i].Cells[7].Value.ToString().Trim())
                            + "," + val(grdSales.Rows[i].Cells[4].Value.ToString().Trim())
                            + "," + val(grdSales.Rows[i].Cells[5].Value.ToString().Trim())
                            + "," + val(grdSales.Rows[i].Cells[6].Value.ToString().Trim())
                            + "," + val(grdSales.Rows[i].Cells[8].Value.ToString().Trim())
                            + "," + val(grdSales.Rows[i].Cells[9].Value.ToString().Trim())
                            + "," + val(grdSales.Rows[i].Cells[10].Value.ToString().Trim())
                            + "," + val(grdSales.Rows[i].Cells[12].Value.ToString().Trim())
                            + "," + val(grdSales.Rows[i].Cells[11].Value.ToString().Trim())
                            + "," + val(uctxtTCS.txt.Text)
                            + "," + val(uctxtFreight.txt.Text)
                            + "," + val(uctxtInsurance.txt.Text)
                            + "," + val(uctxtOtherCharges.txt.Text)
                            + "," + val(uctxtGrandTotal.txt.Text)
                            + "," + float.Parse(grdSales.Rows[i].Cells[13].Value.ToString().Trim())
                            + "," + float.Parse(grdSales.Rows[i].Cells[14].Value.ToString().Trim())
                            + "," + float.Parse(grdSales.Rows[i].Cells[15].Value.ToString().Trim()) + ")";
                            cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();                    
                    }
                    if(uctxtvhno.txt.Text=="")
                        {
                            uctxtvhno.txt.Text = "Not Available";
                        }
                    sql = "insert into trans_1(SNo,Inv_No,Vtype,VDate,PartySNo,NetTotal,TaxableAmount,cgst,sgst,igst,TCS,Vehicle_No,Transport,Batch_No) values("
                        + (sno)
                        + ",'" + uctxtInvNo.txt.Text
                        + "','sales"
                        + "','" + ucBillDate.date.Value.ToString("yyyy-MM-dd")
                        + "'," + val(uctxtPartyNo.txt.Text)
                        + "," + val(uctxtGrandTotal.txt.Text)
                        + "," + val(uctxtSubTotal.txt.Text)
                        + "," + val(uctxtCGST.txt.Text)
                        + "," + val(uctxtSGST.txt.Text)
                        + "," + val(uctxtIGST.txt.Text)
                        + "," + val(uctxtTCS.txt.Text)
                        + ",'" + uctxtvhno.txt.Text
                        + "','" + uctxttransport.txt.Text
                        + "','" + uctxtBatch.txt.Text + "')";
                    cmd1.CommandText = sql;
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();
                    transaction.Commit();
                    if (uctxtSubTotal.txt.Text != "")
                    {
                        Globals.msgbox(this, "Record Updated.");
                        grdSales.Rows.Clear();
                        ClearMe();
                        uctxtFreight.txt.Text = "";
                        uctxtOtherCharges.txt.Text = "";
                        uctxtQty.txt.Text = "";
                        uctxtISI.txt.Text = "";
                        uctxtTCS.txt.Text = "";
                        uctxtInsurance.txt.Text = "";
                        btnList_Click(sender, e);
                    }
                    else
                    {
                        Globals.msgbox(this, "Please select any item");
                    }
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
            usCustomer.Enabled = true;
            usCustomer.txt.Text = "";
            grdSales.Rows.Clear();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            pList.Visible = true;
            grdSales.Rows.Clear();
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
   
           sql1 = "select t.Inv_No [Invoice No],convert(varchar,t.VDate,101) as date,p.SName as [Party Name],t.NetTotal from m_party p,trans_1 t where p.Stype='customer' and t.PartySNo=p.SNo and t.VType='sales' and t.Inv_No like'%" + uSearch.txt.Text.Trim() + "%' and t.VDate between '"+ucDateFrom.date.Value.ToString("yyyy-MM-dd") + "' and '"+ucDateTo.date.Value.ToString("yyyy-MM-dd") + "' and t.Inv_No like '%"+ uSearchParty.txt.Text.Trim() + "%' order by t.Inv_No";

            cmd = new SqlCommand(sql1, Globals.con);
            //rd = cmd.ExecuteReader();
            ad = new SqlDataAdapter(cmd);
            ds.Clear();
            ad.Fill(ds);
            dv.Table = ds.Tables[0];
            gList.DataSource = null;
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
            //gList.Columns[0].Visible = false;
            gList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[1].Width = 250;
 //           gList.Columns[].Width = 250;
        }
        private void gFormat1()
        {
            grdSales.Columns[0].Visible = false;
            grdSales.Columns[1].Visible = false;
            grdSales.Columns[2].Visible = false;
            grdSales.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSales.Columns[2].Width = 100;
            grdSales.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSales.Columns[3].Width = 100;
            grdSales.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSales.Columns[4].Width = 100;
            grdSales.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSales.Columns[5].Width = 100;
            grdSales.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSales.Columns[6].Width = 100;
            grdSales.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdSales.Columns[7].Width = 100;
            grdSales.Columns[14].Visible = false;
            grdSales.Columns[15].Visible = false;
            grdSales.Columns[13].Visible = false;
        }
        private void gList_DoubleClick(object sender, EventArgs e)
        {
            if (gList.Rows.Count > 0 && CurrentRow >= 0)
            {
                pList.Visible = false;
                status = "edit";
                status1 = "edit";
                uctxtVno.txt.Text = gList.Rows[CurrentRow].Cells[1].Value.ToString();
                uctxtSNo.txt.Text = gList.Rows[CurrentRow].Cells[0].Value.ToString();
                PrevRec();
                cmd = new SqlCommand("Select sno,StateCode from m_company where sno=1", Globals.con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    uctxtCompanyStateCode.txt.Text = rd["StateCode"].ToString();
                }
                cmd.Dispose();
                rd.Close();
                ucBillDate.Enabled = false;
                usCustomer.Enabled = false;
                uctxtInvNo.Enabled = false;
                ucBillDate.Enabled = true;
                  ucBillDate.Focus();
            }
        }
        private void PrevRec()
        {
            sql = "";
            

            sql = "select v.*,t.Batch_No,p.SName,p.StateCode,t.Transport,t.Vehicle_No,t.cgst as TaxCgst,t.sgst as TaxSgst,t.igst as TaxIgst,v.Total_Regular,v.Total_ISI,t.TaxableAmount as TaxAmt,t.NetTotal as NT,r.Thickness from trans_1 t,sales v left join m_party p on v.CNo=p.SNo left join finished r on v.FNo=r.SNo where t.SNo=v.VNo and t.Vtype='sales' and v.Bill_no="+(uctxtSNo.txt.Text)+ "";
            cmd = new SqlCommand(sql, Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
//              uDate.date.Value = DateTime.Parse(rd["vdate"].ToString());
                usCustomer.txt.Text = rd["SName"].ToString();
                //              usSupplier.txtCode.Text = rd["Party"].ToString();
                uctxtPartyStateCode.txt.Text = rd["StateCode"].ToString();
                ucBillDate.date.Value = DateTime.Parse(rd["Sdate"].ToString());
                uctxtInvNo.txt.Text = rd["Bill_no"].ToString();
             //   ucInvDate.date.Value = DateTime.Parse(rd["Inv_date"].ToString());
                uctxtConsigner.txt.Text = rd["consignee"].ToString();
                usItem.txt.Text = rd["Thickness"].ToString();
                uctxtPartyNo.txt.Text = rd["CNo"].ToString();
//              usRaw.txtCode.Text = rd["Item_Code"].ToString();
                uctxtQty.txt.Text = rd["Qty"].ToString();
                uctxtBatch.txt.Text = rd["Batch_No"].ToString();
                uctxtvhno.txt.Text = rd["Vehicle_No"].ToString();
                uctxtTCS.txt.Text = rd["TCS"].ToString();
                uctxtFreight.txt.Text = rd["Freight"].ToString();
                uctxtInsurance.txt.Text = rd["Transit_Insurance"].ToString();
                uctxtOtherCharges.txt.Text = rd["Other_Charges"].ToString();
                uctxtGrandTotal.txt.Text = rd["NT"].ToString();
                uctxtVno.txt.Text = rd["VNo"].ToString();
                uctxtISI.txt.Text = rd["ISI"].ToString();
                uctxtSubTotal.txt.Text = rd["TaxAmt"].ToString();
                uctxtIGST.txt.Text = rd["TaxIgst"].ToString();
                uctxtCGST.txt.Text = rd["TaxCgst"].ToString();
                uctxtSGST.txt.Text = rd["TaxSgst"].ToString();
                uctxtCess.txt.Text = rd["Cess"].ToString();
                uctxtStkAbl.txt.Text = rd["Total_Regular"].ToString();
                uctxtBIS.txt.Text = rd["Total_ISI"].ToString();
                uctxttransport.txt.Text = rd["Transport"].ToString();
            }
            cmd.Dispose();
            rd.Close();

            sql = "select v.*,r.Thickness as Item from sales v left join finished r on v.FNo=r.SNo where v.Bill_no=" + (uctxtSNo.txt.Text) + "order by SNo"; 
            cmd = new SqlCommand(sql, Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                grdSales.Rows.Add(rd["SNo"].ToString(), val(rd["Vno"].ToString()), val(rd["FNo"].ToString()), rd["Item"].ToString(), val(rd["ISI"].ToString()), val(rd["ISI_Rate"].ToString()), val(rd["Qty"].ToString()), val(rd["Rate"].ToString()), val(rd["Taxable_Value"].ToString()), val(rd["CGST"].ToString()), val(rd["SGST"].ToString()), val(rd["Cess"].ToString()),val(rd["IGST"].ToString()),val(rd["Total_Qty"]),val(rd["Total_Regular"]),val(rd["Total_ISI"]));
            }
            int r=grdSales.Rows.Count;
            uctxtGrdSales.txt.Text = r.ToString();
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
            //    uSearch.SearchEnterKey = true;
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
                    sql = "Delete from sales where Bill_no=" + int.Parse(gList.Rows[CurrentRow].Cells[0].Value.ToString().Trim()) + " and total=" + gList.Rows[CurrentRow].Cells[3].Value;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();                    
                    sql = "Delete from trans_1 where VType='sales' and Inv_No=" + gList.Rows[CurrentRow].Cells[0].Value + " and NetTotal=" + gList.Rows[CurrentRow].Cells[3].Value;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    sql = "Delete from Sstock where Regular<=0 and BIS<=0";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();                    
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
                ucBillDate.Enabled = true;
                ucBillDate.Focus();
                this.Dispose();                
            }
            else if (e.KeyCode == Keys.Escape && pList.Visible == true)
            {
                pList.Visible = false;                
                usCustomer.txt.Tag = "Text,Require";
                ucBillDate.Enabled = true;
                ucBillDate.Focus();
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
            else if (e.KeyCode == Keys.M)
            {
                lblMin_Click(sender, e);
            }
            else if (e.KeyCode == Keys.N)
            {
                lblMax_Click(sender, e);
            }
        }

        private void usType_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {                                        
            if (uctxtISI.txt.Text == "")
            {
                uctxtISI.txt.Text = "0";
            }
            if (uctxtISIRate.txt.Text == "")
            {
                uctxtISIRate.txt.Text = "0";
            }
            if (uctxtQty.txt.Text == "")
            {
                uctxtQty.txt.Text = "0";
            }
            if ((val(uctxtQty.txt.Text)!=0 || val(uctxtISI.txt.Text)!=0) && val(uctxtRate.txt.Text) != 0)
            {
                if (status1 == "add")
                {
                    uctxtVno.txt.Text = Globals.MaxCode("sales", "VNo").ToString();
                    if (uctxtPartyStateCode.txt.Text == uctxtCompanyStateCode.txt.Text)
                    {
                        grdSales.Rows.Add(grdSales.Rows.Count + 1, val(uctxtVno.txt.Text), val(uctxtFno.txt.Text), usItem.txt.Text, val(uctxtISI.txt.Text), val(uctxtISIRate.txt.Text), val(uctxtQty.txt.Text), val(uctxtRate.txt.Text), val(uctxtISI.txt.Text) * val(uctxtISIRate.txt.Text) + val(uctxtQty.txt.Text) * val(uctxtRate.txt.Text), val(uctxtISI.txt.Text) * val(uctxtISIRate.txt.Text) * val(uctxtCgstval.txt.Text) / 100 + val(uctxtQty.txt.Text) * val(uctxtRate.txt.Text) * val(uctxtCgstval.txt.Text) / 100, val(uctxtISI.txt.Text) * val(uctxtISIRate.txt.Text) * val(uctxtSgstval.txt.Text) / 100 + val(uctxtQty.txt.Text) * val(uctxtRate.txt.Text) * val(uctxtSgstval.txt.Text) / 100, val(uctxtISI.txt.Text) * val(uctxtISIRate.txt.Text) * val(uctxtCessval.txt.Text) / 100 + val(uctxtQty.txt.Text) * val(uctxtRate.txt.Text) * val(uctxtCessval.txt.Text) / 100, 0, val(uctxtQty.txt.Text) + val(uctxtISI.txt.Text), val(uctxtStkAbl.txt.Text), val(uctxtBIS.txt.Text));
                        AutoNumber();
                    }
                    else if (uctxtPartyStateCode.txt.Text == "")
                    {
                        grdSales.Rows.Add(grdSales.Rows.Count + 1, val(uctxtVno.txt.Text), val(uctxtFno.txt.Text), usItem.txt.Text, val(uctxtISI.txt.Text), val(uctxtISIRate.txt.Text), val(uctxtQty.txt.Text), val(uctxtRate.txt.Text), val(uctxtISI.txt.Text) * val(uctxtISIRate.txt.Text) + val(uctxtQty.txt.Text) * val(uctxtRate.txt.Text), val(uctxtISI.txt.Text) * val(uctxtISIRate.txt.Text) * val(uctxtCgstval.txt.Text) / 100 + val(uctxtQty.txt.Text) * val(uctxtRate.txt.Text) * val(uctxtCgstval.txt.Text) / 100, val(uctxtISI.txt.Text) * val(uctxtISIRate.txt.Text) * val(uctxtSgstval.txt.Text) / 100 + val(uctxtQty.txt.Text) * val(uctxtRate.txt.Text) * val(uctxtSgstval.txt.Text) / 100, val(uctxtISI.txt.Text) * val(uctxtISIRate.txt.Text) * val(uctxtCessval.txt.Text) / 100 + val(uctxtQty.txt.Text) * val(uctxtRate.txt.Text) * val(uctxtCessval.txt.Text) / 100, 0, val(uctxtQty.txt.Text) + val(uctxtISI.txt.Text), val(uctxtStkAbl.txt.Text), val(uctxtBIS.txt.Text));
                        AutoNumber();
                    }
                    else
                    {
                        grdSales.Rows.Add(grdSales.Rows.Count + 1, val(uctxtVno.txt.Text), val(uctxtFno.txt.Text), usItem.txt.Text, val(uctxtISI.txt.Text),val(uctxtISIRate.txt.Text), val(uctxtQty.txt.Text), val(uctxtRate.txt.Text), val(uctxtISI.txt.Text) * val(uctxtISIRate.txt.Text) + val(uctxtQty.txt.Text) * val(uctxtRate.txt.Text), 0, 0, val(uctxtISI.txt.Text) * val(uctxtISIRate.txt.Text) * val(uctxtCessval.txt.Text) / 100 + val(uctxtQty.txt.Text) * val(uctxtRate.txt.Text) * val(uctxtCessval.txt.Text) / 100, val(uctxtISI.txt.Text) * val(uctxtISIRate.txt.Text) * val(uctxtIgstval.txt.Text) / 100 + val(uctxtQty.txt.Text) * val(uctxtRate.txt.Text) * val(uctxtIgstval.txt.Text) / 100, val(uctxtQty.txt.Text) + val(uctxtISI.txt.Text), val(uctxtStkAbl.txt.Text), val(uctxtBIS.txt.Text));
                        AutoNumber();
                    }
                    double total = 0, cgst = 0, sgst = 0,gst,cess = 0, igst = 0, fr8=0;
                    int ii = 0;
                    for (int i = 0; i < grdSales.Rows.Count; ++i)
                    {
                        //AutoNumber();
                        total = total + double.Parse(grdSales.Rows[i].Cells[8].Value.ToString().Trim());
                        cgst = cgst + double.Parse(grdSales.Rows[i].Cells[9].Value.ToString().Trim());
                        sgst = sgst + double.Parse(grdSales.Rows[i].Cells[10].Value.ToString().Trim());
                        cess = cess + double.Parse(grdSales.Rows[i].Cells[11].Value.ToString().Trim());
                        igst = igst + double.Parse(grdSales.Rows[i].Cells[12].Value.ToString().Trim());
                        ii = i;
                    }
                    fr8 = val(uctxtFreight.txt.Text);
                    gst = val(uctxtGstRate.txt.Text);
                    uctxtSubTotal.txt.Text = total.ToString();
                    if (uctxtGstRate.txt.Text == "")
                    {
                        uctxtCGST.txt.Text = (cgst).ToString();
                        uctxtSGST.txt.Text = (sgst).ToString();
                        uctxtIGST.txt.Text = (igst).ToString();
                    }
                    else if (uctxtGstRate.txt.Text != "")
                    {
                        if (uctxtPartyStateCode.txt.Text == uctxtCompanyStateCode.txt.Text)
                        {
                            uctxtCGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                            uctxtSGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                        }
                        else
                        {
                            uctxtIGST.txt.Text = ((gst / 100) * (total + fr8)).ToString();
                        }
                    }
                    uctxtCess.txt.Text = (cess).ToString();
                    uctxtRcount.txt.Text = (ii + 1).ToString();
                             }
                else
                {
                    NSstock.txt.Text = Globals.MaxCode("NSstock", "SNo").ToString();                   
                                 int vn = int.Parse(uctxtVno.txt.Text);
                    sql = "insert into NSstock(SNo,SrNo,Vtype,Sdate,FNo,VNo,Regular,BIS,Value,CGST,SGST,IGST) values("
                   + val(NSstock.txt.Text)
                   + "," + val(uctxtSrNo.txt.Text)
                   + ",'Updation"
                   + "','" + ucBillDate.date.Value.ToString("yyyy-MM-dd")
                   + "'," + val(uctxttbfno.txt.Text)
                    + "," + vn
                   + "," + val(uctxttbreg.txt.Text)
                   + "," + val(uctxttbBIS.txt.Text)
                   + "," + val(uctxttbvalue.txt.Text)
                   + "," + val(uctxttbcgst.txt.Text)
                   + "," + val(uctxttbsgst.txt.Text)
                   + "," + val(uctxttbigst.txt.Text) + ")";             
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
                    double total = 0, cgst = 0, sgst = 0, cess = 0, igst = 0, ii = 0,fr8=0,gst=0;
                    
                    for (int i = 0; i < grdSales.Rows.Count; ++i)
                    {
                        total = total + double.Parse(grdSales.Rows[i].Cells[8].Value.ToString().Trim());
                        cgst = cgst + double.Parse(grdSales.Rows[i].Cells[9].Value.ToString().Trim());
                        sgst = sgst + double.Parse(grdSales.Rows[i].Cells[10].Value.ToString().Trim());
                        cess = cess + double.Parse(grdSales.Rows[i].Cells[11].Value.ToString().Trim());
                        igst = igst + double.Parse(grdSales.Rows[i].Cells[12].Value.ToString().Trim());
                        ii = i;
                    }
                    fr8 = val(uctxtFreight.txt.Text);
                    gst = val(uctxtGstRate.txt.Text);
                    uctxtSubTotal.txt.Text = total.ToString();
                    if (uctxtGstRate.txt.Text == "")
                    {
                        uctxtCGST.txt.Text = (cgst).ToString();
                        uctxtSGST.txt.Text = (sgst).ToString();
                        uctxtIGST.txt.Text = (igst).ToString();
                    }
                    else if (uctxtGstRate.txt.Text != "")
                    {
                        if (uctxtPartyStateCode.txt.Text == uctxtCompanyStateCode.txt.Text)
                        {
                            uctxtCGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                            uctxtSGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                        }
                        else
                        {
                            uctxtIGST.txt.Text = ((gst / 100) * (total + fr8)).ToString();
                        }
                    }
                    uctxtCess.txt.Text = (cess).ToString();
                    uctxtRcount.txt.Text = (ii + 1).ToString();


                }
                double cgst1 = double.Parse(uctxtCGST.txt.Text);
                double sgst1 = double.Parse(uctxtSGST.txt.Text);
                double cess1 = double.Parse(uctxtCess.txt.Text);
                double tcs = val(uctxtTCS.txt.Text);
                double subtotal = double.Parse(uctxtSubTotal.txt.Text);
                double freight = val(uctxtFreight.txt.Text);
                double insurance = val(uctxtInsurance.txt.Text);
                double ot = val(uctxtOtherCharges.txt.Text);
                double igst1 = double.Parse(uctxtIGST.txt.Text);
                if (uctxtCess.txt.Text == "")
                {
                    cess1 = 0;
                    uctxtCess.txt.Text = "0";
                }
                if (uctxtFreight.txt.Text == "")
                {
                    freight = 0;
                    uctxtFreight.txt.Text = "0";
                }
                if (uctxtTCS.txt.Text == "")
                {
                    tcs = 0;
                    uctxtTCS.txt.Text = "0";
                }
                if (uctxtInsurance.txt.Text == "")
                {
                    insurance = 0;
                    uctxtInsurance.txt.Text = "0";
                }
                if (uctxtFreight.txt.Text == "")
                {
                    freight = 0;
                    uctxtFreight.txt.Text = "0";
                }
                if (uctxtOtherCharges.txt.Text == "")
                {
                    ot = 0;
                    uctxtOtherCharges.txt.Text = "0";
                }
                double gt = cgst1 + sgst1 + cess1 + tcs + subtotal + freight + insurance + ot + igst1;
                uctxtGrandTotal.txt.Text = gt.ToString();
                status1 = "add";
                usItem.txt.Text = "";
                uctxtQty.txt.Text = "";
                uctxtISI.txt.Text = "";
                uctxtRate.txt.Text = "";
                uctxtHSN.txt.Text = "";
                uctxtISIRate.txt.Text = "";
            }
            else
            {
                Globals.msgbox(this, "Something Missing");
            }
        
            usItem.Focus();
        }
        private void AutoNumber()
        {
            
            for (int i = 0; i < grdSales.Rows.Count; i++)
            {
                grdSales.Rows[i].Cells[0].Value = i + 1;
             
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (ucBillDate.Enabled == true)
                {
                    grdSales.Rows.RemoveAt(grdSales.CurrentRow.Index);
                    AutoNumber();
                }                                
                double total = 0, cgst = 0, sgst = 0, cess = 0, igst = 0,fr8=0,gst=0;
                int ii = 0;
                for (int i = 0; i < grdSales.Rows.Count; ++i)
                {
                    //AutoNumber();
                    total = total + double.Parse(grdSales.Rows[i].Cells[8].Value.ToString().Trim());
                    cgst = cgst + double.Parse(grdSales.Rows[i].Cells[9].Value.ToString().Trim());
                    sgst = sgst + double.Parse(grdSales.Rows[i].Cells[10].Value.ToString().Trim());
                    cess = cess + double.Parse(grdSales.Rows[i].Cells[11].Value.ToString().Trim());
                    igst = igst + double.Parse(grdSales.Rows[i].Cells[12].Value.ToString().Trim());
                    ii = i;
                }
                fr8 = val(uctxtFreight.txt.Text);
                gst = val(uctxtGstRate.txt.Text);
                uctxtSubTotal.txt.Text = total.ToString();
                if (uctxtGstRate.txt.Text == "")
                {
                    uctxtCGST.txt.Text = (cgst).ToString();
                    uctxtSGST.txt.Text = (sgst).ToString();
                    uctxtIGST.txt.Text = (igst).ToString();
                }
                else if (uctxtGstRate.txt.Text != "")
                {
                    if (uctxtPartyStateCode.txt.Text == uctxtCompanyStateCode.txt.Text)
                    {
                        uctxtCGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                        uctxtSGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                    }
                    else
                    {
                        uctxtIGST.txt.Text = ((gst / 100) * (total + fr8)).ToString();
                    }
                }
                uctxtCess.txt.Text = (cess).ToString();
                uctxtRcount.txt.Text = (ii + 1).ToString();
                double cgst1 = double.Parse(uctxtCGST.txt.Text);
                double sgst1 = double.Parse(uctxtSGST.txt.Text);
                double cess1 = double.Parse(uctxtCess.txt.Text);
                double tcs = double.Parse(uctxtTCS.txt.Text);
                double subtotal = double.Parse(uctxtSubTotal.txt.Text);
                double freight = double.Parse(uctxtFreight.txt.Text);
                double insurance = double.Parse(uctxtInsurance.txt.Text);
                double ot = double.Parse(uctxtOtherCharges.txt.Text);
                double igst1 = double.Parse(uctxtIGST.txt.Text);
                if (uctxtCess.txt.Text == "")
                {
                    cess = 0;
                    uctxtCess.txt.Text = "0";
                }
                if (uctxtFreight.txt.Text == "")
                {
                    freight = 0;
                    uctxtFreight.txt.Text = "0";
                }
                if (uctxtTCS.txt.Text == "")
                {
                    tcs = 0;
                    uctxtTCS.txt.Text = "0";
                }
                if (uctxtInsurance.txt.Text == "")
                {
                    insurance = 0;
                    uctxtInsurance.txt.Text = "0";
                }
                if (uctxtFreight.txt.Text == "")
                {
                    freight = 0;
                    uctxtFreight.txt.Text = "0";
                }
                if (uctxtOtherCharges.txt.Text == "")
                {
                    ot = 0;
                    uctxtOtherCharges.txt.Text = "0";
                }
                double gt = cgst1 + sgst1 + cess1 + tcs + subtotal + freight + insurance + ot + igst1;
                uctxtGrandTotal.txt.Text = gt.ToString();
            }
            catch (Exception ex)
            {
                Globals.msgbox(this, ex.Message);
            }
            
            }
        private void usDesc_Leave(object sender, EventArgs e)
        {            
            cmd = new SqlCommand("Select SNo,GSTIN,Statecode from m_party where SName='" + usCustomer.txt.Text + "'", Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                uctxtPartyNo.txt.Text = rd["SNo"].ToString();
                uctxtGSTIN.txt.Text = rd["GSTIN"].ToString();
                uctxtPartyStateCode.txt.Text = rd["StateCode"].ToString();
            }
            cmd.Dispose();
            rd.Close();
            cmd = new SqlCommand("Select sno,StateCode from m_company where sno=1", Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                uctxtCompanyStateCode.txt.Text = rd["StateCode"].ToString();
            }
            cmd.Dispose();
            rd.Close();

            uctxtIGST.txt.Text = "";
            uctxtCGST.txt.Text = "";
            uctxtSGST.txt.Text = "";
            uctxtCess.txt.Text = "";
            uctxtSubTotal.txt.Text = "";
            grdSales.Rows.Clear();

        }

        private void grdProduction_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            uctxttbBIS.txt.Text = "";
            uctxttbreg.txt.Text = "";
            uctxttbcgst.txt.Text = "";
            uctxttbsgst.txt.Text = "";
            uctxttbigst.txt.Text = "";
            int row = grdSales.CurrentCell.RowIndex;
            usItem.txt.Text = grdSales.Rows[row].Cells[3].Value.ToString();
            uctxtQty.txt.Text = grdSales.Rows[row].Cells[6].Value.ToString();
            uctxtSrNo.txt.Text = grdSales.Rows[row].Cells[0].Value.ToString();
            uctxtSrNo1.txt.Text = grdSales.Rows[row].Cells[0].Value.ToString();
            uctxtISI.txt.Text = grdSales.Rows[row].Cells[4].Value.ToString();
            uctxtISIRate.txt.Text = grdSales.Rows[row].Cells[5].Value.ToString();
            uctxtRate.txt.Text = grdSales.Rows[row].Cells[7].Value.ToString();
            uctxttbreg.txt.Text = grdSales.Rows[row].Cells[6].Value.ToString();
            uctxttbreg1.txt.Text = grdSales.Rows[row].Cells[6].Value.ToString();
            uctxttbBIS.txt.Text = grdSales.Rows[row].Cells[4].Value.ToString();
            uctxttbBIS1.txt.Text = grdSales.Rows[row].Cells[4].Value.ToString();
            uctxttbvalue.txt.Text = grdSales.Rows[row].Cells[8].Value.ToString();
            uctxttbvalue1.txt.Text = grdSales.Rows[row].Cells[8].Value.ToString();
            uctxttbcgst.txt.Text = grdSales.Rows[row].Cells[9].Value.ToString();
            uctxttbcgst1.txt.Text = grdSales.Rows[row].Cells[9].Value.ToString();
            uctxttbsgst.txt.Text = grdSales.Rows[row].Cells[10].Value.ToString();
            uctxttbsgst1.txt.Text = grdSales.Rows[row].Cells[10].Value.ToString();
            uctxttbigst.txt.Text = grdSales.Rows[row].Cells[12].Value.ToString();
            uctxttbigst1.txt.Text = grdSales.Rows[row].Cells[12].Value.ToString();
            uctxttbfno.txt.Text = grdSales.Rows[row].Cells[2].Value.ToString();
            uctxttbfno1.txt.Text = grdSales.Rows[row].Cells[2].Value.ToString();
            status1 = "edit";
            usItem.Focus();
        }

        private void ucSearchList1_Load(object sender, EventArgs e)
        {

        }

        private void uSearchISI_TextChanged(object sender, EventArgs e)
        {
            //btnSave_Click(sender , e);
            dv.RowFilter = "[Invoice No] like '%" + uSearchParty.txt.Text + "%'";
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
             Globals.LoadList(this, usItem.lstName, "Select SNo,Thickness from finished  order by Item_Name");
            }

        private void usRaw_Leave_1(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select SNo,Item_Name,Rate,CGST,SGST,IGST,Cess,HSNCODE from finished f  where Thickness='" + usItem.txt.Text + "'order by f.Item_Name", Globals.con);
            rd=cmd.ExecuteReader();
            while (rd.Read())
            {                

                uctxtCgstval.txt.Text = rd["CGST"].ToString();
                uctxtSgstval.txt.Text = rd["SGST"].ToString();
                uctxtIgstval.txt.Text = rd["IGST"].ToString();
                uctxtFno.txt.Text = rd["SNo"].ToString();
                uctxtHSN.txt.Text = rd["HSNCODE"].ToString();
            }
            cmd.Dispose();
            rd.Close();
            cmd = new SqlCommand("Select FinancialDate from m_company", Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ucFDate.date.Value = DateTime.Parse(rd["FinancialDate"].ToString());
            }
            cmd.Dispose();
            rd.Close();
            string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, op.VDate), 0))";
            string VDate1 = "(DATEADD(DAY, DATEDIFF(day, 0, vm.date), 0))";
            string VDate2 = "(DATEADD(DAY, DATEDIFF(day, 0, sr.Date), 0))";
            string VDate3 = "(DATEADD(DAY, DATEDIFF(day, 0, s.SDate), 0))";                                    
            string qry11 = "select f.sno,f.thickness,isnull((select sum(op.regular) from m_Item_Opening op where op.Item_type = 'Finished Good' and op.INo = f.SNo and (" + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as OPStock, isnull((select sum(vm.Regular) from v_manufacturing vm where vm.FNo = f.SNo and (" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as PRODUCTION,isnull((select sum(vm.breackage) from v_manufacturing vm where vm.FNo = f.SNo and(" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as BREACKAGE,isnull((select sum(sr.qty) from Sales_Return sr where sr.FNo = f.SNo and(" + VDate2 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate2 + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as SaleReturn,isnull((select sum(s.qty) from sales s where s.FNo = f.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as Sales,isnull((select sum(s.ISI)   from sales s where s.FNo = f.SNo and (" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as ISI,isnull((select sum(s.taxable_value) from sales s where s.FNo = f.SNo and (" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as Value,isnull((select sum(s.SGST) from sales s where s.FNo = f.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as SGST,isnull((select sum(s.CGST) from sales s where s.FNo = f.SNo and (" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as CGST,isnull((select sum(s.IGST) from sales s where s.FNo = f.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as IGST,'0' as CLSTOCK from finished f where Sno='" + uctxtFno.txt.Text + "' group by f.sno,f.thickness order by f.SNo";
            string qry1 = "select f.sno,f.thickness,isnull((select sum(op.regular) from m_Item_Opening op where op.Item_type = 'Finished Good' and op.INo = f.SNo and (" + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as OPStock, isnull((select sum(vm.Regular) from v_manufacturing vm where vm.FNo = f.SNo and (" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as PRODUCTION,isnull((select sum(vm.breackage) from v_manufacturing vm where vm.FNo = f.SNo and(" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as BREACKAGE,isnull((select sum(sr.qty) from Sales_Return sr where sr.FNo = f.SNo and(" + VDate2 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate2 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as SaleReturn,isnull((select sum(s.qty) from sales s where s.FNo = f.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as Sales,isnull((select sum(s.ISI)   from sales s where s.FNo = f.SNo and (" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as ISI,isnull((select sum(s.taxable_value) from sales s where s.FNo = f.SNo and (" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as Value,isnull((select sum(s.SGST) from sales s where s.FNo = f.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as SGST,isnull((select sum(s.CGST) from sales s where s.FNo = f.SNo and (" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as CGST,isnull((select sum(s.IGST) from sales s where s.FNo = f.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as IGST,'0' as CLSTOCK from finished f where Sno='" + uctxtFno.txt.Text + "' group by f.sno,f.thickness order by f.SNo";
            cmd = new SqlCommand(qry1, Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                float o = float.Parse(rd["OPSTOCK"].ToString());
                float p = float.Parse(rd["PRODUCTION"].ToString());
                float s = float.Parse(rd["Sales"].ToString());
                float sr = float.Parse(rd["SaleReturn"].ToString());
                float tt = o + p + sr - s;
                uctxtStkAbl.txt.Text = tt.ToString();
                }
            cmd.Dispose();
            rd.Close();
            string qry21 = "select f.sno,f.thickness,isnull((select sum(op.BIS) from m_Item_Opening op where op.Item_type = 'Finished Good' and op.INo = f.SNo and (" + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as OPStock, isnull((select sum(vm.ISI) from v_manufacturing vm where vm.FNo = f.SNo and (" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as PRODUCTION,isnull((select sum(vm.breackage) from v_manufacturing vm where vm.FNo = f.SNo and(" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as BREACKAGE,isnull((select sum(sr.BIS) from Sales_Return sr where sr.FNo = f.SNo and(" + VDate2 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate2 + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as SaleReturn,isnull((select sum(s.ISI) from sales s where s.FNo = f.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " < '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as Sales from finished f where Thickness='" + usItem.txt.Text + "' group by f.sno,f.thickness order by f.SNo";
            string qry2 = "select f.sno,f.thickness,isnull((select sum(op.BIS) from m_Item_Opening op where op.Item_type = 'Finished Good' and op.INo = f.SNo and (" + VDate + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as OPStock, isnull((select sum(vm.ISI) from v_manufacturing vm where vm.FNo = f.SNo and (" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as PRODUCTION,isnull((select sum(vm.breackage) from v_manufacturing vm where vm.FNo = f.SNo and(" + VDate1 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate1 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as BREACKAGE,isnull((select sum(sr.BIS) from Sales_Return sr where sr.FNo = f.SNo and(" + VDate2 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate2 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as SaleReturn,isnull((select sum(s.ISI) from sales s where s.FNo = f.SNo and(" + VDate3 + " >= '" + ucFDate.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate3 + " <= '" + ucBillDate.date.Value.ToString("yyyy-MM-dd") + "')),0) as Sales from finished f where Thickness='" + usItem.txt.Text + "' group by f.sno,f.thickness order by f.SNo";
            cmd = new SqlCommand(qry2, Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                float o = float.Parse(rd["OPSTOCK"].ToString());
                float p = float.Parse(rd["PRODUCTION"].ToString());
                //                float b = float.Parse(rd["BREACKAGE"].ToString());
                float s = float.Parse(rd["Sales"].ToString());
                float sr = float.Parse(rd["SaleReturn"].ToString());
                float tt = o + p + sr - s;
                uctxtBIS.txt.Text = tt.ToString();
                label22.Text = "Stock Report on "+ ucBillDate.date.Value.ToString("dd-MM-yyyy") +" =>   Regular  :   " + uctxtStkAbl.txt.Text + "  BIS   :  "  + uctxtBIS.txt.Text;
            }
            cmd.Dispose();
            rd.Close();
            cmd = new SqlCommand(qry21, Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                float o = float.Parse(rd["OPSTOCK"].ToString());
                float p = float.Parse(rd["PRODUCTION"].ToString());
                float s = float.Parse(rd["Sales"].ToString());
                float sr = float.Parse(rd["SaleReturn"].ToString());
                float tt = o + p + sr - s;
                uctxtBIS.txt.Text = tt.ToString();                
            }
            cmd.Dispose();
            rd.Close();
            cmd = new SqlCommand(qry11, Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                float o = float.Parse(rd["OPSTOCK"].ToString());
                float p = float.Parse(rd["PRODUCTION"].ToString());
                float s = float.Parse(rd["Sales"].ToString());
                float sr = float.Parse(rd["SaleReturn"].ToString());
                float tt = o + p + sr - s;
                uctxtStkAbl.txt.Text = tt.ToString();
            }
            cmd.Dispose();
            rd.Close();
            uctxtSRegular.txt.Text = "0";
            uctxtSISI.txt.Text = "0";
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
            double total = 0, cgst = 0, sgst = 0, cess = 0, igst = 0,fr8=0,gst=0;
                    for (int i = 0; i < grdSales.Rows.Count; ++i)
                    {             
                        total = total + double.Parse(grdSales.Rows[i].Cells[8].Value.ToString().Trim());
                        cgst = cgst + double.Parse(grdSales.Rows[i].Cells[9].Value.ToString().Trim());
                        sgst = sgst + double.Parse(grdSales.Rows[i].Cells[10].Value.ToString().Trim());
                        cess = cess + double.Parse(grdSales.Rows[i].Cells[11].Value.ToString().Trim());
                        igst = igst + double.Parse(grdSales.Rows[i].Cells[12].Value.ToString().Trim());
            }
            fr8 = val(uctxtFreight.txt.Text);
            gst = val(uctxtGstRate.txt.Text);
            uctxtSubTotal.txt.Text = total.ToString();
            if (uctxtGstRate.txt.Text == "")
            {
                uctxtCGST.txt.Text = (cgst).ToString();
                uctxtSGST.txt.Text = (sgst).ToString();
                uctxtIGST.txt.Text = (igst).ToString();
            }
            else if (uctxtGstRate.txt.Text != "")
            {
                if (uctxtPartyStateCode.txt.Text == uctxtCompanyStateCode.txt.Text)
                {
                    uctxtCGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                    uctxtSGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                }
                else
                {
                    uctxtIGST.txt.Text = ((gst / 100) * (total + fr8)).ToString();
                }
            }
            uctxtCess.txt.Text = (cess).ToString();                    
        }
        

        private void usRaw_KeyDown(object sender, KeyEventArgs e)
        {
            
          
             if (e.KeyCode == Keys.F2)
            {
                usItem.txt.Text = "";
                usItem.txtCode.Text = "";
                uctxtQty.txt.Text = "";
                uctxtGstRate.Focus();
                uctxtHSN.txt.Text = "";
            }     
        }

        private void uctxtGrandTotal_Enter(object sender, EventArgs e)
        {            
            double cgst = double.Parse(uctxtCGST.txt.Text);
            double sgst = double.Parse(uctxtSGST.txt.Text);
            double cess = double.Parse(uctxtCess.txt.Text);
            double tcs = double.Parse(uctxtTCS.txt.Text);
            double subtotal = double.Parse(uctxtSubTotal.txt.Text);
            double freight = double.Parse(uctxtFreight.txt.Text);
            double insurance = double.Parse(uctxtInsurance.txt.Text);
            double ot = double.Parse(uctxtOtherCharges.txt.Text);
            double igst = double.Parse(uctxtIGST.txt.Text);
            if (uctxtCess.txt.Text == "")
            {
                cess = 0;
                uctxtCess.txt.Text = "0";
            }
            if (uctxtFreight.txt.Text == "")
            {
                freight = 0;
                uctxtFreight.txt.Text = "0";
            }
            if (uctxtTCS.txt.Text == "")
            {
                tcs = 0;
                uctxtTCS.txt.Text = "0";
            }
            if (uctxtInsurance.txt.Text == "")
            {
                insurance = 0;
                uctxtInsurance.txt.Text = "0";
            }
            if (uctxtFreight.txt.Text == "")
            {
                freight = 0;
                uctxtFreight.txt.Text = "0";
            }
            if (uctxtOtherCharges.txt.Text == "")
            {
                ot = 0;
                uctxtOtherCharges.txt.Text = "0";
            }
            double gt = cgst + sgst + cess + tcs + subtotal + freight + insurance + ot+igst;
            uctxtGrandTotal.txt.Text = gt.ToString();
        }

        private void uctxtQty_KeyDown(object sender, KeyEventArgs e)
        {                        
             if (e.KeyCode == Keys.F2)
            {
                usItem.txt.Text = "";
                usItem.txtCode.Text = "";
                uctxtQty.txt.Text = "";
                uctxtGstRate.Focus();
                uctxtHSN.txt.Text = "";
            }
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

        private void usItem_Enter(object sender, EventArgs e)
        {
            
        }

        private void uctxtISI_Enter(object sender, EventArgs e)
        {
        }

        private void uctxtQty_Enter(object sender, EventArgs e)
        {

        }

        private void cbISI_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void uctxtInvNo_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }

        private void frmSales_Activated(object sender, EventArgs e)
        {
            Globals.LoadList(this, usCustomer.lstName, "Select SNo,SName,StateCode from m_party where Stype='customer' order by SName");
        }

        private void uctxtISI_Leave(object sender, EventArgs e)
        {
            if(uctxtISI.txt.Text=="")
            {
                uctxtISI.txt.Text = "0";
            }
        }

        private void uctxtTCS_Leave(object sender, EventArgs e)
        {
            double cgst = val(uctxtCGST.txt.Text);
            double sgst = val(uctxtSGST.txt.Text);
            double cess = val(uctxtCess.txt.Text);
            double tcs = val(uctxtTCS.txt.Text);
            double subtotal = val(uctxtSubTotal.txt.Text);
            double freight = val(uctxtFreight.txt.Text);
            double insurance = val(uctxtInsurance.txt.Text);
            double ot = val(uctxtOtherCharges.txt.Text);
            double igst = val(uctxtIGST.txt.Text);
            if (uctxtCess.txt.Text == "")
            {
                cess = 0;
                uctxtCess.txt.Text = "0";
            }
            if (uctxtFreight.txt.Text == "")
            {
                freight = 0;
                uctxtFreight.txt.Text = "0";
            }
            if (uctxtTCS.txt.Text == "")
            {
                tcs = 0;
                uctxtTCS.txt.Text = "0";
            }
            if (uctxtInsurance.txt.Text == "")
            {
                insurance = 0;
                uctxtInsurance.txt.Text = "0";
            }
            if (uctxtFreight.txt.Text == "")
            {
                freight = 0;
                uctxtFreight.txt.Text = "0";
            }
            if (uctxtOtherCharges.txt.Text == "")
            {
                ot = 0;
                uctxtOtherCharges.txt.Text = "0";
            }
            double gt = cgst + sgst + cess + tcs + subtotal + freight + insurance + ot + igst;
            uctxtGrandTotal.txt.Text = gt.ToString();
        }

        private void btnRemove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                usItem.txt.Text = "";
                usItem.txtCode.Text = "";
                uctxtQty.txt.Text = "";
                uctxtGstRate.Focus();
                uctxtHSN.txt.Text = "";
            
        }
            }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void grdSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uctxtRate_Leave(object sender, EventArgs e)
        {
        }

        private void uctxtGstRate_Leave(object sender, EventArgs e)
        {
            
        }

        private void uctxtFreight_Leave(object sender, EventArgs e)
        {
            double total = 0, cgst = 0, sgst = 0, cess = 0, igst = 0, fr8 = 0, gst = 0;

            for (int i = 0; i < grdSales.Rows.Count; ++i)
            {
                total = total + double.Parse(grdSales.Rows[i].Cells[8].Value.ToString().Trim());
                cgst = cgst + double.Parse(grdSales.Rows[i].Cells[9].Value.ToString().Trim());
                sgst = sgst + double.Parse(grdSales.Rows[i].Cells[10].Value.ToString().Trim());
                cess = cess + double.Parse(grdSales.Rows[i].Cells[11].Value.ToString().Trim());
                igst = igst + double.Parse(grdSales.Rows[i].Cells[12].Value.ToString().Trim());
            }
            fr8 = val(uctxtFreight.txt.Text);
            gst = val(uctxtGstRate.txt.Text);
            uctxtSubTotal.txt.Text = total.ToString();
            if (uctxtGstRate.txt.Text == "")
            {
                uctxtCGST.txt.Text = (cgst).ToString();
                uctxtSGST.txt.Text = (sgst).ToString();
                uctxtIGST.txt.Text = (igst).ToString();
            }
            else if (uctxtGstRate.txt.Text != "")
            {
                if (uctxtPartyStateCode.txt.Text == uctxtCompanyStateCode.txt.Text)
                {
                    uctxtCGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                    uctxtSGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                }
                else
                {
                    uctxtIGST.txt.Text = ((gst / 100) * (total + fr8)).ToString();
                }
            }
            uctxtCess.txt.Text = (cess).ToString();
        }

        private void uctxtInvNo_Leave(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select Bill_no from sales where Bill_no='" + uctxtInvNo.txt.Text + "'", Globals.con);
            rd = cmd.ExecuteReader();
            if(rd.Read())
            {
                Globals.msgbox(this, "Please Cheak Again Invoice Already Exist");
                uctxtInvNo.Focus();
            }
            cmd.Dispose();
            rd.Close();
        }

        private void uctxtISI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                usItem.txt.Text = "";
                usItem.txtCode.Text = "";
                uctxtQty.txt.Text = "";
                uctxtISI.txt.Text = "";
                uctxtGstRate.Focus();
                uctxtHSN.txt.Text = "";
            }
        }

        private void uctxtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                usItem.txt.Text = "";
                usItem.txtCode.Text = "";
                uctxtQty.txt.Text = "";
                uctxtISI.txt.Text = "";
                uctxtGstRate.Focus();
                uctxtHSN.txt.Text = "";
            }
        }

        private void grdSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                uctxttbBIS.txt.Text = "";
                uctxttbreg.txt.Text = "";
                uctxttbcgst.txt.Text = "";
                uctxttbsgst.txt.Text = "";
                uctxttbigst.txt.Text = "";
                int row = grdSales.CurrentCell.RowIndex;

                usItem.txt.Text = grdSales.Rows[row].Cells[3].Value.ToString();
                uctxtQty.txt.Text = grdSales.Rows[row].Cells[6].Value.ToString();
                uctxtSrNo.txt.Text = grdSales.Rows[row].Cells[0].Value.ToString();
                uctxtSrNo1.txt.Text = grdSales.Rows[row].Cells[0].Value.ToString();
                uctxtISI.txt.Text = grdSales.Rows[row].Cells[4].Value.ToString();
                uctxtISIRate.txt.Text = grdSales.Rows[row].Cells[5].Value.ToString();
                uctxtRate.txt.Text = grdSales.Rows[row].Cells[7].Value.ToString();
                uctxttbreg.txt.Text = grdSales.Rows[row].Cells[6].Value.ToString();
                uctxttbreg1.txt.Text = grdSales.Rows[row].Cells[6].Value.ToString();
                uctxttbBIS.txt.Text = grdSales.Rows[row].Cells[4].Value.ToString();
                uctxttbBIS1.txt.Text = grdSales.Rows[row].Cells[4].Value.ToString();
                uctxttbvalue.txt.Text = grdSales.Rows[row].Cells[8].Value.ToString();
                uctxttbvalue1.txt.Text = grdSales.Rows[row].Cells[8].Value.ToString();
                uctxttbcgst.txt.Text = grdSales.Rows[row].Cells[9].Value.ToString();
                uctxttbcgst1.txt.Text = grdSales.Rows[row].Cells[9].Value.ToString();
                uctxttbsgst.txt.Text = grdSales.Rows[row].Cells[10].Value.ToString();
                uctxttbsgst1.txt.Text = grdSales.Rows[row].Cells[10].Value.ToString();
                uctxttbigst.txt.Text = grdSales.Rows[row].Cells[12].Value.ToString();
                uctxttbigst1.txt.Text = grdSales.Rows[row].Cells[12].Value.ToString();
                uctxttbfno.txt.Text = grdSales.Rows[row].Cells[2].Value.ToString();
                uctxttbfno1.txt.Text = grdSales.Rows[row].Cells[2].Value.ToString();
                status1 = "edit";                
                usItem.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                usItem.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                uctxtGstRate.Focus();
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                int row = grdSales.CurrentCell.RowIndex;
                uctxttbfno.txt.Text = grdSales.Rows[row].Cells[2].Value.ToString();
                uctxtSrNo1.txt.Text = grdSales.Rows[row].Cells[0].Value.ToString();
                uctxttbreg1.txt.Text = grdSales.Rows[row].Cells[6].Value.ToString();
                uctxttbBIS1.txt.Text = grdSales.Rows[row].Cells[4].Value.ToString();
                uctxttbvalue1.txt.Text = grdSales.Rows[row].Cells[8].Value.ToString();
                uctxttbcgst1.txt.Text = grdSales.Rows[row].Cells[9].Value.ToString();
                uctxttbsgst1.txt.Text = grdSales.Rows[row].Cells[10].Value.ToString();
                uctxttbigst1.txt.Text = grdSales.Rows[row].Cells[12].Value.ToString();
                uctxttbfno1.txt.Text = grdSales.Rows[row].Cells[2].Value.ToString();
                try
                {
                    if (ucBillDate.Enabled == true)
                    {
                        grdSales.Rows.RemoveAt(grdSales.CurrentRow.Index);
                        AutoNumber();
                    }

                    else if (ucBillDate.Enabled == false && uctxtSrNo1.txt.Text != "")
                    {
                        RNSstock.txt.Text = Globals.MaxCode("RNSstock", "SNo").ToString();
                        int vn = int.Parse(uctxtVno.txt.Text);
                        sql = "insert into RNSstock(SNo,SrNo,Vtype,Sdate,FNo,VNo,Regular,BIS,Value,CGST,SGST,IGST) values("
                       + val(RNSstock.txt.Text)
                       + "," + val(uctxtSrNo1.txt.Text)
                       + ",'Updation"
                       + "','" + ucBillDate.date.Value.ToString("yyyy-MM-dd")
                       + "'," + val(uctxttbfno1.txt.Text)
                        + "," + vn
                       + "," + val(uctxttbreg1.txt.Text)
                       + "," + val(uctxttbBIS1.txt.Text)
                       + "," + val(uctxttbvalue1.txt.Text)
                       + "," + val(uctxttbcgst1.txt.Text)
                       + "," + val(uctxttbsgst1.txt.Text)
                       + "," + val(uctxttbigst1.txt.Text) + ")";
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
                        uctxtremove.txt.Text = "Removed";                        
                    }
                    
                    double total = 0, cgst = 0, sgst = 0, cess = 0, igst = 0, fr8 = 0, gst = 0;
                    int ii = 0;
                    for (int i = 0; i < grdSales.Rows.Count; ++i)
                    {
                        //AutoNumber();
                        total = total + double.Parse(grdSales.Rows[i].Cells[8].Value.ToString().Trim());
                        cgst = cgst + double.Parse(grdSales.Rows[i].Cells[9].Value.ToString().Trim());
                        sgst = sgst + double.Parse(grdSales.Rows[i].Cells[10].Value.ToString().Trim());
                        cess = cess + double.Parse(grdSales.Rows[i].Cells[11].Value.ToString().Trim());
                        igst = igst + double.Parse(grdSales.Rows[i].Cells[12].Value.ToString().Trim());
                        ii = i;
                    }
                    fr8 = val(uctxtFreight.txt.Text);
                    gst = val(uctxtGstRate.txt.Text);
                    uctxtSubTotal.txt.Text = total.ToString();
                    if (uctxtGstRate.txt.Text == "")
                    {
                        uctxtCGST.txt.Text = (cgst).ToString();
                        uctxtSGST.txt.Text = (sgst).ToString();
                        uctxtIGST.txt.Text = (igst).ToString();
                    }
                    else if (uctxtGstRate.txt.Text != "")
                    {
                        if (uctxtPartyStateCode.txt.Text == uctxtCompanyStateCode.txt.Text)
                        {
                            uctxtCGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                            uctxtSGST.txt.Text = ((gst / 200) * (total + fr8)).ToString();
                        }
                        else
                        {
                            uctxtIGST.txt.Text = ((gst / 100) * (total + fr8)).ToString();
                        }
                    }
                    uctxtCess.txt.Text = (cess).ToString();
                    uctxtRcount.txt.Text = (ii + 1).ToString();
                    double cgst1 = double.Parse(uctxtCGST.txt.Text);
                    double sgst1 = double.Parse(uctxtSGST.txt.Text);
                    double cess1 = double.Parse(uctxtCess.txt.Text);
                    double tcs = double.Parse(uctxtTCS.txt.Text);
                    double subtotal = double.Parse(uctxtSubTotal.txt.Text);
                    double freight = double.Parse(uctxtFreight.txt.Text);
                    double insurance = double.Parse(uctxtInsurance.txt.Text);
                    double ot = double.Parse(uctxtOtherCharges.txt.Text);
                    double igst1 = double.Parse(uctxtIGST.txt.Text);
                    if (uctxtCess.txt.Text == "")
                    {
                        cess = 0;
                        uctxtCess.txt.Text = "0";
                    }
                    if (uctxtFreight.txt.Text == "")
                    {
                        freight = 0;
                        uctxtFreight.txt.Text = "0";
                    }
                    if (uctxtTCS.txt.Text == "")
                    {
                        tcs = 0;
                        uctxtTCS.txt.Text = "0";
                    }
                    if (uctxtInsurance.txt.Text == "")
                    {
                        insurance = 0;
                        uctxtInsurance.txt.Text = "0";
                    }
                    if (uctxtFreight.txt.Text == "")
                    {
                        freight = 0;
                        uctxtFreight.txt.Text = "0";
                    }
                    if (uctxtOtherCharges.txt.Text == "")
                    {
                        ot = 0;
                        uctxtOtherCharges.txt.Text = "0";
                    }
                    double gt = cgst1 + sgst1 + cess1 + tcs + subtotal + freight + insurance + ot + igst1;
                    uctxtGrandTotal.txt.Text = gt.ToString();
                }
                catch (Exception ex)
                {
                    Globals.msgbox(this, ex.Message);
                }
            }
            grdSales.Rows[grdSales.CurrentCell.RowIndex].Selected = true;
        }

        private void uctxtGstRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                grdSales.Focus();    
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void uSearchParty_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void uctxtvhno_Load(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void uctxtQty_Leave(object sender, EventArgs e)
        {
            if (uctxtQty.txt.Text == "")
            {
                uctxtQty.txt.Text = "0";
            }
            
        }

        private void grdSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = grdSales.CurrentCell.RowIndex;
            uctxttbfno.txt.Text = grdSales.Rows[row].Cells[2].Value.ToString();
            uctxtSrNo1.txt.Text = grdSales.Rows[row].Cells[0].Value.ToString();
            uctxttbreg1.txt.Text = grdSales.Rows[row].Cells[6].Value.ToString();
            uctxttbBIS1.txt.Text = grdSales.Rows[row].Cells[4].Value.ToString();
            uctxttbvalue1.txt.Text = grdSales.Rows[row].Cells[8].Value.ToString();
            uctxttbcgst1.txt.Text = grdSales.Rows[row].Cells[9].Value.ToString();
            uctxttbsgst1.txt.Text = grdSales.Rows[row].Cells[10].Value.ToString();
            uctxttbigst1.txt.Text = grdSales.Rows[row].Cells[12].Value.ToString();
            uctxttbfno1.txt.Text = grdSales.Rows[row].Cells[2].Value.ToString();
        }

        private void uctxtSRegular_Load(object sender, EventArgs e)
        {

        }

        private void uctxtGrandTotal_Load(object sender, EventArgs e)
        {

        }
    }
}
