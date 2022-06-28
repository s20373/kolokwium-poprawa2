﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolokwium_poprawa.Migrations
{
    public partial class FixMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Member_MemberID",
                table: "Membership");

            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Team_TeamID",
                table: "Membership");

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Member_MemberID",
                table: "Membership",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Team_TeamID",
                table: "Membership",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Member_MemberID",
                table: "Membership");

            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Team_TeamID",
                table: "Membership");

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Member_MemberID",
                table: "Membership",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Team_TeamID",
                table: "Membership",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
