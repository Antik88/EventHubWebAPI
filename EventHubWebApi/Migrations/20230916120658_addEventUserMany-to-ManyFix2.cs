using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventHubWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addEventUserManytoManyFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Users_ParticipantId",
                table: "EventUser");

            migrationBuilder.RenameColumn(
                name: "ParticipantId",
                table: "EventUser",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_ParticipantId",
                table: "EventUser",
                newName: "IX_EventUser_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Users_UsersId",
                table: "EventUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Users_UsersId",
                table: "EventUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "EventUser",
                newName: "ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_UsersId",
                table: "EventUser",
                newName: "IX_EventUser_ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Users_ParticipantId",
                table: "EventUser",
                column: "ParticipantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
