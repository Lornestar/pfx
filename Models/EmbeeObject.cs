using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peerfx.Models
{
    public class EmbeeObject
    {
        private int country;
        private int productid;
        private string productname;
        private string carrier;
        private decimal price;
        private int embee_object_key;
        private int transstatus;
        private int transid;
        private DateTime date_created;
        private string phone;
        private string message;
        private DateTime date_processed;
        private int payment_key;

        public int Embee_object_key
        {
            get
            {
                return embee_object_key;
            }
            set
            {
                embee_object_key = value;
            }
        }

        public int Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        public int Productid
        {
            get
            {
                return productid;
            }
            set
            {
                productid = value;
            }
        }

        public string Productname
        {
            get
            {
                return productname;
            }
            set
            {
                productname = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public string Carrier
        {
            get
            {
                return carrier;
            }
            set
            {
                carrier = value;
            }
        }

        public int Transstatus
        {
            get
            {
                return transstatus;
            }
            set
            {
                transstatus = value;
            }
        }

        public int Transid
        {
            get
            {
                return transid;
            }
            set
            {
                transid = value;
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

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        public DateTime Date_processed
        {
            get
            {
                return date_processed;
            }
            set
            {
                date_processed = value;
            }
        }

        public int Payment_key
        {
            get
            {
                return payment_key;
            }
            set
            {
                payment_key = value;
            }
        }
    }
}