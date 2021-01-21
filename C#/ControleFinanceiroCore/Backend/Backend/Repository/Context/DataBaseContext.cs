using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Context {
    public class DataBaseContext : DbContext {
        public DataBaseContext (DbContextOptions options) : base (options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<SituacaoLancamentoDespesa> SituacaoLancamentoDesposa { get; set; }
        public DbSet<SituacaoLancamentoReceita> SituacaoLancamentoReceita { get; set; }
        public DbSet<ContaReceita> ContaReceita { get; set; }
        public DbSet<ContaDespesa> ContaDespesa { get; set; }
        public DbSet<LancamentosDespesa> LancamentosDespesas { get; set; }
        public DbSet<LancamentosReceita> LancamentosReceitas { get; set; }
    }
}
