using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace daroca_backend.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customer",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customer",
                newName: "CustomerId");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customer",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Customer",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customer",
                newName: "Id");
        }
    }
}
