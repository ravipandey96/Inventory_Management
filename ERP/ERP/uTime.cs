using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class uTime : UserControl
    {
        public uTime()
        {
            InitializeComponent();
        }

        private void uTime_Load(object sender , EventArgs e)
        {
            FontFamily nf = new FontFamily("Arial");
            date.Font = new Font(nf , 10 , FontStyle.Regular);
            this.BackColor = Color.Cyan;
            this.Height = date.Height + 2;
        }

        private void dtpFDate_KeyPress(object sender , KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dtpFDate_Leave(object sender , EventArgs e)
        {
            date.BackColor = Color.White;
        }

        private void dtpFDate_Enter(object sender , EventArgs e)
        {
            date.BackColor = Color.Cyan;
        }

        private void date_ValueChanged(object sender , EventArgs e)
        {

        }
    }
}
