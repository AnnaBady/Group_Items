using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemQuantity",
                table: "Items_Class");

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemPrice",
                table: "Items_Class",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Items_Class",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemImage",
                table: "Items_Class",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Items_Class");

            migrationBuilder.DropColumn(
                name: "ItemImage",
                table: "Items_Class");

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemPrice",
                table: "Items_Class",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ItemQuantity",
                table: "Items_Class",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
