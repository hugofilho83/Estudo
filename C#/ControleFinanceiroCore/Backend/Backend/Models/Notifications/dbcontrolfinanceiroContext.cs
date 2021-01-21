using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Backend
{
    public partial class dbcontrolfinanceiroContext : DbContext
    {
        public dbcontrolfinanceiroContext()
        {
        }

        public dbcontrolfinanceiroContext(DbContextOptions<dbcontrolfinanceiroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContaDespesa> ContaDespesas { get; set; }
        public virtual DbSet<ContaReceita> ContaReceita { get; set; }
        public virtual DbSet<LancamentosDespesa> LancamentosDespesas { get; set; }
        public virtual DbSet<LancamentosReceita> LancamentosReceitas { get; set; }
        public virtual DbSet<PagamentoDespesa> PagamentoDespesas { get; set; }
        public virtual DbSet<ParcelaDespesa> ParcelaDespesas { get; set; }
        public virtual DbSet<ParcelaReceita> ParcelaReceitas { get; set; }
        public virtual DbSet<RecebimentoReceita> RecebimentoReceitas { get; set; }
        public virtual DbSet<SituacaoLancamentoDespesa> SituacaoLancamentoDesposas { get; set; }
        public virtual DbSet<SituacaoLancamentoReceita> SituacaoLancamentoReceita { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=dbcontrolfinanceiro;User Id=postgres;Password=hf@1983");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Portuguese_Brazil.1252");

            modelBuilder.Entity<ContaDespesa>(entity =>
            {
                entity.ToTable("ContaDespesa");
            });

            modelBuilder.Entity<LancamentosDespesa>(entity =>
            {
                entity.HasIndex(e => e.ContaId, "IX_LancamentosDespesas_ContaId");

                entity.HasIndex(e => e.SitucaoLancamentoId, "IX_LancamentosDespesas_SitucaoLancamentoId");

                entity.HasIndex(e => e.UsuarioId, "IX_LancamentosDespesas_UsuarioId");

                entity.HasOne(d => d.Conta)
                    .WithMany(p => p.LancamentosDespesas)
                    .HasForeignKey(d => d.ContaId);

                entity.HasOne(d => d.SitucaoLancamento)
                    .WithMany(p => p.LancamentosDespesas)
                    .HasForeignKey(d => d.SitucaoLancamentoId)
                    .HasConstraintName("FK_LancamentosDespesas_SituacaoLancamentoDesposa_SitucaoLancam~");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.LancamentosDespesas)
                    .HasForeignKey(d => d.UsuarioId);
            });

            modelBuilder.Entity<LancamentosReceita>(entity =>
            {
                entity.HasIndex(e => e.ContaId, "IX_LancamentosReceitas_ContaId");

                entity.HasIndex(e => e.SitucaoLancamentoId, "IX_LancamentosReceitas_SitucaoLancamentoId");

                entity.HasIndex(e => e.UsuarioId, "IX_LancamentosReceitas_UsuarioId");

                entity.HasOne(d => d.Conta)
                    .WithMany(p => p.LancamentosReceita)
                    .HasForeignKey(d => d.ContaId);

                entity.HasOne(d => d.SitucaoLancamento)
                    .WithMany(p => p.LancamentosReceita)
                    .HasForeignKey(d => d.SitucaoLancamentoId)
                    .HasConstraintName("FK_LancamentosReceitas_SituacaoLancamentoReceita_SitucaoLancam~");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.LancamentosReceita)
                    .HasForeignKey(d => d.UsuarioId);
            });

            modelBuilder.Entity<PagamentoDespesa>(entity =>
            {
                entity.HasIndex(e => e.ContaId, "IX_PagamentoDespesas_ContaId");

                entity.HasIndex(e => e.ParcelaId, "IX_PagamentoDespesas_ParcelaId");

                entity.HasOne(d => d.Conta)
                    .WithMany(p => p.PagamentoDespesas)
                    .HasForeignKey(d => d.ContaId);

                entity.HasOne(d => d.Parcela)
                    .WithMany(p => p.PagamentoDespesas)
                    .HasForeignKey(d => d.ParcelaId);
            });

            modelBuilder.Entity<ParcelaDespesa>(entity =>
            {
                entity.ToTable("ParcelaDespesa");

                entity.HasIndex(e => e.LancamentoId, "IX_ParcelaDespesa_LancamentoId");

                entity.HasOne(d => d.Lancamento)
                    .WithMany(p => p.ParcelaDespesas)
                    .HasForeignKey(d => d.LancamentoId);
            });

            modelBuilder.Entity<ParcelaReceita>(entity =>
            {
                entity.HasIndex(e => e.LancamentoId, "IX_ParcelaReceitas_LancamentoId");

                entity.HasOne(d => d.Lancamento)
                    .WithMany(p => p.ParcelaReceita)
                    .HasForeignKey(d => d.LancamentoId);
            });

            modelBuilder.Entity<RecebimentoReceita>(entity =>
            {
                entity.HasIndex(e => e.ParcelaReceitaId, "IX_RecebimentoReceitas_ParcelaReceitaId");

                entity.HasOne(d => d.ParcelaReceita)
                    .WithMany(p => p.RecebimentoReceita)
                    .HasForeignKey(d => d.ParcelaReceitaId);
            });

            modelBuilder.Entity<SituacaoLancamentoDespesa>(entity =>
            {
                entity.ToTable("SituacaoLancamentoDesposa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
