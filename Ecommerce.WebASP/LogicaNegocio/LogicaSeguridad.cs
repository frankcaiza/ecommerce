using Ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.WebASP.LogicaNegocio
{
    public class LogicaSeguridad
    {
        private static EcommerceEntities db = new EcommerceEntities();

        public static string getMD5Hash(string text)
        {
            byte[] data = Convert.FromBase64String(text); // decrypt the incrypted text
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("A"));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        public static string setMD5Hash(string text)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("A"));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        public static TBL_USUARIO obtenerUsuarioLoginUser(string user)
        {
            try
            {
                return db.TBL_USUARIO.FirstOrDefault(data => data.USU_ESTADO == "A" && data.USU_CORREO.Equals(user));
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error : " + e.Message);
            }
        }
        public static TBL_USUARIO obtenerUsuarioLogin(string user, string password)
        {
            try
            {
                return db.TBL_USUARIO.FirstOrDefault(data => data.USU_ESTADO == "A" && data.USU_CORREO.Equals(user) && data.USU_CONTRASENA.Equals(password));

            }
            catch (Exception e)
            {
                throw new ArgumentException("Error : " + e.Message);
            }
        }
        public static async Task<int> falloClaveUsuario(TBL_USUARIO _UserLogin)
        {
            try
            {
                int contador = Convert.ToInt16(_UserLogin.USU_INTENTOS) + 1;
                _UserLogin.USU_FECHA_ACTUALIZACION = DateTime.Now;
                _UserLogin.USU_INTENTOS = contador;
                if (contador >= 3)
                {
                    _UserLogin.USU_ESTADO = "A";
                }
                await db.SaveChangesAsync();

                return contador;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error : " + e.Message);
            }
        }


        public static async Task<bool> resetIntentosUsuario(TBL_USUARIO _UserLogin)
        {
            try
            {
                _UserLogin.USU_FECHA_ACTUALIZACION = DateTime.Now;
                _UserLogin.USU_INTENTOS  = 0;
                _UserLogin.USU_ESTADO = "A";

                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error : " + e.Message);
            }
        }

        public static bool verificarUsuarioExistente(string user)
        {
            try
            {
                var userData = db.TBL_USUARIO.FirstOrDefault(
                    data => data.USU_ESTADO == "A" && data.USU_CORREO.Equals(user));
                if (userData != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error : " + e.Message);
            }
        }
        public static async Task<TBL_USUARIO> obtenerUsuarioiD(string id)
        {
            try
            {
                return await db.TBL_USUARIO.FirstOrDefaultAsync(data => data.USU_ID.Equals(id));

            }
            catch (Exception e)
            {
                throw new ArgumentException("Error : " + e.Message);
            }
        }

    }
}