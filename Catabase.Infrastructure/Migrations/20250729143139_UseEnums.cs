using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UseEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Cats");

            migrationBuilder.AlterColumn<int>(
                name: "Breed",
                table: "Cats",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryColor",
                table: "Cats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryColor",
                table: "Cats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryColor",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "SecondaryColor",
                table: "Cats");

            migrationBuilder.AlterColumn<string>(
                name: "Breed",
                table: "Cats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Cats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
