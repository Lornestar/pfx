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
	/// Strongly-typed collection for the AspnetWebEventEvent class.
	/// </summary>
    [Serializable]
	public partial class AspnetWebEventEventCollection : ActiveList<AspnetWebEventEvent, AspnetWebEventEventCollection>
	{	   
		public AspnetWebEventEventCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AspnetWebEventEventCollection</returns>
		public AspnetWebEventEventCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AspnetWebEventEvent o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the aspnet_WebEvent_Events table.
	/// </summary>
	[Serializable]
	public partial class AspnetWebEventEvent : ActiveRecord<AspnetWebEventEvent>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AspnetWebEventEvent()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AspnetWebEventEvent(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AspnetWebEventEvent(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AspnetWebEventEvent(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("aspnet_WebEvent_Events", TableType.Table, DataService.GetInstance("Peerfx"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarEventId = new TableSchema.TableColumn(schema);
				colvarEventId.ColumnName = "EventId";
				colvarEventId.DataType = DbType.AnsiStringFixedLength;
				colvarEventId.MaxLength = 32;
				colvarEventId.AutoIncrement = false;
				colvarEventId.IsNullable = false;
				colvarEventId.IsPrimaryKey = true;
				colvarEventId.IsForeignKey = false;
				colvarEventId.IsReadOnly = false;
				colvarEventId.DefaultSetting = @"";
				colvarEventId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventId);
				
				TableSchema.TableColumn colvarEventTimeUtc = new TableSchema.TableColumn(schema);
				colvarEventTimeUtc.ColumnName = "EventTimeUtc";
				colvarEventTimeUtc.DataType = DbType.DateTime;
				colvarEventTimeUtc.MaxLength = 0;
				colvarEventTimeUtc.AutoIncrement = false;
				colvarEventTimeUtc.IsNullable = false;
				colvarEventTimeUtc.IsPrimaryKey = false;
				colvarEventTimeUtc.IsForeignKey = false;
				colvarEventTimeUtc.IsReadOnly = false;
				colvarEventTimeUtc.DefaultSetting = @"";
				colvarEventTimeUtc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventTimeUtc);
				
				TableSchema.TableColumn colvarEventTime = new TableSchema.TableColumn(schema);
				colvarEventTime.ColumnName = "EventTime";
				colvarEventTime.DataType = DbType.DateTime;
				colvarEventTime.MaxLength = 0;
				colvarEventTime.AutoIncrement = false;
				colvarEventTime.IsNullable = false;
				colvarEventTime.IsPrimaryKey = false;
				colvarEventTime.IsForeignKey = false;
				colvarEventTime.IsReadOnly = false;
				colvarEventTime.DefaultSetting = @"";
				colvarEventTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventTime);
				
				TableSchema.TableColumn colvarEventType = new TableSchema.TableColumn(schema);
				colvarEventType.ColumnName = "EventType";
				colvarEventType.DataType = DbType.String;
				colvarEventType.MaxLength = 256;
				colvarEventType.AutoIncrement = false;
				colvarEventType.IsNullable = false;
				colvarEventType.IsPrimaryKey = false;
				colvarEventType.IsForeignKey = false;
				colvarEventType.IsReadOnly = false;
				colvarEventType.DefaultSetting = @"";
				colvarEventType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventType);
				
				TableSchema.TableColumn colvarEventSequence = new TableSchema.TableColumn(schema);
				colvarEventSequence.ColumnName = "EventSequence";
				colvarEventSequence.DataType = DbType.Decimal;
				colvarEventSequence.MaxLength = 0;
				colvarEventSequence.AutoIncrement = false;
				colvarEventSequence.IsNullable = false;
				colvarEventSequence.IsPrimaryKey = false;
				colvarEventSequence.IsForeignKey = false;
				colvarEventSequence.IsReadOnly = false;
				colvarEventSequence.DefaultSetting = @"";
				colvarEventSequence.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventSequence);
				
				TableSchema.TableColumn colvarEventOccurrence = new TableSchema.TableColumn(schema);
				colvarEventOccurrence.ColumnName = "EventOccurrence";
				colvarEventOccurrence.DataType = DbType.Decimal;
				colvarEventOccurrence.MaxLength = 0;
				colvarEventOccurrence.AutoIncrement = false;
				colvarEventOccurrence.IsNullable = false;
				colvarEventOccurrence.IsPrimaryKey = false;
				colvarEventOccurrence.IsForeignKey = false;
				colvarEventOccurrence.IsReadOnly = false;
				colvarEventOccurrence.DefaultSetting = @"";
				colvarEventOccurrence.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventOccurrence);
				
				TableSchema.TableColumn colvarEventCode = new TableSchema.TableColumn(schema);
				colvarEventCode.ColumnName = "EventCode";
				colvarEventCode.DataType = DbType.Int32;
				colvarEventCode.MaxLength = 0;
				colvarEventCode.AutoIncrement = false;
				colvarEventCode.IsNullable = false;
				colvarEventCode.IsPrimaryKey = false;
				colvarEventCode.IsForeignKey = false;
				colvarEventCode.IsReadOnly = false;
				colvarEventCode.DefaultSetting = @"";
				colvarEventCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventCode);
				
				TableSchema.TableColumn colvarEventDetailCode = new TableSchema.TableColumn(schema);
				colvarEventDetailCode.ColumnName = "EventDetailCode";
				colvarEventDetailCode.DataType = DbType.Int32;
				colvarEventDetailCode.MaxLength = 0;
				colvarEventDetailCode.AutoIncrement = false;
				colvarEventDetailCode.IsNullable = false;
				colvarEventDetailCode.IsPrimaryKey = false;
				colvarEventDetailCode.IsForeignKey = false;
				colvarEventDetailCode.IsReadOnly = false;
				colvarEventDetailCode.DefaultSetting = @"";
				colvarEventDetailCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventDetailCode);
				
				TableSchema.TableColumn colvarMessage = new TableSchema.TableColumn(schema);
				colvarMessage.ColumnName = "Message";
				colvarMessage.DataType = DbType.String;
				colvarMessage.MaxLength = 1024;
				colvarMessage.AutoIncrement = false;
				colvarMessage.IsNullable = true;
				colvarMessage.IsPrimaryKey = false;
				colvarMessage.IsForeignKey = false;
				colvarMessage.IsReadOnly = false;
				colvarMessage.DefaultSetting = @"";
				colvarMessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMessage);
				
				TableSchema.TableColumn colvarApplicationPath = new TableSchema.TableColumn(schema);
				colvarApplicationPath.ColumnName = "ApplicationPath";
				colvarApplicationPath.DataType = DbType.String;
				colvarApplicationPath.MaxLength = 256;
				colvarApplicationPath.AutoIncrement = false;
				colvarApplicationPath.IsNullable = true;
				colvarApplicationPath.IsPrimaryKey = false;
				colvarApplicationPath.IsForeignKey = false;
				colvarApplicationPath.IsReadOnly = false;
				colvarApplicationPath.DefaultSetting = @"";
				colvarApplicationPath.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApplicationPath);
				
				TableSchema.TableColumn colvarApplicationVirtualPath = new TableSchema.TableColumn(schema);
				colvarApplicationVirtualPath.ColumnName = "ApplicationVirtualPath";
				colvarApplicationVirtualPath.DataType = DbType.String;
				colvarApplicationVirtualPath.MaxLength = 256;
				colvarApplicationVirtualPath.AutoIncrement = false;
				colvarApplicationVirtualPath.IsNullable = true;
				colvarApplicationVirtualPath.IsPrimaryKey = false;
				colvarApplicationVirtualPath.IsForeignKey = false;
				colvarApplicationVirtualPath.IsReadOnly = false;
				colvarApplicationVirtualPath.DefaultSetting = @"";
				colvarApplicationVirtualPath.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApplicationVirtualPath);
				
				TableSchema.TableColumn colvarMachineName = new TableSchema.TableColumn(schema);
				colvarMachineName.ColumnName = "MachineName";
				colvarMachineName.DataType = DbType.String;
				colvarMachineName.MaxLength = 256;
				colvarMachineName.AutoIncrement = false;
				colvarMachineName.IsNullable = false;
				colvarMachineName.IsPrimaryKey = false;
				colvarMachineName.IsForeignKey = false;
				colvarMachineName.IsReadOnly = false;
				colvarMachineName.DefaultSetting = @"";
				colvarMachineName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMachineName);
				
				TableSchema.TableColumn colvarRequestUrl = new TableSchema.TableColumn(schema);
				colvarRequestUrl.ColumnName = "RequestUrl";
				colvarRequestUrl.DataType = DbType.String;
				colvarRequestUrl.MaxLength = 1024;
				colvarRequestUrl.AutoIncrement = false;
				colvarRequestUrl.IsNullable = true;
				colvarRequestUrl.IsPrimaryKey = false;
				colvarRequestUrl.IsForeignKey = false;
				colvarRequestUrl.IsReadOnly = false;
				colvarRequestUrl.DefaultSetting = @"";
				colvarRequestUrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRequestUrl);
				
				TableSchema.TableColumn colvarExceptionType = new TableSchema.TableColumn(schema);
				colvarExceptionType.ColumnName = "ExceptionType";
				colvarExceptionType.DataType = DbType.String;
				colvarExceptionType.MaxLength = 256;
				colvarExceptionType.AutoIncrement = false;
				colvarExceptionType.IsNullable = true;
				colvarExceptionType.IsPrimaryKey = false;
				colvarExceptionType.IsForeignKey = false;
				colvarExceptionType.IsReadOnly = false;
				colvarExceptionType.DefaultSetting = @"";
				colvarExceptionType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExceptionType);
				
				TableSchema.TableColumn colvarDetails = new TableSchema.TableColumn(schema);
				colvarDetails.ColumnName = "Details";
				colvarDetails.DataType = DbType.String;
				colvarDetails.MaxLength = 1073741823;
				colvarDetails.AutoIncrement = false;
				colvarDetails.IsNullable = true;
				colvarDetails.IsPrimaryKey = false;
				colvarDetails.IsForeignKey = false;
				colvarDetails.IsReadOnly = false;
				colvarDetails.DefaultSetting = @"";
				colvarDetails.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDetails);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Peerfx"].AddSchema("aspnet_WebEvent_Events",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("EventId")]
		[Bindable(true)]
		public string EventId 
		{
			get { return GetColumnValue<string>(Columns.EventId); }
			set { SetColumnValue(Columns.EventId, value); }
		}
		  
		[XmlAttribute("EventTimeUtc")]
		[Bindable(true)]
		public DateTime EventTimeUtc 
		{
			get { return GetColumnValue<DateTime>(Columns.EventTimeUtc); }
			set { SetColumnValue(Columns.EventTimeUtc, value); }
		}
		  
		[XmlAttribute("EventTime")]
		[Bindable(true)]
		public DateTime EventTime 
		{
			get { return GetColumnValue<DateTime>(Columns.EventTime); }
			set { SetColumnValue(Columns.EventTime, value); }
		}
		  
		[XmlAttribute("EventType")]
		[Bindable(true)]
		public string EventType 
		{
			get { return GetColumnValue<string>(Columns.EventType); }
			set { SetColumnValue(Columns.EventType, value); }
		}
		  
		[XmlAttribute("EventSequence")]
		[Bindable(true)]
		public decimal EventSequence 
		{
			get { return GetColumnValue<decimal>(Columns.EventSequence); }
			set { SetColumnValue(Columns.EventSequence, value); }
		}
		  
		[XmlAttribute("EventOccurrence")]
		[Bindable(true)]
		public decimal EventOccurrence 
		{
			get { return GetColumnValue<decimal>(Columns.EventOccurrence); }
			set { SetColumnValue(Columns.EventOccurrence, value); }
		}
		  
		[XmlAttribute("EventCode")]
		[Bindable(true)]
		public int EventCode 
		{
			get { return GetColumnValue<int>(Columns.EventCode); }
			set { SetColumnValue(Columns.EventCode, value); }
		}
		  
		[XmlAttribute("EventDetailCode")]
		[Bindable(true)]
		public int EventDetailCode 
		{
			get { return GetColumnValue<int>(Columns.EventDetailCode); }
			set { SetColumnValue(Columns.EventDetailCode, value); }
		}
		  
		[XmlAttribute("Message")]
		[Bindable(true)]
		public string Message 
		{
			get { return GetColumnValue<string>(Columns.Message); }
			set { SetColumnValue(Columns.Message, value); }
		}
		  
		[XmlAttribute("ApplicationPath")]
		[Bindable(true)]
		public string ApplicationPath 
		{
			get { return GetColumnValue<string>(Columns.ApplicationPath); }
			set { SetColumnValue(Columns.ApplicationPath, value); }
		}
		  
		[XmlAttribute("ApplicationVirtualPath")]
		[Bindable(true)]
		public string ApplicationVirtualPath 
		{
			get { return GetColumnValue<string>(Columns.ApplicationVirtualPath); }
			set { SetColumnValue(Columns.ApplicationVirtualPath, value); }
		}
		  
		[XmlAttribute("MachineName")]
		[Bindable(true)]
		public string MachineName 
		{
			get { return GetColumnValue<string>(Columns.MachineName); }
			set { SetColumnValue(Columns.MachineName, value); }
		}
		  
		[XmlAttribute("RequestUrl")]
		[Bindable(true)]
		public string RequestUrl 
		{
			get { return GetColumnValue<string>(Columns.RequestUrl); }
			set { SetColumnValue(Columns.RequestUrl, value); }
		}
		  
		[XmlAttribute("ExceptionType")]
		[Bindable(true)]
		public string ExceptionType 
		{
			get { return GetColumnValue<string>(Columns.ExceptionType); }
			set { SetColumnValue(Columns.ExceptionType, value); }
		}
		  
		[XmlAttribute("Details")]
		[Bindable(true)]
		public string Details 
		{
			get { return GetColumnValue<string>(Columns.Details); }
			set { SetColumnValue(Columns.Details, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varEventId,DateTime varEventTimeUtc,DateTime varEventTime,string varEventType,decimal varEventSequence,decimal varEventOccurrence,int varEventCode,int varEventDetailCode,string varMessage,string varApplicationPath,string varApplicationVirtualPath,string varMachineName,string varRequestUrl,string varExceptionType,string varDetails)
		{
			AspnetWebEventEvent item = new AspnetWebEventEvent();
			
			item.EventId = varEventId;
			
			item.EventTimeUtc = varEventTimeUtc;
			
			item.EventTime = varEventTime;
			
			item.EventType = varEventType;
			
			item.EventSequence = varEventSequence;
			
			item.EventOccurrence = varEventOccurrence;
			
			item.EventCode = varEventCode;
			
			item.EventDetailCode = varEventDetailCode;
			
			item.Message = varMessage;
			
			item.ApplicationPath = varApplicationPath;
			
			item.ApplicationVirtualPath = varApplicationVirtualPath;
			
			item.MachineName = varMachineName;
			
			item.RequestUrl = varRequestUrl;
			
			item.ExceptionType = varExceptionType;
			
			item.Details = varDetails;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varEventId,DateTime varEventTimeUtc,DateTime varEventTime,string varEventType,decimal varEventSequence,decimal varEventOccurrence,int varEventCode,int varEventDetailCode,string varMessage,string varApplicationPath,string varApplicationVirtualPath,string varMachineName,string varRequestUrl,string varExceptionType,string varDetails)
		{
			AspnetWebEventEvent item = new AspnetWebEventEvent();
			
				item.EventId = varEventId;
			
				item.EventTimeUtc = varEventTimeUtc;
			
				item.EventTime = varEventTime;
			
				item.EventType = varEventType;
			
				item.EventSequence = varEventSequence;
			
				item.EventOccurrence = varEventOccurrence;
			
				item.EventCode = varEventCode;
			
				item.EventDetailCode = varEventDetailCode;
			
				item.Message = varMessage;
			
				item.ApplicationPath = varApplicationPath;
			
				item.ApplicationVirtualPath = varApplicationVirtualPath;
			
				item.MachineName = varMachineName;
			
				item.RequestUrl = varRequestUrl;
			
				item.ExceptionType = varExceptionType;
			
				item.Details = varDetails;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn EventIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn EventTimeUtcColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn EventTimeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EventTypeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EventSequenceColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn EventOccurrenceColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn EventCodeColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn EventDetailCodeColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn MessageColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ApplicationPathColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ApplicationVirtualPathColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn MachineNameColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn RequestUrlColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ExceptionTypeColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn DetailsColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string EventId = @"EventId";
			 public static string EventTimeUtc = @"EventTimeUtc";
			 public static string EventTime = @"EventTime";
			 public static string EventType = @"EventType";
			 public static string EventSequence = @"EventSequence";
			 public static string EventOccurrence = @"EventOccurrence";
			 public static string EventCode = @"EventCode";
			 public static string EventDetailCode = @"EventDetailCode";
			 public static string Message = @"Message";
			 public static string ApplicationPath = @"ApplicationPath";
			 public static string ApplicationVirtualPath = @"ApplicationVirtualPath";
			 public static string MachineName = @"MachineName";
			 public static string RequestUrl = @"RequestUrl";
			 public static string ExceptionType = @"ExceptionType";
			 public static string Details = @"Details";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
