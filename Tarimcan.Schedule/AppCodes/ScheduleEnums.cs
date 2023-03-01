using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarimcan.Schedule.AppCodes
{
    public enum LogTypes
    {
        VeriTabaniYedekleme,
        HayvaniTazedenCikarma,
        Genel,
        HataOlustu,
        HayvanParametreleriGuncellendi,
        YemStogundanRasyonDustu,
    }

    public enum LogFolders
    {
        YedekLog,
        TazeCikarmaLog
    }
}
