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
    public class DR_Home : RepositoryBase
    {
        Hashtable htHomeData = null;
        
        public Hashtable getHomeInformation()
        {
            //order in the list should be 
            //
            List<string> lsthomeinfo = new List<string>();
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[] { };
                dsResultSet = DB_UTILITY.RunSP("USP_FETCH_HOMEMASTERDATA", arrParameter);
                if (ValidateResultSet(dsResultSet))
                {
                    htHomeData = new Hashtable();
                    htHomeData.Add("CATEGORY",  OBJECT_UTILITY.GetConvertCollection<Category>(dsResultSet.Tables[0]));
                    htHomeData.Add("INSTITUTE", OBJECT_UTILITY.GetConvertCollection<Institute>(dsResultSet.Tables[1]));
                    htHomeData.Add("HOSTEL", OBJECT_UTILITY.GetConvertCollection<Hostel>((dsResultSet.Tables[2])));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return htHomeData;
        }
    }
}
