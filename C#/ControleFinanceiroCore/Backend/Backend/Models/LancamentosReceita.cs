using System;

namespace Backend.Models {
    public class LancamentosReceita {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public ContaReceita conta { get; set; }
        public DateTime DataDespesa { get; set; }
        public string Historico { get; set; }
        public int Parcela { get; set; }
        public int TotalParcela { get; set; }
        public decimal Valor { get; set; }
        public SituacaoLancamentoReceita SitucaoLancamento { get; set; }
    }
}
