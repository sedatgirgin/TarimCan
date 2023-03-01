using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class SuruGrubuModel
    {
        public int Id { get; set; }
        public int SuruGrubuId { get; set; }
        public int CinsiyetId { get; set; }
        public string SuruGrubu { get; set; }
        public int Sayi { get; set; }
    }
}