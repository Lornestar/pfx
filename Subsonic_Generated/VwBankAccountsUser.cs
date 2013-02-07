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
    /// Strongly-typed collection for the VwBankAccountsUser class.
    /// </summary>
    [Serializable]
    public partial class VwBankAccountsUserCollection : ReadOnlyList<VwBankAccountsUser, VwBankAccountsUserCollection>
    {        
        public VwBankAccountsUserCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vw_Bank_Accounts_Users view.
    /// </summary>
    [Serializable]
    public partial class VwBankAccountsUser : ReadOnlyRecord<VwBankAccountsUser>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vw_Bank_Accounts_Users", TableType.View, DataService.GetInstance("Peerfx"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarPaymentObjectKey = new TableSchema.TableColumn(schema);
                colvarPaymentObjectKey.ColumnName = "payment_object_key";
                colvarPaymentObjectKey.DataType = DbType.Int64;
                colvarPaymentObjectKey.MaxLength = 0;
                colvarPaymentObjectKey.AutoIncrement = false;
                colvarPaymentObjectKey.IsNullable = false;
                colvarPaymentObjectKey.IsPrimaryKey = false;
                colvarPaymentObjectKey.IsForeignKey = false;
                colvarPaymentObjectKey.IsReadOnly = false;
                
                schema.Columns.Add(colvarPaymentObjectKey);
                
                TableSchema.TableColumn colvarPaymentObjectType = new TableSchema.TableColumn(schema);
                colvarPaymentObjectType.ColumnName = "payment_object_type";
                colvarPaymentObjectType.DataType = DbType.Int32;
                colvarPaymentObjectType.MaxLength = 0;
                colvarPaymentObjectType.AutoIncrement = false;
                colvarPaymentObjectType.IsNullable = false;
                colvarPaymentObjectType.IsPrimaryKey = false;
                colvarPaymentObjectType.IsForeignKey = false;
                colvarPaymentObjectType.IsReadOnly = false;
                
                schema.Columns.Add(colvarPaymentObjectType);
                
                TableSchema.TableColumn colvarObjectAccountKey = new TableSchema.TableColumn(schema);
                colvarObjectAccountKey.ColumnName = "object_account_key";
                colvarObjectAccountKey.DataType = DbType.Int32;
                colvarObjectAccountKey.MaxLength = 0;
                colvarObjectAccountKey.AutoIncrement = false;
                colvarObjectAccountKey.IsNullable = false;
                colvarObjectAccountKey.IsPrimaryKey = false;
                colvarObjectAccountKey.IsForeignKey = false;
                colvarObjectAccountKey.IsReadOnly = false;
                
                schema.Columns.Add(colvarObjectAccountKey);
                
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
                
                TableSchema.TableColumn colvarBankAccountKey = new TableSchema.TableColumn(schema);
                colvarBankAccountKey.ColumnName = "bank_account_key";
                colvarBankAccountKey.DataType = DbType.Int32;
                colvarBankAccountKey.MaxLength = 0;
                colvarBankAccountKey.AutoIncrement = false;
                colvarBankAccountKey.IsNullable = false;
                colvarBankAccountKey.IsPrimaryKey = false;
                colvarBankAccountKey.IsForeignKey = false;
                colvarBankAccountKey.IsReadOnly = false;
                
                schema.Columns.Add(colvarBankAccountKey);
                
                TableSchema.TableColumn colvarUserKey = new TableSchema.TableColumn(schema);
                colvarUserKey.ColumnName = "user_key";
                colvarUserKey.DataType = DbType.Int32;
                colvarUserKey.MaxLength = 0;
                colvarUserKey.AutoIncrement = false;
                colvarUserKey.IsNullable = true;
                colvarUserKey.IsPrimaryKey = false;
                colvarUserKey.IsForeignKey = false;
                colvarUserKey.IsReadOnly = false;
                
                schema.Columns.Add(colvarUserKey);
                
                TableSchema.TableColumn colvarCurrencyKey = new TableSchema.TableColumn(schema);
                colvarCurrencyKey.ColumnName = "currency_key";
                colvarCurrencyKey.DataType = DbType.Int32;
                colvarCurrencyKey.MaxLength = 0;
                colvarCurrencyKey.AutoIncrement = false;
                colvarCurrencyKey.IsNullable = false;
                colvarCurrencyKey.IsPrimaryKey = false;
                colvarCurrencyKey.IsForeignKey = false;
                colvarCurrencyKey.IsReadOnly = false;
                
                schema.Columns.Add(colvarCurrencyKey);
                
                TableSchema.TableColumn colvarOrganizationKey = new TableSchema.TableColumn(schema);
                colvarOrganizationKey.ColumnName = "organization_key";
                colvarOrganizationKey.DataType = DbType.Int32;
                colvarOrganizationKey.MaxLength = 0;
                colvarOrganizationKey.AutoIncrement = false;
                colvarOrganizationKey.IsNullable = true;
                colvarOrganizationKey.IsPrimaryKey = false;
                colvarOrganizationKey.IsForeignKey = false;
                colvarOrganizationKey.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganizationKey);
                
                TableSchema.TableColumn colvarBankAccountDescription = new TableSchema.TableColumn(schema);
                colvarBankAccountDescription.ColumnName = "bank_account_description";
                colvarBankAccountDescription.DataType = DbType.String;
                colvarBankAccountDescription.MaxLength = 100;
                colvarBankAccountDescription.AutoIncrement = false;
                colvarBankAccountDescription.IsNullable = true;
                colvarBankAccountDescription.IsPrimaryKey = false;
                colvarBankAccountDescription.IsForeignKey = false;
                colvarBankAccountDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarBankAccountDescription);
                
                TableSchema.TableColumn colvarUserKeyUpdated = new TableSchema.TableColumn(schema);
                colvarUserKeyUpdated.ColumnName = "user_key_updated";
                colvarUserKeyUpdated.DataType = DbType.Int32;
                colvarUserKeyUpdated.MaxLength = 0;
                colvarUserKeyUpdated.AutoIncrement = false;
                colvarUserKeyUpdated.IsNullable = false;
                colvarUserKeyUpdated.IsPrimaryKey = false;
                colvarUserKeyUpdated.IsForeignKey = false;
                colvarUserKeyUpdated.IsReadOnly = false;
                
                schema.Columns.Add(colvarUserKeyUpdated);
                
                TableSchema.TableColumn colvarIpAddress = new TableSchema.TableColumn(schema);
                colvarIpAddress.ColumnName = "ip_address";
                colvarIpAddress.DataType = DbType.AnsiString;
                colvarIpAddress.MaxLength = 20;
                colvarIpAddress.AutoIncrement = false;
                colvarIpAddress.IsNullable = false;
                colvarIpAddress.IsPrimaryKey = false;
                colvarIpAddress.IsForeignKey = false;
                colvarIpAddress.IsReadOnly = false;
                
                schema.Columns.Add(colvarIpAddress);
                
                TableSchema.TableColumn colvarAccountNumber = new TableSchema.TableColumn(schema);
                colvarAccountNumber.ColumnName = "account_number";
                colvarAccountNumber.DataType = DbType.AnsiString;
                colvarAccountNumber.MaxLength = 50;
                colvarAccountNumber.AutoIncrement = false;
                colvarAccountNumber.IsNullable = true;
                colvarAccountNumber.IsPrimaryKey = false;
                colvarAccountNumber.IsForeignKey = false;
                colvarAccountNumber.IsReadOnly = false;
                
                schema.Columns.Add(colvarAccountNumber);
                
                TableSchema.TableColumn colvarIban = new TableSchema.TableColumn(schema);
                colvarIban.ColumnName = "IBAN";
                colvarIban.DataType = DbType.AnsiString;
                colvarIban.MaxLength = 50;
                colvarIban.AutoIncrement = false;
                colvarIban.IsNullable = true;
                colvarIban.IsPrimaryKey = false;
                colvarIban.IsForeignKey = false;
                colvarIban.IsReadOnly = false;
                
                schema.Columns.Add(colvarIban);
                
                TableSchema.TableColumn colvarBic = new TableSchema.TableColumn(schema);
                colvarBic.ColumnName = "BIC";
                colvarBic.DataType = DbType.AnsiString;
                colvarBic.MaxLength = 50;
                colvarBic.AutoIncrement = false;
                colvarBic.IsNullable = true;
                colvarBic.IsPrimaryKey = false;
                colvarBic.IsForeignKey = false;
                colvarBic.IsReadOnly = false;
                
                schema.Columns.Add(colvarBic);
                
                TableSchema.TableColumn colvarABArouting = new TableSchema.TableColumn(schema);
                colvarABArouting.ColumnName = "ABArouting";
                colvarABArouting.DataType = DbType.AnsiString;
                colvarABArouting.MaxLength = 50;
                colvarABArouting.AutoIncrement = false;
                colvarABArouting.IsNullable = true;
                colvarABArouting.IsPrimaryKey = false;
                colvarABArouting.IsForeignKey = false;
                colvarABArouting.IsReadOnly = false;
                
                schema.Columns.Add(colvarABArouting);
                
                TableSchema.TableColumn colvarFirstName = new TableSchema.TableColumn(schema);
                colvarFirstName.ColumnName = "first_name";
                colvarFirstName.DataType = DbType.String;
                colvarFirstName.MaxLength = 100;
                colvarFirstName.AutoIncrement = false;
                colvarFirstName.IsNullable = true;
                colvarFirstName.IsPrimaryKey = false;
                colvarFirstName.IsForeignKey = false;
                colvarFirstName.IsReadOnly = false;
                
                schema.Columns.Add(colvarFirstName);
                
                TableSchema.TableColumn colvarLastName = new TableSchema.TableColumn(schema);
                colvarLastName.ColumnName = "last_name";
                colvarLastName.DataType = DbType.String;
                colvarLastName.MaxLength = 100;
                colvarLastName.AutoIncrement = false;
                colvarLastName.IsNullable = true;
                colvarLastName.IsPrimaryKey = false;
                colvarLastName.IsForeignKey = false;
                colvarLastName.IsReadOnly = false;
                
                schema.Columns.Add(colvarLastName);
                
                TableSchema.TableColumn colvarBusinessName = new TableSchema.TableColumn(schema);
                colvarBusinessName.ColumnName = "business_name";
                colvarBusinessName.DataType = DbType.String;
                colvarBusinessName.MaxLength = 100;
                colvarBusinessName.AutoIncrement = false;
                colvarBusinessName.IsNullable = true;
                colvarBusinessName.IsPrimaryKey = false;
                colvarBusinessName.IsForeignKey = false;
                colvarBusinessName.IsReadOnly = false;
                
                schema.Columns.Add(colvarBusinessName);
                
                TableSchema.TableColumn colvarLastChanged = new TableSchema.TableColumn(schema);
                colvarLastChanged.ColumnName = "last_changed";
                colvarLastChanged.DataType = DbType.DateTime;
                colvarLastChanged.MaxLength = 0;
                colvarLastChanged.AutoIncrement = false;
                colvarLastChanged.IsNullable = false;
                colvarLastChanged.IsPrimaryKey = false;
                colvarLastChanged.IsForeignKey = false;
                colvarLastChanged.IsReadOnly = false;
                
                schema.Columns.Add(colvarLastChanged);
                
                TableSchema.TableColumn colvarExpr1 = new TableSchema.TableColumn(schema);
                colvarExpr1.ColumnName = "Expr1";
                colvarExpr1.DataType = DbType.DateTime;
                colvarExpr1.MaxLength = 0;
                colvarExpr1.AutoIncrement = false;
                colvarExpr1.IsNullable = true;
                colvarExpr1.IsPrimaryKey = false;
                colvarExpr1.IsForeignKey = false;
                colvarExpr1.IsReadOnly = false;
                
                schema.Columns.Add(colvarExpr1);
                
                TableSchema.TableColumn colvarBankAccountInfo = new TableSchema.TableColumn(schema);
                colvarBankAccountInfo.ColumnName = "bank_account_info";
                colvarBankAccountInfo.DataType = DbType.String;
                colvarBankAccountInfo.MaxLength = 100;
                colvarBankAccountInfo.AutoIncrement = false;
                colvarBankAccountInfo.IsNullable = true;
                colvarBankAccountInfo.IsPrimaryKey = false;
                colvarBankAccountInfo.IsForeignKey = false;
                colvarBankAccountInfo.IsReadOnly = false;
                
                schema.Columns.Add(colvarBankAccountInfo);
                
                TableSchema.TableColumn colvarOrganizationName = new TableSchema.TableColumn(schema);
                colvarOrganizationName.ColumnName = "organization_name";
                colvarOrganizationName.DataType = DbType.String;
                colvarOrganizationName.MaxLength = 50;
                colvarOrganizationName.AutoIncrement = false;
                colvarOrganizationName.IsNullable = true;
                colvarOrganizationName.IsPrimaryKey = false;
                colvarOrganizationName.IsForeignKey = false;
                colvarOrganizationName.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganizationName);
                
                TableSchema.TableColumn colvarCountryText = new TableSchema.TableColumn(schema);
                colvarCountryText.ColumnName = "country_text";
                colvarCountryText.DataType = DbType.String;
                colvarCountryText.MaxLength = 50;
                colvarCountryText.AutoIncrement = false;
                colvarCountryText.IsNullable = true;
                colvarCountryText.IsPrimaryKey = false;
                colvarCountryText.IsForeignKey = false;
                colvarCountryText.IsReadOnly = false;
                
                schema.Columns.Add(colvarCountryText);
                
                TableSchema.TableColumn colvarCurrencyText = new TableSchema.TableColumn(schema);
                colvarCurrencyText.ColumnName = "currency_text";
                colvarCurrencyText.DataType = DbType.String;
                colvarCurrencyText.MaxLength = 50;
                colvarCurrencyText.AutoIncrement = false;
                colvarCurrencyText.IsNullable = true;
                colvarCurrencyText.IsPrimaryKey = false;
                colvarCurrencyText.IsForeignKey = false;
                colvarCurrencyText.IsReadOnly = false;
                
                schema.Columns.Add(colvarCurrencyText);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Peerfx"].AddSchema("vw_Bank_Accounts_Users",schema);
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
	    public VwBankAccountsUser()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VwBankAccountsUser(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VwBankAccountsUser(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VwBankAccountsUser(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("PaymentObjectKey")]
        [Bindable(true)]
        public long PaymentObjectKey 
	    {
		    get
		    {
			    return GetColumnValue<long>("payment_object_key");
		    }
            set 
		    {
			    SetColumnValue("payment_object_key", value);
            }
        }
	      
        [XmlAttribute("PaymentObjectType")]
        [Bindable(true)]
        public int PaymentObjectType 
	    {
		    get
		    {
			    return GetColumnValue<int>("payment_object_type");
		    }
            set 
		    {
			    SetColumnValue("payment_object_type", value);
            }
        }
	      
        [XmlAttribute("ObjectAccountKey")]
        [Bindable(true)]
        public int ObjectAccountKey 
	    {
		    get
		    {
			    return GetColumnValue<int>("object_account_key");
		    }
            set 
		    {
			    SetColumnValue("object_account_key", value);
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
	      
        [XmlAttribute("BankAccountKey")]
        [Bindable(true)]
        public int BankAccountKey 
	    {
		    get
		    {
			    return GetColumnValue<int>("bank_account_key");
		    }
            set 
		    {
			    SetColumnValue("bank_account_key", value);
            }
        }
	      
        [XmlAttribute("UserKey")]
        [Bindable(true)]
        public int? UserKey 
	    {
		    get
		    {
			    return GetColumnValue<int?>("user_key");
		    }
            set 
		    {
			    SetColumnValue("user_key", value);
            }
        }
	      
        [XmlAttribute("CurrencyKey")]
        [Bindable(true)]
        public int CurrencyKey 
	    {
		    get
		    {
			    return GetColumnValue<int>("currency_key");
		    }
            set 
		    {
			    SetColumnValue("currency_key", value);
            }
        }
	      
        [XmlAttribute("OrganizationKey")]
        [Bindable(true)]
        public int? OrganizationKey 
	    {
		    get
		    {
			    return GetColumnValue<int?>("organization_key");
		    }
            set 
		    {
			    SetColumnValue("organization_key", value);
            }
        }
	      
        [XmlAttribute("BankAccountDescription")]
        [Bindable(true)]
        public string BankAccountDescription 
	    {
		    get
		    {
			    return GetColumnValue<string>("bank_account_description");
		    }
            set 
		    {
			    SetColumnValue("bank_account_description", value);
            }
        }
	      
        [XmlAttribute("UserKeyUpdated")]
        [Bindable(true)]
        public int UserKeyUpdated 
	    {
		    get
		    {
			    return GetColumnValue<int>("user_key_updated");
		    }
            set 
		    {
			    SetColumnValue("user_key_updated", value);
            }
        }
	      
        [XmlAttribute("IpAddress")]
        [Bindable(true)]
        public string IpAddress 
	    {
		    get
		    {
			    return GetColumnValue<string>("ip_address");
		    }
            set 
		    {
			    SetColumnValue("ip_address", value);
            }
        }
	      
        [XmlAttribute("AccountNumber")]
        [Bindable(true)]
        public string AccountNumber 
	    {
		    get
		    {
			    return GetColumnValue<string>("account_number");
		    }
            set 
		    {
			    SetColumnValue("account_number", value);
            }
        }
	      
        [XmlAttribute("Iban")]
        [Bindable(true)]
        public string Iban 
	    {
		    get
		    {
			    return GetColumnValue<string>("IBAN");
		    }
            set 
		    {
			    SetColumnValue("IBAN", value);
            }
        }
	      
        [XmlAttribute("Bic")]
        [Bindable(true)]
        public string Bic 
	    {
		    get
		    {
			    return GetColumnValue<string>("BIC");
		    }
            set 
		    {
			    SetColumnValue("BIC", value);
            }
        }
	      
        [XmlAttribute("ABArouting")]
        [Bindable(true)]
        public string ABArouting 
	    {
		    get
		    {
			    return GetColumnValue<string>("ABArouting");
		    }
            set 
		    {
			    SetColumnValue("ABArouting", value);
            }
        }
	      
        [XmlAttribute("FirstName")]
        [Bindable(true)]
        public string FirstName 
	    {
		    get
		    {
			    return GetColumnValue<string>("first_name");
		    }
            set 
		    {
			    SetColumnValue("first_name", value);
            }
        }
	      
        [XmlAttribute("LastName")]
        [Bindable(true)]
        public string LastName 
	    {
		    get
		    {
			    return GetColumnValue<string>("last_name");
		    }
            set 
		    {
			    SetColumnValue("last_name", value);
            }
        }
	      
        [XmlAttribute("BusinessName")]
        [Bindable(true)]
        public string BusinessName 
	    {
		    get
		    {
			    return GetColumnValue<string>("business_name");
		    }
            set 
		    {
			    SetColumnValue("business_name", value);
            }
        }
	      
        [XmlAttribute("LastChanged")]
        [Bindable(true)]
        public DateTime LastChanged 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("last_changed");
		    }
            set 
		    {
			    SetColumnValue("last_changed", value);
            }
        }
	      
        [XmlAttribute("Expr1")]
        [Bindable(true)]
        public DateTime? Expr1 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("Expr1");
		    }
            set 
		    {
			    SetColumnValue("Expr1", value);
            }
        }
	      
        [XmlAttribute("BankAccountInfo")]
        [Bindable(true)]
        public string BankAccountInfo 
	    {
		    get
		    {
			    return GetColumnValue<string>("bank_account_info");
		    }
            set 
		    {
			    SetColumnValue("bank_account_info", value);
            }
        }
	      
        [XmlAttribute("OrganizationName")]
        [Bindable(true)]
        public string OrganizationName 
	    {
		    get
		    {
			    return GetColumnValue<string>("organization_name");
		    }
            set 
		    {
			    SetColumnValue("organization_name", value);
            }
        }
	      
        [XmlAttribute("CountryText")]
        [Bindable(true)]
        public string CountryText 
	    {
		    get
		    {
			    return GetColumnValue<string>("country_text");
		    }
            set 
		    {
			    SetColumnValue("country_text", value);
            }
        }
	      
        [XmlAttribute("CurrencyText")]
        [Bindable(true)]
        public string CurrencyText 
	    {
		    get
		    {
			    return GetColumnValue<string>("currency_text");
		    }
            set 
		    {
			    SetColumnValue("currency_text", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string PaymentObjectKey = @"payment_object_key";
            
            public static string PaymentObjectType = @"payment_object_type";
            
            public static string ObjectAccountKey = @"object_account_key";
            
            public static string DateCreated = @"date_created";
            
            public static string BankAccountKey = @"bank_account_key";
            
            public static string UserKey = @"user_key";
            
            public static string CurrencyKey = @"currency_key";
            
            public static string OrganizationKey = @"organization_key";
            
            public static string BankAccountDescription = @"bank_account_description";
            
            public static string UserKeyUpdated = @"user_key_updated";
            
            public static string IpAddress = @"ip_address";
            
            public static string AccountNumber = @"account_number";
            
            public static string Iban = @"IBAN";
            
            public static string Bic = @"BIC";
            
            public static string ABArouting = @"ABArouting";
            
            public static string FirstName = @"first_name";
            
            public static string LastName = @"last_name";
            
            public static string BusinessName = @"business_name";
            
            public static string LastChanged = @"last_changed";
            
            public static string Expr1 = @"Expr1";
            
            public static string BankAccountInfo = @"bank_account_info";
            
            public static string OrganizationName = @"organization_name";
            
            public static string CountryText = @"country_text";
            
            public static string CurrencyText = @"currency_text";
            
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
