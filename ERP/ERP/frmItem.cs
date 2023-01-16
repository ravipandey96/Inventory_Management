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
    public partial class frmItem : Form
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
        public frmItem()
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
            uName.txt.Tag = "Text,Require";
            uAlias.txt.Tag = "Text";
            uPrintName.txt.Tag = "Text";
            uSearchGroup.txt.Tag = "SearchList,Require";
            uSearchBrand.txt.Tag = "SearchList,Require";
            uSearchUnit.txt.Tag = "SearchList,Require";
            uSearchAtlUnit.txt.Tag = "SearchList";
            uConversion.txt.Tag = "Number";
            uHSNCode.txt.Tag = "Text";
            uSearchTax.txt.Tag = "SearchList,Require";
            uSearchGSTType.txt.Tag = "SearchList,Require";
            uCGST.txt.Tag = "Amount";
            uSGST.txt.Tag = "Amount,ReadOnly";
            uIGST.txt.Tag = "Amount,ReadOnly";
            uCess.txt.Tag = "Amount,ReadOnly";
            uPurchRate.txt.Tag = "Amount";
            uPurchDisc.txt.Tag = "Amount";
            uPPer.txt.Tag = "Amount";
            uSaleRate.txt.Tag = "Amount";
            uTPRate.txt.Tag = "Amount";
            uSaleDisc.txt.Tag = "Amount";
            uPPer2.txt.Tag = "Amount";
            uSaleRate2.txt.Tag = "Amount";
            uTPRate2.txt.Tag = "Amount";
            uSaleDisc2.txt.Tag = "Amount";
            uMRP.txt.Tag = "Amount";

            status = "add";
            FormMode = "Max";
            //Form Position     
            lblBorderBottom.Height = 2;
            lblBorderLeft.Width = 2;
            lblBorderRight.Width = 2;
            this.Location = new Point((x - this.Width) / 2 , (y - this.Height - frm.MainMenuStrip.Height) / 2);

            lblClose.Top = (lblTitleBar.Height - lblClose.Height) / 2;
            lblClose.Left = this.Width - lblClose.Width - 4;
            lblMin.Top = lblClose.Top;
            lblMin.Left = lblClose.Left - lblMin.Width - 2;
            // Panel Position           pbase1.Left = (this.Width - (pbase1.Width + pbase2.Width)) / 2;
            pbase.Left = (this.Width - pbase.Width) / 2;
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
                if (uName.txt.Text.Trim() == "")
                {
                    Globals.msgbox(this , lblTitleBar.Text + " Name Can't be Empty.");
                    uName.Focus();
                    return;
                }

                btnSave.Enabled = false;
                bool chkExist;
                if (status == "add")
                {
                    if (uAlias.txt.Text.Trim().Length > 0)
                    {
                        chkExist = Globals.chkRecord("m_item" , "Alias='" + uAlias.txt.Text.Trim() + "'");
                        if (chkExist)
                        {
                            Globals.msgbox(this , "This Item Alias Already Exists");
                            uName.Focus(); btnSave.Enabled = true; return;
                        }
                    }
                    else if (Globals.chkRecord("m_item" , "ItemName='" + uName.txt.Text.Trim() + "'"))
                    {
                        Globals.msgbox(this , "This Item Name Already Exists");
                        uName.Focus(); btnSave.Enabled = true; return;
                    }
                    uctxtSNo.txt.Text = Globals.MaxCode("M_Item" , "SNo").ToString();
                    sql = "insert into M_Item(SNo,ItemName,Alias,PrintName,GroupSNo,BrandSNo,Unit,AltUnit,Conv,PurchRate,PurchDisc,PPer,SaleRate,TPRate,SaleDisc,PPer2,SaleRate2,TPRate2,SaleDisc2,MRP,HSNCode,TaxCategory,TaxType,CGST,SGST,IGST,Cess,TaxOnMRP,TaxCalculation,StockLocation) values (" +
                    val(uctxtSNo.txt.Text)
                    + ",'" + uName.txt.Text
                    + "','" + uAlias.txt.Text
                    + "','" + uPrintName.txt.Text
                    + "'," + uSearchGroup.txtCode.Text
                    + "," + uSearchBrand.txtCode.Text
                    + ",'" + uSearchUnit.txt.Text
                    + "','" + uSearchAtlUnit.txt.Text
                    + "'," + uConversion.txt.Text
                    + "," + val(uPurchRate.txt.Text)
                    + "," + val(uPurchDisc.txt.Text)
                    + "," + val(uPPer.txt.Text)
                    + "," + val(uSaleRate.txt.Text)
                    + "," + val(uTPRate.txt.Text)
                    + "," + val(uSaleDisc.txt.Text)
                    + "," + val(uPPer2.txt.Text)
                    + "," + val(uSaleRate2.txt.Text)
                    + "," + val(uTPRate2.txt.Text)
                    + "," + val(uSaleDisc2.txt.Text)
                    + "," + val(uMRP.txt.Text)
                    + ",'" + uHSNCode.txt.Text
                    + "','" + uSearchTax.txt.Text
                    + "','" + uSearchGSTType.txt.Text
                    + "'," + val(uCGST.txt.Text)
                    + "," + val(uSGST.txt.Text)
                    + "," + val(uIGST.txt.Text)
                    + "," + val(uCess.txt.Text)
                    + ",'" + uSearchTaxOnMRP.txt.Text
                    + "','" + uSearchTaxCalculation.txt.Text
                    + "','" + uSearchStockLocation.txt.Text + "')";
                    cmd = new SqlCommand(sql , Globals.con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Globals.msgbox(this , "Item Saved.");
                    ClearMe();
                    uName.Focus();
                }
                else
                {
                    if (Globals.chkRecord("M_Item" , "ItemName='" + uName.txt.Text.Trim() + "' and SNo<>" + val(uctxtSNo.txt.Text) + ""))
                    {
                        Globals.msgbox(this , "This Item Name Already Exists");
                        uName.Focus();
                    }
                    else
                    {
                        sql = "update M_Item set ItemName='" + uName.txt.Text
                        + "',Alias='" + uAlias.txt.Text
                        + "',PrintName='" + uPrintName.txt.Text
                        + "',GroupSNo=" + uSearchGroup.txtCode.Text
                        + ",BrandSNo=" + uSearchBrand.txtCode.Text
                        + ",Unit='" + uSearchUnit.txt.Text
                        + "',AltUnit='" + uSearchAtlUnit.txt.Text
                        + "',Conv=" + uConversion.txt.Text
                        + ",PurchRate=" + val(uPurchRate.txt.Text)
                        + ",PurchDisc=" + val(uPurchDisc.txt.Text)
                        + ",PPer=" + val(uPPer.txt.Text)
                        + ",SaleRate=" + val(uSaleRate.txt.Text)
                        + ",TPRate=" + val(uTPRate.txt.Text)
                        + ",SaleDisc=" + val(uSaleDisc.txt.Text)
                        + ",PPer2=" + val(uPPer2.txt.Text)
                        + ",SaleRate2=" + val(uSaleRate2.txt.Text)
                        + ",TPRate2=" + val(uTPRate2.txt.Text)
                        + ",SaleDisc2=" + val(uSaleDisc2.txt.Text)
                        + ",MRP=" + val(uMRP.txt.Text)
                        + ",HSNCode='" + uHSNCode.txt.Text
                        + "',TaxCategory='" + uSearchTax.txt.Text
                        + "',TaxType='" + uSearchGSTType.txt.Text
                        + "',CGST=" + val(uCGST.txt.Text)
                        + ",SGST=" + val(uSGST.txt.Text)
                        + ",IGST=" + val(uIGST.txt.Text)
                        + ",Cess=" + val(uCess.txt.Text)
                        + ",TaxOnMRP='" + uSearchTaxOnMRP.txt.Text
                        + "',TaxCalculation='" + uSearchTaxCalculation.txt.Text
                        + "',StockLocation='" + uSearchStockLocation.txt.Text
                        + "' where SNo=" + val(uctxtSNo.txt.Text) + "";
                        cmd = new SqlCommand(sql , Globals.con);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        Globals.msgbox(this , "Item Updated.");
                        ClearMe();
                        btnList_Click(sender , e);
                    }
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
            uSearchGSTType.txt.Text = "Goods";
            uSearchTaxOnMRP.txt.Text = "No";
            uSearchTaxCalculation.txt.Text = "On Value";
        }
        private void btnList_Click(object sender , EventArgs e)
        {
            pList.Visible = true;
            uName.txt.Tag = "Text";
            btnShow_Click(sender , e);
            uSearch.txt.Focus();
        }
        private double val(object value)
        {
            if (value.ToString().Trim() == "") { value = "0"; }
            return Convert.ToDouble(value);
        }

        private void btnShow_Click(object sender , EventArgs e)
        {
            string SNum = "Row_Number() over(order by I.ItemName) as [S.No.]";
            sql = "select I.SNo," + SNum + ",I.ItemName as [Item Name],G.MName as [Group Name],B.MName as [Brand Name],I.Unit,I.SaleRate2 as [Retail S.Rate],I.SaleDisc2 [Retail S.Disc],I.TaxCategory from (m_item I left join m_Master G on i.GroupSno=G.SNo) left join M_Master B on I.BrandSno=B.Sno where ItemName Like '%" + uSearch.txt.Text + "%'";
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
            gList.Columns[0].Visible = false;
            gList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[1].Width = 60;
            //gList.Columns[2].Width = 300;
            //gList.Columns[3].Width = 300;


        }
        private void gList_DoubleClick(object sender , EventArgs e)
        {
            //if (gList.Rows.Count > 0 && (CurrentRow>=0 && CurrentRow<gList.Rows.Count))
            //{                
            //    pList.Visible = false;
            //    status = "edit";               
            //    uctxtSNo.txt.Text = gList.Rows[CurrentRow].Cells[0].Value.ToString();
            //    PrevRec();
            //    uName.Focus();
            //}
        }
        private void PrevRec()
        {
            sql = "select I.*,G.MName as GName,B.MName as BName from (m_item I left join m_Master G on i.GroupSno=G.SNo) left join M_Master B on I.BrandSno=B.Sno where I.SNo= " + uctxtSNo.txt.Text + "";
            cmd = new SqlCommand(sql , Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                uName.txt.Text = rd["ItemName"].ToString();
                uAlias.txt.Text = rd["Alias"].ToString();
                uPrintName.txt.Text = rd["PrintName"].ToString();
                uSearchGroup.txt.Text = rd["GName"].ToString();
                uSearchGroup.txtCode.Text = rd["GroupSNo"].ToString();
                uSearchBrand.txt.Text = rd["BName"].ToString();
                uSearchBrand.txtCode.Text = rd["BrandSno"].ToString();
                uSearchUnit.txt.Text = rd["Unit"].ToString();
                uSearchAtlUnit.txt.Text = rd["AltUnit"].ToString();
                uConversion.txt.Text = rd["Conv"].ToString();
                uHSNCode.txt.Text = rd["HSNCode"].ToString();
                uSearchGSTType.txt.Text = rd["TaxType"].ToString();
                uSearchTax.txt.Text = rd["TaxCategory"].ToString();
                uCGST.txt.Text = rd["CGST"].ToString();
                uSGST.txt.Text = rd["SGST"].ToString();
                uIGST.txt.Text = rd["IGST"].ToString();
                uCess.txt.Text = rd["Cess"].ToString();
                uPurchRate.txt.Text = rd["PurchRate"].ToString();
                uPurchDisc.txt.Text = rd["PurchDisc"].ToString();
                uPPer.txt.Text = rd["PPer"].ToString();
                uSaleRate.txt.Text = rd["SaleRate"].ToString();
                uTPRate.txt.Text = rd["TPRate"].ToString();
                uSaleDisc.txt.Text = rd["SaleDisc"].ToString();
                uPPer2.txt.Text = rd["PPer2"].ToString();
                uSaleRate2.txt.Text = rd["SaleRate2"].ToString();
                uTPRate2.txt.Text = rd["TPRate2"].ToString();
                uSaleDisc2.txt.Text = rd["SaleDisc2"].ToString();
                uMRP.txt.Text = rd["MRP"].ToString();
                uSearchTaxOnMRP.txt.Text = rd["TaxOnMRP"].ToString();
                uSearchTaxCalculation.txt.Text = rd["TaxCalculation"].ToString();
                uSearchStockLocation.txt.Text = rd["StockLocation"].ToString();
            }
            cmd.Dispose();
            rd.Close();
        }
        private void uSearch_TextChanged(object sender , EventArgs e)
        {
            //btnSave_Click(sender , e);
            dv.RowFilter = "[Item Name] like '%" + uSearch.txt.Text + "%'";
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
                gList_CellDoubleClick(sender , new DataGridViewCellEventArgs(0 , 0));
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
            //if (gList.Rows.Count > 0)
            //{
            //    CurrentRow = gList.CurrentRow.Index;
            //}
        }

        private void uSearch_Load(object sender , EventArgs e)
        {

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
                if (Globals.msgbox(this , "Are You Sure To Delete?" , "YesNo;Center") == 1)
                {
                    Globals.DeleteRecord("m_Item" , gList.Rows[CurrentRow].Cells[0].Value);
                    btnShow_Click(sender , e);
                }
            }
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
                uName.txt.Tag = "Text,Require";
                uName.Focus();
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
            else if (e.Control && e.KeyCode == Keys.M)
            {
                lblMin_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                lblMax_Click(sender, e);
            }
        }
        private void uCGST_KeyDown(object sender , KeyEventArgs e)
        {

        }

        private void uCGST_Leave(object sender , EventArgs e)
        {

        }

        private void uCGST_TextChanged(object sender , EventArgs e)
        {

        }
        private void uSearchGroup_Load(object sender , EventArgs e)
        {
            Globals.LoadList(this , uSearchGroup.lstName , "m_master" , "ItemGroup");
        }
        private void uSearchBrand_Load(object sender , EventArgs e)
        {
            //uSearchBrand.lstName.DataSource = Globals.LoadList(this , "m_master" , "ItemBrand");
            Globals.LoadList(this , uSearchBrand.lstName , "m_master" , "ItemBrand");
        }
        private void uSearchUnit_Load(object sender , EventArgs e)
        {
            Globals.LoadList(this , uSearchUnit.lstName , "m_master" , "ItemUnit");
        }
        private void uSearchTax_Load(object sender , EventArgs e)
        {
            Globals.LoadList(this , uSearchTax.lstName , "m_master" , "TaxCategory");
        }
        private void uSearchGSTType_Load(object sender , EventArgs e)
        {
            Globals.LoadList(this , uSearchGSTType.lstName , "m_master" , "GSTType");
        }
        private void uSearchAtlUnit_Load(object sender , EventArgs e)
        {
            Globals.LoadList(this , uSearchAtlUnit.lstName , "m_master" , "ItemUnit");
        }

        private void uSearchTaxOnMRP_Load(object sender , EventArgs e)
        {
            Globals.LoadList(this , uSearchTaxOnMRP.lstName , "m_master" , "YesNo");
        }

        private void uSearchTaxCalculation_Load(object sender , EventArgs e)
        {
            uSearchTaxCalculation.lstName.Items.Clear();
            ucSearchList.MList lst = new ucSearchList.MList();
            lst.Code = 0; lst.Name = "None";
            uSearchTaxCalculation.lstName.Items.Add(lst);
            lst = new ucSearchList.MList();
            lst.Code = 1; lst.Name = "On Value";
            uSearchTaxCalculation.lstName.Items.Add(lst);
            lst = new ucSearchList.MList();
            lst.Code = 2; lst.Name = "On Rate";
            uSearchTaxCalculation.lstName.Items.Add(lst);
            uSearchTaxCalculation.lstName.ClearSelected();


        }
        private void uSearchStockLocation_Load(object sender , EventArgs e)
        {
            Globals.LoadList(this , uSearchStockLocation.lstName , "m_master" , "Warehouse");
        }

        private void uSearchTax_Leave(object sender , EventArgs e)
        {
            cmd = new SqlCommand("Select CGST,SGST,IGST,Cess From m_master where mType='TaxCategory' and SNo=" + val(uSearchTax.txtCode.Text) + "" , Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                uCGST.txt.Text = rd["CGST"].ToString();
                uSGST.txt.Text = rd["SGST"].ToString();
                uIGST.txt.Text = rd["IGST"].ToString();
                uCess.txt.Text = rd["Cess"].ToString();
            }
            cmd.Dispose();
            rd.Close();
        }

        private void pbase1_Paint(object sender , PaintEventArgs e)
        {

        }

        private void gList_CellClick(object sender , DataGridViewCellEventArgs e)
        {
            if (gList.Rows.Count > 0)
            {
                CurrentRow = gList.CurrentRow.Index;
            }
        }

        private void gList_CellDoubleClick(object sender , DataGridViewCellEventArgs e)
        {
            if (gList.Rows.Count > 0 && (CurrentRow >= 0 && CurrentRow < gList.Rows.Count))
            {
                pList.Visible = false;
                status = "edit";
                uctxtSNo.txt.Text = gList.Rows[CurrentRow].Cells[0].Value.ToString();
                PrevRec();
                uName.Focus();
            }
        }

        private void gList_CellContentClick(object sender , DataGridViewCellEventArgs e)
        {

        }

        private void uPPer_Load(object sender , EventArgs e)
        {

        }

        private void uPPer_Leave(object sender , EventArgs e)
        {
            if (val(uPPer.txt.Text) > 0)
            {
                double pr = val(uPurchRate.txt.Text);
                double pd = val(uPurchDisc.txt.Text);
                double pp = val(uPPer.txt.Text);
                uSaleRate.txt.Text = ((pr - pd) + (pr - pd) * pp / 100).ToString();
            }
        }

        private void uPPer2_Load(object sender , EventArgs e)
        {

        }

        private void uPPer2_Leave(object sender , EventArgs e)
        {
            if (val(uPPer2.txt.Text) > 0)
            {
                double sr = val(uSaleRate.txt.Text);
                double pp = val(uPPer2.txt.Text);
                uSaleRate2.txt.Text = (sr + (sr * pp / 100)).ToString();
            }
        }

        private void uSaleRate_Leave(object sender , EventArgs e)
        {
            if (val(uSaleRate.txt.Text) > 0)
            {
                double TaxAmt = 0;
                double CessAmt = 0;
                TaxAmt = (val(uSaleRate.txt.Text) * val(uIGST.txt.Text) / 100);
                CessAmt = (TaxAmt * val(uCess.txt.Text) / 100);
                uTPRate.txt.Text = (val(uSaleRate.txt.Text) + TaxAmt + CessAmt).ToString();
            }
        }

        private void uSaleRate2_Load(object sender , EventArgs e)
        {

        }

        private void uSaleRate2_Leave(object sender , EventArgs e)
        {
            uTPRate2.txt.Text = (val(uSaleRate2.txt.Text) + (val(uSaleRate2.txt.Text) * val(uIGST.txt.Text) / 100)).ToString();
        }

        private void uPurchRate_Load(object sender , EventArgs e)
        {

        }

        private void uPurchDisc_Load(object sender , EventArgs e)
        {

        }

        private void uPPer_TextChanged(object sender , EventArgs e)
        {
            if (val(uPPer.txt.Text) > 0)
            {
                double pr = val(uPurchRate.txt.Text);
                double pd = val(uPurchDisc.txt.Text);
                double pp = val(uPPer.txt.Text);
                uSaleRate.txt.Text = ((pr - pd) + (pr - pd) * pp / 100).ToString();
            }
        }

        private void uSaleRate_Load(object sender , EventArgs e)
        {

        }

        private void uSaleRate_TextChanged(object sender , EventArgs e)
        {
            if (val(uSaleRate.txt.Text) > 0)
            {
                double TaxAmt = 0;
                double CessAmt = 0;
                TaxAmt = (val(uSaleRate.txt.Text) * val(uIGST.txt.Text) / 100);
                CessAmt = (TaxAmt * val(uCess.txt.Text) / 100);
                uTPRate.txt.Text = (val(uSaleRate.txt.Text) + TaxAmt + CessAmt).ToString();
            }
        }

        private void uPPer2_TextChanged(object sender , EventArgs e)
        {
            if (val(uPPer2.txt.Text) > 0)
            {
                double sr = val(uSaleRate.txt.Text);
                double pp = val(uPPer2.txt.Text);
                uSaleRate2.txt.Text = (sr + (sr * pp / 100)).ToString();
            }
        }
    }
}
