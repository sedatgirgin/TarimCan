using System;
using System.Globalization;

namespace TarimCan.Models
{
    public class SutModel
    {
        public int Id { get; set; }
        public int SutIslemId { get; set; }
        public int UyeId { get; set; }
        public int IsletmeId { get; set; }
        public int HayvanId { get; set; }
        public string Adi { get; set; }
        public string KupeNo { get; set; }
        public decimal TopluLitreFiyati { get; set; }
        public decimal GunlukTopluSatisMiktari { get; set; }
        public decimal PerakendeLitreFiyati { get; set; }
        public decimal PerakendeSatisMiktari { get; set; }
        public decimal BuzagiIctigiToplamLitre { get; set; }
        public decimal ToplamTopluSatisFiyati { get; set; }
        public decimal ToplamPerakendeSatisFiyati { get; set; }
        public DateTime IslemTarihi { get; set; }
        public decimal GunlukSutMiktari { get; set; }
        public decimal GunlukSutSatisGelirleri { get; set; }
        public decimal GunlukSatilanMamulSutMiktari { get; set; }
        public decimal GunlukMamulSatisGelirleri { get; set; }
        public decimal GunlukToplamHasilat { get; set; }
        public decimal LitreFiyati { get; set; }
        public decimal ToplamLitre { get; set; }
        public decimal SabahSutMiktari { get; set; }
        public decimal OglenSutMiktari { get; set; }
        public decimal AksamSutMiktari { get; set; }
        public decimal GunlukGelirToplami { get; set; }
    }
}