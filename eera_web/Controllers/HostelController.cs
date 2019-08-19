using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eera_datarepository;
using eera_model;
using System.IO;

namespace eera_web.Controllers
{
    public class HostelController : EERABaseController
    {
        Hostel _modelHostel = null;
        DR_Hostel _drHostel = null;
        List<Hostel> lstHostel = null;
        DR_Location _drlocation = null;


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewHostel()
        {
            _drlocation = new DR_Location();
            List<Location> locations = _drlocation.getLocations();
            ViewBag.Locations = locations;
            return View(new Hostel());
        }

        [HttpPost]
        public ActionResult Create(Hostel Hostel, HttpPostedFileBase file, FormCollection postedForm)
        {
            try
            {
                //getting file name if uploaded
                if (file != null)
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    Hostel.BannerImage = Hostel.Title + fi.Extension;
                }

                //getting checkbox values
                if (postedForm["chkHomeAccess"] != null)
                {
                    Hostel.BannerImageAccess = Convert.ToString(postedForm["chkHomeAccess"]) == "on" ? true : false;
                }

                if (postedForm["chkBannerAccess"] != null)
                {
                    Hostel.BannerImageAccess = Convert.ToString(postedForm["chkBannerAccess"]) == "on" ? true : false;
                }

                //insert into database
                _drHostel = new DR_Hostel();
                bool result = _drHostel.CreateHostel(Hostel);

                //upload file
                if (result && file != null)
                {
                    file.SaveAs(Server.MapPath(CategoryPath) + Hostel.BannerImage);
                }
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("", "");
        }
        
    }
}
