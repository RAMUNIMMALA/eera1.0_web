using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eera_datarepository;
using eera_model;
using System.Collections;

namespace eera_web.Controllers
{    public class HomeController : EERABaseController
    {

        DR_User _drUser = null;
        DR_Home _drHome = null;
        DR_PartnerEnquiry _drPartnerEnquiry = null;
        DR_UserEnquiry _drUserEnquiry = null;
        DR_Location _drlocation = null;
        User _user = null;
        string userMail = null;
        string password = null;

        public ActionResult Index()
        {
            _drHome = new DR_Home();
            Hashtable htData = null;
            try
            {
                htData = _drHome.getHomeInformation();
            }
            catch (Exception ex)
            {

            }
            return View(htData);
        }

        public ActionResult UserLogin(User user)
        {
            try
            {
                userMail = user.MailID;
                password = user.Password;
                _drUser = new DR_User();
                _user = _drUser.verifyUserLogin(userMail, password);
                if (_user != null)
                {
                    if (_user.Status)
                    {
                        Session["loginuserdata"] = _user;
                        returnAction = "Index";
                        returnController = "Admin";
                    }
                    else
                    {
                        ViewBag.warningMessage = "Account is blocke. Please contact admin";
                        returnAction = "Index";
                        returnController = "Home";
                    }
                }
                else
                {
                    ViewBag.warningMessage = "Invalid User details. Please try again";
                    returnAction = "Index";
                    returnController = "Home";
                }
            }
            catch (Exception ex)
            {
                returnAction = "Index";
                returnController = "Home";
                ViewBag.errorMessage = errorMessage;
            }
            return RedirectToAction(returnAction, returnController);
        }

        public ActionResult UserSigup(User user)
        {
          
            _drlocation = new DR_Location();
            List<Location> locations = _drlocation.getLocations();
            ViewBag.Locations = locations;
            try
            {
                user.RoleId = 1;
                _drUser = new DR_User();
                _drUser.verifyUserSigup(user);

                if (user != null)
                {
                    if (user.Status)
                    {
                        Session["loginuserdata"] = user;
                        returnAction = "Index";
                        returnController = "Home";
                    }
                    else
                    {
                        ViewBag.warningMessage = "Account is blocke. Please contact admin";
                        returnAction = "Index";
                        returnController = "Home";
                    }
                }
                else
                {
                    ViewBag.warningMessage = "Invalid User details. Please try again";
                    returnAction = "Index";
                    returnController = "Home";
                }

            }
            catch (Exception ex)
            {
                returnAction = "Index";
                returnController = "Home";
                ViewBag.errorMessage = errorMessage;
            }
            //return RedirectToAction(returnAction, returnController);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Courses()
        {
            return View();
        }

        public ActionResult Institutes()
        {
            return View();
        }

        public ActionResult Hostels()
        {
            return View();
        }

        public ActionResult Tests()
        {
            return View();
        }

        public ActionResult Enquiry()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult PostEnquiry(UserEnquiry userenquiry, HttpPostedFileBase file, FormCollection postedForm)
        {
            //insert UserEnquiry into database
            _drUserEnquiry = new DR_UserEnquiry();
            bool result = _drUserEnquiry.CreateUserEnquiry(userenquiry);
            return RedirectToAction("Index", "Home");
        }



        public ActionResult PartnerEnquiry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostCreate(PartnerEnquiry partnerenquiry, HttpPostedFileBase file, FormCollection postedForm)
        {
            try
            {
                //insert PartnerEnquiry into database
                _drPartnerEnquiry = new DR_PartnerEnquiry();
                bool result = _drPartnerEnquiry.CreateEnquiry(partnerenquiry);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ContactUs()
        {
            return View();
        } 
    }
}
