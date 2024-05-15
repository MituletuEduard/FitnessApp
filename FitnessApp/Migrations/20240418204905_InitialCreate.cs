using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antrenament",
                columns: table => new
                {
                    ID_Antrenament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Istoric = table.Column<int>(type: "int", nullable: false),
                    Antrenament_Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antrenament", x => x.ID_Antrenament);
                });

            migrationBuilder.CreateTable(
                name: "Utilizatori",
                columns: table => new
                {
                    ID_Utilizator = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizatori", x => x.ID_Utilizator);
                });

            migrationBuilder.CreateTable(
                name: "Exercitiu",
                columns: table => new
                {
                    ID_Exercitiu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Antrenament = table.Column<int>(type: "int", nullable: false),
                    Nr_Repetari = table.Column<int>(type: "int", nullable: false),
                    Greutate_Adaugata = table.Column<int>(type: "int", nullable: false),
                    AntrenamentID_Antrenament = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercitiu", x => x.ID_Exercitiu);
                    table.ForeignKey(
                        name: "FK_Exercitiu_Antrenament_AntrenamentID_Antrenament",
                        column: x => x.AntrenamentID_Antrenament,
                        principalTable: "Antrenament",
                        principalColumn: "ID_Antrenament",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Istoric",
                columns: table => new
                {
                    ID_Istoric = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Utilizator = table.Column<int>(type: "int", nullable: false),
                    ID_Antrenament = table.Column<int>(type: "int", nullable: false),
                    UtilizatorID_Utilizator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Istoric", x => x.ID_Istoric);
                    table.ForeignKey(
                        name: "FK_Istoric_Antrenament_ID_Antrenament",
                        column: x => x.ID_Antrenament,
                        principalTable: "Antrenament",
                        principalColumn: "ID_Antrenament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Istoric_Utilizatori_UtilizatorID_Utilizator",
                        column: x => x.UtilizatorID_Utilizator,
                        principalTable: "Utilizatori",
                        principalColumn: "ID_Utilizator",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Masuratori",
                columns: table => new
                {
                    ID_Masuratori = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Greutate = table.Column<int>(type: "int", nullable: false),
                    ID_Utilizator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masuratori", x => x.ID_Masuratori);
                    table.ForeignKey(
                        name: "FK_Masuratori_Utilizatori_ID_Utilizator",
                        column: x => x.ID_Utilizator,
                        principalTable: "Utilizatori",
                        principalColumn: "ID_Utilizator",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercitiu_AntrenamentID_Antrenament",
                table: "Exercitiu",
                column: "AntrenamentID_Antrenament");

            migrationBuilder.CreateIndex(
                name: "IX_Istoric_ID_Antrenament",
                table: "Istoric",
                column: "ID_Antrenament",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Istoric_UtilizatorID_Utilizator",
                table: "Istoric",
                column: "UtilizatorID_Utilizator");

            migrationBuilder.CreateIndex(
                name: "IX_Masuratori_ID_Utilizator",
                table: "Masuratori",
                column: "ID_Utilizator",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercitiu");

            migrationBuilder.DropTable(
                name: "Istoric");

            migrationBuilder.DropTable(
                name: "Masuratori");

            migrationBuilder.DropTable(
                name: "Antrenament");

            migrationBuilder.DropTable(
                name: "Utilizatori");
        }
    }
}
