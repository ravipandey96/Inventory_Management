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
    public partial class frmRawMaterial : Form
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
        public frmRawMaterial()
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
            //usUnit.txt.Tag = "SearchList,Require";
            //uctxtName.txt.Tag = "Text,Require";
            //usTaxType.txt.Tag = "SearchList,Require";
            uctxtCgst.Enabled = false;
            uctxtSgst.Enabled = false;
            uctxtIgst.Enabled = false;

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
            try
            {

                if (uctxtName.txt.Text.Trim() != "" && usTaxType.txt.Text!="")
                {
                    btnSave.Enabled = false;
                    if (status == "add")
                    {
                        uctxtSNo.txt.Text = Globals.MaxCode("m_raw", "SNo").ToString();
                        long sno = long.Parse(uctxtSNo.txt.Text);
                        sql = "insert into m_raw(SNo,Item_Name,Alias,PrintName,Unit,Thickness,Grade,Rate,HSNCODE,TaxType,CGST,SGST,IGST,Cess) values(" +
                        sno
                        + ",'" + uctxtName.txt.Text
                        + "','" + uctxtAlias.txt.Text
                        + "','" + uctxtPrint.txt.Text
                        + "'," + val(usUnit.txtCode.Text)
                        + ",'" + uctxtThickness.txt.Text
                        + "','" + uctxtGrade.txt.Text
                        + "'," + val(uctxtRate.txt.Text)
                        + ",'" + uctxtHSNCODE.txt.Text
                        + "','" + usTaxType.txt.Text
                        + "'," + val(uctxtCgst.txt.Text)
                        + "," + val(uctxtSgst.txt.Text)
                        + "," + val(uctxtIgst.txt.Text)
                        + "," + val(uctxtCess.txt.Text) + ")";
                        cmd = new SqlCommand(sql, Globals.con);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        Globals.msgbox(this, lblTitleBar.Text + " Saved.");
                        ClearMe();                  
                    }
                    else
                    {
                        sql = "update m_raw set Item_Name='" + uctxtName.txt.Text
                           + "', Alias='" + uctxtAlias.txt.Text
                           + "', PrintName='" + uctxtPrint.txt.Text
                           + "', Unit=" + val(usUnit.txtCode.Text)
                           + ", Thickness='" + uctxtThickness.txt.Text
                           + "', Grade='" + uctxtGrade.txt.Text
                           + "', Rate=" + val(uctxtRate.txt.Text)
                           + ", HSNCODE='" + uctxtHSNCODE.txt.Text
                           + "', TaxType='" + usTaxType.txt.Text
                           + "', CGST=" + val(uctxtCgst.txt.Text)
                           + ", SGST=" + val(uctxtSgst.txt.Text)
                           + ", IGST=" + val(uctxtIgst.txt.Text)
                           + ",Cess=" + val(uctxtCess.txt.Text)
                           + " where SNo=" + val(uctxtSNo.txt.Text) + "";
                        cmd = new SqlCommand(sql, Globals.con);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        Globals.msgbox(this, lblTitleBar.Text + " Updated.");
                        ClearMe();
                        btnList_Click(sender, e);
                    }
                }
                else
                {
                    Globals.msgbox(this, "Enter Materials Name or Tax.");
                }
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                Globals.msgbox(this, ex.Message);
            }
            btnSave.Enabled = true;

        }
        private void ClearMe()
        {
            Globals.ClearAllFields(this);
            status = "add";
            uctxtName.Focus();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            pList.Visible = true;
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
            sql = "Select r.Sno,Row_Number() over(order by Item_Name) as [S.No.],Item_Name as [Item Name],Thickness,m.MName as unit,Rate,HSNCODE as HSN,r.TaxType from m_raw r left join m_master m on m.MType='ItemUnit' and r.unit=m.SNo where Item_Name like '%" + uSearch.txt.Text.Trim() + "%' order by Item_Name";
            cmd = new SqlCommand(sql, Globals.con);

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
            uSearch.txt.Focus();
        }
        private void gFormat()
        {
            gList.Columns[0].Visible = false;
            gList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[1].Width = 40;
            gList.Columns[2].Width = 150;
            gList.Columns[3].Width = 80;
            gList.Columns[4].Width = 70;
            gList.Columns[5].Width = 70;
            gList.Columns[6].Width = 70;
            gList.Columns[7].Width = 100;
        }
        private void gList_DoubleClick(object sender, EventArgs e)
        {
            if (gList.Rows.Count > 0 && CurrentRow >= 0)
            {
                pList.Visible = false;
                status = "edit";
                uctxtSNo.txt.Text = gList.Rows[CurrentRow].Cells[0].Value.ToString();
                PrevRec();
                uctxtName.Focus();
            }
        }
        private void PrevRec()
        {
            sql = "Select r.*,m.MName as Uname from m_raw r left join m_master m on m.MType='ItemUnit' and r.unit=m.SNo where r.SNo=" + (uctxtSNo.txt.Text) + "";
            //SNo,Item_Name,Unit,Qty,Rate,HSNCODE,IGST,TCS
            cmd = new SqlCommand(sql, Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                //       uDate.date.Value = DateTime.Parse(rd["vdate"].ToString());
                uctxtName.txt.Text = rd["Item_Name"].ToString();
                uctxtAlias.txt.Text = rd["Alias"].ToString();
                uctxtPrint.txt.Text = rd["PrintName"].ToString();
                usUnit.txt.Text = rd["Uname"].ToString();
                uctxtThickness.txt.Text = rd["Thickness"].ToString();
                uctxtGrade.txt.Text = rd["Grade"].ToString();
                uctxtRate.txt.Text = rd["Rate"].ToString();
                uctxtHSNCODE.txt.Text = rd["HSNCODE"].ToString();
                usTaxType.txt.Text = rd["TaxType"].ToString();
                uctxtCgst.txt.Text = rd["CGST"].ToString();
                uctxtSgst.txt.Text = rd["SGST"].ToString();
                uctxtIgst.txt.Text = rd["IGST"].ToString();
                uctxtCess.txt.Text = rd["Cess"].ToString();
            }
            cmd.Dispose();
            rd.Close();
        }
        private void uSearch_TextChanged(object sender, EventArgs e)
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
                if (Globals.msgbox(this, "Are You Sure To Delete Selected Record ?", "YesNo") == 1)
                {
                    Globals.DeleteRecord("m_raw", gList.Rows[CurrentRow].Cells[0].Value);
                    btnShow_Click(sender, e);
                }
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
        
        private void frmBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && pList.Visible == false)
            {
                this.Dispose();
            }
            else if (e.KeyCode == Keys.Escape && pList.Visible == true)
            {
                pList.Visible = false;
                uctxtName.Focus();
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
            else if (e.Control && e.KeyCode == Keys.M)
            {
                lblMin_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                lblMax_Click(sender, e);
            }
        }

        private void usRType_Load(object sender, EventArgs e)
        {


     //       string[] post = { "GST FREE", "Nil-Rated","GST 5%", "GST 12%","GST 18%","GST 28%" };
            Globals.LoadList(this, usTaxType.lstName, "m_master", "TaxCategory");
            // Ensure the form opens with no rows selected.               

        }
        // Ensure the form opens with no rows selected.               
        //usType.lstName.ClearSelected();
        private void usUnit_Load(object sender, EventArgs e)
        {


            //string[] post = { "GST FREE", "Nil-Rated", "GST 5%", "GST 12%", "GST 18%", "GST 28%" };
            Globals.LoadList(this, usUnit.lstName, "m_master", "ItemUnit");
            // Ensure the form opens with no rows selected.               

        }

        private void usTaxType_Load(object sender, EventArgs e)
        {
            Globals.LoadList(this, usTaxType.lstName, "m_master", "TaxCategory");
        }

        private void usTaxType_Leave(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select CGST,SGST,IGST,Cess From m_master where mType='TaxCategory' and SNo=" + val(usTaxType.txtCode.Text) + "", Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                uctxtCgst.txt.Text = rd["CGST"].ToString();
                uctxtSgst.txt.Text = rd["SGST"].ToString();
                uctxtIgst.txt.Text = rd["IGST"].ToString();
                uctxtCess.txt.Text = rd["Cess"].ToString();
            }
            cmd.Dispose();
            rd.Close();
        }

        private void gList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
    }
//}

