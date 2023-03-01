using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class DemirbasModel
    {
        public int DemirbasId { get; set; }
        public int IsletmeId { get; set; }
        public int DemirbasTipId { get; set; }
        public string DemirbasTipi { get; set; }
        public int DemirbasYerId { get; set; }
        public string DemirbasYeri { get; set; }
        public string TakipNumarasi { get; set; }
        public string UrunAdi { get; set; }
        public string SeriNumarasi { get; set; }
        public string FaturaBedeli { get; set; }
        public string FaturaNo { get; set; }
        public DateTime? FaturaTarihi { get; set; }
        public int RutinBakimGerekiyorMu { get; set; }
        public int BakimPeriyoduGun { get; set; }
        public string Aciklama { get; set; }
        public int KayitTarihi { get; set; }
        public int KayitKullaniciId { get; set; }
        public int KullaniciAdi { get; set; }
    }
}