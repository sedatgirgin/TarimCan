using SuruTakip.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TarimCan.App_Helper;
using TarimCan.Models;

namespace TarimCan.DataAccessLayer
{
    public class ProfilManager
    {
        MSSqlDataAccess sda = new MSSqlDataAccess();

        public DBCheckModel KullaniciGuncelle(KullaniciModel model)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(new SqlParameter("@pKullaniciId", SessionManager.AktifKullanici.Id));
            lstParam.Add(new SqlParameter("@pEmail", model.Email));
            lstParam.Add(new SqlParameter("@pIsimSoyisim", model.IsimSoyisim));
            lstParam.Add(new SqlParameter("@pCepTelefonu", model.CepTelefonu));
            lstParam.Add(new SqlParameter("@pProfilResmi", model.ProfilResmi));
            lstParam.Add(new SqlParameter("@pSehirId", model.SehirId));
            lstParam.Add(new SqlParameter("@pIlceId", model.IlceId));
            lstParam.Add(new SqlParameter("@pMahalleId", model.MahalleId));
            lstParam.Add(new SqlParameter("@pIsletmeAdi", model.IsletmeAdi));
            lstParam.Add(new SqlParameter("@pIsletmeKayitNo", model.IsletmeKayitNo));
            return sda.ExcuteReturnObject<DBCheckModel>("sp_KullaniciGuncelle", lstParam);
        }
    }
}