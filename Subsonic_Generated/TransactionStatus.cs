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
	/// Strongly-typed collection for the TransactionStatus class.
	/// </summary>
    [Serializable]
	public partial class TransactionStatusCollection : ActiveList<TransactionStatus, TransactionStatusCollection>
	{	   
		public TransactionStatusCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TransactionStatusCollection</returns>
		public TransactionStatusCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TransactionStatus o = this[i];
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
	/// This is an ActiveRecord class which wraps the Transaction_Status table.
	/// </summary>
	[Serializable]
	public partial class TransactionStatus : ActiveRecord<TransactionStatus>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TransactionStatus()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TransactionStatus(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TransactionStatus(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TransactionStatus(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Transaction_Status", TableType.Table, DataService.GetInstance("Peerfx"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTransactionStatusKey = new TableSchema.TableColumn(schema);
				colvarTransactionStatusKey.ColumnName = "transaction_status_key";
				colvarTransactionStatusKey.DataType = DbType.Int32;
				colvarTransactionStatusKey.MaxLength = 0;
				colvarTransactionStatusKey.AutoIncrement = false;
				colvarTransactionStatusKey.IsNullable = false;
				colvarTransactionStatusKey.IsPrimaryKey = true;
				colvarTransactionStatusKey.IsForeignKey = false;
				colvarTransactionStatusKey.IsReadOnly = false;
				colvarTransactionStatusKey.DefaultSetting = @"";
				colvarTransactionStatusKey.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransactionStatusKey);
				
				TableSchema.TableColumn colvarStatusDescription = new TableSchema.TableColumn(schema);
				colvarStatusDescription.ColumnName = "status_description";
				colvarStatusDescription.DataType = DbType.String;
				colvarStatusDescription.MaxLength = 20;
				colvarStatusDescription.AutoIncrement = false;
				colvarStatusDescription.IsNullable = false;
				colvarStatusDescription.IsPrimaryKey = false;
				colvarStatusDescription.IsForeignKey = false;
				colvarStatusDescription.IsReadOnly = false;
				colvarStatusDescription.DefaultSetting = @"";
				colvarStatusDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatusDescription);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Peerfx"].AddSchema("Transaction_Status",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TransactionStatusKey")]
		[Bindable(true)]
		public int TransactionStatusKey 
		{
			get { return GetColumnValue<int>(Columns.TransactionStatusKey); }
			set { SetColumnValue(Columns.TransactionStatusKey, value); }
		}
		  
		[XmlAttribute("StatusDescription")]
		[Bindable(true)]
		public string StatusDescription 
		{
			get { return GetColumnValue<string>(Columns.StatusDescription); }
			set { SetColumnValue(Columns.StatusDescription, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varTransactionStatusKey,string varStatusDescription)
		{
			TransactionStatus item = new TransactionStatus();
			
			item.TransactionStatusKey = varTransactionStatusKey;
			
			item.StatusDescription = varStatusDescription;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTransactionStatusKey,string varStatusDescription)
		{
			TransactionStatus item = new TransactionStatus();
			
				item.TransactionStatusKey = varTransactionStatusKey;
			
				item.StatusDescription = varStatusDescription;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TransactionStatusKeyColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusDescriptionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TransactionStatusKey = @"transaction_status_key";
			 public static string StatusDescription = @"status_description";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}