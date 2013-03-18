using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peerfx.Models
{
    public class Users
    {
        private int user_key;
        private string account_number;
        private string title;
        private string first_name;
        private string middle_name;
        private string last_name;
        private string full_name;
        private DateTime dob;
        private int country_residence;
        private string email;
        private string ip_address;
        private DateTime last_changed;
        private DateTime signed_up;
        private int user_status;
        private bool isadmin;
        private string address1;
        private string address2;
        private string city;
        private string state;
        private int country;
        private string postalcode;
        private string phonecountrycode1;
        private int phonetype1;
        private string phonenumber1;
        private string phonecountrycode2;
        private int phonetype2;
        private string phonenumber2;
        private int identitynationality;
        private string occupation;
        private string passportnumber;
        private string user_status_text;
        private Int64 bancbox_payment_object_key;
        private int bancbox_client_id;        
        private string bancbox_cipstatus;
        private string bancbox_client_status;
        private string ssn;
        private string image_url;
        private int verification_points;

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

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
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

        public string Middle_name
        {
            get
            {
                return middle_name;
            }
            set
            {
                middle_name = value;
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

        public string Full_name
        {
            get
            {
                return full_name;
            }
            set
            {
                full_name = value;
            }
        }

        public DateTime Dob
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
            }
        }

        public int Country_residence
        {
            get
            {
                return country_residence;
            }
            set
            {
                country_residence = value;
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

        public DateTime Signed_up
        {
            get
            {
                return signed_up;
            }
            set
            {
                signed_up = value;
            }
        }

        public int User_status
        {
            get
            {
                return user_status;
            }
            set
            {
                user_status = value;
            }
        }

        public bool Isadmin
        {
            get
            {
                return isadmin;
            }
            set
            {
                isadmin = value;
            }
        }

        public string Address1
        {
            get
            {
                return address1;
            }
            set
            {
                address1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
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

        public string Postalcode
        {
            get
            {
                return postalcode;
            }
            set
            {
                postalcode = value;
            }
        }

        public string Phonecountrycode1
        {
            get
            {
                return phonecountrycode1;
            }
            set
            {
                phonecountrycode1 = value;
            }
        }

        public int Phonetype1
        {
            get
            {
                return phonetype1;
            }
            set
            {
                phonetype1 = value;
            }
        }

        public string Phonenumber1
        {
            get
            {
                return phonenumber1;
            }
            set
            {
                phonenumber1 = value;
            }
        }

        public string Phonecountrycode2
        {
            get
            {
                return phonecountrycode2;
            }
            set
            {
                phonecountrycode2 = value;
            }
        }

        public int Phonetype2
        {
            get
            {
                return phonetype2;
            }
            set
            {
                phonetype2 = value;
            }
        }

        public string Phonenumber2
        {
            get
            {
                return phonenumber2;
            }
            set
            {
                phonenumber2 = value;
            }
        }

        public int Identitynationality
        {
            get
            {
                return identitynationality;
            }
            set
            {
                identitynationality = value;
            }
        }

        public string Occupation
        {
            get
            {
                return occupation;
            }
            set
            {
                occupation = value;
            }
        }

        public string Passportnumber
        {
            get
            {
                return passportnumber;
            }
            set
            {
                passportnumber = value;
            }
        }

        public string User_status_text
        {
            get
            {
                return user_status_text;
            }
            set
            {
                user_status_text = value;
            }
        }

        public int Bancbox_client_id
        {
            get
            {
                return bancbox_client_id;
            }
            set
            {
                bancbox_client_id = value;
            }
        }

        public string Bancbox_cipstatus
        {
            get
            {
                return bancbox_cipstatus;
            }
            set
            {
                bancbox_cipstatus = value;
            }
        }

        public string Bancbox_client_status
        {
            get
            {
                return bancbox_client_status;
            }
            set
            {
                bancbox_client_status = value;
            }
        }

        public Int64 Bancbox_payment_object_key
        {
            get
            {
                return bancbox_payment_object_key;
            }
            set
            {
                bancbox_payment_object_key = value;
            }
        }

        public string Ssn
        {
            get
            {
                return ssn;
            }
            set
            {
                ssn = value;
            }
        }

        public string Image_url
        {
            get
            {
                return image_url;
            }
            set
            {
                image_url = value;
            }
        }

        public int Verification_points
        {
            get
            {
                return verification_points;
            }
            set
            {
                verification_points = value;
            }
        }
    }
}