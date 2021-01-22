﻿// <auto-generated />
using System;
using Backend.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:Collation", "Portuguese_Brazil.1252")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Backend.Models.ContaDespesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Codigo")
                        .HasColumnType("text");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ContaDespesa");
                });

            modelBuilder.Entity("Backend.Models.ContaReceita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Codigo")
                        .HasColumnType("text");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ContaReceita");
                });

            modelBuilder.Entity("Backend.Models.LancamentosDespesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("ContaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataDespesa")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Historico")
                        .HasColumnType("text");

                    b.Property<int>("Parcela")
                        .HasColumnType("integer");

                    b.Property<int>("SitucaoLancamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalParcela")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ContaId" }, "IX_LancamentosDespesas_ContaId");

                    b.HasIndex(new[] { "SitucaoLancamentoId" }, "IX_LancamentosDespesas_SitucaoLancamentoId");

                    b.HasIndex(new[] { "UsuarioId" }, "IX_LancamentosDespesas_UsuarioId");

                    b.ToTable("LancamentosDespesas");
                });

            modelBuilder.Entity("Backend.Models.LancamentosReceita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("ContaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataReceita")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Historico")
                        .HasColumnType("text");

                    b.Property<int>("Parcela")
                        .HasColumnType("integer");

                    b.Property<int>("SitucaoLancamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalParcela")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ContaId" }, "IX_LancamentosReceitas_ContaId");

                    b.HasIndex(new[] { "SitucaoLancamentoId" }, "IX_LancamentosReceitas_SitucaoLancamentoId");

                    b.HasIndex(new[] { "UsuarioId" }, "IX_LancamentosReceitas_UsuarioId");

                    b.ToTable("LancamentosReceitas");
                });

            modelBuilder.Entity("Backend.Models.PagamentoDespesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("ContaId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DataPagto")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Historico")
                        .HasColumnType("text");

                    b.Property<int>("ParcelaId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ContaId" }, "IX_PagamentoDespesas_ContaId");

                    b.HasIndex(new[] { "ParcelaId" }, "IX_PagamentoDespesas_ParcelaId");

                    b.ToTable("PagamentoDespesas");
                });

            modelBuilder.Entity("Backend.Models.ParcelaDespesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("DataPagto")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Historico")
                        .HasColumnType("text");

                    b.Property<int>("LancamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("Parcela")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("ValorPago")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "LancamentoId" }, "IX_ParcelaDespesa_LancamentoId");

                    b.ToTable("ParcelaDespesa");
                });

            modelBuilder.Entity("Backend.Models.ParcelaReceita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("DataRecebido")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Historico")
                        .HasColumnType("text");

                    b.Property<int>("LancamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("Parcela")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("ValorRecebido")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "LancamentoId" }, "IX_ParcelaReceitas_LancamentoId");

                    b.ToTable("ParcelaReceitas");
                });

            modelBuilder.Entity("Backend.Models.RecebimentoReceita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("DataReceb")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Historico")
                        .HasColumnType("text");

                    b.Property<int>("ParcelaReceitaId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ParcelaReceitaId" }, "IX_RecebimentoReceitas_ParcelaReceitaId");

                    b.ToTable("RecebimentoReceitas");
                });

            modelBuilder.Entity("Backend.Models.SituacaoLancamentoDespesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Codigo")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SituacaoLancamentoDesposa");
                });

            modelBuilder.Entity("Backend.Models.SituacaoLancamentoReceita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Codigo")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SituacaoLancamentoReceita");
                });

            modelBuilder.Entity("Backend.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Backend.Models.LancamentosDespesa", b =>
                {
                    b.HasOne("Backend.Models.ContaDespesa", "Conta")
                        .WithMany("LancamentosDespesas")
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.SituacaoLancamentoDespesa", "SitucaoLancamento")
                        .WithMany("LancamentosDespesas")
                        .HasForeignKey("SitucaoLancamentoId")
                        .HasConstraintName("FK_LancamentosDespesas_SituacaoLancamentoDesposa_SitucaoLancam~")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Usuario", "Usuario")
                        .WithMany("LancamentosDespesas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");

                    b.Navigation("SitucaoLancamento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Backend.Models.LancamentosReceita", b =>
                {
                    b.HasOne("Backend.Models.ContaReceita", "Conta")
                        .WithMany("LancamentosReceita")
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.SituacaoLancamentoReceita", "SitucaoLancamento")
                        .WithMany("LancamentosReceita")
                        .HasForeignKey("SitucaoLancamentoId")
                        .HasConstraintName("FK_LancamentosReceitas_SituacaoLancamentoReceita_SitucaoLancam~")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Usuario", "Usuario")
                        .WithMany("LancamentosReceita")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");

                    b.Navigation("SitucaoLancamento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Backend.Models.PagamentoDespesa", b =>
                {
                    b.HasOne("Backend.Models.ContaReceita", "Conta")
                        .WithMany("PagamentoDespesas")
                        .HasForeignKey("ContaId");

                    b.HasOne("Backend.Models.ParcelaDespesa", "Parcela")
                        .WithMany("PagamentoDespesas")
                        .HasForeignKey("ParcelaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");

                    b.Navigation("Parcela");
                });

            modelBuilder.Entity("Backend.Models.ParcelaDespesa", b =>
                {
                    b.HasOne("Backend.Models.LancamentosDespesa", "Lancamento")
                        .WithMany("ParcelaDespesas")
                        .HasForeignKey("LancamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lancamento");
                });

            modelBuilder.Entity("Backend.Models.ParcelaReceita", b =>
                {
                    b.HasOne("Backend.Models.LancamentosReceita", "Lancamento")
                        .WithMany("ParcelaReceita")
                        .HasForeignKey("LancamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lancamento");
                });

            modelBuilder.Entity("Backend.Models.RecebimentoReceita", b =>
                {
                    b.HasOne("Backend.Models.ParcelaReceita", "ParcelaReceita")
                        .WithMany("RecebimentoReceita")
                        .HasForeignKey("ParcelaReceitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParcelaReceita");
                });

            modelBuilder.Entity("Backend.Models.ContaDespesa", b =>
                {
                    b.Navigation("LancamentosDespesas");
                });

            modelBuilder.Entity("Backend.Models.ContaReceita", b =>
                {
                    b.Navigation("LancamentosReceita");

                    b.Navigation("PagamentoDespesas");
                });

            modelBuilder.Entity("Backend.Models.LancamentosDespesa", b =>
                {
                    b.Navigation("ParcelaDespesas");
                });

            modelBuilder.Entity("Backend.Models.LancamentosReceita", b =>
                {
                    b.Navigation("ParcelaReceita");
                });

            modelBuilder.Entity("Backend.Models.ParcelaDespesa", b =>
                {
                    b.Navigation("PagamentoDespesas");
                });

            modelBuilder.Entity("Backend.Models.ParcelaReceita", b =>
                {
                    b.Navigation("RecebimentoReceita");
                });

            modelBuilder.Entity("Backend.Models.SituacaoLancamentoDespesa", b =>
                {
                    b.Navigation("LancamentosDespesas");
                });

            modelBuilder.Entity("Backend.Models.SituacaoLancamentoReceita", b =>
                {
                    b.Navigation("LancamentosReceita");
                });

            modelBuilder.Entity("Backend.Models.Usuario", b =>
                {
                    b.Navigation("LancamentosDespesas");

                    b.Navigation("LancamentosReceita");
                });
#pragma warning restore 612, 618
        }
    }
}
