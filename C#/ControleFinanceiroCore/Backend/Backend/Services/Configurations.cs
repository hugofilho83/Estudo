using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Backend.Services {
    public class Configurations {
        public static string GetKeyToken () {
            JToken jAppSettings = JToken.Parse (File.ReadAllText (Path.Combine (Environment.CurrentDirectory, "appsettings.json")));

            string strCnn = jAppSettings["JWT"]["Key"].ToString ();

            return strCnn;
        }

        public static string GetConnectionString () {
            JToken jAppSettings = JToken.Parse (File.ReadAllText (Path.Combine (Environment.CurrentDirectory, "appsettings.json")));

            string strCnn = jAppSettings["ConnectionStrings"]["ConnetionStringDev"].ToString ();

            return strCnn;
        }

        public static string RetornarMD5 (string Senha) {
            using (MD5 md5Hash = MD5.Create ()) {
                return RetonarHash (md5Hash, Senha);
            }
        }

        private static string RetonarHash (MD5 md5Hash, string input) {
            byte[] data = md5Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

            StringBuilder sBuilder = new StringBuilder ();

            for (int i = 0; i < data.Length; i++) {
                sBuilder.Append (data[i].ToString ("x2"));
            }

            return sBuilder.ToString ();
        }
    }
}
