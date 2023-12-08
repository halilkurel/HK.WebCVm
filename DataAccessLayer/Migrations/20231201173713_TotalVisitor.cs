using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class TotalVisitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminUrl",
                table: "Footers");

            migrationBuilder.AddColumn<int>(
                name: "TotalVisitor",
                table: "Footers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalVisitor",
                table: "Footers");

            migrationBuilder.AddColumn<string>(
                name: "AdminUrl",
                table: "Footers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
