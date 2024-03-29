﻿using System;
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

        public ActionResult PartnerEnquiry()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        } 
    }
}
