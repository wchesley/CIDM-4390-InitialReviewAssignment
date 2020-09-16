using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingClub.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ContentID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatorMemberID = table.Column<int>(nullable: true),
                    ContentTitle = table.Column<string>(nullable: true),
                    ContentBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ContentID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectDescription = table.Column<string>(nullable: true),
                    TeamLeaderMemberID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "ClubMember",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    ClubTitle = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    DuesPaid = table.Column<bool>(nullable: false),
                    Team = table.Column<int>(nullable: false),
                    TeamsTeamID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubMember", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_ClubMember_Teams_TeamsTeamID",
                        column: x => x.TeamsTeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubMember_TeamsTeamID",
                table: "ClubMember",
                column: "TeamsTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_CreatorMemberID",
                table: "Content",
                column: "CreatorMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamLeaderMemberID",
                table: "Teams",
                column: "TeamLeaderMemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_ClubMember_CreatorMemberID",
                table: "Content",
                column: "CreatorMemberID",
                principalTable: "ClubMember",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_ClubMember_TeamLeaderMemberID",
                table: "Teams",
                column: "TeamLeaderMemberID",
                principalTable: "ClubMember",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubMember_Teams_TeamsTeamID",
                table: "ClubMember");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "ClubMember");
        }
    }
}
