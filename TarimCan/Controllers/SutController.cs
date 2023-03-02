using System;
using System.Web.Mvc;
using TarimCan.Models;
using System.Collections.Generic;
using TarimCan.Helper;

namespace TarimCan.Controllers
{
    public class SutController : BaseController
    {
        // GET: Sut
        [UserAuthorizeController]
        public ActionResult Index(DateTime IslemZamani)
        {
            SutIndexModel sim = new SutIndexModel();

            sim.GecmisSutOzeti = sm.SutSatisListesiGetir(7, SessionManager.KullaniciId);
            sim.GunlukSutSatislari = sm.GunlukSutSatislariGetir(IslemZamani, SessionManager.KullaniciId);
            sim.GunlukSutUrunleri = sm.GunlukSutUrunleriniGetir(IslemZamani, SessionManager.KullaniciId);

            List<SutModel> sutList = sm.GunlukSutSatisOzetiGetir(SessionManager.KullaniciId);

            string SutListStr = "";

            foreach (var item in sutList)
            {
                SutListStr += "{ x: new Date(" + item.IslemTarihi.ToString("yyyy") + ", " + int.Parse(item.IslemTarihi.ToString("MM")) + ", " + int.Parse(item.IslemTarihi.ToString("dd")) + "), y: " + Convert.ToInt32(item.GunlukSutMiktari) + " },";
            }
            ViewBag.GunlukSutSatislari = SutListStr;

            return View(sim);
        }

        // GET: Sut
        [UserAuthorizeController]
        public ActionResult SutUrunleriSatisi(DateTime IslemZamani)
        {
            SutIndexModel sim = new SutIndexModel();

            sim.GecmisSutOzeti = sm.SutSatisListesiGetir(7, SessionManager.KullaniciId);
            sim.GunlukSutSatislari = sm.GunlukSutSatislariGetir(IslemZamani, SessionManager.KullaniciId);
            sim.GunlukSutUrunleri = sm.GunlukSutUrunleriniGetir(IslemZamani, SessionManager.KullaniciId);

            List<SutModel> sutList = sm.GunlukSutSatisOzetiGetir(SessionManager.KullaniciId);

            string SutListStr = "";

            foreach (var item in sutList)
            {
                SutListStr += "{ x: new Date(" + item.IslemTarihi.ToString("yyyy") + ", " + int.Parse(item.IslemTarihi.ToString("MM")) + ", " + int.Parse(item.IslemTarihi.ToString("dd")) + "), y: " + Convert.ToInt32(item.GunlukSutMiktari) + " },";
            }
            ViewBag.GunlukSutSatislari = SutListStr;

            return View(sim);
        }

        // GET: Sut
        [UserAuthorizeController]
        public ActionResult Hazirlik()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult GunlukSutSatisiKaydetAction(SutModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = sm.GunlukSutSatisiKaydet(model, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt sırasında hata oluştu...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }

            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        // GET: Sut
        [UserAuthorizeController]
        public ActionResult HayvanBazliSutGirisi(DateTime IslemZamani)
        {
            List<SutModel> GunlukSagilanHayvanlar = new List<SutModel>();

            GunlukSagilanHayvanlar = sm.GunlukSagilanHayvanlariGetir(IslemZamani, SessionManager.KullaniciId);

            if (GunlukSagilanHayvanlar.Count > 0)
            {
                ViewBag.HayvanListesi = GunlukSagilanHayvanlar;
                ViewBag.LitreFiyati = GunlukSagilanHayvanlar[0].LitreFiyati;
                ViewBag.ToplamLitre = GunlukSagilanHayvanlar[0].ToplamLitre;
                ViewBag.GunlukToplamHasilat = GunlukSagilanHayvanlar[0].LitreFiyati * GunlukSagilanHayvanlar[0].ToplamLitre;
            }
            else
            {
                ViewBag.LitreFiyati = 0;
                ViewBag.ToplamLitre = 0;
                ViewBag.GunlukToplamHasilat = 0;
            }

            string HayvanIdleri = "";
            foreach (var item in GunlukSagilanHayvanlar)
            {
                HayvanIdleri += item.HayvanId.ToString() + ",";
            }

            ViewBag.HayvanIdleri = HayvanIdleri.Substring(0, HayvanIdleri.Length - 1);
            ViewBag.SonSutLitreFiyati = sm.SonSutLitreFiyatiGetir(SessionManager.KullaniciId);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult SutUrunleriEkleAction(SutUrunleriModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = sm.GunlukSutUrunleriKaydet(model, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt sırasında hata oluştu...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }

            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult SagilanHayvanlariKaydet(SutModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = sm.SagilanHayvanKaydet(model, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt sırasında hata oluştu...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }

            return Json(srm, JsonRequestBehavior.AllowGet);
        }

    }
}