using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP
{
    public class clsRawReport
    {
        public string Item_Name { get; set; }
        public int SNo { get; set; }       
        public double OPSTOCK { get; set; }
        public double Purchase { get; set; }
        public double PurReturn { get; set; }
        public double Consumed { get; set; }
        public double Closing_Balance {
            get
            {
                return OPSTOCK + Purchase - PurReturn - Consumed;
            }
        }
    }
}
