using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class AkademiModel
    {
        public int Id { get; set; }
        public int OynatmaListesiId { get; set; }
        public string OynatmaListesi { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string KapakResmi { get; set; }
        public string VideoLinki { get; set; }
        public int GoruntulenmeSayisi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public string EklenmeTarihiFormatted
        {
            get
            {
                return EklenmeTarihi.ToString("dd.MM.yyyy");
            }
        }
    }
}