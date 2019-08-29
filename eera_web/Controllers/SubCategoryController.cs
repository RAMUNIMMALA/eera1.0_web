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
    public class SubCategoryController : EERABaseController
    {
        SubCategory modelSubCategory = null;
        DR_SubCategory drSubCategory = null;
        List<SubCategory> lstSubCategories = null;
        //
        // GET: /SubCategory/
        //Controller For Fetching SubCategory Data From Database.

        public ActionResult Index()
        {
            @ViewBag.CurrentPageLocation = "SubCategory";
            try
            {
                drSubCategory = new DR_SubCategory();
                int iTotalRows = 0;
                lstSubCategories = drSubCategory.getSubCategoryList(ref iTotalRows);
                ViewBag.TotalRecords = iTotalRows;
            }
            catch (Exception ex)
            {

            }
            return View(lstSubCategories);
        }
        //public ActionResult NewCategory()
        //{
        //    @ViewBag.CurrentPageLocation = "New Category";
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(SubCategory category, HttpPostedFileBase file, FormCollection postedForm)
        //{
        //    try
        //    {
        //        //getting file name if uploaded
        //        if (file != null)
        //        {
        //            FileInfo fi = new FileInfo(file.FileName);
        //            category.HomeImage = category.Title + fi.Extension;
        //        }

        //        //getting checkbox values
        //        if (postedForm["chkHomeAccess"] != null)
        //        {
        //            category.HomeImageAccess = Convert.ToString(postedForm["chkHomeAccess"]) == "on" ? true : false;
        //        }

        //        if (postedForm["chkBannerAccess"] != null)
        //        {
        //            category.HomePageAccess = Convert.ToString(postedForm["chkBannerAccess"]) == "on" ? true : false;
        //        }

        //        //insert into database
        //        drSubCategory = new DR_SubCategory();
        //        bool result = drSubCategory.CreateCategory(category);

        //        //upload file
        //        if (result && file != null)
        //        {
        //            file.SaveAs(Server.MapPath(CategoryPath) + category.HomeImage);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return RedirectToAction("Index", "Category");
        //}
       

    }
}
