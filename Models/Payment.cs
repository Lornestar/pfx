﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peerfx.Models
{
    public class Payment
    {
        private int payments_key;
        private int quote_key;
        private int payment_status;
        private DateTime date_created;
        private Int64 payment_object_sender;
        private Int64 payment_object_receiver;
        private string payment_description;
        private decimal sell_amount;
        private int sell_currency;
        private decimal buy_amount;
        private int buy_currency;
        private decimal rate;
        private decimal service_fee;
        private DateTime promised_delivery_date;
        private DateTime actual_delivery_date;
        private string receiver_name;
        private string sender_name;
        private string sell_currency_text;
        private string buy_currency_text;
        private string payment_status_text;

        public int Payments_Key
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

        public int Quote_Key
        {
            get
            {
                return quote_key;
            }
            set
            {
                quote_key = value;
            }
        }

        public int Payment_status
        {
            get
            {
                return payment_status;
            }
            set
            {
                payment_status = value;
            }
        }

        public DateTime Date_created
        {
            get
            {
                return date_created;
            }
            set
            {
                date_created = value;
            }
        }

        public Int64 Payment_object_sender
        {
            get
            {
                return payment_object_sender;
            }
            set
            {
                payment_object_sender = value;
            }
        }

        public Int64 Payment_object_receiver
        {
            get
            {
                return payment_object_receiver;
            }
            set
            {
                payment_object_receiver = value;
            }
        }

        public decimal Sell_amount
        {
            get
            {
                return sell_amount;
            }
            set
            {
                sell_amount = value;
            }
        }

        public int Sell_currency
        {
            get
            {
                return sell_currency;
            }
            set
            {
                sell_currency = value;
            }
        }

        public decimal Buy_amount
        {
            get
            {
                return buy_amount;
            }
            set
            {
                buy_amount = value;
            }
        }

        public int Buy_currency
        {
            get
            {
                return buy_currency;
            }
            set
            {
                buy_currency = value;
            }
        }

        public decimal Rate
        {
            get
            {
                return rate;
            }
            set
            {
                rate = value;
            }
        }

        public decimal Service_fee
        {
            get
            {
                return service_fee;
            }
            set
            {
                service_fee = value;
            }
        }

        public DateTime Promised_delivery_date
        {
            get
            {
                return promised_delivery_date;
            }
            set
            {
                promised_delivery_date = value;
            }
        }

        public DateTime Actual_delivery_date
        {
            get
            {
                return actual_delivery_date;
            }
            set
            {
                actual_delivery_date = value;
            }
        }

        public string Receiver_name
        {
            get
            {
                return receiver_name;
            }
            set
            {
                receiver_name = value;
            }
        }

        public string Sender_name
        {
            get
            {
                return sender_name;
            }
            set
            {
                sender_name = value;
            }
        }

        public string Sell_currency_text
        {
            get
            {
                return sell_currency_text;
            }
            set
            {
                sell_currency_text = value;
            }
        }

        public string Buy_currency_text
        {
            get
            {
                return buy_currency_text;
            }
            set
            {
                buy_currency_text = value;
            }
        }

        public string Payment_status_text
        {
            get
            {
                return payment_status_text;
            }
            set
            {
                payment_status_text = value;
            }
        }

        public string Payment_description
        {
            get
            {
                return payment_description;
            }
            set
            {
                payment_description = value;
            }
        }        
        
    }
}