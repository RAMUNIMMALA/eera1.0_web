using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eera_web.Controllers
{
    public class EnquiryController : Controller
    {
        //
        // GET: /Enquiry/

        public ActionResult Index()
        {
            return View("UserEnquiry");
        }

        public ActionResult UserEnquiry()
        {
            return View();
        }

        public ActionResult PartnerEnquiry()
        {
            return View();
        }

    }
}
