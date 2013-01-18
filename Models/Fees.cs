using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peerfx.Models
{
    public class Fees
    {
        private string organization_name;
        private string description;
        private decimal fee_base;
        private decimal fee_percentage;
        private decimal fee_addon;
        private decimal fee_min;
        private decimal fee_max;
        private int currency1;
        private int currency2;
        private string currency1_code;
        private string currency2_code;
        Site sitetemp = new Site();


        public string Organization_Name
        {
            get
            {
                return organization_name;
            }
            set
            {
                organization_name = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public decimal Fee_Base
        {
            get
            {
                return fee_base;
            }
            set
            {
                fee_base = value;
            }
        }

        public decimal Fee_Percentage
        {
            get
            {
                return fee_percentage;
            }
            set
            {
                fee_percentage = value;
            }
        }

        public decimal Fee_Addon
        {
            get
            {
                return fee_addon;
            }
            set
            {
                fee_addon = value;
            }
        }

        public decimal Fee_Min
        {
            get
            {
                return fee_min;
            }
            set
            {
                fee_min = value;
            }
        }

        public decimal Fee_Max
        {
            get
            {
                return fee_max;
            }
            set
            {
                fee_max = value;
            }
        }

        public int Currency1
        {
            get
            {
                return currency1;
            }
            set
            {
                currency1 = value;
            }
        }

        public int Currency2
        {
            get
            {
                return currency2;
            }
            set
            {
                currency2 = value;
            }
        }

        public string Currency1_Code
        {
            get
            {
                return sitetemp.getcurrencycode(currency1);
            }            
        }

        public string Currency2_Code
        {
            get
            {
                return sitetemp.getcurrencycode(currency2);
            }            
        }
    }
}