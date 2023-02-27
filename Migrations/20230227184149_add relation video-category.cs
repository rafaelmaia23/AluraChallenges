using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluraChallenges.Migrations
{
    /// <inheritdoc />
    public partial class addrelationvideocategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_videos_CategoryId",
                table: "videos",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_videos_categories_CategoryId",
                table: "videos",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videos_categories_CategoryId",
                table: "videos");

            migrationBuilder.DropIndex(
                name: "IX_videos_CategoryId",
                table: "videos");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "videos");
        }
    }
}
