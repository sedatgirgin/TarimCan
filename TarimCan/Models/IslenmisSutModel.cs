using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class SutUrunleriModel
    {
        public int Id { get; set; }
        public decimal PeynirMiktarKg { get; set; }
        public decimal PeynirKullanilanSutKg { get; set; }
        public decimal PeynirSatisFiyati { get; set; }
        public decimal PeynirToplamFiyat { get; set; }
        public decimal YogurtMiktarKg { get; set; }
        public decimal YogurtKullanilanSutKg { get; set; }
        public decimal YogurtSatisFiyati { get; set; }
        public decimal YogurtToplamFiyat { get; set; }
        public decimal TereyagMiktarKg { get; set; }
        public decimal TereyagKullanilanSutKg { get; set; }
        public decimal TereyagSatisFiyati { get; set; }
        public decimal TereyagToplamFiyat { get; set; }
        public decimal DigerMiktarKg { get; set; }
        public decimal DigerKullanilanSutKg { get; set; }
        public decimal DigerSatisFiyati { get; set; }
        public decimal DigerToplamFiyat { get; set; }
        public DateTime IslemTarihi { get; set; }

    }
}