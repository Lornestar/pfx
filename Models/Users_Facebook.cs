using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peerfx.Models
{
    public class Users_Facebook
    {
        private int user_key;
        private Int64 uid;
        private string location;
        private string email;
        private int friends_count;
        private string access_token;
        private DateTime date_created;
        private DateTime last_changed;
        private bool ismale;
        private string first_name;
        private string last_name;
        private string full_name;
        private bool isverified;
        
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

        public Int64 fb_uid
        {
            get
            {
                return uid;
            }
            set
            {
                 uid = value;
            }
        }

        public string fb_location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        public string fb_email
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

        public int fb_friends_count
        {
            get
            {
                return friends_count;
            }
            set
            {
                friends_count = value;
            }
        }

        public string fb_access_token
        {
            get
            {
                return access_token;
            }
            set
            {
                access_token = value;
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

        public bool fb_ismale
        {
            get
            {
                return ismale;
            }
            set
            {
                ismale = value;
            }
        }

        public string fb_first_name
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

        public string fb_last_name
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

        public string fb_full_name
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

        public bool fb_isverified
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
    
    }
}