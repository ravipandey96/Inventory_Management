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
    public partial class ucSearchList : UserControl
    {
        public ucSearchList()
        {
            InitializeComponent();
        }

        private void txt_TextChanged(object sender , EventArgs e)
        {
            //---Search any string,substring in list
                lblRequire.Visible = false;
                string ListData = "";
                try
                {
                    ListData = this.lstName.Items.Cast<object>().Where(x => x.ToString().IndexOf(txt.Text , StringComparison.CurrentCultureIgnoreCase) >= 0).FirstOrDefault().ToString();
                }
                catch (Exception ex)
                { }
                int i = this.lstName.FindString(ListData);
                this.lstName.SelectedIndex = i;
        }
        private void txt_Enter(object sender , EventArgs e)
        {
                txt.BackColor = Color.Cyan;
                this.lstName.Visible = true;
            try
            {
                var temp = txt.Tag.ToString();

                if (temp.Contains("AutoHeight:false") == false) /// if AutoHeight is not present in tag it means it autimatically AutoHeight
                {
                    this.lstName.Height = this.lstName.Items.Count * 20;
                }
                else
                {
                    var StartIndex = temp.LastIndexOf("Height");
                    if (StartIndex != -1)
                    {
                        int CustomHeight = int.Parse(temp.Substring(StartIndex, temp.IndexOf(",", StartIndex) - StartIndex).Remove(0, 7));
                        this.lstName.Height = CustomHeight;
                    }
                }
            }
            catch (Exception ex) { }

            this.Height = txt.Height + this.lstName.Height + 2;
        }
        private void txt_Leave(object sender , EventArgs e)
        {
           // this.OnLeave(e);
            //---assign selected list item and value
            MList lst = this.lstName.SelectedItem as MList;
            if (lst != null)
            {
                txt.Text = lst.Name;
                txtCode.Text = lst.Code.ToString();
            }
            else
            {
                txt.Text = "";
                txtCode.Text = "";
            }
            if (txt.Tag.ToString().Contains("Require") && txt.Text.Trim().Length == 0)
                {
                    txt.Focus();
                    lblRequire.Visible = true;
                return;
                }
            txt.BackColor = Color.White;
            this.lstName.Visible = false;
            this.Height = txt.Height +2;
        }
        public class MList
        {
            public string Name;
            public object Code;
            public override string ToString(){
                return this.Name;
            }
        }
        
        private void txt_KeyDown(object sender , KeyEventArgs e)
        { // ---list search up down
                if (e.KeyCode == Keys.Down)
                {
                    if (this.lstName.SelectedIndex < this.lstName.Items.Count - 1)
                    {
                        this.lstName.SelectedIndex = this.lstName.SelectedIndex + 1;
                        txt.SelectionStart = txt.TextLength;
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (this.lstName.SelectedIndex > 0)
                    {
                        this.lstName.SelectedIndex = this.lstName.SelectedIndex - 1;
                        txt.SelectionStart = txt.TextLength;
                    }
                }
            this.OnKeyDown(e);
        }

        private void txt_KeyPress(object sender , KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }           
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
            //-----------for Data List------------
            lstName.Visible = false;
            lstName.Font = txt.Font;
            lstName.Width = txt.Width;
            lstName.Left = txt.Left;
            lstName.Top = txt.Top + txt.Height;
        }

 }}
