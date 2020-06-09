using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "recettes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titre = table.Column<string>(nullable: true),
                    recette = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    typeRecette = table.Column<int>(nullable: false),
                    createdBy = table.Column<int>(nullable: false),
                    dateAdd = table.Column<DateTime>(nullable: false),
                    dateModify = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recettes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recettes");
        }
    }
}
