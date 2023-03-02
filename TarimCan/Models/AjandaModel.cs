using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class AjandaModel
    {
        public int HayvanId { get; set; }
        public string KupeNo { get; set; }
        public string Adi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Gorev { get; set; }

    }
}