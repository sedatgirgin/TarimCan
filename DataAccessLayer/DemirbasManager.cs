using System.Collections.Generic;
using System.Data.SqlClient;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class DemirbasManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public List<AkademiModel> AkademiVideoGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            return sda.ExecuteObject<AkademiModel>("sp_AkademiVideoGetir", lstParam);
        }
    }
}