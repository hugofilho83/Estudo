using Backend.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Backend.Models
{
    public partial class ParcelaReceita : Notifies
    {
        public ParcelaReceita()
        {
            RecebimentoReceita = new HashSet<RecebimentoReceita>();
        }

        public int Id { get; set; }
        public int LancamentoId { get; set; }
        public int Parcela { get; set; }
        public decimal Valor { get; set; }
        public decimal? ValorRecebido { get; set; }
        public DateTime? DataRecebido { get; set; }
        public string Historico { get; set; }

        [JsonIgnore]
        public virtual LancamentosReceita Lancamento { get; set; }
        [JsonIgnore]
        public virtual ICollection<RecebimentoReceita> RecebimentoReceita { get; set; }
    }
}
