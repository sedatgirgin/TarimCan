using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TarimCan.Controllers
{
    public class StokController : Controller
    {
        // GET: Stok
        [UserAuthorizeController]
        public ActionResult StokListesi()
        {
            return View();
        }
    }
}