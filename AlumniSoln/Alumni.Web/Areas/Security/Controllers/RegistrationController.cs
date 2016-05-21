using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alumni.Model;
using Alumni.BLL;

namespace Alumni.Web.Areas.Security.Controllers
{
    public class RegistrationController : Controller
    {
        AlumnusRegBs NewAlumnusRegBs = new AlumnusRegBs();
        AlumnusRegistration AlumnusRegObj = new AlumnusRegistration();
        CodesBs NewCodesBs = new CodesBs();
        // GET: Security/Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AlumnusReg(string ValidateReg="")
        {
            if (ValidateReg != "Y")
            {
                return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            }
            ViewBag.State = new SelectList(NewCodesBs.LoadStates());
            return View();
        }

        [HttpPost]
        public ActionResult AlumnusReg(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                AlumnusRegObj.Surname = collection["Surname"];
                AlumnusRegObj.Othername = collection["Othername"];
                AlumnusRegObj.Sex = collection["Sex"];
                AlumnusRegObj.Dob =Convert.ToDateTime(collection["Dob"]);
                AlumnusRegObj.Marital_Status = collection["Marital_Status"];
                AlumnusRegObj.State = collection["State"];
                AlumnusRegObj.Phone_Number = collection["Phone_Number"];
                AlumnusRegObj.Address = collection["Address"];
                AlumnusRegObj.Department = collection["Department"];
                AlumnusRegObj.Graduation_Year = Convert.ToInt32(collection["Graduation_Year"]);
                AlumnusRegObj.Email_Id = collection["Email_Id"];
                AlumnusRegObj.Username = collection["Username"];
                AlumnusRegObj.Password = collection["Password"];


                if (collection["Password"] == collection["ConfirmPassword"])
                {
                    AlumnusRegObj.AlumnusRegistration_Id = System.Guid.NewGuid().ToString("N");
                    AlumnusRegObj.Reg_Status = "P";
                    AlumnusRegObj.Alumnus_Role = "";
                    AlumnusRegObj.Key_Date = DateTime.Today;
                    AlumnusRegObj.Flag = "A";
                    NewAlumnusRegBs.Insert(AlumnusRegObj);
                    ViewData["Message"] = "Record save successfully";
                    ViewBag.State = new SelectList(NewCodesBs.LoadStates());
                    return View();
                }
                else
                {
                    ViewData["Message"] = "Password does not matches";
                    //return RedirectToAction("LaundryManRegistration");
                    ViewBag.State = new SelectList(NewCodesBs.LoadStates());
                    return View(AlumnusRegObj);
                }
            }
            else
            {
                ViewBag.State = new SelectList(NewCodesBs.LoadStates());
                return View(AlumnusRegObj);
            }
        }
    }
}