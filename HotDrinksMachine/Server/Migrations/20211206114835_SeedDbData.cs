using Microsoft.EntityFrameworkCore.Migrations;

namespace HotDrinksMachine.Server.Migrations
{
    public partial class SeedDbData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lemon Tea" },
                    { 2, "Coffee" },
                    { 3, "Chocolate" }
                });

            migrationBuilder.InsertData(
                table: "PreparationActions",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Boil some water" },
                    { 2, "Steep the water in the tea" },
                    { 3, "Pour tea in the cup" },
                    { 4, "Add lemon" },
                    { 5, "Brew the coffee grounds" },
                    { 6, "Pour coffee in the cup" },
                    { 7, "Add sugar and milk" },
                    { 8, "Add drinking chocolate powder to the water" },
                    { 9, "Pour chocolate in the cup" }
                });

            migrationBuilder.InsertData(
                table: "DrinkPreparationActions",
                columns: new[] { "Id", "ActionOrder", "DrinkId", "PreparationActionId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 5, 1, 2, 1 },
                    { 9, 1, 3, 1 },
                    { 2, 2, 1, 2 },
                    { 3, 3, 1, 3 },
                    { 4, 4, 1, 4 },
                    { 6, 2, 2, 5 },
                    { 7, 3, 2, 6 },
                    { 8, 4, 2, 7 },
                    { 10, 2, 3, 8 },
                    { 11, 3, 3, 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DrinkPreparationActions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DrinkPreparationActions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DrinkPreparationActions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DrinkPreparationActions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DrinkPreparationActions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DrinkPreparationActions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DrinkPreparationActions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DrinkPreparationActions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DrinkPreparationActions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DrinkPreparationActions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DrinkPreparationActions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PreparationActions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PreparationActions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PreparationActions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PreparationActions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PreparationActions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PreparationActions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PreparationActions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PreparationActions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PreparationActions",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
