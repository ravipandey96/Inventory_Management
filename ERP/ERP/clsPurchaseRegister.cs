using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP
{
    public class clsPurchaseRegister
    {
        public string Date { get; set; }
        public string Invoice_no { get; set; }
        public string Place { get; set; }
        public string PartyName { get; set; }
        public string Item_Name { get; set; }
        public double Qty { get; set; }
        public double Value { get; set; }
        public double Transit_Insurance { get; set; }
        public double Other_Charges { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
        public double Cess { get; set; }
        public double Freight { get; set; }
        public double TCS { get; set; }        
        public double Total
        {
            get
            {
                return Value + CGST + SGST + IGST + Cess + Freight + TCS + Transit_Insurance + Other_Charges; 
            }
        }
}
}
