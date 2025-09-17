using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstacionamento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeColunasTempo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicioVigencia",
                table: "preco_estacionamento",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFimVigencia",
                table: "preco_estacionamento",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "PlacaCarro",
                table: "entrada_saida",
                type: "character varying(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataSaida",
                table: "entrada_saida",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrada",
                table: "entrada_saida",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "carro",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicioVigencia",
                table: "preco_estacionamento",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFimVigencia",
                table: "preco_estacionamento",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<string>(
                name: "PlacaCarro",
                table: "entrada_saida",
                type: "character varying(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(8)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataSaida",
                table: "entrada_saida",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrada",
                table: "entrada_saida",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "carro",
                type: "character varying(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(8)",
                oldMaxLength: 8);
        }
    }
}
