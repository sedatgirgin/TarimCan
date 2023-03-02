﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarimCan.Models
{
    public class HayvanModel
    {
        public int Id { get; set; }
        public int HayvanId { get; set; }
        public int SahipId { get; set; }
        public string HayvanStatusu { get; set; }
        public string KupeNo { get; set; }
        public string Adi { get; set; }
        public int CinsiyetId { get; set; }
        public string Cinsiyet { get; set; }
        public int IrkId { get; set; }
        public string Irk { get; set; }
        public int Kilosu { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string DogumTarihiFormatted
        {
            get
            {
                return DogumTarihi.ToString("dd.MM.yyyy");
            }
        }
        public string Fotograf { get; set; }
        public DateTime SuruyeGirisTarihi { get; set; }
        public string SuruyeGirisTarihiFormatted
        {
            get
            {
                return SuruyeGirisTarihi.ToString("dd.MM.yyyy");
            }
        }
        public int SuruyeGirisTipId { get; set; }
        public string SuruyeGirisTipi { get; set; }
        public string AnneKupeNo { get; set; }
        public string BabaKupeNo { get; set; }
        public int SuruGrubuId { get; set; }
        public string SuruGrubu { get; set; }
        public string Aciklama { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string KayitTarihiFormatted
        {
            get
            {
                return KayitTarihi.ToString("dd.MM.yyyy");
            }
        }
        public bool IsSuccess { get; set; }
        public bool GebeMi { get; set; }
        public DateTime? TohumlanmaTarihi { get; set; }
        public string Foto1Base64 { get; set; }
        public string Foto2Base64 { get; set; }
        public string Foto3Base64 { get; set; }
        public string Foto4Base64 { get; set; }
        public List<string> Fotograflar
        {
            get
            {
                List<string> lcl = new List<string>();

                if (Fotograf != null)
                {
                    string[] fotos = Fotograf.Split(',');
                    foreach (var item in fotos)
                    {
                        lcl.Add(item);
                    }
                }
                return lcl;
            }
        }
        public int SuruyeGirisDurumId { get; set; }
        public bool DogumGucMu { get; set; }
        public int DurumBilgisiId { get; set; }
        public DateTime SonDogumYaptigiTarih { get; set; }
        public string SonDogumYaptigiTarihFormatted
        {
            get
            {
                if (SonDogumYaptigiTarih.ToString("dd.MM.yyyy") != "01.01.0001")
                {
                    return SonDogumYaptigiTarih.ToString("dd.MM.yyyy");
                }
                else
                {
                    return "01.01.9999";
                }
            }
        }
        public int GebelikDurumId { get; set; }
        public int PadokId { get; set; }
        public string Padok { get; set; }
        public string DurumOzeti { get; set; }
        public int DurumOzetiId { get; set; }
    }
}