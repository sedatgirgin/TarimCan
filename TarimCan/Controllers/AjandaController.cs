using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TarimCan.Helper;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class AjandaController : BaseController
    {
        // GET: Ajanda
        [UserAuthorizeController]
        public ActionResult Index(int id = 0, int index = 0)
        {
            List<AjandaModel> model = new List<AjandaModel>();
            model = ajanda.TumGorevleriGetir(SessionManager.KullaniciId, id, index);
            return View(model);
        }

        // GET: Ajanda
        [UserAuthorizeController]
        public ActionResult TamamlananGorevler(int id = 0, int index = 0)
        {
            List<AjandaModel> model = new List<AjandaModel>();
            model = ajanda.TamamlananGorevleriGetir(SessionManager.KullaniciId, id, index);
            return View(model);
        }

        // GET: Ajanda
        [UserAuthorizeController]
        public ActionResult HayvanGorevDetay(int id = 0, int index = 0)
        {
            List<AjandaModel> model = new List<AjandaModel>();
            model = ajanda.HayvanaAitTumGorevleriGetir(SessionManager.KullaniciId, id, index);
            return View(model);
        }

        // GET: Ajanda
        [UserAuthorizeController]
        public ActionResult YeniGorev()
        {
            ViewBag.Hayvanlar = cm.TumHayvanlariSelectListOlarakGetir(SessionManager.KullaniciId);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult GorevEkleAction(AjandaModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = ajanda.AjandaGorevKaydet(model, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else if (dbC.ReturnValue == 2)
                {
                    srm.IsSuccess = false;
                    srm.Message = dbC.ReturnMessage;
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
        public JsonResult GorevTamamlaAction(int AjandaId, string IslemNotu)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = ajanda.GorevTamamla(AjandaId, IslemNotu, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Görev Tamamlandı...";
                } 
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Görev tamamlanma sırasında hata oluştu...";
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