using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using eera_model;
using eera_datarepository;

namespace eera_web.Controllers
{
    public class InstituteController : EERABaseController
    {
        Institute _modelInstitute = null;
        DR_Institute _drInstitute = null;
        DR_Location _drlocation = null;
        //
        // GET: /Institute/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewInstitute()
        {
            @ViewBag.CurrentPageLocation = "New Institute";
            return View();
        }
        [HttpPost]
        public ActionResult Create(Institute Institute, HttpPostedFileBase file, FormCollection postedForm)
        {
            try
            {
                //getting file name if uploaded
                if (file != null)
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    Institute.BannerImage = Institute.Title + fi.Extension;
                }

                //getting checkbox values
                if (postedForm["chkHomeAccess"] != null)
                {
                    Institute.BannerImageAccess = Convert.ToString(postedForm["chkHomeAccess"]) == "on" ? true : false;
                }

                if (postedForm["chkBannerAccess"] != null)
                {
                    Institute.BannerImageAccess = Convert.ToString(postedForm["chkBannerAccess"]) == "on" ? true : false;
                }
                //insert into database
                _drInstitute = new DR_Institute();
                bool result = _drInstitute.CreateInstitute(Institute);

                //upload file
                if (result && file != null)
                {
                    file.SaveAs(Server.MapPath(CategoryPath) + Institute.BannerImage);
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("", "");
        }
        public ActionResult New()
        {
            return View();
        }
        public ActionResult Location()
        {
            //to get the Location institute
            List<Institute> listins = null;
            try
            {
                _drlocation = new DR_Location();
                listins = _drlocation.getInstitutes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(listins);
        }

    }
}
