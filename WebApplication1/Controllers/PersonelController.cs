using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace mvc.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index(string p, int sayfa = 1)
        {
            var degerler = c.Personels.ToList().ToPagedList(sayfa, 4);
            var deger1 = (from x in c.Personels.Where(x => x.Durum == true) select x.PersonelAd).Distinct().Count().ToString();

            ViewBag.deger1 = deger1;

            var personel = from x in c.Personels.Where(x => x.Durum == true) select x;

            if (!string.IsNullOrEmpty(p))
            {
                personel = personel.Where(y => y.PersonelAd.Contains(p));
            }
            return View(personel.ToList());
        }
        [Authorize]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger2 = (from i in c.Departmens.Where(s => s.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.DepartmanAd,
                                               Value = i.Departmanid.ToString()
                                           }).ToList();
            ViewBag.deger2 = deger2;
            List<SelectListItem> degerler = (from i in c.Sirkets.Where(a => a.Durum == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SirketAd,
                                                 Value = i.Sirketid.ToString()
                                             }).ToList();
            ViewBag.deger = degerler;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult PersonelEkle(Personel p, HttpPostedFileBase fileuploader)
        {
            var dp = c.Departmens.Where(x => x.Departmanid == p.Departman.Departmanid).Where(a => a.Durum == true).FirstOrDefault();
            p.Departman = dp;
            var skt = c.Sirkets.Where(x => x.Sirketid == p.Sirket.Sirketid).Where(b => b.Durum == true).FirstOrDefault();
            p.Sirket = skt;


            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));


                p.PersonelGorsel = "/Image/" + fileuploader.FileName + uzanti;
                if (fileuploader == null)
                {
                    p.PersonelGorsel = null;
                }
                else
                {
                    p.PersonelGorsel = "/Image/" + fileuploader.FileName + uzanti;
                }
            }

            c.Personels.Add(p);
            p.Durum = true;
            p.DateTime = DateTime.Now;
            if (p.EsTcKimlik == null)
            {
                p.EsTcKimlik = null;
            }
            if (p.Cocuk1TCKimlik == null)
            {
                p.Cocuk1TCKimlik = null;
            }
            if (p.Cocuk2TCKimlik == null)
            {
                p.Cocuk2TCKimlik = null;
            }
            if (p.Cocuk3TCKimlik == null)
            {
                p.Cocuk3TCKimlik = null;
            }
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var deger = c.Personels.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CheckGender(Personel person)
        {
            if (person.Cinsiyet == Cinsiyet.Erkek)
            {
                return Content(person.PersonelAd + " is a male.");
            }
            else if (person.Cinsiyet == Cinsiyet.Kadın)
            {
                return Content(person.PersonelAd + " is a female.");
            }
            else
            {
                return Content(person.PersonelAd + " does not identify as male or female.");
            }
        }
        [Authorize]
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger2 = (from i in c.Departmens.Where(s => s.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.DepartmanAd,
                                               Value = i.Departmanid.ToString()
                                           }).ToList();
            ViewBag.deger2 = deger2;
            List<SelectListItem> degerler = (from i in c.Sirkets.Where(a => a.Durum == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SirketAd,
                                                 Value = i.Sirketid.ToString()
                                             }).ToList();
            ViewBag.deger = degerler;
            var personeldeger = c.Personels.Find(id);
            return View("PersonelGetir", personeldeger);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var dp = c.Departmens.Where(x => x.Departmanid == p.Departman.Departmanid).FirstOrDefault();
            p.Departman = dp;
            var skt = c.Sirkets.Where(x => x.Sirketid == p.Sirket.Sirketid).Where(b => b.Durum == true).FirstOrDefault();
            p.Sirket = skt;
            var per = c.Personels.Find(p.Personelid);
            per.PersonelAd = p.PersonelAd;
            per.PersonelSoyad = p.PersonelSoyad;
            per.Cinsiyet = p.Cinsiyet;
            per.TCKimlik = p.TCKimlik;
            per.SosyalGuvenlikNo = p.SosyalGuvenlikNo;
            per.GoreveBaslamaT = p.GoreveBaslamaT;
            per.Departman.DepartmanAd = p.Departman.DepartmanAd;
            per.Takımlideri = p.Takımlideri;
            per.AtamalıMeslegi = p.AtamalıMeslegi;
            per.Maas = p.Maas;
            per.MeslekKodu = p.MeslekKodu;
            per.Sirket.SirketAd = p.Sirket.SirketAd;
            per.GorevYaptıgıYer = p.GorevYaptıgıYer;
            per.Sirket.SirketAdres = p.Sirket.SirketAdres;
            per.Sirket.SirketSahibi = p.Sirket.SirketSahibi;
            per.Sirket.SirketsecilNo = p.Sirket.SirketsecilNo;
            per.Sirket.SirketVergiNo = p.Sirket.SirketVergiNo;
            per.Sirket.isYeriTelefon = p.Sirket.isYeriTelefon;
            per.Sirket.Mail = p.Sirket.Mail;
            per.GoreveBaslamaT = p.GoreveBaslamaT;
            per.MezunOlduguOkul = p.MezunOlduguOkul;
            per.YabanciDil = p.YabanciDil;
            per.OncekiIsYeri_Gorevi = p.OncekiIsYeri_Gorevi;
            per.DeneyimSuresi = p.DeneyimSuresi;
            per.OncekiISYeri_gorev2 = p.OncekiISYeri_gorev2;
            per.DeneyimSuresi2 = p.DeneyimSuresi2;
            per.OncekiIsYeri_gorev3 = p.OncekiIsYeri_gorev3;
            per.DeneyimSuresi3 = p.DeneyimSuresi3;
            per.personelDogumT = p.personelDogumT;
            per.KanGrubu = p.KanGrubu;
            per.CepTel = p.CepTel;
            per.Mail = p.Mail;
            per.Adres = p.Adres;
            per.Ililce = p.Ililce;
            per.BirlestirmisAdres = p.BirlestirmisAdres;
            per.Medeni = p.Medeni;
            per.EsAdıSoyadı = p.EsAdıSoyadı;
            per.EsTcKimlik = p.EsTcKimlik;
            per.EsDogumT = p.EsDogumT;
            per.EsTahsil = p.EsTahsil;
            per.EsMeslek = p.EsMeslek;
            per.Escalısıyormu = p.Escalısıyormu;
            per.kamuOzel = p.kamuOzel;
            per.EvlilikT = p.EvlilikT;
            per.Estel = p.Estel;
            per.CocukAdı1 = p.CocukAdı1;
            per.Cocuk1TCKimlik = p.Cocuk1TCKimlik;
            per.cocuk1DogumT = p.cocuk1DogumT;
            per.Cocuk1OkduguOkul = p.Cocuk1OkduguOkul;
            per.CocukAdı2 = p.CocukAdı2;
            per.Cocuk2TCKimlik = p.Cocuk2TCKimlik;
            per.cocuk2DogumT = p.cocuk2DogumT;
            per.Cocuk2OkduguOkul = p.Cocuk2OkduguOkul;
            per.CocukAdı3 = p.CocukAdı3;
            per.Cocuk3TCKimlik = p.Cocuk3TCKimlik;
            per.cocuk3DogumT = p.cocuk3DogumT;
            per.Cocuk3OkduguOkul = p.Cocuk3OkduguOkul;
            per.erkekCalısanlarınaskerlik = p.erkekCalısanlarınaskerlik;
            per.EngelliRapor = p.EngelliRapor;
            per.babaSagVefat = p.babaSagVefat;
            per.BabaAdıSoyadı = p.BabaAdıSoyadı;
            per.BabaTel = p.BabaTel;
            per.AnneSagVefat = p.AnneSagVefat;
            per.AnneAdıSoyadı = p.AnneAdıSoyadı;
            per.AnneTel = p.AnneTel;
            per.İleveBilgi = p.İleveBilgi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult PersonelDetay(int id, string p)
        {

            var degerler = c.Personels.Where(x => x.Personelid == id).ToList();
            return View(degerler);
        }



        [HttpPost]
        public JsonResult KimlikNoKontrol(string no)
        {
            bool sonuc = false;
            if (no.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;
                TcNo = Int64.Parse(no);
                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;
                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);
                sonuc = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
                return Json(new { Durum = sonuc }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Durum = sonuc });
        }



    }
} 

