using Backend.Models.Notifications;
using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Models
{
    public partial class SituacaoLancamentoDespesa : Notifies
    {
        public SituacaoLancamentoDespesa()
        {
            LancamentosDespesas = new HashSet<LancamentosDespesa>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<LancamentosDespesa> LancamentosDespesas { get; set; }
    }
}
