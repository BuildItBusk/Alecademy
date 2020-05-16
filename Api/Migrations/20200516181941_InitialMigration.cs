using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    AlcoholVol = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    OriginId = table.Column<int>(nullable: false),
                    ImageUri = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beers_Countries_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Denmark" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "France" });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholVol", "ImageUri", "Name", "OriginId" },
                values: new object[] { 1, 4.6m, null, "Grøn Tuborg", 1 });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholVol", "ImageUri", "Name", "OriginId" },
                values: new object[] { 2, 6.4m, null, "Grimbergen", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_OriginId",
                table: "Beers",
                column: "OriginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
