using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alumni.Model;
using Alumni.BLL;
using System.IO;

namespace Alumni.Web.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        // GET: User/Profile
        AlumnusRegBs NewAlumnusRegBs = new AlumnusRegBs();
        AlumnusRegistration AlumnusRegObj = new AlumnusRegistration();
        AlumnusPicture AlumnusPicObj = new AlumnusPicture();
        AlumnusPictureBs NewAlumnusPictureBs = new AlumnusPictureBs();
        CodesBs NewCodesBs = new CodesBs();

        HttpPostedFileBase postedImage;
        private static byte[] byteImageData;

        [HttpGet]
        public ActionResult UpdatePersonalData()
        {
            try
            {
                ViewBag.Username = Session["Username"].ToString();
            }
            catch
            {
                Session["ConfirmLogin"] = "You must login first";
                return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            }
            ViewBag.State = new SelectList(NewCodesBs.LoadStates());
            var result = NewAlumnusRegBs.GetByUsername(ViewBag.Username);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdatePersonalData(FormCollection collection)
        {
            try
            {
                ViewBag.Username = Session["Username"].ToString();
            }
            catch
            {
                Session["ConfirmLogin"] = "You must login first";
                return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            }

            if (ModelState.IsValid)
            {
                AlumnusRegObj.Username = ViewBag.Username;
                AlumnusRegObj.Surname = collection["Surname"];
                AlumnusRegObj.Othername = collection["Othername"];
                AlumnusRegObj.Sex = collection["Sex"];
                AlumnusRegObj.Dob = Convert.ToDateTime(collection["Dob"]);
                AlumnusRegObj.Marital_Status = collection["Marital_Status"];
                AlumnusRegObj.State = collection["State"];
                AlumnusRegObj.Phone_Number = collection["Phone_Number"];
                AlumnusRegObj.Address = collection["Address"];
                AlumnusRegObj.Department = collection["Department"];
                AlumnusRegObj.Graduation_Year = Convert.ToInt32(collection["Graduation_Year"]);
                AlumnusRegObj.Email_Id = collection["Email_Id"];
                NewAlumnusRegBs.Update(AlumnusRegObj);
                //AlumnusRegObj.Email_Id = collection["Email_Id"];
                //AlumnusRegObj.Username = collection["Username"];
            }
            else
            {
                ViewBag.State = new SelectList(NewCodesBs.LoadStates());
                return View(AlumnusRegObj);
            }
            ViewBag.State = new SelectList(NewCodesBs.LoadStates());
            return View();
        }

        [HttpGet]
        public ActionResult UploadProfilePicture()
        {
            try
            {
                ViewBag.Username = Session["Username"].ToString();
            }
            catch
            {
                Session["ConfirmLogin"] = "You must login first";
                return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            }
            var result = NewAlumnusPictureBs.GetByUsername(ViewBag.Username);
                if (result != null)
            {
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public ActionResult UploadProfilePicture(FormCollection collection, HttpPostedFileBase image)
        {
            try
            {
                ViewBag.Username = Session["Username"].ToString();
            }
            catch
            {
                Session["ConfirmLogin"] = "You must login first";
                return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            }

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    AlumnusPicObj.Username = ViewBag.Username;
                    postedImage = image;
                    byteImageData = ByteImage(postedImage.FileName, new string[] { ".gif", ".jpg", ".bmp" }, image);
                    AlumnusPicObj.Picture = byteImageData;
                    var result = NewAlumnusPictureBs.GetByUsername(AlumnusPicObj.Username);
                    if (result == null)
                    {
                        AlumnusPicObj.AlumnusPictureId = System.Guid.NewGuid().ToString("N");
                        AlumnusPicObj.Key_Date = DateTime.Today;
                        AlumnusPicObj.Flag = "A";
                        NewAlumnusPictureBs.Insert(AlumnusPicObj);
                        return RedirectToAction("UploadProfilePicture");
                    }
                    else
                    {
                        AlumnusPicObj.Flag = "C";
                        NewAlumnusPictureBs.Update(AlumnusPicObj);
                        return RedirectToAction("UploadProfilePicture");
                    }
                }
            }
            else
            {
                return View(AlumnusRegObj);
            }
            return View();
        }


        private static byte[] ReadImage(string p_postedImageFileName, string[] p_fileType)
        {
            bool isValidFileType = false;
            try
            {
                FileInfo file = new FileInfo(p_postedImageFileName);
                foreach (string strExtensionType in p_fileType)
                {
                    if (strExtensionType == file.Extension)
                    {
                        isValidFileType = true;
                        break;
                    }
                }
                if (isValidFileType)
                {
                    FileStream fs = new FileStream(p_postedImageFileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] image = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                    return image;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static byte[] ByteImage(string p_postedImageFileName, string[] p_fileType, HttpPostedFileBase img)
        {
            bool isValidFileType = false;
            try
            {
                FileInfo file = new FileInfo(p_postedImageFileName);
                foreach (string strExtensionType in p_fileType)
                {
                    if (strExtensionType == file.Extension)
                    {
                        isValidFileType = true;
                        break;
                    }
                }
                if (isValidFileType)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                        return array;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}