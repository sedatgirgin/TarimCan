using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class SinavSonucuModel
    {
        public long TCKimlikNo { get; set; }
        public long SinavSonucu { get; set; }
        public string AdiSoyadi { get; set; }
        public bool IsSuccess { get; set; }
    }
}