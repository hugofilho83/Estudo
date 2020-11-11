using System;

namespace Api.Models {
    public class ContasDespesas {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

    }
}
