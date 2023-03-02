using System.Web.Mvc;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class TanimlamalarController : BaseController
    {
        [UserAuthorizeController]
        public ActionResult Index()
        {
            return View();
        }

        [UserAuthorizeController]
        public ActionResult HayvanIrklari()
        {
            return View(tm.TumHayvanIrklariniGetir());
        }

        [UserAuthorizeController]
        public JsonResult HayvanIrklariAction(int IslemId, int Id, string Value)
        {
            //DBCheckModel model = new DBCheckModel();

            DBCheckModel model = tm.HayvanIrkıIslemleri(IslemId, Id, Value);

            if (model.ReturnValue == 1)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [UserAuthorizeController]
        public ActionResult SuruGruplari()
        {
            return View(tm.TumHayvanSuruGruplariniGetir());
        }

        [UserAuthorizeController]
        public JsonResult SuruGruplariAction(int IslemId, int Id, string Value)
        {
            //DBCheckModel model = new DBCheckModel();

            DBCheckModel model = tm.HayvanSuruGrubuIslemleri(IslemId, Id, Value);

            if (model.ReturnValue == 1)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [UserAuthorizeController]
        public ActionResult RutinIslemler()
        {
            ViewBag.DurumBilgileri = cm.TumDurumBilgileriniGetir();
            return View();
        }


        [UserAuthorizeController]
        [HttpPost]
        public JsonResult RutinIslemlerAction(int DurumBilgisiId)
        {
            return Json(tm.RutinIslemiDurumTipineGoreGetir(DurumBilgisiId));
        }

        [UserAuthorizeController]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult RutinIslemEkleAction(RutinIslemModel model)
        {
            //DBCheckModel model = new DBCheckModel();

            //DBCheckModel dbc = tm.RutinIslemEkle(model);

            //if (dbc.ReturnValue == 1)
            //{
            //    return Json(true);
            //}
            //else
            //{
            //    return Json(false);
            //}
            return Json(false);
        }

        [UserAuthorizeController]
        public ActionResult DurumBilgisi()
        {
            return View();
        }

        [UserAuthorizeController]
        public ActionResult HayvanStatuleri()
        {
            return View();
        }
    }
}