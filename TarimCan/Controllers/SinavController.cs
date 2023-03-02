using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TarimCan.Controllers
{
    public class SinavController : Controller
    {
        // GET: Sinav
        [UserAuthorizeController]
        public ActionResult Index()
        {
            return View();
        }
    }
}