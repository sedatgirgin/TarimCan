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
    public class UzmanaSorManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();
        UIHelper helpler = new UIHelper();

        public DBCheckModel UzmanaSorKaydet(UzmanaSorModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKullaniciId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pKategoriId", model.KategoriId));
            lstParam.Add(new SqlParameter("@pBaslik", model.Baslik));
            lstParam.Add(new SqlParameter("@pAciklama", model.Aciklama));
            lstParam.Add(new SqlParameter("@pKayitIpAdresi", helpler.GetIPAddress()));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_UzmanaSorKaydet", lstParam);
        }

        public UzmanaSorModel IdyeGoreSoruGetir(int SoruId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKullaniciId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pSoruId", SoruId));
            return sda.ExcuteReturnObject<UzmanaSorModel>("sp_UzmanaSorVerileriGetir", lstParam);
        }
        
        public List<UzmanaSorModel> KullaniciyaGoreTumSorulariGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKullaniciId", SessionManager.AktifKullanici.Id));
            return sda.ExecuteObject<UzmanaSorModel>("sp_UzmanaSorVerileriGetir", lstParam);
        }


    }
}