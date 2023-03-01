using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class YemManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public DBCheckModel KabaYemStokEkle(KabaYemModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pYemTipId", 1)); // 1 Kaba - 2 Kesif
            lstParam.Add(new SqlParameter("@pYemId", model.YemId));
            lstParam.Add(new SqlParameter("@pYemAdi", model.YemAdi));
            lstParam.Add(new SqlParameter("@pStokHareketTipId", 1)); // 1 Giriş, 2 Çıkış
            lstParam.Add(new SqlParameter("@pStokGirisSekliId", model.StokGirisSekliId));
            lstParam.Add(new SqlParameter("@pStokGirisMiktariTon", model.StokGirisMiktariTon));
            lstParam.Add(new SqlParameter("@pBirimFiyati", model.BirimFiyati));
            lstParam.Add(new SqlParameter("@pToplamFiyat", model.ToplamFiyat));
            lstParam.Add(new SqlParameter("@pSatinAlmaTarihi", model.SatinAlmaTarihi));
            lstParam.Add(new SqlParameter("@pFaturaNo", model.FaturaNo));
            lstParam.Add(new SqlParameter("@pOdemeSekliId", model.OdemeSekliId));
            lstParam.Add(new SqlParameter("@pOdemeTarihi", model.OdemeTarihi));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_KabaYemStokEkle", lstParam);
        }

        public DBCheckModel KesifYemStokEkle(KesifYemModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pYemTipId", 2)); // 1 Kaba - 2 Kesif
            lstParam.Add(new SqlParameter("@pKesifYemId", model.KesifYemId));
            lstParam.Add(new SqlParameter("@pKesifYemUstId", model.KesifYemUstId));
            lstParam.Add(new SqlParameter("@pYemAdi", model.YemAdi));
            lstParam.Add(new SqlParameter("@pMarkasi", model.Markasi));
            lstParam.Add(new SqlParameter("@pStokHareketTipId", 1)); // 1 Giriş, 2 Çıkış
            lstParam.Add(new SqlParameter("@pStokGirisSekliId", model.StokGirisSekliId));
            lstParam.Add(new SqlParameter("@pBirimMiktarId", model.BirimMiktarId));
            lstParam.Add(new SqlParameter("@pSatinAlinanMiktar", model.SatinAlinanMiktar));
            lstParam.Add(new SqlParameter("@pBirimFiyat", model.BirimFiyat));
            lstParam.Add(new SqlParameter("@pToplamFiyat", model.ToplamFiyat));
            lstParam.Add(new SqlParameter("@pStokGirisTarihi", model.IslemTarihi));
            lstParam.Add(new SqlParameter("@pFaturaNo", model.FaturaNo));
            lstParam.Add(new SqlParameter("@pOdemeSekliId", model.OdemeSekliId));
            lstParam.Add(new SqlParameter("@pOdemeTarihi", model.OdemeTarihi));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_KesifYemStokEkle", lstParam);
        }

        public List<YemStoguModel> StokdakiYemleriGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pIslemTipId", 0));
            return sda.ExecuteObject<YemStoguModel>("sp_IsletmeYemStoklariGetir", lstParam);
        }

        public DBCheckModel RasyonOlustur(string RasyonAdi, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pRasyonAdi", RasyonAdi));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_RasyonAdiOlustur", lstParam);
        }

        public DBCheckModel RasyonSil(int RasyonId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pRasyonId", RasyonId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_RasyonSil", lstParam);
        }

        public DBCheckModel RasyonDetayOlustur(RasyonDetayModel model, int RasyonId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pRasyonId", RasyonId));
            lstParam.Add(new SqlParameter("@pYemTipId", model.YemTipId));
            lstParam.Add(new SqlParameter("@pYemId", model.YemId));
            lstParam.Add(new SqlParameter("@pYemMiktariKg", model.YemMiktariKg));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_RasyonDetayOlustur", lstParam);
        }

        public DBCheckModel RasyonDetayGuncelle(RasyonDetayModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pRasyonId", model.RasyonId));
            lstParam.Add(new SqlParameter("@pYemTipId", model.YemTipId));
            lstParam.Add(new SqlParameter("@pYemId", model.YemId));
            lstParam.Add(new SqlParameter("@pYemMiktariKg", model.YemMiktariKg));
            lstParam.Add(new SqlParameter("@pYemAdi", model.YemAdi));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_RasyonGuncelle", lstParam);
        }

        public DBCheckModel RasyonPadokEslestir(int RasyonId, int PadokId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pPadokId", RasyonId));
            lstParam.Add(new SqlParameter("@pRasyonId", PadokId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_RasyonPadokEslestir", lstParam);
        }

        public List<PadokModel> IsletmePadokRasyonGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<PadokModel>("sp_IsletmePadokRasyonGetir", lstParam);
        }

        public List<YemStoguModel> IsletmeYemStogonuGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pIslemTipId", 2));
            return sda.ExecuteObject<YemStoguModel>("sp_IsletmeYemStoklariGetir", lstParam);
        }

        public List<RasyonModel> IsletmeRasyonlariniGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<RasyonModel>("sp_IsletmeRasyonlariniGetir", lstParam);
        }

        public List<YemStoguModel> RasyonYemStoguGetir(int RasyonId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pRasyonId", RasyonId));
            return sda.ExecuteObject<YemStoguModel>("sp_IsletmeRasyonDetayiYemStoguGetir", lstParam);
        }

        public RasyonModel RasyonAdiGetir(int RasyonId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pRasyonId", RasyonId));
            return sda.ExcuteReturnObject<RasyonModel>("sp_RasyonAdiGetir", lstParam);
        }

        public List<YemStokHareketModel> YemStokHareketleriniGetir(int YemId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pYemId", YemId));
            return sda.ExecuteObject<YemStokHareketModel>("sp_YemStokHareketleriGetir", lstParam);
        }

        public DBCheckModel YemStokHareketiSil(int StokHareketId, int YemId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pStokHareketId", StokHareketId));
            lstParam.Add(new SqlParameter("@pYemId", YemId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_YemStokSil", lstParam);
        }
    }
}

