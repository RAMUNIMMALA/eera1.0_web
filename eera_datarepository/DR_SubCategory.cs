using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eera_model;
using System.Data;

namespace eera_datarepository
{
    public class DR_SubCategory : RepositoryBase
    {
        SubCategory _Subcategory = null;
        List<SubCategory> lstSubCategory = null;

        // Method For Fetch SubCategory Data From Database.


        public List<SubCategory> getSubCategoryList(ref int Total)
        {
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[] { };
                dsResultSet = DB_UTILITY.RunSP("USP_FETCHTBL_SUBCATEGORY", arrParameter);
                if (ValidateResultSet(dsResultSet))
                {
                    Total = Convert.ToInt32(dsResultSet.Tables[0].Rows[0][0]);
                    lstSubCategory = OBJECT_UTILITY.GetConvertCollection<SubCategory>(dsResultSet.Tables[1]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstSubCategory;
        }

        //Method For Insert SubCategory Data Into Database.

        public bool CreateSubCategory(SubCategory Subcategory)
        {
            bool result = false;
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[]{
                    DB_UTILITY.CreateParameter("@iTitle", DbType.String, ParameterDirection.Input, Subcategory.Title ),
                    DB_UTILITY.CreateParameter("@iDescription", DbType.String, ParameterDirection.Input, Subcategory.Details ),
                    DB_UTILITY.CreateParameter("@iBannerImage", DbType.String, ParameterDirection.Input, Subcategory.HomeImage == null ? "" : Subcategory.HomeImage ),
                    DB_UTILITY.CreateParameter("@iBannerImageAccess", DbType.String, ParameterDirection.Input, Subcategory.HomeImageAccess ),
                    DB_UTILITY.CreateParameter("@iHomePageAccess", DbType.String, ParameterDirection.Input, Subcategory.HomePageAccess ),
                    DB_UTILITY.CreateParameter("@iStatus", DbType.String, ParameterDirection.Input, "1" )
                };
                dsResultSet = DB_UTILITY.RunSP("USP_INSERTTBL_SUBCATEGORY", arrParameter);
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
    }
}


