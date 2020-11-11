using Microsoft.EntityFrameworkCore;

namespace Api.Models.Context {
    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) {

        }

        public DbSet<ContasDespesas> ContasDespesas { get; set; }
        public DbSet<ContasReceitas> ContasRecitas { get; set; }
        public DbSet<SitucaoLancamentoDespesa> SituacaoLancamentoDespesa { get; set; }
        public DbSet<LancamentoDespesa> LancamentoDespesas { get; set; }
        public DbSet<SituacaoLancamentoReceitas> SituacaoLancamentoReceita { get; set; }
        public DbSet<LancamentoReceitas> LancamentoRecitas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<LancamentoDespesa> (entity => {
                entity.Property (p => p.Valor).HasColumnType ("decimal(18,2)");
            });

            modelBuilder.Entity<LancamentoReceitas> (entity => {
                entity.Property (p => p.Valor).HasColumnType ("decimal(18,2)");
            });
        }
    }
}
