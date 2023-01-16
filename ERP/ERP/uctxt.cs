using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ERP
{
    public partial class uctxt : UserControl
    {
        //[Bindable(true)]
        //[EditorBrowsable(EditorBrowsableState.Always)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[Browsable(true)]
        //[Category("Appearance")]
        //public override string Text { get { return base.Text; } set { base.Text = value; this.Invalidate(); } }
        //[Browsable(true)]
        //public event EventHandler TextChanged;
        [Browsable(true)]
        public event EventHandler TextChanged
        {
            add { base.TextChanged += value; }
            remove { base.TextChanged -= value; }
        }
        public bool SearchEnterKey = false;
        public uctxt()
        {
            InitializeComponent();
        }

        private void txt_TextChanged(object sender , EventArgs e)
        {
            lblRequire.Visible = false;
            this.OnTextChanged(e);
        }

        private void txt_Enter(object sender , EventArgs e)
        {
            txt.BackColor = Color.Cyan;
            lblRequire.Text = "Need";
        }

        private void txt_Leave(object sender , EventArgs e)
        {
            txt.Text = txt.Text.Trim();
            txt.BackColor = Color.White;
            if(txt.Tag.ToString().Contains("Text"))
            {
                if (txt.Tag.ToString().Contains("Require") && txt.Text.Trim().Length == 0)
                {
                    txt.Focus();
                    lblRequire.Visible = true;
                }
            }
            else if (txt.Tag.ToString().Contains("Amount"))
            {
                txt.Text = val(txt.Text,true);
                if (txt.Tag.ToString().Contains("Require") && double.Parse(txt.Text) == 0)
                {
                    txt.Focus();
                    lblRequire.Visible = true;
                }
            }
            else if (txt.Tag.ToString().Contains("Mobile"))
            {
                if (txt.Tag.ToString().Contains("Require") && txt.Text.Trim().Length == 0)
                {
                      txt.Focus();
                      lblRequire.Visible = true;                   
                }
                else if ((txt.Text.Trim().Length>0 && txt.Text.Trim().Length>=10)==false && txt.Text.Trim().Length>0)
                {        
                    txt.Focus();
                    lblRequire.Text = txt.Text.Trim().Length.ToString() +" No";
                    lblRequire.Visible = true;
                }
            }
            else if (txt.Tag.ToString().Contains("Number"))
            {
                txt.Text = val(txt.Text , false);
                if (txt.Tag.ToString().Contains("Require") && double.Parse(txt.Text) == 0)
                {
                    txt.Focus();
                    lblRequire.Visible = true;
                }
            }
        }
        private string val(string str="",bool decimalPoint=false)
        {
            if (str.Trim() == "") {str = "0";}

            if (decimalPoint)
            {str = string.Format("{0:#0.00}" , Convert.ToDouble(str));}
            else
            {str=Convert.ToDouble(str).ToString(); }
            return str;
        }
        private void txt_KeyDown(object sender , KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void txt_KeyPress(object sender , KeyPressEventArgs e)
        {
            //validation for Text Box
            
            if (e.KeyChar == 13)
            {
                if (SearchEnterKey==false) // For Proper Enter Working
                {
                    SendKeys.Send("{TAB}");                    
                }
                SearchEnterKey = false;
            }
            if (txt.Tag.ToString().Contains("ReadOnly"))
            { e.KeyChar = (char)0;return; }
            if (txt.Tag.ToString().Contains("Text"))
            { /*DO ANY CODE*/}
            else if (txt.Tag.ToString().Contains("Amount"))
            {
                if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar==46))
                {  
                    e.KeyChar = (char)0;
                }
                if (txt.Text.IndexOf('.') > 0 && e.KeyChar == 46) { e.KeyChar = (char)0; }
            }
            else if (txt.Tag.ToString().Contains("Number"))
            {
                if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46))
                {
                    e.KeyChar = (char)0;
                }
            }
            else if (txt.Tag.ToString().Contains("Mobile"))
            {
                if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 44))
                {
                    e.KeyChar = (char)0;
                }
            }
            else if (txt.Tag.ToString().Contains("Email"))
            { }

        }

        private void uctxt_Load(object sender , EventArgs e)
        {
            txt.BorderStyle = BorderStyle.None;
            FontFamily nf = new FontFamily("Arial");
            txt.Font = new Font(nf, 12 , FontStyle.Regular);
            lblRequire.Font = txt.Font;
            lblRequire.Height = txt.Height;
            lblRequire.Top = txt.Top;
            lblRequire.Left = txt.Width - lblRequire.Width+2;
            lblRequire.Visible = false;
            this.BackColor = Color.Cyan;
            this.Height = txt.Height+2;   
        }


    }
}
