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
    /// Strongly-typed collection for the VwCurrencyCloudSettlement class.
    /// </summary>
    [Serializable]
    public partial class VwCurrencyCloudSettlementCollection : ReadOnlyList<VwCurrencyCloudSettlement, VwCurrencyCloudSettlementCollection>
    {        
        public VwCurrencyCloudSettlementCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vw_CurrencyCloud_Settlements view.
    /// </summary>
    [Serializable]
    public partial class VwCurrencyCloudSettlement : ReadOnlyRecord<VwCurrencyCloudSettlement>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vw_CurrencyCloud_Settlements", TableType.View, DataService.GetInstance("Peerfx"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarInitiatedDate = new TableSchema.TableColumn(schema);
                colvarInitiatedDate.ColumnName = "initiated_date";
                colvarInitiatedDate.DataType = DbType.DateTime;
                colvarInitiatedDate.MaxLength = 0;
                colvarInitiatedDate.AutoIncrement = false;
                colvarInitiatedDate.IsNullable = true;
                colvarInitiatedDate.IsPrimaryKey = false;
                colvarInitiatedDate.IsForeignKey = false;
                colvarInitiatedDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarInitiatedDate);
                
                TableSchema.TableColumn colvarReleasedate = new TableSchema.TableColumn(schema);
                colvarReleasedate.ColumnName = "releasedate";
                colvarReleasedate.DataType = DbType.DateTime;
                colvarReleasedate.MaxLength = 0;
                colvarReleasedate.AutoIncrement = false;
                colvarReleasedate.IsNullable = true;
                colvarReleasedate.IsPrimaryKey = false;
                colvarReleasedate.IsForeignKey = false;
                colvarReleasedate.IsReadOnly = false;
                
                schema.Columns.Add(colvarReleasedate);
                
                TableSchema.TableColumn colvarCcSettlementid = new TableSchema.TableColumn(schema);
                colvarCcSettlementid.ColumnName = "cc_settlementid";
                colvarCcSettlementid.DataType = DbType.AnsiString;
                colvarCcSettlementid.MaxLength = 50;
                colvarCcSettlementid.AutoIncrement = false;
                colvarCcSettlementid.IsNullable = true;
                colvarCcSettlementid.IsPrimaryKey = false;
                colvarCcSettlementid.IsForeignKey = false;
                colvarCcSettlementid.IsReadOnly = false;
                
                schema.Columns.Add(colvarCcSettlementid);
                
                TableSchema.TableColumn colvarCurrencycloudSettlementKey = new TableSchema.TableColumn(schema);
                colvarCurrencycloudSettlementKey.ColumnName = "currencycloud_settlement_key";
                colvarCurrencycloudSettlementKey.DataType = DbType.Int64;
                colvarCurrencycloudSettlementKey.MaxLength = 0;
                colvarCurrencycloudSettlementKey.AutoIncrement = false;
                colvarCurrencycloudSettlementKey.IsNullable = false;
                colvarCurrencycloudSettlementKey.IsPrimaryKey = false;
                colvarCurrencycloudSettlementKey.IsForeignKey = false;
                colvarCurrencycloudSettlementKey.IsReadOnly = false;
                
                schema.Columns.Add(colvarCurrencycloudSettlementKey);
                
                TableSchema.TableColumn colvarNumberOfTrades = new TableSchema.TableColumn(schema);
                colvarNumberOfTrades.ColumnName = "number_of_trades";
                colvarNumberOfTrades.DataType = DbType.Int32;
                colvarNumberOfTrades.MaxLength = 0;
                colvarNumberOfTrades.AutoIncrement = false;
                colvarNumberOfTrades.IsNullable = true;
                colvarNumberOfTrades.IsPrimaryKey = false;
                colvarNumberOfTrades.IsForeignKey = false;
                colvarNumberOfTrades.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumberOfTrades);
                
                TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
                colvarStatus.ColumnName = "status";
                colvarStatus.DataType = DbType.Int32;
                colvarStatus.MaxLength = 0;
                colvarStatus.AutoIncrement = false;
                colvarStatus.IsNullable = false;
                colvarStatus.IsPrimaryKey = false;
                colvarStatus.IsForeignKey = false;
                colvarStatus.IsReadOnly = false;
                
                schema.Columns.Add(colvarStatus);
                
                TableSchema.TableColumn colvarFundsreceivedDate = new TableSchema.TableColumn(schema);
                colvarFundsreceivedDate.ColumnName = "fundsreceived_date";
                colvarFundsreceivedDate.DataType = DbType.DateTime;
                colvarFundsreceivedDate.MaxLength = 0;
                colvarFundsreceivedDate.AutoIncrement = false;
                colvarFundsreceivedDate.IsNullable = true;
                colvarFundsreceivedDate.IsPrimaryKey = false;
                colvarFundsreceivedDate.IsForeignKey = false;
                colvarFundsreceivedDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarFundsreceivedDate);
                
                TableSchema.TableColumn colvarWithdrawlsentDate = new TableSchema.TableColumn(schema);
                colvarWithdrawlsentDate.ColumnName = "withdrawlsent_date";
                colvarWithdrawlsentDate.DataType = DbType.DateTime;
                colvarWithdrawlsentDate.MaxLength = 0;
                colvarWithdrawlsentDate.AutoIncrement = false;
                colvarWithdrawlsentDate.IsNullable = true;
                colvarWithdrawlsentDate.IsPrimaryKey = false;
                colvarWithdrawlsentDate.IsForeignKey = false;
                colvarWithdrawlsentDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarWithdrawlsentDate);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Peerfx"].AddSchema("vw_CurrencyCloud_Settlements",schema);
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
	    public VwCurrencyCloudSettlement()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VwCurrencyCloudSettlement(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VwCurrencyCloudSettlement(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VwCurrencyCloudSettlement(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("InitiatedDate")]
        [Bindable(true)]
        public DateTime? InitiatedDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("initiated_date");
		    }
            set 
		    {
			    SetColumnValue("initiated_date", value);
            }
        }
	      
        [XmlAttribute("Releasedate")]
        [Bindable(true)]
        public DateTime? Releasedate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("releasedate");
		    }
            set 
		    {
			    SetColumnValue("releasedate", value);
            }
        }
	      
        [XmlAttribute("CcSettlementid")]
        [Bindable(true)]
        public string CcSettlementid 
	    {
		    get
		    {
			    return GetColumnValue<string>("cc_settlementid");
		    }
            set 
		    {
			    SetColumnValue("cc_settlementid", value);
            }
        }
	      
        [XmlAttribute("CurrencycloudSettlementKey")]
        [Bindable(true)]
        public long CurrencycloudSettlementKey 
	    {
		    get
		    {
			    return GetColumnValue<long>("currencycloud_settlement_key");
		    }
            set 
		    {
			    SetColumnValue("currencycloud_settlement_key", value);
            }
        }
	      
        [XmlAttribute("NumberOfTrades")]
        [Bindable(true)]
        public int? NumberOfTrades 
	    {
		    get
		    {
			    return GetColumnValue<int?>("number_of_trades");
		    }
            set 
		    {
			    SetColumnValue("number_of_trades", value);
            }
        }
	      
        [XmlAttribute("Status")]
        [Bindable(true)]
        public int Status 
	    {
		    get
		    {
			    return GetColumnValue<int>("status");
		    }
            set 
		    {
			    SetColumnValue("status", value);
            }
        }
	      
        [XmlAttribute("FundsreceivedDate")]
        [Bindable(true)]
        public DateTime? FundsreceivedDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("fundsreceived_date");
		    }
            set 
		    {
			    SetColumnValue("fundsreceived_date", value);
            }
        }
	      
        [XmlAttribute("WithdrawlsentDate")]
        [Bindable(true)]
        public DateTime? WithdrawlsentDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("withdrawlsent_date");
		    }
            set 
		    {
			    SetColumnValue("withdrawlsent_date", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string InitiatedDate = @"initiated_date";
            
            public static string Releasedate = @"releasedate";
            
            public static string CcSettlementid = @"cc_settlementid";
            
            public static string CurrencycloudSettlementKey = @"currencycloud_settlement_key";
            
            public static string NumberOfTrades = @"number_of_trades";
            
            public static string Status = @"status";
            
            public static string FundsreceivedDate = @"fundsreceived_date";
            
            public static string WithdrawlsentDate = @"withdrawlsent_date";
            
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
