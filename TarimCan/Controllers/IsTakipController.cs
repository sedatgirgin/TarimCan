using System;
using System.Web.Mvc;
using TarimCan.Helper;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class IsTakipController : BaseController
    {
        // GET: IsTakip
        [UserAuthorizeController]
        public ActionResult Index(int id = 0)
        {
            if (!SessionManager.AdminMi)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(itm.TumIsListesiniGetir(id));
        }

        // GET: IsTakip
        [UserAuthorizeController]
        public ActionResult IsEkle()
        {
            if (!SessionManager.AdminMi)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: IsTakip
        [UserAuthorizeController]
        public ActionResult IsDetay(int id = 0)
        {
            if (!SessionManager.AdminMi)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Kategoriler = cm.IsTakipKategorileriGetir();
            ViewBag.IsTakipId = id;

            IsTakipModel model = itm.IsDetayGetir(id);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public JsonResult IsKaydet(IsTakipModel model, string SelectedFileName)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                if (model.Base64File != null)
                {
                    model.EkliDosyaAdi = helper.IsTakipDokumanKaydet(model.Base64File, SelectedFileName.Split('.')[1]);
                }

                DBCheckModel dbC = itm.IsKaydet(model, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt Başarılı";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt Sırasında Hata Oluştu";
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

        [ValidateAntiForgeryToken]
        public JsonResult IsGuncelle(IsTakipModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = itm.IsGuncelle(model);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt Başarılı";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt Sırasında Hata Oluştu";
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