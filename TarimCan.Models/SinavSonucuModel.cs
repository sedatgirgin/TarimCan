using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class SinavSonucuModel
    {
        public long SinavSonucu { get; set; }
        public string AdiSoyadi { get; set; }
        public string BelgeNumarasi { get; set; }
        public string TCKimlikNo { get; set; }
        public string Durumu { get; set; }
        public string SertifikaPath { get; set; }
        public bool IsSuccess { get; set; }
    }
}