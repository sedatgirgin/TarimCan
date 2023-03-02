using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using TarimCan.Models;

namespace TarimCan.App_Helper
{
    public class UIHelper
    {
        private readonly Random _random = new Random();

        public bool HayvanResmiKaydet(string ImgStr, string ImgName)
        {
            string imgPath = Path.Combine(HttpContext.Current.Server.MapPath("~/YuklenenDosyalar/HayvanFotograflari"), ImgName);
            byte[] imageBytes = Convert.FromBase64String(ImgStr);
            File.WriteAllBytes(imgPath, imageBytes);
            return true;
        }

        public string TopluHayvanResmiKaydet(HayvanModel model)
        {
            string isimler = "";

            if (model.Foto1Base64 != null)
            {
                string CovertedBase64DataUrl = model.Foto1Base64.Substring(model.Foto1Base64.LastIndexOf(',') + 1);
                string strPhotoName = RandomString(10) + "." + GetFileExtensionFromFileAsBase64(model.Foto1Base64);
                HayvanResmiKaydet(CovertedBase64DataUrl, strPhotoName);
                isimler += strPhotoName + ",";
            }

            if (model.Foto2Base64 != null)
            {
                string CovertedBase64DataUrl = model.Foto2Base64.Substring(model.Foto2Base64.LastIndexOf(',') + 1);
                string strPhotoName = RandomString(10) + "." + GetFileExtensionFromFileAsBase64(model.Foto2Base64);
                HayvanResmiKaydet(CovertedBase64DataUrl, strPhotoName);
                isimler += strPhotoName + ",";
            }

            if (model.Foto3Base64 != null)
            {
                string CovertedBase64DataUrl = model.Foto3Base64.Substring(model.Foto3Base64.LastIndexOf(',') + 1);
                string strPhotoName = RandomString(10) + "." + GetFileExtensionFromFileAsBase64(model.Foto3Base64);
                HayvanResmiKaydet(CovertedBase64DataUrl, strPhotoName);
                isimler += strPhotoName + ",";
            }

            if (model.Foto4Base64 != null)
            {
                string CovertedBase64DataUrl = model.Foto4Base64.Substring(model.Foto4Base64.LastIndexOf(',') + 1);
                string strPhotoName = RandomString(10) + "." + GetFileExtensionFromFileAsBase64(model.Foto4Base64);
                HayvanResmiKaydet(CovertedBase64DataUrl, strPhotoName);
                isimler += strPhotoName + ",";
            }

            if (isimler.Length > 0)
            {
                isimler = isimler.Substring(0, isimler.Length - 1);
            }


            return isimler;
        }

        public bool UyeResmiKaydet(string ImgStr, string ImgName)
        {
            string imgPath = Path.Combine(HttpContext.Current.Server.MapPath("~/YuklenenDosyalar/UyeFotograflari"), ImgName);
            byte[] imageBytes = Convert.FromBase64String(ImgStr);
            File.WriteAllBytes(imgPath, imageBytes);
            return true;
        }

        public string ExcelKaydet(string FileBase64Str, string FileExtensions)
        {
            string CovertedBase64DataUrl = FileBase64Str.Substring(FileBase64Str.LastIndexOf(',') + 1);
            string strFileName = RandomString(10) + "." + FileExtensions;

            string imgPath = Path.Combine(HttpContext.Current.Server.MapPath("~/YuklenenDosyalar/ExcelTemp"), strFileName);
            byte[] imageBytes = Convert.FromBase64String(CovertedBase64DataUrl);
            File.WriteAllBytes(imgPath, imageBytes);
            return strFileName;
        }


        public string GetIPAddress()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }

        public string GetFileExtensionFromFileAsBase64(string fileAsBase64String)
        {
            var fileType = "";
            var mimeType = GetMimeTypeFromFileAsBase64(fileAsBase64String);

            if (!String.IsNullOrEmpty(mimeType))
            {
                fileType = mimeType.ToLower().Split('/')[1];
            }

            return fileType.ToLower();
        }

        public string GetMimeTypeFromFileAsBase64(string fileAsBase64String)
        {
            string mimeType = "";

            Regex r = new Regex(@"[^:]\w+\/[\w-+\d.]+(?=;|,)");

            var matches = r.Match(fileAsBase64String);

            if (matches.Success)
            {
                mimeType = matches.Groups[0].Value;
            }

            return mimeType;
        }

        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        private int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public string ReplaceInjectionChar(string text)
        {
            text = text.Replace("'", "");
            text = text.Replace("\"", "");
            text = text.Replace("-", "");
            text = text.Replace("/", "");
            text = text.Replace("*", "");
            text = text.Replace("alter", "");
            text = text.Replace("select", "");
            text = text.Replace("drop", "");
            text = text.Replace("insert", "");
            text = text.Replace("delete", "");
            text = text.Replace("from", "");
            text = text.Replace("&", "");
            text = text.Replace("#", "");
            text = text.Replace(":", "");
            text = text.Replace(";", "");
            text = text.Replace("=", "");
            return text;
        }

        public bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

    }
}