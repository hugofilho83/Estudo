using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessandoApiRest.Model
{
    public class Usuario
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idColaborador")]
        public int IdColaborador { get; set; }

        [JsonProperty("idPapel")]
        public int IdPapel { get; set; }

        [JsonProperty("idEmpresa")]
        public int IdEmpresa { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("dataCadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonProperty("administrador")]
        public string Administrador { get; set; }

        [JsonProperty("situacao")]
        public string Situacao { get; set; }
    }
}
