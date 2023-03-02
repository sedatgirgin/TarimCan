using System;
using TarimCan.Models;
using TarimCan.DataAccessLayer;
using Tarimcan.Schedule.AppCodes;
using System.Collections.Generic;

namespace Tarimcan.Schedule
{
    class Program
    {
        static HayvanlarManager hm = new HayvanlarManager();
        static CommonManager cm = new CommonManager();

        static void Main(string[] args)
        {
            ScheduleHelper.AddMsjToLog(LogTypes.Genel, "Uygulama Başladı...", LogFolders.YedekLog);

            try
            {
                #region Veri Tabanı Yedekle

                // Veri Tabanı Yedekleniyor
                DBCheckModel dbCBackup = cm.BackupDatabase();
                if (dbCBackup.ReturnValue == 1)
                {
                    ScheduleHelper.AddMsjToLog(LogTypes.VeriTabaniYedekleme, "Veri Tabanı Yedeklendi...", LogFolders.YedekLog);
                }

                #endregion

                #region Hayvanları Tazeden Çıkar

                // Hayvanlar Tazeden Çıkarılıyor...
                DBCheckModel dbC = hm.HayvanlariTazedenCikar();
                if (dbC.ReturnValue == 1)
                {
                    ScheduleHelper.AddMsjToLog(LogTypes.HayvaniTazedenCikarma, "Hayvanlar Tazeden Çıkarıldı...", LogFolders.YedekLog);
                }

                #endregion

                #region Hayvanları Güncelle

                int GuncellenenHayvanSayisi = 0;
                List<HayvanModel> parametresiGuncellenecekler = hm.HayvanModelSql("Select Id From Hayvanlar Where SuruGrubuId = 4 Or SuruGrubuId = 5 And AktifMi = 'True'");
                foreach (var item in parametresiGuncellenecekler)
                {
                    try
                    {
                        hm.GunlukHayvanVerileriniGuncelle(item.Id);
                        GuncellenenHayvanSayisi = GuncellenenHayvanSayisi + 1;
                    }
                    catch (Exception)
                    {

                    }
                }
                ScheduleHelper.AddMsjToLog(LogTypes.HayvanParametreleriGuncellendi, GuncellenenHayvanSayisi.ToString() + " Adet Hayvan Güncellendi...", LogFolders.YedekLog);

                #endregion

                #region Rasyon Miktarı Stoklardan Düşüyor

                // Veri Tabanı Yedekleniyor
                DBCheckModel dbCStoktanRasyonDus = cm.YemStogundanGunlukRasyonuDus();
                if (dbCStoktanRasyonDus.ReturnValue == 1)
                {
                    ScheduleHelper.AddMsjToLog(LogTypes.YemStogundanRasyonDustu, "Yem stoğundan rasyondaki yemler düştü...", LogFolders.YedekLog);
                }

                #endregion

                ScheduleHelper.AddMsjToLog(LogTypes.HayvaniTazedenCikarma, "İşlem Tamamlandı...", LogFolders.YedekLog);

            }
            catch (Exception ex)
            {

                ScheduleHelper.AddMsjToLog(LogTypes.HataOlustu, "Hata Oluştu: " + ex.ToString(), LogFolders.YedekLog);
            }

            Console.ReadLine();

        }
    }
}
