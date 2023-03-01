using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class MakinaEkipmanManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public DBCheckModel MakinaEkipmanKaydet(MakinaEkipmanModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pTipId", model.TipId));
            lstParam.Add(new SqlParameter("@pYerId", model.YerId));
            lstParam.Add(new SqlParameter("@pSeriNumarasi", model.SeriNumarasi));
            lstParam.Add(new SqlParameter("@pMarkasi", model.Markasi));
            lstParam.Add(new SqlParameter("@pModeli", model.Modeli));
            lstParam.Add(new SqlParameter("@pSatinAlinanYil", model.SatinAlinanYil));
            lstParam.Add(new SqlParameter("@pSatinAlmaBedeli", model.SatinAlmaBedeli));
            lstParam.Add(new SqlParameter("@pFaturaNo", model.FaturaNo));
            lstParam.Add(new SqlParameter("@pFaturaTarihi", model.FaturaTarihi));
            lstParam.Add(new SqlParameter("@pPeriyodikBakimGerekiyorMu", model.PeriyodikBakimGerekiyorMu));
            lstParam.Add(new SqlParameter("@pBakimPeriyoduAy", model.BakimPeriyoduAy));
            lstParam.Add(new SqlParameter("@pSonBakimYapildigiTarih", model.SonBakimYapildigiTarih));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            lstParam.Add(new SqlParameter("@pKayitKullaniciId", IsletmeId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_MakinaEkipmanKaydet", lstParam);
        }

        public DBCheckModel MakinaEkipmanGuncelle(MakinaEkipmanModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pMakinaEkipmanId", model.MakinaEkipmanId));
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pTipId", model.TipId));
            lstParam.Add(new SqlParameter("@pYerId", model.YerId));
            lstParam.Add(new SqlParameter("@pSeriNumarasi", model.SeriNumarasi));
            lstParam.Add(new SqlParameter("@pMarkasi", model.Markasi));
            lstParam.Add(new SqlParameter("@pModeli", model.Modeli));
            lstParam.Add(new SqlParameter("@pSatinAlinanYil", model.SatinAlinanYil));
            lstParam.Add(new SqlParameter("@pSatinAlmaBedeli", model.SatinAlmaBedeli));
            lstParam.Add(new SqlParameter("@pFaturaNo", model.FaturaNo));
            lstParam.Add(new SqlParameter("@pFaturaTarihi", model.FaturaTarihi));
            lstParam.Add(new SqlParameter("@pPeriyodikBakimGerekiyorMu", model.PeriyodikBakimGerekiyorMu));
            lstParam.Add(new SqlParameter("@pBakimPeriyoduAy", model.BakimPeriyoduAy));
            lstParam.Add(new SqlParameter("@pSonBakimYapildigiTarih", model.SonBakimYapildigiTarih));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            lstParam.Add(new SqlParameter("@pKayitKullaniciId", IsletmeId));
            lstParam.Add(new SqlParameter("@pAktifMi", model.AktifMi));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_MakinaEkipmanGuncelle", lstParam);
        }

        public List<MakinaEkipmanModel> MakinaEkipmanListesiniGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<MakinaEkipmanModel>("sp_MakinaEkipmanGetir", lstParam);
        }

        public MakinaEkipmanModel MakinaEkipmanDetayGetir(int IsletmeId, int MakinaEkipmanId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pMakinaEkipmanId", MakinaEkipmanId));
            return sda.ExcuteReturnObject<MakinaEkipmanModel>("sp_MakinaEkipmanGetir", lstParam);
        }




    }
}
