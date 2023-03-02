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
    public class AjandaManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public DBCheckModel AjandaGorevKaydet(AjandaModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pHayvanId", model.HayvanId));
            lstParam.Add(new SqlParameter("@pBaslangicTarihi", model.BaslangicTarihi));
            lstParam.Add(new SqlParameter("@pBitisTarihi", model.BitisTarihi));
            lstParam.Add(new SqlParameter("@pGorev", model.Gorev));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_AjandaGorevKaydet", lstParam);
        }
    }
}