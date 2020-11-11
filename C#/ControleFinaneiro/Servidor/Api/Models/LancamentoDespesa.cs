using System;

namespace Api.Models {
    public class LancamentoDespesa {
        public Guid Id { get; set; }
        public Usuarios Usuario { get; set; }
        public String Codigo { get; set; }
        public DateTime DataDespesa { get; set; }
        public string Historico { get; set; }
        public int Parcela { get; set; }
        public int TotalParcela { get; set; }
        public decimal Valor { get; set; }
        public SitucaoLancamentoDespesa SitucaoLancamento { get; set; }
    }
}
