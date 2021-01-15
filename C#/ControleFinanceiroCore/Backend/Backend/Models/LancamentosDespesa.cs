using System;

namespace Backend.Models {
    public class LancamentosDespesa {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public ContaDespesa Conta { get; set; }
        public DateTime DataDespesa { get; set; }
        public string Historico { get; set; }
        public int Parcela { get; set; }
        public int TotalParcela { get; set; }
        public decimal Valor { get; set; }
        public SitaucaoLancamentoDespesa SitucaoLancamento { get; set; }
    }
}
