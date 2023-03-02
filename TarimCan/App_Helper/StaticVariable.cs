using System.Configuration;

namespace TarimCan.App_Helper
{
    public static class StaticVariable
    {
        public static string DBConnectionString
        {
            get { return ConfigurationManager.AppSettings["DBConnectionString"].ToString(); }
        }
        public static int CanliHayvanKgKesimFiyati
        {
            get { return int.Parse(ConfigurationManager.AppSettings["HayvanKesimKgFiyatiTL"]); }
        }
    }
}