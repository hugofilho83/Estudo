using Backend.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Backend.Models
{
    public partial class LancamentosDespesa : Notifies
    {
        public LancamentosDespesa()
        {
            ParcelaDespesas = new HashSet<ParcelaDespesa>();
        }

        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? ContaId { get; set; }
        public DateTime DataDespesa { get; set; }
        public string Historico { get; set; }
        public int Parcela { get; set; }
        public int TotalParcela { get; set; }
        public decimal Valor { get; set; }
        public int? SitucaoLancamentoId { get; set; }

        [JsonIgnore]
        public virtual ContaDespesa Conta { get; set; }
        [JsonIgnore]
        public virtual SituacaoLancamentoDespesa SitucaoLancamento { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<ParcelaDespesa> ParcelaDespesas { get; set; }
    }
}
