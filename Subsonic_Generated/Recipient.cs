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
	/// Strongly-typed collection for the Recipient class.
	/// </summary>
    [Serializable]
	public partial class RecipientCollection : ActiveList<Recipient, RecipientCollection>
	{	   
		public RecipientCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RecipientCollection</returns>
		public RecipientCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Recipient o = this[i];
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
	/// This is an ActiveRecord class which wraps the Recipients table.
	/// </summary>
	[Serializable]
	public partial class Recipient : ActiveRecord<Recipient>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Recipient()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Recipient(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Recipient(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Recipient(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Recipients", TableType.Table, DataService.GetInstance("Peerfx"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarRecipientsKey = new TableSchema.TableColumn(schema);
				colvarRecipientsKey.ColumnName = "recipients_key";
				colvarRecipientsKey.DataType = DbType.Int32;
				colvarRecipientsKey.MaxLength = 0;
				colvarRecipientsKey.AutoIncrement = true;
				colvarRecipientsKey.IsNullable = false;
				colvarRecipientsKey.IsPrimaryKey = true;
				colvarRecipientsKey.IsForeignKey = false;
				colvarRecipientsKey.IsReadOnly = false;
				colvarRecipientsKey.DefaultSetting = @"";
				colvarRecipientsKey.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRecipientsKey);
				
				TableSchema.TableColumn colvarUserKey = new TableSchema.TableColumn(schema);
				colvarUserKey.ColumnName = "user_key";
				colvarUserKey.DataType = DbType.Int32;
				colvarUserKey.MaxLength = 0;
				colvarUserKey.AutoIncrement = false;
				colvarUserKey.IsNullable = false;
				colvarUserKey.IsPrimaryKey = false;
				colvarUserKey.IsForeignKey = false;
				colvarUserKey.IsReadOnly = false;
				colvarUserKey.DefaultSetting = @"";
				colvarUserKey.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserKey);
				
				TableSchema.TableColumn colvarPaymentObjectKey = new TableSchema.TableColumn(schema);
				colvarPaymentObjectKey.ColumnName = "payment_object_key";
				colvarPaymentObjectKey.DataType = DbType.Int64;
				colvarPaymentObjectKey.MaxLength = 0;
				colvarPaymentObjectKey.AutoIncrement = false;
				colvarPaymentObjectKey.IsNullable = false;
				colvarPaymentObjectKey.IsPrimaryKey = false;
				colvarPaymentObjectKey.IsForeignKey = false;
				colvarPaymentObjectKey.IsReadOnly = false;
				colvarPaymentObjectKey.DefaultSetting = @"";
				colvarPaymentObjectKey.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPaymentObjectKey);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Peerfx"].AddSchema("Recipients",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("RecipientsKey")]
		[Bindable(true)]
		public int RecipientsKey 
		{
			get { return GetColumnValue<int>(Columns.RecipientsKey); }
			set { SetColumnValue(Columns.RecipientsKey, value); }
		}
		  
		[XmlAttribute("UserKey")]
		[Bindable(true)]
		public int UserKey 
		{
			get { return GetColumnValue<int>(Columns.UserKey); }
			set { SetColumnValue(Columns.UserKey, value); }
		}
		  
		[XmlAttribute("PaymentObjectKey")]
		[Bindable(true)]
		public long PaymentObjectKey 
		{
			get { return GetColumnValue<long>(Columns.PaymentObjectKey); }
			set { SetColumnValue(Columns.PaymentObjectKey, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varUserKey,long varPaymentObjectKey)
		{
			Recipient item = new Recipient();
			
			item.UserKey = varUserKey;
			
			item.PaymentObjectKey = varPaymentObjectKey;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varRecipientsKey,int varUserKey,long varPaymentObjectKey)
		{
			Recipient item = new Recipient();
			
				item.RecipientsKey = varRecipientsKey;
			
				item.UserKey = varUserKey;
			
				item.PaymentObjectKey = varPaymentObjectKey;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn RecipientsKeyColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn UserKeyColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PaymentObjectKeyColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string RecipientsKey = @"recipients_key";
			 public static string UserKey = @"user_key";
			 public static string PaymentObjectKey = @"payment_object_key";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}