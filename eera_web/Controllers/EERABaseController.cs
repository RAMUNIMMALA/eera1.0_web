using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace eera_web.Controllers
{
    public class EERABaseController : Controller
    {
        protected string errorMessage = "Something went wrong. Please contact administrator";
        protected string sucessMessage = null;
        protected string warningMessage = null;
        protected string returnAction = null;
        protected string returnController = null;
        private static string categoryPath ;
        private static string subCategoryPath;
        private static string coursePath;
        private static string institutePath;
        private static string hostelPath;

        static EERABaseController()
        {
            categoryPath = Convert.ToString(ConfigurationManager.AppSettings["categoryimagepath"]);
            subCategoryPath =Convert.ToString(ConfigurationManager.AppSettings["subcategoryimagepath"]);
            coursePath =  Convert.ToString(ConfigurationManager.AppSettings["courseimagepath"]);
            institutePath = Convert.ToString(ConfigurationManager.AppSettings["institutepath"]);
            hostelPath = Convert.ToString(ConfigurationManager.AppSettings["hostelpath"]);
        }

        public EERABaseController()
        {
            
        }

        //image paths
        

        protected string CategoryPath
        {
            get { return categoryPath; }
            set { categoryPath = value; }
        }

        protected string SubCategoryPath
        {
            get { return subCategoryPath; }
            set { subCategoryPath = value; }
        }

        protected string CoursePath
        {
            get { return coursePath; }
            set { coursePath = value; }
        }

        protected string InstitutePath
        {
            get { return institutePath; }
            set { institutePath = value; }
        }

        protected string HostelPath
        {
            get { return hostelPath; }
            set { hostelPath = value; }
        }


    }
}
