using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TarimCan.Helper;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class HayvanlarController : BaseController
    {

        [UserAuthorizeController]
        public ActionResult Index(int SuruGrubuId = 0, int HayvanId = 0, int DurumOzetiId = 0, int PadokId = 0)
        {

            if (PadokId != 0)
            {
                List<HayvanModel> hayvanlar = new List<HayvanModel>();
                hayvanlar = hm.SurudekiHayvanlariPadogaGoreGetir(PadokId, SessionManager.KullaniciId);
                ViewBag.Hayvanlar = hayvanlar;
                ViewBag.DurumBilgileri = cm.TumDurumBilgileriniGetir();
                ViewBag.SuruGruplari = cm.TumSuruGruplariniGetir();
                ViewBag.SuruGrubuId = SuruGrubuId;
                ViewBag.HayvanSayisi = hayvanlar.Count;

                ViewBag.DurumOzetiId = DurumOzetiId;
                ViewBag.SuruGrubuId = SuruGrubuId;

                return View();
            }

            if (SuruGrubuId != 0)
            {
                ViewBag.SayfaBasligi = cm.SuruGrubuSayfaBasligiGetir(SuruGrubuId).Value;
            }
            else if (DurumOzetiId != 0)
            {
                ViewBag.SayfaBasligi = cm.DurumOzetiSayfaBasligiGetir(DurumOzetiId).Value;
            }
            else
            {
                ViewBag.SayfaBasligi = "Hayvan";
            }

            if (HayvanId == 0)
            {
                List<HayvanModel> hayvanlar = new List<HayvanModel>();
                hayvanlar = hm.SurudekiHayvanlariSahibineGoreGetir(SessionManager.KullaniciId, SuruGrubuId, DurumOzetiId);
                ViewBag.Hayvanlar = hayvanlar;
                ViewBag.DurumBilgileri = cm.TumDurumBilgileriniGetir();
                ViewBag.SuruGruplari = cm.TumSuruGruplariniGetir();
                ViewBag.SuruGrubuId = SuruGrubuId;
                ViewBag.HayvanSayisi = hayvanlar.Count;

                if (hayvanlar.Count == 1)
                {
                    ViewBag.CinsiyetId = hayvanlar[0].CinsiyetId;
                    ViewBag.HayvanId = hayvanlar[0].Id;
                }
                else
                {
                    ViewBag.CinsiyetId = 0;
                    ViewBag.HayvanId = 0;
                }
            }
            else
            {
                List<HayvanModel> hayvan = new List<HayvanModel>();
                hayvan.Add(hm.HayvanDetayiSahibineGoreGetir(HayvanId, SessionManager.KullaniciId));
                ViewBag.Hayvanlar = hayvan;
                ViewBag.CinsiyetId = hayvan[0].CinsiyetId;
                ViewBag.DurumBilgileri = cm.TumDurumBilgileriniGetir();
                ViewBag.SuruGruplari = cm.TumSuruGruplariniGetir();
                ViewBag.HayvanSayisi = 1;
                ViewBag.HayvanId = HayvanId;

                if (hayvan.Count == 1)
                {
                    ViewBag.CinsiyetId = hayvan[0].CinsiyetId;
                    ViewBag.HayvanId = hayvan[0].Id;
                }
                else
                {
                    ViewBag.CinsiyetId = 0;
                    ViewBag.HayvanId = 0;
                }
            }

            ViewBag.DurumOzetiId = DurumOzetiId;
            ViewBag.SuruGrubuId = SuruGrubuId;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanDetayGetir(int HayvanId)
        {
            HayvanDetayResponseModel model = new HayvanDetayResponseModel();

            model.HayvanDetay = hm.HayvanDetayiSahibineGoreGetir(HayvanId, SessionManager.KullaniciId);
            model.DurumHareketleri = hm.HayvanDurumHareketleriGetir(HayvanId, SessionManager.KullaniciId);

            ViewBag.Fotograflar = model.HayvanDetay.Fotograflar;

            if (model != null)
            {
                model.IsSuccess = true;
            }
            else
            {
                model.IsSuccess = false;
                model.Message = "Hayvan bulunamadı...";
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanDurumHareketleriGetirAction(int HayvanId)
        {
            List<DurumHareketModel> list = hm.HayvanDurumHareketleriGetir(HayvanId, SessionManager.KullaniciId);

            HayvanDetayResponseModel model = new HayvanDetayResponseModel();
            if (model != null)
            {
                model.IsSuccess = true;
                model.DurumHareketleri = list;
            }
            else
            {
                model.IsSuccess = false;
                model.Message = "Hareket bulunamadı...";
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [UserAuthorizeController]
        public ActionResult HayvanEkle(int DurumId, int HayvanId)
        {
            int HayvanKacAylik = 0;
            ViewBag.Cinsiyeti = cm.TumHayvanCinsiyetleriniGetir();
            ViewBag.Irki = cm.TumHayvanIrklariniGetir();
            ViewBag.SuruyeGirisTipi = cm.TumSuruyeGirisTipleriniGetir();
            ViewBag.SuruyeGirisDurumlari = cm.TumSuruyeGirisDurumlariGetir();
            ViewBag.Padoklar = cm.IsletmeyeGorePadokGetir(SessionManager.KullaniciId);

            ViewBag.HayvanId = HayvanId;
            ViewBag.DurumId = DurumId;
            ViewBag.BabaKupeNo = "";
            if (hm.SonEklenenIrkIdGetir(SessionManager.KullaniciId) != null)
            {
                ViewBag.SonEklenenIrkId = hm.SonEklenenIrkIdGetir(SessionManager.KullaniciId).IrkId;
            }
            else
            {
                ViewBag.SonEklenenIrkId = 0;
            }

            if (HayvanId == 0)
            {
                ViewBag.IslemTipi = 1; //Ekle
                return View();
            }
            else if (DurumId != 0 && HayvanId != 0)
            {
                HayvanModel hayMod = hm.HayvanDetayiSahibineGoreGetir(HayvanId, SessionManager.KullaniciId);
                ViewBag.AnneKupeNo = hayMod.KupeNo;

                HayvanModel BabaKupeNoModel = hm.TohumlananBabaKupeNoGetir(HayvanId, SessionManager.KullaniciId);
                if (BabaKupeNoModel != null)
                {
                    ViewBag.BabaKupeNo = BabaKupeNoModel.BabaKupeNo;
                }
                else
                {
                    ViewBag.BabaKupeNo = "";
                }
                ViewBag.IrkId = hayMod.IrkId;
                ViewBag.IslemTipi = 1; //Ekle
                return View();
            }
            else
            {
                HayvanModel hayMod = hm.HayvanDetayiSahibineGoreGetir(HayvanId, SessionManager.KullaniciId);
                ViewBag.IrkId = hayMod.IrkId;
                ViewBag.SuruyeGirisTipId = hayMod.SuruyeGirisTipId;
                ViewBag.CinsiyetId = hayMod.CinsiyetId;
                ViewBag.Fotograf = hayMod.Fotograf;
                ViewBag.PhotoCount = hayMod.Fotograflar.Count;
                ViewBag.IslemTipi = 2; //Güncelle

                TimeSpan HayvanGun = DateTime.Now - hayMod.DogumTarihi;
                ViewBag.HayvanKacAylik = HayvanGun.Days / 30;

                return View(hayMod);
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken()]
        //public JsonResult HayvanEkleAction(HayvanModel model)
        //{
        //    SiteResponseModel srm = new SiteResponseModel();

        //    try
        //    {
        //        if (SessionManager.HayvanTohumlamaAyi != 0)
        //        {

        //            model.Fotograf = helper.TopluHayvanResmiKaydet(model);

        //            DBCheckModel dbC = hm.HayvanKaydet(model);
        //            if (dbC.ReturnValue == 1)
        //            {

        //                hm.HayvanSuruGruplariniGuncell();
        //                srm.IsSuccess = true;
        //                srm.Message = "Kayıt başarılı...";
        //            }
        //            else if (dbC.ReturnValue == 2)
        //            {
        //                srm.IsSuccess = false;
        //                srm.Message = dbC.ReturnMessage;
        //            }
        //            else
        //            {
        //                srm.IsSuccess = false;
        //                srm.Message = "Kayıt sırasında hata oluştu...";
        //            }
        //        }
        //        else
        //        {
        //            srm.IsSuccess = false;
        //            srm.Message = "Hayvan tohumlama başlangıç ayı girilmeli...";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        srm.IsSuccess = false;
        //        srm.MessageCode = -1;
        //        srm.Message = ex.ToString();
        //    }

        //    return Json(srm, JsonRequestBehavior.AllowGet);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanEkleAction(HayvanModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                if (SessionManager.HayvanTohumlamaAyi != 0)
                {

                    model.Fotograf = helper.TopluHayvanResmiKaydet(model.Foto1Base64, model.Foto2Base64, model.Foto3Base64, model.Foto4Base64);

                    DBCheckModel dbC = hm.HayvanKaydet(model, SessionManager.KullaniciId);
                    if (dbC.ReturnValue == 1)
                    {
                        int KayitEdilenHayvanId = Convert.ToInt32(dbC.ReturnMessage);
                        DurumHareketModel dhm = new DurumHareketModel();
                        int DogumdanItibarenGecenGunSayisi = 0;

                        hm.HayvanSuruGruplariniGuncell(SessionManager.KullaniciId);

                        if (model.SonDogumYaptigiTarih.Year != 9999)
                        {
                            // Hayvan doğum kaydı ekleniyor...
                            dhm = new DurumHareketModel();
                            dhm.HayvanId = KayitEdilenHayvanId;
                            dhm.DurumBilgisiId = 6;
                            dhm.IslemTarihi = model.SonDogumYaptigiTarih;
                            dhm.IslemSonlandiMi = false;
                            hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);

                            // Doğum tarihinin 280 gün öncesine gebelik kaydı ekleniyor...
                            dhm = new DurumHareketModel();
                            dhm.HayvanId = KayitEdilenHayvanId;
                            dhm.DurumBilgisiId = 3;
                            dhm.IslemTarihi = model.SonDogumYaptigiTarih.AddDays(-280);
                            dhm.IslemSonlandiMi = true;
                            hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);

                            // Doğum tarihinin 280 gün öncesine tohumlanma kaydı ekleniyor...
                            dhm = new DurumHareketModel();
                            dhm.HayvanId = KayitEdilenHayvanId;
                            dhm.DurumBilgisiId = 4;
                            dhm.IslemTarihi = model.SonDogumYaptigiTarih.AddDays(-280);
                            dhm.IslemSonlandiMi = true;
                            hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);

                            TimeSpan ts = DateTime.Now - model.SonDogumYaptigiTarih;

                            DogumdanItibarenGecenGunSayisi = Convert.ToInt32(ts.TotalDays);

                            if (DogumdanItibarenGecenGunSayisi <= 45)
                            {
                                dhm = new DurumHareketModel();
                                dhm.HayvanId = KayitEdilenHayvanId;
                                dhm.DurumBilgisiId = 21;
                                dhm.IslemTarihi = model.SonDogumYaptigiTarih;
                                dhm.IslemSonlandiMi = false;
                                hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                            }
                        }

                        //Sağmal
                        if (model.SuruyeGirisDurumId == 20) // Sağmal
                        {
                            // Update Padok

                            //Sağmal Durumu atıldı
                            dhm.HayvanId = KayitEdilenHayvanId;
                            dhm.DurumBilgisiId = 20;
                            dhm.IslemTarihi = model.SonDogumYaptigiTarih;
                            //dhm.Aciklama = "Sağmala alındı";
                            dhm.IslemSonlandiMi = false;
                            hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);

                            //Gebelik Durumu
                            if (model.GebelikDurumId == 3) // Gebe
                            {
                                // Gebe
                                dhm = new DurumHareketModel();
                                dhm.HayvanId = KayitEdilenHayvanId;
                                dhm.DurumBilgisiId = 3;
                                dhm.IslemTarihi = model.TohumlanmaTarihi.Value;
                                dhm.IslemSonlandiMi = false;
                                hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);

                                //Tohumlandı
                                dhm = new DurumHareketModel();
                                dhm.HayvanId = KayitEdilenHayvanId;
                                dhm.DurumBilgisiId = 4;
                                dhm.IslemTarihi = model.TohumlanmaTarihi.Value;
                                dhm.IslemSonlandiMi = true;
                                hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                            }
                            else if (model.GebelikDurumId == 4) // Tohumlandı
                            {
                                dhm = new DurumHareketModel();
                                dhm.HayvanId = KayitEdilenHayvanId;
                                dhm.DurumBilgisiId = 4;
                                dhm.IslemTarihi = model.TohumlanmaTarihi.Value;
                                //dhm.Aciklama = "Tohumlandı";
                                dhm.IslemSonlandiMi = false;
                                hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                            }
                            else if (model.GebelikDurumId == 19 && DogumdanItibarenGecenGunSayisi >= 45)
                            {
                                // Boş seçilmiş bile olsa. Doğumdan itibaren 45 günü geçmediyse hayvanı boşa almıyoruz. 
                                dhm = new DurumHareketModel();
                                dhm.HayvanId = KayitEdilenHayvanId;
                                dhm.DurumBilgisiId = 19;
                                dhm.IslemTarihi = model.SonDogumYaptigiTarih;
                                //dhm.Aciklama = "Boşa alındı";
                                dhm.IslemSonlandiMi = false;
                                hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                            }
                        }

                        // Kuru ise
                        if (model.SuruyeGirisDurumId == 8)
                        {
                            //Gebelik Eklendi
                            dhm = new DurumHareketModel();
                            dhm.HayvanId = KayitEdilenHayvanId;
                            dhm.DurumBilgisiId = 3;
                            dhm.IslemTarihi = model.TohumlanmaTarihi.Value;
                            dhm.IslemSonlandiMi = false;
                            hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);

                            //Tohumlandı
                            dhm = new DurumHareketModel();
                            dhm.HayvanId = KayitEdilenHayvanId;
                            dhm.DurumBilgisiId = 4;
                            dhm.IslemTarihi = model.TohumlanmaTarihi.Value;
                            dhm.IslemSonlandiMi = true;
                            hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);

                            //Kuru
                            dhm = new DurumHareketModel();
                            dhm.HayvanId = KayitEdilenHayvanId;
                            dhm.DurumBilgisiId = 8;
                            dhm.IslemTarihi = model.TohumlanmaTarihi.Value.AddDays(270);
                            dhm.IslemSonlandiMi = false;
                            hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                        }

                        // Boş Kuru ise
                        if (model.SuruyeGirisDurumId == 22)
                        {
                            dhm = new DurumHareketModel();
                            dhm.HayvanId = KayitEdilenHayvanId;
                            dhm.DurumBilgisiId = 22;
                            dhm.IslemTarihi = model.SuruyeGirisTarihi;
                            dhm.IslemSonlandiMi = false;
                            hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                        }

                        if (model.SuruyeGirisDurumId == 0)
                        {
                            if (model.GebelikDurumId == 4)
                            {
                                dhm = new DurumHareketModel();
                                dhm.HayvanId = KayitEdilenHayvanId;
                                dhm.DurumBilgisiId = 4;
                                dhm.IslemTarihi = model.TohumlanmaTarihi.Value;
                                //dhm.Aciklama = "Tohumlandı";
                                dhm.IslemSonlandiMi = false;
                                hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                            }
                            else if (model.GebelikDurumId == 3)
                            {
                                // Gebe
                                dhm = new DurumHareketModel();
                                dhm.HayvanId = KayitEdilenHayvanId;
                                dhm.DurumBilgisiId = 3;
                                dhm.IslemTarihi = model.TohumlanmaTarihi.Value;
                                dhm.IslemSonlandiMi = false;
                                hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);

                                //Tohumlandı
                                dhm = new DurumHareketModel();
                                dhm.HayvanId = KayitEdilenHayvanId;
                                dhm.DurumBilgisiId = 4;
                                dhm.IslemTarihi = model.TohumlanmaTarihi.Value;
                                dhm.IslemSonlandiMi = true;
                                hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                            }
                            else if (model.GebelikDurumId == 19)
                            {
                                //Boş
                                dhm = new DurumHareketModel();
                                dhm.HayvanId = KayitEdilenHayvanId;
                                dhm.DurumBilgisiId = 19;
                                dhm.IslemTarihi = model.SonDogumYaptigiTarih;
                                //dhm.Aciklama = "Boşa alındı";
                                dhm.IslemSonlandiMi = false;
                                hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                            }
                        }

                        hm.GunlukHayvanVerileriniGuncelle(KayitEdilenHayvanId);

                        srm.IsSuccess = true;
                        srm.Message = "Kayıt başarılı...";
                    }
                    else if (dbC.ReturnValue == 2)
                    {
                        srm.IsSuccess = false;
                        srm.Message = dbC.ReturnMessage;
                    }
                    else
                    {
                        srm.IsSuccess = false;
                        srm.Message = "Kayıt sırasında hata oluştu...";
                    }
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Hayvan tohumlama başlangıç ayı girilmeli...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }

            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken()]
        //public JsonResult HayvanGuncelleAction(HayvanModel model)
        //{
        //    SiteResponseModel srm = new SiteResponseModel();

        //    try
        //    {
        //        if (model.Fotograf != null)
        //        {
        //            model.Fotograf += "," + helper.TopluHayvanResmiKaydet(model);
        //        }
        //        else
        //        {
        //            model.Fotograf = helper.TopluHayvanResmiKaydet(model);
        //        }

        //        DBCheckModel dbC = hm.HayvanGuncelle(model);
        //        if (dbC.ReturnValue == 1)
        //        {
        //            hm.HayvanSuruGruplariniGuncell();
        //            srm.IsSuccess = true;
        //            srm.Message = "Kayıt başarılı...";
        //        }
        //        else if (dbC.ReturnValue == 2)
        //        {
        //            srm.IsSuccess = false;
        //            srm.Message = dbC.ReturnMessage;
        //        }
        //        else
        //        {
        //            srm.IsSuccess = false;
        //            srm.Message = "Kayıt sırasında hata oluştu...";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        srm.IsSuccess = false;
        //        srm.MessageCode = -1;
        //        srm.Message = ex.ToString();
        //    }

        //    return Json(srm, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanDurumEkleAction(DurumHareketModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbCKontrol = hm.HayvanDurumEkleUygunlukKontrol(model.DurumBilgisiId, model.HayvanId);

                if (dbCKontrol.ReturnValue == 1)
                {
                    DBCheckModel dbC = hm.HayvanDurumHereketiEkle(model, SessionManager.KullaniciId);
                    if (dbC.ReturnValue == 1)
                    {
                        srm.IsSuccess = true;
                        srm.Message = "Kayıt başarılı...";

                        hm.GunlukHayvanVerileriniGuncelle(model.HayvanId);
                    }
                    else
                    {
                        srm.IsSuccess = false;
                        srm.Message = "Kayıt sırasında hata oluştu...";
                    }
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = dbCKontrol.ReturnMessage;
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }
            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanDurumUygunlukKontrol(DurumHareketModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbCKontrol = hm.HayvanDurumEkleUygunlukKontrol(model.DurumBilgisiId, model.HayvanId);

                if (dbCKontrol.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Uygun";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = dbCKontrol.ReturnMessage;
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }
            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanAraAction(HayvanModel model)
        {
            string sql = "";
            if (model.SuruGrubuId == 0)
            {
                sql = "Select h.Id, KupeNo, Adi, h.CinsiyetId, SuruyeGirisTarihi, DogumTarihi, c.Cinsiyet, sg.SuruGrubu " +
                    "From Hayvanlar h, TnmHayvanCinsiyeti c, TnmSuruGrubu sg Where SahipId = " + SessionManager.KullaniciId + " And h.SuruGrubuId = sg.Id And h.CinsiyetId = c.Id And h.AktifMi = 'True' And ";
            }
            else
            {
                sql = "Select h.Id, KupeNo, Adi, h.CinsiyetId, SuruyeGirisTarihi, DogumTarihi, c.Cinsiyet, sg.SuruGrubu " +
                    "From Hayvanlar h, TnmHayvanCinsiyeti c, TnmSuruGrubu sg Where SahipId = " + SessionManager.KullaniciId + " And h.SuruGrubuId = sg.Id And  h.SuruGrubuId = " + model.SuruGrubuId + " And h.CinsiyetId = c.Id And h.AktifMi = 'True' And ";
            }

            if (model.KupeNo != null)
            {
                sql += "KupeNo Like '%" + helper.ReplaceInjectionChar(model.KupeNo) + "%' And ";
            }

            if (model.Adi != null)
            {
                sql += "Adi Like '%" + helper.ReplaceInjectionChar(model.Adi) + "%' And ";
            }

            if (model.Aciklama != null)
            {
                sql += "Aciklama Like '%" + helper.ReplaceInjectionChar(model.Aciklama) + "%' And ";
            }

            if (model.CinsiyetId != 0)
            {
                sql += "h.CinsiyetId = " + model.CinsiyetId + " And ";
            }

            sql = sql.Substring(0, sql.Length - 4);

            sql += " Order By KupeNo";

            List<HayvanModel> list = hm.HayvanModelSql(sql);

            return Json(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult CheckDogumTarihi(DateTime DogumTarihi)
        {
            SiteResponseModel srm = new SiteResponseModel();

            int GebeMiValue = 0;
            int SonDogumDurumuVal = 0;

            if (DateTime.Now < DogumTarihi)
            {
                srm.IsSuccess = false;
                srm.Message = "Doğum Tarihi bugünden küçük olamaz...";
            }
            else
            {
                TimeSpan ts = DateTime.Now - DogumTarihi;
                int days = Convert.ToInt32(ts.TotalDays);

                decimal mounts = days / 30;

                if (Math.Ceiling(mounts) > SessionManager.HayvanTohumlamaAyi)
                {
                    GebeMiValue = 1;
                }

                if (Math.Ceiling(mounts) > 20) //13 aydan büyük ise son dogum tarihi giriliyor. 
                {
                    SonDogumDurumuVal = 1;
                }
            }

            return Json(new { GebeMiValue = GebeMiValue, SonDogumDurumuVal = SonDogumDurumuVal }, JsonRequestBehavior.AllowGet);
        }

        [UserAuthorizeController]
        public ActionResult TopluHayvanYukleme()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanDurumSilAction(HayvanModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = hm.HayvanDurumSil(model, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Durum Hareketi Silindi...";
                }
                else if (dbC.ReturnValue == 2)
                {
                    srm.IsSuccess = false;
                    srm.Message = dbC.ReturnMessage;
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }

            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [UserAuthorizeController]
        public ActionResult KesimOlum(int DurumId, int HayvanId)
        {
            ViewBag.HayvanId = HayvanId;
            ViewBag.DurumId = DurumId;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanOlumEkleAction(DurumHareketModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = hm.HayvanDurumHereketiEkle(model, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "İşlem başarılı.";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt sırasında hata oluştu...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }
            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [UserAuthorizeController]
        public ActionResult HayvanDetay(int id)
        {

            HayvanDetayResponseModel model = new HayvanDetayResponseModel();

            model.HayvanDetay = hm.HayvanDetayiSahibineGoreGetir(id, SessionManager.KullaniciId);
            model.DurumHareketleri = hm.HayvanDurumHareketleriGetir(id, SessionManager.KullaniciId);
            model.DurumHareketleriReverse = hm.HayvanDurumHareketleriGetir(id, SessionManager.KullaniciId);

            model.DurumHareketleriReverse.Reverse();
            ViewBag.HayvanAsiList = asiMan.HayvanAsiSelect(id); ;

            if (model.HayvanDetay.Fotograflar != null)
            {
                ViewBag.Fotograflar = model.HayvanDetay.Fotograflar;
            }

            //HayvanModel model = hm.HayvanDetayiSahibineGoreGetir(id);
            //ViewBag.CinsiyetId = model.CinsiyetId;
            ViewBag.DurumBilgileri = cm.TumDurumBilgileriniGetir();
            ViewBag.SuruGruplari = cm.TumSuruGruplariniGetir();
            //ViewBag.HayvanSayisi = 1;
            //ViewBag.HayvanId = model;

            return View(model);
        }

        [UserAuthorizeController]
        public ActionResult Tohumlama(int HayvanId)
        {
            ViewBag.HayvanId = HayvanId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult TohumlamaKaydetAction(int HayvanId, DateTime IslemTarihi, decimal IslemUcreti = 0, string BabaKupeNo = "", string Aciklama = "")
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = hm.HayvanTohumlamaBilgisiEkle(HayvanId, IslemTarihi, BabaKupeNo, IslemUcreti, Aciklama, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt sırasında hata oluştu...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }
            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [UserAuthorizeController]
        public ActionResult HastalikEkle(int HayvanId)
        {
            ViewBag.Hastaliklar = cm.TumHastaliklariGetir();
            ViewBag.HayvanId = HayvanId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HastalikEkleAction(int HayvanId, DateTime IslemTarihi, int HastalikId, string KullanilanIlac,
            decimal KullanilanIlacMaliyeti, string VeterinerHekim, decimal VeterinerHekimMaliyeti, string Aciklama, string DigerHastalik)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = hm.HayvanHastalikEkle(HayvanId, IslemTarihi, HastalikId, KullanilanIlac, KullanilanIlacMaliyeti, VeterinerHekim, VeterinerHekimMaliyeti, Aciklama, DigerHastalik, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt sırasında hata oluştu...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }
            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [UserAuthorizeController]
        public ActionResult SatisYap(int HayvanId)
        {
            ViewBag.Hastaliklar = cm.TumHastaliklariGetir();
            ViewBag.HayvanId = HayvanId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult SatisYapAction(int HayvanId, DateTime IslemTarihi, int IslemTipId, int KarkasAgirligi, decimal SatisFiyati, string Aciklama)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = hm.HayvanKesimSatisBilgisiEkle(HayvanId, IslemTarihi, IslemTipId, KarkasAgirligi, SatisFiyati, Aciklama, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt sırasında hata oluştu...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }
            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [UserAuthorizeController]
        public ActionResult TohumlananListesi()
        {
            HayvanModel tohumOraniModel = rprMan.TohumlananHayvanlarinGebelikDurumunuGetir(SessionManager.KullaniciId);
            ViewBag.DuveOrani = tohumOraniModel.DuveGebeKalmaOrani.ToString("0.00");
            ViewBag.InekOrani = tohumOraniModel.InekGebeKalmaOrani.ToString("0.00");

            List<HayvanModel> hayvanlar = new List<HayvanModel>();
            hayvanlar = hm.TohumlananHayvanlariGetir(SessionManager.KullaniciId);
            ViewBag.Hayvanlar = hayvanlar;
            return View();
        }

        [UserAuthorizeController]
        public ActionResult SaglikKarnesi(int id)
        {
            HayvanModel detay = hm.HayvanDetayiSahibineGoreGetir(id, SessionManager.KullaniciId);
            ViewBag.Adi = detay.Adi;
            ViewBag.KupeNo = detay.KupeNo;
            ViewBag.Irk = detay.Irk;
            ViewBag.DogumTarihi = detay.DogumTarihi.ToString("dd.MM.yyyy");

            return View(hm.HayvanSaglikKarnesiGetir(id, SessionManager.KullaniciId));
        }

        [UserAuthorizeController]
        public ActionResult HastaHayvanlar()
        {
            List<HayvanModel> hayvanlar = new List<HayvanModel>();
            hayvanlar = hm.SurudekiHayvanlariSahibineGoreGetir(SessionManager.KullaniciId, 0, 2);

            return View(hayvanlar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult TedaviBilgisiEkle(TedaviModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = hm.TedaviEkle(model, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt sırasında hata oluştu...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }
            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [UserAuthorizeController]
        public ActionResult GebeHayvanlar()
        {

            List<HayvanModel> hayvanlar = new List<HayvanModel>();
            hayvanlar = hm.GebeHayvanLitesiDetayGetir(SessionManager.KullaniciId);
            ViewBag.Hayvanlar = hayvanlar;
            ViewBag.DurumBilgileri = cm.TumDurumBilgileriniGetir();
            ViewBag.SuruGruplari = cm.TumSuruGruplariniGetir();
            ViewBag.HayvanSayisi = hayvanlar.Count;

            if (hayvanlar.Count == 1)
            {
                ViewBag.CinsiyetId = hayvanlar[0].CinsiyetId;
                ViewBag.HayvanId = hayvanlar[0].Id;
            }
            else
            {
                ViewBag.CinsiyetId = 0;
                ViewBag.HayvanId = 0;
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanTohumlanmaAyiGuncelleAction(int HayvanTohumlamaAyi)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = km.HayvanTohumlanmaAyiGuncelle(HayvanTohumlamaAyi, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    SessionManager.HayvanTohumlamaAyiKaydet(HayvanTohumlamaAyi);
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt sırasında hata oluştu...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }
            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [UserAuthorizeController]
        public ActionResult IsletmedenAyrilanHayvanlar()
        {
            ViewBag.Hayvanlar = hm.IsletmedenAyrilanHayvanlariGetir(SessionManager.KullaniciId);
            return View();
        }

        [UserAuthorizeController]
        public ActionResult TazeHayvanlar()
        {
            List<HayvanModel> hayvanlar = new List<HayvanModel>();
            hayvanlar = hm.TazeHayvanListesiniGetir(SessionManager.KullaniciId);
            ViewBag.Hayvanlar = hayvanlar;
            ViewBag.DurumBilgileri = cm.TumDurumBilgileriniGetir();
            ViewBag.SuruGruplari = cm.TumSuruGruplariniGetir();
            ViewBag.HayvanSayisi = hayvanlar.Count;

            if (hayvanlar.Count == 1)
            {
                ViewBag.CinsiyetId = hayvanlar[0].CinsiyetId;
                ViewBag.HayvanId = hayvanlar[0].Id;
            }
            else
            {
                ViewBag.CinsiyetId = 0;
                ViewBag.HayvanId = 0;
            }
            return View();
        }

        [UserAuthorizeController]
        public ActionResult BosKuruHayvanlar()
        {
            List<HayvanModel> hayvanlar = new List<HayvanModel>();
            hayvanlar = hm.BosKuruHayvanListesiniGetir(SessionManager.KullaniciId);
            ViewBag.Hayvanlar = hayvanlar;
            ViewBag.DurumBilgileri = cm.TumDurumBilgileriniGetir();
            ViewBag.SuruGruplari = cm.TumSuruGruplariniGetir();
            ViewBag.HayvanSayisi = hayvanlar.Count;

            if (hayvanlar.Count == 1)
            {
                ViewBag.CinsiyetId = hayvanlar[0].CinsiyetId;
                ViewBag.HayvanId = hayvanlar[0].Id;
            }
            else
            {
                ViewBag.CinsiyetId = 0;
                ViewBag.HayvanId = 0;
            }
            return View();
        }

        [UserAuthorizeController]
        public ActionResult Inekler()
        {
            List<HayvanModel> hayvanlar = new List<HayvanModel>();
            hayvanlar = hm.InekleriGetir(SessionManager.KullaniciId);
            return View(hayvanlar);
        }

        [UserAuthorizeController]
        public ActionResult KuruHayvanlar()
        {
            List<HayvanModel> hayvanlar = new List<HayvanModel>();
            hayvanlar = hm.KurudakiHayvanlariGetir(SessionManager.KullaniciId);
            ViewBag.Hayvanlar = hayvanlar;
            ViewBag.HayvanSayisi = hayvanlar.Count;
            return View();
        }

        [UserAuthorizeController]
        public ActionResult SagmalHayvanlar()
        {
            AnaSayfaIsletmeDurumModel isletmeDurumu = cm.AnaSayfaIsletmeDurumuGetir(SessionManager.KullaniciId);
            ViewBag.SGSDegeri = isletmeDurumu.SGSDegeri;

            List<HayvanModel> hayvanlar = new List<HayvanModel>();
            hayvanlar = hm.SagmalHayvanlariGetir(SessionManager.KullaniciId);
            ViewBag.Hayvanlar = hayvanlar;
            ViewBag.HayvanSayisi = hayvanlar.Count;
            return View();
        }

        [UserAuthorizeController]
        public ActionResult BosHayvanlar()
        {
            List<HayvanModel> hayvanlar = new List<HayvanModel>();
            hayvanlar = hm.BosHayvanlariGetir(SessionManager.KullaniciId);
            ViewBag.Hayvanlar = hayvanlar;
            ViewBag.HayvanSayisi = hayvanlar.Count;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanSilAction(int HayvanId)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = hm.HayvanSilAction(HayvanId, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt sırasında hata oluştu...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }
            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [UserAuthorizeController]
        public ActionResult HayvanGuncelle(int id)
        {
            HayvanDetayResponseModel model = new HayvanDetayResponseModel();

            model.HayvanDetay = hm.HayvanDetayiSahibineGoreGetir(id, SessionManager.KullaniciId);
            model.DurumHareketleri = hm.HayvanDurumHareketleriGetir(id, SessionManager.KullaniciId);

            if (model.HayvanDetay.Fotograflar != null)
            {
                ViewBag.Fotograflar = model.HayvanDetay.Fotograflar;
            }

            ViewBag.Cinsiyeti = cm.TumHayvanCinsiyetleriniGetir();
            ViewBag.Irki = cm.TumHayvanIrklariniGetir();
            ViewBag.SuruyeGirisTipi = cm.TumSuruyeGirisTipleriniGetir();
            ViewBag.SuruyeGirisDurumlari = cm.TumSuruyeGirisDurumlariGetir();
            ViewBag.Padoklar = cm.IsletmeyeGorePadokGetir(SessionManager.KullaniciId);
            ViewBag.DurumBilgileri = cm.TumDurumBilgileriniGetir();
            ViewBag.SuruGruplari = cm.TumSuruGruplariniGetir();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanGuncelleAction(HayvanModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = hm.HayvanGuncelle(model, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt sırasında hata oluştu...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }
            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult HayvanDurumGuncelleAction(DurumHareketModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = hm.HayvanDurumHereketiGuncelle(model);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt başarılı...";
                }
                else
                {
                    srm.IsSuccess = false;
                    srm.Message = "Kayıt sırasında hata oluştu...";
                }
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }
            return Json(srm, JsonRequestBehavior.AllowGet);
        }

    }
}