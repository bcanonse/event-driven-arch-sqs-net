using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventOne.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    LicenseNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("drivers_pk_id", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "drivers",
                columns: new[] { "Id", "FirstName", "LastName", "LicenseNumber" },
                values: new object[] { new Guid("a34cadab-a2d9-4180-abad-987aa96e88ef"), "Bryan", "Canon", "KS0-34KSDFGSD" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drivers");
        }
    }
}
