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

        //Controller For Fetching Institute Data From Database.

        public ActionResult Index()
        {
            @ViewBag.CurrentPageLocation = "Institutes";
            List<Institute> lstInstituteinfo = null;
            try
            {
                _drInstitute = new DR_Institute();
                lstInstituteinfo = _drInstitute.getInstitutes();

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return View(lstInstituteinfo);
        }

        //Controller For Inserting Institute Data Into Database.

        public ActionResult NewInstitute()
        {
            @ViewBag.CurrentPageLocation = "New Institute";
            _drlocation = new DR_Location();
            List<Location> locations = _drlocation.getLocations();
            ViewBag.Locations = locations;
            return View(new Institute());
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
                    file.SaveAs(Server.MapPath(InstitutePath) + Institute.BannerImage);
                }
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("NewInstitute", "Institute");
        }
    }
}

