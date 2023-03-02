using System.Collections.Generic;
using System.Data.SqlClient;
using TarimCan.App_Helper;
using TarimCan.Models;

namespace SuruTakip.DataAccessLayer
{
    public class KullaniciManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();
        EncryptionManager em = new EncryptionManager();

        public KullaniciModel KullaniciEmailIleGirisKontrol(string UserName, string Password)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_Email", UserName));
            lstParam.Add(new SqlParameter("@p_Sifre", em.GenerateMd5(Password)));
            return sda.ExcuteReturnObject<KullaniciModel>("sp_KullaniciGiris", lstParam);
        }

        public KullaniciModel KullaniciTelefonNoIleGirisKontrol(string UserName, string Password)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_CepTel", UserName));
            lstParam.Add(new SqlParameter("@p_Sifre", em.GenerateMd5(Password)));
            return sda.ExcuteReturnObject<KullaniciModel>("sp_KullaniciGiris", lstParam);
        }

        public KullaniciModel KullaniciKayitEt(KullaniciModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_Email", model.Email));
            lstParam.Add(new SqlParameter("@p_Sifre", em.GenerateMd5(model.Sifre)));
            lstParam.Add(new SqlParameter("@p_IsimSoyisim", model.IsimSoyisim));
            lstParam.Add(new SqlParameter("@p_CepTelefonu", model.CepTelefonu));
            return sda.ExcuteReturnObject<KullaniciModel>("sp_KullaniciKaydet", lstParam);
        }

        public List<AjandaModel> KullaniciGorevleriniGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKullaniciId", SessionManager.AktifKullanici.Id));
            return sda.ExecuteObject<AjandaModel>("sp_AjandaGorevleriGetir", lstParam);
        }

        public KullaniciModel SGSDegeriGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", SessionManager.AktifKullanici.Id));
            return sda.ExcuteReturnObject<KullaniciModel>("sp_SGSDegeriGetir", lstParam);
        }

    }
}