using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eera_web.Controllers
{
    public class CourseController : EERABaseController
    {
        //
        // GET: /Course/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewCourse()
        {
            return View();
        }

    }
}
