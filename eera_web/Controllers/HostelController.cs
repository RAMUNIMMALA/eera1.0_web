using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eera_web.Controllers
{
    public class HostelController : EERABaseController
    {
        //
        // GET: /Hostel/

        public ActionResult Index()
        {
            return View();
        }

    }
}
