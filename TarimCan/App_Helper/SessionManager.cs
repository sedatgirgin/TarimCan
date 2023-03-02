using System.Collections.Generic;
using System.Web;
using TarimCan.Models;

namespace TarimCan.App_Helper
{
    public static class SessionManager
    {

        public static void KullaniciKaydet(KullaniciModel kullanici)
        {
            HttpContext.Current.Session["Kullanici"] = kullanici;
        }

        public static KullaniciModel AktifKullanici
        {
            get
            {
                return HttpContext.Current.Session["Kullanici"] as KullaniciModel;
            }
        }

        public static void KullaniciSessionTemizle()
        {
            HttpContext.Current.Session["Kullanici"] = null;
            HttpContext.Current.Session["KullaniciMenuer"] = null;
        }

        public static bool CheckSessionActive()
        {
            bool durum = false;

            if (AktifKullanici != null)
            {
                durum = true;
            }

            return durum;
        }

    }
}