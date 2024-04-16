using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvc.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
       Context c=new Context();
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.UserName, false);
                Session["UserName"] = bilgiler.UserName.ToString();
                return RedirectToAction("Index", "Index");
            }
            else
            {
                return RedirectToAction("Admin","Admin");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Admin");
        }
    }
}