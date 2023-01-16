using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP
{
    public class clsFinishedParticular
    {
        public string Item_Name { get; set; }
        public string Date { get; set; }
        public double OpRegular { get; set; }
        public double OpBIS { get; set; }
        public double OpTotal
        {
            get
            {
                return OpRegular + OpBIS;
            }
        }
        public double PRegular { get; set; }
        public double PBIS { get; set; }
        public double PTotal
        {
            get
            {
                return PRegular + PBIS;
            }
        }
        public double RRegular { get; set; }
        public double RBIS { get; set; }
        public string Bill_No { get; set; }
        public double SRegular { get; set; }
        public double SBIS { get; set; }
        public double STotal
        {
            get
            {
                return SRegular + SBIS;
            }
        }
        public double Value { get; set; }
        public double IGST { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double TRegular
        {
            get
            {
                return OpRegular + PRegular - SRegular + RRegular;
            }
        }
        public double TBIS
        {
            get
            {
                return OpBIS + PBIS - SBIS + RBIS;
            }
        }
        public double TTotal
        {
            get
            {
                return TRegular + TBIS;
            }
        }
        public double Breackage { get; set; }

    }
    }

