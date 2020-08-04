using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessandoApiRest.Model
{
    public class Token
    {
        [JsonProperty("usuario")]
        public Usuario Usuario { get; set; }
        [JsonProperty("token")]
        public string Cahve { get; set; }
        public Task Result { get; internal set; }

        [JsonProperty("expire")]
        public DateTime Expire;

    }
}
