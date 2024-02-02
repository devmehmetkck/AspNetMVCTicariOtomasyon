using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            for (int i = 0; i < degerler.Count; i++)
            {
                int adet = KacAdet(degerler[i].PersonelID);
                degerler[i].SatisAdet = adet;
            }
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniPersonel()
        {
            List<SelectListItem> list = (from x in c.Departmans.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmanAd,
                                             Value = x.DepartmanID.ToString()
                                         }).ToList();
            ViewBag.dDepart=list;
            return View();
        }

        [HttpPost]
        public ActionResult YeniPersonel(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("YeniPersonel");
            }
            var depart = c.Departmans.Where(x => x.DepartmanID == personel.Departman.DepartmanID).FirstOrDefault();
            personel.Departman = depart;
            personel.Durum = true;
            c.Personels.Add(personel);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var personel = c.Personels.Find(id);
            personel.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGoster (int id)
        {
            var personel=c.Personels.Find(id);
            List<SelectListItem> list = (from x in c.Departmans.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmanAd,
                                             Value = x.DepartmanID.ToString()
                                         }).ToList();
            ViewBag.gndep = list;
            return View("PersonelGoster", personel);
        }
        public ActionResult Guncelle(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelGoster");
            }
            var depart = c.Departmans.Where(x => x.DepartmanID == personel.Departman.DepartmanID).FirstOrDefault();
            var per = c.Personels.Find(personel.PersonelID);
            per.PersonelAd= personel.PersonelAd;
            per.PersonelSoyad= personel.PersonelSoyad;
            per.Departman= depart;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        int KacAdet(int id)
        {
            int sayi=c.SatisHarekets.Where(x=>x.Personel.PersonelID==id).ToList().Count();
            return sayi;
        }
    }
}