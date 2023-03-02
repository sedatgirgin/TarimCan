using System.Web.Mvc;
using TarimCan.Helper;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class ProfilController : BaseController
    {
        [UserAuthorizeController]
        public ActionResult Index()
        {
            ViewBag.Sehirler = cm.TumSehirleriGetir();
            ViewBag.AdresIlceler = cm.TumIlceleriGetir(SessionManager.SehirId);
            ViewBag.AdresMahalleler = cm.TumMahalleleriGetir(SessionManager.IlceId);
            return View(km.KullaniciBilgileriniGetir(SessionManager.KullaniciId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult ProfilBilgileriGuncelle(KullaniciModel model)
        {
            if (model.ImgBase64 != null)
            {
                string CovertedBase64DataUrl = model.ImgBase64.Substring(model.ImgBase64.LastIndexOf(',') + 1);
                string strPhotoName = helper.RandomString(10) + "." + helper.GetFileExtensionFromFileAsBase64(model.ImgBase64);
                helper.UyeResmiKaydet(CovertedBase64DataUrl, strPhotoName);
                model.ProfilResmi = strPhotoName;
            }

            DBCheckModel dbC = pm.KullaniciGuncelle(model, SessionManager.KullaniciId);
            SiteResponseModel srm = new SiteResponseModel();

            if (dbC.ReturnValue == 1)
            {
                srm.IsSuccess = true;
                srm.Message = "Kullanıcı Bilgileri Güncellendi";
                KullaniciModel kullanici = km.KullaniciBilgileriniGetir(SessionManager.KullaniciId);

                SessionManager.KullaniciSessionTemizle();
                SessionManager.KullaniciKaydet(kullanici);
            }
            else
            {
                srm.IsSuccess = false;
                srm.Message = "Hata Oluştu...";
            }

            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult IsletmePadoklariniGetir()
        {
            return Json(km.IsletmePadoklariniGetir(SessionManager.KullaniciId));
        } 

    }
}