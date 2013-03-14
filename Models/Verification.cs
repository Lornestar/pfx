using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peerfx.Models
{
    public class Verification
    {
        private int users_verified_key;
        private int user_key;
        private int verification_methods_key;
        private bool isverified;
        private DateTime last_changed;
        private string ip_address;
        private string unique_key;
        private string verification_method_name;
        private int points;
        private bool ismandatory;

        public int Users_verified_key
        {
            get
            {
                return users_verified_key;
            }
            set
            {
                users_verified_key = value;
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

        public int Verification_methods_key
        {
            get
            {
                return verification_methods_key;
            }
            set
            {
                verification_methods_key = value;
            }
        }

        public bool Isverified
        {
            get
            {
                return isverified;
            }
            set
            {
                isverified = value;
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

        public string Unique_key
        {
            get
            {
                return unique_key;
            }
            set
            {
                unique_key = value;
            }
        }

        public string Verification_method_name
        {
            get
            {
                return verification_method_name;
            }
            set
            {
                verification_method_name = value;
            }
        }

        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }

        public bool Ismandatory
        {
            get
            {
                return ismandatory;
            }
            set
            {
                ismandatory = value;
            }
        }
        

    }
}