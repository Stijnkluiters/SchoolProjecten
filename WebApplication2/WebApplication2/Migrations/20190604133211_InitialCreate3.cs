using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Partij_PartijId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_PartijId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "PartijId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "PatrijId",
                table: "Player");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Partij",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Partij_PlayerId",
                table: "Partij",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partij_Player_PlayerId",
                table: "Partij",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partij_Player_PlayerId",
                table: "Partij");

            migrationBuilder.DropIndex(
                name: "IX_Partij_PlayerId",
                table: "Partij");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Partij");

            migrationBuilder.AddColumn<int>(
                name: "PartijId",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatrijId",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Player_PartijId",
                table: "Player",
                column: "PartijId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Partij_PartijId",
                table: "Player",
                column: "PartijId",
                principalTable: "Partij",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
