using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eera_datarepository;
using eera_model;
using System.IO;
using System.Configuration;

namespace eera_web.Controllers
{
    public class CategoryController : EERABaseController
    {

        Category modelCategory = null;
        DR_Category drCategory = null;       
        //
        // GET: /Category/

        public ActionResult Index()
        {
            @ViewBag.CurrentPageLocation = "Category";
            return View();
        }

        public ActionResult NewCategory()
        {
            @ViewBag.CurrentPageLocation = "New Category";
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category, HttpPostedFileBase file, FormCollection postedForm)
        {
            try
            {
                //getting file name if uploaded
                if (file != null)
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    category.HomeImage = category.Title + fi.Extension;
                }

                //getting checkbox values
                if (postedForm["chkHomeAccess"] != null)
                {
                    category.HomeImageAccess  = Convert.ToString( postedForm["chkHomeAccess"]) == "on" ? true : false;
                }

                if (postedForm["chkBannerAccess"] != null)
                {
                    category.HomePageAccess = Convert.ToString(postedForm["chkBannerAccess"]) == "on" ? true : false;
                }
                
                //insert into database
                drCategory = new DR_Category();
                bool result = drCategory.CreateCategory(category);
                
                //upload file
                if (result && file != null)
                {
                    file.SaveAs(Server.MapPath(CategoryPath) + category.HomeImage);
                }
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("","");
        }

    }
}
