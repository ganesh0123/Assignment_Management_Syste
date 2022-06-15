using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapplication8;
using webapplication8.Models;


namespace webapplication8.Controllers
{

    public class loginpageController : Controller
    {
        
        // GET: Login


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(tblogin lg)
        {
            using (ganEntities2 db = new ganEntities2())
            {
                var result = db.tblogins.Where(x => x.username == lg.username && x.password == lg.password && x.Role == lg.Role).FirstOrDefault();


                if (ModelState.IsValid)
                {
                    if (lg.Role == "Admin" && result != null)
                    {
                        return RedirectToAction("Index", "Admin");

                    }
                    else if (lg.Role == "superuser" && result != null)
                    {
                        return RedirectToAction("Index", "superuser");
                    }
                    else if (lg.Role == "genuser" && result != null)
                    {
                        return RedirectToAction("Index", "genuser");
                    }
                    else
                    {
                        return RedirectToAction("Login", "LoginPage");
                    }
                }
                else
                {
                    TempData["msg"] = "Incorrect UserName/Password";
                }


                return View(lg);
            }
        }
        public ActionResult Logout()
        {
            ModelState.Clear();
            return View();
        }
    }
}