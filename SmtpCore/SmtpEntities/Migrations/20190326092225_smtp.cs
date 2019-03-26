using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmtpEntities.Migrations
{
    public partial class smtp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Group_GroupId",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GroupEmails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupEmails_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupEmails_Emails_UserId",
                        column: x => x.UserId,
                        principalTable: "Emails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupEmails_GroupId",
                table: "GroupEmails",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEmails_UserId",
                table: "GroupEmails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Groups_GroupId",
                table: "UserGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Groups_GroupId",
                table: "UserGroups");

            migrationBuilder.DropTable(
                name: "GroupEmails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Group_GroupId",
                table: "UserGroups",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
