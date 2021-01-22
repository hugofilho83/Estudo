using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Backend.Models.Notifications;

namespace Backend.Models {
    public partial class LancamentosReceita : Notifies {
        public LancamentosReceita () {
            ParcelaReceita = new HashSet<ParcelaReceita> ();
        }

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ContaId { get; set; }
        public DateTime DataReceita { get; set; }
        public string Historico { get; set; }
        public int Parcela { get; set; }
        public int TotalParcela { get; set; }
        public decimal Valor { get; set; }
        public int SitucaoLancamentoId { get; set; }

        [JsonIgnore]
        public virtual ContaReceita Conta { get; set; }
        [JsonIgnore]
        public virtual SituacaoLancamentoReceita SitucaoLancamento { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
        [JsonIgnore]
        public virtual ICollection<ParcelaReceita> ParcelaReceita { get; set; }
    }
}
