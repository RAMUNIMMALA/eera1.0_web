using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eera_model;
using System.Data;

namespace eera_datarepository
{
    public class DR_Category : RepositoryBase
    {
        Category _category = null;
        List<Category> lstCategory = null;

      

        public List<Category> getCategoryList(ref int Total)
        {
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[] { };
                dsResultSet = DB_UTILITY.RunSP("USP_FETCHTBL_CATEGORY", arrParameter);
                if (ValidateResultSet(dsResultSet))
                {
                    Total = Convert.ToInt32(dsResultSet.Tables[0].Rows[0][0]);
                    lstCategory = OBJECT_UTILITY.GetConvertCollection<Category>(dsResultSet.Tables[1]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCategory;
        }

        //Method For Insert Category Data Into Database.

        public bool CreateCategory(Category category)
        {
            bool result = false;
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[]{
                    DB_UTILITY.CreateParameter("@iTitle", DbType.String, ParameterDirection.Input, category.Title ),
                    DB_UTILITY.CreateParameter("@iDescription", DbType.String, ParameterDirection.Input, category.Details ),
                    DB_UTILITY.CreateParameter("@iBannerImage", DbType.String, ParameterDirection.Input, category.HomeImage == null ? "" : category.HomeImage ),
                    DB_UTILITY.CreateParameter("@iBannerImageAccess", DbType.String, ParameterDirection.Input, category.HomeImageAccess ),
                    DB_UTILITY.CreateParameter("@iHomePageAccess", DbType.String, ParameterDirection.Input, category.HomePageAccess ),
                    DB_UTILITY.CreateParameter("@iStatus", DbType.String, ParameterDirection.Input, "1" )
                };
                dsResultSet = DB_UTILITY.RunSP("USP_INSERTTBL_CATEGORY", arrParameter);
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
