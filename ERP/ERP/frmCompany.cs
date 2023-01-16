using System;
using System.Collections;
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
    public partial class frmCompany : Form
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
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //-----END
        public frmCompany()
        {
            InitializeComponent();
        }

        private void frmCompany_Load(object sender , EventArgs e)
        {
            int i = 0;
            uctxtSNo.txt.Text = "1";
            uctxtCName.txt.Tag = "Text";
            uctxtIndustry.txt.Tag = "SearchList,Require";
            uctxtMailingName.txt.Tag = "Text";
            uctxtEmail.txt.Tag = "Text";
            uctxtMobileNo1.txt.Tag = "Mobile,Require";
            uctxtMobileNo2.txt.Tag = "Mobile";
            uctxtAddress.txt.Tag = "Text,Require";
            uctxtCity.txt.Tag = "Text";
            uctxtPinCode.txt.Tag = "Text";
            uctxtStateName.txt.Tag = "SearchList,Require";
            uctxtStateCode.txt.Tag = "ReadOnly";
            uctxtTaxBasis.txt.Tag = "SearchList,Require";
            uctxtGSTIN.txt.Tag = "Text";
            uctxtCID.txt.Tag = "Text";
            uctxtPanCardNo.txt.Tag = "Text";
            uctxtWebsite.txt.Tag = "Text";

            FormMode = "Max";
            Form frm = new frmMain();
            lblBorderBottom.Height = 2;
            lblBorderLeft.Width = 2;
            lblBorderRight.Width = 2;
            this.Location = new Point((x - this.Width) / 2 , (y - this.Height - frm.MainMenuStrip.Height) / 2);

            lblClose.Top = (lblTitleBar.Height - lblClose.Height) / 2;
            lblClose.Left = this.Width - lblClose.Width - 4;
            lblMin.Top = lblClose.Top;
            lblMin.Left = lblClose.Left - lblMin.Width - 2;

            LoadData();
        }
        private void LoadData()
        {
            try
            {
                sql = "Select * from m_Company";
                cmd = new SqlCommand(sql , Globals.con);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    uctxtSNo.txt.Text = rd["SNo"].ToString();
                    uctxtCName.txt.Text = rd["CName"].ToString();
                    uctxtIndustry.txt.Text = rd["IName"].ToString();
                    uctxtMailingName.txt.Text = rd["MailingName"].ToString();
                    uctxtEmail.txt.Text = rd["EMail"].ToString();
                    uctxtMobileNo1.txt.Text = rd["MobileNo1"].ToString();
                    uctxtMobileNo2.txt.Text = rd["MobileNo2"].ToString();
                    uctxtAddress.txt.Text = rd["Address"].ToString();
                    uctxtCity.txt.Text = rd["City"].ToString();
                    uctxtPinCode.txt.Text = rd["Pincode"].ToString();
                    uctxtStateName.txt.Text = rd["StateName"].ToString();
                    uctxtStateCode.txt.Text = rd["StateCode"].ToString();
                    ucFDate.date.Value = DateTime.Parse(rd["FinancialDate"].ToString());
                    uctxtTaxBasis.txt.Text = rd["TaxBasis"].ToString();
                    uctxtGSTIN.txt.Text = rd["GSTIN"].ToString();
                    uctxtCID.txt.Text = rd["CID"].ToString();
                    uctxtPanCardNo.txt.Text = rd["PanNo"].ToString();
                    uctxtWebsite.txt.Text = rd["Website"].ToString();
                }
                cmd.Dispose();
                rd.Close();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                rd.Close();
                MessageBox.Show(ex.ToString());
            }
        }
        //public class   MList
        //{
        //    public string Name;
        //    public int Code;
        //    public override string ToString()
        //    {
        //        return this.Name;
        //    }
        //}
    
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
            Form frm = new frmMain();

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
        private void frmCompany_KeyPress(object sender , KeyPressEventArgs e)
        { if (e.KeyChar == 27) this.Hide();}

        private void uctxtStateName_Load(object sender , EventArgs e)
        {
            try
            { 
                sql = "Select Code,SName +' ['+Symbol+']' as SName1 from m_State order by SName1";
                cmd = new SqlCommand(sql , Globals.con);
                rd = cmd.ExecuteReader();
                uctxtStateName.lstName.Items.Clear();
                while (rd.Read())
                {
                    ucSearchList.MList lst = new ucSearchList.MList();
                    lst.Code = rd["Code"];
                    lst.Name = rd["SName1"].ToString();
                    uctxtStateName.lstName.Items.Add(lst);
                }
                uctxtStateName.lstName.ClearSelected();
                cmd.Dispose();
                rd.Close();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                rd.Close();
                MessageBox.Show(ex.ToString());
            }            
        }

        private void uctxtStateName_Leave(object sender , EventArgs e)
        {
             uctxtStateCode.txt.Text =uctxtStateName.txtCode.Text;
        }

        private void uctxtIndustry_Load(object sender , EventArgs e)
        {
            try
            {
                sql = "Select SNo,IName from m_Industry order by IName";
                cmd = new SqlCommand(sql , Globals.con);
                rd = cmd.ExecuteReader();
                uctxtIndustry.lstName.Items.Clear();
                while (rd.Read())
                {
                    ucSearchList.MList lst = new ucSearchList.MList();
                    lst.Code = int.Parse(rd["SNo"].ToString());
                    lst.Name = rd["IName"].ToString();
                    uctxtIndustry.lstName.Items.Add(lst);
                }
                uctxtIndustry.lstName.ClearSelected();
                cmd.Dispose();
                rd.Close();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                rd.Close();
                MessageBox.Show(ex.ToString());
            }
        }
        private void uctxtTaxBasis_Load(object sender , EventArgs e)
        {
                uctxtTaxBasis.lstName.Items.Clear();
                ucSearchList.MList lst = new ucSearchList.MList();
                lst.Name = "Cash";
                lst.Code = 1;
                uctxtTaxBasis.lstName.Items.Add(lst);
                ucSearchList.MList lst1 = new ucSearchList.MList();
                lst1.Name = "Accrual";
                lst1.Code = 2;
                uctxtTaxBasis.lstName.Items.Add(lst1);
                // Ensure the form opens with no rows selected.               
                uctxtTaxBasis.lstName.ClearSelected();
        }
        private double val(object value)
        {
            if (value.ToString().Trim() == "") {value = "0";}
            return Convert.ToDouble(value);
        }
        private void btnSave_Click(object sender , EventArgs e)
        {
            bool blank = false;
            if (uctxtCName.txt.Text.Trim().Length == 0)
            {
                uctxtCName.Focus(); blank = true;
            }
            else if (uctxtIndustry.txt.Text.Trim().Length == 0)
            {
                uctxtIndustry.Focus(); blank = true;
            }
            else if(uctxtMobileNo1.txt.Text.Trim().Length == 0 )
            {
                uctxtMobileNo1.Focus(); blank = true;
            }
            else if(uctxtAddress.txt.Text.Trim().Length == 0)
            {
                uctxtAddress.Focus(); blank = true;
            }
            else if(uctxtStateName.txt.Text.Trim().Length == 0)
            {
                uctxtStateName.Focus(); blank = true;
            }
            else if(uctxtTaxBasis.txt.Text.Trim().Length == 0)
            {
                uctxtTaxBasis.Focus(); blank = true;
            }
            if(blank)
            {                 
                Globals.msgbox(this,"Fill Required Fields","Ok,Center");
                return;
            }

            btnSave.Enabled = false;
            try
            {
                cmd = new SqlCommand("Delete from m_Company" , Globals.con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                sql = "insert into m_Company(SNo,CName,IName,MailingName,EMail,MobileNo1,MobileNo2,Address,City,Pincode,StateName,StateCode,FinancialDate,TaxBasis,GSTIN,CID,PanNo,Website) values (" +
                            val(uctxtSNo.txt.Text) +
                        ",'" + uctxtCName.txt.Text +
                        "','" + uctxtIndustry.txt.Text +
                        "','" + uctxtMailingName.txt.Text +
                        "','" + uctxtEmail.txt.Text +
                        "','" + uctxtMobileNo1.txt.Text +
                        "','" + uctxtMobileNo2.txt.Text +
                        "','" + uctxtAddress.txt.Text +
                        "','" + uctxtCity.txt.Text +
                        "','" + uctxtPinCode.txt.Text +
                        "','" + uctxtStateName.txt.Text +
                        "','" + uctxtStateCode.txt.Text +
                        "','" + ucFDate.date.Value.ToString("yyyy-MM-dd hh:mm:ss") +
                        "','" + uctxtTaxBasis.txt.Text +
                        "','" + uctxtGSTIN.txt.Text +
                        "','" + uctxtCID.txt.Text +
                        "','" + uctxtPanCardNo.txt.Text +
                        "','" + uctxtWebsite.txt.Text + "')";
                cmd = new SqlCommand(sql , Globals.con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Globals.msgbox(this,"Company Profile Saved." , "Ok,Center");
                Globals.ClearAllFields(this);
                uctxtCName.Focus();
                
            }
            catch(Exception ex)
            {
                cmd.Dispose();
                Globals.msgbox(this , ex.Message , "Ok,Left");
            }
            btnSave.Enabled = true;
        }
        
        private void uctxtSNo_Load(object sender , EventArgs e)
        {

        }

        private void button1_Click(object sender , EventArgs e)
        {
            this.Dispose();
        }

        private void uctxtGSTIN_Leave(object sender , EventArgs e)
        {
            if (uctxtGSTIN.txt.Text.Trim().Length >= 1 && uctxtGSTIN.txt.Text.Trim().Length != 15)
            {
                Globals.msgbox(this , "GSTIN number should be 15 digits." , "Ok,Center");
                uctxtGSTIN.Focus(); return;
            }
            else if (uctxtGSTIN.txt.Text.Trim().Length==15)
            {
                if (!uctxtGSTIN.txt.Text.Trim().StartsWith(uctxtStateCode.txt.Text))
                {
                    Globals.msgbox(this , "First 2 digits of GSTIN number should match with Statecode." , "Ok,Left");
                    uctxtGSTIN.Focus();return;
                }
            }
           
        }

        private void uctxtGSTIN_Load(object sender , EventArgs e)
        {

        }
    }
}
