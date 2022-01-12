using Microsoft.EntityFrameworkCore.Migrations;

namespace HotDrinksMachine.Server.Migrations
{
    public partial class AddDrinksAndPreparationActionsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreparationActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreparationActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrinkPreparationActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionOrder = table.Column<int>(type: "int", nullable: false),
                    DrinkId = table.Column<int>(type: "int", nullable: false),
                    PreparationActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkPreparationActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrinkPreparationActions_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkPreparationActions_PreparationActions_PreparationActionId",
                        column: x => x.PreparationActionId,
                        principalTable: "PreparationActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrinkPreparationActions_DrinkId",
                table: "DrinkPreparationActions",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkPreparationActions_PreparationActionId",
                table: "DrinkPreparationActions",
                column: "PreparationActionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrinkPreparationActions");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "PreparationActions");
        }
    }
}
