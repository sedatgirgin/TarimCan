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
            SetVaccineViewBag();
            SetRepeatsViewBag();
            return View(asiMan.Select(SessionManager.KullaniciId));
        }

        [ValidateAntiForgeryToken()]
        public JsonResult Insert(string asiAdi, string ticariAdi, int tekrar, bool rabel, int cinsiyet, string sonUygulanacagiTarih)
        {
            Asi asi = new Asi();
            asi.IsletmeId = SessionManager.KullaniciId;
            asi.Aktif = true;
            asi.AsiAdi = asiAdi;
            asi.TicariAdi = ticariAdi;
            asi.Rapel = rabel;
            asi.Cinsiyet = cinsiyet;
            asi.SonUygulanacagiTarih = DateTime.Now;

            return Json(asiMan.Insert(asi));
        }

        private void SetVaccineViewBag()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Value = "Enterotoksemi(KARMA, MERA)", Text = "Enterotoksemi(KARMA, MERA)" });
            items.Add(new SelectListItem() { Value = "Şap", Text = "Şap" });
            items.Add(new SelectListItem() { Value = "IBR–BVD–PI–BRS", Text = "IBR–BVD–PI–BRS" });
            items.Add(new SelectListItem() { Value = "BRD–BRSV", Text = "BRD–BRSV" });
            items.Add(new SelectListItem() { Value = "Pastörella", Text = "Pastörella" });
            items.Add(new SelectListItem() { Value = "Botulismus", Text = "Botulismus" });
            items.Add(new SelectListItem() { Value = "Çiçek(LSD)", Text = "Çiçek(LSD)" });
            items.Add(new SelectListItem() { Value = "Brucella", Text = "Brucella" });
            items.Add(new SelectListItem() { Value = "Leptospiroz", Text = "Leptospiroz" });
            items.Add(new SelectListItem() { Value = "Yanıkara", Text = "Yanıkara" });
            items.Add(new SelectListItem() { Value = "Şarbon", Text = "Şarbon" });
            items.Add(new SelectListItem() { Value = "Septisemi", Text = "Septisemi" });
            items.Add(new SelectListItem() { Value = "Kuduz", Text = "Kuduz" });
            items.Add(new SelectListItem() { Value = "Theileria", Text = "Theileria" });
            items.Add(new SelectListItem() { Value = "Trikofiti(Mantar)", Text = "Trikofiti(Mantar)" });
            items.Add(new SelectListItem() { Value = "Diğer", Text = "Diğer" });
            ViewBag.asilar = items;
        }
        private void SetRepeatsViewBag()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            for (int i = 1; i < 13; i++)
            {
                items.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });

            }
            ViewBag.Repeats = items;
        }

    }
}
