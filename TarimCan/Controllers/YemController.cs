using System;
using System.Linq;
using System.Web.Mvc;
using TarimCan.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using TarimCan.Helper;

namespace TarimCan.Controllers
{
    public class YemController : BaseController
    {
        [UserAuthorizeController]
        public ActionResult KabaYemStokEkle()
        {
            ViewBag.IsletmeYemStoklari = ym.IsletmeYemStogonuGetir(SessionManager.KullaniciId).Where(q => q.YemTipId == 1).ToList();
            ViewBag.KabaYemler = cm.KabaYemleriGetir(SessionManager.KullaniciId);
            return View();
        }

        [UserAuthorizeController]
        public ActionResult KesifYemStokEkle()
        {
            ViewBag.KesifYemler = cm.KesifYemleriGetir(SessionManager.KullaniciId, -1);
            ViewBag.KesifYemBirimMiktari = cm.KesifYemBirimMiktariGetir();

            ViewBag.IsletmeYemStoklari = ym.IsletmeYemStogonuGetir(SessionManager.KullaniciId).Where(q => q.YemTipId == 2).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult KesifYemAltKategoriGetir(int YemId)
        {
            return Json(cm.KesifYemleriGetir(SessionManager.KullaniciId, YemId), JsonRequestBehavior.AllowGet);
        }

        [UserAuthorizeController]
        public ActionResult RasyonOlustur(int id = 0)
        {
            ViewBag.RasyonId = id;

            if (id == 0)
            {
                ViewBag.YemStogu = ym.StokdakiYemleriGetir(SessionManager.KullaniciId);
            }
            else
            {
                ViewBag.YemStogu = ym.RasyonYemStoguGetir(id, SessionManager.KullaniciId);
                ViewBag.RasyonAdi = ym.RasyonAdiGetir(id, SessionManager.KullaniciId).RasyonAdi;
            }

            return View();
        }

        [UserAuthorizeController]
        public ActionResult GunlukProgramOlustur()
        {
            ViewBag.Padoklar = cm.IsletmeyeGorePadokGetir(SessionManager.KullaniciId);
            ViewBag.Rasyonlar = cm.IsletmeRasyonlariniGetir(SessionManager.KullaniciId);

            ViewBag.PadokRasyon = ym.IsletmePadokRasyonGetir(SessionManager.KullaniciId);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult KabaYemStokEkleAction(KabaYemModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = ym.KabaYemStokEkle(model, SessionManager.KullaniciId);
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
        public JsonResult KesifYemStokEkleAction(KesifYemModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = ym.KesifYemStokEkle(model, SessionManager.KullaniciId);
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
        public JsonResult RasyonKaydetAction(string RasyonAdi, string YemIdleri, string YemMiktarlari)
        {
            SiteResponseModel srm = new SiteResponseModel();

            List<string> lstYemId = JsonConvert.DeserializeObject<List<string>>(YemIdleri);
            List<decimal> lstYemMiktari = JsonConvert.DeserializeObject<List<decimal>>(YemMiktarlari);

            try
            {
                DBCheckModel dbC = ym.RasyonOlustur(RasyonAdi, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    int RasyonId = Convert.ToInt32(dbC.ReturnMessage);

                    for (int i = 0; i < lstYemId.Count; i++)
                    {
                        RasyonDetayModel rdm = new RasyonDetayModel();
                        var part = lstYemId[i].Split('_');

                        rdm.YemId = Convert.ToInt32(part[0]);
                        rdm.YemTipId = Convert.ToInt32(part[1]);
                        rdm.YemMiktariKg = lstYemMiktari[i];

                        DBCheckModel dbCInsSonuc = ym.RasyonDetayOlustur(rdm, RasyonId, SessionManager.KullaniciId);
                    }

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
        public JsonResult RasyonPadokEslestirAction(int RasyonId, int PadokId)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = ym.RasyonPadokEslestir(RasyonId, PadokId, SessionManager.KullaniciId);
                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = "Kayıt edildi";
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
        public ActionResult RasyonDegistir()
        {
            ViewBag.Rasyonlar = ym.IsletmeRasyonlariniGetir(SessionManager.KullaniciId);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult RasyonGuncelleAction(int RasyonId, string RasyonAdi, string YemIdleri, string YemMiktarlari)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                List<YemStoguModel> rm = ym.RasyonYemStoguGetir(RasyonId, SessionManager.KullaniciId);
                List<YemStoguModel> gelenYemDurumlari = new List<YemStoguModel>();
                List<string> lstYemId = JsonConvert.DeserializeObject<List<string>>(YemIdleri);
                List<decimal> lstYemMiktari = JsonConvert.DeserializeObject<List<decimal>>(YemMiktarlari);

                List<RasyonDetayModel> guncellenecekYemler = new List<RasyonDetayModel>();

                for (int i = 0; i < lstYemId.Count; i++)
                {
                    YemStoguModel ysm = new YemStoguModel();
                    var part = lstYemId[i].Split('_');
                    ysm.YemId = Convert.ToInt32(part[0]);
                    ysm.YemTipId = Convert.ToInt32(part[1]);
                    ysm.YemMiktariKg = lstYemMiktari[i];
                    gelenYemDurumlari.Add(ysm);
                }

                foreach (var item in rm)
                {
                    foreach (var kontrolItem in gelenYemDurumlari)
                    {
                        if (item.YemTipId == kontrolItem.YemTipId && item.YemId == kontrolItem.YemId && item.YemMiktariKg != kontrolItem.YemMiktariKg)
                        {
                            RasyonDetayModel rdm = new RasyonDetayModel();
                            rdm.RasyonId = RasyonId;
                            rdm.YemAdi = item.YemAdi;
                            rdm.YemId = kontrolItem.YemId;
                            rdm.YemTipId = kontrolItem.YemTipId;
                            rdm.YemMiktariKg = kontrolItem.YemMiktariKg;
                            guncellenecekYemler.Add(rdm);

                            ym.RasyonDetayGuncelle(rdm, SessionManager.KullaniciId);
                        }
                    }
                }

                srm.IsSuccess = true;
                srm.Message = "Kayıt başarılı...";

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
        public JsonResult RasyonSilAction(int RasyonId)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = ym.RasyonSil(RasyonId, SessionManager.KullaniciId);

                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = dbC.ReturnMessage;
                }
                else
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
        public ActionResult YemStokHareketleri(int id = 0)
        {
            List<YemStokHareketModel> YemStokHareketlerini = ym.YemStokHareketleriniGetir(id, SessionManager.KullaniciId);

            return View(YemStokHareketlerini);
        }


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult YemStokHareketiSilAction(int StokHareketId, int YemId)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                DBCheckModel dbC = ym.YemStokHareketiSil(StokHareketId, YemId, SessionManager.KullaniciId);

                if (dbC.ReturnValue == 1)
                {
                    srm.IsSuccess = true;
                    srm.Message = dbC.ReturnMessage;
                }
                else
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

    }
}
//