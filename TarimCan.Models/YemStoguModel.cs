using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class YemStoguModel
    {
        public int StokId { get; set; }
        public int YemId { get; set; }
        public string YemAdi { get; set; }
        public string RasyonAdi { get; set; }
        public int YemTipId { get; set; }
        public string YemTipi { get; set; }
        public decimal StokMiktariKg { get; set; }
        public decimal YemMiktariKg { get; set; }
    }

    public class YemStokHareketModel
    {
        public int StokHareketId { get; set; }
        public int YemId { get; set; }
        public int YemTipId { get; set; }
        public string YemAdi { get; set; }
        public int StokHareketTipId { get; set; }
        public string GirisCikis { get; set; }
        public int OdemeSekliId { get; set; }
        public string OdemeSekli { get; set; }
        public int StokGirisTipId { get; set; }
        public string StokGirisTipi { get; set; }
        public decimal StokGirisMiktari { get; set; }
        public decimal ToplamMiktar { get; set; }
        public decimal ToplamFiyat { get; set; }
        public decimal BirimFiyat { get; set; }
        public string MiktarAdi { get; set; }
        public DateTime IslemTarihi { get; set; }
        public string FaturaNo { get; set; }
        public int BirimMiktarId { get; set; }
    }
}



