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
    /// Controller class for System_Bank_Accounts
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SystemBankAccountController
    {
        // Preload our schema..
        SystemBankAccount thisSchemaLoad = new SystemBankAccount();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public SystemBankAccountCollection FetchAll()
        {
            SystemBankAccountCollection coll = new SystemBankAccountCollection();
            Query qry = new Query(SystemBankAccount.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SystemBankAccountCollection FetchByID(object SystemBankAccountsKey)
        {
            SystemBankAccountCollection coll = new SystemBankAccountCollection().Where("system_bank_accounts_key", SystemBankAccountsKey).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SystemBankAccountCollection FetchByQuery(Query qry)
        {
            SystemBankAccountCollection coll = new SystemBankAccountCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SystemBankAccountsKey)
        {
            return (SystemBankAccount.Delete(SystemBankAccountsKey) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SystemBankAccountsKey)
        {
            return (SystemBankAccount.Destroy(SystemBankAccountsKey) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int CurrencyKey,int BankKey,string BankAccount,DateTime LastChanged,string BankAccountDescription,int UserKeyUpdated)
	    {
		    SystemBankAccount item = new SystemBankAccount();
		    
            item.CurrencyKey = CurrencyKey;
            
            item.BankKey = BankKey;
            
            item.BankAccount = BankAccount;
            
            item.LastChanged = LastChanged;
            
            item.BankAccountDescription = BankAccountDescription;
            
            item.UserKeyUpdated = UserKeyUpdated;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SystemBankAccountsKey,int CurrencyKey,int BankKey,string BankAccount,DateTime LastChanged,string BankAccountDescription,int UserKeyUpdated)
	    {
		    SystemBankAccount item = new SystemBankAccount();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SystemBankAccountsKey = SystemBankAccountsKey;
				
			item.CurrencyKey = CurrencyKey;
				
			item.BankKey = BankKey;
				
			item.BankAccount = BankAccount;
				
			item.LastChanged = LastChanged;
				
			item.BankAccountDescription = BankAccountDescription;
				
			item.UserKeyUpdated = UserKeyUpdated;
				
	        item.Save(UserName);
	    }
    }
}