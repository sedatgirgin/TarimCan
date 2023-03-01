using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class SutIndexModel
    {
        public List<SutModel> GecmisSutOzeti { get; set; }
        public SutModel GunlukSutSatislari { get; set; }
        public SutUrunleriModel GunlukSutUrunleri { get; set; }
    }
}