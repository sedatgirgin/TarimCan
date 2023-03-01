using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class IsTakipManager
    {

        MSSqlDataAccess sda = new MSSqlDataAccess();

        public DBCheckModel IsKaydet(IsTakipModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pBaslik", model.Baslik));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            lstParam.Add(new SqlParameter("@pOncelikSirasi", model.OncelikSirasi));
            lstParam.Add(new SqlParameter("@pEkliDosyaAdi", model.EkliDosyaAdi));
            lstParam.Add(new SqlParameter("@pTalepOlusturanKullaniciId", IsletmeId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_IsTakipKayitEkle", lstParam);
        }

        public List<IsTakipModel> TumIsListesiniGetir(int KategoriId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKategoriId", KategoriId));
            return sda.ExecuteObject<IsTakipModel>("sp_IsTakipTumListeGetir", lstParam);
        }

        public DBCheckModel IsGuncelle(IsTakipModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pTamamlanmaYorumu", model.TamamlanmaYorumu));
            lstParam.Add(new SqlParameter("@pKategoriId", model.KategoriId));
            lstParam.Add(new SqlParameter("@pIsTakipId", model.IsTakipId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_IsTakipGuncelle", lstParam);
        }

        public IsTakipModel IsDetayGetir(int IsId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsId", IsId));
            return sda.ExcuteReturnObject<IsTakipModel>("sp_IsDetayGetir", lstParam);
        }
    }
}