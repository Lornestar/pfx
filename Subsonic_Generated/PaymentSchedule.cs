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
	/// Strongly-typed collection for the PaymentSchedule class.
	/// </summary>
    [Serializable]
	public partial class PaymentScheduleCollection : ActiveList<PaymentSchedule, PaymentScheduleCollection>
	{	   
		public PaymentScheduleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PaymentScheduleCollection</returns>
		public PaymentScheduleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PaymentSchedule o = this[i];
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
	/// This is an ActiveRecord class which wraps the Payment_Schedule table.
	/// </summary>
	[Serializable]
	public partial class PaymentSchedule : ActiveRecord<PaymentSchedule>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PaymentSchedule()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PaymentSchedule(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PaymentSchedule(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PaymentSchedule(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Payment_Schedule", TableType.Table, DataService.GetInstance("Peerfx"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarPaymentScheduleKey = new TableSchema.TableColumn(schema);
				colvarPaymentScheduleKey.ColumnName = "payment_schedule_key";
				colvarPaymentScheduleKey.DataType = DbType.Int32;
				colvarPaymentScheduleKey.MaxLength = 0;
				colvarPaymentScheduleKey.AutoIncrement = true;
				colvarPaymentScheduleKey.IsNullable = false;
				colvarPaymentScheduleKey.IsPrimaryKey = true;
				colvarPaymentScheduleKey.IsForeignKey = false;
				colvarPaymentScheduleKey.IsReadOnly = false;
				colvarPaymentScheduleKey.DefaultSetting = @"";
				colvarPaymentScheduleKey.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPaymentScheduleKey);
				
				TableSchema.TableColumn colvarCurrencySender = new TableSchema.TableColumn(schema);
				colvarCurrencySender.ColumnName = "currency_sender";
				colvarCurrencySender.DataType = DbType.Int32;
				colvarCurrencySender.MaxLength = 0;
				colvarCurrencySender.AutoIncrement = false;
				colvarCurrencySender.IsNullable = false;
				colvarCurrencySender.IsPrimaryKey = false;
				colvarCurrencySender.IsForeignKey = false;
				colvarCurrencySender.IsReadOnly = false;
				colvarCurrencySender.DefaultSetting = @"";
				colvarCurrencySender.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrencySender);
				
				TableSchema.TableColumn colvarCurrencyReceiver = new TableSchema.TableColumn(schema);
				colvarCurrencyReceiver.ColumnName = "currency_receiver";
				colvarCurrencyReceiver.DataType = DbType.Int32;
				colvarCurrencyReceiver.MaxLength = 0;
				colvarCurrencyReceiver.AutoIncrement = false;
				colvarCurrencyReceiver.IsNullable = false;
				colvarCurrencyReceiver.IsPrimaryKey = false;
				colvarCurrencyReceiver.IsForeignKey = false;
				colvarCurrencyReceiver.IsReadOnly = false;
				colvarCurrencyReceiver.DefaultSetting = @"";
				colvarCurrencyReceiver.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrencyReceiver);
				
				TableSchema.TableColumn colvarTimeToDelivery = new TableSchema.TableColumn(schema);
				colvarTimeToDelivery.ColumnName = "time_to_delivery";
				colvarTimeToDelivery.DataType = DbType.DateTime;
				colvarTimeToDelivery.MaxLength = 0;
				colvarTimeToDelivery.AutoIncrement = false;
				colvarTimeToDelivery.IsNullable = false;
				colvarTimeToDelivery.IsPrimaryKey = false;
				colvarTimeToDelivery.IsForeignKey = false;
				colvarTimeToDelivery.IsReadOnly = false;
				colvarTimeToDelivery.DefaultSetting = @"";
				colvarTimeToDelivery.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTimeToDelivery);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Peerfx"].AddSchema("Payment_Schedule",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("PaymentScheduleKey")]
		[Bindable(true)]
		public int PaymentScheduleKey 
		{
			get { return GetColumnValue<int>(Columns.PaymentScheduleKey); }
			set { SetColumnValue(Columns.PaymentScheduleKey, value); }
		}
		  
		[XmlAttribute("CurrencySender")]
		[Bindable(true)]
		public int CurrencySender 
		{
			get { return GetColumnValue<int>(Columns.CurrencySender); }
			set { SetColumnValue(Columns.CurrencySender, value); }
		}
		  
		[XmlAttribute("CurrencyReceiver")]
		[Bindable(true)]
		public int CurrencyReceiver 
		{
			get { return GetColumnValue<int>(Columns.CurrencyReceiver); }
			set { SetColumnValue(Columns.CurrencyReceiver, value); }
		}
		  
		[XmlAttribute("TimeToDelivery")]
		[Bindable(true)]
		public DateTime TimeToDelivery 
		{
			get { return GetColumnValue<DateTime>(Columns.TimeToDelivery); }
			set { SetColumnValue(Columns.TimeToDelivery, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varCurrencySender,int varCurrencyReceiver,DateTime varTimeToDelivery)
		{
			PaymentSchedule item = new PaymentSchedule();
			
			item.CurrencySender = varCurrencySender;
			
			item.CurrencyReceiver = varCurrencyReceiver;
			
			item.TimeToDelivery = varTimeToDelivery;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varPaymentScheduleKey,int varCurrencySender,int varCurrencyReceiver,DateTime varTimeToDelivery)
		{
			PaymentSchedule item = new PaymentSchedule();
			
				item.PaymentScheduleKey = varPaymentScheduleKey;
			
				item.CurrencySender = varCurrencySender;
			
				item.CurrencyReceiver = varCurrencyReceiver;
			
				item.TimeToDelivery = varTimeToDelivery;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn PaymentScheduleKeyColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CurrencySenderColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CurrencyReceiverColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TimeToDeliveryColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string PaymentScheduleKey = @"payment_schedule_key";
			 public static string CurrencySender = @"currency_sender";
			 public static string CurrencyReceiver = @"currency_receiver";
			 public static string TimeToDelivery = @"time_to_delivery";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
