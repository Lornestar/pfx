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
    /// Controller class for Payment_Status
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PaymentStatusController
    {
        // Preload our schema..
        PaymentStatus thisSchemaLoad = new PaymentStatus();
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
        public PaymentStatusCollection FetchAll()
        {
            PaymentStatusCollection coll = new PaymentStatusCollection();
            Query qry = new Query(PaymentStatus.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PaymentStatusCollection FetchByID(object PaymentStatusKey)
        {
            PaymentStatusCollection coll = new PaymentStatusCollection().Where("payment_status_key", PaymentStatusKey).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PaymentStatusCollection FetchByQuery(Query qry)
        {
            PaymentStatusCollection coll = new PaymentStatusCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object PaymentStatusKey)
        {
            return (PaymentStatus.Delete(PaymentStatusKey) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object PaymentStatusKey)
        {
            return (PaymentStatus.Destroy(PaymentStatusKey) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int PaymentStatusKey,string PaymentStatusDescription)
	    {
		    PaymentStatus item = new PaymentStatus();
		    
            item.PaymentStatusKey = PaymentStatusKey;
            
            item.PaymentStatusDescription = PaymentStatusDescription;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int PaymentStatusKey,string PaymentStatusDescription)
	    {
		    PaymentStatus item = new PaymentStatus();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.PaymentStatusKey = PaymentStatusKey;
				
			item.PaymentStatusDescription = PaymentStatusDescription;
				
	        item.Save(UserName);
	    }
    }
}
