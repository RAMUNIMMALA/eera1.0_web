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
    }
}
