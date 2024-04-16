using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        [Authorize]
        public ActionResult Index(string p)
        {
            var deger1 = (from x in c.Departmens.Where(x => x.Durum == true) select x.DepartmanAd).Distinct().Count().ToString();
            ViewBag.deger1 = deger1;
            var departman = from x in c.Departmens.Where(x => x.Durum == true) select x;
            if (!string.IsNullOrEmpty(p))
            {
                departman = departman.Where(y => y.DepartmanAd.Contains(p));
            }
            return View(departman.ToList());
        }

        public ActionResult Departmanekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Departmanekle(Departmen p)
        {
            c.Departmens.Add(p);
            p.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Departmansil(int id)
        {
            var deger = c.Departmens.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dprt = c.Departmens.Find(id);
            return View("DepartmanGetir", dprt);
        }
        public ActionResult DepartmanGuncelle(Departmen p)
        {
            var dp = c.Departmens.Find(p.Departmanid);
            dp.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}