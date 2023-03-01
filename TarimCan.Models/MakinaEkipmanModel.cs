using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarimCan.Models
{
    public class MakinaEkipmanModel
    {
        public int MakinaEkipmanId { get; set; }
        public int TipId { get; set; }
        public string DemirbasTipi { get; set; }
        public int YerId { get; set; }
        public string DemirbasYeri { get; set; }
        public string SeriNumarasi { get; set; }
        public string UrunAdi { get; set; }
        public string Markasi { get; set; }
        public string Modeli { get; set; }
        public int SatinAlinanYil { get; set; }
        public decimal SatinAlmaBedeli { get; set; }
        public string FaturaNo { get; set; }
        public DateTime? FaturaTarihi { get; set; }
        public bool PeriyodikBakimGerekiyorMu { get; set; }
        public int BakimPeriyoduAy { get; set; }
        public string Aciklama { get; set; }
        public DateTime? SonBakimYapildigiTarih { get; set; }
        public bool AktifMi { get; set; }
    }
}
