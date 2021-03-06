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
    /// Controller class for Users_Security_Answers
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UsersSecurityAnswerController
    {
        // Preload our schema..
        UsersSecurityAnswer thisSchemaLoad = new UsersSecurityAnswer();
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
        public UsersSecurityAnswerCollection FetchAll()
        {
            UsersSecurityAnswerCollection coll = new UsersSecurityAnswerCollection();
            Query qry = new Query(UsersSecurityAnswer.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UsersSecurityAnswerCollection FetchByID(object UsersSecurityAnswersKey)
        {
            UsersSecurityAnswerCollection coll = new UsersSecurityAnswerCollection().Where("users_security_answers_key", UsersSecurityAnswersKey).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UsersSecurityAnswerCollection FetchByQuery(Query qry)
        {
            UsersSecurityAnswerCollection coll = new UsersSecurityAnswerCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UsersSecurityAnswersKey)
        {
            return (UsersSecurityAnswer.Delete(UsersSecurityAnswersKey) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UsersSecurityAnswersKey)
        {
            return (UsersSecurityAnswer.Destroy(UsersSecurityAnswersKey) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int UserKey,int Question,string Answer,DateTime DateCreated,DateTime LastChanged)
	    {
		    UsersSecurityAnswer item = new UsersSecurityAnswer();
		    
            item.UserKey = UserKey;
            
            item.Question = Question;
            
            item.Answer = Answer;
            
            item.DateCreated = DateCreated;
            
            item.LastChanged = LastChanged;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int UsersSecurityAnswersKey,int UserKey,int Question,string Answer,DateTime DateCreated,DateTime LastChanged)
	    {
		    UsersSecurityAnswer item = new UsersSecurityAnswer();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.UsersSecurityAnswersKey = UsersSecurityAnswersKey;
				
			item.UserKey = UserKey;
				
			item.Question = Question;
				
			item.Answer = Answer;
				
			item.DateCreated = DateCreated;
				
			item.LastChanged = LastChanged;
				
	        item.Save(UserName);
	    }
    }
}
