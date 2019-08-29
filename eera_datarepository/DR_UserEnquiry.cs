using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using eera_model;

namespace eera_datarepository
{
    public class DR_UserEnquiry : RepositoryBase
    {

        UserEnquiry _userenquiry = null;
        List<UserEnquiry> listuserenquery = null;
        /// <summary>
        /// Description :Insert User enquirs to database
        /// Name: Girish
        /// </summary>

        public bool CreateUserEnquiry(UserEnquiry userenquiry)
        {
            bool result = false;
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[]{
                    DB_UTILITY.CreateParameter("@iUserAuthenticationCode", DbType.String, ParameterDirection.Input, userenquiry.UserAuthenticationCode),
                    DB_UTILITY.CreateParameter("@iUserName", DbType.String, ParameterDirection.Input,  userenquiry.UserName),
                    DB_UTILITY.CreateParameter("@iPhoneNumber", DbType.String, ParameterDirection.Input,  userenquiry.PhoneNumber),
                    DB_UTILITY.CreateParameter("@iEmail", DbType.String, ParameterDirection.Input, userenquiry.Email),
                    DB_UTILITY.CreateParameter("@iOption", DbType.String, ParameterDirection.Input, userenquiry.Option),
                    DB_UTILITY.CreateParameter("@iDescription", DbType.String, ParameterDirection.Input,userenquiry.Description),
                    DB_UTILITY.CreateParameter("@iStatus", DbType.String, ParameterDirection.Input, "1")
                };
                dsResultSet = DB_UTILITY.RunSP("USP_INSERTTBL_USERQUERY", arrParameter);
                if (ValidateResultSet(dsResultSet))
                {
                    result = Convert.ToBoolean(dsResultSet.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        /// <summary>
        /// Description :To get User enquirs from database
        /// Name: Girish
        /// </summary>
        public List<UserEnquiry> GetUserEnquery()
        {
            List<string> listuserenqueryinfo = new List<string>();

            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[] { };
                dsResultSet = DB_UTILITY.RunSP("USP_FETCHTBL_USERENQUERY", arrParameter);

                if (ValidateResultSet(dsResultSet))
                {
                    listuserenquery = OBJECT_UTILITY.GetConvertCollection<UserEnquiry>(dsResultSet.Tables[0]);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listuserenquery;

        }

    }

}
