using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alumni.BLL;
namespace Alumni.Web.Areas.Admin.Controllers
{
    public class ManageAlumnusController : Controller
    {
        AlumnusRegBs NewAlumnusRegBs = new AlumnusRegBs();
        // GET: Admin/ManageAlumnus
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageAlumusReg(string status)
        {
            //try
            //{
            //    ViewBag.UserId = Session["Username"].ToString();
            //}
            //catch
            //{
            //    Session["ConfirmLogin"] = "You must login first";
            //    return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            //}
            if (status == null)
            {
                status = "P";
            }
            ViewBag.status = status;
            if (status == "L")
            {
                return View(NewAlumnusRegBs.ListAll());
            }

            return View(NewAlumnusRegBs.ListAllByStatus(status));
        }

        public ActionResult UpdateStatus(string username, string status)
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
            var result = NewAlumnusRegBs.UpdateStatus(username, status);
            return RedirectToAction("ListLaundryMan");
        }

        public void UpdateStatusRole(List<string> username, string status, string role)
        {
            string result = "";
            try
            {
                if (username != null)
                {
                    foreach (var item in username)
                    {
                        result = NewAlumnusRegBs.UpdateStatusRole(item, status, role);
                    }
                    Session["UpdateMessage"] = result;
                }
                else
                {
                    Session["UpdateMessage"] = "You selected nothing";

                }            }
            catch (Exception ex)

            {
                throw new Exception(ex.Message);
            }
        }

    }
}