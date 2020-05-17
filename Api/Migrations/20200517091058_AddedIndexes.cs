using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class AddedIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_Name",
                table: "Beers",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countries_Name",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Beers_Name",
                table: "Beers");

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholVol", "ImageUri", "Name", "OriginId" },
                values: new object[] { 1, 4.6m, null, "Grøn Tuborg", 1 });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholVol", "ImageUri", "Name", "OriginId" },
                values: new object[] { 2, 6.4m, null, "Grimbergen", 2 });
        }
    }
}
