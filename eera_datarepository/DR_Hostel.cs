using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eera_model;
using System.Data;

namespace eera_datarepository
{
    public class DR_Hostel : RepositoryBase
    {
        Hostel _Hostel = null;

        public bool CreateHostel(Hostel Hostel)
        {
            bool result = false;
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[]{
                    DB_UTILITY.CreateParameter("@iTitle", DbType.String, ParameterDirection.Input, Hostel.Title ),
                    DB_UTILITY.CreateParameter("@iDescription", DbType.String, ParameterDirection.Input, Hostel.Detials ),
                    DB_UTILITY.CreateParameter("@iCategory", DbType.String, ParameterDirection.Input, Hostel.Category ),
                    DB_UTILITY.CreateParameter("@iBannerImage", DbType.String, ParameterDirection.Input, Hostel.BannerImage == null ? "" : Hostel.BannerImage ),
                    DB_UTILITY.CreateParameter("@iBannerImageAccess", DbType.String, ParameterDirection.Input, Hostel.BannerImageAccess ),
                    DB_UTILITY.CreateParameter("@iSliderAccess", DbType.String, ParameterDirection.Input, Hostel.SliderAccess ),
                    DB_UTILITY.CreateParameter("@iStateCode", DbType.String, ParameterDirection.Input, Hostel.StateCode ),
                    DB_UTILITY.CreateParameter("@iCityCode", DbType.String, ParameterDirection.Input, Hostel.CityCode ),
                    DB_UTILITY.CreateParameter("@iAreaCode", DbType.String, ParameterDirection.Input, Hostel.AreaCode ),
                    DB_UTILITY.CreateParameter("@iContactNo", DbType.String, ParameterDirection.Input, Hostel.ContactNo ),
                    DB_UTILITY.CreateParameter("@iMailID", DbType.String, ParameterDirection.Input, Hostel.MailID ),
                    DB_UTILITY.CreateParameter("@iAddress", DbType.String, ParameterDirection.Input, Hostel.Address ),
                    DB_UTILITY.CreateParameter("@iLandmark", DbType.String, ParameterDirection.Input, Hostel.Landmark ),
                    DB_UTILITY.CreateParameter("@iShare", DbType.String, ParameterDirection.Input, Hostel.Share ),
                    DB_UTILITY.CreateParameter("@iBudget", DbType.String, ParameterDirection.Input, Hostel.Budget ),
                    DB_UTILITY.CreateParameter("@iAmenities", DbType.String, ParameterDirection.Input, Hostel.Amenities ),
                    DB_UTILITY.CreateParameter("@iGoogleLocation", DbType.String, ParameterDirection.Input, Hostel.GoogleLocation ),
                    DB_UTILITY.CreateParameter("@iHomePageAccess", DbType.String, ParameterDirection.Input, Hostel.HomePageAccess ),
                    DB_UTILITY.CreateParameter("@iStatus", DbType.String, ParameterDirection.Input, "1" )
                };
                dsResultSet = DB_UTILITY.RunSP("USP_INSERTTBL_AGENCY", arrParameter);
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
