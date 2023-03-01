using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class KabaYemModel
    {
        public int IsletmeId { get; set; }
        public int YemId { get; set; }
        public string YemAdi { get; set; }
        public string DigerYem { get; set; }
        public int StokHareketTipId { get; set; }
        public int StokGirisSekliId { get; set; }
        public decimal StokGirisMiktariTon { get; set; }
        public decimal KalanStokMiktariKg { get; set; }
        public decimal BirimFiyati { get; set; }
        public decimal ToplamFiyat { get; set; }
        public DateTime SatinAlmaTarihi { get; set; }
        public string FaturaNo { get; set; }
        public int OdemeSekliId { get; set; }
        public DateTime? OdemeTarihi { get; set; }

    }
}