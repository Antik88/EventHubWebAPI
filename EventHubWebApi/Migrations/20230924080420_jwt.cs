using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventHubWebApi.Migrations
{
    /// <inheritdoc />
    public partial class jwt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventReview_Events_EventId",
                table: "EventReview");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReview_Users_UserId",
                table: "EventReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventReview",
                table: "EventReview");

            migrationBuilder.RenameTable(
                name: "EventReview",
                newName: "EventReviews");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameIndex(
                name: "IX_EventReview_UserId",
                table: "EventReviews",
                newName: "IX_EventReviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_EventReview_EventId",
                table: "EventReviews",
                newName: "IX_EventReviews_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventReviews",
                table: "EventReviews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventReviews_Events_EventId",
                table: "EventReviews",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventReviews_Users_UserId",
                table: "EventReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventReviews_Events_EventId",
                table: "EventReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReviews_Users_UserId",
                table: "EventReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventReviews",
                table: "EventReviews");

            migrationBuilder.RenameTable(
                name: "EventReviews",
                newName: "EventReview");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameIndex(
                name: "IX_EventReviews_UserId",
                table: "EventReview",
                newName: "IX_EventReview_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_EventReviews_EventId",
                table: "EventReview",
                newName: "IX_EventReview_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventReview",
                table: "EventReview",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventReview_Events_EventId",
                table: "EventReview",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventReview_Users_UserId",
                table: "EventReview",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
