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
        private string categoryPath ;
        private string subCategoryPath;
        private string coursePath;
        private string institutePath;
        private string hostelPath;

        public EERABaseController()
        {
            categoryPath = Server.MapPath( Convert.ToString(ConfigurationManager.AppSettings["categoryimagepath"]));
            subCategoryPath = Server.MapPath(Convert.ToString(ConfigurationManager.AppSettings["subcategoryimagepath"]));
            coursePath = Server.MapPath(Convert.ToString(ConfigurationManager.AppSettings["courseimagepath"]));
            institutePath = Server.MapPath(Convert.ToString(ConfigurationManager.AppSettings["institutepath"]));
            hostelPath = Server.MapPath(Convert.ToString(ConfigurationManager.AppSettings["hostelpath"]));
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
