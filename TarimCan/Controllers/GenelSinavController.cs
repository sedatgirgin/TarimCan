using System.Web.Mvc;
using TarimCan.DataAccessLayer;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class GenelSinavController : Controller
    {
        CommonManager cm = new CommonManager();

        // GET: GenelSinav
        public ActionResult Index()
        {
            Response.Headers.Remove("X-Frame-Options");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult TcKimlikNodanSinavSorgula(long TCKimlikNo)
        {
            SiteResponseModel srm = new SiteResponseModel();
            SinavSonucuModel ssm = cm.SinavSonucuGetir(TCKimlikNo);

            if (ssm != null)
            {
                srm.IsSuccess = true;
                srm.Message = " Sayın <strong> " + ssm.AdiSoyadi + " </strong> <br /> <br /> Durumunuz: " + ssm.Durumu;

                //srm.Message = " Sayın <strong> " + ssm.AdiSoyadi + " </strong> <br /> <br /> Almış olduğunuz sınav sonucunuz: <strong>" + ssm.SinavSonucu + "</strong> <br /> Başarı Durumunuz: " + ssm.Durumu;

                if (ssm.Durumu == "BAŞARILI")
                {
                    srm.Message += "<br /><br /><a href=\"" + ssm.SertifikaPath + "\" target=\"_blank\"> Sertifikanızı indirmek için tıklayınız...</a>";
                }

            }
            else
            {
                srm.IsSuccess = false;
                srm.Message = "Sınav sonucu bulunamadı... Lütfen bilgilerinizi kontrol ediniz...";
            }
            return Json(srm);
        }

    }
}