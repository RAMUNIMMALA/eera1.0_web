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
                FileInfo fi = new FileInfo(file.FileName);
                category.HomeImage = category.Title + fi.Extension;

                if (postedForm["chkHomeAccess"] != null)
                {
                    category.HomeImageAccess  = Convert.ToString( postedForm["chkHomeAccess"]) == "on" ? true : false;
                }

                if (postedForm["chkBannerAccess"] != null)
                {
                    category.HomeImageAccess = Convert.ToString(postedForm["chkBannerAccess"]) == "on" ? true : false;
                }
                
                drCategory = new DR_Category();
                bool result = drCategory.CreateCategory(category);
                if (result)
                {
                    file.SaveAs(CategoryPath + category.HomeImage);
                }

            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("","");
        }

    }
}
