using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarimCan.Helper;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class MakinaEkipmanController : BaseController
    {
        // GET: MakinaEkipman
        [UserAuthorizeController]
        public ActionResult MakinaEkipmanEkle()
        {
            ViewBag.DemirbasTipi = cm.DemirbasTipleriGetir(2, SessionManager.KullaniciId);
            ViewBag.DemirbasYerleri = cm.DemirbasYerleriGetir(SessionManager.KullaniciId);
            ViewBag.MakinaEkipmanParkuru = mem.MakinaEkipmanListesiniGetir(SessionManager.KullaniciId);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult MakinaEkipmanEkleAction(MakinaEkipmanModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbCKontrol = mem.MakinaEkipmanKaydet(model, SessionManager.KullaniciId);

                if (dbCKontrol.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = dbCKontrol.ReturnMessage;
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
        public ActionResult MakinaEkipmanGuncelle(int Id)
        {
            ViewBag.DemirbasTipi = cm.DemirbasTipleriGetir(2, SessionManager.KullaniciId);
            ViewBag.DemirbasYerleri = cm.DemirbasYerleriGetir(SessionManager.KullaniciId);

            MakinaEkipmanModel model = mem.MakinaEkipmanDetayGetir(SessionManager.KullaniciId, Id);
            if (model == null)
                ViewBag.MakinaEkipmanId = 0;
            else
                ViewBag.MakinaEkipmanId = model.MakinaEkipmanId;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult MakinaEkipmanGuncelleAction(MakinaEkipmanModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbCKontrol = mem.MakinaEkipmanGuncelle(model, SessionManager.KullaniciId);

                if (dbCKontrol.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = dbCKontrol.ReturnMessage;
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