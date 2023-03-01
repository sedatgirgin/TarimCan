using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class UzmanaSorModel
    {
        public int KategoriId { get; set; }
        public string Baslik { get; set; }
        public string Kategori { get; set; }
        public string Aciklama { get; set; }
        public bool CevaplandiMi { get; set; }
        public string CevapMetni { get; set; }
        public DateTime KayitTarihi { get; set; }

    }
}