    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TarimCan.Controllers
{
    public class YardimController : BaseController
    {
        // GET: Yardim
        [UserAuthorizeController]
        public ActionResult Talep()
        {
            ViewBag.Sehirler = cm.TumSehirleriGetir();
            return View();
        }
    }
}