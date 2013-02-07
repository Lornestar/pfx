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
    /// Controller class for Recipients
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RecipientController
    {
        // Preload our schema..
        Recipient thisSchemaLoad = new Recipient();
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
        public RecipientCollection FetchAll()
        {
            RecipientCollection coll = new RecipientCollection();
            Query qry = new Query(Recipient.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RecipientCollection FetchByID(object RecipientsKey)
        {
            RecipientCollection coll = new RecipientCollection().Where("recipients_key", RecipientsKey).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RecipientCollection FetchByQuery(Query qry)
        {
            RecipientCollection coll = new RecipientCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object RecipientsKey)
        {
            return (Recipient.Delete(RecipientsKey) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object RecipientsKey)
        {
            return (Recipient.Destroy(RecipientsKey) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int UserKey,long PaymentObjectKey)
	    {
		    Recipient item = new Recipient();
		    
            item.UserKey = UserKey;
            
            item.PaymentObjectKey = PaymentObjectKey;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int RecipientsKey,int UserKey,long PaymentObjectKey)
	    {
		    Recipient item = new Recipient();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.RecipientsKey = RecipientsKey;
				
			item.UserKey = UserKey;
				
			item.PaymentObjectKey = PaymentObjectKey;
				
	        item.Save(UserName);
	    }
    }
}
