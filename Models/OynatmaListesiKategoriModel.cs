using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class OynatmaListesiKategoriModel
    {
        public int OynatmaListesiId { get; set; }
        public int VideoSayisi { get; set; }
        public string OynatmaListesi { get; set; }
        public string KategoriRengi { get; set; }
    }
}