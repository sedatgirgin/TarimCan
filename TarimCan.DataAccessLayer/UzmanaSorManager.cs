using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class UzmanaSorManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public DBCheckModel UzmanaSorKaydet(UzmanaSorModel model, int IsletmeId, string IPAdress)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKullaniciId", IsletmeId));
            lstParam.Add(new SqlParameter("@pKategoriId", model.KategoriId));
            lstParam.Add(new SqlParameter("@pBaslik", model.Baslik));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            lstParam.Add(new SqlParameter("@pKayitIpAdresi", IPAdress));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_UzmanaSorKaydet", lstParam);
        }

        public UzmanaSorModel IdyeGoreSoruGetir(int SoruId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKullaniciId", IsletmeId));
            lstParam.Add(new SqlParameter("@pSoruId", SoruId));
            return sda.ExcuteReturnObject<UzmanaSorModel>("sp_UzmanaSorVerileriGetir", lstParam);
        }
        
        public List<UzmanaSorModel> KullaniciyaGoreTumSorulariGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKullaniciId", IsletmeId));
            return sda.ExecuteObject<UzmanaSorModel>("sp_UzmanaSorVerileriGetir", lstParam);
        }


    }
}