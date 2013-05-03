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
    /// Controller class for Users_Bancbox
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UsersBancboxController
    {
        // Preload our schema..
        UsersBancbox thisSchemaLoad = new UsersBancbox();
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
        public UsersBancboxCollection FetchAll()
        {
            UsersBancboxCollection coll = new UsersBancboxCollection();
            Query qry = new Query(UsersBancbox.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UsersBancboxCollection FetchByID(object UserKey)
        {
            UsersBancboxCollection coll = new UsersBancboxCollection().Where("user_key", UserKey).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UsersBancboxCollection FetchByQuery(Query qry)
        {
            UsersBancboxCollection coll = new UsersBancboxCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UserKey)
        {
            return (UsersBancbox.Delete(UserKey) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UserKey)
        {
            return (UsersBancbox.Destroy(UserKey) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int UserKey,int? ClientId,string ClientStatus,string CipStatus)
	    {
		    UsersBancbox item = new UsersBancbox();
		    
            item.UserKey = UserKey;
            
            item.ClientId = ClientId;
            
            item.ClientStatus = ClientStatus;
            
            item.CipStatus = CipStatus;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int UserKey,int? ClientId,string ClientStatus,string CipStatus)
	    {
		    UsersBancbox item = new UsersBancbox();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.UserKey = UserKey;
				
			item.ClientId = ClientId;
				
			item.ClientStatus = ClientStatus;
				
			item.CipStatus = CipStatus;
				
	        item.Save(UserName);
	    }
    }
}
