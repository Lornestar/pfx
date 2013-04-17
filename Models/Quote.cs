using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peerfx.Models
{
    public class Quote
    {

        private DateTime bid_price_timestamp;
        private decimal bid_price;
        private DateTime offer_price_timestamp;
        private decimal offer_price;
        private DateTime value_date;
        private string quote_condition;
        private string real_market;
        private string ccy_pair;
        private decimal broker_bid;
        private decimal broker_offer;
        private decimal market_price;
        private decimal peerfx_rate;
        private decimal peerfx_servicefee;
        private decimal buyamount;
        private decimal sellamount;
        private int timing_key;
        private string timing_description;
        private int sellcurrency;
        private int buycurrency;
        
        public DateTime Bid_Price_Timestamp
        {
            get
            {
                return bid_price_timestamp;
            }
            set
            {
                bid_price_timestamp = value;
            }
        }

        public decimal Bid_Price         
        {
            get
            {
                return bid_price;
            }
            set
            {
                bid_price = value;
            }
        }

        public DateTime Offer_Price_Timestamp
        {
            get
            {
                return offer_price_timestamp;
            }
            set
            {
                offer_price_timestamp = value;
            }
        }

        public decimal Offer_Price
        {
            get
            {
                return offer_price;
            }
            set
            {
                offer_price = value;
            }
        }

        public DateTime Value_Date
        {
            get
            {
                return value_date;
            }
            set
            {
                value_date = value;
            }
        }

        public string Quote_Condition
        {
            get
            {
                return quote_condition;
            }
            set
            {
                quote_condition = value;
            }
        }

        public string Real_Market
        {
            get
            {
                return real_market;
            }
            set
            {
                real_market = value;
            }
        }

        public string Ccy_Pair
        {
            get
            {
                return ccy_pair;
            }
            set
            {
                ccy_pair = value;
            }
        }

        public decimal Broker_Bid
        {
            get
            {
                return broker_bid;
            }
            set
            {
                broker_bid = value;
            }
        }

        public decimal Broker_Offer
        {
            get
            {
                return broker_offer;
            }
            set
            {
                broker_offer = value;
            }
        }

        public decimal Market_Price
        {
            get
            {
                return market_price;
            }
            set
            {
                market_price = value;
            }
        }

        public decimal Peerfx_Rate
        {
            get
            {
                return peerfx_rate;
            }
            set
            {
                peerfx_rate = value;
            }
        }

        public decimal Peerfx_Servicefee
        {
            get
            {
                return peerfx_servicefee;
            }
            set
            {
                peerfx_servicefee = value;
            }
        }

        public decimal Buyamount
        {
            get
            {
                return buyamount;
            }
            set
            {
                buyamount = value;
            }
        }

        public decimal Sellamount
        {
            get
            {
                return sellamount;
            }
            set
            {
                sellamount = value;
            }
        }

        public int Timing_key
        {
            get
            {
                return timing_key;
            }
            set
            {
                timing_key = value;
            }
        }

        public string Timing_description
        {
            get
            {
                return timing_description;
            }
            set
            {
                timing_description = value;
            }
        }

        public int Sellcurrency
        {
            get
            {
                return sellcurrency;
            }
            set
            {
                sellcurrency = value;
            }
        }

        public int Buycurrency
        {
            get
            {
                return buycurrency;
            }
            set
            {
                buycurrency = value;
            }
        }
        
    }
}