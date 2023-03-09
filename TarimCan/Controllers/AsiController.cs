using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TarimCan.Helper;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class AsiController : BaseController
    {
        [UserAuthorizeController]
        public ActionResult Index()
        {
            return View(asiMan.Select(SessionManager.KullaniciId));
        }

        [ValidateAntiForgeryToken()]
        public JsonResult Insert(string asiAdi, string ticariAdi, int tekrar, int rabel, int cinsiyet, string sonUygulandıgiTarih)
        {
            Asi asi = new Asi();
            asi.IsletmeId = SessionManager.KullaniciId;
            asi.Aktif = true;
            asi.AsiAdi = asiAdi;
            asi.TicariAdi = ticariAdi;
            asi.Rapel = rabel==0?false:true;
            asi.Cinsiyet = cinsiyet;
            asi.AsininUygulamaTekrari = tekrar;
            asi.SonUygulanacagiTarih = DateTime.Parse(sonUygulandıgiTarih);

            return Json(asiMan.Insert(asi));
        }

        [ValidateAntiForgeryToken()]
        public JsonResult Update(int id, int active)
        {
            return Json(asiMan.Update(id, active==0?false:true));
        }

        [ValidateAntiForgeryToken()]
        public JsonResult Delete(int id)
        {
            return Json(asiMan.Delete(id));
        }
    }
}
