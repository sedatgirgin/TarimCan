using System.Web.Mvc;
using TarimCan.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using TarimCan.App_Helper;

namespace SuruTakip.DataAccessLayer
{
    public class CommonManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();
        UIHelper helper = new UIHelper();

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

        public AnaSayfaIstatistiklerModel AnaSayfaIstatistikleriGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            return sda.ExcuteReturnObject<AnaSayfaIstatistiklerModel>("sp_AnaSayfaIstatistikleriGetir", lstParam);
        }

        public AnaSayfaIstatistiklerModel AnaSayfaDurumOzetiGetir()
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKullaniciId", SessionManager.AktifKullanici.Id));
            return sda.ExcuteReturnObject<AnaSayfaIstatistiklerModel>("sp_HayvanDurumOzetiGetir", lstParam);
        }

        public DBCheckModel AnahtarKelimeKaydet(AnahtarKelimeModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKullaniciId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pAnahtarKelime", model.AnahtarKelime));
            lstParam.Add(new SqlParameter("@pGorusVeOneri", model.GorusVeOneri));
            lstParam.Add(new SqlParameter("@pKayitIpAdresi", helper.GetIPAddress())); 
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

        public List<SelectListItem> TumHayvanlariSelectListOlarakGetir()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pSahipId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pSuruGrubuId", 0));
            List<HayvanModel> hayvanlar = sda.ExecuteObject<HayvanModel>("sp_SurudekiHayvanlariSahibineGoreGetir", lstParam);

            foreach (var item in hayvanlar)
            {
                items.Add(new SelectListItem { Text = item.KupeNo, Value = item.Id.ToString() });
            }
            return items;
        }

        public List<SelectListItem> IsletmeyeGorePadokGetir()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@p_IsletmeId", SessionManager.AktifKullanici.Id));
            List<IdValueModel> list = sda.ExecuteObject<IdValueModel>("sp_IsletmeyeGorePadokGetir", lstParam);

            foreach (var item in list)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
            }
            return items;
        }

        public DBCheckModel KullaniciPadokKaydet(string Padok)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pIsletmeId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pPadok", Padok));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_KullaniciPadokKaydet", lstParam);
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

    }
}