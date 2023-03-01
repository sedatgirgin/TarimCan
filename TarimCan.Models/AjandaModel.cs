using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class AjandaModel
    {
        public int AjandaId { get; set; }
        public int KategoriId { get; set; }
        public int HayvanId { get; set; }
        public string KupeNo { get; set; }
        public string Adi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Gorev { get; set; }
        public string IslemNotu { get; set; }
        public string BaslamaTarihiFormatted { get { return BaslangicTarihi.ToString("dd.MM.yyyy"); } }
        public string HataDurumu { get; set; }
        public bool ErtelendiMi { get; set; }
        public bool TamamlandiMi { get; set; }

    }
}