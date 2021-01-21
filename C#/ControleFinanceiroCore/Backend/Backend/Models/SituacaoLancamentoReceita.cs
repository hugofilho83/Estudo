using Backend.Models.Notifications;
using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Models
{
    public partial class SituacaoLancamentoReceita : Notifies
    {
        public SituacaoLancamentoReceita()
        {
            LancamentosReceita = new HashSet<LancamentosReceita>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<LancamentosReceita> LancamentosReceita { get; set; }
    }
}
