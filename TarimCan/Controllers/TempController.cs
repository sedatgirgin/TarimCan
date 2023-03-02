using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarimCan.Helper;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class TempController : BaseController
    {
        // GET: Temp
        [UserAuthorizeController]
        public ActionResult Index()
        {
            return View();
        }

        [UserAuthorizeController]
        public ActionResult AnahtarKelimeGirisi()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult AnahtarKelimeKaydet(AnahtarKelimeModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            DBCheckModel dbC = cm.AnahtarKelimeKaydet(model, SessionManager.KullaniciId, helper.GetIPAddress());
            if (dbC.ReturnValue == 1)
            {
                srm.IsSuccess = true;
                srm.Message = "Kayıt başarılı...";
            }
            else if (dbC.ReturnValue == 2)
            {
                srm.IsSuccess = false;
                srm.Message = "Anahtar kelime girişi daha önce yapılmış...";
            }
            else
            {
                srm.IsSuccess = false;
                srm.Message = "Kayıt sırasında hata oluştu...";
            }

            return Json(srm, JsonRequestBehavior.AllowGet);
        }
    }
}