using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TarimCan.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        [UserAuthorizeController]
        public ActionResult Index()
        {
            return View();
        }


        // GET: Test
        [UserAuthorizeController]
        public ActionResult adsasdasd()
        {
            return View();
        }
    }
}