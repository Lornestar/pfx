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
    /// Controller class for Payments
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PaymentController
    {
        // Preload our schema..
        Payment thisSchemaLoad = new Payment();
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
        public PaymentCollection FetchAll()
        {
            PaymentCollection coll = new PaymentCollection();
            Query qry = new Query(Payment.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PaymentCollection FetchByID(object PaymentsKey)
        {
            PaymentCollection coll = new PaymentCollection().Where("payments_key", PaymentsKey).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PaymentCollection FetchByQuery(Query qry)
        {
            PaymentCollection coll = new PaymentCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object PaymentsKey)
        {
            return (Payment.Delete(PaymentsKey) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object PaymentsKey)
        {
            return (Payment.Destroy(PaymentsKey) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int QuoteKey,int? QuoteKeyActual,int PaymentStatus,DateTime DateCreated,int? RequestorUserKey,long? PaymentObjectSender,long? PaymentObjectReceiver,string PaymentDescription,int? TreasuryType)
	    {
		    Payment item = new Payment();
		    
            item.QuoteKey = QuoteKey;
            
            item.QuoteKeyActual = QuoteKeyActual;
            
            item.PaymentStatus = PaymentStatus;
            
            item.DateCreated = DateCreated;
            
            item.RequestorUserKey = RequestorUserKey;
            
            item.PaymentObjectSender = PaymentObjectSender;
            
            item.PaymentObjectReceiver = PaymentObjectReceiver;
            
            item.PaymentDescription = PaymentDescription;
            
            item.TreasuryType = TreasuryType;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int PaymentsKey,int QuoteKey,int? QuoteKeyActual,int PaymentStatus,DateTime DateCreated,int? RequestorUserKey,long? PaymentObjectSender,long? PaymentObjectReceiver,string PaymentDescription,int? TreasuryType)
	    {
		    Payment item = new Payment();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.PaymentsKey = PaymentsKey;
				
			item.QuoteKey = QuoteKey;
				
			item.QuoteKeyActual = QuoteKeyActual;
				
			item.PaymentStatus = PaymentStatus;
				
			item.DateCreated = DateCreated;
				
			item.RequestorUserKey = RequestorUserKey;
				
			item.PaymentObjectSender = PaymentObjectSender;
				
			item.PaymentObjectReceiver = PaymentObjectReceiver;
				
			item.PaymentDescription = PaymentDescription;
				
			item.TreasuryType = TreasuryType;
				
	        item.Save(UserName);
	    }
    }
}
