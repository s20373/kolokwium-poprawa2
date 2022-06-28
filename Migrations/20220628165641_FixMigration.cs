using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolokwium_poprawa.Migrations
{
    public partial class FixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Team_TeamID",
                table: "Membership");

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Team_TeamID",
                table: "Membership",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Team_TeamID",
                table: "Membership");

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Team_TeamID",
                table: "Membership",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
