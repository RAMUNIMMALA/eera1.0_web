using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using eera_model;

namespace eera_datarepository
{
   public class DR_Location : RepositoryBase
    {
        List<Location> lstLocations = null;
        List<Institute>lstins=null;
        public List<Location> getLocations()
        {
            /// <summary>
            /// Description : To get the Locations list
            /// Name: Ramu Nimmala
            /// </summary>
            List<string> lstlocationinfo = new List<string>();
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[] { };
                dsResultSet = DB_UTILITY.RunSP("USP_FETCH_LOCATION", arrParameter);
                if (ValidateResultSet(dsResultSet))
                {
                    lstLocations = OBJECT_UTILITY.GetConvertCollection<Location>(dsResultSet.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstLocations;
        }
        public List<Institute> getInstitutes()
        {
            
            List<string> lstlocationinfo = new List<string>();
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[] { };
                dsResultSet = DB_UTILITY.RunSP("USP_FETCH_INSTITUTE", arrParameter);
                if (ValidateResultSet(dsResultSet))
                {
                    lstins = OBJECT_UTILITY.GetConvertCollection<Institute>(dsResultSet.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstins;
        }
    }
}
