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
	/// Strongly-typed collection for the UsersBancbox class.
	/// </summary>
    [Serializable]
	public partial class UsersBancboxCollection : ActiveList<UsersBancbox, UsersBancboxCollection>
	{	   
		public UsersBancboxCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>UsersBancboxCollection</returns>
		public UsersBancboxCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                UsersBancbox o = this[i];
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
	/// This is an ActiveRecord class which wraps the Users_Bancbox table.
	/// </summary>
	[Serializable]
	public partial class UsersBancbox : ActiveRecord<UsersBancbox>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public UsersBancbox()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public UsersBancbox(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public UsersBancbox(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public UsersBancbox(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Users_Bancbox", TableType.Table, DataService.GetInstance("Peerfx"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarUserKey = new TableSchema.TableColumn(schema);
				colvarUserKey.ColumnName = "user_key";
				colvarUserKey.DataType = DbType.Int32;
				colvarUserKey.MaxLength = 0;
				colvarUserKey.AutoIncrement = false;
				colvarUserKey.IsNullable = false;
				colvarUserKey.IsPrimaryKey = true;
				colvarUserKey.IsForeignKey = false;
				colvarUserKey.IsReadOnly = false;
				colvarUserKey.DefaultSetting = @"";
				colvarUserKey.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserKey);
				
				TableSchema.TableColumn colvarClientId = new TableSchema.TableColumn(schema);
				colvarClientId.ColumnName = "client_id";
				colvarClientId.DataType = DbType.Int32;
				colvarClientId.MaxLength = 0;
				colvarClientId.AutoIncrement = false;
				colvarClientId.IsNullable = true;
				colvarClientId.IsPrimaryKey = false;
				colvarClientId.IsForeignKey = false;
				colvarClientId.IsReadOnly = false;
				colvarClientId.DefaultSetting = @"";
				colvarClientId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClientId);
				
				TableSchema.TableColumn colvarClientStatus = new TableSchema.TableColumn(schema);
				colvarClientStatus.ColumnName = "client_status";
				colvarClientStatus.DataType = DbType.AnsiString;
				colvarClientStatus.MaxLength = 50;
				colvarClientStatus.AutoIncrement = false;
				colvarClientStatus.IsNullable = true;
				colvarClientStatus.IsPrimaryKey = false;
				colvarClientStatus.IsForeignKey = false;
				colvarClientStatus.IsReadOnly = false;
				colvarClientStatus.DefaultSetting = @"";
				colvarClientStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClientStatus);
				
				TableSchema.TableColumn colvarCipStatus = new TableSchema.TableColumn(schema);
				colvarCipStatus.ColumnName = "cip_status";
				colvarCipStatus.DataType = DbType.AnsiString;
				colvarCipStatus.MaxLength = 50;
				colvarCipStatus.AutoIncrement = false;
				colvarCipStatus.IsNullable = true;
				colvarCipStatus.IsPrimaryKey = false;
				colvarCipStatus.IsForeignKey = false;
				colvarCipStatus.IsReadOnly = false;
				colvarCipStatus.DefaultSetting = @"";
				colvarCipStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCipStatus);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Peerfx"].AddSchema("Users_Bancbox",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("UserKey")]
		[Bindable(true)]
		public int UserKey 
		{
			get { return GetColumnValue<int>(Columns.UserKey); }
			set { SetColumnValue(Columns.UserKey, value); }
		}
		  
		[XmlAttribute("ClientId")]
		[Bindable(true)]
		public int? ClientId 
		{
			get { return GetColumnValue<int?>(Columns.ClientId); }
			set { SetColumnValue(Columns.ClientId, value); }
		}
		  
		[XmlAttribute("ClientStatus")]
		[Bindable(true)]
		public string ClientStatus 
		{
			get { return GetColumnValue<string>(Columns.ClientStatus); }
			set { SetColumnValue(Columns.ClientStatus, value); }
		}
		  
		[XmlAttribute("CipStatus")]
		[Bindable(true)]
		public string CipStatus 
		{
			get { return GetColumnValue<string>(Columns.CipStatus); }
			set { SetColumnValue(Columns.CipStatus, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varUserKey,int? varClientId,string varClientStatus,string varCipStatus)
		{
			UsersBancbox item = new UsersBancbox();
			
			item.UserKey = varUserKey;
			
			item.ClientId = varClientId;
			
			item.ClientStatus = varClientStatus;
			
			item.CipStatus = varCipStatus;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varUserKey,int? varClientId,string varClientStatus,string varCipStatus)
		{
			UsersBancbox item = new UsersBancbox();
			
				item.UserKey = varUserKey;
			
				item.ClientId = varClientId;
			
				item.ClientStatus = varClientStatus;
			
				item.CipStatus = varCipStatus;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn UserKeyColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ClientIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ClientStatusColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CipStatusColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string UserKey = @"user_key";
			 public static string ClientId = @"client_id";
			 public static string ClientStatus = @"client_status";
			 public static string CipStatus = @"cip_status";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
