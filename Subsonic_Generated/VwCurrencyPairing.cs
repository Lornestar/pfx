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
    /// Strongly-typed collection for the VwCurrencyPairing class.
    /// </summary>
    [Serializable]
    public partial class VwCurrencyPairingCollection : ReadOnlyList<VwCurrencyPairing, VwCurrencyPairingCollection>
    {        
        public VwCurrencyPairingCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vw_currency_pairings view.
    /// </summary>
    [Serializable]
    public partial class VwCurrencyPairing : ReadOnlyRecord<VwCurrencyPairing>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vw_currency_pairings", TableType.View, DataService.GetInstance("Peerfx"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarInfoFeeTypes = new TableSchema.TableColumn(schema);
                colvarInfoFeeTypes.ColumnName = "info_fee_types";
                colvarInfoFeeTypes.DataType = DbType.Int32;
                colvarInfoFeeTypes.MaxLength = 0;
                colvarInfoFeeTypes.AutoIncrement = false;
                colvarInfoFeeTypes.IsNullable = false;
                colvarInfoFeeTypes.IsPrimaryKey = false;
                colvarInfoFeeTypes.IsForeignKey = false;
                colvarInfoFeeTypes.IsReadOnly = false;
                
                schema.Columns.Add(colvarInfoFeeTypes);
                
                TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
                colvarDescription.ColumnName = "description";
                colvarDescription.DataType = DbType.String;
                colvarDescription.MaxLength = 100;
                colvarDescription.AutoIncrement = false;
                colvarDescription.IsNullable = true;
                colvarDescription.IsPrimaryKey = false;
                colvarDescription.IsForeignKey = false;
                colvarDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarDescription);
                
                TableSchema.TableColumn colvarFeeBase = new TableSchema.TableColumn(schema);
                colvarFeeBase.ColumnName = "fee_base";
                colvarFeeBase.DataType = DbType.Currency;
                colvarFeeBase.MaxLength = 0;
                colvarFeeBase.AutoIncrement = false;
                colvarFeeBase.IsNullable = true;
                colvarFeeBase.IsPrimaryKey = false;
                colvarFeeBase.IsForeignKey = false;
                colvarFeeBase.IsReadOnly = false;
                
                schema.Columns.Add(colvarFeeBase);
                
                TableSchema.TableColumn colvarFeePercentage = new TableSchema.TableColumn(schema);
                colvarFeePercentage.ColumnName = "fee_percentage";
                colvarFeePercentage.DataType = DbType.Currency;
                colvarFeePercentage.MaxLength = 0;
                colvarFeePercentage.AutoIncrement = false;
                colvarFeePercentage.IsNullable = true;
                colvarFeePercentage.IsPrimaryKey = false;
                colvarFeePercentage.IsForeignKey = false;
                colvarFeePercentage.IsReadOnly = false;
                
                schema.Columns.Add(colvarFeePercentage);
                
                TableSchema.TableColumn colvarFeeAddon = new TableSchema.TableColumn(schema);
                colvarFeeAddon.ColumnName = "fee_addon";
                colvarFeeAddon.DataType = DbType.Currency;
                colvarFeeAddon.MaxLength = 0;
                colvarFeeAddon.AutoIncrement = false;
                colvarFeeAddon.IsNullable = true;
                colvarFeeAddon.IsPrimaryKey = false;
                colvarFeeAddon.IsForeignKey = false;
                colvarFeeAddon.IsReadOnly = false;
                
                schema.Columns.Add(colvarFeeAddon);
                
                TableSchema.TableColumn colvarFeeMin = new TableSchema.TableColumn(schema);
                colvarFeeMin.ColumnName = "fee_min";
                colvarFeeMin.DataType = DbType.Currency;
                colvarFeeMin.MaxLength = 0;
                colvarFeeMin.AutoIncrement = false;
                colvarFeeMin.IsNullable = true;
                colvarFeeMin.IsPrimaryKey = false;
                colvarFeeMin.IsForeignKey = false;
                colvarFeeMin.IsReadOnly = false;
                
                schema.Columns.Add(colvarFeeMin);
                
                TableSchema.TableColumn colvarFeeMax = new TableSchema.TableColumn(schema);
                colvarFeeMax.ColumnName = "fee_max";
                colvarFeeMax.DataType = DbType.Currency;
                colvarFeeMax.MaxLength = 0;
                colvarFeeMax.AutoIncrement = false;
                colvarFeeMax.IsNullable = true;
                colvarFeeMax.IsPrimaryKey = false;
                colvarFeeMax.IsForeignKey = false;
                colvarFeeMax.IsReadOnly = false;
                
                schema.Columns.Add(colvarFeeMax);
                
                TableSchema.TableColumn colvarCurrency1 = new TableSchema.TableColumn(schema);
                colvarCurrency1.ColumnName = "currency1";
                colvarCurrency1.DataType = DbType.Int32;
                colvarCurrency1.MaxLength = 0;
                colvarCurrency1.AutoIncrement = false;
                colvarCurrency1.IsNullable = true;
                colvarCurrency1.IsPrimaryKey = false;
                colvarCurrency1.IsForeignKey = false;
                colvarCurrency1.IsReadOnly = false;
                
                schema.Columns.Add(colvarCurrency1);
                
                TableSchema.TableColumn colvarCurrency2 = new TableSchema.TableColumn(schema);
                colvarCurrency2.ColumnName = "currency2";
                colvarCurrency2.DataType = DbType.Int32;
                colvarCurrency2.MaxLength = 0;
                colvarCurrency2.AutoIncrement = false;
                colvarCurrency2.IsNullable = true;
                colvarCurrency2.IsPrimaryKey = false;
                colvarCurrency2.IsForeignKey = false;
                colvarCurrency2.IsReadOnly = false;
                
                schema.Columns.Add(colvarCurrency2);
                
                TableSchema.TableColumn colvarExchangeRateUpdated = new TableSchema.TableColumn(schema);
                colvarExchangeRateUpdated.ColumnName = "Exchange_Rate_Updated";
                colvarExchangeRateUpdated.DataType = DbType.DateTime;
                colvarExchangeRateUpdated.MaxLength = 0;
                colvarExchangeRateUpdated.AutoIncrement = false;
                colvarExchangeRateUpdated.IsNullable = true;
                colvarExchangeRateUpdated.IsPrimaryKey = false;
                colvarExchangeRateUpdated.IsForeignKey = false;
                colvarExchangeRateUpdated.IsReadOnly = false;
                
                schema.Columns.Add(colvarExchangeRateUpdated);
                
                TableSchema.TableColumn colvarExchangeRate = new TableSchema.TableColumn(schema);
                colvarExchangeRate.ColumnName = "Exchange_Rate";
                colvarExchangeRate.DataType = DbType.Decimal;
                colvarExchangeRate.MaxLength = 0;
                colvarExchangeRate.AutoIncrement = false;
                colvarExchangeRate.IsNullable = true;
                colvarExchangeRate.IsPrimaryKey = false;
                colvarExchangeRate.IsForeignKey = false;
                colvarExchangeRate.IsReadOnly = false;
                
                schema.Columns.Add(colvarExchangeRate);
                
                TableSchema.TableColumn colvarTreasuryType = new TableSchema.TableColumn(schema);
                colvarTreasuryType.ColumnName = "Treasury_Type";
                colvarTreasuryType.DataType = DbType.Int32;
                colvarTreasuryType.MaxLength = 0;
                colvarTreasuryType.AutoIncrement = false;
                colvarTreasuryType.IsNullable = true;
                colvarTreasuryType.IsPrimaryKey = false;
                colvarTreasuryType.IsForeignKey = false;
                colvarTreasuryType.IsReadOnly = false;
                
                schema.Columns.Add(colvarTreasuryType);
                
                TableSchema.TableColumn colvarCurrency1Code = new TableSchema.TableColumn(schema);
                colvarCurrency1Code.ColumnName = "currency1_code";
                colvarCurrency1Code.DataType = DbType.String;
                colvarCurrency1Code.MaxLength = 3;
                colvarCurrency1Code.AutoIncrement = false;
                colvarCurrency1Code.IsNullable = true;
                colvarCurrency1Code.IsPrimaryKey = false;
                colvarCurrency1Code.IsForeignKey = false;
                colvarCurrency1Code.IsReadOnly = false;
                
                schema.Columns.Add(colvarCurrency1Code);
                
                TableSchema.TableColumn colvarCurrency2Code = new TableSchema.TableColumn(schema);
                colvarCurrency2Code.ColumnName = "currency2_code";
                colvarCurrency2Code.DataType = DbType.String;
                colvarCurrency2Code.MaxLength = 3;
                colvarCurrency2Code.AutoIncrement = false;
                colvarCurrency2Code.IsNullable = true;
                colvarCurrency2Code.IsPrimaryKey = false;
                colvarCurrency2Code.IsForeignKey = false;
                colvarCurrency2Code.IsReadOnly = false;
                
                schema.Columns.Add(colvarCurrency2Code);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Peerfx"].AddSchema("vw_currency_pairings",schema);
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
	    public VwCurrencyPairing()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VwCurrencyPairing(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VwCurrencyPairing(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VwCurrencyPairing(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("InfoFeeTypes")]
        [Bindable(true)]
        public int InfoFeeTypes 
	    {
		    get
		    {
			    return GetColumnValue<int>("info_fee_types");
		    }
            set 
		    {
			    SetColumnValue("info_fee_types", value);
            }
        }
	      
        [XmlAttribute("Description")]
        [Bindable(true)]
        public string Description 
	    {
		    get
		    {
			    return GetColumnValue<string>("description");
		    }
            set 
		    {
			    SetColumnValue("description", value);
            }
        }
	      
        [XmlAttribute("FeeBase")]
        [Bindable(true)]
        public decimal? FeeBase 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("fee_base");
		    }
            set 
		    {
			    SetColumnValue("fee_base", value);
            }
        }
	      
        [XmlAttribute("FeePercentage")]
        [Bindable(true)]
        public decimal? FeePercentage 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("fee_percentage");
		    }
            set 
		    {
			    SetColumnValue("fee_percentage", value);
            }
        }
	      
        [XmlAttribute("FeeAddon")]
        [Bindable(true)]
        public decimal? FeeAddon 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("fee_addon");
		    }
            set 
		    {
			    SetColumnValue("fee_addon", value);
            }
        }
	      
        [XmlAttribute("FeeMin")]
        [Bindable(true)]
        public decimal? FeeMin 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("fee_min");
		    }
            set 
		    {
			    SetColumnValue("fee_min", value);
            }
        }
	      
        [XmlAttribute("FeeMax")]
        [Bindable(true)]
        public decimal? FeeMax 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("fee_max");
		    }
            set 
		    {
			    SetColumnValue("fee_max", value);
            }
        }
	      
        [XmlAttribute("Currency1")]
        [Bindable(true)]
        public int? Currency1 
	    {
		    get
		    {
			    return GetColumnValue<int?>("currency1");
		    }
            set 
		    {
			    SetColumnValue("currency1", value);
            }
        }
	      
        [XmlAttribute("Currency2")]
        [Bindable(true)]
        public int? Currency2 
	    {
		    get
		    {
			    return GetColumnValue<int?>("currency2");
		    }
            set 
		    {
			    SetColumnValue("currency2", value);
            }
        }
	      
        [XmlAttribute("ExchangeRateUpdated")]
        [Bindable(true)]
        public DateTime? ExchangeRateUpdated 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("Exchange_Rate_Updated");
		    }
            set 
		    {
			    SetColumnValue("Exchange_Rate_Updated", value);
            }
        }
	      
        [XmlAttribute("ExchangeRate")]
        [Bindable(true)]
        public decimal? ExchangeRate 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("Exchange_Rate");
		    }
            set 
		    {
			    SetColumnValue("Exchange_Rate", value);
            }
        }
	      
        [XmlAttribute("TreasuryType")]
        [Bindable(true)]
        public int? TreasuryType 
	    {
		    get
		    {
			    return GetColumnValue<int?>("Treasury_Type");
		    }
            set 
		    {
			    SetColumnValue("Treasury_Type", value);
            }
        }
	      
        [XmlAttribute("Currency1Code")]
        [Bindable(true)]
        public string Currency1Code 
	    {
		    get
		    {
			    return GetColumnValue<string>("currency1_code");
		    }
            set 
		    {
			    SetColumnValue("currency1_code", value);
            }
        }
	      
        [XmlAttribute("Currency2Code")]
        [Bindable(true)]
        public string Currency2Code 
	    {
		    get
		    {
			    return GetColumnValue<string>("currency2_code");
		    }
            set 
		    {
			    SetColumnValue("currency2_code", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string InfoFeeTypes = @"info_fee_types";
            
            public static string Description = @"description";
            
            public static string FeeBase = @"fee_base";
            
            public static string FeePercentage = @"fee_percentage";
            
            public static string FeeAddon = @"fee_addon";
            
            public static string FeeMin = @"fee_min";
            
            public static string FeeMax = @"fee_max";
            
            public static string Currency1 = @"currency1";
            
            public static string Currency2 = @"currency2";
            
            public static string ExchangeRateUpdated = @"Exchange_Rate_Updated";
            
            public static string ExchangeRate = @"Exchange_Rate";
            
            public static string TreasuryType = @"Treasury_Type";
            
            public static string Currency1Code = @"currency1_code";
            
            public static string Currency2Code = @"currency2_code";
            
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
