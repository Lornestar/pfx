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
namespace Peerfx_DB{
    /// <summary>
    /// Strongly-typed collection for the VwPayment class.
    /// </summary>
    [Serializable]
    public partial class VwPaymentCollection : ReadOnlyList<VwPayment, VwPaymentCollection>
    {        
        public VwPaymentCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vw_Payments view.
    /// </summary>
    [Serializable]
    public partial class VwPayment : ReadOnlyRecord<VwPayment>, IReadOnlyRecord
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }
	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }
                return BaseSchema;
            }
        }
    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("vw_Payments", TableType.View, DataService.GetInstance("Peerfx"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarPaymentsKey = new TableSchema.TableColumn(schema);
                colvarPaymentsKey.ColumnName = "payments_key";
                colvarPaymentsKey.DataType = DbType.Int32;
                colvarPaymentsKey.MaxLength = 0;
                colvarPaymentsKey.AutoIncrement = false;
                colvarPaymentsKey.IsNullable = false;
                colvarPaymentsKey.IsPrimaryKey = false;
                colvarPaymentsKey.IsForeignKey = false;
                colvarPaymentsKey.IsReadOnly = false;
                
                schema.Columns.Add(colvarPaymentsKey);
                
                TableSchema.TableColumn colvarQuoteKey = new TableSchema.TableColumn(schema);
                colvarQuoteKey.ColumnName = "quote_key";
                colvarQuoteKey.DataType = DbType.Int32;
                colvarQuoteKey.MaxLength = 0;
                colvarQuoteKey.AutoIncrement = false;
                colvarQuoteKey.IsNullable = false;
                colvarQuoteKey.IsPrimaryKey = false;
                colvarQuoteKey.IsForeignKey = false;
                colvarQuoteKey.IsReadOnly = false;
                
                schema.Columns.Add(colvarQuoteKey);
                
                TableSchema.TableColumn colvarPaymentStatus = new TableSchema.TableColumn(schema);
                colvarPaymentStatus.ColumnName = "payment_status";
                colvarPaymentStatus.DataType = DbType.Int32;
                colvarPaymentStatus.MaxLength = 0;
                colvarPaymentStatus.AutoIncrement = false;
                colvarPaymentStatus.IsNullable = false;
                colvarPaymentStatus.IsPrimaryKey = false;
                colvarPaymentStatus.IsForeignKey = false;
                colvarPaymentStatus.IsReadOnly = false;
                
                schema.Columns.Add(colvarPaymentStatus);
                
                TableSchema.TableColumn colvarDateCreated = new TableSchema.TableColumn(schema);
                colvarDateCreated.ColumnName = "date_created";
                colvarDateCreated.DataType = DbType.DateTime;
                colvarDateCreated.MaxLength = 0;
                colvarDateCreated.AutoIncrement = false;
                colvarDateCreated.IsNullable = false;
                colvarDateCreated.IsPrimaryKey = false;
                colvarDateCreated.IsForeignKey = false;
                colvarDateCreated.IsReadOnly = false;
                
                schema.Columns.Add(colvarDateCreated);
                
                TableSchema.TableColumn colvarRequestorUserKey = new TableSchema.TableColumn(schema);
                colvarRequestorUserKey.ColumnName = "requestor_user_key";
                colvarRequestorUserKey.DataType = DbType.Int32;
                colvarRequestorUserKey.MaxLength = 0;
                colvarRequestorUserKey.AutoIncrement = false;
                colvarRequestorUserKey.IsNullable = true;
                colvarRequestorUserKey.IsPrimaryKey = false;
                colvarRequestorUserKey.IsForeignKey = false;
                colvarRequestorUserKey.IsReadOnly = false;
                
                schema.Columns.Add(colvarRequestorUserKey);
                
                TableSchema.TableColumn colvarPaymentObjectSender = new TableSchema.TableColumn(schema);
                colvarPaymentObjectSender.ColumnName = "payment_object_sender";
                colvarPaymentObjectSender.DataType = DbType.Int64;
                colvarPaymentObjectSender.MaxLength = 0;
                colvarPaymentObjectSender.AutoIncrement = false;
                colvarPaymentObjectSender.IsNullable = true;
                colvarPaymentObjectSender.IsPrimaryKey = false;
                colvarPaymentObjectSender.IsForeignKey = false;
                colvarPaymentObjectSender.IsReadOnly = false;
                
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
                
                schema.Columns.Add(colvarPaymentObjectReceiver);
                
                TableSchema.TableColumn colvarPaymentDescription = new TableSchema.TableColumn(schema);
                colvarPaymentDescription.ColumnName = "payment_description";
                colvarPaymentDescription.DataType = DbType.String;
                colvarPaymentDescription.MaxLength = 100;
                colvarPaymentDescription.AutoIncrement = false;
                colvarPaymentDescription.IsNullable = true;
                colvarPaymentDescription.IsPrimaryKey = false;
                colvarPaymentDescription.IsForeignKey = false;
                colvarPaymentDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarPaymentDescription);
                
                TableSchema.TableColumn colvarSellAmount = new TableSchema.TableColumn(schema);
                colvarSellAmount.ColumnName = "sell_amount";
                colvarSellAmount.DataType = DbType.Currency;
                colvarSellAmount.MaxLength = 0;
                colvarSellAmount.AutoIncrement = false;
                colvarSellAmount.IsNullable = true;
                colvarSellAmount.IsPrimaryKey = false;
                colvarSellAmount.IsForeignKey = false;
                colvarSellAmount.IsReadOnly = false;
                
                schema.Columns.Add(colvarSellAmount);
                
                TableSchema.TableColumn colvarSellCurrency = new TableSchema.TableColumn(schema);
                colvarSellCurrency.ColumnName = "sell_currency";
                colvarSellCurrency.DataType = DbType.Int32;
                colvarSellCurrency.MaxLength = 0;
                colvarSellCurrency.AutoIncrement = false;
                colvarSellCurrency.IsNullable = true;
                colvarSellCurrency.IsPrimaryKey = false;
                colvarSellCurrency.IsForeignKey = false;
                colvarSellCurrency.IsReadOnly = false;
                
                schema.Columns.Add(colvarSellCurrency);
                
                TableSchema.TableColumn colvarBuyAmount = new TableSchema.TableColumn(schema);
                colvarBuyAmount.ColumnName = "buy_amount";
                colvarBuyAmount.DataType = DbType.Currency;
                colvarBuyAmount.MaxLength = 0;
                colvarBuyAmount.AutoIncrement = false;
                colvarBuyAmount.IsNullable = true;
                colvarBuyAmount.IsPrimaryKey = false;
                colvarBuyAmount.IsForeignKey = false;
                colvarBuyAmount.IsReadOnly = false;
                
                schema.Columns.Add(colvarBuyAmount);
                
                TableSchema.TableColumn colvarBuyCurrency = new TableSchema.TableColumn(schema);
                colvarBuyCurrency.ColumnName = "buy_currency";
                colvarBuyCurrency.DataType = DbType.Int32;
                colvarBuyCurrency.MaxLength = 0;
                colvarBuyCurrency.AutoIncrement = false;
                colvarBuyCurrency.IsNullable = true;
                colvarBuyCurrency.IsPrimaryKey = false;
                colvarBuyCurrency.IsForeignKey = false;
                colvarBuyCurrency.IsReadOnly = false;
                
                schema.Columns.Add(colvarBuyCurrency);
                
                TableSchema.TableColumn colvarRate = new TableSchema.TableColumn(schema);
                colvarRate.ColumnName = "rate";
                colvarRate.DataType = DbType.Decimal;
                colvarRate.MaxLength = 0;
                colvarRate.AutoIncrement = false;
                colvarRate.IsNullable = true;
                colvarRate.IsPrimaryKey = false;
                colvarRate.IsForeignKey = false;
                colvarRate.IsReadOnly = false;
                
                schema.Columns.Add(colvarRate);
                
                TableSchema.TableColumn colvarServiceFee = new TableSchema.TableColumn(schema);
                colvarServiceFee.ColumnName = "service_fee";
                colvarServiceFee.DataType = DbType.Currency;
                colvarServiceFee.MaxLength = 0;
                colvarServiceFee.AutoIncrement = false;
                colvarServiceFee.IsNullable = true;
                colvarServiceFee.IsPrimaryKey = false;
                colvarServiceFee.IsForeignKey = false;
                colvarServiceFee.IsReadOnly = false;
                
                schema.Columns.Add(colvarServiceFee);
                
                TableSchema.TableColumn colvarPromisedDeliveryDate = new TableSchema.TableColumn(schema);
                colvarPromisedDeliveryDate.ColumnName = "promised_delivery_date";
                colvarPromisedDeliveryDate.DataType = DbType.DateTime;
                colvarPromisedDeliveryDate.MaxLength = 0;
                colvarPromisedDeliveryDate.AutoIncrement = false;
                colvarPromisedDeliveryDate.IsNullable = true;
                colvarPromisedDeliveryDate.IsPrimaryKey = false;
                colvarPromisedDeliveryDate.IsForeignKey = false;
                colvarPromisedDeliveryDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarPromisedDeliveryDate);
                
                TableSchema.TableColumn colvarActualDeliveryDate = new TableSchema.TableColumn(schema);
                colvarActualDeliveryDate.ColumnName = "actual_delivery_date";
                colvarActualDeliveryDate.DataType = DbType.DateTime;
                colvarActualDeliveryDate.MaxLength = 0;
                colvarActualDeliveryDate.AutoIncrement = false;
                colvarActualDeliveryDate.IsNullable = true;
                colvarActualDeliveryDate.IsPrimaryKey = false;
                colvarActualDeliveryDate.IsForeignKey = false;
                colvarActualDeliveryDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarActualDeliveryDate);
                
                TableSchema.TableColumn colvarReceiverName = new TableSchema.TableColumn(schema);
                colvarReceiverName.ColumnName = "receiver_name";
                colvarReceiverName.DataType = DbType.String;
                colvarReceiverName.MaxLength = 201;
                colvarReceiverName.AutoIncrement = false;
                colvarReceiverName.IsNullable = true;
                colvarReceiverName.IsPrimaryKey = false;
                colvarReceiverName.IsForeignKey = false;
                colvarReceiverName.IsReadOnly = false;
                
                schema.Columns.Add(colvarReceiverName);
                
                TableSchema.TableColumn colvarSenderName = new TableSchema.TableColumn(schema);
                colvarSenderName.ColumnName = "sender_name";
                colvarSenderName.DataType = DbType.String;
                colvarSenderName.MaxLength = 201;
                colvarSenderName.AutoIncrement = false;
                colvarSenderName.IsNullable = true;
                colvarSenderName.IsPrimaryKey = false;
                colvarSenderName.IsForeignKey = false;
                colvarSenderName.IsReadOnly = false;
                
                schema.Columns.Add(colvarSenderName);
                
                TableSchema.TableColumn colvarSellCurrencyText = new TableSchema.TableColumn(schema);
                colvarSellCurrencyText.ColumnName = "sell_currency_text";
                colvarSellCurrencyText.DataType = DbType.String;
                colvarSellCurrencyText.MaxLength = 3;
                colvarSellCurrencyText.AutoIncrement = false;
                colvarSellCurrencyText.IsNullable = true;
                colvarSellCurrencyText.IsPrimaryKey = false;
                colvarSellCurrencyText.IsForeignKey = false;
                colvarSellCurrencyText.IsReadOnly = false;
                
                schema.Columns.Add(colvarSellCurrencyText);
                
                TableSchema.TableColumn colvarBuyCurrencyText = new TableSchema.TableColumn(schema);
                colvarBuyCurrencyText.ColumnName = "buy_currency_text";
                colvarBuyCurrencyText.DataType = DbType.String;
                colvarBuyCurrencyText.MaxLength = 3;
                colvarBuyCurrencyText.AutoIncrement = false;
                colvarBuyCurrencyText.IsNullable = true;
                colvarBuyCurrencyText.IsPrimaryKey = false;
                colvarBuyCurrencyText.IsForeignKey = false;
                colvarBuyCurrencyText.IsReadOnly = false;
                
                schema.Columns.Add(colvarBuyCurrencyText);
                
                TableSchema.TableColumn colvarPaymentStatusText = new TableSchema.TableColumn(schema);
                colvarPaymentStatusText.ColumnName = "payment_status_text";
                colvarPaymentStatusText.DataType = DbType.String;
                colvarPaymentStatusText.MaxLength = 50;
                colvarPaymentStatusText.AutoIncrement = false;
                colvarPaymentStatusText.IsNullable = true;
                colvarPaymentStatusText.IsPrimaryKey = false;
                colvarPaymentStatusText.IsForeignKey = false;
                colvarPaymentStatusText.IsReadOnly = false;
                
                schema.Columns.Add(colvarPaymentStatusText);
                
                TableSchema.TableColumn colvarInternalOnly = new TableSchema.TableColumn(schema);
                colvarInternalOnly.ColumnName = "internal_only";
                colvarInternalOnly.DataType = DbType.Int32;
                colvarInternalOnly.MaxLength = 0;
                colvarInternalOnly.AutoIncrement = false;
                colvarInternalOnly.IsNullable = false;
                colvarInternalOnly.IsPrimaryKey = false;
                colvarInternalOnly.IsForeignKey = false;
                colvarInternalOnly.IsReadOnly = false;
                
                schema.Columns.Add(colvarInternalOnly);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Peerfx"].AddSchema("vw_Payments",schema);
            }
        }
        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }
	    #endregion
	    
	    #region .ctors
	    public VwPayment()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VwPayment(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VwPayment(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VwPayment(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("PaymentsKey")]
        [Bindable(true)]
        public int PaymentsKey 
	    {
		    get
		    {
			    return GetColumnValue<int>("payments_key");
		    }
            set 
		    {
			    SetColumnValue("payments_key", value);
            }
        }
	      
        [XmlAttribute("QuoteKey")]
        [Bindable(true)]
        public int QuoteKey 
	    {
		    get
		    {
			    return GetColumnValue<int>("quote_key");
		    }
            set 
		    {
			    SetColumnValue("quote_key", value);
            }
        }
	      
        [XmlAttribute("PaymentStatus")]
        [Bindable(true)]
        public int PaymentStatus 
	    {
		    get
		    {
			    return GetColumnValue<int>("payment_status");
		    }
            set 
		    {
			    SetColumnValue("payment_status", value);
            }
        }
	      
        [XmlAttribute("DateCreated")]
        [Bindable(true)]
        public DateTime DateCreated 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("date_created");
		    }
            set 
		    {
			    SetColumnValue("date_created", value);
            }
        }
	      
        [XmlAttribute("RequestorUserKey")]
        [Bindable(true)]
        public int? RequestorUserKey 
	    {
		    get
		    {
			    return GetColumnValue<int?>("requestor_user_key");
		    }
            set 
		    {
			    SetColumnValue("requestor_user_key", value);
            }
        }
	      
        [XmlAttribute("PaymentObjectSender")]
        [Bindable(true)]
        public long? PaymentObjectSender 
	    {
		    get
		    {
			    return GetColumnValue<long?>("payment_object_sender");
		    }
            set 
		    {
			    SetColumnValue("payment_object_sender", value);
            }
        }
	      
        [XmlAttribute("PaymentObjectReceiver")]
        [Bindable(true)]
        public long? PaymentObjectReceiver 
	    {
		    get
		    {
			    return GetColumnValue<long?>("payment_object_receiver");
		    }
            set 
		    {
			    SetColumnValue("payment_object_receiver", value);
            }
        }
	      
        [XmlAttribute("PaymentDescription")]
        [Bindable(true)]
        public string PaymentDescription 
	    {
		    get
		    {
			    return GetColumnValue<string>("payment_description");
		    }
            set 
		    {
			    SetColumnValue("payment_description", value);
            }
        }
	      
        [XmlAttribute("SellAmount")]
        [Bindable(true)]
        public decimal? SellAmount 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("sell_amount");
		    }
            set 
		    {
			    SetColumnValue("sell_amount", value);
            }
        }
	      
        [XmlAttribute("SellCurrency")]
        [Bindable(true)]
        public int? SellCurrency 
	    {
		    get
		    {
			    return GetColumnValue<int?>("sell_currency");
		    }
            set 
		    {
			    SetColumnValue("sell_currency", value);
            }
        }
	      
        [XmlAttribute("BuyAmount")]
        [Bindable(true)]
        public decimal? BuyAmount 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("buy_amount");
		    }
            set 
		    {
			    SetColumnValue("buy_amount", value);
            }
        }
	      
        [XmlAttribute("BuyCurrency")]
        [Bindable(true)]
        public int? BuyCurrency 
	    {
		    get
		    {
			    return GetColumnValue<int?>("buy_currency");
		    }
            set 
		    {
			    SetColumnValue("buy_currency", value);
            }
        }
	      
        [XmlAttribute("Rate")]
        [Bindable(true)]
        public decimal? Rate 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("rate");
		    }
            set 
		    {
			    SetColumnValue("rate", value);
            }
        }
	      
        [XmlAttribute("ServiceFee")]
        [Bindable(true)]
        public decimal? ServiceFee 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("service_fee");
		    }
            set 
		    {
			    SetColumnValue("service_fee", value);
            }
        }
	      
        [XmlAttribute("PromisedDeliveryDate")]
        [Bindable(true)]
        public DateTime? PromisedDeliveryDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("promised_delivery_date");
		    }
            set 
		    {
			    SetColumnValue("promised_delivery_date", value);
            }
        }
	      
        [XmlAttribute("ActualDeliveryDate")]
        [Bindable(true)]
        public DateTime? ActualDeliveryDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("actual_delivery_date");
		    }
            set 
		    {
			    SetColumnValue("actual_delivery_date", value);
            }
        }
	      
        [XmlAttribute("ReceiverName")]
        [Bindable(true)]
        public string ReceiverName 
	    {
		    get
		    {
			    return GetColumnValue<string>("receiver_name");
		    }
            set 
		    {
			    SetColumnValue("receiver_name", value);
            }
        }
	      
        [XmlAttribute("SenderName")]
        [Bindable(true)]
        public string SenderName 
	    {
		    get
		    {
			    return GetColumnValue<string>("sender_name");
		    }
            set 
		    {
			    SetColumnValue("sender_name", value);
            }
        }
	      
        [XmlAttribute("SellCurrencyText")]
        [Bindable(true)]
        public string SellCurrencyText 
	    {
		    get
		    {
			    return GetColumnValue<string>("sell_currency_text");
		    }
            set 
		    {
			    SetColumnValue("sell_currency_text", value);
            }
        }
	      
        [XmlAttribute("BuyCurrencyText")]
        [Bindable(true)]
        public string BuyCurrencyText 
	    {
		    get
		    {
			    return GetColumnValue<string>("buy_currency_text");
		    }
            set 
		    {
			    SetColumnValue("buy_currency_text", value);
            }
        }
	      
        [XmlAttribute("PaymentStatusText")]
        [Bindable(true)]
        public string PaymentStatusText 
	    {
		    get
		    {
			    return GetColumnValue<string>("payment_status_text");
		    }
            set 
		    {
			    SetColumnValue("payment_status_text", value);
            }
        }
	      
        [XmlAttribute("InternalOnly")]
        [Bindable(true)]
        public int InternalOnly 
	    {
		    get
		    {
			    return GetColumnValue<int>("internal_only");
		    }
            set 
		    {
			    SetColumnValue("internal_only", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string PaymentsKey = @"payments_key";
            
            public static string QuoteKey = @"quote_key";
            
            public static string PaymentStatus = @"payment_status";
            
            public static string DateCreated = @"date_created";
            
            public static string RequestorUserKey = @"requestor_user_key";
            
            public static string PaymentObjectSender = @"payment_object_sender";
            
            public static string PaymentObjectReceiver = @"payment_object_receiver";
            
            public static string PaymentDescription = @"payment_description";
            
            public static string SellAmount = @"sell_amount";
            
            public static string SellCurrency = @"sell_currency";
            
            public static string BuyAmount = @"buy_amount";
            
            public static string BuyCurrency = @"buy_currency";
            
            public static string Rate = @"rate";
            
            public static string ServiceFee = @"service_fee";
            
            public static string PromisedDeliveryDate = @"promised_delivery_date";
            
            public static string ActualDeliveryDate = @"actual_delivery_date";
            
            public static string ReceiverName = @"receiver_name";
            
            public static string SenderName = @"sender_name";
            
            public static string SellCurrencyText = @"sell_currency_text";
            
            public static string BuyCurrencyText = @"buy_currency_text";
            
            public static string PaymentStatusText = @"payment_status_text";
            
            public static string InternalOnly = @"internal_only";
            
	    }
	    #endregion
	    
	    
	    #region IAbstractRecord Members
        public new CT GetColumnValue<CT>(string columnName) {
            return base.GetColumnValue<CT>(columnName);
        }
        public object GetColumnValue(string columnName) {
            return base.GetColumnValue<object>(columnName);
        }
        #endregion
	    
    }
}
