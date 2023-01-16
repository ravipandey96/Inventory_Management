using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP
{
   public class clsSales_RegisterParticular
    {
        public double SNo { get; set; }
        public double VNo { get; set; }
        public string Sdate { get; set; }
        public string SName { get; set; }
        public string Vehicle_No { get; set; }
        public string BillNo { get; set; }
        public string Batch_No { get; set; }
        public string Item_Name { get; set; }
        public double Qty { get; set; }
        public double Regular { get; set; }
        public double BIS { get; set; }
        public double Sold
        {
            get
            {
                return Regular + BIS;
            }
        }
        public double Closing_bal
        {
            get
            {
                return Opening_Bal - Sold;
            }
        }
        public double Total_Regular { get; set; }
        public double Breackage { get; set; }
        public double PBIS { get; set; }
        public double ISI { get; set; }
        public double PRegular { get; set; }
        public double mfd
        {
            get
            {
                return PRegular + PBIS;
            }
        }
        public double Opening_Bal
        {
            get
            {
                return mfd + Total;
            }
        }
        public double Total_ISI { get; set; }
        public double Area
        {
            get
            {
                return 2440*1220;
            }
        }
        public double Total
        {
            get
            {
                return Total_Regular + Total_ISI;
            }
        }        
//        public double Total   {get;set; }
    }
}
