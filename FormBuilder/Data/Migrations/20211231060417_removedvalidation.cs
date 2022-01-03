using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Data.Migrations
{
    public partial class removedvalidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_Validations_FormValidationId",
                table: "Elements");

            migrationBuilder.DropTable(
                name: "Validations");

            migrationBuilder.DropIndex(
                name: "IX_Elements_FormValidationId",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "FormValidationId",
                table: "Elements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormValidationId",
                table: "Elements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Validations",
                columns: table => new
                {
                    FormValidationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementId = table.Column<int>(type: "int", nullable: false),
                    ElementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidationType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validations", x => x.FormValidationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elements_FormValidationId",
                table: "Elements",
                column: "FormValidationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_Validations_FormValidationId",
                table: "Elements",
                column: "FormValidationId",
                principalTable: "Validations",
                principalColumn: "FormValidationId");
        }
    }
}
