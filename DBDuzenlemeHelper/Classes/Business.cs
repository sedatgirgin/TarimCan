using SuruTakip.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDuzenlemeHelper.Classes
{
    class Business
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public List<Model> VeriGetir(string Sql)
        {
            return sda.ExecuteObject<Model>(Sql);
        }

    }
}
