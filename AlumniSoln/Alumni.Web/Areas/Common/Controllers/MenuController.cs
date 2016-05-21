using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alumni.Web.Areas.Common.Controllers
{
    public class MenuController : Controller
    {
        // GET: Common/Menu
        public ActionResult AlumnusMenu()
        {
            try
            {
                ViewBag.UserId = Session["Username"].ToString();
            }
            catch
            {
                Session["ConfirmLogin"] = "You must login first";
                return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            }
            return View();
        }
    }
}