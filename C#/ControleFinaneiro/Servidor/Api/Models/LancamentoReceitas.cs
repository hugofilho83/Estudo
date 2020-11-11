using System;

namespace Api.Models {
    public class LancamentoReceitas {
        public Guid Id { get; set; }
        public Usuarios Usuario { get; set; }
        public String Codigo { get; set; }
        public DateTime DataDespesa { get; set; }
        public string Historico { get; set; }
        public int Parcela { get; set; }
        public int TotalParcela { get; set; }
        public decimal Valor { get; set; }
        public SituacaoLancamentoReceitas SitucaoLancamento { get; set; }
    }
}
