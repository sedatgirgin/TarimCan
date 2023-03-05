using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class AsiManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public List<Asi> Select(int isletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@IsletmeId", isletmeId));
            lstParam.Add(new SqlParameter("@StatementType", "Select"));
            return sda.ExecuteObject<Asi>("sp_AsiSelectInsertUpdateDelete", lstParam);
        }

        public bool Insert(Asi model)
        {
            try
            {
                List<SqlParameter> lstParam = new List<SqlParameter>();
                lstParam.Add(new SqlParameter("@IsletmeId", model.IsletmeId));
                lstParam.Add(new SqlParameter("@AsiAdi", model.AsiAdi));
                lstParam.Add(new SqlParameter("@TicariAdi", model.TicariAdi));
                lstParam.Add(new SqlParameter("@AsininUygulamaTekrari", model.AsininUygulamaTekrari));
                lstParam.Add(new SqlParameter("@Rapel", model.Rapel));
                lstParam.Add(new SqlParameter("@Cinsiyet", model.Cinsiyet));
                lstParam.Add(new SqlParameter("@SonUygulanacagiTarih", model.SonUygulanacagiTarih));
                lstParam.Add(new SqlParameter("@Aktif", model.Aktif));
                lstParam.Add(new SqlParameter("@StatementType", "Insert"));
                sda.ExecuteObject<AjandaModel>("sp_AsiSelectInsertUpdateDelete", lstParam);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
