using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccess.Migrations
{
    public partial class bezvezne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeniMeals");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Menis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Menis_MealId",
                table: "Menis",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menis_Meals_MealId",
                table: "Menis",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menis_Meals_MealId",
                table: "Menis");

            migrationBuilder.DropIndex(
                name: "IX_Menis_MealId",
                table: "Menis");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Menis");

            migrationBuilder.CreateTable(
                name: "MeniMeals",
                columns: table => new
                {
                    MeniId = table.Column<int>(nullable: false),
                    MealId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeniMeals", x => new { x.MeniId, x.MealId });
                    table.ForeignKey(
                        name: "FK_MeniMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeniMeals_Menis_MeniId",
                        column: x => x.MeniId,
                        principalTable: "Menis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeniMeals_MealId",
                table: "MeniMeals",
                column: "MealId");
        }
    }
}
