using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class FinansModel
    {
        public int IsletmeGelirId { get; set; }
        public int IslemTipId { get; set; }
        public string KupeNo { get; set; }
        public string GelirTipi { get; set; }
        public decimal Miktari { get; set; }
        public decimal BirimFiyati { get; set; }
        public decimal ToplamTutar { get; set; }
        public DateTime IslemTarihi { get; set; }

    }
}