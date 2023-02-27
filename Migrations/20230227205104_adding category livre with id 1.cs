using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluraChallenges.Migrations
{
    /// <inheritdoc />
    public partial class addingcategorylivrewithid1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Color", "Title" },
                values: new object[] { 1, "branco", "Livre" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
