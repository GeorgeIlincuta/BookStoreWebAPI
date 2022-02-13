using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    public partial class ChangeLogModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Proprietes",
                table: "Logs",
                newName: "Properties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Properties",
                table: "Logs",
                newName: "Proprietes");
        }
    }
}
