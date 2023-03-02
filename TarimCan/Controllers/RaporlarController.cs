using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TarimCan.Helper;
using TarimCan.Models;

namespace TarimCan.Controllers
{
    public class RaporlarController : BaseController
    {
        // GET: Raporlar
        [UserAuthorizeController]
        public ActionResult SagmalGrupDurumOzetiDagilimi()
        {
            List<HayvanModel> list = rprMan.SagmalGrupDurumOzetiDagiliminiGetir(SessionManager.KullaniciId);
            //List<RaporModel> raporModel = new List<RaporModel>();

            string raporVerisi = "";

            int ToplamHayvanSayisi = 0;

            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    ToplamHayvanSayisi = ToplamHayvanSayisi + item.HayvanSayisi;
                }

                foreach (var item in list)
                {
                    float VeriY = (Convert.ToSingle(item.HayvanSayisi) / Convert.ToSingle(ToplamHayvanSayisi)) * 100;
                    string Label = item.DurumBilgisi + "(" + item.HayvanSayisi + ")";
                    string colorCode = "";

                    switch (item.DurumBilgisiId)
                    {
                        case 3:
                            colorCode = "#4472c4";
                            break;
                        case 4:
                            colorCode = "#ed7d31";
                            break;
                        case 19:
                            colorCode = "#a5a5a5";
                            break;
                        case 21:
                            colorCode = "#ffc000";
                            break;
                        default:
                            break;
                    }

                    raporVerisi += "{ y: " + VeriY.ToString("0.00").Replace(",", ".") + ", name: \"" + Label + "\", color: \"" + colorCode + "\", exploded: true },";
                }

                //raporVerisi = raporVerisi.Substring(0, raporVerisi.Length - 1);

                ViewBag.RaporVerisi = raporVerisi;
            }

            return View();
        }

        // GET: Raporlar
        [UserAuthorizeController]
        public ActionResult InekDurumOzetiDagilimi()
        {
            List<HayvanModel> list = rprMan.IneklerDurumOzetiDagiliminiGetir(SessionManager.KullaniciId);
            //List<RaporModel> raporModel = new List<RaporModel>();

            string raporVerisi = "";

            int ToplamHayvanSayisi = 0;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    ToplamHayvanSayisi = ToplamHayvanSayisi + item.HayvanSayisi;
                }

                foreach (var item in list)
                {

                    float VeriY = (Convert.ToSingle(item.HayvanSayisi) / Convert.ToSingle(ToplamHayvanSayisi)) * 100;
                    string Label = item.DurumBilgisi + "(" + item.HayvanSayisi + ")";
                    string colorCode = "";

                    switch (item.DurumBilgisiId)
                    {
                        case 8:
                            colorCode = "#4472c4";
                            break;
                        case 20:
                            colorCode = "#ed7d31";
                            break;
                        case 22:
                            colorCode = "#a5a5a5";
                            break;
                        default:
                            break;
                    }

                    raporVerisi += "{ y: " + VeriY.ToString("0.00").Replace(",", ".") + ", name: \"" + Label + "\", color: \"" + colorCode + "\", exploded: true },";
                }
            }

            ViewBag.RaporVerisi = raporVerisi;

            return View();
        }

        // GET: Raporlar
        [UserAuthorizeController]
        public ActionResult InekUremeDurumlariDagilimi()
        {
            List<HayvanModel> list = rprMan.IneklerinUremeDurumuDagiliminiGetir(SessionManager.KullaniciId);
            //List<RaporModel> raporModel = new List<RaporModel>();

            string raporVerisi = "";

            int ToplamHayvanSayisi = 0;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    ToplamHayvanSayisi = ToplamHayvanSayisi + item.HayvanSayisi;
                }

                foreach (var item in list)
                {

                    float VeriY = (Convert.ToSingle(item.HayvanSayisi) / Convert.ToSingle(ToplamHayvanSayisi)) * 100;
                    string Label = item.DurumBilgisi + "(" + item.HayvanSayisi + ")";
                    string colorCode = "";

                    switch (item.DurumBilgisiId)
                    {
                        case 3:
                            colorCode = "#4472c4";
                            break;
                        case 4:
                            colorCode = "#ed7d31";
                            break;
                        case 19:
                            colorCode = "#a5a5a5";
                            break;
                        case 21:
                            colorCode = "#ffc000";
                            break;
                        default:
                            break;
                    }

                    raporVerisi += "{ y: " + VeriY.ToString("0.00").Replace(",", ".") + ", name: \"" + Label + "\", color: \"" + colorCode + "\", exploded: true },";
                }
            }

            //raporVerisi = raporVerisi.Substring(0, raporVerisi.Length - 1);

            ViewBag.RaporVerisi = raporVerisi;

            return View();
        }

        [UserAuthorizeController]
        public ActionResult SuruGrubuDagilimi()
        {
            List<HayvanModel> list = rprMan.SuruDagiliminiGetir(SessionManager.KullaniciId);
            //List<RaporModel> raporModel = new List<RaporModel>();

            string raporVerisi = "";

            int ToplamHayvanSayisi = 0;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    ToplamHayvanSayisi = ToplamHayvanSayisi + item.HayvanSayisi;
                }

                foreach (var item in list)
                {

                    float VeriY = (Convert.ToSingle(item.HayvanSayisi) / Convert.ToSingle(ToplamHayvanSayisi)) * 100;
                    string Label = item.SuruGrubu + "(" + item.HayvanSayisi + ")";
                    string colorCode = "";

                    switch (item.SuruGrubuId)
                    {
                        case 1:
                            colorCode = "#53bcb8";
                            break;
                        case 2:
                            colorCode = "#535bbc";
                            break;
                        case 3:
                            colorCode = "#bc5353";
                            break;
                        case 4:
                            colorCode = "#8dbc53";
                            break;
                        case 5:
                            colorCode = "#bcaf53";
                            break;
                        case 6:
                            colorCode = "#53bc73";
                            break;
                        default:
                            break;
                    }

                    raporVerisi += "{ y: " + VeriY.ToString("0.00").Replace(",", ".") + ", name: \"" + Label + "\", color: \"" + colorCode + "\", exploded: true },";
                }
            }
            //raporVerisi = raporVerisi.Substring(0, raporVerisi.Length - 1);

            ViewBag.RaporVerisi = raporVerisi;

            return View();
        }

    }
}