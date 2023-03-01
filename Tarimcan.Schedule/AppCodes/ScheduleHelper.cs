using System;
using System.IO;

namespace Tarimcan.Schedule.AppCodes
{
    public static class ScheduleHelper
    {

        public static void AddMsjToLog(LogTypes LogType, string mesaj, LogFolders LogFolder)
        {
            Console.WriteLine(mesaj);

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\" + LogFolder;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\" + LogFolder + "\\ScheduleLog_" + DateTime.Now.Date.ToString("yyyyMMdd") + ".txt";
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(string.Format("{0} \t {1} \t {2}", LogType, mesaj, DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")));
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(string.Format("{0} \t {1} \t {2}", LogType, mesaj, DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")));
                }
            }

        }


    }
}
