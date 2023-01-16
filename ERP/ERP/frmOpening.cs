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
    public partial class frmOpening : Form
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
        public frmOpening()
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

           
            FormMode = "Max";
            int ht = btnSave.Top - (usItem.Top + usItem.Height);
            usItem.txt.Tag = "SearchList,AutoHeight:false,Height:" + ht + ",";

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
            
            usItemType.txt.Text = "Finished Good";
            ClearMe();
        }

        private void frmUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((val(uctxtRegular.txt.Text) + val(uctxtBIS.txt.Text))==0)
            {
                Globals.msgbox(this,"Please Enter Quantity.");
                uctxtRegular.Focus();
                return;
            }

            try
            {           
                btnSave.Enabled = false;
                if (status == "add")
                {
                    uctxtSNo.txt.Text = Globals.MaxCode("m_Item_Opening", "SNo").ToString();
                    sql = "insert into m_Item_Opening(SNo,Item_Type,INo,OpStock,OpValue,VDate,OpRate,BIS,R_Qty,Regular) values(" +
                    val(uctxtSNo.txt.Text)
                    + ",'" + usItemType.txt.Text
                    + "'," + val(usItem.txtCode.Text)
                    + "," + (val(uctxtBIS.txt.Text) + val(uctxtRegular.txt.Text))
                    + "," + (val(uctxtBIS.txt.Text) + val(uctxtRegular.txt.Text)) * val(uctxtRate.txt.Text)
                    + ",'" + uDate.date.Value.ToString("yyyy-MM-dd")
                    + "'," + val(uctxtRate.txt.Text)
                    + "," + val(uctxtBIS.txt.Text)
                    + "," + (usItemType.txt.Text.ToUpper() == "RAW MATERIAL" ? val(uctxtRegular.txt.Text) : 0)
                    + "," + (usItemType.txt.Text.ToUpper() == "FINISHED GOOD" ? val(uctxtRegular.txt.Text) : 0) + ")";
                    cmd = new SqlCommand(sql, Globals.con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Globals.msgbox(this, usItemType.txt.Text + "\n\n Opening Stock Saved.");
                    ClearMe();
                    uDate.Focus();
                }
                else
                {
                    sql = "update m_Item_Opening set vdate='" + uDate.date.Value.ToString("yyyy-MM-dd hh:mm:ss tt") + "',OpStock=" + (val(uctxtBIS.txt.Text) + val(uctxtRegular.txt.Text)) + ",OpValue=" + (val(uctxtBIS.txt.Text) + val(uctxtRegular.txt.Text)) * val(uctxtRate.txt.Text) + ",OpRate=" + val(uctxtRate.txt.Text) + ",BIS=" + val(uctxtBIS.txt.Text) + ",regular=" + (usItemType.txt.Text.ToUpper() == "FINISHED GOOD" ? val(uctxtRegular.txt.Text) : 0) + ",R_Qty=" + (usItemType.txt.Text.ToUpper() == "RAW MATERIAL" ? val(uctxtRegular.txt.Text) : 0) + ",Item_Type='" + usItemType.txt.Text + "' where SNo=" + val(uctxtSNo.txt.Text) + "";
                    cmd = new SqlCommand(sql, Globals.con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Globals.msgbox(this, usItemType.txt.Text + "\n\n Opening Stock Updated.");
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
            status = "add";
            usItemType.Enabled = true;
            usItem.Enabled = true;
            usItem.txt.Text = "";
            usItemType_Leave(new object(),new EventArgs());
            
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            pList.Visible = true;
            usTypeItem.txt.Text = usItemType.txt.Text;
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
            string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, io.VDate), 0))";
            if (usTypeItem.txt.Text.ToUpper() == "RAW MATERIAL")
            {  
                sql = "Select io.SNo,convert(varchar,io.VDate,103) as date,r.Item_Name,io.OpStock as [Opening Stock],io.BIS,io.Regular,R_Qty as Quantity from m_Item_Opening io left join m_raw r on io.INo=r.SNo where (" + VDate + " >='" + uFrom.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + "<='" + uTo.date.Value.ToString("yyyy-MM-dd") + "') and io.Item_Type='Raw Material' and r.Item_Name like '%" + uSearch.txt.Text.Trim() + "%'  order by r.Item_Name ";
            }
            else 
            {
                sql = "Select io.SNo,convert(varchar,io.VDate,103) as Date,f.Thickness as Item_Name,io.OpStock as [Opening Stock],io.BIS,io.Regular,R_Qty as Quantity from m_Item_Opening io left join finished f on io.INo=f.SNo where (" + VDate + " >='" + uFrom.date.Value.ToString("yyyy-MM-dd") + "' and " + VDate + "<='" + uTo.date.Value.ToString("yyyy-MM-dd") + "') and io.Item_Type='Finished Good' and f.Item_Name like '%" + uSearch.txt.Text.Trim() + "%'  order by f.Thickness ";
            }
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
            gList.Columns[1].Width = 100;
            gList.Columns[2].Width = 200;
            gList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[3].Width = 150;
            //gList.Columns[4].Width = 75;
            //gList.Columns[5].Width = 75;
            //gList.Columns[6].Width = 75;

            if (usTypeItem.txt.Text.ToUpper() == "RAW MATERIAL")
            {
                gList.Columns[4].Visible = false;
                gList.Columns[5].Visible = false;
                gList.Columns[6].Visible = true;
            }
            else // finish goods
            {
                gList.Columns[4].Visible = true;
                gList.Columns[5].Visible = true;
                gList.Columns[6].Visible = false;
            }
        }

        private void gList_DoubleClick(object sender, EventArgs e)
        {
            if (gList.Rows.Count > 0 && CurrentRow >= 0)
            {
                pList.Visible = false;
                status = "edit";
                uctxtSNo.txt.Text = gList.Rows[CurrentRow].Cells[0].Value.ToString();
                usItemType.txt.Text = usTypeItem.txt.Text;
                usItemType_Leave(sender, e);

                PrevRec(); 
                             
                usItemType.Enabled = false;
                usItem.Enabled = false;                
                uDate.Focus();
            }
        }
        private void PrevRec()
        {
            
            if (usItemType.txt.Text.ToUpper() == "RAW MATERIAL")
            {
                sql = "Select o.SNo,o.R_Qty,o.Item_Type,o.INo,o.Vdate,o.OpRate,f.Item_Name from m_Item_Opening o left join m_raw f on f.SNo=o.INo where o.SNo=" + val(uctxtSNo.txt.Text) + " and o.INo=f.SNo and o.Item_Type='Raw Material'";
            }
            else
            {
                sql = "Select o.SNo,o.OpStock,o.Item_Type,o.INo,o.Vdate,o.OpRate,o.Regular,o.BIS,f.Thickness as Item_Name from m_Item_Opening o left join Finished f on f.SNo=o.INo where o.SNo=" + val(uctxtSNo.txt.Text) + " and o.INo=f.SNo and o.Item_Type='Finished Good'";               
            }
            cmd = new SqlCommand(sql, Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                if (usItemType.txt.Text.ToUpper() == "RAW MATERIAL")
                {
                    uctxtRegular.txt.Text = rd["R_Qty"].ToString();
                    uctxtBIS.txt.Text = "";
                }
                else
                {
                    uctxtRegular.txt.Text = rd["Regular"].ToString();
                    uctxtBIS.txt.Text = rd["BIS"].ToString();
                }
                             
                    usItem.txt.Text = rd["Item_Name"].ToString();
                    usItem.txtCode.Text = rd["INo"].ToString();
                    uDate.date.Value = DateTime.Parse(rd["VDate"].ToString());
                    uctxtRate.txt.Text = rd["OpRate"].ToString();                        
            }
            cmd.Dispose();
            rd.Close();      
        }
        private void uSearch_TextChanged(object sender, EventArgs e)
        {
            //btnSave_Click(sender , e);            
            dv.RowFilter = "[Item_Name] like '%" + uSearch.txt.Text + "%'";
                      
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
                    Globals.DeleteRecord("m_Item_Opening", gList.Rows[CurrentRow].Cells[0].Value);
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
           
             // Ensure the form opens with no rows selected.               
             //usType.lstName.ClearSelected();
        }

        private void usItemType_Load(object sender, EventArgs e)
        {
            string[] post = { "Raw Material", "Finished Good" };
            Globals.LoadList2(this, usItemType.lstName, post);
        }

        private void usItem_Leave(object sender, EventArgs e)
        {
                       
        }
        
        private void usItemType_Leave(object sender, EventArgs e)
        {
            if (usItemType.txt.Text.Trim().ToUpper() == "RAW MATERIAL")
            {
                Globals.LoadList(this, usItem.lstName, "Select SNo,Item_Name,Rate from m_raw order by Item_Name");
                usItem.txt.Text = "";
                uctxtBIS.txt.Text = "";
                uctxtBIS.Visible = false;
                lblBIS.Visible = false;
                lblRegular.Text = "Quantity";
            }
            else  //Finish Goods
            {
                Globals.LoadList(this, usItem.lstName, "Select SNo,Thickness,Rate from finished order by Item_Name");
                usItem.txt.Text = "";
                uctxtBIS.Visible = true;
                lblBIS.Visible = true;
                lblRegular.Text = "Regular";
            }
        }

        private void usTypeItem_Load(object sender, EventArgs e)
        {
            string[] post = { "Raw Material", "Finished Good" };
            Globals.LoadList2(this, usTypeItem.lstName, post);
        }

        private void uctxt1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void frmOpening_Activated(object sender, EventArgs e)
        {
            
        }

        private void usTypeItem_Leave(object sender, EventArgs e)
        {
            //    gList.Columns.Clear();
            
/*            if (usTypeItem.txt.Text == "Finished Good")
            {
       //         gList.Columns[2].Visible = false;
                //        gList.Columns[3].Visible = false;
                gList.Columns[2].Width = 500;
                gList.Columns[3].Width = 100;
                gList.Columns[4].Width = 70;
                gList.Columns[5].Width = 70;
                //                gList.Columns[4].Visible = false;
                //                gList.Columns[5].Visible = false;
                //                gList.Columns[6].Visible = false;
            }
            else
            {
                gList.Columns[2].Width = 200;
                
            }  */
        }

        private void uctxtRegular_Load(object sender, EventArgs e)
        {

        }

        private void pbase_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pList_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
     