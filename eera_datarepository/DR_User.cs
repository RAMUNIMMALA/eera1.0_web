using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using eera_model;

namespace eera_datarepository
{
    public class DR_User : RepositoryBase
    {
        User _user = null;

        public User verifyUserLogin(string UserMailId, string Password)
        {
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[]{
                    DB_UTILITY.CreateParameter("@iMailID", DbType.String, ParameterDirection.Input, UserMailId ),
                    DB_UTILITY.CreateParameter("@iPassword", DbType.String, ParameterDirection.Input, Password )
                };
                dsResultSet = DB_UTILITY.RunSP("USP_FETCH_USERLOGIN", arrParameter);
                if (ValidateResultSet(dsResultSet))
                {
                    _user = OBJECT_UTILITY.GetConvert<User>(dsResultSet.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

           return _user; 
        }
        public User verifyUserSigup(User userdata)
        {
            IDbDataParameter[] arrParameter = new IDbDataParameter[]{
                    DB_UTILITY.CreateParameter("@iFullName", DbType.String, ParameterDirection.Input, userdata.Name) ,
                    DB_UTILITY.CreateParameter("@iPhoneNumber", DbType.String, ParameterDirection.Input, userdata.ContactNo ),
                     DB_UTILITY.CreateParameter("@iEmail", DbType.String, ParameterDirection.Input, userdata.MailID ),
                      DB_UTILITY.CreateParameter("@iCity", DbType.String, ParameterDirection.Input,userdata.City ),
                           DB_UTILITY.CreateParameter("@iPassword", DbType.String, ParameterDirection.Input, userdata.Password),
                                DB_UTILITY.CreateParameter("@iRoleID", DbType.Int16, ParameterDirection.Input,userdata.RoleNo ),
                                DB_UTILITY.CreateParameter("@iStatus", DbType.String, ParameterDirection.Input,"1")

                };
            dsResultSet = DB_UTILITY.RunSP("USP_INSERT_USERAUTHENTICATION", arrParameter);
            if (ValidateResultSet(dsResultSet))
            {
                _user = OBJECT_UTILITY.GetConvert<User>(dsResultSet.Tables[0]);
            }

            return _user;
        }

    }
}
