using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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

        public HayvanModel HayvanDetayiSahibineGoreGetir(int HayvanId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            return sda.ExcuteReturnObject<HayvanModel>("sp_HayvanDetayiSahibineGoreGetir", lstParam);
        }

        public List<DurumHareketModel> HayvanDurumHareketleriGetir(int HayvanId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            return sda.ExecuteObject<DurumHareketModel>("sp_HayvanDurumHareketleriniGetir", lstParam);
        }

        public DBCheckModel HayvanKaydet(HayvanModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
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
            lstParam.Add(new SqlParameter("@pEsiniSonunuAttiMi", model.EsiniSonunuAttiMi));
            lstParam.Add(new SqlParameter("@pGebelikDurumId", model.GebelikDurumId));
            lstParam.Add(new SqlParameter("@pSuruyeGirisDurumId", model.SuruyeGirisDurumId));
            lstParam.Add(new SqlParameter("@pTohumlanmaTarihi", model.TohumlanmaTarihi));
            lstParam.Add(new SqlParameter("@pSonDogumYaptigiTarih", model.SonDogumYaptigiTarih));
            lstParam.Add(new SqlParameter("@pSatinAlmaFiyati", model.SatinAlmaFiyati));
            lstParam.Add(new SqlParameter("@pLaktasyonSayisi", model.LaktasyonSayisi));
            lstParam.Add(new SqlParameter("@pKayitKullaniciId", IsletmeId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanEkle", lstParam);
        }

        public DBCheckModel TopluHayvanKaydet(HayvanModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pKupeNo", model.KupeNo));
            lstParam.Add(new SqlParameter("@pAdi", model.Adi));
            lstParam.Add(new SqlParameter("@pIrkId", model.IrkId));
            lstParam.Add(new SqlParameter("@pCinsiyetId", model.CinsiyetId));
            lstParam.Add(new SqlParameter("@pDogumTarihi", model.DogumTarihi));
            lstParam.Add(new SqlParameter("@pHayvanDurumId", model.HayvanDurumId));
            lstParam.Add(new SqlParameter("@pGebelikDurumId", model.GebelikDurumId));
            lstParam.Add(new SqlParameter("@pGebelikDurumu", model.GebelikDurumu));
            lstParam.Add(new SqlParameter("@pLaktasyonSayisi", model.LaktasyonSayisi));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_TopluHayvanEkle", lstParam);
        }

        public DBCheckModel HayvanGuncelle(HayvanModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pId", model.HayvanId));
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            lstParam.Add(new SqlParameter("@pKupeNo", model.KupeNo));
            lstParam.Add(new SqlParameter("@pAdi", model.Adi));
            lstParam.Add(new SqlParameter("@pAnneKupeNo", model.AnneKupeNo));
            lstParam.Add(new SqlParameter("@pBabaKupeNo", model.BabaKupeNo));
            lstParam.Add(new SqlParameter("@pLaktasyonSayisi", model.LaktasyonSayisi));
            lstParam.Add(new SqlParameter("@pPadokId", model.PadokId));
            lstParam.Add(new SqlParameter("@pIrkId", model.IrkId));
            lstParam.Add(new SqlParameter("@pSuruyeGirisTipId", model.SuruyeGirisTipId));
            lstParam.Add(new SqlParameter("@pSuruyeGirisTarihi", model.SuruyeGirisTarihi));
            lstParam.Add(new SqlParameter("@pDogumTarihi", model.DogumTarihi));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanGuncelle", lstParam);
        }

        public List<RutinIslemModel> HayvanRutinIslemleriniGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            return sda.ExecuteObject<RutinIslemModel>("sp_HayvanRutinIslemleriGetir", lstParam);
        }

        public List<RutinIslemModel> HaftalikHayvanRutinIslemleriniGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHaftalikMi", true));
            return sda.ExecuteObject<RutinIslemModel>("sp_HayvanRutinIslemleriGetir", lstParam);
        }

        public DBCheckModel HayvanDurumHereketiEkle(DurumHareketModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", model.HayvanId));
            lstParam.Add(new SqlParameter("@pDurumBilgisiId", model.DurumBilgisiId));
            lstParam.Add(new SqlParameter("@pIslemTarihi", model.IslemTarihi));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanDurumHareketiEkle", lstParam);
        }

        public DBCheckModel HayvanTekilDurumHereketiEkle(DurumHareketModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", model.HayvanId));
            lstParam.Add(new SqlParameter("@pDurumBilgisiId", model.DurumBilgisiId));
            lstParam.Add(new SqlParameter("@pIslemTarihi", model.IslemTarihi));
            lstParam.Add(new SqlParameter("@pIslemSonlandiMi", model.IslemSonlandiMi));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanDurumHareketiEkle_Tekil", lstParam);
        }

        public DBCheckModel HayvanTohumlamaBilgisiEkle(int HayvanId, DateTime IslemTarihi, string BabaKupeNo, decimal IslemUcreti, string Aciklama, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            lstParam.Add(new SqlParameter("@pDurumBilgisiId", 4));
            lstParam.Add(new SqlParameter("@pIslemTarihi", IslemTarihi));
            lstParam.Add(new SqlParameter("@pBabaKupeNo", BabaKupeNo));
            lstParam.Add(new SqlParameter("@pIslemUcreti", IslemUcreti));
            lstParam.Add(new SqlParameter("@pAciklama", Aciklama));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanTohumlamaBilgisiEkle", lstParam);
        }

        public DBCheckModel HayvanHastalikEkle(int HayvanId, DateTime IslemTarihi, int HastalikId, string KullanilanIlac,
            decimal KullanilanIlacMaliyeti, string VeterinerHekim, decimal VeterinerHekimMaliyeti, string Aciklama, string DigerHastalik, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
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

        public DBCheckModel HayvanKesimSatisBilgisiEkle(int HayvanId, DateTime IslemTarihi, int IslemTipId, int KarkasAgirligi, decimal SatisFiyati, string Aciklama, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
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

        public List<SuruGrubuModel> SuruGrubuSayilariGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            return sda.ExecuteObject<SuruGrubuModel>("sp_SuruGrubuSayilariGetir", lstParam);
        }

        public List<SuruGrubuModel> DurumOzetiSayilariGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            return sda.ExecuteObject<SuruGrubuModel>("sp_HayvanDurumOzetiGetir", lstParam);
        }

        public DBCheckModel HayvanSuruGruplariniGuncell(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanSuruGruplariGuncelle", lstParam);
        }

        public DBCheckModel HayvanDurumSil(HayvanModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", model.HayvanId));
            lstParam.Add(new SqlParameter("@pDurumBilgisiId", model.DurumBilgisiId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanDurumHareketiSil", lstParam);
        }

        public List<IdValueModel> IsletmeyeGorePadokGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IsletmeId", IsletmeId));
            return sda.ExecuteObject<IdValueModel>("sp_IsletmeyeGorePadokGetir", lstParam);
        }

        public HayvanModel TohumlananBabaKupeNoGetir(int HayvanId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
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

        public List<DurumBilgisiModel> HayvanSaglikKarnesiGetir(int HayvanId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            return sda.ExecuteObject<DurumBilgisiModel>("sp_HayvanSaglikKarnesiGetir", lstParam);
        }


        public DBCheckModel TedaviEkle(TedaviModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", model.HayvanId));
            lstParam.Add(new SqlParameter("@pIslemTarihi", model.IslemTarihi));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            lstParam.Add(new SqlParameter("@pHasKullanilanIlac", model.HasKullanilanIlac));
            lstParam.Add(new SqlParameter("@pHasIlacMaliyeti", model.HasIlacMaliyeti));
            lstParam.Add(new SqlParameter("@pHasVeterinerHekim", model.HasVeterinerHekim));
            lstParam.Add(new SqlParameter("@pHasVeterinerHekimMaliyeti", model.HasVeterinerHekimMaliyeti));
            lstParam.Add(new SqlParameter("@pHasCerrahiOperasyonOlduMu", model.HasCerrahiOperasyonOlduMu));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_TedaviEkle", lstParam);
        }

        public List<HayvanModel> TopluDurumGuncellenecekHayvanlariGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_TopluGuncellenecekHayvanlariGetir", lstParam);
        }

        public List<HayvanModel> TopluPadokGuncellenecekHayvanlariGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId)); 
            lstParam.Add(new SqlParameter("@pSuruGrubuId", 0));
            lstParam.Add(new SqlParameter("@pDurumOzetiId", 0));
            return sda.ExecuteObject<HayvanModel>("sp_SurudekiHayvanlariSahibineGoreGetir", lstParam);
        }

        public List<HayvanModel> HayvanListGetirSql(string Sql)
        {
            return sda.ExecuteObject<HayvanModel>(Sql);
        }

        public List<HayvanModel> GebeHayvanLitesiDetayGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_GebeHayvanLitesiDetayGetir", lstParam);
        }

        public List<HayvanModel> TazeHayvanListesiniGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_TazeHayvanListesiGetir", lstParam);
        }

        public List<HayvanModel> TohumlananHayvanlariGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_TohumlananHayvanlariGetir", lstParam);
        }

        public List<HayvanModel> SurudekiHayvanlariPadogaGoreGetir(int PadokId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pPadokId", PadokId));
            return sda.ExecuteObject<HayvanModel>("sp_SurudekiHayvanlariPadogaGoreGetir", lstParam);
        }

        public List<HayvanModel> IsletmedenAyrilanHayvanlariGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_IsletmedenAyrilanHayvanlariGetir", lstParam);
        }

        public DBCheckModel HayvanPadokGuncelle(int HayvanId, int PadokId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            lstParam.Add(new SqlParameter("@pPadokId", PadokId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanPadokGuncelle", lstParam);
        }

        public List<HayvanModel> BosKuruHayvanListesiniGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_BosKuruHayvanListesiGetir", lstParam);
        }

        public HayvanModel SonEklenenIrkIdGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExcuteReturnObject<HayvanModel>("sp_SonEklenenIrkIdGetir", lstParam);
        }

        public List<HayvanModel> InekleriGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_InekleriGetir", lstParam);
        }

        public DBCheckModel HayvanDurumEkleUygunlukKontrol(int DurumTipId, int HayvanId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pDurumTipId", DurumTipId));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanDurumEkleOncesiKontrol", lstParam);
        }

        public List<HayvanModel> KurudakiHayvanlariGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_KurudakiHayvanlariGetir", lstParam);
        }

        public List<HayvanModel> SagmalHayvanlariGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_SagmalHayvanlariGetir", lstParam);
        }

        public List<HayvanModel> BosHayvanlariGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_BostakiHayvanlariGetir", lstParam);
        }

        public DBCheckModel HayvanSilAction(int HayvanId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanSil", lstParam);
        }

        public DBCheckModel HayvanDurumHereketiGuncelle(DurumHareketModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pDurumHareketId", model.Id));
            lstParam.Add(new SqlParameter("@pHayvanId", model.HayvanId));
            lstParam.Add(new SqlParameter("@pIslemTarihi", model.IslemTarihi));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanDurumHareketiGuncelle", lstParam);
        }

        public DBCheckModel HayvanlariTazedenCikar()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            return sda.ExcuteReturnObject<DBCheckModel>("sp_HayvanlariTazedenCikar", lstParam);
        }

        public DBCheckModel GunlukHayvanVerileriniGuncelle(int HayvanId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_Sch_GunlukHayvanVerileriniGuncelle", lstParam);
        }
    }
}