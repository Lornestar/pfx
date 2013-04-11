using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace Peerfx_DB
{
    /// <summary>
    /// Controller class for Users_Info
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UsersInfoController
    {
        // Preload our schema..
        UsersInfo thisSchemaLoad = new UsersInfo();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public UsersInfoCollection FetchAll()
        {
            UsersInfoCollection coll = new UsersInfoCollection();
            Query qry = new Query(UsersInfo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UsersInfoCollection FetchByID(object UserKey)
        {
            UsersInfoCollection coll = new UsersInfoCollection().Where("user_key", UserKey).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UsersInfoCollection FetchByQuery(Query qry)
        {
            UsersInfoCollection coll = new UsersInfoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UserKey)
        {
            return (UsersInfo.Delete(UserKey) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UserKey)
        {
            return (UsersInfo.Destroy(UserKey) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int UserKey,string Address1,string Address2,string City,string State,int? Country,string Postalcode,int? Phonecountrycode1,int? Phonetype1,string Phonenumber1,int? Phonecountrycode2,int? Phonetype2,string Phonenumber2,int? Identitynationality,string Occupation,string Passportnumber,DateTime? LastChanged,string Username,string Password,string Ssn,string ImageUrl,int? DefaultCurrency)
	    {
		    UsersInfo item = new UsersInfo();
		    
            item.UserKey = UserKey;
            
            item.Address1 = Address1;
            
            item.Address2 = Address2;
            
            item.City = City;
            
            item.State = State;
            
            item.Country = Country;
            
            item.Postalcode = Postalcode;
            
            item.Phonecountrycode1 = Phonecountrycode1;
            
            item.Phonetype1 = Phonetype1;
            
            item.Phonenumber1 = Phonenumber1;
            
            item.Phonecountrycode2 = Phonecountrycode2;
            
            item.Phonetype2 = Phonetype2;
            
            item.Phonenumber2 = Phonenumber2;
            
            item.Identitynationality = Identitynationality;
            
            item.Occupation = Occupation;
            
            item.Passportnumber = Passportnumber;
            
            item.LastChanged = LastChanged;
            
            item.Username = Username;
            
            item.Password = Password;
            
            item.Ssn = Ssn;
            
            item.ImageUrl = ImageUrl;
            
            item.DefaultCurrency = DefaultCurrency;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int UserKey,string Address1,string Address2,string City,string State,int? Country,string Postalcode,int? Phonecountrycode1,int? Phonetype1,string Phonenumber1,int? Phonecountrycode2,int? Phonetype2,string Phonenumber2,int? Identitynationality,string Occupation,string Passportnumber,DateTime? LastChanged,string Username,string Password,string Ssn,string ImageUrl,int? DefaultCurrency)
	    {
		    UsersInfo item = new UsersInfo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.UserKey = UserKey;
				
			item.Address1 = Address1;
				
			item.Address2 = Address2;
				
			item.City = City;
				
			item.State = State;
				
			item.Country = Country;
				
			item.Postalcode = Postalcode;
				
			item.Phonecountrycode1 = Phonecountrycode1;
				
			item.Phonetype1 = Phonetype1;
				
			item.Phonenumber1 = Phonenumber1;
				
			item.Phonecountrycode2 = Phonecountrycode2;
				
			item.Phonetype2 = Phonetype2;
				
			item.Phonenumber2 = Phonenumber2;
				
			item.Identitynationality = Identitynationality;
				
			item.Occupation = Occupation;
				
			item.Passportnumber = Passportnumber;
				
			item.LastChanged = LastChanged;
				
			item.Username = Username;
				
			item.Password = Password;
				
			item.Ssn = Ssn;
				
			item.ImageUrl = ImageUrl;
				
			item.DefaultCurrency = DefaultCurrency;
				
	        item.Save(UserName);
	    }
    }
}
