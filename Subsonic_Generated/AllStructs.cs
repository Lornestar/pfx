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
		
		public static readonly string InfoCountryCodeList = @"Info_Country_Code_List";
        
		public static readonly string InfoCountryList = @"Info_Country_List";
        
		public static readonly string InfoPhoneType = @"Info_Phone_Type";
        
		public static readonly string InfoReferralQuestion = @"Info_Referral_Questions";
        
		public static readonly string UserStatus = @"User_Statuses";
        
		public static readonly string User = @"Users";
        
		public static readonly string UsersInfo = @"Users_Info";
        
		public static readonly string UsersSecurityAnswer = @"Users_Security_Answers";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table InfoCountryCodeList
		{
            get { return DataService.GetSchema("Info_Country_Code_List", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoCountryList
		{
            get { return DataService.GetSchema("Info_Country_List", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoPhoneType
		{
            get { return DataService.GetSchema("Info_Phone_Type", "Peerfx"); }
		}
        
		public static TableSchema.Table InfoReferralQuestion
		{
            get { return DataService.GetSchema("Info_Referral_Questions", "Peerfx"); }
		}
        
		public static TableSchema.Table UserStatus
		{
            get { return DataService.GetSchema("User_Statuses", "Peerfx"); }
		}
        
		public static TableSchema.Table User
		{
            get { return DataService.GetSchema("Users", "Peerfx"); }
		}
        
		public static TableSchema.Table UsersInfo
		{
            get { return DataService.GetSchema("Users_Info", "Peerfx"); }
		}
        
		public static TableSchema.Table UsersSecurityAnswer
		{
            get { return DataService.GetSchema("Users_Security_Answers", "Peerfx"); }
		}
        
	
    }
    #endregion
    #region View Struct
    public partial struct Views 
    {
		
		public static readonly string VwUsersInfo = @"vw_Users_Info";
        
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