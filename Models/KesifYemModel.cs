using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class KesifYemModel
    {
        public int Id { get; set; }
        public int IsletmeId { get; set; }
        public int KesifYemId { get; set; } 
        public string YemAdi { get; set; }
        public int KesifYemUstId { get; set; }
        public string Markasi { get; set; }
        public int StokGirisSekliId { get; set; }
        public int BirimMiktarId { get; set; }
        public decimal SatinAlinanMiktar { get; set; }
        public decimal ToplamMiktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal ToplamFiyat { get; set; }
        public DateTime IslemTarihi { get; set; }
        public string FaturaNo { get; set; }
        public int OdemeSekliId { get; set; }
        public DateTime? OdemeTarihi { get; set; }
    }
}