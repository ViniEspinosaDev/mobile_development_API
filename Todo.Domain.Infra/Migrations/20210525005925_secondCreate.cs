using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo.Domain.Infra.Migrations
{
    public partial class secondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Todo",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Todo",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Todo",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Concluida",
                table: "Todo",
                newName: "Done");

            migrationBuilder.RenameIndex(
                name: "IX_Todo_Usuario",
                table: "Todo",
                newName: "IX_Todo_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Todo",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Todo",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Done",
                table: "Todo",
                newName: "Concluida");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Todo",
                newName: "Data");

            migrationBuilder.RenameIndex(
                name: "IX_Todo_User",
                table: "Todo",
                newName: "IX_Todo_Usuario");
        }
    }
}
