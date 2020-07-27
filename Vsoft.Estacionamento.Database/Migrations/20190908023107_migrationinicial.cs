using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vsoft.Estacionamento.Database.Migrations
{
    public partial class migrationinicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ilhas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Localizacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ocupada = table.Column<bool>(nullable: false),
                    Ativa = table.Column<bool>(nullable: true, defaultValue: true),
                    IdIlha = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vagas_Ilhas_IdIlha",
                        column: x => x.IdIlha,
                        principalTable: "Ilhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    IdVaga = table.Column<int>(nullable: false),
                    NomeVeiculo = table.Column<string>(nullable: true),
                    PlacaVeiculo = table.Column<string>(nullable: true),
                    CorVeiculo = table.Column<string>(nullable: true),
                    NomeCliente = table.Column<string>(nullable: true),
                    CpfCliente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Vagas_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_IdVaga",
                table: "Movimentacoes",
                column: "IdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_IdIlha",
                table: "Vagas",
                column: "IdIlha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "Ilhas");
        }
    }
}
