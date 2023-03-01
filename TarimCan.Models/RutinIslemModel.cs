using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class RutinIslemModel
    {
        public int Id { get; set; }
        public int HayvanId { get; set; }
        public int IslemId { get; set; }
        public int DurumBilgisiId { get; set; }
        public int DogumdanSonrakiSure { get; set; }
        public string KupeNo { get; set; }
        public string Adi { get; set; }
        public int CinsiyetId { get; set; }
        public string Aciklama { get; set; }
        public bool VeterinerKontroluGerekiyorMu { get; set; }
        public DateTime IslemYapilacakTarih { get; set; }
        public DateTime KontrolBasTar { get; set; }
        public DateTime KontrolBitTar { get; set; }
        public string KontrolTarihiFormatted
        {
            get
            {
                return KontrolBasTar.ToString("dd.MM.yyyy") + " / " + KontrolBitTar.ToString("dd.MM.yyyy");
            }
        }

    }
}