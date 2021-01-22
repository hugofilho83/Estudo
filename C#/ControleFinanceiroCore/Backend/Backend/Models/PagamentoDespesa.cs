using Backend.Models.Notifications;
using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Models
{
    public partial class PagamentoDespesa : Notifies
    {
        public int Id { get; set; }
        public int ParcelaId { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime? DataPagto { get; set; }
        public string Historico { get; set; }
        public int? ContaId { get; set; }

        public virtual ContaReceita Conta { get; set; }
        public virtual ParcelaDespesa Parcela { get; set; }
    }
}
