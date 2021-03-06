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
    /// Controller class for CurrencyCloud_API_Errors
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CurrencyCloudApiErrorController
    {
        // Preload our schema..
        CurrencyCloudApiError thisSchemaLoad = new CurrencyCloudApiError();
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
        public CurrencyCloudApiErrorCollection FetchAll()
        {
            CurrencyCloudApiErrorCollection coll = new CurrencyCloudApiErrorCollection();
            Query qry = new Query(CurrencyCloudApiError.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CurrencyCloudApiErrorCollection FetchByID(object CurrencycloudApiErrors)
        {
            CurrencyCloudApiErrorCollection coll = new CurrencyCloudApiErrorCollection().Where("currencycloud_api_errors", CurrencycloudApiErrors).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CurrencyCloudApiErrorCollection FetchByQuery(Query qry)
        {
            CurrencyCloudApiErrorCollection coll = new CurrencyCloudApiErrorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CurrencycloudApiErrors)
        {
            return (CurrencyCloudApiError.Delete(CurrencycloudApiErrors) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CurrencycloudApiErrors)
        {
            return (CurrencyCloudApiError.Destroy(CurrencycloudApiErrors) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CurrencycloudApiDescription,DateTime? Dateoccured)
	    {
		    CurrencyCloudApiError item = new CurrencyCloudApiError();
		    
            item.CurrencycloudApiDescription = CurrencycloudApiDescription;
            
            item.Dateoccured = Dateoccured;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CurrencycloudApiErrors,string CurrencycloudApiDescription,DateTime? Dateoccured)
	    {
		    CurrencyCloudApiError item = new CurrencyCloudApiError();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CurrencycloudApiErrors = CurrencycloudApiErrors;
				
			item.CurrencycloudApiDescription = CurrencycloudApiDescription;
				
			item.Dateoccured = Dateoccured;
				
	        item.Save(UserName);
	    }
    }
}
