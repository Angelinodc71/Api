using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class AddAgeInEntityCast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "Casts",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "Casts");
        }
    }
}
