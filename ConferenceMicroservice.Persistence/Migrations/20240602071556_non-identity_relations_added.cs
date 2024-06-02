using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceMicroservice.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class nonidentity_relations_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Parties_PartyId",
                table: "Messages");

            migrationBuilder.AlterColumn<Guid>(
                name: "PartyId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Parties_PartyId",
                table: "Messages",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Parties_PartyId",
                table: "Messages");

            migrationBuilder.AlterColumn<Guid>(
                name: "PartyId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Parties_PartyId",
                table: "Messages",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "Id");
        }
    }
}
