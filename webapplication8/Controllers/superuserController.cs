using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webapplication8.Controllers
{
    public class superuserController : Controller
    {
        // GET: superuser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Signin()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "--select--" });
            list.Add(new SelectListItem { Text = "genuser" });
            ViewData["list"] = list;
            return View();
        }

        [HttpPost]
        public ActionResult Signin(tblogin lg)
        {
            using (ganEntities2 db = new ganEntities2())
            {
                db.tblogins.Add(lg);
                if (db.SaveChanges() > 0)
                {
                    ViewBag.msg = "Inserted Successfully";
                    ModelState.Clear();
                    return RedirectToAction("Login", "LoginPage");
                }

            }
            return View(lg);
        }
        }
}