using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarimCan.Helper;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class CommonController : BaseController
    {
        // GET: Genel
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public JsonResult IlceleriGetir(int SehirId)
        {
            List<IdValueModel> ilceler = cm.TumIlceleriListeOlarakGetir(SehirId);
            return Json(ilceler);
        }

        [ValidateAntiForgeryToken]
        public JsonResult MahalleleriGetir(int IlceId)
        {
            List<IdValueModel> ilceler = cm.TumIMahalleleriListeOlarakGetir(IlceId);
            return Json(ilceler);
        }

        [ValidateAntiForgeryToken]
        public JsonResult VerifyExcel(string Base64File, string SelectedFileName)
        {
            SiteResponseModel srm = new SiteResponseModel();
            List<HayvanModel> hayvanList = new List<HayvanModel>();

            try
            {
                List<IdValueModel> HayvanIrklari = cm.TumHayvanIrklariniListeGetir();
                List<IdValueModel> SuruGruplari = cm.TumSuruGruplariniListeGetir();
                List<IdValueModel> SuruyeGirisTipleri = cm.TumSuruyeGirisTipleriniListeGetir();


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
                    OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from [" + tableName + "]", excelConnection);
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            HayvanModel item = new HayvanModel();
                            item.KupeNo = dataTable.Rows[i][0].ToString();
                            item.Adi = dataTable.Rows[i][1].ToString();
                            item.CinsiyetId = GetCinsiyet(dataTable.Rows[i][2].ToString()).Id;
                            item.Cinsiyet = GetCinsiyet(dataTable.Rows[i][2].ToString()).Value;
                            item.IrkId = HayvanIrklari.First(temp => temp.Value == dataTable.Rows[i][4].ToString()).Id;
                            item.Irk = HayvanIrklari.First(temp => temp.Value == dataTable.Rows[i][4].ToString()).Value;
                            item.DogumTarihi = DateTime.Parse(dataTable.Rows[i][5].ToString());
                            item.SuruyeGirisTarihi = DateTime.Parse(dataTable.Rows[i][6].ToString());
                            item.SuruyeGirisTipId = SuruyeGirisTipleri.First(temp => temp.Value == dataTable.Rows[i][7].ToString()).Id;
                            item.SuruyeGirisTipi = SuruyeGirisTipleri.First(temp => temp.Value == dataTable.Rows[i][7].ToString()).Value;
                            item.AnneKupeNo = dataTable.Rows[i][8].ToString();
                            item.BabaKupeNo = dataTable.Rows[i][9].ToString();
                            item.SuruGrubuId = SuruGruplari.First(temp => temp.Value == dataTable.Rows[i][10].ToString()).Id;
                            item.SuruGrubu = SuruGruplari.First(temp => temp.Value == dataTable.Rows[i][10].ToString()).Value;
                            item.Aciklama = dataTable.Rows[i][11].ToString();
                            hayvanList.Add(item);
                        }
                    }

                }

                Session["HayvanListesi"] = hayvanList;
                srm.IsSuccess = true;
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.MessageCode = -1;
                srm.Message = ex.ToString();
            }

            return Json(new { HayvanList = hayvanList, SiteResponse = srm });
        }
        private IdValueModel GetCinsiyet(string cinsiyet)
        {
            IdValueModel model = new IdValueModel();

            if (cinsiyet == "Erkek")
            {
                model.Id = 1;
                model.Value = "Erkek";
            }
            else if (cinsiyet == "Dişi")
            {
                model.Id = 2;
                model.Value = "Dişi";
            }
            else
            {
                model.Id = 2;
                model.Value = "Dişi";
            }

            return model;
        }

        [ValidateAntiForgeryToken]
        public JsonResult AltDurumBilgisiGetir(int DurumBilgisiId)
        {
            return Json(cm.AltDurumBilgileriniGetir(DurumBilgisiId));
        }

        [ValidateAntiForgeryToken]
        public JsonResult KullaniciPadokKaydet(PadokModel model)
        {
            SiteResponseModel srm = new SiteResponseModel();
            DBCheckModel dbC = cm.KullaniciPadokKaydet(model, SessionManager.KullaniciId);

            if (dbC.ReturnValue == 1)
            {
                srm.IsSuccess = true;
                srm.Message = "Padok eklendi...";
            }
            else
            {
                srm.IsSuccess = false;
                srm.Message = "Padok eklenirken hata oluştu...";
            }

            return Json(srm, JsonRequestBehavior.AllowGet);

        }

        [ValidateAntiForgeryToken]
        public JsonResult IsletmeDemirbasTipiKaydet(string DemirbasTipi)
        {
            return Json(cm.IsletmeDemirbasTipiKaydet(DemirbasTipi, SessionManager.KullaniciId));
        }

        [ValidateAntiForgeryToken]
        public JsonResult IsletmeDemirbasYeriKaydet(string DemirbasYeri)
        {
            return Json(cm.IsletmeDemirbasYeriKaydet(DemirbasYeri, SessionManager.KullaniciId));
        }

        [ValidateAntiForgeryToken]
        public JsonResult PadokSilAction(int PadokId)
        {
            SiteResponseModel srm = new SiteResponseModel();
            DBCheckModel dbC = cm.KullaniciPadokSil(PadokId, SessionManager.KullaniciId);

            if (dbC.ReturnValue == 1)
            {
                srm.IsSuccess = true;
                srm.Message = "Padok silindi...";
            }
            else
            {
                srm.IsSuccess = false;
                srm.Message = "Genel padok silinemez...";
            }

            return Json(srm, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult AjandaGorevleriGetir()
        {
            List<AjandaModel> gorevler = new List<AjandaModel>();
            SiteResponseModel srm = new SiteResponseModel();
            try
            {
                gorevler = ajanda.GorevleriGetir(SessionManager.KullaniciId);
            }
            catch (Exception ex)
            {
                srm.IsSuccess = false;
                srm.Message = ex.ToString();
            }
            return Json(gorevler, JsonRequestBehavior.AllowGet);
        }
    }
}