using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Controllers
{
    [Authorize]
    public class SirketController : Controller
    {
        // GET: Sirket
        Context c =new Context();   
        public ActionResult Index(string p)
        {
            var deger1 = (from x in c.Sirkets.Where(x => x.Durum == true) select x.SirketAd).Distinct().Count().ToString();
            ViewBag.deger1 = deger1;
            var srkt = from x in c.Sirkets.Where(x => x.Durum == true) select x;
            if (!string.IsNullOrEmpty(p))
            {
                srkt = srkt.Where(y => y.SirketAd.Contains(p));
            }
            return View(srkt.ToList());

        }
        [Authorize]
        public ActionResult SirketEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SirketEkle(Sirket p)
        { 
            c.Sirkets.Add(p);
            p.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sirketsil(int id)
        {
            var deger = c.Sirkets.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
       
        public ActionResult SirketGetir(int id)
        {
            var sirketdeger=c.Sirkets.Find(id);
            return View("SirketGetir", sirketdeger);
        }
        [HttpPost]
        public ActionResult SirketGuncelle(Sirket p)
        {
            var sk=c.Sirkets.Find(p.Sirketid);
            sk.SirketAd = p.SirketAd;
            sk.SirketAdres=p.SirketAdres;
            sk.SirketSahibi=p.SirketSahibi;
            sk.SirketsecilNo=p.SirketsecilNo;
            sk.SirketVergiNo = p.SirketVergiNo;
            sk.isYeriTelefon=p.isYeriTelefon;
            sk.İsyeriBelgegecerNo = p.İsyeriBelgegecerNo;
            sk.Mail=p.Mail;
            sk.İsyeriTehlikesınıfı = p.İsyeriTehlikesınıfı;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}