using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarimCan.Models.Yardim
{
    class YardimTalepModel
    {
        public int YardimTalepId { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
        public int MahalleId { get; set; }
        public int IsimSoyisim { get; set; }
        public int CepTelefonu { get; set; }
        public int IsletmeAdi { get; set; }
        public int IsletmeKayitNo { get; set; }
        public int HayvanCinsi { get; set; }
        public int KabaYemCinsi { get; set; }
        public int KabaYemMiktari { get; set; }
        public int KesifYemCinsi { get; set; }
        public int KesifYemMiktari { get; set; }
        public int HayvanTalepCinsi { get; set; }
        public int HayvanTalepAdedi { get; set; }
    }
}
