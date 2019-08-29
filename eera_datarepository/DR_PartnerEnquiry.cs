
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using eera_model;

namespace eera_datarepository
{
    public class DR_PartnerEnquiry : RepositoryBase
    {
        List<PartnerEnquiry> listpartnerenquery = null;
        /// <summary>
        /// Description : To insert partner enquirs to database
        /// Name: Bhargav krishna
        /// </summary>
        public bool CreateEnquiry(PartnerEnquiry partnerenquiry)
        {
            bool result = false;
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[]{
                      DB_UTILITY.CreateParameter("@iUserCode", DbType.String, ParameterDirection.Input,partnerenquiry.UserCode) ,
                    DB_UTILITY.CreateParameter("@iOrganizationName", DbType.String, ParameterDirection.Input, partnerenquiry.OrganizationName) ,
                    DB_UTILITY.CreateParameter("@iPhoneNumber", DbType.String, ParameterDirection.Input, partnerenquiry.PhoneNumber) ,
                    DB_UTILITY.CreateParameter("@iEmail", DbType.String, ParameterDirection.Input, partnerenquiry.Email) ,
                    DB_UTILITY.CreateParameter("@iCity", DbType.String, ParameterDirection.Input, partnerenquiry.City ),
                    DB_UTILITY.CreateParameter("@iDescription", DbType.String, ParameterDirection.Input, partnerenquiry.Description) ,
                    DB_UTILITY.CreateParameter("@iStatus", DbType.String, ParameterDirection.Input, "1")
                };
                dsResultSet = DB_UTILITY.RunSP("USP_INSERT_PARTNERQUERY", arrParameter);
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
        /// Description : To get the partner enquirs from database
        /// Name: Bhargav krishna
        /// </summary>
        public List<PartnerEnquiry> GetPartnerEnquery()
        {

            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[] { };
                dsResultSet = DB_UTILITY.RunSP("USP_FETCHTBL_PARTNERQUERY", arrParameter);
                if (ValidateResultSet(dsResultSet))
                {
                    listpartnerenquery = OBJECT_UTILITY.GetConvertCollection<PartnerEnquiry>(dsResultSet.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listpartnerenquery;
        }
    }
}
