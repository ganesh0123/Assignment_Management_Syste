using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webapplication8.Controllers
{
    public class genuserController : Controller
    {
        // GET: genuser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult dashboard()
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("index");
            }
            else { }
            return View();
        }
        
        [HttpPost]
        public ActionResult dashboard(string Password, string newPassword, string Confirmpwd)
        {
             using (ganEntities2 db = new ganEntities2())
             {
                 User objlogin = new User();
                
            string user = Session["userid"].ToString();
         
            var result = db.UserMasters.Where(x=> x.Name == user).FirstOrDefault();
            if (result.Password == Password)
            {
                if (Confirmpwd == newPassword)
                    {
                        result.Password = newPassword;
                        db.Entry(result).State = EntityState.Modified;
                        db.SaveChanges();
                        TempData["msg"] = "<script>alert('Password has been changed successfully !!!');</script>";
                    }
                else
                {
                    TempData["msg"] = "<script>alert('New password match !!! Please check');</script>";
                }
            }
            else
            {
                TempData["msg"] = "<script>alert('Old password not match !!! Please check entered old password');</script>";
            }
             }
            return View();
        }
        public ActionResult Downloads()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/App_Data/uploads/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }

        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = "~/App_Data/uploads/" + ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }  
        public ActionResult AssignmentDetails()
        {
            List<Detail> detail= new List<Detail>();
            using (ganEntities2 db = new ganEntities2())
            {
                //var result = db.Details;
         
                var result = db.Details.AsEnumerable().Where(x => ((x.assignmentUser).ToLower()).Contains(Session["userid"].ToString().ToLower()));
                if(result.Count() > 0)
                {
                    foreach (var data in result)
                    {
                        detail.Add(new Detail { Id = 1, assignmentName = data.assignmentName, assignmentUser = data.assignmentUser });
                    }
                }
                
            }
            return View(detail);
        }
        }
	}

   