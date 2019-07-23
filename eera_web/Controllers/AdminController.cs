using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eera_datarepository;

namespace eera_web.Controllers
{
    public class AdminController : EERABaseController
    {
        DR_Admin drAdmin = null;
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            List<string> lstDashboardInfo = null;
            drAdmin = new DR_Admin();
            try
            {
                lstDashboardInfo = drAdmin.getAdminDashboardInformation();

            }
            catch (Exception Ex)
            {

            }
            return View(lstDashboardInfo);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}
