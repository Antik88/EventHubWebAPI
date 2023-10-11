using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventHubWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addEventCategoryManytoOneFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
