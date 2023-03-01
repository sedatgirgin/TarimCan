
using System;

namespace TarimCan.Models
{
    public class AnaSayfaIsletmeDurumModel
    {
        public int SGSDegeri { get; set; }
        public decimal IsletmeGelirleri { get; set; }
        public string IsletmeGelirleriFormatted
        {
            get
            {
                return String.Format("{0:#,0.00}", IsletmeGelirleri) + " TL";
            }
        }
        public decimal IsletmeGiderleri { get; set; }
        public string IsletmeGiderleriFormatted
        {
            get
            {
                return String.Format("{0:#,0.00}", IsletmeGiderleri) + " TL";
            }
        }
        public decimal IsletmeKarZarar { get; set; }
        public string IsletmeKarZararFormatted
        {
            get
            {
                return String.Format("{0:#,0.00}", IsletmeKarZarar) + " TL";
            }
        }
        public int ToplamHayvanSayisi { get; set; }
        public int SagmalSayisi { get; set; }
        public int TazeSayisi { get; set; }
        public int KuruSayisi { get; set; }
        public int BostaSayisi { get; set; }
        public int BostaInekSayisi { get; set; }
        public int BostaDuveSayisi { get; set; }
        public int TohumlandiSayisi { get; set; }
        public int TohumlandiInekSayisi { get; set; }
        public int TohumlandiDuveSayisi { get; set; }
        public int GebeSayisi { get; set; }
        public int GebeInekSayisi { get; set; }
        public int GebeDuveSayisi { get; set; }
        public int BosKuruSayisi { get; set; }
        public int HastaSayisi { get; set; } 
        public int InekSayisi { get; set; }
        public int DuveSayisi { get; set; }
        public int TosunSayisi { get; set; }
        public int DanaSayisi { get; set; }
        public int DanaDisi { get; set; }
        public int DanaErkek { get; set; }
        public int BuzagiSayisi { get; set; }
        public int BuzagiDisi { get; set; }
        public int BuzagiErkek { get; set; }
        public int BogaSayisi { get; set; }

    }
}