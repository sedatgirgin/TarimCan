using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class IsTakipModel
    {
        public int IsTakipId { get; set; }
        public int KategoriId { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string TamamlanmaYorumu { get; set; }
        public int OncelikSirasi { get; set; }
        public string EkliDosyaAdi { get; set; }
        public string Base64File { get; set; }
        public int TalepOlusturanKullaniciId { get; set; }
        public string Kategori { get; set; }
        public string IsimSoyisim { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}