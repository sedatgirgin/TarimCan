using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDuzenlemeHelper
{
    class Program
    {
        static void Main(string[] args)
        {

            string Sql = "Select h.Id as HayvanId, h.SahipId From Hayvanlar h, HayvanDurumHareketleri dh, TnmDurumBilgileri d " +
                "Where h.Id = dh.HayvanId And dh.IslemSonlandiMi = 'False' And dh.DurumBilgisiId = d.Id And dh.AktifMi = 'True' And h.AktifMi = 1 And dh.DurumBilgisiId = 20 " +
                "Group By h.Id, h.SahipId, d.Id, d.DurumBilgisi Order By SahipId ";






        }
    }
}
