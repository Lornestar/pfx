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
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the Delete_Users_Security_Answers Procedure
        /// </summary>
        public static StoredProcedure DeleteUsersSecurityAnswers(int? userkey)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Delete_Users_Security_Answers", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@user_key", userkey, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Bank_Accounts Procedure
        /// </summary>
        public static StoredProcedure UpdateBankAccounts(int? bankaccountkey, int? userkey, int? currencykey, int? organizationkey, string bankaccountdescription, int? userkeyupdated, string ipaddress, string accountnumber, string IBAN, string BIC, string ABArouting, string firstname, string lastname, string businessname, int? bankaccountkeyreturn)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Bank_Accounts", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@bank_account_key", bankaccountkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@user_key", userkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@currency_key", currencykey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@organization_key", organizationkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@bank_account_description", bankaccountdescription, DbType.String, null, null);
        	
            sp.Command.AddParameter("@user_key_updated", userkeyupdated, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@ip_address", ipaddress, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@account_number", accountnumber, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@IBAN", IBAN, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@BIC", BIC, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@ABArouting", ABArouting, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@first_name", firstname, DbType.String, null, null);
        	
            sp.Command.AddParameter("@last_name", lastname, DbType.String, null, null);
        	
            sp.Command.AddParameter("@business_name", businessname, DbType.String, null, null);
        	
            sp.Command.AddOutputParameter("@bank_account_key_return", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Info_CurrencyCloud_Tokens Procedure
        /// </summary>
        public static StoredProcedure UpdateInfoCurrencyCloudTokens(int? cctokenkey, string cctoken)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Info_CurrencyCloud_Tokens", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@cctokenkey", cctokenkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@cctoken", cctoken, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Payment_Objects Procedure
        /// </summary>
        public static StoredProcedure UpdatePaymentObjects(long? paymentobjectkey, int? paymentobjecttype, int? objectaccountkey, int? paymentobjectkeyreturn)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Payment_Objects", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@payment_object_key", paymentobjectkey, DbType.Int64, 0, 19);
        	
            sp.Command.AddParameter("@payment_object_type", paymentobjecttype, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@object_account_key", objectaccountkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddOutputParameter("@payment_object_key_return", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Payment_Status Procedure
        /// </summary>
        public static StoredProcedure UpdatePaymentStatus(int? paymentskey, int? paymentstatus)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Payment_Status", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@payments_key", paymentskey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@payment_status", paymentstatus, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Payments Procedure
        /// </summary>
        public static StoredProcedure UpdatePayments(int? paymentskey, int? quotekey, int? paymentstatus, int? paymentskeyreturn, int? requestoruserkey, string paymentdescription)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Payments", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@payments_key", paymentskey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@quote_key", quotekey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@payment_status", paymentstatus, DbType.Int32, 0, 10);
        	
            sp.Command.AddOutputParameter("@payments_key_return", DbType.Int32, 0, 10);
            
            sp.Command.AddParameter("@requestor_user_key", requestoruserkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@payment_description", paymentdescription, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Process_Deposit Procedure
        /// </summary>
        public static StoredProcedure UpdateProcessDeposit(int? txexternalkey, int? purposetype, int? objectkey)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Process_Deposit", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@tx_external_key", txexternalkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@purpose_type", purposetype, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@object_key", objectkey, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Quotes Procedure
        /// </summary>
        public static StoredProcedure UpdateQuotes(int? quoteskey, decimal? sellamount, int? sellcurrency, decimal? buyamount, int? buycurrency, decimal? rate, decimal? servicefee, DateTime? promiseddeliverydate, DateTime? actualdeliverydate, int? quoteskeyreturn)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Quotes", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@quotes_key", quoteskey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@sell_amount", sellamount, DbType.Currency, 4, 19);
        	
            sp.Command.AddParameter("@sell_currency", sellcurrency, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@buy_amount", buyamount, DbType.Currency, 4, 19);
        	
            sp.Command.AddParameter("@buy_currency", buycurrency, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@rate", rate, DbType.Decimal, 4, 10);
        	
            sp.Command.AddParameter("@service_fee", servicefee, DbType.Currency, 4, 19);
        	
            sp.Command.AddParameter("@promised_delivery_date", promiseddeliverydate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@actual_delivery_date", actualdeliverydate, DbType.DateTime, null, null);
        	
            sp.Command.AddOutputParameter("@quotes_key_return", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Transaction_External_Purpose Procedure
        /// </summary>
        public static StoredProcedure UpdateTransactionExternalPurpose(int? txexternalkey, int? purposetype, int? objectkey)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Transaction_External_Purpose", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@tx_external_key", txexternalkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@purpose_type", purposetype, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@object_key", objectkey, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Transaction_External_Status Procedure
        /// </summary>
        public static StoredProcedure UpdateTransactionExternalStatus(int? txexternalkey, int? txexternalstatus, string ipaddress, int? userkeyupdated)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Transaction_External_Status", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@tx_external_key", txexternalkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tx_external_status", txexternalstatus, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@ip_address", ipaddress, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@user_key_updated", userkeyupdated, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Transaction_Fees Procedure
        /// </summary>
        public static StoredProcedure UpdateTransactionFees(int? txfeeskey, int? txtype, int? txkey, decimal? amount, int? currency, string description, int? feetype, int? txfeeskeyreturn)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Transaction_Fees", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@tx_fees_key", txfeeskey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tx_type", txtype, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tx_key", txkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@amount", amount, DbType.Currency, 4, 19);
        	
            sp.Command.AddParameter("@currency", currency, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@description", description, DbType.String, null, null);
        	
            sp.Command.AddParameter("@fee_type", feetype, DbType.Int32, 0, 10);
        	
            sp.Command.AddOutputParameter("@tx_fees_key_return", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Transactions_External Procedure
        /// </summary>
        public static StoredProcedure UpdateTransactionsExternal(int? txexternalkey, int? txexternalstatus, int? currency, decimal? amount, long? paymentobjectsender, long? paymentobjectreceiver, string ipaddress, int? userkeyupdated, string txexternaldescription, string bankreference, int? txexternalkeyreturn)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Transactions_External", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@tx_external_key", txexternalkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tx_external_status", txexternalstatus, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@currency", currency, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@amount", amount, DbType.Currency, 4, 19);
        	
            sp.Command.AddParameter("@payment_object_sender", paymentobjectsender, DbType.Int64, 0, 19);
        	
            sp.Command.AddParameter("@payment_object_receiver", paymentobjectreceiver, DbType.Int64, 0, 19);
        	
            sp.Command.AddParameter("@ip_address", ipaddress, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@user_key_updated", userkeyupdated, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tx_external_description", txexternaldescription, DbType.String, null, null);
        	
            sp.Command.AddParameter("@bank_reference", bankreference, DbType.AnsiString, null, null);
        	
            sp.Command.AddOutputParameter("@tx_external_key_return", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Users Procedure
        /// </summary>
        public static StoredProcedure UpdateUsers(int? userkey, string title, string firstname, string middlename, string lastname, DateTime? dob, int? countryresidence, string email, string ipaddress, int? userkeyreturn)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Users", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@user_key", userkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@title", title, DbType.String, null, null);
        	
            sp.Command.AddParameter("@first_name", firstname, DbType.String, null, null);
        	
            sp.Command.AddParameter("@middle_name", middlename, DbType.String, null, null);
        	
            sp.Command.AddParameter("@last_name", lastname, DbType.String, null, null);
        	
            sp.Command.AddParameter("@dob", dob, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@country_residence", countryresidence, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@email", email, DbType.String, null, null);
        	
            sp.Command.AddParameter("@ip_address", ipaddress, DbType.String, null, null);
        	
            sp.Command.AddOutputParameter("@user_key_return", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Users_Info Procedure
        /// </summary>
        public static StoredProcedure UpdateUsersInfo(int? userkey, string address1, string address2, string city, string state, int? country, string postalcode, int? phonecountrycode1, int? phonetype1, string phonenumber1, int? phonecountrycode2, int? phonetype2, string phonenumber2, int? identitynationality, string occupation, string passportnumber)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Users_Info", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@user_key", userkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@address1", address1, DbType.String, null, null);
        	
            sp.Command.AddParameter("@address2", address2, DbType.String, null, null);
        	
            sp.Command.AddParameter("@city", city, DbType.String, null, null);
        	
            sp.Command.AddParameter("@state", state, DbType.String, null, null);
        	
            sp.Command.AddParameter("@country", country, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@postalcode", postalcode, DbType.String, null, null);
        	
            sp.Command.AddParameter("@phonecountrycode1", phonecountrycode1, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@phonetype1", phonetype1, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@phonenumber1", phonenumber1, DbType.String, null, null);
        	
            sp.Command.AddParameter("@phonecountrycode2", phonecountrycode2, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@phonetype2", phonetype2, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@phonenumber2", phonenumber2, DbType.String, null, null);
        	
            sp.Command.AddParameter("@identitynationality", identitynationality, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@occupation", occupation, DbType.String, null, null);
        	
            sp.Command.AddParameter("@passportnumber", passportnumber, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Users_Info_Signup_Tab3 Procedure
        /// </summary>
        public static StoredProcedure UpdateUsersInfoSignupTab3(int? userkey, string username, string password)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Users_Info_Signup_Tab3", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@user_key", userkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@username", username, DbType.String, null, null);
        	
            sp.Command.AddParameter("@password", password, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Users_Security_Answers Procedure
        /// </summary>
        public static StoredProcedure UpdateUsersSecurityAnswers(int? userkey, int? question, string answer)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Users_Security_Answers", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@user_key", userkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@question", question, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@answer", answer, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Update_Verification_Email Procedure
        /// </summary>
        public static StoredProcedure UpdateVerificationEmail(int? userkey, bool? isverified, string ipaddress, string uniquekey)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Update_Verification_Email", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@user_key", userkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@isverified", isverified, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@ip_address", ipaddress, DbType.String, null, null);
        	
            sp.Command.AddParameter("@unique_key", uniquekey, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Admin_Deposits Procedure
        /// </summary>
        public static StoredProcedure ViewAdminDeposits(bool? isprocessed)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Admin_Deposits", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@isprocessed", isprocessed, DbType.Boolean, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Bank_Accounts_Specific Procedure
        /// </summary>
        public static StoredProcedure ViewBankAccountsSpecific(int? bankaccountkey)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Bank_Accounts_Specific", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@bankaccountkey", bankaccountkey, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Bank_Accounts_Users Procedure
        /// </summary>
        public static StoredProcedure ViewBankAccountsUsers()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Bank_Accounts_Users", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Info_Banks Procedure
        /// </summary>
        public static StoredProcedure ViewInfoBanks()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Info_Banks", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Info_Country_Code_List Procedure
        /// </summary>
        public static StoredProcedure ViewInfoCountryCodeList()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Info_Country_Code_List", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Info_Country_List Procedure
        /// </summary>
        public static StoredProcedure ViewInfoCountryList()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Info_Country_List", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Info_Currencies Procedure
        /// </summary>
        public static StoredProcedure ViewInfoCurrencies()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Info_Currencies", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Info_Currencies_CanBuy Procedure
        /// </summary>
        public static StoredProcedure ViewInfoCurrenciesCanBuy()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Info_Currencies_CanBuy", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Info_Currencies_CanSell Procedure
        /// </summary>
        public static StoredProcedure ViewInfoCurrenciesCanSell()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Info_Currencies_CanSell", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Info_Currencies_Specific Procedure
        /// </summary>
        public static StoredProcedure ViewInfoCurrenciesSpecific(int? CurrencyKey)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Info_Currencies_Specific", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@Currency_Key", CurrencyKey, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Info_CurrencyCloud_Tokens Procedure
        /// </summary>
        public static StoredProcedure ViewInfoCurrencyCloudTokens()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Info_CurrencyCloud_Tokens", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Info_Fee_Types Procedure
        /// </summary>
        public static StoredProcedure ViewInfoFeeTypes(int? currency1, int? currency2)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Info_Fee_Types", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@currency1", currency1, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@currency2", currency2, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Info_Phone_Type Procedure
        /// </summary>
        public static StoredProcedure ViewInfoPhoneType()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Info_Phone_Type", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Info_Security_Questions Procedure
        /// </summary>
        public static StoredProcedure ViewInfoSecurityQuestions()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Info_Security_Questions", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Payment_Object_Bank_Account Procedure
        /// </summary>
        public static StoredProcedure ViewPaymentObjectBankAccount(int? BankAccountkey)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Payment_Object_Bank_Account", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@Bank_Account_key", BankAccountkey, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Payment_Schedule Procedure
        /// </summary>
        public static StoredProcedure ViewPaymentSchedule()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Payment_Schedule", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Payments_Confirmed Procedure
        /// </summary>
        public static StoredProcedure ViewPaymentsConfirmed()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Payments_Confirmed", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_System_Bank_Accounts Procedure
        /// </summary>
        public static StoredProcedure ViewSystemBankAccounts()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_System_Bank_Accounts", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the view_Transaction_External Procedure
        /// </summary>
        public static StoredProcedure ViewTransactionExternal()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("view_Transaction_External", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Transaction_Fees Procedure
        /// </summary>
        public static StoredProcedure ViewTransactionFees(int? txtype)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Transaction_Fees", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@tx_type", txtype, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Transaction_Fees_txkey Procedure
        /// </summary>
        public static StoredProcedure ViewTransactionFeesTxkey(int? txtype, int? txkey)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Transaction_Fees_txkey", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@tx_type", txtype, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tx_key", txkey, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Users_Admin Procedure
        /// </summary>
        public static StoredProcedure ViewUsersAdmin()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Users_Admin", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Users_All Procedure
        /// </summary>
        public static StoredProcedure ViewUsersAll()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Users_All", DataService.GetInstance("Peerfx"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Users_Email Procedure
        /// </summary>
        public static StoredProcedure ViewUsersEmail(string Email)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Users_Email", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@Email", Email, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Users_Info Procedure
        /// </summary>
        public static StoredProcedure ViewUsersInfo(int? userkey)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Users_Info", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@user_key", userkey, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Users_Security_Answers Procedure
        /// </summary>
        public static StoredProcedure ViewUsersSecurityAnswers(int? userkey)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Users_Security_Answers", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@user_key", userkey, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Users_Verified Procedure
        /// </summary>
        public static StoredProcedure ViewUsersVerified(int? userkey, int? verificationmethodskey)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Users_Verified", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@user_key", userkey, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@verification_methods_key", verificationmethodskey, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the View_Users_Verified_byCode Procedure
        /// </summary>
        public static StoredProcedure ViewUsersVerifiedByCode(string uniquekey, int? verificationmethodskey)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("View_Users_Verified_byCode", DataService.GetInstance("Peerfx"), "dbo");
        	
            sp.Command.AddParameter("@unique_key", uniquekey, DbType.String, null, null);
        	
            sp.Command.AddParameter("@verification_methods_key", verificationmethodskey, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
    }
    
}
