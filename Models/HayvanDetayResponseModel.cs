using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class HayvanDetayResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<DurumHareketModel> DurumHareketleri { get; set; }
        public HayvanModel HayvanDetay { get; set; }
    }

    public class DurumHareketModel
    {
        public int Id { get; set; }
        public int HayvanId { get; set; }
        public int DurumBilgisiId { get; set; }
        public string DurumBilgisi { get; set; }
        public DateTime IslemTarihi { get; set; }
        public int GunSayisi { get; set; }
        public DateTime KontrolBasTar { get; set; }
        public DateTime KontrolBitTar { get; set; }
        public string IslemTarihiFormatted
        {
            get
            {
                return IslemTarihi.ToString("dd.MM.yyyy");
            }
        }
        public string KontrolTarihiFormatted
        {
            get
            {
                if (KontrolBasTar.ToString("dd.MM.yyyy") != "01.01.0001")
                {
                    return KontrolBasTar.ToString("dd.MM.yyyy") + " / " + KontrolBitTar.ToString("dd.MM.yyyy");
                }
                else
                {
                    return "";
                }
            }
        }
        public bool IsSuccess { get; set; }
        public string AciklamaFormatted
        {
            get
            {
                if (Aciklama == null)
                {
                    return "";
                }
                else
                {
                    return Aciklama;
                }
            }
        }
        public string Aciklama { get; set; }
        public int Sayisi { get; set; }
        public bool IslemSonlandiMi { get; set; }
        public DateTime IslemSonlanmaTarihi { get; set; }
    }
}