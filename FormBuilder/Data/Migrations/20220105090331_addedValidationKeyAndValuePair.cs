using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Data.Migrations
{
    public partial class addedValidationKeyAndValuePair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValidationType",
                table: "Validations",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Validations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Validations");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Validations",
                newName: "ValidationType");
        }
    }
}
