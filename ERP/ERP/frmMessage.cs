using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMessage : Form
    { 

        int left;
        int top;
        int x = Globals.ScreenWith;
        int y = Globals.ScreenHeight;
        string FormMode;
        public string msg = "";
        public string criteria = "";
        public int dialogResult;
        public frmMessage()
        {
            InitializeComponent();
        }


        private void lblClose_Click(object sender , EventArgs e)
        {
            dialogResult = 0;
            Globals.MsgResult = dialogResult;
            this.Close();
        }

        private void frmMessage_KeyPress(object sender , KeyPressEventArgs e)
        {
           
        }
        public void Message(string msg="",string criteria="")
        {
            this.msg = msg;
            this.criteria = criteria;
        }
        private void frmMessage_Load(object sender , EventArgs e)
        {
            frmMain frm = new frmMain();
            lblBorderBottom.Height = 2;
            lblBorderLeft.Width = 2;
            lblBorderRight.Width = 2;
            this.Location = new Point((x - this.Width) / 2 , (y - this.Height - frm.MainMenuStrip.Height) / 2);
            lblClose.Top = (lblTitleBar.Height - lblClose.Height) / 2;
            lblClose.Left = this.Width - lblClose.Width - 4;

            if((msg.Trim().Length>0 && criteria.Trim().Length>0))
            {
                lblName.Text = msg;
                if (criteria.Contains("Left"))
                { lblName.TextAlign = ContentAlignment.MiddleLeft; }
                else if(criteria.Contains("Center"))
                { lblName.TextAlign = ContentAlignment.MiddleCenter; }
                if(criteria.Contains("Ok"))
                {
                    btnSave.Text = "Ok";
                    btnSave.Visible = true;
                }
                else if (criteria.Contains("Yes"))
                {
                    btnSave.Text = "Yes";
                    btnSave.Visible = true;
                }
                if (criteria.Contains("Cancel"))
                {
                    btnCancel.Text = "Cancel";
                    btnCancel.Visible = true;
                }
                else if (criteria.Contains("No"))
                {
                    btnCancel.Text = "No";
                    btnCancel.Visible = true;
                }
                if(btnSave.Visible && !btnCancel.Visible)
                {
                    btnSave.Left=(this.Width-btnSave.Width)/ 2;
                }
                btnSave.Focus();
            }
            dialogResult = 0;
        }

        private void lblName_Click(object sender , EventArgs e)
        {

        }

        private void btnSave_Click(object sender , EventArgs e)
        {
            dialogResult = 1;
            Globals.MsgResult=dialogResult;
            this.Close();
        }

        private void btnCancel_Click(object sender , EventArgs e)
        {
            dialogResult = 0;
            Globals.MsgResult = dialogResult;
            this.Close();
        }

        private void frmMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Y || e.KeyCode==Keys.O)
            {
                dialogResult = 1;
                Globals.MsgResult = dialogResult;
                this.Close();
            }
            else if (e.KeyCode == Keys.N || e.KeyCode==Keys.Escape)
            {
                dialogResult = 0;
                Globals.MsgResult = dialogResult;
                this.Close();
            }
        }
    }
}
