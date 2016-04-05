//Using statements @1-2F3A9EB8
namespace IssueManager.Security
{
	using System;
	using System.Data;
	using System.Configuration;
	using System.Web;
	using System.Web.Security;
	using IssueManager.Data;
	using IssueManager.Configuration;

//End Using statements

//MembershipProvider class @2b-03BCDFE5
public class CCSMembershipProvider:MembershipProvider   
{
    private string connName;
    private string tableName;
    private string userIdField;
    private string userLoginField;
    private string userPasswordField;
    private string userGroupField;
	private string userIdSessionVariable;
	private string userGroupSessionVariable;
	private string userLoginSessionVariable;

	public CCSMembershipProvider()
	{
	}

    public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
    {
        connName = config["connectionString"];
		tableName = config["tableName"];
	    userIdField = config["userIdField"];
		userLoginField = config["userLoginField"];
	    userPasswordField = config["userPasswordField"];
		userGroupField = config["userGroupField"];
		userIdSessionVariable = config["userIdSessionVariable"];
		userGroupSessionVariable = config["userGroupSessionVariable"];
		userLoginSessionVariable = config["userLoginSessionVariable"];

		base.Initialize(name, config);
    }

    public override string ApplicationName
    {
        get
        {
            return HttpContext.Current.Request.ApplicationPath;
        }
        set
        {
            string a = value;
        }
    }

    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
       
        DataAccessObject dao = Settings.GetConnection(connName);
        string Sql = "insert into "+tableName+" ("+userLoginField+","+userPasswordField+") values(" + dao.ToSql(username, FieldType.Text) + "," + dao.ToSql(password,FieldType.Text) + ")";
        dao.ExecuteNonQuery(Sql);
        Sql = "SELECT "+userIdField+" FROM "+tableName+" WHERE "+userLoginField+"=" + dao.ToSql(username, FieldType.Text) + " AND "+userPasswordField+"=" + dao.ToSql(password, FieldType.Text);
        int id = (int)dao.ExecuteScalar(Sql);
        MembershipUser user = new MembershipUser("CCSMembershipProvider", username, id, null, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
        status = MembershipCreateStatus.Success;
        return user;
    }

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
        DataAccessObject dao = Settings.GetConnection(connName);
        string Sql = "delete from "+tableName+" where "+userLoginField+" = " + dao.ToSql(username, FieldType.Text);
        dao.ExecuteNonQuery(Sql);
        return true;

    }

    public override bool EnablePasswordReset
    {
        get { return false; }
    }

    public override bool EnablePasswordRetrieval
    {
        get { return false; }
    }

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
        DataAccessObject dao = Settings.GetConnection(connName);
        string Sql = "SELECT * FROM "+tableName;
        MembershipUserCollection col = new MembershipUserCollection();

        DataSet ds = dao.RunSql(Sql,pageIndex*pageSize,pageSize);
        totalRecords = ds.Tables[0].Rows.Count;
        for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
        {
            MembershipUser user = new MembershipUser("CCSMembershipProvider", ds.Tables[0].Rows[i][userLoginField].ToString(), ds.Tables[0].Rows[0][userIdField].ToString(), null, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            col.Add(user);
        }
        return col;
    }

    public override int GetNumberOfUsersOnline()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override string GetPassword(string username, string answer)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override MembershipUser GetUser(string username, bool userIsOnline)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override string GetUserNameByEmail(string email)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override int MaxInvalidPasswordAttempts
    {
        get { throw new Exception("The method or operation is not implemented."); }
    }

    public override int MinRequiredNonAlphanumericCharacters
    {
        get { throw new Exception("The method or operation is not implemented."); }
    }

    public override int MinRequiredPasswordLength
    {
        get { throw new Exception("The method or operation is not implemented."); }
    }

    public override int PasswordAttemptWindow
    {
        get { throw new Exception("The method or operation is not implemented."); }
    }

    public override MembershipPasswordFormat PasswordFormat
    {
        get { throw new Exception("The method or operation is not implemented."); }
    }

    public override string PasswordStrengthRegularExpression
    {
        get { throw new Exception("The method or operation is not implemented."); }
    }

    public override bool RequiresQuestionAndAnswer
    {
        get { throw new Exception("The method or operation is not implemented."); }
    }

    public override bool RequiresUniqueEmail
    {
        get { throw new Exception("The method or operation is not implemented."); }
    }

    public override string ResetPassword(string username, string answer)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override bool UnlockUser(string userName)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override void UpdateUser(MembershipUser user)
    {
        DataAccessObject dao = Settings.GetConnection(connName);
        string Sql = "UPDATE "+tableName+" SET "+userLoginField+" = " + dao.ToSql(user.UserName, FieldType.Text) + ")"; 

        dao.ExecuteNonQuery(Sql);
    }

    public override bool ValidateUser(string username, string password)
    {
        DataAccessObject dao = Settings.GetConnection(connName);
        string Sql = "SELECT * FROM "+tableName+" WHERE "+userLoginField+"=" + dao.ToSql(username, FieldType.Text) + " AND "+userPasswordField+"=" + dao.ToSql(password, FieldType.Text);

        DataSet ds = dao.RunSql(Sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            HttpContext.Current.Session[userIdSessionVariable] = ds.Tables[0].Rows[0][userIdField];
            if(userGroupField != null && userGroupField!="")
				HttpContext.Current.Session[userGroupSessionVariable] = ds.Tables[0].Rows[0][userGroupField].ToString(); ;
            HttpContext.Current.Session[userLoginSessionVariable] = username;
            return true;
        }


        return false;
	}

//End MembershipProvider class

	} //End MembershipProvider class @1-FCB6E20C

} //End namespace @1-FCB6E20C

