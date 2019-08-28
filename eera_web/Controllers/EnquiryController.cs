using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eera_model;
using eera_datarepository;

namespace eera_web.Controllers
{
    public class EnquiryController : Controller
    {
        DR_PartnerEnquiry _drPartnerEnquiry = null;
        DR_UserEnquiry _druserenquery = null;
        //
        // GET: /Enquiry/

        public ActionResult Index()
        {
            return View("UserEnquiry");
        }

        public ActionResult UserEnquiry()
        {
            //To get the UserEnquiry
            List<UserEnquiry> userenquery = null;
            try
            {
                _druserenquery = new DR_UserEnquiry();
                userenquery = _druserenquery.GetUserEnquery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(userenquery);
        }

        public ActionResult PartnerEnquiry()
        {
            //To get the PartnerEnquiry
            List<PartnerEnquiry> partnerenquery = null;
            try
            {
                _drPartnerEnquiry = new DR_PartnerEnquiry();
                partnerenquery = _drPartnerEnquiry.GetPartnerEnquery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(partnerenquery);
        }
    }
}
