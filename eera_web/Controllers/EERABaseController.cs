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

        public EERABaseController()
        {
            categoryPath = Server.MapPath( Convert.ToString(ConfigurationManager.AppSettings["categoryimagepath"]));
        }

        //image paths
        private string categoryPath;

        protected string CategoryPath
        {
            get { return categoryPath; }
            set { categoryPath = value; }
        }
    }
}
