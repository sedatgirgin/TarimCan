using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class PadokModel
    {
        public int PadokId { get; set; }
        public string PadokAdi { get; set; }
        public string RasyonAdi { get; set; }
        public string Icon { get; set; }
        public int PadoktakiHayvanSayisi { get; set; }
    }
}