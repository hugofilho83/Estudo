using Backend.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Backend.Models
{
    public partial class RecebimentoReceita : Notifies
    {
        public int Id { get; set; }
        public int ParcelaReceitaId { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataReceb { get; set; }
        public string Historico { get; set; }

        [JsonIgnore]
        public virtual ParcelaReceita ParcelaReceita { get; set; }
    }
}
