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
	/// Strongly-typed collection for the ScheduledTask class.
	/// </summary>
    [Serializable]
	public partial class ScheduledTaskCollection : ActiveList<ScheduledTask, ScheduledTaskCollection>
	{	   
		public ScheduledTaskCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ScheduledTaskCollection</returns>
		public ScheduledTaskCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ScheduledTask o = this[i];
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
	/// This is an ActiveRecord class which wraps the Scheduled_Task table.
	/// </summary>
	[Serializable]
	public partial class ScheduledTask : ActiveRecord<ScheduledTask>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ScheduledTask()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ScheduledTask(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ScheduledTask(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ScheduledTask(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Scheduled_Task", TableType.Table, DataService.GetInstance("Peerfx"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarScheduledTaskKey = new TableSchema.TableColumn(schema);
				colvarScheduledTaskKey.ColumnName = "scheduled_task_key";
				colvarScheduledTaskKey.DataType = DbType.Int32;
				colvarScheduledTaskKey.MaxLength = 0;
				colvarScheduledTaskKey.AutoIncrement = true;
				colvarScheduledTaskKey.IsNullable = false;
				colvarScheduledTaskKey.IsPrimaryKey = true;
				colvarScheduledTaskKey.IsForeignKey = false;
				colvarScheduledTaskKey.IsReadOnly = false;
				colvarScheduledTaskKey.DefaultSetting = @"";
				colvarScheduledTaskKey.ForeignKeyTableName = "";
				schema.Columns.Add(colvarScheduledTaskKey);
				
				TableSchema.TableColumn colvarScheduledTaskType = new TableSchema.TableColumn(schema);
				colvarScheduledTaskType.ColumnName = "scheduled_task_type";
				colvarScheduledTaskType.DataType = DbType.Int32;
				colvarScheduledTaskType.MaxLength = 0;
				colvarScheduledTaskType.AutoIncrement = false;
				colvarScheduledTaskType.IsNullable = false;
				colvarScheduledTaskType.IsPrimaryKey = false;
				colvarScheduledTaskType.IsForeignKey = false;
				colvarScheduledTaskType.IsReadOnly = false;
				colvarScheduledTaskType.DefaultSetting = @"";
				colvarScheduledTaskType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarScheduledTaskType);
				
				TableSchema.TableColumn colvarDateChanged = new TableSchema.TableColumn(schema);
				colvarDateChanged.ColumnName = "date_changed";
				colvarDateChanged.DataType = DbType.DateTime;
				colvarDateChanged.MaxLength = 0;
				colvarDateChanged.AutoIncrement = false;
				colvarDateChanged.IsNullable = false;
				colvarDateChanged.IsPrimaryKey = false;
				colvarDateChanged.IsForeignKey = false;
				colvarDateChanged.IsReadOnly = false;
				colvarDateChanged.DefaultSetting = @"";
				colvarDateChanged.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateChanged);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Peerfx"].AddSchema("Scheduled_Task",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ScheduledTaskKey")]
		[Bindable(true)]
		public int ScheduledTaskKey 
		{
			get { return GetColumnValue<int>(Columns.ScheduledTaskKey); }
			set { SetColumnValue(Columns.ScheduledTaskKey, value); }
		}
		  
		[XmlAttribute("ScheduledTaskType")]
		[Bindable(true)]
		public int ScheduledTaskType 
		{
			get { return GetColumnValue<int>(Columns.ScheduledTaskType); }
			set { SetColumnValue(Columns.ScheduledTaskType, value); }
		}
		  
		[XmlAttribute("DateChanged")]
		[Bindable(true)]
		public DateTime DateChanged 
		{
			get { return GetColumnValue<DateTime>(Columns.DateChanged); }
			set { SetColumnValue(Columns.DateChanged, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varScheduledTaskType,DateTime varDateChanged)
		{
			ScheduledTask item = new ScheduledTask();
			
			item.ScheduledTaskType = varScheduledTaskType;
			
			item.DateChanged = varDateChanged;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varScheduledTaskKey,int varScheduledTaskType,DateTime varDateChanged)
		{
			ScheduledTask item = new ScheduledTask();
			
				item.ScheduledTaskKey = varScheduledTaskKey;
			
				item.ScheduledTaskType = varScheduledTaskType;
			
				item.DateChanged = varDateChanged;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ScheduledTaskKeyColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ScheduledTaskTypeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DateChangedColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ScheduledTaskKey = @"scheduled_task_key";
			 public static string ScheduledTaskType = @"scheduled_task_type";
			 public static string DateChanged = @"date_changed";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}