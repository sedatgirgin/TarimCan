using System.Web;
using System.Web.Mvc;
using TarimCan.Helper;

namespace TarimCan.Controllers
{
    public class UserAuthorizeController : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (!SessionManager.CheckSessionActive())
            {
                //httpContext.Response.Redirect("/Test/Index");
                httpContext.Response.Redirect("/Home/Login");
                return false;
            }
            else
            {
                //httpContext.Response.Redirect("/Test/Index");
                return true;
            }

        }

    }
}