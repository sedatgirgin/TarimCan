using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TarimCan.Models
{
    public class Asi
    {
        public int Id { get; set; }
        public int IsletmeId { get; set; }
        public string AsiAdi { get; set; }
        public string TicariAdi { get; set; }
        public int AsininUygulamaTekrari { get; set; }
        public bool Rapel { get; set; }
        public int Cinsiyet { get; set; }
        public DateTime SonUygulanacagiTarih { get; set; }
        public bool Aktif { get; set; }
    }
}
