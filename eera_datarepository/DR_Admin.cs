using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace eera_datarepository
{
    public class DR_Admin : RepositoryBase
    {
        public List<string> getAdminDashboardInformation()
        {
            //order in the list should be 
            //USER AUTHENTICATION, USER QUERY, PARTNER QUERY, L1 COURSE, L2 COURSE COUNT, SUPPLIER COUNT, AGENCY COUNT
            List<string> lstDashbaordinfo = new List<string>();
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[]{ };
                dsResultSet = DB_UTILITY.RunSP("USP_FETCH_ADMINDASHBOARD", arrParameter);
                if (ValidateResultSet(dsResultSet))
                {
                    foreach (DataTable dtTable in dsResultSet.Tables)
                    {
                        lstDashbaordinfo.Add(dtTable.Rows[0][0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstDashbaordinfo;
        } 
    }
}
