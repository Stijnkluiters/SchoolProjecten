using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Player",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartijId",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatrijId",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Partij",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dag = table.Column<int>(nullable: false),
                    Uitslag = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partij", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Partij_PartijId",
                table: "Player");

            migrationBuilder.DropTable(
                name: "Partij");

            migrationBuilder.DropIndex(
                name: "IX_Player_PartijId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "PartijId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "PatrijId",
                table: "Player");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Player",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
