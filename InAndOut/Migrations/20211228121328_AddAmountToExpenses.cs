using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut.Migrations
{
    public partial class AddAmountToExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Expenses");
        }
    }
}
