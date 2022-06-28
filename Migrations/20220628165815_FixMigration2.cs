using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolokwium_poprawa.Migrations
{
    public partial class FixMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Member_MemberID",
                table: "Membership");

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Member_MemberID",
                table: "Membership",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Member_MemberID",
                table: "Membership");

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Member_MemberID",
                table: "Membership",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
