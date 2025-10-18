using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModuloAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    NomeUsuario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    role = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.Id_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "tb_veiculo",
                columns: table => new
                {
                    Id_Veiculo = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Nome_Veiculo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Marca_Veiculo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ano_Veiculo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_veiculo", x => x.Id_Veiculo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_usuario");

            migrationBuilder.DropTable(
                name: "tb_veiculo");
        }
    }
}
