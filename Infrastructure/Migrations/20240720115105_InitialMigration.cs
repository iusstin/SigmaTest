using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Candidates",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                StartCallTimeInterval = table.Column<DateTime>(type: "datetime2", nullable: true),
                EndCallTimeIntervall = table.Column<DateTime>(type: "datetime2", nullable: true),
                LinkedInProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                GitHubProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Candidates", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Candidates_Email",
            table: "Candidates",
            column: "Email",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Candidates");
    }
}
