using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eera_model;
using System.Data;

namespace eera_datarepository
{
    public class DR_Institute : RepositoryBase
    {
        Institute _Institute = null;
        List<Institute> lstInstitute = null;

        //Method for Insert Institute Data Into Database 

        public bool CreateInstitute(Institute Institute)
        {
            bool result = false;
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[]{
                    DB_UTILITY.CreateParameter("@iTitle", DbType.String, ParameterDirection.Input, Institute.Title ),
                    DB_UTILITY.CreateParameter("@iDescription", DbType.String, ParameterDirection.Input, Institute.Details ),
                    DB_UTILITY.CreateParameter("@iBannerImage", DbType.String, ParameterDirection.Input, Institute.BannerImage == null ? "" : Institute.BannerImage ),
                    DB_UTILITY.CreateParameter("@iBannerImageAccess", DbType.String, ParameterDirection.Input, Institute.BannerImageAccess ),
                    DB_UTILITY.CreateParameter("@iSliderAccess", DbType.String, ParameterDirection.Input, Institute.SliderAccess ),
                    DB_UTILITY.CreateParameter("@iStateCode", DbType.String, ParameterDirection.Input, Institute.StateCode ),
                    DB_UTILITY.CreateParameter("@iCityCode", DbType.String, ParameterDirection.Input, Institute.CityCode ),
                    DB_UTILITY.CreateParameter("@iAreaCode", DbType.String, ParameterDirection.Input, Institute.AreaCode ),
                    DB_UTILITY.CreateParameter("@iContactNo", DbType.String, ParameterDirection.Input, Institute.ContactNo ),
                    DB_UTILITY.CreateParameter("@iMailID", DbType.String, ParameterDirection.Input, Institute.MailID ),
                    DB_UTILITY.CreateParameter("@iAddress", DbType.String, ParameterDirection.Input, Institute.Address ),
                    DB_UTILITY.CreateParameter("@iLandmark", DbType.String, ParameterDirection.Input, Institute.Landmark ),
                    DB_UTILITY.CreateParameter("@iGoogleLocation", DbType.String, ParameterDirection.Input, Institute.GoogleLocation ),
                    DB_UTILITY.CreateParameter("@iHomePageAccess", DbType.String, ParameterDirection.Input, Institute.HomePageAccess ),
                    DB_UTILITY.CreateParameter("@iStatus", DbType.String, ParameterDirection.Input, "1" )
                };
                dsResultSet = DB_UTILITY.RunSP("USP_INSERTTBL_SUPPLIER", arrParameter);
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


        //Method for Fetch  Institute Data From Database.

        public List<Institute> getInstitutes()
        {

            List<string> lstInstituteinfo = new List<string>();
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[] { };
                dsResultSet = DB_UTILITY.RunSP("USP_FETCHTBL_SUPPLIER", arrParameter);
                if (ValidateResultSet(dsResultSet))
                {
                    lstInstitute = OBJECT_UTILITY.GetConvertCollection<Institute>(dsResultSet.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstInstitute;
        }
    }
}
