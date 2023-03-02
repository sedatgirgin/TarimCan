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
    public class AkademiManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public List<AkademiModel> AkademiVideoGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            return sda.ExecuteObject<AkademiModel>("sp_AkademiVideoGetir", lstParam);
        }

        public AkademiModel VideoDetayGetir(int VideoId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pVideoId", VideoId));
            return sda.ExcuteReturnObject<AkademiModel>("sp_AkademiVideoGetir", lstParam);
        }

        public List<OynatmaListesiKategoriModel> OynatmaListesiKategorileriGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            return sda.ExecuteObject<OynatmaListesiKategoriModel>("sp_AkademiOynatListesiKategorileriGetir", lstParam);
        }

        public List<AkademiModel> KategoriyeGoreVideoGetir(int OynatmaListesiId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pOynatmaListesiId", OynatmaListesiId));
            return sda.ExecuteObject<AkademiModel>("sp_KategoriyeGoreAkademiVideoGetir", lstParam);
        }
    }
}