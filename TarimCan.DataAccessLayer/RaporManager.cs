using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class RaporManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public List<HayvanModel> SagmalGrupDurumOzetiDagiliminiGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_Rpr_SagmalGrupDagilimi", lstParam);
        }

        public List<HayvanModel> IneklerDurumOzetiDagiliminiGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_Rpr_InekGrupDagilimi", lstParam);
        }

        public List<HayvanModel> IneklerinUremeDurumuDagiliminiGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_Rpr_InekUremeDurumlari", lstParam);
        }
        public List<HayvanModel> SuruDagiliminiGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExecuteObject<HayvanModel>("sp_Rpr_SuruGrubuDagilimiGetir", lstParam);
        }
        public HayvanModel TohumlananHayvanlarinGebelikDurumunuGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExcuteReturnObject<HayvanModel>("sp_TohumGebelikOraniniGetir", lstParam);
        }
    }
}
