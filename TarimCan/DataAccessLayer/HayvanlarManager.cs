using SuruTakip.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TarimCan.App_Helper;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class HayvanlarManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public List<HayvanModel> SurudekiHayvanlariSahibineGoreGetir(int SahipId, int SuruGrubuId, int DurumOzetiId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SahipId));
            lstParam.Add(new SqlParameter("@pSuruGrubuId", SuruGrubuId));
            lstParam.Add(new SqlParameter("@pDurumOzetiId", DurumOzetiId));
            return sda.ExecuteObject<HayvanModel>("sp_SurudekiHayvanlariSahibineGoreGetir", lstParam);
        }

        public HayvanModel HayvanDetayiSahibineGoreGetir(int HayvanId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            return sda.ExcuteReturnObject<HayvanModel>("sp_HayvanDetayiSahibineGoreGetir", lstParam);
        }

        public List<DurumHareketModel> HayvanDurumHareketleriGetir(int HayvanId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            return sda.ExecuteObject<DurumHareketModel>("sp_HayvanDurumHareketleriniGetir", lstParam);
        }

        public DBCheckModel HayvanKaydet(HayvanModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pKupeNo", model.KupeNo));
            lstParam.Add(new SqlParameter("@pAdi", model.Adi));
            lstParam.Add(new SqlParameter("@pCinsiyetId", model.CinsiyetId));
            lstParam.Add(new SqlParameter("@pIrkId", model.IrkId));
            lstParam.Add(new SqlParameter("@pDogumTarihi", model.DogumTarihi));
            lstParam.Add(new SqlParameter("@pSuruyeGirisTarihi", model.SuruyeGirisTarihi));
            lstParam.Add(new SqlParameter("@pSuruyeGirisTipId", model.SuruyeGirisTipId));
            lstParam.Add(new SqlParameter("@pAnneKupeNo", model.AnneKupeNo));
            lstParam.Add(new SqlParameter("@pBabaKupeNo", model.BabaKupeNo));
            lstParam.Add(new SqlParameter("@pSuruGrubuId", model.SuruGrubuId));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            lstParam.Add(new SqlParameter("@pFotograf", model.Fotograf));
            lstParam.Add(new SqlParameter("@pDurumBilgisiId", model.DurumBilgisiId));
            lstParam.Add(new SqlParameter("@pDogumGucMu", model.DogumGucMu));
            lstParam.Add(new SqlParameter("@pPadokId", model.PadokId));
            lstParam.Add(new SqlParameter("@pGebelikDurumId", model.GebelikDurumId));
            lstParam.Add(new SqlParameter("@pSuruyeGirisDurumId", model.SuruyeGirisDurumId));
            lstParam.Add(new SqlParameter("@pTohumlanmaTarihi", model.TohumlanmaTarihi));
            lstParam.Add(new SqlParameter("@pSonDogumYaptigiTarih", model.SonDogumYaptigiTarih));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanEkle", lstParam);
        }

        public DBCheckModel HayvanGuncelle(HayvanModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pId", model.Id));
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pKupeNo", model.KupeNo));
            lstParam.Add(new SqlParameter("@pAdi", model.Adi));
            lstParam.Add(new SqlParameter("@pCinsiyetId", model.CinsiyetId));
            lstParam.Add(new SqlParameter("@pIrkId", model.IrkId));
            lstParam.Add(new SqlParameter("@pDogumTarihi", model.DogumTarihi));
            lstParam.Add(new SqlParameter("@pSuruyeGirisTarihi", model.SuruyeGirisTarihi));
            lstParam.Add(new SqlParameter("@pSuruyeGirisTipId", model.SuruyeGirisTipId));
            lstParam.Add(new SqlParameter("@pAnneKupeNo", model.AnneKupeNo));
            lstParam.Add(new SqlParameter("@pBabaKupeNo", model.BabaKupeNo));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            lstParam.Add(new SqlParameter("@pFotograf", model.Fotograf));
            lstParam.Add(new SqlParameter("@pPadokId", model.PadokId));
            lstParam.Add(new SqlParameter("@pSonDogumYaptigiTarih", DateTime.Parse(model.SonDogumYaptigiTarihFormatted)));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanGuncelle", lstParam);
        }

        public List<RutinIslemModel> HayvanRutinIslemleriniGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            return sda.ExecuteObject<RutinIslemModel>("sp_HayvanRutinIslemleriGetir", lstParam);
        }

        public List<RutinIslemModel> HaftalikHayvanRutinIslemleriniGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pHaftalikMi", true));
            return sda.ExecuteObject<RutinIslemModel>("sp_HayvanRutinIslemleriGetir", lstParam);
        }

        public DBCheckModel HayvanDurumHereketiEkle(DurumHareketModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pHayvanId", model.HayvanId));
            lstParam.Add(new SqlParameter("@pDurumBilgisiId", model.DurumBilgisiId));
            lstParam.Add(new SqlParameter("@pIslemTarihi", model.IslemTarihi));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanDurumHareketiEkle", lstParam);
        }

        public DBCheckModel HayvanTohumlamaBilgisiEkle(int HayvanId, DateTime IslemTarihi, string BabaKupeNo, decimal IslemUcreti, string Aciklama)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            lstParam.Add(new SqlParameter("@pDurumBilgisiId", 4));
            lstParam.Add(new SqlParameter("@pIslemTarihi", IslemTarihi));
            lstParam.Add(new SqlParameter("@pBabaKupeNo", BabaKupeNo));
            lstParam.Add(new SqlParameter("@pIslemUcreti", IslemUcreti));
            lstParam.Add(new SqlParameter("@pAciklama", Aciklama));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanTohumlamaBilgisiEkle", lstParam);
        }

        public DBCheckModel HayvanHastalikEkle(int HayvanId, DateTime IslemTarihi, int HastalikId, string KullanilanIlac,
            decimal KullanilanIlacMaliyeti, string VeterinerHekim, decimal VeterinerHekimMaliyeti, string Aciklama, string DigerHastalik)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            lstParam.Add(new SqlParameter("@pHastalikId", HastalikId));
            lstParam.Add(new SqlParameter("@pIslemTarihi", IslemTarihi));
            lstParam.Add(new SqlParameter("@pAciklama", Aciklama));
            lstParam.Add(new SqlParameter("@pKullanilanIlac", KullanilanIlac));
            lstParam.Add(new SqlParameter("@pIlacMaliyeti", KullanilanIlacMaliyeti));
            lstParam.Add(new SqlParameter("@pVeterinerHekim", VeterinerHekim));
            lstParam.Add(new SqlParameter("@pVeterinerHekimMaliyeti", VeterinerHekimMaliyeti));
            lstParam.Add(new SqlParameter("@pDigerHastalik", DigerHastalik));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanHastalikDurumEkle", lstParam);
        }

        public DBCheckModel HayvanKesimSatisBilgisiEkle(int HayvanId, DateTime IslemTarihi, int IslemTipId, int KarkasAgirligi, decimal SatisFiyati, string Aciklama)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            lstParam.Add(new SqlParameter("@pAltDurumBilgisiId", IslemTipId));
            lstParam.Add(new SqlParameter("@pIslemTarihi", IslemTarihi));
            lstParam.Add(new SqlParameter("@pAciklama", Aciklama));
            lstParam.Add(new SqlParameter("@pKarkasAgirligi", KarkasAgirligi));
            lstParam.Add(new SqlParameter("@pIslemUcreti", SatisFiyati));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanKesimSatisBilgisiEkle", lstParam);
        }

        public List<HayvanModel> HayvanModelSql(string Sql)
        {
            return sda.ExecuteObject<HayvanModel>(Sql);
        }

        public List<SuruGrubuModel> SuruGrubuSayilariGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            return sda.ExecuteObject<SuruGrubuModel>("sp_SuruGrubuSayilariGetir", lstParam);
        }

        public List<SuruGrubuModel> DurumOzetiSayilariGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            return sda.ExecuteObject<SuruGrubuModel>("sp_HayvanDurumOzetiGetir", lstParam);
        }

        public DBCheckModel HayvanSuruGruplariniGuncell()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanSuruGruplariGuncelle", lstParam);
        }

        public DBCheckModel HayvanDurumSil(HayvanModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pHayvanId", model.HayvanId));
            lstParam.Add(new SqlParameter("@pDurumBilgisiId", model.DurumBilgisiId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanDurumHareketiSil", lstParam);
        }

        public List<IdValueModel> IsletmeyeGorePadokGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IsletmeId", SessionManager.AktifKullanici.Id));
            return sda.ExecuteObject<IdValueModel>("sp_IsletmeyeGorePadokGetir", lstParam);
        }

        public HayvanModel TohumlananBabaKupeNoGetir(int HayvanId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            return sda.ExcuteReturnObject<HayvanModel>("sp_TohumlananBabaKupeNoGetir", lstParam);
        }

        public List<HayvanModel> SurudakiHayvanlariCinsiyetineGoreGetir(int SahipId, int CinsiyetId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SahipId));
            lstParam.Add(new SqlParameter("@pCinsiyetId", CinsiyetId));
            return sda.ExecuteObject<HayvanModel>("sp_SurudekiHayvanlariCinisyetineGoreGetir", lstParam);
        }

        public List<HayvanModel> TohumlanacakHayvanlariGetir(int SahipId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SahipId));
            return sda.ExecuteObject<HayvanModel>("sp_TohumlanacakHayvanlariGetir", lstParam);
        }
    }
}