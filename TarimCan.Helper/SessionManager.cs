using System;
using System.Collections.Generic;
using System.Web;
using TarimCan.Models;

namespace TarimCan.Helper
{
    public static class SessionManager
    {

        public static void KullaniciKaydet(KullaniciModel model)
        {
            HttpContext.Current.Session["KullaniciId"] = model.Id;
            HttpContext.Current.Session["ProfilResmi"] = model.ProfilResmi;
            HttpContext.Current.Session["IsimSoyisim"] = model.IsimSoyisim;
            HttpContext.Current.Session["Email"] = model.Email;
            HttpContext.Current.Session["CepTelefonu"] = model.CepTelefonu;
            HttpContext.Current.Session["IsletmeAdi"] = model.IsletmeAdi;
            HttpContext.Current.Session["IsletmeKayitNo"] = model.IsletmeKayitNo;
            HttpContext.Current.Session["HayvanTohumlamaAyi"] = model.HayvanTohumlamaAyi;
            HttpContext.Current.Session["AdminMi"] = model.AdminMi;
            HttpContext.Current.Session["SehirId"] = model.SehirId;
            HttpContext.Current.Session["IlceId"] = model.IlceId;
            HttpContext.Current.Session["MahalleId"] = model.MahalleId;
        }

        public static KullaniciModel AktifKullanici
        {
            get
            {
                return HttpContext.Current.Session["SehirId"] as KullaniciModel;
            }
        }

        public static int SehirId
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session["SehirId"]);
            }
        }

        public static int IlceId
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session["IlceId"]);
            }
        }

        public static int MahalleId
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session["MahalleId"]);
            }
        }

        public static bool AdminMi
        {
            get
            {
                return Convert.ToBoolean(HttpContext.Current.Session["AdminMi"]);
            }
        }

        public static void HayvanTohumlamaAyiKaydet(int HayvanTohumlamaAyi)
        {
            HttpContext.Current.Session["HayvanTohumlamaAyi"] = HayvanTohumlamaAyi;
        }

        public static int KullaniciId
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session["KullaniciId"]);
            }
        }

        public static int HayvanTohumlamaAyi
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session["HayvanTohumlamaAyi"]);
            }
        }

        public static string ProfilResmi
        {
            get
            {
                if (HttpContext.Current.Session["ProfilResmi"] != null)
                {
                    return HttpContext.Current.Session["ProfilResmi"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        public static string IsimSoyisim
        {
            get
            {
                return HttpContext.Current.Session["IsimSoyisim"].ToString();
            }
        }

        public static void KullaniciSessionTemizle()
        {
            HttpContext.Current.Session["KullaniciId"] = 0;
            HttpContext.Current.Session["HayvanTohumlamaAyi"] = 0;
            HttpContext.Current.Session["ProfilResmi"] = null;
            HttpContext.Current.Session["IsimSoyisim"] = null;
        }

        public static bool CheckSessionActive()
        {
            bool durum = false;

            if (KullaniciId != 0)
            {
                durum = true;
            }

            return durum;
        }

    }
}