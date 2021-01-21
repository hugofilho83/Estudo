using Backend.Models.Notifications;
using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Models
{
    public partial class Usuario : Notifies
    {
        public Usuario()
        {
            LancamentosDespesas = new HashSet<LancamentosDespesa>();
            LancamentosReceita = new HashSet<LancamentosReceita>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }

        public virtual ICollection<LancamentosDespesa> LancamentosDespesas { get; set; }
        public virtual ICollection<LancamentosReceita> LancamentosReceita { get; set; }
    }
}
