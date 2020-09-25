using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesWebApp.Migrations
{
    public partial class NewAnnotations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Compte",
                table: "T_J_FAVORI_FAV");

            migrationBuilder.DropColumn(
                name: "Film",
                table: "T_J_FAVORI_FAV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Compte",
                table: "T_J_FAVORI_FAV",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Film",
                table: "T_J_FAVORI_FAV",
                type: "integer",
                nullable: true);
        }
    }
}
