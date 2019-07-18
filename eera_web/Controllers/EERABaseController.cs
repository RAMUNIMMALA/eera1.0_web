using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eera_web.Controllers
{
    public class EERABaseController : Controller
    {
        protected string errorMessage = "Something went wrong. Please contact administrator";
        protected string sucessMessage = null;
        protected string warningMessage = null;
        protected string returnAction = null;
        protected string returnController = null;

    }
}
