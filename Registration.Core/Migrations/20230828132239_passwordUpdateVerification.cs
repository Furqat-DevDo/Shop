using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Core.Migrations
{
    /// <inheritdoc />
    public partial class passwordUpdateVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "PasswordUpdates",
                columns: table => new
                {
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    NewPassword = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordUpdates", x => x.EmailAddress);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordUpdates");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "text",
                nullable: true);
        }
    }
}
