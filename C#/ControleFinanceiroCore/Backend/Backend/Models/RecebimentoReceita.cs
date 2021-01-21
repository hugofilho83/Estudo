using Backend.Models.Notifications;
using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Models
{
    public partial class RecebimentoReceita : Notifies
    {
        public int Id { get; set; }
        public int? ParcelaReceitaId { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataReceb { get; set; }
        public string Historico { get; set; }

        public virtual ParcelaReceita ParcelaReceita { get; set; }
    }
}
