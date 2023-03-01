using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class TedaviModel
    {
        public int HayvanId { get; set; }
        public int IsletmeId { get; set; }
        public string HasKullanilanIlac { get; set; }
        public decimal HasIlacMaliyeti { get; set; }
        public string HasVeterinerHekim { get; set; }
        public decimal HasVeterinerHekimMaliyeti { get; set; }
        public bool HasCerrahiOperasyonOlduMu { get; set; }
        public DateTime IslemTarihi { get; set; }
        public string Aciklama { get; set; }

    }
}