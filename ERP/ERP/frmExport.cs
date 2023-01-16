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
    public partial class frmExport : Form
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
        public frmExport()
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

            uFrom.date.Font = chkSale.Font;
            uTo.date.Font = chkSale.Font;

            uFrom.date.Value = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/01");
            int DaysInMonth = DateTime.DaysInMonth(int.Parse(uFrom.date.Value.ToString("yyyy")), int.Parse(uFrom.date.Value.ToString("MM")));
            uTo.date.Value = uFrom.date.Value.AddDays(DaysInMonth - 1);
        }

        private void frmUnit_KeyPress(object sender , KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
        }

        private double val(object value)
        {if (value.ToString().Trim() == "") { value = "0"; }
            return Convert.ToDouble(value);}

        private void frmBrand_KeyDown(object sender , KeyEventArgs e)
        {     
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var sql = "";
            var ConnectionString = "Data Source=" + Globals.ServerName + ";Initial Catalog=Master;User ID=sa;Password=vin0101";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlTransaction transaction;
                transaction = con.BeginTransaction();
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.Transaction = transaction;
                SqlDataReader rd;

                var Inventory1 = Globals.DatabaseName + ".dbo";  //Actual
                var Inventory2 = "Inventory.dbo";                // Physical
                if (Inventory1.Trim().ToUpper() == Inventory2.Trim().ToUpper()) return;

                try
                {
                    lblWait.Visible = true;
                    btnShow.Enabled = false;
                    string VDate = "(DATEADD(DAY, DATEDIFF(day, 0, VDate), 0))";
                    string FromDate = uFrom.date.Value.ToString("yyyy-MM-dd");
                    string ToDate = uTo.date.Value.ToString("yyyy-MM-dd");

                    if (chkSale.Checked)
                    {
                        Application.DoEvents();
                        sql = "Delete from " + Inventory2 + ".Sales where " + VDate.Replace("VDate", "SDate") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                        sql = "Delete from " + Inventory2 + ".Trans_1 where vtype='sales' and " + VDate + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                        sql = "Delete from " + Inventory2 + ".SStock where " + VDate.Replace("VDate", "SDate") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();

                        sql = "insert into " + Inventory2 + ".Sales select * from " + Inventory1 + ".Sales where " + VDate.Replace("VDate", "SDate") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                        sql = "insert into " + Inventory2 + ".Trans_1 select * from " + Inventory1 + ".Trans_1 where VType='sales' and " + VDate + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                        sql = "insert into " + Inventory2 + ".SStock select * from " + Inventory1 + ".SStock where " + VDate.Replace("VDate", "SDate") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                    }
                    if (chkSaleReturn.Checked)
                    {
                        Application.DoEvents();
                        sql = "Delete from " + Inventory2 + ".Sales_Return where " + VDate.Replace("VDate", "Date") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                        sql = "Delete from " + Inventory2 + ".Returnstock where " + VDate.Replace("VDate", "RDate") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();

                        sql = "insert into " + Inventory2 + ".Sales_Return select * from " + Inventory1 + ".Sales_Return where " + VDate.Replace("VDate", "Date") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                        sql = "insert into " + Inventory2 + ".Returnstock select * from " + Inventory1 + ".Returnstock where " + VDate.Replace("VDate", "RDate") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                    }
                    if (chkPurchase.Checked)
                    {
                        Application.DoEvents();
                        sql = "Delete from " + Inventory2 + ".v_Purchase where " + VDate.Replace("VDate", "Inv_Date") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                        sql = "Delete from " + Inventory2 + ".Trans_1 where vtype='Purchase' and " + VDate + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();

                        sql = "insert into " + Inventory2 + ".v_Purchase select * from " + Inventory1 + ".v_Purchase where " + VDate.Replace("VDate", "Inv_Date") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                        sql = "insert into " + Inventory2 + ".Trans_1 select * from " + Inventory1 + ".Trans_1 where VType='purchase' and " + VDate + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                    }
                    if (chkPurchaseReturn.Checked)
                    {
                        Application.DoEvents();
                        sql = "Delete from " + Inventory2 + ".Purchase_Return where " + VDate.Replace("VDate", "Date") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();

                        sql = "insert into " + Inventory2 + ".Purchase_Return select * from " + Inventory1 + ".Purchase_Return where " + VDate.Replace("VDate", "Date") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                    }
                    if (chkProduction.Checked)
                    {
                        Application.DoEvents();
                        sql = "Delete from " + Inventory2 + ".v_manufacturing where " + VDate.Replace("VDate", "Date") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                        sql = "Delete from " + Inventory2 + ".Consumption where " + VDate.Replace("VDate", "Date") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                        sql = "Delete from " + Inventory2 + ".PStock where " + VDate.Replace("VDate", "PDate") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();

                        sql = "insert into " + Inventory2 + ".v_manufacturing select * from " + Inventory1 + ".v_manufacturing where " + VDate.Replace("VDate", "Date") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                        sql = "insert into " + Inventory2 + ".Consumption select * from " + Inventory1 + ".Consumption where " + VDate.Replace("VDate", "Date") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                        sql = "insert into " + Inventory2 + ".PStock select * from " + Inventory1 + ".PStock where " + VDate.Replace("VDate", "PDate") + " between '" + FromDate + "' and '" + ToDate + "'";
                        cmd.CommandText = sql; cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    Globals.msgbox(this,"Data Exported Successfully...");
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
                        Globals.msgbox(this,ex2.Message); // rollback error
                    }
                    Globals.msgbox(this,ex.Message); // commited error
                }
            }
            lblWait.Visible = false;
            btnShow.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblClose_Click(sender,e);
        }
    } }
