﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vsoft.Estacionamento.Database.DataContext;

namespace Vsoft.Estacionamento.Database.Migrations
{
    [DbContext(typeof(EstacionamentoDbContext))]
    partial class EstacionamentoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vsoft.Estacionamento.Core.Models.IlhaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Localizacao")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ilhas");
                });

            modelBuilder.Entity("Vsoft.Estacionamento.Core.Models.MovimentacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CorVeiculo");

                    b.Property<string>("CpfCliente");

                    b.Property<DateTime>("DataEntrada");

                    b.Property<DateTime?>("DataSaida");

                    b.Property<int>("IdVaga");

                    b.Property<string>("NomeCliente");

                    b.Property<string>("NomeVeiculo");

                    b.Property<string>("PlacaVeiculo");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("IdVaga");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("Vsoft.Estacionamento.Core.Models.VagaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativa")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<int>("IdIlha");

                    b.Property<bool>("Ocupada");

                    b.HasKey("Id");

                    b.HasIndex("IdIlha");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("Vsoft.Estacionamento.Core.Models.MovimentacaoModel", b =>
                {
                    b.HasOne("Vsoft.Estacionamento.Core.Models.VagaModel", "Vaga")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("IdVaga")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vsoft.Estacionamento.Core.Models.VagaModel", b =>
                {
                    b.HasOne("Vsoft.Estacionamento.Core.Models.IlhaModel", "Ilha")
                        .WithMany("Vagas")
                        .HasForeignKey("IdIlha")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
