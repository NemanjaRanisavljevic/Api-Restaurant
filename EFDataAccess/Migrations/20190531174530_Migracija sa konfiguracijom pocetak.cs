using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccess.Migrations
{
    public partial class Migracijasakonfiguracijompocetak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    ModifieAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DrinkName = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    ModifieAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Start = table.Column<string>(nullable: false),
                    Finish = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    ModifieAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    NameFood = table.Column<string>(maxLength: 30, nullable: false),
                    Ingrediant = table.Column<string>(nullable: false),
                    Price = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    ModifieAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    NameRole = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    ModifieAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false, defaultValue: false),
                    Token = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Impressions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    ModifieAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Content = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impressions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Impressions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    ModifieAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ReservationDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    Guest = table.Column<int>(nullable: false),
                    Time = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Impressions_UserId",
                table: "Impressions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeniMeals_MealId",
                table: "MeniMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Impressions");

            migrationBuilder.DropTable(
                name: "MeniMeals");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Menis");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
