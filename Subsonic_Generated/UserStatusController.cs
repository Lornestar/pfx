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
    /// Controller class for User_Statuses
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UserStatusController
    {
        // Preload our schema..
        UserStatus thisSchemaLoad = new UserStatus();
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
        public UserStatusCollection FetchAll()
        {
            UserStatusCollection coll = new UserStatusCollection();
            Query qry = new Query(UserStatus.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserStatusCollection FetchByID(object UserStatusKey)
        {
            UserStatusCollection coll = new UserStatusCollection().Where("user_status_key", UserStatusKey).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserStatusCollection FetchByQuery(Query qry)
        {
            UserStatusCollection coll = new UserStatusCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UserStatusKey)
        {
            return (UserStatus.Delete(UserStatusKey) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UserStatusKey)
        {
            return (UserStatus.Destroy(UserStatusKey) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int UserStatusKey,string StatusDescription)
	    {
		    UserStatus item = new UserStatus();
		    
            item.UserStatusKey = UserStatusKey;
            
            item.StatusDescription = StatusDescription;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int UserStatusKey,string StatusDescription)
	    {
		    UserStatus item = new UserStatus();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.UserStatusKey = UserStatusKey;
				
			item.StatusDescription = StatusDescription;
				
	        item.Save(UserName);
	    }
    }
}
