using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventFlow.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionUpcoming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Upcomings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Upcomings");
        }
    }
}
