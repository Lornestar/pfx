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
    /// Controller class for aspnet_WebEvent_Events
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AspnetWebEventEventController
    {
        // Preload our schema..
        AspnetWebEventEvent thisSchemaLoad = new AspnetWebEventEvent();
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
        public AspnetWebEventEventCollection FetchAll()
        {
            AspnetWebEventEventCollection coll = new AspnetWebEventEventCollection();
            Query qry = new Query(AspnetWebEventEvent.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AspnetWebEventEventCollection FetchByID(object EventId)
        {
            AspnetWebEventEventCollection coll = new AspnetWebEventEventCollection().Where("EventId", EventId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AspnetWebEventEventCollection FetchByQuery(Query qry)
        {
            AspnetWebEventEventCollection coll = new AspnetWebEventEventCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object EventId)
        {
            return (AspnetWebEventEvent.Delete(EventId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object EventId)
        {
            return (AspnetWebEventEvent.Destroy(EventId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string EventId,DateTime EventTimeUtc,DateTime EventTime,string EventType,decimal EventSequence,decimal EventOccurrence,int EventCode,int EventDetailCode,string Message,string ApplicationPath,string ApplicationVirtualPath,string MachineName,string RequestUrl,string ExceptionType,string Details)
	    {
		    AspnetWebEventEvent item = new AspnetWebEventEvent();
		    
            item.EventId = EventId;
            
            item.EventTimeUtc = EventTimeUtc;
            
            item.EventTime = EventTime;
            
            item.EventType = EventType;
            
            item.EventSequence = EventSequence;
            
            item.EventOccurrence = EventOccurrence;
            
            item.EventCode = EventCode;
            
            item.EventDetailCode = EventDetailCode;
            
            item.Message = Message;
            
            item.ApplicationPath = ApplicationPath;
            
            item.ApplicationVirtualPath = ApplicationVirtualPath;
            
            item.MachineName = MachineName;
            
            item.RequestUrl = RequestUrl;
            
            item.ExceptionType = ExceptionType;
            
            item.Details = Details;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string EventId,DateTime EventTimeUtc,DateTime EventTime,string EventType,decimal EventSequence,decimal EventOccurrence,int EventCode,int EventDetailCode,string Message,string ApplicationPath,string ApplicationVirtualPath,string MachineName,string RequestUrl,string ExceptionType,string Details)
	    {
		    AspnetWebEventEvent item = new AspnetWebEventEvent();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.EventId = EventId;
				
			item.EventTimeUtc = EventTimeUtc;
				
			item.EventTime = EventTime;
				
			item.EventType = EventType;
				
			item.EventSequence = EventSequence;
				
			item.EventOccurrence = EventOccurrence;
				
			item.EventCode = EventCode;
				
			item.EventDetailCode = EventDetailCode;
				
			item.Message = Message;
				
			item.ApplicationPath = ApplicationPath;
				
			item.ApplicationVirtualPath = ApplicationVirtualPath;
				
			item.MachineName = MachineName;
				
			item.RequestUrl = RequestUrl;
				
			item.ExceptionType = ExceptionType;
				
			item.Details = Details;
				
	        item.Save(UserName);
	    }
    }
}
