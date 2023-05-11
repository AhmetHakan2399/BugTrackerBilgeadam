using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTrackerBilgeAdam.Migrations
{
    public partial class öncelik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HataÖncelik",
                table: "Hatalar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HataÖncelik",
                table: "Hatalar");
        }
    }
}
