using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarimCan.Helper;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class FinansController : BaseController
    {
        // GET: Finans
        [UserAuthorizeController]
        public ActionResult Index()
        {
            /*fm.IsletmeGelirleriGetir()*/
            return View(fm.IsletmeGelirleriGetir(SessionManager.KullaniciId));
        }

        [UserAuthorizeController]
        public ActionResult FinansalIndex()
        {
            List<GelirGiderModel> gelirGiderList = fm.IsletmeFinansDokumunuDetayliGetir(SessionManager.KullaniciId, 0, 0);

            List<GelirGiderModel> list = fm.IsletmeFinansalHareketleriGetir(SessionManager.KullaniciId);
            string GelirStr = "";
            string GiderlerStr = "";

            foreach (var item in list)
            {
                if (item.IslemTipId == 1)
                {
                    // Grafikte ay bir sonraki aya attığı için, burada ayı bir eksilttik.
                    // Grafikten hata sunucunun tarih saat ayarından kaynaklanabilir.
                    // Yeni sunucuya geçildiğinde tekrar değerlendirilecek. 
                    // 17.02.2023 Kemal KİREZCİ
                    DateTime dtTemp = item.IslemTarihi.AddMonths(-1);
                    GelirStr += "{ x: new Date(" + dtTemp.ToString("yyyy") + ", " + dtTemp.ToString("MM") + ", " + dtTemp.ToString("dd") + "), y: " + Convert.ToInt32(item.Tutari) + " },";
                }
                else
                {
                    // Grafikte ay bir sonraki aya attığı için, burada ayı bir eksilttik.
                    // Grafikten hata sunucunun tarih saat ayarından kaynaklanabilir.
                    // Yeni sunucuya geçildiğinde tekrar değerlendirilecek. 
                    // 17.02.2023 Kemal KİREZCİ
                    DateTime dtTemp = item.IslemTarihi.AddMonths(-1);
                    GiderlerStr += "{ x: new Date(" + dtTemp.ToString("yyyy") + ", " + dtTemp.ToString("MM") + ", " + dtTemp.ToString("dd") + "), y: " + Convert.ToInt32(item.Tutari) + " },";
                }
            }

            ViewBag.Gelirler = GelirStr;
            ViewBag.Giderler = GiderlerStr;

            AnaSayfaIsletmeDurumModel isletmeDurumu = fm.IsletmeGelirGiderOzetGetir(SessionManager.KullaniciId);
            ViewBag.IsletmeGelirleri = String.Format("{0:0,0}", isletmeDurumu.IsletmeGelirleri);
            ViewBag.IsletmeGiderleri = String.Format("{0:0,0}", isletmeDurumu.IsletmeGiderleri);
            ViewBag.IsletmeKarZarar = String.Format("{0:0,0}", (isletmeDurumu.IsletmeGelirleri- isletmeDurumu.IsletmeGiderleri));

            return View(gelirGiderList);
        }

        [UserAuthorizeController]
        public ActionResult ManuelGelirEkle()
        {
            ViewBag.GelirGiderTipleri = cm.IsletmeGelirGiderTipleriGetir("gelir");
            return View();
        }

        [UserAuthorizeController]
        public ActionResult ManuelGiderEkle()
        {
            ViewBag.GelirGiderTipleri = cm.IsletmeGelirGiderTipleriGetir("gider");
            return View();
        }

        [UserAuthorizeController]
        public ActionResult Hazirlik()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult ManuelGelirEkleAction(GelirGiderModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = fm.ManuelGelirGiderKaydet(model, 1, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt edildi";
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
        public JsonResult ManuelGiderEkleAction(GelirGiderModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = fm.ManuelGelirGiderKaydet(model, 2, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt edildi";
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

        [UserAuthorizeController]
        public ActionResult FinansDokumu(int Tip = 0, int Sayfa = 0)
        {
            List<GelirGiderModel> list = fm.IsletmeFinansDokumunuDetayliGetir(SessionManager.KullaniciId, Tip, Sayfa);

            ViewBag.FinansanDokumListesi = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult FinansAkisiniSil(int IslemId)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = fm.FinansHareketiniSil(SessionManager.KullaniciId, IslemId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt Silindi";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "İşlem sırasında hata oluştu, Lütfen durumu sistem yöneticilerine bildiriniz...";
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


        [UserAuthorizeController]
        public ActionResult FinansHareketiGuncelle(int Tip, int IslemId)
        {
            if(Tip == 1)
            {
                ViewBag.GelirGiderTipleri = cm.IsletmeGelirGiderTipleriGetir("gelir");
            }
            else
            {
                ViewBag.GelirGiderTipleri = cm.IsletmeGelirGiderTipleriGetir("gider");
            }

            return View(fm.FinansHareketDetayiniGetir(SessionManager.KullaniciId, IslemId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult FinansalIslemGuncelle(GelirGiderModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = fm.FinansalIslemGuncelle(model, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt silindi";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt silme hata oluştu...";
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