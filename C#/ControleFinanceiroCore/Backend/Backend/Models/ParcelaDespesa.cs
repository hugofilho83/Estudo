using Backend.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Backend.Models
{
    public partial class ParcelaDespesa : Notifies
    {
        public ParcelaDespesa()
        {
            PagamentoDespesas = new HashSet<PagamentoDespesa>();
        }

        public int Id { get; set; }
        public int LancamentoId { get; set; }
        public int Parcela { get; set; }
        public decimal Valor { get; set; }
        public decimal? ValorPago { get; set; }
        public DateTime? DataPagto { get; set; }
        public string Historico { get; set; }

        [JsonIgnore]
        public virtual LancamentosDespesa Lancamento { get; set; }
        [JsonIgnore]
        public virtual ICollection<PagamentoDespesa> PagamentoDespesas { get; set; }
    }
}
