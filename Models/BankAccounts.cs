using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peerfx.Models
{
    public class BankAccounts
    {
        private Int64 payment_object_key;
        private int payment_object_type;
        private int bank_account_key;
        private DateTime date_created;
        private int user_key;
        private int currency_key;
        private int organization_key;
        private string bank_account_description;
        private int user_key_updated;
        private string ip_address;
        private string account_number;
        private string iban;
        private string bic;
        private string abarouting;
        private string first_name;
        private string last_name;
        private string business_name;
        private DateTime last_changed;
        private string bank_account_info;
        private string organization_name;
        private string country_text;
        private string currency_text;
        private string sortcode;
        private string bsb;
        private string email;

        public Int64 Payment_object_key
        {
            get
            {
                return payment_object_key;
            }
            set
            {
                payment_object_key = value;
            }
        }

        public int Payment_object_type
        {
            get
            {
                return payment_object_type;
            }
            set
            {
                payment_object_type = value;
            }
        }

        public int Bank_account_key
        {
            get
            {
                return bank_account_key;
            }
            set
            {
                bank_account_key = value;
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

        public int User_key
        {
            get
            {
                return user_key;
            }
            set
            {
                user_key = value;
            }
        }

        public int Currency_key
        {
            get
            {
                return currency_key;
            }
            set
            {
                currency_key = value;
            }
        }

        public int Organization_key
        {
            get
            {
                return organization_key;
            }
            set
            {
                organization_key = value;
            }
        }

        public string Bank_account_description
        {
            get
            {
                return bank_account_description;
            }
            set
            {
                bank_account_description = value;
            }
        }

        public int User_key_updated
        {
            get
            {
                return user_key_updated;
            }
            set
            {
                user_key_updated = value;
            }
        }

        public string Ip_address
        {
            get
            {
                return ip_address;
            }
            set
            {
                ip_address = value;
            }
        }

        public string Account_number
        {
            get
            {
                return account_number;
            }
            set
            {
                account_number = value;
            }
        }

        public string IBAN
        {
            get
            {
                return iban;
            }
            set
            {
                iban = value;
            }
        }

        public string BIC
        {
            get
            {
                return bic;
            }
            set
            {
                bic = value;
            }
        }

        public string ABArouting
        {
            get
            {
                return abarouting;
            }
            set
            {
                abarouting = value;
            }
        }        

        public string First_name
        {
            get
            {
                return first_name;
            }
            set
            {
                first_name = value;
            }
        }

        public string Last_name
        {
            get
            {
                return last_name;
            }
            set
            {
                last_name = value;
            }
        }

        public string Business_name
        {
            get
            {
                return business_name;
            }
            set
            {
                business_name = value;
            }
        }

        public DateTime Last_changed
        {
            get
            {
                return last_changed;
            }
            set
            {
                last_changed = value;
            }
        }

        public string Bank_account_info
        {
            get
            {
                return bank_account_info;
            }
            set
            {
                bank_account_info = value;
            }
        }

        public string Organization_name
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

        public string Country_text
        {
            get
            {
                return country_text;
            }
            set
            {
                country_text = value;
            }
        }

        public string Currency_text
        {
            get
            {
                return currency_text;
            }
            set
            {
                currency_text = value;
            }
        }

        public string Sortcode
        {
            get
            {
                return sortcode;
            }
            set
            {
                sortcode = value;
            }
        }

        public string BSB
        {
            get
            {
                return bsb;
            }
            set
            {
                bsb = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
    }
}