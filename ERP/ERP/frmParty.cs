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
    public partial class frmParty : Form
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
        public Form _frm = null;
        public frmParty(Form frm=null)
        {            
            InitializeComponent();
            ds = new DataSet();
            dv = new DataView();
            _frm = frm;
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
        public void lblMax_Click(object sender , EventArgs e)
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
            uctxtSName.txt.Tag = "Text";
            uctxtMobileNo.txt.Tag = "Number,MobileNo";
            uctxtAddress1.txt.Tag = "Text";
            uctxtStateCode.Enabled = false;
            //comboBox2.Tag = "Selection,Require";
            //comboBox1.Tag = "Selection,Require";

            //Form Position     
            int ht = btnSave.Top - (usState.Top + usState.Height);
            usState.txt.Tag = "SearchList,AutoHeight:false,Height:" + ht + ",";

            lblClose.Top = (lblTitleBar.Height - lblClose.Height) / 2;
            lblClose.Left = this.Width - lblClose.Width - 4;
            lblMin.Top = lblClose.Top;
            lblMin.Left = lblClose.Left - lblMin.Width - 2;
            status = "add";
            FormMode = "Max";
            //Form Position     
            lblBorderBottom.Height = 2;
            lblBorderLeft.Width = 2;
            lblBorderRight.Width = 2;
            this.Location = new Point((x - this.Width) / 2 , (y - this.Height - frm.MainMenuStrip.Height) / 2);
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

        private void frmUnit_KeyPress(object sender , KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
            
        }

        private void btnSave_Click(object sender , EventArgs e)
        {
            
              try
             {
                 if (uctxtSName.txt.Text.Trim() == "")
                 {
                     Globals.msgbox(this , "Please Enter Party Name.");
                     uctxtSName.Focus();
                     return;
                 }

                 btnSave.Enabled = false;

                 if (status == "add")
                 {
                    uctxtSNo.txt.Text = Globals.MaxCode("m_party" , "SNo").ToString();
                    sql = "insert into m_party(SNo,Stype,SName,SAdd1,SAdd2,SAdd3,SMobileNo,SEmailID,SContactPerson,City,State,PanNo,GSTIN,Aadhaar,StateCode,RType,SPinCode) values(" +
                    val(uctxtSNo.txt.Text)
                    + ",'" + usPartyType.txt.Text
                    + "','" + uctxtSName.txt.Text
                    + "','" + uctxtAddress1.txt.Text
                    + "','" + uctxtAddress2.txt.Text                        
                    + "','" + uctxtAddress3.txt.Text
                    + "','" + uctxtMobileNo.txt.Text
                    + "','" + uctxtEmail.txt.Text
                    + "','" + uctxtContactPerson.txt.Text
                    + "','" + uctxtCity.txt.Text
                    + "','" + usState.txt.Text
                    + "','" + uctxtPanCardNo.txt.Text
                    + "','" + uctxtGSTIN.txt.Text
                    + "','" + uctxtAadharNo.txt.Text
                    + "','" + uctxtStateCode.txt.Text
                    + "','" + usRType.txt.Text
                    + "','" +uctxtPinCode.txt.Text + "')";
                    cmd = new SqlCommand(sql , Globals.con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Globals.msgbox(this , uctxtSName.txt.Text + " Details Saved.");

                    if (_frm != null)
                        this.Dispose();
                    ClearMe();
                 }
                 else
                 {
                    sql = "update m_party set SName='" + uctxtSName.txt.Text
                    + "',Stype='" + usPartyType.txt.Text
                    + "',SAdd1='" + uctxtAddress1.txt.Text
                    + "',SAdd2='" + uctxtAddress2.txt.Text
                    + "',SAdd3='" + uctxtAddress3.txt.Text
                    + "',SMobileNo='" + uctxtMobileNo.txt.Text
                    + "',SEmailID='" + uctxtEmail.txt.Text
                    + "',SContactPerson='" + uctxtContactPerson.txt.Text
                    + "',City='" + uctxtCity.txt.Text
                    + "',State='" + usState.txt.Text
                    + "',PanNo='" + uctxtPanCardNo.txt.Text
                    + "',GSTIN='" + uctxtGSTIN.txt.Text
                    + "',Aadhaar='" + uctxtAadharNo.txt.Text
                    + "',StateCode='" + uctxtStateCode.txt.Text
                    + "',RType='" + usRType.txt.Text
                    + "',SPinCode='" + uctxtPinCode.txt.Text
                    + "' where SNo="+val(uctxtSNo.txt.Text)+"";

                    cmd = new SqlCommand(sql , Globals.con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Globals.msgbox(this , uctxtSName.txt.Text + " Details Updated.");
                    ClearMe();
                    btnList_Click(sender , e);
                 }
             }
             catch (Exception ex)
             {
                 cmd.Dispose();
                 Globals.msgbox(this , ex.Message);
             }
             btnSave.Enabled = true;
              
        }
        private void usPartyType_Load(object sender, EventArgs e)
        {


            // Ensure the form opens with no rows selected.               

        }
        private void usRType_Load(object sender, EventArgs e)
        {              

        }
        private void ClearMe()
        {
            Globals.ClearAllFields(this);
            status = "add";
            usRType.txt.Text = "Regular";
            usPartyType.txt.Text = "Customer";
            uctxtSName.Focus();
        }
        private void btnList_Click(object sender , EventArgs e)
        {
            pList.Visible = true;
            btnShow_Click(sender , e);         
        }
        private double val(object value)
        {
            double Num = 0;
            if (Double.TryParse(value.ToString() , out Num))
            {
                return Num;
            }
            else
            {
                return 0;
            }
        }
        private void btnShow_Click(object sender , EventArgs e)
        {
            //int i = 0;
            string SNum = "Row_Number() over(order by SType,SName) as [S.No.]";
            sql = "select " + SNum + ",SNo as [ID],SName as [Party Name],Stype as [Party Type],SMobileNo as [Mobile No],SAdd1 as Address,RType as [GST Type],GSTIN from m_party where (SName Like '%" + uSearch.txt.Text + "%') order by SType,SName";

            cmd = new SqlCommand(sql , Globals.con);
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
            gList.ColumnHeadersHeight = 25;       
            gList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gList.Columns[0].Width = 30;
            gList.Columns[1].Visible = false;
            gList.Columns[2].Width = 150;
            gList.Columns[3].Width = 80;
            gList.Columns[4].Width = 100;
            //gList.Columns[5].Width = 100;
            gList.Columns[6].Width = 100;
            gList.Columns[7].Width = 160;
        }
        private void gList_DoubleClick(object sender , EventArgs e)
        {
            if (gList.Rows.Count > 0 && CurrentRow >= 0)
            {
                pList.Visible = false;
                status = "edit";
                uctxtSNo.txt.Text = gList.Rows[CurrentRow].Cells[1].Value.ToString();
                PrevRec();
                uctxtSName.Focus();
            }
        }
        private void PrevRec()
        {
            sql = "Select * from m_party where SNo=" + (uctxtSNo.txt.Text) + "";
            cmd = new SqlCommand(sql , Globals.con);
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                uctxtSName.txt.Text = rd["SName"].ToString();
                usPartyType.txt.Text = rd["Stype"].ToString();
                uctxtAddress1.txt.Text = rd["SAdd1"].ToString();
                uctxtAddress2.txt.Text = rd["SAdd2"].ToString();
                uctxtAddress3.txt.Text = rd["SAdd3"].ToString();
                uctxtMobileNo.txt.Text = rd["SMobileNo"].ToString();
                uctxtEmail.txt.Text = rd["SEmailId"].ToString();
                uctxtContactPerson.txt.Text = rd["SContactPerson"].ToString();                
                uctxtCity.txt.Text = rd["City"].ToString();
                usState.txt.Text = rd["State"].ToString();
                uctxtPanCardNo.txt.Text = rd["PanNo"].ToString();
                uctxtGSTIN.txt.Text = rd["GSTIN"].ToString();
                uctxtAadharNo.txt.Text = rd["Aadhaar"].ToString();
                uctxtStateCode.txt.Text = rd["StateCode"].ToString();
                usRType.txt.Text = rd["RType"].ToString();
                uctxtPinCode.txt.Text = rd["SPinCode"].ToString();               
            }
            cmd.Dispose();
            rd.Close();
        }
        private void uSearch_TextChanged(object sender , EventArgs e)
        {
            //btnSave_Click(sender , e);
            dv.RowFilter = "[Party Name] like '%" + uSearch.txt.Text + "%'";
            gList.DataSource = dv;
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
            try
            {
                if (gList.Rows.Count > 0)
                {
                    CurrentRow = gList.CurrentRow.Index;
                }
            }
            catch(Exception)
            {
                CurrentRow = 0;
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
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender , e);
            }
        }

        private void gList_KeyDown(object sender , KeyEventArgs e)
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
                gList_DoubleClick(sender , e);
            else if (e.Control && e.KeyCode == Keys.D && pList.Visible == true)
            {
                btnDelete_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.W && pList.Visible == true)
            {
                btnShow_Click(sender, e);
            }
        }

        private void btnDelete_Click(object sender , EventArgs e)
        {
            if (gList.Rows.Count > 0 && (CurrentRow >= 0 && CurrentRow < gList.Rows.Count))
            {
                if (Globals.msgbox(this, "Are You Sure To Delete Selected Record ?", "YesNo") == 1)
                {
                    sql = "Delete from m_party where SNo=" + int.Parse(gList.Rows[CurrentRow].Cells[1].Value.ToString().Trim());
                    SqlCommand cmd1 = new SqlCommand(sql, Globals.con);
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();
                    btnShow_Click(sender, e);
                }
            }
        }

        private void gList_CellContentClick(object sender , DataGridViewCellEventArgs e)
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

        private void frmBrand_KeyDown(object sender , KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && pList.Visible == false)
            {
                this.Dispose();
            }
            else if (e.KeyCode == Keys.Escape && pList.Visible == true)
            {
                pList.Visible = false;
                usPartyType.txt.Tag = "Text,Require";
                uctxtSName.Focus();
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

        private void pbase_Paint(object sender, PaintEventArgs e)
        {

        }

        private void usPartyType_Load_1(object sender, EventArgs e)
        {
            string[] post = { "supplier", "customer" };
            Globals.LoadList2(this, usPartyType.lstName, post);

        }

        private void usRType_Load_1(object sender, EventArgs e)
        {

            string[] post = { "Regular", "Composition", "Unregistered" };
            Globals.LoadList2(this, usRType.lstName, post);
        }

        private void usState_Load(object sender, EventArgs e)
        {
            Globals.LoadList(this, usState.lstName, "Select Code,SName from m_state order by SName");
        }

        private void usState_Leave(object sender, EventArgs e)
        {
            uctxtStateCode.txt.Text = usState.txtCode.Text;
        }

        private void uctxtMobileNo_Load(object sender, EventArgs e)
        {

        }

        private void gList_KeyPress(object sender, KeyPressEventArgs e)
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

        /*        private void usType_Load(object sender , EventArgs e)
                {
                    usPartyType.lstName.Items.Clear();
                    string[] post = { "Half Holiday" , "Full Holiday" };
                    for (int i = 0 ; i < post.Length ; i++)
                    {
                        ucSearchList.MList lst = new ucSearchList.MList();
                        lst.Name = post[i];
                        lst.Code = i;
                        usType.lstName.Items.Add(lst);
                    }
                    // Ensure the form opens with no rows selected.               
                    //usType.lstName.ClearSelected();
                }*/
    }
    }
