using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP
{
    public class clsFinishedReport
    {
        public int SNo { get; set; }
        public string Thickness { get; set; }
        public double OPSTOCK { get; set; }
        public double PRODUCTION { get; set; }
        public double BREACKAGE { get; set; }
        public double SaleReturn { get; set; }
        public double Sales { get; set; }
        public double ISI { get; set; }
        public double Value { get; set; }
        public double SGST { get; set; }
        public double CGST { get; set; }
        public double IGST { get; set; }        
        public double Closing_Balance
        {
            get
            {
                return OPSTOCK + PRODUCTION + SaleReturn - Sales - BREACKAGE;
            }
        }
    }
}
