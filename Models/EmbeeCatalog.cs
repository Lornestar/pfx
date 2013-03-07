using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peerfx.Models
{
    public class EmbeeCatalog
    {
        private int country;
        private int productid;
        private string productname;
        private string carrier;
        private decimal price;

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
    }
}