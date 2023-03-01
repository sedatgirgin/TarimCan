using System.Collections.Generic;
using System.Data.SqlClient;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class KullaniciManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public KullaniciModel KullaniciEmailIleGirisKontrol(string UserName, string Password)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_Email", UserName));
            lstParam.Add(new SqlParameter("@p_Sifre", Password));
            return sda.ExcuteReturnObject<KullaniciModel>("sp_KullaniciGiris", lstParam);
        }

        public KullaniciModel KullaniciBilgileriniGetir(int KullaniciId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKullaniciId", KullaniciId));
            return sda.ExcuteReturnObject<KullaniciModel>("sp_KullaniciBilgileriniGetir", lstParam);
        }

        public KullaniciModel KullaniciTelefonNoIleGirisKontrol(string UserName, string Password)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_CepTel", UserName));
            lstParam.Add(new SqlParameter("@p_Sifre", Password));
            return sda.ExcuteReturnObject<KullaniciModel>("sp_KullaniciGiris", lstParam);
        }

        public KullaniciModel KullaniciKayitEt(KullaniciModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_Email", model.Email));
            lstParam.Add(new SqlParameter("@p_Sifre", model.Sifre));
            lstParam.Add(new SqlParameter("@p_IsimSoyisim", model.IsimSoyisim));
            lstParam.Add(new SqlParameter("@p_CepTelefonu", model.CepTelefonu));
            return sda.ExcuteReturnObject<KullaniciModel>("sp_KullaniciKaydet", lstParam);
        } 

        public KullaniciModel SGSDegeriGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExcuteReturnObject<KullaniciModel>("sp_SGSDegeriGetir", lstParam);
        }

        public List<PadokModel> IsletmePadoklariniGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<PadokModel>("sp_IsletmePadoklariniGetir", lstParam);
        }

        public DBCheckModel HayvanTohumlanmaAyiGuncelle(int HayvanTohumlamaAyi, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKullaniciId", IsletmeId));
            lstParam.Add(new SqlParameter("@pTohumlanmaAyi", HayvanTohumlamaAyi));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_TohumlanmaAyiEkle", lstParam);
        }
    }
}