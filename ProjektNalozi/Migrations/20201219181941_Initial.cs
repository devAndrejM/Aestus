using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektNalozi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Putnici",
                columns: table => new
                {
                    PutnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Putnici", x => x.PutnikId);
                });

            migrationBuilder.CreateTable(
                name: "PutniNalozi",
                columns: table => new
                {
                    PutniNalogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazlogPutovanja = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Polazak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Povratak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojPutnika = table.Column<int>(type: "int", nullable: false),
                    Polaziste = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Odrediste = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Prijevoz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistracijaVozila = table.Column<string>(type: "varchar(8)", nullable: true),
                    Komentar = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutniNalozi", x => x.PutniNalogId);
                });

            migrationBuilder.CreateTable(
                name: "PutnikoviNalozi",
                columns: table => new
                {
                    PutnikId = table.Column<int>(type: "int", nullable: false),
                    PutniNalogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutnikoviNalozi", x => new { x.PutnikId, x.PutniNalogId });
                    table.ForeignKey(
                        name: "FK_PutnikoviNalozi_Putnici_PutnikId",
                        column: x => x.PutnikId,
                        principalTable: "Putnici",
                        principalColumn: "PutnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PutnikoviNalozi_PutniNalozi_PutniNalogId",
                        column: x => x.PutniNalogId,
                        principalTable: "PutniNalozi",
                        principalColumn: "PutniNalogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PutniNalozi",
                columns: new[] { "PutniNalogId", "BrojPutnika", "Email", "Komentar", "Odrediste", "Polazak", "Polaziste", "Povratak", "Prijevoz", "RazlogPutovanja", "RegistracijaVozila" },
                values: new object[,]
                {
                    { 1, 1, "ivan@gmail.com", "", "Osijek", new DateTime(2018, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zagreb", new DateTime(2018, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Službeni automobil", "Moralo se", "ZG2342CA" },
                    { 2, 2, "ivan@gmail.com", "eto", "Osijek", new DateTime(2020, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zagreb", new DateTime(2020, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Službeni automobil", "Moralo se", "ZG2342CA" },
                    { 3, 3, "ivan@gmail.com", "", "Osijek", new DateTime(2019, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zagreb", new DateTime(2019, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Službeni automobil", "Moralo se", "ZG2342CA" },
                    { 4, 1, "ivan@gmail.com", "", "Osijek", new DateTime(2021, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zagreb", new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Službeni automobil", "Moralo se", "ZG2342CA" }
                });

            migrationBuilder.InsertData(
                table: "Putnici",
                columns: new[] { "PutnikId", "Ime", "Prezime" },
                values: new object[,]
                {
                    { 1, "Marko", "Markić" },
                    { 2, "Ivan", "Ivanić" },
                    { 3, "Luna", "Lunić" },
                    { 4, "Karla", "Karlić" }
                });

            migrationBuilder.InsertData(
                table: "PutnikoviNalozi",
                columns: new[] { "PutniNalogId", "PutnikId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PutnikoviNalozi_PutniNalogId",
                table: "PutnikoviNalozi",
                column: "PutniNalogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PutnikoviNalozi");

            migrationBuilder.DropTable(
                name: "Putnici");

            migrationBuilder.DropTable(
                name: "PutniNalozi");
        }
    }
}
