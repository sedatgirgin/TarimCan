using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class SutManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public DBCheckModel GunlukSutSatisiKaydet(SutModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pTopluLitreFiyati", model.TopluLitreFiyati));
            lstParam.Add(new SqlParameter("@pGunlukTopluSatisMiktari", model.GunlukTopluSatisMiktari));
            lstParam.Add(new SqlParameter("@pPerakendeLitreFiyati", model.PerakendeLitreFiyati));
            lstParam.Add(new SqlParameter("@pPerakendeSatisMiktari", model.PerakendeSatisMiktari));
            lstParam.Add(new SqlParameter("@pBuzagiIctigiToplamLitre", model.BuzagiIctigiToplamLitre));
            lstParam.Add(new SqlParameter("@pIslemTarihi", model.IslemTarihi));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_GunlukSutSatisiKaydet", lstParam);
        }

        public SutModel GunlukSutSatislariGetir(DateTime IslemZamani, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pIslemTarihi", IslemZamani));
            return sda.ExcuteReturnObject<SutModel>("sp_GunlukSutSatisiGetir", lstParam);
        }

        public List<SutModel> GecmisSutOzetiniGetir(int GunSayisi, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pGunSayisi", GunSayisi));
            return sda.ExecuteObject<SutModel>("sp_SutOzetiGecmisiGetir", lstParam);
        }

        public DBCheckModel GunlukSutUrunleriKaydet(SutUrunleriModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pPeynirMiktarKg", model.PeynirMiktarKg));
            lstParam.Add(new SqlParameter("@pPeynirKullanilanSutKg", model.PeynirKullanilanSutKg));
            lstParam.Add(new SqlParameter("@pPeynirSatisFiyati", model.PeynirSatisFiyati));
            lstParam.Add(new SqlParameter("@pPeynirToplamFiyat", model.PeynirToplamFiyat));
            lstParam.Add(new SqlParameter("@pYogurtMiktarKg", model.YogurtMiktarKg));
            lstParam.Add(new SqlParameter("@pYogurtKullanilanSutKg", model.YogurtKullanilanSutKg));
            lstParam.Add(new SqlParameter("@pYogurtSatisFiyati", model.YogurtSatisFiyati));
            lstParam.Add(new SqlParameter("@pYogurtToplamFiyat", model.YogurtToplamFiyat));
            lstParam.Add(new SqlParameter("@pTereyagMiktarKg", model.TereyagMiktarKg));
            lstParam.Add(new SqlParameter("@pTereyagKullanilanSutKg", model.TereyagKullanilanSutKg));
            lstParam.Add(new SqlParameter("@pTereyagSatisFiyati", model.TereyagSatisFiyati));
            lstParam.Add(new SqlParameter("@pTereyagToplamFiyat", model.TereyagToplamFiyat));
            lstParam.Add(new SqlParameter("@pDigerMiktarKg", model.DigerMiktarKg));
            lstParam.Add(new SqlParameter("@pDigerKullanilanSutKg", model.DigerKullanilanSutKg));
            lstParam.Add(new SqlParameter("@pDigerSatisFiyati", model.DigerSatisFiyati));
            lstParam.Add(new SqlParameter("@pDigerToplamFiyat", model.DigerToplamFiyat));
            lstParam.Add(new SqlParameter("@pIslemTarihi", model.IslemTarihi));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_GunlukSutUrunleriEkle", lstParam);
        }

        public SutUrunleriModel GunlukSutUrunleriniGetir(DateTime IslemZamani, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pIslemTarihi", IslemZamani));
            return sda.ExcuteReturnObject<SutUrunleriModel>("sp_GunlukSutUrunleriGetir", lstParam);
        }

        public List<SutModel> SutSatisListesiGetir(int GunSayisi, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pGunSayisi", GunSayisi));
            return sda.ExecuteObject<SutModel>("sp_GunlukSutSatisBilgileriGetir", lstParam);
        }

        public DBCheckModel SagilanHayvanKaydet(SutModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", model.HayvanId));
            lstParam.Add(new SqlParameter("@pSabahSutu", model.SabahSutMiktari));
            lstParam.Add(new SqlParameter("@pOglenSutu", model.OglenSutMiktari));
            lstParam.Add(new SqlParameter("@pAksamSutu", model.AksamSutMiktari));
            lstParam.Add(new SqlParameter("@pToplamSutMiktari", (model.SabahSutMiktari + model.OglenSutMiktari + model.AksamSutMiktari)));
            lstParam.Add(new SqlParameter("@pLitreFiyati", model.LitreFiyati));
            lstParam.Add(new SqlParameter("@pIslemTarihi", model.IslemTarihi));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_GunlukSutSagilanHayvanKaydet", lstParam);
        }

        public List<SutModel> GunlukSutSatisOzetiGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<SutModel>("sp_GunlukSutSatisOzetiGetir", lstParam);
        }

        public List<SutModel> GunlukSagilanHayvanlariGetir(DateTime IslemTarihi, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pIslemTarihi", IslemTarihi));
            return sda.ExecuteObject<SutModel>("sp_GunlukSagilanHayvanlariGetir", lstParam);
        }

        public List<SutModel> SagmalHayvanlariGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            lstParam.Add(new SqlParameter("@pSuruGrubuId", 0));
            lstParam.Add(new SqlParameter("@pDurumOzetiId", 20));
            return sda.ExecuteObject<SutModel>("sp_SurudekiHayvanlariSahibineGoreGetir", lstParam);
        }

        public decimal SonSutLitreFiyatiGetir(int IsletmeId)
        {
            decimal sonuc = 0;
            DataTable dt = sda.GetDataTable("Select Top 1 LitreFiyati From GunlukSutSagilanHayvanlar Where IsletmeId = " + IsletmeId + " Order By IslemZamani Desc");
            if (dt.Rows.Count > 0)
            {
                sonuc = Convert.ToDecimal(dt.Rows[0][0]);
            }
            return sonuc;
        }

    }
}