using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peerfx.Models
{
    public class CurrencyCloudTrade
    {

        private Int64 currencycloud_trade_key;
        private int payments_key;
        private Int64 settlement_key;
        private DateTime initiated_date;
        private DateTime settlement_date;
        private string cc_tradeid;

        public Int64 Currencycloud_trade_key
        {
            get
            {
                return currencycloud_trade_key;
            }
            set
            {
                currencycloud_trade_key = value;
            }
        }

        public int Payments_key
        {
            get
            {
                return payments_key;
            }
            set
            {
                 payments_key = value;
            }
        }

        public Int64 Settlement_key
        {
            get
            {
                return settlement_key;
            }
            set
            {
                 settlement_key = value;
            }
        }

        public DateTime Initiated_date
        {
            get
            {
                return initiated_date;
            }
            set
            {
                 initiated_date = value;
            }
        }

        public DateTime Settlement_date
        {
            get
            {
                return settlement_date;
            }
            set
            {
                settlement_date = value;
            }
        }

        public string Cc_tradeid
        {
            get
            {
                return cc_tradeid;
            }
            set
            {
                 cc_tradeid = value;
            }
        }
        
    }
}