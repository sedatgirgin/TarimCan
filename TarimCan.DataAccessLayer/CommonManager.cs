﻿using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Mvc;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class CommonManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public List<SelectListItem> TumSehirleriGetir()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_TumSehirleriGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<SelectListItem> TumIlceleriGetir(int SehirId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_SehirId", SehirId));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_TumIlceleriGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<IdValueModel> TumIlceleriListeOlarakGetir(int SehirId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_SehirId", SehirId));
            return sda.ExecuteObject<IdValueModel>("sp_TumIlceleriGetir", lstParam);
        }

        public List<SelectListItem> TumMahalleleriGetir(int IlceId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IlceId", IlceId));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_TumMahalleleriGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<IdValueModel> TumIMahalleleriListeOlarakGetir(int IlceId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IlceId", IlceId));
            return sda.ExecuteObject<IdValueModel>("sp_TumMahalleleriGetir", lstParam);
        }

        public List<IdValueModel> AltDurumBilgileriniGetir(int DurumBilgisiId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", 3));
            lstParam.Add(new SqlParameter("@p_ParentId", DurumBilgisiId));
            return sda.ExecuteObject<IdValueModel>("sp_TnmDurumBilgileri", lstParam);
        }

        public List<SelectListItem> TumDurumBilgileriniGetir()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", 0));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_TnmDurumBilgileri", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<SelectListItem> TumHayvanCinsiyetleriniGetir()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", 0));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_TnmHayvanCinsiyetleri", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<IdValueModel> TumHayvanIrklariniListeGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", 0));
            return sda.ExecuteObject<IdValueModel>("sp_TnmHayvanIrklari", lstParam);
        }


        public List<SelectListItem> TumHayvanIrklariniGetir()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", 0));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_TnmHayvanIrklari", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<IdValueModel> TumSuruGruplariniListeGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", 0));
            return sda.ExecuteObject<IdValueModel>("sp_TnmHayvanSuruGruplari", lstParam);
        }

        public List<SelectListItem> TumSuruGruplariniGetir()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", 0));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_TnmHayvanSuruGruplari", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<IdValueModel> TumSuruyeGirisTipleriniListeGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", 0));
            return sda.ExecuteObject<IdValueModel>("sp_TnmHayvanSuruyeGirisTipleri", lstParam);
        }

        public List<SelectListItem> TumSuruyeGirisTipleriniGetir()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IslemId", 0));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_TnmHayvanSuruyeGirisTipleri", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }
        public AnaSayfaIsletmeDurumModel AnaSayfaIsletmeDurumuGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExcuteReturnObject<AnaSayfaIsletmeDurumModel>("sp_AnaSayfa_IsletmeDurumOzetiGetir", lstParam);
        }

        public DBCheckModel AnahtarKelimeKaydet(AnahtarKelimeModel model, int IsletmeId, string IPAdress)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pAnahtarKelime", model.AnahtarKelime));
            lstParam.Add(new SqlParameter("@pGorusVeOneri", model.GorusVeOneri));
            lstParam.Add(new SqlParameter("@pKayitIpAdresi", IPAdress));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_AnahtarKelimeKaydet", lstParam);
        }

        public List<SelectListItem> TumSuruyeGirisDurumlariGetir()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_TnmSuruyeGirisDurumlari", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<SelectListItem> TumHayvanlariSelectListOlarakGetir(int IsletmeId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", IsletmeId));
            lstParam.Add(new SqlParameter("@pSuruGrubuId", 0));
            List<HayvanModel> hayvanlar = sda.ExecuteObject<HayvanModel>("sp_SurudekiHayvanlariSahibineGoreGetir", lstParam);

            foreach (var item in hayvanlar)
            {
                items.Add(new SelectListItem { Text = item.KupeNo, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<SelectListItem> IsletmeyeGorePadokGetir(int IsletmeId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IsletmeId", IsletmeId));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_IsletmeyeGorePadokGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public DBCheckModel KullaniciPadokKaydet(PadokModel model, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pPadok", model.PadokAdi));
            lstParam.Add(new SqlParameter("@pIcon", model.Icon));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_KullaniciPadokKaydet", lstParam);
        }

        public DBCheckModel KullaniciPadokSil(int PadokId, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pPadokId", PadokId));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_KullaniciPadokSil", lstParam);
        }

        public List<SelectListItem> TumHastaliklariGetir()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<IdValueModel> list = AltDurumBilgileriniGetir(2);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public IdValueModel SuruGrubuSayfaBasligiGetir(int SayfaId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSayfaId", SayfaId));
            lstParam.Add(new SqlParameter("@pTip", 1));
            return sda.ExcuteReturnObject<IdValueModel>("sp_GetSayfaAdi", lstParam);
        }

        public IdValueModel DurumOzetiSayfaBasligiGetir(int SayfaId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSayfaId", SayfaId));
            lstParam.Add(new SqlParameter("@pTip", 2));
            return sda.ExcuteReturnObject<IdValueModel>("sp_GetSayfaAdi", lstParam);
        }

        public List<SelectListItem> KabaYemleriGetir(int IsletmeId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_KabaYemleriGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<SelectListItem> KesifYemleriGetir(int IsletmeId, int UstMenuId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pUstMenuUd", UstMenuId));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_KesifYemleriGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<SelectListItem> KesifYemBirimMiktariGetir()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_KesifYemBirimMiktariGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<SelectListItem> IsletmeYemStoklariGetir(int IsletmeId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pIslemTipId", 1));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_IsletmeYemStoklariGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<SelectListItem> IsletmeRasyonlariniGetir(int IsletmeId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_IsletmeRasyonlariniGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<SelectListItem> IsletmeGelirGiderTipleriGetir(string Tipi)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pTipi", Tipi));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_IsletmeGelirGiderTipleriGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            items.Add(new SelectListItem { Text = "Diğer", Value = "999999" });
            return items;
        }

        public List<SelectListItem> IsTakipKategorileriGetir()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_TnmIsTakipKategorileri", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<SelectListItem> DemirbasTipleriGetir(int ModulId, int IsletmeId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pModulId", ModulId));
            lstParam.Add(new SqlParameter("@pIslemTipId", 1));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_TnmDemirbasTipleriGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<SelectListItem> DemirbasYerleriGetir(int IsletmeId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pIslemTipId", 1));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_TnmDemirbasYerleriGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public DBCheckModel IsletmeDemirbasTipiKaydet(string Value, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pDemirbasTipi", Value));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_DemirbasTipiKaydet", lstParam);
        }

        public DBCheckModel IsletmeDemirbasYeriKaydet(string Value, int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            lstParam.Add(new SqlParameter("@pDemirbasYeri", Value));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_DemirbasYeriKaydet", lstParam);
        }

        public SinavSonucuModel SinavSonucuGetir(long TCKimlikNo)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pTCKimlikNo", TCKimlikNo.ToString()));
            return sda.ExcuteReturnObject<SinavSonucuModel>("sp_SinavSonucuGetir", lstParam);
        }

        public DBCheckModel BackupDatabase()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            return sda.ExcuteReturnObject<DBCheckModel>("sp_sys_BackupDatabase", lstParam);
        }

        public DBCheckModel YemStogundanGunlukRasyonuDus()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            return sda.ExcuteReturnObject<DBCheckModel>("sp_YemStogundanGunlukRasyonMiktariDus", lstParam);
        }

        public AnaSayfaIsletmeDurumModel AnaSayfaOzetGetir(int IsletmeId)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", IsletmeId));
            return sda.ExcuteReturnObject<AnaSayfaIsletmeDurumModel>("sp_AnaSayfaOzetVeriGetir", lstParam);
        }

        public DBCheckModel DogumuYaklasanHayvanlariAjandayaEkle()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            return sda.ExcuteReturnObject<DBCheckModel>("sp_DogumuYaklasanHayvanlariAjandayaEkle", lstParam);
        }


    }
}