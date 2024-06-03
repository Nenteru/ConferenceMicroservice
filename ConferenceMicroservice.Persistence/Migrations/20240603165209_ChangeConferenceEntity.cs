using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceMicroservice.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConferenceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStart",
                table: "Conferences",
                newName: "DateTimeStart");

            migrationBuilder.RenameColumn(
                name: "TimeEnd",
                table: "Conferences",
                newName: "DateTimeEnd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeStart",
                table: "Conferences",
                newName: "TimeStart");

            migrationBuilder.RenameColumn(
                name: "DateTimeEnd",
                table: "Conferences",
                newName: "TimeEnd");
        }
    }
}
