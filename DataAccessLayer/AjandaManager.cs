using System.Collections.Generic;
using System.Data.SqlClient;
using Tarimcan.DataAccessLayer;
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
    }
}