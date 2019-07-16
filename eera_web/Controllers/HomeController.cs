using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eera_web.Controllers
{
    public class HomeController : EERABaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin(FormCollection form)
        {
            string principle1 = form["txtMailId"].ToString();
            string principle = Request["txtPassword"].ToString();
            return RedirectToAction("Index", "Admin");
        }

    }
}
