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
    public class FinansManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public DBCheckModel HayvanKesimGeliriKaydet(int HayvanId, int GelirTipId, decimal Miktari, decimal BirimFiyati, decimal ToplamTutar, DateTime IslemTarihi)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pHayvanId", HayvanId));
            lstParam.Add(new SqlParameter("@pGelirTipId", GelirTipId));
            lstParam.Add(new SqlParameter("@pMiktari", Miktari));
            lstParam.Add(new SqlParameter("@pBirimFiyati", BirimFiyati));
            lstParam.Add(new SqlParameter("@pToplamTutar", ToplamTutar));
            lstParam.Add(new SqlParameter("@pIslemTarihi", IslemTarihi));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_IsletmeGelirTipiKaydet", lstParam);
        }

        public List<FinansModel> IsletmeGelirleriGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", SessionManager.AktifKullanici.Id));
            return sda.ExecuteObject<FinansModel>("sp_IsletmeGelirleriGetir", lstParam);
        }
    }
}