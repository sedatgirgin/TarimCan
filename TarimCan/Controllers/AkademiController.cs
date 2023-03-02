using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class AkademiController : BaseController
    {

        // GET: Akademi
        [UserAuthorizeController]
        public ActionResult Index()
        {
            ViewBag.TumVideolar = akM.AkademiVideoGetir();
            ViewBag.OynatmaListesiKategorileri = akM.OynatmaListesiKategorileriGetir();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult OynatmaListesineGoreVideoGetir(int KategoriId)
        {

            return Json(akM.KategoriyeGoreVideoGetir(KategoriId), JsonRequestBehavior.AllowGet);
        }

        // GET: Akademi
        [UserAuthorizeController]
        public ActionResult Detay(int id)
        {
            AkademiModel model = akM.VideoDetayGetir(id);
            ViewBag.DigerVideolar = akM.KategoriyeGoreVideoGetir(model.OynatmaListesiId);
            return View(model);
        }

    }
}