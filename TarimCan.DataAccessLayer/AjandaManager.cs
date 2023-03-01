using System.Collections.Generic;
using System.Data.SqlClient;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class AjandaManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public DBCheckModel AjandaGorevKaydet(AjandaModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", model.HayvanId));
            lstParam.Add(new SqlParameter("@pBaslangicTarihi", model.BaslangicTarihi));
            lstParam.Add(new SqlParameter("@pBitisTarihi", model.BitisTarihi));
            lstParam.Add(new SqlParameter("@pGorev", model.Gorev));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_AjandaGorevKaydet", lstParam);
        }

        public List<AjandaModel> GorevleriGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<AjandaModel>("sp_AjandaGorevleriGetir", lstParam);
        }

        public List<AjandaModel> TumGorevleriGetir(int IsletmeId, int KategoriId, int PageIndex)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pKategoriId", KategoriId)); 
            lstParam.Add(new SqlParameter("@pPageIndex", PageIndex));
            return sda.ExecuteObject<AjandaModel>("sp_AjandaTumGorevleriGetir", lstParam);
        }

        public DBCheckModel GorevTamamla(int AjandaId, string IslemNotu, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pAjandaId", AjandaId));
            lstParam.Add(new SqlParameter("@pIslemNotu", IslemNotu));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_AjandaGorevTamamla", lstParam);
        }

        public List<AjandaModel> TamamlananGorevleriGetir(int IsletmeId, int KategoriId, int PageIndex)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pKategoriId", KategoriId));
            lstParam.Add(new SqlParameter("@pPageIndex", PageIndex));
            return sda.ExecuteObject<AjandaModel>("sp_AjandaTamamlananGorevleriGetir", lstParam);
        }

        public List<AjandaModel> HayvanaAitTumGorevleriGetir(int IsletmeId, int HayvanId, int PageIndex)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            lstParam.Add(new SqlParameter("@pPageIndex", PageIndex));
            return sda.ExecuteObject<AjandaModel>("sp_HayvanGorevListesiGetir", lstParam);
        }
    }
}