using System.Web.Mvc;
using TarimCan.Helper;

namespace TarimCan.Controllers
{
    public class DemirbasController : BaseController
    {
        // GET: Demirbas
        [UserAuthorizeController]
        public ActionResult DemirbasEkle()
        {
            ViewBag.DemirbasTipi = cm.DemirbasTipleriGetir(2, SessionManager.KullaniciId);
            ViewBag.DemirbasYerleri = cm.DemirbasYerleriGetir(SessionManager.KullaniciId);
            return View();
        }
    }
}