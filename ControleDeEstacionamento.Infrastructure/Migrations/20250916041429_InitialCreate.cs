using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleDeEstacionamento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carro",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carro", x => x.Placa);
                });

            migrationBuilder.CreateTable(
                name: "preco_estacionamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ValorHoraInicial = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorHoraAdicional = table.Column<decimal>(type: "numeric", nullable: false),
                    DataInicioVigencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFimVigencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preco_estacionamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "entrada_saida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlacaCarro = table.Column<string>(type: "character varying(6)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ValorAPagar = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrada_saida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_entrada_saida_carro_PlacaCarro",
                        column: x => x.PlacaCarro,
                        principalTable: "carro",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_entrada_saida_PlacaCarro",
                table: "entrada_saida",
                column: "PlacaCarro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entrada_saida");

            migrationBuilder.DropTable(
                name: "preco_estacionamento");

            migrationBuilder.DropTable(
                name: "carro");
        }
    }
}
