using Backend.Models.Notifications;
using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Models
{
    public partial class ContaReceita : Notifies
    {
        public ContaReceita()
        {
            LancamentosReceita = new HashSet<LancamentosReceita>();
            PagamentoDespesas = new HashSet<PagamentoDespesa>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<LancamentosReceita> LancamentosReceita { get; set; }
        public virtual ICollection<PagamentoDespesa> PagamentoDespesas { get; set; }
    }
}
