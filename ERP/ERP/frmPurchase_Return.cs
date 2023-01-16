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
    public partial class frmPurchase_Return : Form
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
        public frmPurchase_Return()
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
            usItem.txt.Tag = "SearchList";
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
            if (grdReturn.Rows.Count == 0)
            {
                Globals.msgbox(this, "Please Select Any Item");usItem.Focus();return;
            }

            try
            {
                btnSave.Enabled = false;
                if (status == "add")
                {
                    uctxtVNo.txt.Text = Globals.MaxCode("Purchase_Return", "VNo").ToString();
                    if (uctxtRefNo.txt.Text.Trim() == "")
                        uctxtRefNo.txt.Text = uctxtVNo.txt.Text;

                    for (int i = 0; i < grdReturn.Rows.Count; ++i)
                    {
                        sql = "insert into Purchase_Return(SNo,VNo,Ref_No,RNo,Qty,Narration,Date) values(" +
                        (i + 1)
                        + "," + int.Parse(uctxtVNo.txt.Text)
                        + ",'" + uctxtRefNo.txt.Text
                        + "'," + int.Parse(grdReturn.Rows[i].Cells[3].Value.ToString().Trim())
                        + "," + float.Parse(grdReturn.Rows[i].Cells[5].Value.ToString().Trim())
                        + ",'" + uctxtNarration.txt.Text
                        + "','" + uDate.date.Value.ToString("yyyy-MM-dd hh:mm:ss tt") + "')";
                        cmd = new SqlCommand(sql, Globals.con);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    
                    Globals.msgbox(this, lblTitleBar.Text + " Saved.");
                    ClearMe();
                }
                else
                {
                    sql = "delete from purchase_return where VNo=" + int.Parse(uctxtVNo.txt.Text) + "";
                    cmd = new SqlCommand(sql, Globals.con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    if (uctxtRefNo.txt.Text.Trim() == "")
                        uctxtRefNo.txt.Text = uctxtVNo.txt.Text;

                    for (int i = 0; i < grdReturn.Rows.Count; ++i)
                    {
                        sql = "insert into Purchase_Return(SNo,VNo,Ref_No,RNo,Qty,Narration,Date) values (" +
                        (i + 1)
                        + "," + int.Parse(uctxtVNo.txt.Text)
                        + ",'" + uctxtRefNo.txt.Text
                        + "'," + int.Parse(grdReturn.Rows[i].Cells[3].Value.ToString().Trim())
                        + "," + float.Parse(grdReturn.Rows[i].Cells[5].Value.ToString().Trim())
                        + ",'" + uctxtNarration.txt.Text
                        + "','" + uDate.date.Value.ToString("yyyy-MM-dd hh:mm:ss tt") + "')";
                        cmd = new SqlCommand(sql, Globals.con);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
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
        private void ClearMe()
        {
            Globals.ClearAllFields(this);
            grdReturn.Rows.Clear();
            status = "add";
            usItem.txt.Text = "";
            usItem.txtCode.Text = "";
            uDate.Focus();
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
            sql = "select pr.SNo,pr.VNo,pr.Ref_No,convert(varchar,pr.date,103) as Date,r.Item_Name,pr.Qty as Quantity from purchase_Return pr left join m_raw r on pr.RNo=r.SNo where (" + VDate + " >='" + uFrom.date.Value.ToString("yyyy-MM-dd") + "' and "+ VDate +"<='" + uTo.date.Value.ToString("yyyy-MM-dd") + "') and pr.Ref_No like '%" + uSearch.txt.Text.Trim() + "%'   order by Ref_No,VNo,Date";
            cmd = new SqlCommand(sql, Globals.con);
            ad = new SqlDataAdapter(cmd);
            ds.Clear();
            ad.Fill(ds);
            dv.Table = ds.Tables[0];
            gList.DataSource = null;
            gList.DataSource = dv;
            cmd.Dispose();
            ad.Dispose();

            gFormat();

            if (gList.Rows.Count > 0)
            {
                CurrentRow = 0;
                gList.Rows[CurrentRow].Selected = true;
            }
            uSearch.Focus();
        }
        private void gFormat()
        {
            gList.Columns[0].Visible = false;
            gList.Columns[1].Visible = false;
            gList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;         
            gList.Columns[2].Width = 60;
            gList.Columns[3].Width = 80;
            //gList.Columns[4].Width = 80;
            gList.Columns[5].Width = 100;
        }
        private void gFormat1()
        {
        //    grdReturn.Columns[0].Visible = false;
        //    grdReturn.Columns[1].Visible = false;
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
        //    grdReturn.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           // grdReturn.Columns[6].Width = 150;          
        }
        private void gList_DoubleClick(object sender, EventArgs e)
        {
            if (gList.Rows.Count > 0 && CurrentRow >= 0)
            {
                pList.Visible = false;
                status = "edit";
                uctxtSNo.txt.Text = gList.Rows[CurrentRow].Cells[0].Value.ToString();
                uctxtVNo.txt.Text = gList.Rows[CurrentRow].Cells[1].Value.ToString();
                PrevRec();
                AutoNumber();
                grdReturn.Focus();
            }
        }
        private void PrevRec()
        {
            sql = "select pr.SNo,pr.VNo,pr.Date,pr.Ref_No,pr.RNo,pr.date,r.Item_Name,pr.Qty from purchase_Return pr left join m_raw r on pr.RNo=r.SNo where pr.VNo=" + val(uctxtVNo.txt.Text) + " order by pr.SNo";
            cmd = new SqlCommand(sql, Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                uDate.date.Value = DateTime.Parse(rd["Date"].ToString());
                uctxtRefNo.txt.Text = rd["Ref_No"].ToString();
            }
            cmd.Dispose();
            rd.Close();

            sql = "select pr.SNo,pr.VNo,pr.Date,pr.Ref_No,pr.RNo,pr.date,r.Item_Name,pr.Qty from purchase_Return pr left join m_raw r on pr.RNo=r.SNo where pr.VNo=" + val(uctxtVNo.txt.Text) + " order by pr.SNo";
            cmd = new SqlCommand(sql, Globals.con);
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                grdReturn.Rows.Add(rd["SNo"].ToString(), rd["VNo"].ToString(), rd["Ref_No"].ToString(), val(rd["RNo"].ToString()), rd["Item_Name"].ToString() , val(rd["Qty"].ToString()));
            }

            cmd.Dispose();
            rd.Close();
        }
        private void uSearch_TextChanged(object sender, EventArgs e)
        {
            //btnSave_Click(sender , e);
            dv.RowFilter = "[Ref_No] like '%" + uSearch.txt.Text + "%' or [Item_Name] like '%" + uSearch.txt.Text + "%'";
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
            if (gList.Rows.Count > 0 && (CurrentRow >= 0 && CurrentRow < gList.Rows.Count))
            {
                if (Globals.msgbox(this, "Are You Sure To Delete Selected Record ?", "YesNo") == 1)
                {
                    sql = "delete from purchase_return where SNo=" + int.Parse(gList.Rows[CurrentRow].Cells[0].Value.ToString().Trim()) + " and VNo=" + int.Parse(gList.Rows[CurrentRow].Cells[1].Value.ToString().Trim()) + "";
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
            }
            else if (e.KeyCode == Keys.F2 && pList.Visible == false)
            {
                uctxtNarration.Focus();
                usItem.txt.Text = "";
                usItem.txtCode.Text = "";
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
            Globals.LoadList(this, usItem.lstName, "Select SNo,Item_Name from m_raw order by Item_Name");
        }

        private void usItem_Leave(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select SNo from m_raw where Item_Name='" + usItem.txt.Text + "'", Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {                
                uctxtRNo.txt.Text = rd["SNo"].ToString();                               
            }
            cmd.Dispose();
            rd.Close();
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
            if (usItem.txt.Text.Trim() == "" || val(usItem.txtCode.Text) == 0)
            {
                Globals.msgbox(this,"Please Enter Item Description"); usItem.Focus();return;
            }

            if (val(uctxtQty.txt.Text) == 0)
            {
                Globals.msgbox(this,"Please Enter Quantity"); uctxtQty.Focus(); return;
            }

            if (status1 == "add")
            {
                grdReturn.Rows.Add(grdReturn.Rows.Count + 1, 0, 0, val(uctxtRNo.txt.Text), usItem.txt.Text, val(uctxtQty.txt.Text));
                AutoNumber();                    
            }
            else
            {
                //grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[0].Value = val(uctxtSNo.txt.Text);
                //grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[1].Value = uctxtSNo.txt.Text;
                //grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[2].Value = uctxtRefNo.txt.Text;
                grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[3].Value = val(uctxtRNo.txt.Text);
                grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[4].Value = usItem.txt.Text;              
                grdReturn.Rows[grdReturn.CurrentCell.RowIndex].Cells[5].Value = val(uctxtQty.txt.Text);
            }
            status1 = "add";
            usItem.txt.Text = "";
            usItem.txtCode.Text = "";
            uctxtQty.txt.Text = "";                
            usItem.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                grdReturn.Rows.RemoveAt(grdReturn.CurrentRow.Index);
                AutoNumber();
            }
            catch (Exception ex) { }
        }

        private void uTo_Load(object sender, EventArgs e)
        {

        }

        private void grdReturn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = grdReturn.CurrentCell.RowIndex;
            uctxtSNo.txt.Text = grdReturn.Rows[row].Cells[0].Value.ToString();
            uctxtRefNo.txt.Text = grdReturn.Rows[row].Cells[2].Value.ToString();
            uctxtRNo.txt.Text = grdReturn.Rows[row].Cells[3].Value.ToString();
            usItem.txt.Text = grdReturn.Rows[row].Cells[4].Value.ToString();
            uctxtQty.txt.Text = grdReturn.Rows[row].Cells[5].Value.ToString();
            uctxtRefNo.Enabled = false;
            status1 = "edit";
            usItem.Focus();
        }
        // Ensure the form opens with no rows selected.               
        //usType.lstName.ClearSelected();
    }
    }
//}

