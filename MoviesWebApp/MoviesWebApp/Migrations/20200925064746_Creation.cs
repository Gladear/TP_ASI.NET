using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MoviesWebApp.Migrations
{
    public partial class Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_E_COMPTE_CPT",
                columns: table => new
                {
                    CPT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPT_NOM = table.Column<string>(maxLength: 50, nullable: false),
                    CPT_PRENOM = table.Column<string>(maxLength: 50, nullable: false),
                    CPT_TELPORTABLE = table.Column<string>(type: "char(10)", nullable: true),
                    CPT_MEL = table.Column<string>(maxLength: 100, nullable: false),
                    CPT_PWD = table.Column<string>(maxLength: 64, nullable: true),
                    CPT_RUE = table.Column<string>(maxLength: 200, nullable: true),
                    CPT_CP = table.Column<string>(type: "char(5)", nullable: false),
                    CPT_VILLE = table.Column<string>(maxLength: 50, nullable: true),
                    CPT_PAYS = table.Column<string>(maxLength: 50, nullable: true, defaultValue: "France"),
                    CPT_LATITUDE = table.Column<float>(nullable: true),
                    CPT_LONGITUDE = table.Column<float>(nullable: true),
                    CPT_DATECREATION = table.Column<DateTime>(nullable: false, defaultValueSql: "current_date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_E_COMPTE_CPT", x => x.CPT_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_E_FILM_FLM",
                columns: table => new
                {
                    FLM_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FLM_TITRE = table.Column<string>(nullable: false),
                    FLM_SYNOPSIS = table.Column<string>(nullable: true),
                    FLM_DATEPARUTION = table.Column<DateTime>(nullable: false),
                    FLM_DUREE = table.Column<long>(nullable: false),
                    FLM_GENRE = table.Column<string>(nullable: false),
                    FLM_URLPHOTO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_E_FILM_FLM", x => x.FLM_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_J_FAVORI_FAV",
                columns: table => new
                {
                    CPT_ID = table.Column<int>(nullable: false),
                    FLM_ID = table.Column<int>(nullable: false),
                    Compte = table.Column<int>(nullable: true),
                    Film = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fav", x => new { x.FLM_ID, x.CPT_ID });
                    table.ForeignKey(
                        name: "fk_fav_cpt",
                        column: x => x.CPT_ID,
                        principalTable: "T_E_COMPTE_CPT",
                        principalColumn: "CPT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fav_flm",
                        column: x => x.FLM_ID,
                        principalTable: "T_E_FILM_FLM",
                        principalColumn: "FLM_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "uq_cpt_mel",
                table: "T_E_COMPTE_CPT",
                column: "CPT_MEL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_J_FAVORI_FAV_CPT_ID",
                table: "T_J_FAVORI_FAV",
                column: "CPT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_J_FAVORI_FAV");

            migrationBuilder.DropTable(
                name: "T_E_COMPTE_CPT");

            migrationBuilder.DropTable(
                name: "T_E_FILM_FLM");
        }
    }
}
