using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class GelirGiderModel
    {
        public int Id { get; set; }
        public int IsletmeId { get; set; }
        public int IslemTipId { get; set; }
        public int GelirGiderTipId { get; set; }
        public string GelirGiderTipi { get; set; }
        public int TabloDetayKayitId { get; set; }
        public decimal Tutari { get; set; }
        public string MusteriTedarikci { get; set; }
        public string FaturaNo { get; set; }
        public DateTime IslemTarihi { get; set; }
        public string Aciklama { get; set; }
        public int KayitKullaniciId { get; set; }
        public bool AktifMi { get; set; }
    }
}