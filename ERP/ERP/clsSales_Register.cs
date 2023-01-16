using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP
{
   public class clsSales_Register
    {
        public double SNo { get; set; }
        public string inv_date { get; set; }
        public string PartyName { get; set; }
        public string Invoice_no { get; set; }
        public string Item_Name { get; set; }
        public double Qty { get; set; }
        public double ISI { get; set; }
        public double t_Qty
        {
            get
            {
                return Qty + ISI;
            }
        }
        public double Value { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
        public double Cess { get; set; }
        public double Freight { get; set; }
        public double TCS { get; set; }
        public double Transit_Insurance { get; set; }
        public double Other_Charges { get; set; }
        public double Total   {get;set; }
    }
}
