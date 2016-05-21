using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alumni.Model;
using Alumni.BLL;

namespace Alumni.Web.Areas.Security.Controllers
{
    public class AccessController : Controller
    {
        AlumnusRegBs NewAlumnusRegBs = new AlumnusRegBs();
        AlumnusRegistration AlumnusRegObj = new AlumnusRegistration();
        string message;
        ///CompanyDetailBs NewCompanyDetailBs = new CompanyDetailBs();
        // GET: Security/Access
        public ActionResult Login()
        {
            //  var CompanyShortName = NewCompanyDetailBs.DisplayCompanyShortName();
            // ViewBag.CompanyShortName = CompanyShortName;
            return View();
        }

        // POST: Security/Access/Create
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                Session["ConfirmLogin"] = "";
                AlumnusRegObj.Username = collection["Username"];
                AlumnusRegObj.Password = collection["Password"];
                var search = NewAlumnusRegBs.Login(AlumnusRegObj.Username);
                if (search == null)
                {
                    message = "Invalid username or email";
                }
                else if (search.Password == AlumnusRegObj.Password)
                {
                    Session["Role"] = search.Alumnus_Role;
                    Session["Username"] = search.Username;
                    Session["FullName"] = search.Surname + " " + search.Othername;
                    if (search.Reg_Status == "A")
                        return RedirectToAction("AlumnusMenu", new { Controller = "Menu", Area = "Common" });
                    else if (search.Reg_Status == "P")
                        message = "User confirmation is still pending";
                    else if (search.Reg_Status == "R")
                        message = "User has been rejected";
                }
                else
                {
                    message = "Invalid password";
                }
            }
            else
            {
                return View(AlumnusRegObj);
            }
            ViewData["Message"] = message;
            return View(AlumnusRegObj);
        }

        public ActionResult Logout()
        {
            if (Session["Username"] != null)

            {
                Session.Remove(Session["Username"].ToString());
                Session.Remove(Session["ConfirmLogin"].ToString());
                Session.Abandon();
            }
            return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });

        }
    }
}