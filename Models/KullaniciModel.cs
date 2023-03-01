namespace TarimCan.Models
{
    public class KullaniciModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string IsimSoyisim { get; set; }
        public string CepTelefonu { get; set; }
        public string Sifre { get; set; }
        public string SifreTekrar { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
        public int MahalleId { get; set; }
        public bool ITMKayitliMi { get; set; }
        public string IsletmeAdi { get; set; }
        public string IsletmeKayitNo { get; set; }
        public int TarimMudSehirId { get; set; }
        public int TarimMudIlceId { get; set; }
        public int ReturnValue { get; set; }
        public bool AdminMi { get; set; }
        public string ImgBase64 { get; set; }
        public string ProfilResmi { get; set; }
        public int SGSDegeri { get; set; }
        public int HayvanTohumlamaAyi { get; set; }
    }
}