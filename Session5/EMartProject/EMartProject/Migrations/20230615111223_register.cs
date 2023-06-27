using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EMartProject.Migrations
{
    /// <inheritdoc />
    public partial class register : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c840302-c5e2-4fc6-a6ed-e60e0e838c25", "712ac747-cf93-4888-a6d0-bb8ba7c1c42e", "Administartor", "ADMINISTRATOR" },
                    { "79c88601-a3ae-4003-b38f-cd749a7f34eb", "b8514857-0462-4297-9caa-cf0b7cd9cbd5", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c840302-c5e2-4fc6-a6ed-e60e0e838c25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79c88601-a3ae-4003-b38f-cd749a7f34eb");
        }
    }
}
