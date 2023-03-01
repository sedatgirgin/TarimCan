using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class RasyonModel
    {
        public int Id { get; set; }
        public int IsletmeId { get; set; }
        public string RasyonAdi { get; set; }
        public bool CalisiyorMu { get; set; }
        public DateTime? CalisacagiTarih { get; set; }
        public DateTime KayitTarihi { get; set; }
        public bool AktifMi { get; set; }
        public List<RasyonDetayModel> RasyonDetay { get; set; }
        public int PadokSayisi { get; set; }
    }

    public class RasyonDetayModel
    {
        public int Id { get; set; }
        public int RasyonId { get; set; }
        public int YemTipId { get; set; }
        public int YemId { get; set; }
        public string YemAdi { get; set; }
        public decimal YemMiktariKg { get; set; }
        public bool AktifMi { get; set; }
    }
}