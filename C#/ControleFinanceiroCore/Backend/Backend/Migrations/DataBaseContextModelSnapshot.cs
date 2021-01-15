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

                    b.Property<int?>("ContaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataDespesa")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Historico")
                        .HasColumnType("text");

                    b.Property<int>("Parcela")
                        .HasColumnType("integer");

                    b.Property<int?>("SitucaoLancamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalParcela")
                        .HasColumnType("integer");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.HasIndex("SitucaoLancamentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("LancamentosDespesas");
                });

            modelBuilder.Entity("Backend.Models.LancamentosReceita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("DataDespesa")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Historico")
                        .HasColumnType("text");

                    b.Property<int>("Parcela")
                        .HasColumnType("integer");

                    b.Property<int?>("SitucaoLancamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalParcela")
                        .HasColumnType("integer");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.Property<int?>("contaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SitucaoLancamentoId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("contaId");

                    b.ToTable("LancamentosReceitas");
                });

            modelBuilder.Entity("Backend.Models.SitaucaoLancamentoDespesa", b =>
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
                        .WithMany()
                        .HasForeignKey("ContaId");

                    b.HasOne("Backend.Models.SitaucaoLancamentoDespesa", "SitucaoLancamento")
                        .WithMany()
                        .HasForeignKey("SitucaoLancamentoId");

                    b.HasOne("Backend.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Conta");

                    b.Navigation("SitucaoLancamento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Backend.Models.LancamentosReceita", b =>
                {
                    b.HasOne("Backend.Models.SituacaoLancamentoReceita", "SitucaoLancamento")
                        .WithMany()
                        .HasForeignKey("SitucaoLancamentoId");

                    b.HasOne("Backend.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.HasOne("Backend.Models.ContaReceita", "conta")
                        .WithMany()
                        .HasForeignKey("contaId");

                    b.Navigation("conta");

                    b.Navigation("SitucaoLancamento");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
