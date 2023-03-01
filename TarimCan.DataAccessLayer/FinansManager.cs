using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class FinansManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        //public DBCheckModel HayvanKesimGeliriKaydet(int HayvanId, int GelirTipId, decimal Miktari, decimal BirimFiyati, decimal ToplamTutar, DateTime IslemTarihi)
        //{
        //    List<SqlParameter> lstParam = new List<SqlParameter>();
        //    lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
        //    lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
        //    lstParam.Add(new SqlParameter("@pGelirTipId", GelirTipId));
        //    lstParam.Add(new SqlParameter("@pMiktari", Miktari));
        //    lstParam.Add(new SqlParameter("@pBirimFiyati", BirimFiyati));
        //    lstParam.Add(new SqlParameter("@pToplamTutar", ToplamTutar));
        //    lstParam.Add(new SqlParameter("@pIslemTarihi", IslemTarihi));
        //    return sda.ExcuteReturnObject<DBCheckModel>("sp_IsletmeGelirTipiKaydet", lstParam);
        //}

        public List<FinansModel> IsletmeGelirleriGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<FinansModel>("sp_IsletmeGelirleriGetir", lstParam);
        }

        public DBCheckModel ManuelGelirGiderKaydet(GelirGiderModel model, int IslemDurumId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pIslemTipId", IslemDurumId));
            lstParam.Add(new SqlParameter("@pGelirGiderTipId", model.GelirGiderTipId));
            lstParam.Add(new SqlParameter("@pGelirGiderTipi", model.GelirGiderTipi));
            lstParam.Add(new SqlParameter("@pTutari", model.Tutari));
            lstParam.Add(new SqlParameter("@pMusterTedarikci", model.MusteriTedarikci));
            lstParam.Add(new SqlParameter("@pFaturaNo", model.FaturaNo));
            lstParam.Add(new SqlParameter("@pIslemTarihi", model.IslemTarihi));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            lstParam.Add(new SqlParameter("@pKayitKullaniciId", IsletmeId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_IsletmeManuelGelirGiderEkle", lstParam);
        }

        public DBCheckModel FinansalIslemGuncelle(GelirGiderModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pId", model.Id));
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pIslemTipId", model.IslemTipId));
            lstParam.Add(new SqlParameter("@pGelirGiderTipId", model.GelirGiderTipId));
            lstParam.Add(new SqlParameter("@pGelirGiderTipi", model.GelirGiderTipi));
            lstParam.Add(new SqlParameter("@pTutari", model.Tutari));
            lstParam.Add(new SqlParameter("@pMusterTedarikci", model.MusteriTedarikci));
            lstParam.Add(new SqlParameter("@pFaturaNo", model.FaturaNo));
            lstParam.Add(new SqlParameter("@pIslemTarihi", model.IslemTarihi));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_IsletmeFinansHareketiGuncelle", lstParam);
        }

        public List<GelirGiderModel> IsletmeFinansalHareketleriGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<GelirGiderModel>("sp_IsletmeDurumAkisiGetir", lstParam);
        }

        public List<GelirGiderModel> IsletmeFinansDokumunuDetayliGetir(int IsletmeId, int Tip, int Sayfa)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pTip", Tip));
            lstParam.Add(new SqlParameter("@pSayfa", Sayfa));
            return sda.ExecuteObject<GelirGiderModel>("sp_IsletmeFinansHareketleriniGetir", lstParam);
        }

        public AnaSayfaIsletmeDurumModel IsletmeGelirGiderOzetGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExcuteReturnObject<AnaSayfaIsletmeDurumModel>("sp_IsletmeFinansOzetiGetir", lstParam);
        }

        public DBCheckModel FinansHareketiniSil(int IsletmeId, int IslemId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pIslemId", IslemId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_IsletmeFinansHareketiniSil", lstParam);
        }

        public GelirGiderModel FinansHareketDetayiniGetir(int IsletmeId, int IslemId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pIslemId", IslemId));
            return sda.ExcuteReturnObject<GelirGiderModel>("sp_IsletmeFinansDetayiGetir", lstParam);
        }


    }
}