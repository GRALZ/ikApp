using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace mvc.Controllers
{
    [Authorize]
    public class IndexController : Controller
    {
        // GET: Index
        Context c=new Context();

        public ActionResult Index()
        {
            var deger = (from x in c.Personels.Where(x => x.Durum == true) select x.Personelid).Distinct().Count().ToString();
            ViewBag.deger = deger;
            var deger2=(from x in c.Sirkets.Where(x=>x.Durum==true) select x.Sirketid).Distinct().Count().ToString();
            ViewBag.deger2 = deger2;
            var deger3 = (from x in c.Departmens.Where(x => x.Durum == true) select x.Departmanid).Distinct().Count().ToString();
            ViewBag.deger3 = deger3;
            var urunler = from x in c.Sirkets select x;
            return View(urunler.ToList());

        }
        public ActionResult ToplamPersonel()
        {
            var toplamsayis= c.toplamsayis.ToList();
         ViewBag.Departmanlari=toplamsayis;
            
            return View();
        }
    }
}