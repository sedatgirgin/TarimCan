using TarimCan.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using TarimCan.Helper;

namespace TarimCan.DataAccessLayer
{
    public class TanimlamalarManager
    {

        MSSqlDataAccess sda = new MSSqlDataAccess();
        UIHelper helper = new UIHelper();

        public List<IdValueModel> TumHayvanIrklariniGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", 0));
            return sda.ExecuteObject<IdValueModel>("sp_TnmHayvanIrklari", lstParam);
        }

        public DBCheckModel HayvanIrkıIslemleri(int IslemId, int Id, string Value)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", IslemId));
            lstParam.Add(new SqlParameter("@p_Id", Id));
            lstParam.Add(new SqlParameter("@p_Value", Value));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_TnmHayvanIrklari", lstParam);
        }

        
        public List<IdValueModel> TumHayvanSuruGruplariniGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", 0));
            return sda.ExecuteObject<IdValueModel>("sp_TnmHayvanSuruGruplari", lstParam);
        }

        public DBCheckModel HayvanSuruGrubuIslemleri(int IslemId, int Id, string Value)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", IslemId));
            lstParam.Add(new SqlParameter("@p_Id", Id));
            lstParam.Add(new SqlParameter("@p_Value", Value));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_TnmHayvanSuruGruplari", lstParam);
        }


        public List<RutinIslemModel> RutinIslemiDurumTipineGoreGetir(int DurumBilgisiId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", 0));
            lstParam.Add(new SqlParameter("@p_DurumBilgisiId", DurumBilgisiId));
            return sda.ExecuteObject<RutinIslemModel>("sp_TnmRutinIslemler", lstParam);
        }

        //public DBCheckModel RutinIslemEkle(RutinIslemModel model)
        //{
        //    List<SqlParameter> lstParam = new List<SqlParameter>();
        //    lstParam.Add(new SqlParameter("@p_IslemId", 1));
        //    lstParam.Add(new SqlParameter("@p_DurumBilgisiId", model.DurumBilgisiId));
        //    lstParam.Add(new SqlParameter("@p_RutinIslem", model.RutinIslem));
        //    lstParam.Add(new SqlParameter("@p_DogumdanSonrakiSure", model.DogumdanSonrakiSure));
        //    lstParam.Add(new SqlParameter("@p_VeterinerKontroluGerekiyorMu", model.VeterinerKontroluGerekiyorMu));
        //    return sda.ExcuteReturnObject<DBCheckModel>("sp_TnmRutinIslemler", lstParam);
        //}

    }
}