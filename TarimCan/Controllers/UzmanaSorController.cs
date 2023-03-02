using System.Web.Mvc;
using TarimCan.Helper;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class UzmanaSorController : BaseController
    {
        // GET: UzmanaSor
        [UserAuthorizeController]
        public ActionResult Index()
        {
            ViewBag.Sorular = usm.KullaniciyaGoreTumSorulariGetir(SessionManager.KullaniciId);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult UzmanaSorKaydetAction(UzmanaSorModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            DBCheckModel dbC = usm.UzmanaSorKaydet(model, SessionManager.KullaniciId, helper.GetIPAddress());
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

            return Json(srm, JsonRequestBehavior.AllowGet);
        }
    }
}