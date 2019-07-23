using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eera_model;

namespace eera_web.Controllers
{
    public class CourseController : EERABaseController
    {
        //
        // GET: /Course/

        public ActionResult Index()
        {
            @ViewBag.CurrentPageLocation = "Courses";
            return View();
        }

        public ActionResult NewCourse()
        {
            @ViewBag.CurrentPageLocation = "New Courses";
            return View();
        }

        public ActionResult Create(Course _course)
        {
            return RedirectToAction("Index");
        }

    }
}
