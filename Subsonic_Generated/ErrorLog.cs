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
	/// Strongly-typed collection for the ErrorLog class.
	/// </summary>
    [Serializable]
	public partial class ErrorLogCollection : ActiveList<ErrorLog, ErrorLogCollection>
	{	   
		public ErrorLogCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ErrorLogCollection</returns>
		public ErrorLogCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ErrorLog o = this[i];
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
	/// This is an ActiveRecord class which wraps the Error_Log table.
	/// </summary>
	[Serializable]
	public partial class ErrorLog : ActiveRecord<ErrorLog>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ErrorLog()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ErrorLog(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ErrorLog(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ErrorLog(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Error_Log", TableType.Table, DataService.GetInstance("Peerfx"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "Id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarDateX = new TableSchema.TableColumn(schema);
				colvarDateX.ColumnName = "Date";
				colvarDateX.DataType = DbType.DateTime;
				colvarDateX.MaxLength = 0;
				colvarDateX.AutoIncrement = false;
				colvarDateX.IsNullable = false;
				colvarDateX.IsPrimaryKey = false;
				colvarDateX.IsForeignKey = false;
				colvarDateX.IsReadOnly = false;
				colvarDateX.DefaultSetting = @"";
				colvarDateX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateX);
				
				TableSchema.TableColumn colvarThread = new TableSchema.TableColumn(schema);
				colvarThread.ColumnName = "Thread";
				colvarThread.DataType = DbType.AnsiString;
				colvarThread.MaxLength = 255;
				colvarThread.AutoIncrement = false;
				colvarThread.IsNullable = false;
				colvarThread.IsPrimaryKey = false;
				colvarThread.IsForeignKey = false;
				colvarThread.IsReadOnly = false;
				colvarThread.DefaultSetting = @"";
				colvarThread.ForeignKeyTableName = "";
				schema.Columns.Add(colvarThread);
				
				TableSchema.TableColumn colvarLevel = new TableSchema.TableColumn(schema);
				colvarLevel.ColumnName = "Level";
				colvarLevel.DataType = DbType.AnsiString;
				colvarLevel.MaxLength = 50;
				colvarLevel.AutoIncrement = false;
				colvarLevel.IsNullable = false;
				colvarLevel.IsPrimaryKey = false;
				colvarLevel.IsForeignKey = false;
				colvarLevel.IsReadOnly = false;
				colvarLevel.DefaultSetting = @"";
				colvarLevel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLevel);
				
				TableSchema.TableColumn colvarLogger = new TableSchema.TableColumn(schema);
				colvarLogger.ColumnName = "Logger";
				colvarLogger.DataType = DbType.AnsiString;
				colvarLogger.MaxLength = 255;
				colvarLogger.AutoIncrement = false;
				colvarLogger.IsNullable = false;
				colvarLogger.IsPrimaryKey = false;
				colvarLogger.IsForeignKey = false;
				colvarLogger.IsReadOnly = false;
				colvarLogger.DefaultSetting = @"";
				colvarLogger.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLogger);
				
				TableSchema.TableColumn colvarMessage = new TableSchema.TableColumn(schema);
				colvarMessage.ColumnName = "Message";
				colvarMessage.DataType = DbType.AnsiString;
				colvarMessage.MaxLength = 4000;
				colvarMessage.AutoIncrement = false;
				colvarMessage.IsNullable = false;
				colvarMessage.IsPrimaryKey = false;
				colvarMessage.IsForeignKey = false;
				colvarMessage.IsReadOnly = false;
				colvarMessage.DefaultSetting = @"";
				colvarMessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMessage);
				
				TableSchema.TableColumn colvarException = new TableSchema.TableColumn(schema);
				colvarException.ColumnName = "Exception";
				colvarException.DataType = DbType.AnsiString;
				colvarException.MaxLength = 2000;
				colvarException.AutoIncrement = false;
				colvarException.IsNullable = true;
				colvarException.IsPrimaryKey = false;
				colvarException.IsForeignKey = false;
				colvarException.IsReadOnly = false;
				colvarException.DefaultSetting = @"";
				colvarException.ForeignKeyTableName = "";
				schema.Columns.Add(colvarException);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Peerfx"].AddSchema("Error_Log",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("DateX")]
		[Bindable(true)]
		public DateTime DateX 
		{
			get { return GetColumnValue<DateTime>(Columns.DateX); }
			set { SetColumnValue(Columns.DateX, value); }
		}
		  
		[XmlAttribute("Thread")]
		[Bindable(true)]
		public string Thread 
		{
			get { return GetColumnValue<string>(Columns.Thread); }
			set { SetColumnValue(Columns.Thread, value); }
		}
		  
		[XmlAttribute("Level")]
		[Bindable(true)]
		public string Level 
		{
			get { return GetColumnValue<string>(Columns.Level); }
			set { SetColumnValue(Columns.Level, value); }
		}
		  
		[XmlAttribute("Logger")]
		[Bindable(true)]
		public string Logger 
		{
			get { return GetColumnValue<string>(Columns.Logger); }
			set { SetColumnValue(Columns.Logger, value); }
		}
		  
		[XmlAttribute("Message")]
		[Bindable(true)]
		public string Message 
		{
			get { return GetColumnValue<string>(Columns.Message); }
			set { SetColumnValue(Columns.Message, value); }
		}
		  
		[XmlAttribute("Exception")]
		[Bindable(true)]
		public string Exception 
		{
			get { return GetColumnValue<string>(Columns.Exception); }
			set { SetColumnValue(Columns.Exception, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime varDateX,string varThread,string varLevel,string varLogger,string varMessage,string varException)
		{
			ErrorLog item = new ErrorLog();
			
			item.DateX = varDateX;
			
			item.Thread = varThread;
			
			item.Level = varLevel;
			
			item.Logger = varLogger;
			
			item.Message = varMessage;
			
			item.Exception = varException;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,DateTime varDateX,string varThread,string varLevel,string varLogger,string varMessage,string varException)
		{
			ErrorLog item = new ErrorLog();
			
				item.Id = varId;
			
				item.DateX = varDateX;
			
				item.Thread = varThread;
			
				item.Level = varLevel;
			
				item.Logger = varLogger;
			
				item.Message = varMessage;
			
				item.Exception = varException;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DateXColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ThreadColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn LevelColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn LoggerColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn MessageColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ExceptionColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string DateX = @"Date";
			 public static string Thread = @"Thread";
			 public static string Level = @"Level";
			 public static string Logger = @"Logger";
			 public static string Message = @"Message";
			 public static string Exception = @"Exception";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
