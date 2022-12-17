using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LinkGenderUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Genders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_GenderId",
                table: "Genders",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genders_Genders_GenderId",
                table: "Genders",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Genders_GenderId",
                table: "Users",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genders_Genders_GenderId",
                table: "Genders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Genders_GenderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GenderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Genders_GenderId",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Genders");
        }
    }
}
