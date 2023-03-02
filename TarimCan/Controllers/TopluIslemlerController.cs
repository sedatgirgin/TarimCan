using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web.Mvc;
using TarimCan.Helper;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class TopluIslemlerController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [UserAuthorizeController]
        public ActionResult Tohumlama()
        {
            return View(hm.TohumlanacakHayvanlariGetir(SessionManager.KullaniciId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult TopluHayvanTohumlaAction(DateTime IslemTarihi, string Ids)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                List<int> lstIds = JsonConvert.DeserializeObject<List<int>>(Ids);

                foreach (var item in lstIds)
                {
                    DurumHareketModel model = new DurumHareketModel();
                    model.HayvanId = item;
                    model.DurumBilgisiId = 4;
                    model.IslemTarihi = IslemTarihi;

                    DBCheckModel dbC = hm.HayvanDurumHereketiEkle(model, SessionManager.KullaniciId);
                    if (dbC.ReturnValue == 1)
                    {
                        srm.IsSuccess = true;
                        srm.Message = "Tohumlama başarılı...";
                    }
                    else
                    {
                        srm.IsSuccess = false;
                        srm.Message = "Kayıt sırasında hata oluştu...";
                    }
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
        public ActionResult Satis()
        {
            return View();
        }

        [UserAuthorizeController]
        public ActionResult Kesim()
        {
            return View(hm.SurudekiHayvanlariSahibineGoreGetir(SessionManager.KullaniciId, 0, 0));
        }

        [UserAuthorizeController]
        public ActionResult SuruGrubuGuncelle()
        {
            ViewBag.SuruGruplari = cm.TumSuruGruplariniGetir();
            ViewBag.Padok = cm.IsletmeyeGorePadokGetir(SessionManager.KullaniciId);
            return View(hm.TopluDurumGuncellenecekHayvanlariGetir(SessionManager.KullaniciId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult HayvanFiltrele(HayvanModel model)
        {
            string sql = "Select h.Id as HayvanId, h.KupeNo, h.Adi, db.Id as DurumBilgisiId, db.DurumBilgisi, p.PadokAdi, sg.SuruGrubu, c.Cinsiyet " +
                "From Hayvanlar h, HayvanDurumHareketleri dh, TnmDurumBilgileri db, Padoklar p, TnmSuruGrubu sg, TnmHayvanCinsiyeti c " +
                "Where h.Id = dh.HayvanId And h.PadokId = p.Id And h.SuruGrubuId = sg.Id And h.CinsiyetId = c.Id And dh.DurumBilgisiId = db.Id And " +
                "dh.IslemSonlandiMi = 'False' And db.DurumOzetiMi = 'True' And db.TopluGuncellenebilirMi = 'True' And h.AktifMi = 'True' And h.SahipId = " + SessionManager.KullaniciId + " And ";

            if (model.SuruGrubuId != 0)
            {
                sql += "(h.SuruGrubuId = " + model.SuruGrubuId + ") And ";
            }

            if (model.DurumBilgisiId != 0)
            {
                sql += "(dh.DurumBilgisiId = " + model.DurumBilgisiId + ") And ";
            }

            if (model.CinsiyetId != 0)
            {
                sql += "(h.CinsiyetId = " + model.CinsiyetId + ") And ";
            }

            if (model.PadokId != 0)
            {
                sql += "(h.PadokId = " + model.PadokId + ") And ";
            }
            sql = sql.Substring(0, sql.Length - 4);

            List<HayvanModel> list = hm.HayvanListGetirSql(sql);

            return Json(list);
        }

        [UserAuthorizeController]
        public ActionResult TopluPadokGuncelle()
        {
            ViewBag.Padok = cm.IsletmeyeGorePadokGetir(SessionManager.KullaniciId);
            return View(hm.TopluPadokGuncellenecekHayvanlariGetir(SessionManager.KullaniciId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult TopluHayvanPadokGuncelle(string Ids, int PadokId)
        {
            SiteResponseModel srm = new SiteResponseModel();

            try
            {
                List<int> lstIds = JsonConvert.DeserializeObject<List<int>>(Ids);

                foreach (var item in lstIds)
                {
                    DBCheckModel dbC = hm.HayvanPadokGuncelle(Convert.ToInt32(item), PadokId, SessionManager.KullaniciId);
                    if (dbC.ReturnValue == 1)
                    {
                        srm.IsSuccess = true;
                        srm.Message = "Güncelleme başarılı...";
                    }
                    else
                    {
                        srm.IsSuccess = false;
                        srm.Message = "Kayıt sırasında hata oluştu...";
                    }
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
        public ActionResult TopluHayvanYukleme()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public JsonResult TopluHayvanYukleAction()
        {
            SiteResponseModel srm = new SiteResponseModel();

            List<HayvanModel> hayvanlar = Session["HayvanListesi"] as List<HayvanModel>;

            if (hayvanlar != null)
            {
                foreach (var item in hayvanlar)
                {
                    DBCheckModel dbc = hm.HayvanKaydet(item, SessionManager.KullaniciId);
                    hm.GunlukHayvanVerileriniGuncelle(Convert.ToInt32(dbc.ReturnValue));
                }
                srm.IsSuccess = true;
            }
            else
            {
                srm.IsSuccess = false;
                srm.Message = "Hata oluştu. Lütfen excel belgesini kontrol ediniz ve değişiklik yapmadığınızdan emin olunuz.";
            }

            Session["HayvanListesi"] = "";

            return Json(srm, JsonRequestBehavior.AllowGet);
        }

        [ValidateAntiForgeryToken]
        public JsonResult UploadExcel(string Base64File, string SelectedFileName)
        {
            SiteResponseModel srm = new SiteResponseModel();
            List<HayvanModel> hayvanList = new List<HayvanModel>();

            try
            {
                List<IdValueModel> HayvanIrklari = cm.TumHayvanIrklariniListeGetir();

                if (Base64File != "")
                {

                    string uploadedFileName = helper.ExcelKaydet(Base64File, SelectedFileName.Split('.')[1]);

                    string path = Server.MapPath("~/YuklenenDosyalar/ExcelTemp/" + uploadedFileName);

                    string excelConnectionString = @"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='" + path + "';Extended Properties='Excel 12.0 Xml;IMEX=1'";
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

                    excelConnection.Open();
                    string tableName = excelConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
                    excelConnection.Close();

                    DataTable dataTable = new DataTable();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from [Sayfa1$]", excelConnection);
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 2; i < dataTable.Rows.Count; i++)
                        {
                            HayvanModel item = new HayvanModel();

                            try
                            {
                                if (dataTable.Rows[i][0].ToString() == "" && dataTable.Rows[i][1].ToString() == "" && dataTable.Rows[i][2].ToString() == "")
                                {
                                    break;
                                }

                                item.KupeNo = dataTable.Rows[i][0].ToString();
                                item.Adi = dataTable.Rows[i][1].ToString();
                                item.IrkId = HayvanIrklari.First(temp => temp.Value == dataTable.Rows[i][2].ToString()).Id;
                                item.Irk = HayvanIrklari.First(temp => temp.Value == dataTable.Rows[i][2].ToString()).Value;
                                item.CinsiyetId = GetCinsiyet(dataTable.Rows[i][3].ToString()).Id;
                                item.Cinsiyet = GetCinsiyet(dataTable.Rows[i][3].ToString()).Value;

                                item.DogumTarihi = DateTime.Parse(dataTable.Rows[i][4].ToString());

                                item.HayvanDurumId = GetHayvanDurumu(dataTable.Rows[i][5].ToString()).Id;
                                item.HayvanDurumu = item.HayvanDurumId + " - " + GetHayvanDurumu(dataTable.Rows[i][5].ToString()).Value;

                                item.GebelikDurumId = GetGebelikDurumu(dataTable.Rows[i][6].ToString()).Id;
                                item.GebelikDurumu = item.GebelikDurumId + " - " + GetGebelikDurumu(dataTable.Rows[i][6].ToString()).Value;

                                //Hayvan Durumu: Sağmal, Kuru, Boş / Kuru
                                //Gebelik Durumu: Gebe / Tohumlandı / Boş

                                if (dataTable.Rows[i][7].ToString() != "")
                                {
                                    item.TohumlanmaTarihi = DateTime.Parse(dataTable.Rows[i][7].ToString());
                                }

                                if (dataTable.Rows[i][9].ToString() != "")
                                {
                                    item.LaktasyonSayisi = int.Parse(dataTable.Rows[i][9].ToString());
                                }

                                item.Aciklama = "Hayvan Kayıt Edildi... - <br />";

                                DBCheckModel dbc = hm.TopluHayvanKaydet(item, SessionManager.KullaniciId);

                                item.HayvanId = Convert.ToInt32(dbc.ReturnMessage);
                                if (dbc.ReturnValue == 1)
                                {
                                    if (dataTable.Rows[i][8].ToString() != "")
                                    {
                                        item.SonDogumYaptigiTarih = DateTime.Parse(dataTable.Rows[i][8].ToString());
                                        //item.Aciklama = item.Aciklama + " Son Doğum Bilgisi Eklenecek. Doğum Tarihi: " + item.SonDogumYaptigiTarih.ToString("dd.MM.yyyy") + " - <br />";

                                        DurumHareketModel dhm = new DurumHareketModel();
                                        dhm.HayvanId = Convert.ToInt32(dbc.ReturnMessage);
                                        dhm.DurumBilgisiId = 6;
                                        dhm.IslemTarihi = item.SonDogumYaptigiTarih;
                                        dhm.IslemSonlandiMi = false;
                                        //drm1.Aciklama = "Doğum Yaptı";
                                        hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);

                                        // Doğum tarihinin 280 gün öncesine gebelik kaydı ekleniyor...
                                        dhm = new DurumHareketModel();
                                        dhm.HayvanId = Convert.ToInt32(dbc.ReturnMessage);
                                        dhm.DurumBilgisiId = 3;
                                        dhm.IslemTarihi = item.SonDogumYaptigiTarih.AddDays(-280);
                                        dhm.IslemSonlandiMi = true;
                                        hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                                    }

                                    if (item.HayvanDurumId != 0 && dataTable.Rows[i][8].ToString() != "")
                                    {
                                        //item.Aciklama = item.Aciklama + item.HayvanDurumu + " Durum bilgisi eklenecek. İşlem Tarihi " + item.SonDogumYaptigiTarih.ToString("dd.MM.yyyy") + " <br />";

                                        DurumHareketModel dhm = new DurumHareketModel();
                                        dhm.HayvanId = Convert.ToInt32(dbc.ReturnMessage);
                                        dhm.DurumBilgisiId = item.HayvanDurumId;
                                        dhm.IslemTarihi = item.SonDogumYaptigiTarih;
                                        dhm.IslemSonlandiMi = false;
                                        hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                                    }

                                    if (item.GebelikDurumId == 19 && dataTable.Rows[i][8].ToString() != "")
                                    {
                                        //item.Aciklama = item.Aciklama + item.GebelikDurumu + " Gebelik Durum bilgisi eklenecek. Gebelik Tarihi: " + item.TohumlanmaTarihi.Value.ToString("dd.MM.yyyy") + " - <br />";

                                        DurumHareketModel dhm = new DurumHareketModel();
                                        dhm.IslemTarihi = DateTime.Parse(dataTable.Rows[i][8].ToString());
                                        dhm.HayvanId = Convert.ToInt32(dbc.ReturnMessage);
                                        dhm.DurumBilgisiId = item.GebelikDurumId;
                                        dhm.IslemSonlandiMi = false;
                                        hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                                    }
                                    else
                                    {
                                        DurumHareketModel dhm = new DurumHareketModel();
                                        dhm.IslemTarihi = item.TohumlanmaTarihi.Value;
                                        dhm.HayvanId = Convert.ToInt32(dbc.ReturnMessage);
                                        dhm.DurumBilgisiId = item.GebelikDurumId;
                                        dhm.IslemSonlandiMi = false;
                                        hm.HayvanTekilDurumHereketiEkle(dhm, SessionManager.KullaniciId);
                                    }

                                    hm.GunlukHayvanVerileriniGuncelle(Convert.ToInt32(dbc.ReturnMessage));
                                }
                                else
                                {
                                    item.Aciklama = dbc.ReturnMessage;
                                }


                                hayvanList.Add(item);

                            }
                            catch (Exception ex)
                            {
                                if (item.HayvanId == 0)
                                {
                                    item.Aciklama = "Hayvan toplu listeden kayıt edilemedi. Lütfen tek olarak ekleyiniz...";
                                }
                                else
                                {
                                    item.Aciklama = "Hayvan Kayıt Edildi... - <br />";
                                }
                                hayvanList.Add(item);
                            }
                        }
                    }
                }

                srm.IsSuccess = true;
                //hm.HayvanSuruGruplariniGuncell(SessionManager.KullaniciId);
            }
            catch (Exception ex)
            {
                //srm.IsSuccess = false;
                //srm.MessageCode = -1;
                //srm.Message = ex.ToString();
            }

            return Json(new { HayvanList = hayvanList, SiteResponse = srm });
        }

        private IdValueModel GetGebelikDurumu(string value)
        {
            IdValueModel model = new IdValueModel();
            switch (value)
            {
                case "Tohumlandı":
                    model.Id = 4;
                    model.Value = value;
                    break;
                case "Gebe":
                    model.Id = 3;
                    model.Value = value;
                    break;
                case "Boş":
                    model.Id = 19;
                    model.Value = value;
                    break;
                default:
                    break;
            }
            return model;
        }

        private IdValueModel GetHayvanDurumu(string value)
        {
            IdValueModel model = new IdValueModel();
            switch (value)
            {
                case "Sağmal":
                    model.Id = 20;
                    model.Value = value;
                    break;
                case "Kuru":
                    model.Id = 8;
                    model.Value = value;
                    break;
                case "Boş Kuru":
                    model.Id = 22;
                    model.Value = value;
                    break;
                default:
                    break;
            }
            return model;
        }

        private IdValueModel GetCinsiyet(string cinsiyet)
        {
            IdValueModel model = new IdValueModel();

            if (cinsiyet == "Erkek")
            {
                model.Id = 2;
                model.Value = "Erkek";
            }
            else if (cinsiyet == "Dişi")
            {
                model.Id = 1;
                model.Value = "Dişi";
            }
            else
            {
                model.Id = 1;
                model.Value = "Dişi";
            }

            return model;
        }

    }
}