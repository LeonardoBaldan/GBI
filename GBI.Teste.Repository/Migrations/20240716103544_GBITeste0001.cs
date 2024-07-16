using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBI.Teste.Repository.Migrations
{
    /// <inheritdoc />
    public partial class GBITeste0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_gbi_usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(70)", maxLength: 70, nullable: false),
                    RG = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime", nullable: false),
                    CPF = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    Celular = table.Column<long>(type: "bigint", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_gbi_usuario", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_gbi_usuario");
        }
    }
}
