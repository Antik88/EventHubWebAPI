using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventHubWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "EventImages");

            migrationBuilder.AddColumn<string>(
                name: "ImgaePath",
                table: "EventImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgaePath",
                table: "EventImages");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "EventImages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
