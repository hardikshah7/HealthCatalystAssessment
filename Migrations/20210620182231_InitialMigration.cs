using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCatalystAssessment.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_Interest_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName" },
                values: new object[] { new Guid("dd6ebe6c-875e-455a-aa1e-edb1429f93e7"), "Oregon", (byte)30, "Hardik", "Shah" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName" },
                values: new object[] { new Guid("024f1c07-4f80-4540-8495-6027e49a8866"), "Carribean", (byte)35, "Jack", "Sparrow" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName" },
                values: new object[] { new Guid("6546b18a-62e4-4a48-a5fc-fc4f9171a7d1"), "Hogwarts", (byte)20, "Harry", "Potter" });

            migrationBuilder.InsertData(
                table: "Interest",
                columns: new[] { "Id", "UserId", "Activity" },
                values: new object[,]
                {
                    { new Guid("df96d2af-a5a5-4dec-af24-d7689aa4cb89"), new Guid("dd6ebe6c-875e-455a-aa1e-edb1429f93e7"), "Video Games" },
                    { new Guid("8c82801f-33d2-4ae5-954b-94befe92aaa7"), new Guid("dd6ebe6c-875e-455a-aa1e-edb1429f93e7"), "Biking" },
                    { new Guid("1b5cafd3-c40e-48e8-ab85-1f1a67d04fe3"), new Guid("dd6ebe6c-875e-455a-aa1e-edb1429f93e7"), "Software Development" },
                    { new Guid("147e22fe-3ca9-4322-9b68-fa09f9bfc814"), new Guid("024f1c07-4f80-4540-8495-6027e49a8866"), "Black Pearl" },
                    { new Guid("c0c064dd-c018-45bf-8cb0-e0435b601518"), new Guid("024f1c07-4f80-4540-8495-6027e49a8866"), "Treasure hunting" },
                    { new Guid("9617799a-7ce2-41f1-bf71-3818c3851834"), new Guid("024f1c07-4f80-4540-8495-6027e49a8866"), "Sea Adventures" },
                    { new Guid("8f6a72a5-5b9b-4655-8db4-1a7adbc340ce"), new Guid("6546b18a-62e4-4a48-a5fc-fc4f9171a7d1"), "Quidditch" },
                    { new Guid("6c5df546-68fa-4d11-a98c-a2869d3f6139"), new Guid("6546b18a-62e4-4a48-a5fc-fc4f9171a7d1"), "Magic" },
                    { new Guid("89e77ce5-b481-4a0b-81ac-718da50d24c7"), new Guid("6546b18a-62e4-4a48-a5fc-fc4f9171a7d1"), "Butterbeer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
