using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Backend.Services {
    public class Configurations {
        public string GetKeyToken () {
            JToken jAppSettings = JToken.Parse (File.ReadAllText (Path.Combine (Environment.CurrentDirectory, "appsettings.json")));

            string strCnn = jAppSettings["JWT"]["Key"].ToString ();

            return strCnn;
        }
    }
}
