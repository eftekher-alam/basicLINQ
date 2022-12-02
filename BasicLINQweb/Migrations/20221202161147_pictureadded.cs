using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicLINQweb.Migrations
{
    public partial class pictureadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Vehicles");
        }
    }
}
