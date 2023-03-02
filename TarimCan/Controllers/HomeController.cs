using System.Web.Mvc;
using TarimCan.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using TarimCan.Helper;

namespace TarimCan.Controllers
{
    public class HomeController : BaseController
    {
        EncryptionManager em = new EncryptionManager();

        [UserAuthorizeController]
        public ActionResult Index()
        {
            hm.HayvanSuruGruplariniGuncell(SessionManager.KullaniciId);

            //AnaSayfaIsletmeDurumModel isletmeDurumuFinans = fm.IsletmeGelirGiderOzetGetir(SessionManager.KullaniciId);
            //ViewBag.IsletmeGelirleri = String.Format("{0:0,0}", isletmeDurumuFinans.IsletmeGelirleri);
            //ViewBag.IsletmeGiderleri = String.Format("{0:0,0}", isletmeDurumuFinans.IsletmeGiderleri);
            //ViewBag.IsletmeKarZarar = String.Format("{0:0,0}", isletmeDurumuFinans.IsletmeKarZarar);

            //ViewBag.SGSDegeri = km.SGSDegeriGetir().SGSDegeri;
            AnaSayfaIsletmeDurumModel isletmeDurumu = cm.AnaSayfaIsletmeDurumuGetir(SessionManager.KullaniciId);
            ViewBag.SGSDegeri = isletmeDurumu.SGSDegeri;

            AnaSayfaIsletmeDurumModel gelirGiderModel = fm.IsletmeGelirGiderOzetGetir(SessionManager.KullaniciId);
            ViewBag.IsletmeGelirleri = String.Format("{0:0,0}", gelirGiderModel.IsletmeGelirleri);
            ViewBag.IsletmeGiderleri = String.Format("{0:0,0}", gelirGiderModel.IsletmeGiderleri);
            ViewBag.IsletmeKarZarar = String.Format("{0:0,0}", (isletmeDurumu.IsletmeGelirleri - isletmeDurumu.IsletmeGiderleri));

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult LoginAction(string KullaniciAdi, string Sifre)
        {
            SiteResponseModel srm = new SiteResponseModel();

            if (KullaniciAdi != "" && Sifre != "")
            {
                KullaniciModel kullanici = new KullaniciModel();

                if (helper.IsValidEmail(KullaniciAdi))
                {
                    kullanici = km.KullaniciEmailIleGirisKontrol(KullaniciAdi, em.GenerateMd5(Sifre));
                    if (kullanici.ReturnValue == 1)
                    {
                        SessionManager.KullaniciKaydet(kullanici);
                        srm.IsSuccess = true;
                    }
                    else
                    {
                        srm.IsSuccess = false;
                        srm.Message = "Kullanıcı Adı Şifre Hatalı...";
                    }
                }
                else if (helper.IsDigitsOnly(KullaniciAdi))
                {
                    kullanici = km.KullaniciTelefonNoIleGirisKontrol(KullaniciAdi, em.GenerateMd5(Sifre));
                    if (kullanici.ReturnValue == 1)
                    {
                        SessionManager.KullaniciKaydet(kullanici);
                        srm.IsSuccess = true;

                        hm.HayvanSuruGruplariniGuncell(SessionManager.KullaniciId);
                    }
                    else
                    {
                        srm.IsSuccess = false;
                        srm.Message = "Kullanıcı Adı Şifre Hatalı...";
                    }
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Girmiş olduğunuz bilgileri kontrol ediniz";
                }
            }
            else
            {
                srm.IsSuccess = false;
                srm.Message = "Lütfen tüm alanları doldurun...";
            }

            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut()
        {
            SessionManager.KullaniciSessionTemizle();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult RegisterAction(KullaniciModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();
            if (model.Sifre == model.SifreTekrar)
            {
                model.Sifre = em.GenerateMd5(model.Sifre);
                KullaniciModel kullanici = km.KullaniciKayitEt(model);

                if (kullanici.ReturnValue == 1)
                {
                    SessionManager.KullaniciKaydet(kullanici);
                    srm.IsSuccess = true;
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Bu mail adresi sistemde kayıtlı. Lütfen giriş yapınız...";
                }
            }
            else
            {
                srm.IsSuccess = false;
                srm.Message = "Şifreler Eşleşmiyor...";
            }

            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult PadoklariGetir()
        {
            List<PadokModel> padoklar = new List<PadokModel>();
            padoklar = km.IsletmePadoklariniGetir(SessionManager.KullaniciId);
            return Json(padoklar, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanSayilariniGetir()
        {
            AnaSayfaIsletmeDurumModel model = new AnaSayfaIsletmeDurumModel();
            model = cm.AnaSayfaOzetGetir(SessionManager.KullaniciId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    
    }
}