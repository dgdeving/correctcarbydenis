using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorrectCar.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ListImageUrl",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListImageUrl",
                table: "Products");
        }
    }
}
