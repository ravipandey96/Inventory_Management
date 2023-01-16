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
    public partial class frmUnit : Form
    { 
        bool drag = false;
        Point Start_Point = new Point(0 , 0);
        Point Store_Location=new Point(0,0);
        Size Store_Size=new Size(0,0);
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
        public frmUnit()
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

            if (Globals.MinFormLocation.Rows.Count-1==0) 
            {   
                this.Location = new Point(left,top);
                Globals.MinFormLocation.Rows.Add(left,top);
            }
            else
            {  
                bool exist=false;
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
                    if(exist == false)
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
                for (int i = 0 ; i < Globals.MinFormLocation.Rows.Count-1 ; i++)
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
            utxtName.txt.Tag = "Text";
            utxtFName.txt.Tag = "Text";
            utxtCUnit.txt.Tag = "Text";
            status = "add";
            FormMode = "Max";     
            //Form Position     
            lblBorderBottom.Height = 2;
            lblBorderLeft.Width = 2;
            lblBorderRight.Width = 2;
            this.Location = new Point((x - this.Width) / 2 , (y - this.Height - frm.MainMenuStrip.Height) / 2);
            pbase.Left=(this.Width-pbase.Width)/ 2;
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

        private void frmUnit_KeyPress(object sender , KeyPressEventArgs e)
        {
        }

        private void btnSave_Click(object sender , EventArgs e)
        {
            try
            {
                if (utxtName.txt.Text.Trim() == "")
                {
                    Globals.msgbox(this , lblTitleBar.Text + " Name Can't be Empty.");
                    utxtName.Focus();
                    return;
                }

                btnSave.Enabled = false;
                if (status == "add")
                {
                    if (Globals.chkRecord("M_Master" , "MName='" + utxtName.txt.Text.Trim() + "' and MType = '" + this.Text + "'"))
                    {
                        Globals.msgbox(this , "This " + lblTitleBar.Text + " Already Exists");
                        utxtName.Focus();
                    }
                    else
                    {
                        uctxtSNo.txt.Text = Globals.MaxCode("M_Master" , "SNo").ToString();
                        sql = "insert into M_Master(SNo,MType,MName,Desc1,Unit1) values(" +
                        val(uctxtSNo.txt.Text)
                        + ",'" + this.Text
                        + "','" + utxtName.txt.Text
                        + "','" + utxtFName.txt.Text
                        + "','" + utxtCUnit.txt.Text + "')";
                        cmd = new SqlCommand(sql , Globals.con);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        Globals.msgbox(this , lblTitleBar.Text + " Saved.");
                        ClearMe();
                        utxtName.Focus();
                    }
                }
                else
                {
                    if (Globals.chkRecord("M_Master" , "MName='" + utxtName.txt.Text.Trim() + "' and MType = '" + this.Text + "' and SNo<>"+val(uctxtSNo.txt.Text)+""))
                    {
                        Globals.msgbox(this , "This " + lblTitleBar.Text + " Already Exists");
                        utxtName.Focus();
                    }
                    else
                    {
                        sql = "update M_Master set MName='" + utxtName.txt.Text
                        + "',Desc1='" + utxtFName.txt.Text
                        + "',Unit1='" + utxtCUnit.txt.Text
                        + "' where MType='" + this.Text + "' and SNo=" + val(uctxtSNo.txt.Text) + "";
                        cmd = new SqlCommand(sql , Globals.con);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        Globals.msgbox(this , lblTitleBar.Text + " Updated.");
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
            utxtName.txt.ReadOnly = false;
            status = "add";
            Globals.ClearAllFields(this);
        }
        private void btnList_Click(object sender , EventArgs e)
        {
            pList.Visible = true;
            utxtName.txt.Tag = "Text";
            btnShow_Click(sender , e);
            uSearch.txt.Focus();
        }
        private double val(object value)
        {if (value.ToString().Trim() == "") { value = "0"; }
            return Convert.ToDouble(value);}
        private void btnShow_Click(object sender , EventArgs e)
        {
            //int i = 0;
            sql = "Select SNo,Row_Number() over(order by MName) as [S.No.] ,MName as [Short Name],Desc1 as [Full Name],Unit1 as Conversion from m_master where MType='" + this.Text+"' and MName like '%"+uSearch.txt.Text.Trim()+"%' order by MName";
            cmd = new SqlCommand(sql , Globals.con);
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
            gList.Columns[1].Width = 100;
            gList.Columns[2].Width = 300;
            gList.Columns[3].Width = 300;
            gList.Columns[4].Width = 300;
        }
        private void gList_DoubleClick(object sender , EventArgs e)
        {
            if (gList.Rows.Count > 0 && CurrentRow>=0)
            {
                pList.Visible = false;
                status = "edit";               
                uctxtSNo.txt.Text = gList.Rows[CurrentRow].Cells[0].Value.ToString();
                PrevRec();
                utxtName.Focus();
            }
        }
        private void PrevRec()
        {          
            sql = "Select SNo,MType,MName,Desc1,Unit1 from m_master where MType='" + this.Text + "' and SNo=" + int.Parse(uctxtSNo.txt.Text) + "";
            cmd = new SqlCommand(sql , Globals.con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                utxtName.txt.Text = rd["MName"].ToString();
                utxtFName.txt.Text = rd["Desc1"].ToString();
                utxtCUnit.txt.Text = rd["Unit1"].ToString();
            }
            cmd.Dispose();
            rd.Close();
        }
        private void uSearch_TextChanged(object sender , EventArgs e)
        {           
                //btnSave_Click(sender , e);
                dv.RowFilter = "[Short Name] like '%" + uSearch.txt.Text + "%'";
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

        private void uSearch_Load(object sender , EventArgs e)
        {

        }

        private void utxtCUnit_Load(object sender , EventArgs e)
        {

        }

        private void utxtCUnit_KeyDown(object sender , KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender , e);
            }
        }

        private void gList_KeyDown(object sender , KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            gList_DoubleClick(sender , e);
        }

        private void btnDelete_Click(object sender , EventArgs e)
        {
            if (gList.Rows.Count > 0 && (CurrentRow>=0 && CurrentRow < gList.Rows.Count))
            {
                Globals.DeleteRecord("m_master",gList.Rows[CurrentRow].Cells[0].Value);
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
                utxtName.txt.Tag = "Text,Require";
                utxtName.Focus();
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

        private void utxtName_Load(object sender, EventArgs e)
        {

        }
    } }
