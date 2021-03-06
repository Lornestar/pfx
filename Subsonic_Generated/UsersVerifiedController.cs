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
    /// Controller class for Users_Verified
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UsersVerifiedController
    {
        // Preload our schema..
        UsersVerified thisSchemaLoad = new UsersVerified();
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
        public UsersVerifiedCollection FetchAll()
        {
            UsersVerifiedCollection coll = new UsersVerifiedCollection();
            Query qry = new Query(UsersVerified.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UsersVerifiedCollection FetchByID(object UsersVerifiedKey)
        {
            UsersVerifiedCollection coll = new UsersVerifiedCollection().Where("users_verified_key", UsersVerifiedKey).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UsersVerifiedCollection FetchByQuery(Query qry)
        {
            UsersVerifiedCollection coll = new UsersVerifiedCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UsersVerifiedKey)
        {
            return (UsersVerified.Delete(UsersVerifiedKey) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UsersVerifiedKey)
        {
            return (UsersVerified.Destroy(UsersVerifiedKey) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int UserKey,int VerificationMethodsKey,bool Isverified,DateTime LastChanged,string IpAddress,string UniqueKey)
	    {
		    UsersVerified item = new UsersVerified();
		    
            item.UserKey = UserKey;
            
            item.VerificationMethodsKey = VerificationMethodsKey;
            
            item.Isverified = Isverified;
            
            item.LastChanged = LastChanged;
            
            item.IpAddress = IpAddress;
            
            item.UniqueKey = UniqueKey;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int UsersVerifiedKey,int UserKey,int VerificationMethodsKey,bool Isverified,DateTime LastChanged,string IpAddress,string UniqueKey)
	    {
		    UsersVerified item = new UsersVerified();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.UsersVerifiedKey = UsersVerifiedKey;
				
			item.UserKey = UserKey;
				
			item.VerificationMethodsKey = VerificationMethodsKey;
				
			item.Isverified = Isverified;
				
			item.LastChanged = LastChanged;
				
			item.IpAddress = IpAddress;
				
			item.UniqueKey = UniqueKey;
				
	        item.Save(UserName);
	    }
    }
}
