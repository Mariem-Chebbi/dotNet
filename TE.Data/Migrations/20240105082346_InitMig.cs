using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TE.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concours",
                columns: table => new
                {
                    Promotion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NbrEM = table.Column<int>(type: "int", nullable: false),
                    NbrGC = table.Column<int>(type: "int", nullable: false),
                    NbrGED = table.Column<int>(type: "int", nullable: false),
                    NbrLANGUE = table.Column<int>(type: "int", nullable: false),
                    NbrMATH = table.Column<int>(type: "int", nullable: false),
                    NbrTIC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concours", x => x.Promotion);
                });

            migrationBuilder.CreateTable(
                name: "UP",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UP", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    Matricule = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Specialite = table.Column<int>(type: "int", nullable: false),
                    UPFK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.Matricule);
                    table.ForeignKey(
                        name: "FK_Enseignant_UP_UPFK",
                        column: x => x.UPFK,
                        principalTable: "UP",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidature",
                columns: table => new
                {
                    EnseignantFk = table.Column<int>(type: "int", nullable: false),
                    ConcoursFk = table.Column<int>(type: "int", nullable: false),
                    DateDepot = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEntretien = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEpreuve = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dossier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resultat = table.Column<bool>(type: "bit", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidature", x => new { x.ConcoursFk, x.EnseignantFk });
                    table.ForeignKey(
                        name: "FK_Candidature_Concours_ConcoursFk",
                        column: x => x.ConcoursFk,
                        principalTable: "Concours",
                        principalColumn: "Promotion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidature_Enseignant_EnseignantFk",
                        column: x => x.EnseignantFk,
                        principalTable: "Enseignant",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_EnseignantFk",
                table: "Candidature",
                column: "EnseignantFk");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignant_UPFK",
                table: "Enseignant",
                column: "UPFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidature");

            migrationBuilder.DropTable(
                name: "Concours");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "UP");
        }
    }
}
