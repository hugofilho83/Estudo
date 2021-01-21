using Backend.Models.Notifications;
using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Models
{
    public partial class ContaDespesa : Notifies
    {
        public ContaDespesa()
        {
            LancamentosDespesas = new HashSet<LancamentosDespesa>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<LancamentosDespesa> LancamentosDespesas { get; set; }
    }
}
