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

        public List<FinansModel> IsletmeGelirleriGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<FinansModel>("sp_IsletmeGelirleriGetir", lstParam);
        }

        public DBCheckModel ManuelGelirGiderKaydet(GelirGiderModel model, int IslemDurumId)
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

        public List<GelirGiderModel> IsletmeFinansalHareketleriGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<GelirGiderModel>("sp_IsletmeDurumAkisiGetir", lstParam);
        }


        public AnaSayfaIsletmeDurumModel IsletmeGelirGiderOzetGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExcuteReturnObject<AnaSayfaIsletmeDurumModel>("sp_IsletmeFinansOzetiGetir", lstParam);
        }


    }
}