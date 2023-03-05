using System.Web.Mvc;
using TarimCan.DataAccessLayer;
using TarimCan.Helper;

namespace TarimCan.Controllers
{
    public class BaseController : Controller
    {
        public KullaniciManager km = new KullaniciManager();
        public HayvanlarManager hm = new HayvanlarManager();
        public CommonManager cm = new CommonManager();
        public AkademiManager akM = new AkademiManager();
        public UzmanaSorManager usm = new UzmanaSorManager();
        public ProfilManager pm = new ProfilManager();
        public TanimlamalarManager tm = new TanimlamalarManager();
        public FinansManager fm = new FinansManager();
        public AjandaManager ajanda = new AjandaManager();
        public SutManager sm = new SutManager();
        public YemManager ym = new YemManager();
        public IsTakipManager itm = new IsTakipManager();
        public MakinaEkipmanManager mem = new MakinaEkipmanManager();
        public RaporManager rprMan = new RaporManager();
        public AsiManager asiMan = new AsiManager();

        public UIHelper helper = new UIHelper();

        public BaseController()
        {
            if (SessionManager.CheckSessionActive())
            {
                RedirectToAction("Login", "Home");
            }
        }
    }
}