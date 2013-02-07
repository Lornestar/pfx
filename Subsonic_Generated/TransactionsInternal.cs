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
	/// Strongly-typed collection for the TransactionsInternal class.
	/// </summary>
    [Serializable]
	public partial class TransactionsInternalCollection : ActiveList<TransactionsInternal, TransactionsInternalCollection>
	{	   
		public TransactionsInternalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TransactionsInternalCollection</returns>
		public TransactionsInternalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TransactionsInternal o = this[i];
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
	/// This is an ActiveRecord class which wraps the Transactions_Internal table.
	/// </summary>
	[Serializable]
	public partial class TransactionsInternal : ActiveRecord<TransactionsInternal>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TransactionsInternal()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TransactionsInternal(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TransactionsInternal(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TransactionsInternal(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Transactions_Internal", TableType.Table, DataService.GetInstance("Peerfx"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTxInternalKey = new TableSchema.TableColumn(schema);
				colvarTxInternalKey.ColumnName = "tx_internal_key";
				colvarTxInternalKey.DataType = DbType.Int64;
				colvarTxInternalKey.MaxLength = 0;
				colvarTxInternalKey.AutoIncrement = true;
				colvarTxInternalKey.IsNullable = false;
				colvarTxInternalKey.IsPrimaryKey = true;
				colvarTxInternalKey.IsForeignKey = false;
				colvarTxInternalKey.IsReadOnly = false;
				colvarTxInternalKey.DefaultSetting = @"";
				colvarTxInternalKey.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTxInternalKey);
				
				TableSchema.TableColumn colvarTxInternalStatus = new TableSchema.TableColumn(schema);
				colvarTxInternalStatus.ColumnName = "tx_internal_status";
				colvarTxInternalStatus.DataType = DbType.Int32;
				colvarTxInternalStatus.MaxLength = 0;
				colvarTxInternalStatus.AutoIncrement = false;
				colvarTxInternalStatus.IsNullable = false;
				colvarTxInternalStatus.IsPrimaryKey = false;
				colvarTxInternalStatus.IsForeignKey = false;
				colvarTxInternalStatus.IsReadOnly = false;
				colvarTxInternalStatus.DefaultSetting = @"";
				colvarTxInternalStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTxInternalStatus);
				
				TableSchema.TableColumn colvarPurposeType = new TableSchema.TableColumn(schema);
				colvarPurposeType.ColumnName = "purpose_type";
				colvarPurposeType.DataType = DbType.Int32;
				colvarPurposeType.MaxLength = 0;
				colvarPurposeType.AutoIncrement = false;
				colvarPurposeType.IsNullable = true;
				colvarPurposeType.IsPrimaryKey = false;
				colvarPurposeType.IsForeignKey = false;
				colvarPurposeType.IsReadOnly = false;
				colvarPurposeType.DefaultSetting = @"";
				colvarPurposeType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPurposeType);
				
				TableSchema.TableColumn colvarPurposeObjectKey = new TableSchema.TableColumn(schema);
				colvarPurposeObjectKey.ColumnName = "purpose_object_key";
				colvarPurposeObjectKey.DataType = DbType.Int32;
				colvarPurposeObjectKey.MaxLength = 0;
				colvarPurposeObjectKey.AutoIncrement = false;
				colvarPurposeObjectKey.IsNullable = true;
				colvarPurposeObjectKey.IsPrimaryKey = false;
				colvarPurposeObjectKey.IsForeignKey = false;
				colvarPurposeObjectKey.IsReadOnly = false;
				colvarPurposeObjectKey.DefaultSetting = @"";
				colvarPurposeObjectKey.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPurposeObjectKey);
				
				TableSchema.TableColumn colvarCurrency = new TableSchema.TableColumn(schema);
				colvarCurrency.ColumnName = "currency";
				colvarCurrency.DataType = DbType.Int32;
				colvarCurrency.MaxLength = 0;
				colvarCurrency.AutoIncrement = false;
				colvarCurrency.IsNullable = false;
				colvarCurrency.IsPrimaryKey = false;
				colvarCurrency.IsForeignKey = false;
				colvarCurrency.IsReadOnly = false;
				colvarCurrency.DefaultSetting = @"";
				colvarCurrency.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrency);
				
				TableSchema.TableColumn colvarAmount = new TableSchema.TableColumn(schema);
				colvarAmount.ColumnName = "amount";
				colvarAmount.DataType = DbType.Currency;
				colvarAmount.MaxLength = 0;
				colvarAmount.AutoIncrement = false;
				colvarAmount.IsNullable = false;
				colvarAmount.IsPrimaryKey = false;
				colvarAmount.IsForeignKey = false;
				colvarAmount.IsReadOnly = false;
				colvarAmount.DefaultSetting = @"";
				colvarAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmount);
				
				TableSchema.TableColumn colvarPaymentObjectSender = new TableSchema.TableColumn(schema);
				colvarPaymentObjectSender.ColumnName = "payment_object_sender";
				colvarPaymentObjectSender.DataType = DbType.Int64;
				colvarPaymentObjectSender.MaxLength = 0;
				colvarPaymentObjectSender.AutoIncrement = false;
				colvarPaymentObjectSender.IsNullable = true;
				colvarPaymentObjectSender.IsPrimaryKey = false;
				colvarPaymentObjectSender.IsForeignKey = false;
				colvarPaymentObjectSender.IsReadOnly = false;
				colvarPaymentObjectSender.DefaultSetting = @"";
				colvarPaymentObjectSender.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPaymentObjectSender);
				
				TableSchema.TableColumn colvarPaymentObjectReceiver = new TableSchema.TableColumn(schema);
				colvarPaymentObjectReceiver.ColumnName = "payment_object_receiver";
				colvarPaymentObjectReceiver.DataType = DbType.Int64;
				colvarPaymentObjectReceiver.MaxLength = 0;
				colvarPaymentObjectReceiver.AutoIncrement = false;
				colvarPaymentObjectReceiver.IsNullable = true;
				colvarPaymentObjectReceiver.IsPrimaryKey = false;
				colvarPaymentObjectReceiver.IsForeignKey = false;
				colvarPaymentObjectReceiver.IsReadOnly = false;
				colvarPaymentObjectReceiver.DefaultSetting = @"";
				colvarPaymentObjectReceiver.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPaymentObjectReceiver);
				
				TableSchema.TableColumn colvarTxInternalDescription = new TableSchema.TableColumn(schema);
				colvarTxInternalDescription.ColumnName = "tx_internal_description";
				colvarTxInternalDescription.DataType = DbType.String;
				colvarTxInternalDescription.MaxLength = 100;
				colvarTxInternalDescription.AutoIncrement = false;
				colvarTxInternalDescription.IsNullable = true;
				colvarTxInternalDescription.IsPrimaryKey = false;
				colvarTxInternalDescription.IsForeignKey = false;
				colvarTxInternalDescription.IsReadOnly = false;
				colvarTxInternalDescription.DefaultSetting = @"";
				colvarTxInternalDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTxInternalDescription);
				
				TableSchema.TableColumn colvarLastChanged = new TableSchema.TableColumn(schema);
				colvarLastChanged.ColumnName = "last_changed";
				colvarLastChanged.DataType = DbType.DateTime;
				colvarLastChanged.MaxLength = 0;
				colvarLastChanged.AutoIncrement = false;
				colvarLastChanged.IsNullable = false;
				colvarLastChanged.IsPrimaryKey = false;
				colvarLastChanged.IsForeignKey = false;
				colvarLastChanged.IsReadOnly = false;
				colvarLastChanged.DefaultSetting = @"";
				colvarLastChanged.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLastChanged);
				
				TableSchema.TableColumn colvarIpAddress = new TableSchema.TableColumn(schema);
				colvarIpAddress.ColumnName = "ip_address";
				colvarIpAddress.DataType = DbType.String;
				colvarIpAddress.MaxLength = 16;
				colvarIpAddress.AutoIncrement = false;
				colvarIpAddress.IsNullable = true;
				colvarIpAddress.IsPrimaryKey = false;
				colvarIpAddress.IsForeignKey = false;
				colvarIpAddress.IsReadOnly = false;
				colvarIpAddress.DefaultSetting = @"";
				colvarIpAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIpAddress);
				
				TableSchema.TableColumn colvarUserKeyUpdated = new TableSchema.TableColumn(schema);
				colvarUserKeyUpdated.ColumnName = "user_key_updated";
				colvarUserKeyUpdated.DataType = DbType.Int32;
				colvarUserKeyUpdated.MaxLength = 0;
				colvarUserKeyUpdated.AutoIncrement = false;
				colvarUserKeyUpdated.IsNullable = true;
				colvarUserKeyUpdated.IsPrimaryKey = false;
				colvarUserKeyUpdated.IsForeignKey = false;
				colvarUserKeyUpdated.IsReadOnly = false;
				colvarUserKeyUpdated.DefaultSetting = @"";
				colvarUserKeyUpdated.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserKeyUpdated);
				
				TableSchema.TableColumn colvarDateCreated = new TableSchema.TableColumn(schema);
				colvarDateCreated.ColumnName = "date_created";
				colvarDateCreated.DataType = DbType.DateTime;
				colvarDateCreated.MaxLength = 0;
				colvarDateCreated.AutoIncrement = false;
				colvarDateCreated.IsNullable = true;
				colvarDateCreated.IsPrimaryKey = false;
				colvarDateCreated.IsForeignKey = false;
				colvarDateCreated.IsReadOnly = false;
				colvarDateCreated.DefaultSetting = @"";
				colvarDateCreated.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateCreated);
				
				TableSchema.TableColumn colvarDateProcessed = new TableSchema.TableColumn(schema);
				colvarDateProcessed.ColumnName = "date_processed";
				colvarDateProcessed.DataType = DbType.DateTime;
				colvarDateProcessed.MaxLength = 0;
				colvarDateProcessed.AutoIncrement = false;
				colvarDateProcessed.IsNullable = true;
				colvarDateProcessed.IsPrimaryKey = false;
				colvarDateProcessed.IsForeignKey = false;
				colvarDateProcessed.IsReadOnly = false;
				colvarDateProcessed.DefaultSetting = @"";
				colvarDateProcessed.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateProcessed);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Peerfx"].AddSchema("Transactions_Internal",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TxInternalKey")]
		[Bindable(true)]
		public long TxInternalKey 
		{
			get { return GetColumnValue<long>(Columns.TxInternalKey); }
			set { SetColumnValue(Columns.TxInternalKey, value); }
		}
		  
		[XmlAttribute("TxInternalStatus")]
		[Bindable(true)]
		public int TxInternalStatus 
		{
			get { return GetColumnValue<int>(Columns.TxInternalStatus); }
			set { SetColumnValue(Columns.TxInternalStatus, value); }
		}
		  
		[XmlAttribute("PurposeType")]
		[Bindable(true)]
		public int? PurposeType 
		{
			get { return GetColumnValue<int?>(Columns.PurposeType); }
			set { SetColumnValue(Columns.PurposeType, value); }
		}
		  
		[XmlAttribute("PurposeObjectKey")]
		[Bindable(true)]
		public int? PurposeObjectKey 
		{
			get { return GetColumnValue<int?>(Columns.PurposeObjectKey); }
			set { SetColumnValue(Columns.PurposeObjectKey, value); }
		}
		  
		[XmlAttribute("Currency")]
		[Bindable(true)]
		public int Currency 
		{
			get { return GetColumnValue<int>(Columns.Currency); }
			set { SetColumnValue(Columns.Currency, value); }
		}
		  
		[XmlAttribute("Amount")]
		[Bindable(true)]
		public decimal Amount 
		{
			get { return GetColumnValue<decimal>(Columns.Amount); }
			set { SetColumnValue(Columns.Amount, value); }
		}
		  
		[XmlAttribute("PaymentObjectSender")]
		[Bindable(true)]
		public long? PaymentObjectSender 
		{
			get { return GetColumnValue<long?>(Columns.PaymentObjectSender); }
			set { SetColumnValue(Columns.PaymentObjectSender, value); }
		}
		  
		[XmlAttribute("PaymentObjectReceiver")]
		[Bindable(true)]
		public long? PaymentObjectReceiver 
		{
			get { return GetColumnValue<long?>(Columns.PaymentObjectReceiver); }
			set { SetColumnValue(Columns.PaymentObjectReceiver, value); }
		}
		  
		[XmlAttribute("TxInternalDescription")]
		[Bindable(true)]
		public string TxInternalDescription 
		{
			get { return GetColumnValue<string>(Columns.TxInternalDescription); }
			set { SetColumnValue(Columns.TxInternalDescription, value); }
		}
		  
		[XmlAttribute("LastChanged")]
		[Bindable(true)]
		public DateTime LastChanged 
		{
			get { return GetColumnValue<DateTime>(Columns.LastChanged); }
			set { SetColumnValue(Columns.LastChanged, value); }
		}
		  
		[XmlAttribute("IpAddress")]
		[Bindable(true)]
		public string IpAddress 
		{
			get { return GetColumnValue<string>(Columns.IpAddress); }
			set { SetColumnValue(Columns.IpAddress, value); }
		}
		  
		[XmlAttribute("UserKeyUpdated")]
		[Bindable(true)]
		public int? UserKeyUpdated 
		{
			get { return GetColumnValue<int?>(Columns.UserKeyUpdated); }
			set { SetColumnValue(Columns.UserKeyUpdated, value); }
		}
		  
		[XmlAttribute("DateCreated")]
		[Bindable(true)]
		public DateTime? DateCreated 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateCreated); }
			set { SetColumnValue(Columns.DateCreated, value); }
		}
		  
		[XmlAttribute("DateProcessed")]
		[Bindable(true)]
		public DateTime? DateProcessed 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateProcessed); }
			set { SetColumnValue(Columns.DateProcessed, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varTxInternalStatus,int? varPurposeType,int? varPurposeObjectKey,int varCurrency,decimal varAmount,long? varPaymentObjectSender,long? varPaymentObjectReceiver,string varTxInternalDescription,DateTime varLastChanged,string varIpAddress,int? varUserKeyUpdated,DateTime? varDateCreated,DateTime? varDateProcessed)
		{
			TransactionsInternal item = new TransactionsInternal();
			
			item.TxInternalStatus = varTxInternalStatus;
			
			item.PurposeType = varPurposeType;
			
			item.PurposeObjectKey = varPurposeObjectKey;
			
			item.Currency = varCurrency;
			
			item.Amount = varAmount;
			
			item.PaymentObjectSender = varPaymentObjectSender;
			
			item.PaymentObjectReceiver = varPaymentObjectReceiver;
			
			item.TxInternalDescription = varTxInternalDescription;
			
			item.LastChanged = varLastChanged;
			
			item.IpAddress = varIpAddress;
			
			item.UserKeyUpdated = varUserKeyUpdated;
			
			item.DateCreated = varDateCreated;
			
			item.DateProcessed = varDateProcessed;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(long varTxInternalKey,int varTxInternalStatus,int? varPurposeType,int? varPurposeObjectKey,int varCurrency,decimal varAmount,long? varPaymentObjectSender,long? varPaymentObjectReceiver,string varTxInternalDescription,DateTime varLastChanged,string varIpAddress,int? varUserKeyUpdated,DateTime? varDateCreated,DateTime? varDateProcessed)
		{
			TransactionsInternal item = new TransactionsInternal();
			
				item.TxInternalKey = varTxInternalKey;
			
				item.TxInternalStatus = varTxInternalStatus;
			
				item.PurposeType = varPurposeType;
			
				item.PurposeObjectKey = varPurposeObjectKey;
			
				item.Currency = varCurrency;
			
				item.Amount = varAmount;
			
				item.PaymentObjectSender = varPaymentObjectSender;
			
				item.PaymentObjectReceiver = varPaymentObjectReceiver;
			
				item.TxInternalDescription = varTxInternalDescription;
			
				item.LastChanged = varLastChanged;
			
				item.IpAddress = varIpAddress;
			
				item.UserKeyUpdated = varUserKeyUpdated;
			
				item.DateCreated = varDateCreated;
			
				item.DateProcessed = varDateProcessed;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TxInternalKeyColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TxInternalStatusColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PurposeTypeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PurposeObjectKeyColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CurrencyColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AmountColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PaymentObjectSenderColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn PaymentObjectReceiverColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TxInternalDescriptionColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn LastChangedColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IpAddressColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn UserKeyUpdatedColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DateCreatedColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn DateProcessedColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TxInternalKey = @"tx_internal_key";
			 public static string TxInternalStatus = @"tx_internal_status";
			 public static string PurposeType = @"purpose_type";
			 public static string PurposeObjectKey = @"purpose_object_key";
			 public static string Currency = @"currency";
			 public static string Amount = @"amount";
			 public static string PaymentObjectSender = @"payment_object_sender";
			 public static string PaymentObjectReceiver = @"payment_object_receiver";
			 public static string TxInternalDescription = @"tx_internal_description";
			 public static string LastChanged = @"last_changed";
			 public static string IpAddress = @"ip_address";
			 public static string UserKeyUpdated = @"user_key_updated";
			 public static string DateCreated = @"date_created";
			 public static string DateProcessed = @"date_processed";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}