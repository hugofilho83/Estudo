using System;
using System.Collections.Generic;
using Backend.Models.Notifications;

namespace Backend.Models {
    public partial class LancamentosReceita : Notifies {
        public LancamentosReceita () {
            ParcelaReceita = new HashSet<ParcelaReceita> ();
        }

        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? ContaId { get; set; }
        public DateTime DataReceita { get; set; }
        public string Historico { get; set; }
        public int Parcela { get; set; }
        public int TotalParcela { get; set; }
        public decimal Valor { get; set; }
        public int? SitucaoLancamentoId { get; set; }

        public virtual ContaReceita Conta { get; set; }
        public virtual SituacaoLancamentoReceita SitucaoLancamento { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<ParcelaReceita> ParcelaReceita { get; set; }
    }
}
