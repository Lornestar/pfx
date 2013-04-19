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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static readonly string AdminBankAccount = @"Admin_Bank_Accounts";
        
		public static readonly string AspnetApplication = @"aspnet_Applications";
        
		public static readonly string AspnetSchemaVersion = @"aspnet_SchemaVersions";
        
		public static readonly string AspnetUser = @"aspnet_Users";
        
		public static readonly string AspnetWebEventEvent = @"aspnet_WebEvent_Events";
        
		public static readonly string BankAccountFieldType = @"Bank_Account_Field_Type";
        
		public static readonly string BankAccountLocalRequiredField = @"Bank_Account_Local_Required_Fields";
        
		public static readonly string BankAccount = @"Bank_Accounts";
        
		public static readonly string CurrencyCloudSettlement = @"CurrencyCloud_Settlements";
        
		public static readonly string CurrencyCloudTrade = @"CurrencyCloud_Trades";
        
		public static readonly string CurrencyCloudTradesError = @"CurrencyCloud_Trades_Errors";
        
		public static readonly string EmbeeObject = @"Embee_Objects";
        
		public static readonly string EmbeeCatalog = @"EmbeeCatalog";
        
		public static readonly string ErrorLog = @"Error_Log";
        
		public static readonly string InfoCountryCodeList = @"Info_Country_Code_List";
        
		public static readonly string InfoCountryList = @"Info_Country_List";
        
		public static readonly string InfoCurrency = @"Info_Currencies";
        
		public static readonly string InfoCurrencyCloudToken = @"Info_CurrencyCloud_Tokens";
        
		public static readonly string InfoFeeType = @"Info_Fee_Types";
        
		public static readonly string InfoOrganizationType = @"Info_Organization_Type";
        
		public static readonly string InfoOrganization = @"Info_Organizations";
        
		public static readonly string InfoPhoneType = @"Info_Phone_Type";
        
		public static readonly string InfoSecurityQuestion = @"Info_Security_Questions";
        
		public static readonly string InfoVerificationMethod = @"Info_Verification_Methods";
        
		public static readonly string PaymentObjectType = @"Payment_Object_Types";
        
		public static readonly string PaymentObject = @"Payment_Objects";
        
		public static readonly string PaymentSchedule = @"Payment_Schedule";
        
		public static readonly string PaymentStatus = @"Payment_Status";
        
		public static readonly string PaymentTimingType = @"Payment_Timing_Types";
        
		public static readonly string Payment = @"Payments";
        
		public static readonly string PurposeType = @"Purpose_Types";
        
		public static readonly string Quote = @"Quotes";
        
		public static readonly string Recipient = @"Recipients";
        
		public static readonly string ScheduledTask = @"Scheduled_Task";
        
		public static readonly string ScheduledTaskType = @"Scheduled_Task_Types";
        
		public static readonly string TransactionFee = @"Transaction_Fees";
        
		public static readonly string TransactionStatus = @"Transaction_Status";
        
		public static readonly string TransactionsExternal = @"Transactions_External";
        
		public static readonly string TransactionsInternal = @"Transactions_Internal";
        
		public static readonly string TreasuryType = @"Treasury_Type";
        
		public static readonly string UserFacebook = @"User_Facebook";
        
		public static readonly string UserRecipient = @"User_Recipients";
        
		public static readonly string UserStatus = @"User_Statuses";
        
		public static readonly string UserType = @"User_Types";
        
		public static readonly string User = @"Users";
        
		public static readonly string UsersBancbox = @"Users_Bancbox";
        
		public static readonly string UsersInfo = @"Users_Info";
        
		public static readonly string UsersSecurityAnswer = @"Users_Security_Answers";
        
		public static readonly string UsersVerified = @"Users_Verified";
        
		public static readonly string VerificationMethod = @"Verification_Methods";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table AdminBankAccount
		{
            get { return DataService.GetSchema("Admin_Bank_Accounts", "Peerfx"); }
		}
        
		public static TableSchema.Table AspnetApplication
		{
            get { return DataService.GetSchema("aspnet_Applications", "Peerfx"); }
		}
        
		public static TableSchema.Table AspnetSchemaVersion
		{
            get { return DataService.GetSchema("aspnet_SchemaVersions", "Peerfx"); }
		}
        
		public static TableSchema.Table AspnetUser
		{
            get { return DataService.GetSchema("aspnet_Users", "Peerfx"); }
		}
        
		public static TableSchema.Table AspnetWebEventEvent
		{
            get { return DataService.GetSchema("aspnet_WebEvent_Events", "Peerfx"); }
		}
        
		public static TableSchema.Table BankAccountFieldType
		{
            get { return DataService.GetSchema("Bank_Account_Field_Type", "Peerfx"); }
		}
        
		public static TableSchema.Table BankAccountLocalRequiredField
		{
            get { return DataService.GetSchema("Bank_Account_Local_Required_Fields", "Peerfx"); }
		}
        
		public static TableSchema.Table BankAccount
		{
            get { return DataService.GetSchema("Bank_Accounts", "Peerfx"); }
		}
        
		public static TableSchema.Table CurrencyCloudSettlement
		{
            get { return DataService.GetSchema("CurrencyCloud_Settlements", "Peerfx"); }
		}
        
		public static TableSchema.Table CurrencyCloudTrade
		{
            get { return DataService.GetSchema("CurrencyCloud_Trades", "Peerfx"); }
		}
        
		public static TableSchema.Table CurrencyCloudTradesError
		{
            get { return DataService.GetSchema("CurrencyCloud_Trades_Errors", "Peerfx"); }
		}
        
		public static TableSchema.Table EmbeeObject
		{
            get { return DataService.GetSchema("Embee_Objects", "Peerfx"); }
		}
        
		public static TableSchema.Table EmbeeCatalog
		{
            get { return DataService.GetSchema("EmbeeCatalog", "Peerfx"); }
		}
        
		public static TableSchema.Table ErrorLog
		{
            get { return DataService.GetSchema("Error_Log", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoCountryCodeList
		{
            get { return DataService.GetSchema("Info_Country_Code_List", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoCountryList
		{
            get { return DataService.GetSchema("Info_Country_List", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoCurrency
		{
            get { return DataService.GetSchema("Info_Currencies", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoCurrencyCloudToken
		{
            get { return DataService.GetSchema("Info_CurrencyCloud_Tokens", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoFeeType
		{
            get { return DataService.GetSchema("Info_Fee_Types", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoOrganizationType
		{
            get { return DataService.GetSchema("Info_Organization_Type", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoOrganization
		{
            get { return DataService.GetSchema("Info_Organizations", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoPhoneType
		{
            get { return DataService.GetSchema("Info_Phone_Type", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoSecurityQuestion
		{
            get { return DataService.GetSchema("Info_Security_Questions", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoVerificationMethod
		{
            get { return DataService.GetSchema("Info_Verification_Methods", "Peerfx"); }
		}
        
		public static TableSchema.Table PaymentObjectType
		{
            get { return DataService.GetSchema("Payment_Object_Types", "Peerfx"); }
		}
        
		public static TableSchema.Table PaymentObject
		{
            get { return DataService.GetSchema("Payment_Objects", "Peerfx"); }
		}
        
		public static TableSchema.Table PaymentSchedule
		{
            get { return DataService.GetSchema("Payment_Schedule", "Peerfx"); }
		}
        
		public static TableSchema.Table PaymentStatus
		{
            get { return DataService.GetSchema("Payment_Status", "Peerfx"); }
		}
        
		public static TableSchema.Table PaymentTimingType
		{
            get { return DataService.GetSchema("Payment_Timing_Types", "Peerfx"); }
		}
        
		public static TableSchema.Table Payment
		{
            get { return DataService.GetSchema("Payments", "Peerfx"); }
		}
        
		public static TableSchema.Table PurposeType
		{
            get { return DataService.GetSchema("Purpose_Types", "Peerfx"); }
		}
        
		public static TableSchema.Table Quote
		{
            get { return DataService.GetSchema("Quotes", "Peerfx"); }
		}
        
		public static TableSchema.Table Recipient
		{
            get { return DataService.GetSchema("Recipients", "Peerfx"); }
		}
        
		public static TableSchema.Table ScheduledTask
		{
            get { return DataService.GetSchema("Scheduled_Task", "Peerfx"); }
		}
        
		public static TableSchema.Table ScheduledTaskType
		{
            get { return DataService.GetSchema("Scheduled_Task_Types", "Peerfx"); }
		}
        
		public static TableSchema.Table TransactionFee
		{
            get { return DataService.GetSchema("Transaction_Fees", "Peerfx"); }
		}
        
		public static TableSchema.Table TransactionStatus
		{
            get { return DataService.GetSchema("Transaction_Status", "Peerfx"); }
		}
        
		public static TableSchema.Table TransactionsExternal
		{
            get { return DataService.GetSchema("Transactions_External", "Peerfx"); }
		}
        
		public static TableSchema.Table TransactionsInternal
		{
            get { return DataService.GetSchema("Transactions_Internal", "Peerfx"); }
		}
        
		public static TableSchema.Table TreasuryType
		{
            get { return DataService.GetSchema("Treasury_Type", "Peerfx"); }
		}
        
		public static TableSchema.Table UserFacebook
		{
            get { return DataService.GetSchema("User_Facebook", "Peerfx"); }
		}
        
		public static TableSchema.Table UserRecipient
		{
            get { return DataService.GetSchema("User_Recipients", "Peerfx"); }
		}
        
		public static TableSchema.Table UserStatus
		{
            get { return DataService.GetSchema("User_Statuses", "Peerfx"); }
		}
        
		public static TableSchema.Table UserType
		{
            get { return DataService.GetSchema("User_Types", "Peerfx"); }
		}
        
		public static TableSchema.Table User
		{
            get { return DataService.GetSchema("Users", "Peerfx"); }
		}
        
		public static TableSchema.Table UsersBancbox
		{
            get { return DataService.GetSchema("Users_Bancbox", "Peerfx"); }
		}
        
		public static TableSchema.Table UsersInfo
		{
            get { return DataService.GetSchema("Users_Info", "Peerfx"); }
		}
        
		public static TableSchema.Table UsersSecurityAnswer
		{
            get { return DataService.GetSchema("Users_Security_Answers", "Peerfx"); }
		}
        
		public static TableSchema.Table UsersVerified
		{
            get { return DataService.GetSchema("Users_Verified", "Peerfx"); }
		}
        
		public static TableSchema.Table VerificationMethod
		{
            get { return DataService.GetSchema("Verification_Methods", "Peerfx"); }
		}
        
	
    }
    #endregion
    #region View Struct
    public partial struct Views 
    {
		
		public static readonly string VwAspnetApplication = @"vw_aspnet_Applications";
        
		public static readonly string VwAspnetUser = @"vw_aspnet_Users";
        
		public static readonly string VwBankAccountsBancbox = @"vw_Bank_Accounts_Bancbox";
        
		public static readonly string VwBankAccountsSystem = @"vw_Bank_Accounts_System";
        
		public static readonly string VwBankAccountsUser = @"vw_Bank_Accounts_Users";
        
		public static readonly string VwCurrency = @"vw_currencies";
        
		public static readonly string VwCurrencyPairing = @"vw_currency_pairings";
        
		public static readonly string VwCurrencyCloudSettlement = @"vw_CurrencyCloud_Settlements";
        
		public static readonly string VwCurrencyCloudTrade = @"vw_CurrencyCloud_Trades";
        
		public static readonly string VwCurrencyCloudTradesError = @"vw_CurrencyCloud_Trades_Errors";
        
		public static readonly string VwInfoBank = @"vw_info_banks";
        
		public static readonly string VwPayment = @"vw_Payments";
        
		public static readonly string VwTransactionsAll = @"vw_Transactions_All";
        
		public static readonly string VwTransactionsExternal = @"vw_Transactions_External";
        
		public static readonly string VwUsersInfo = @"vw_Users_Info";
        
		public static readonly string VwVerification = @"vw_Verification";
        
    }
    #endregion
    
    #region Query Factories
	public static partial class DB
	{
        public static DataProvider _provider = DataService.Providers["Peerfx"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository 
        {
            get 
            {
                if (_repository == null)
                    return new SubSonicRepository(_provider);
                return _repository; 
            }
            set { _repository = value; }
        }
        public static Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new()
	    {
            return Repository.SelectAllColumnsFrom<T>();
	    }
	    public static Select Select()
	    {
            return Repository.Select();
	    }
	    
		public static Select Select(params string[] columns)
		{
            return Repository.Select(columns);
        }
	    
		public static Select Select(params Aggregate[] aggregates)
		{
            return Repository.Select(aggregates);
        }
   
	    public static Update Update<T>() where T : RecordBase<T>, new()
	    {
            return Repository.Update<T>();
	    }
	    
	    public static Insert Insert()
	    {
            return Repository.Insert();
	    }
	    
	    public static Delete Delete()
	    {
            return Repository.Delete();
	    }
	    
	    public static InlineQuery Query()
	    {
            return Repository.Query();
	    }
	    	    
	    
	}
    #endregion
    
}
#region Databases
public partial struct Databases 
{
	
	public static readonly string Peerfx = @"Peerfx";
    
}
#endregion