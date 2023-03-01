using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class DurumBilgisiModel
    {
        public int HayvanId { get; set; }
        public int DurumBilgisiId { get; set; }
        public string DurumBilgisi { get; set; }
        public DateTime IslemTarihi { get; set; }
        public DateTime IslemSonlanmaTarihi { get; set; }
        public string Aciklama { get; set; }
    }
}