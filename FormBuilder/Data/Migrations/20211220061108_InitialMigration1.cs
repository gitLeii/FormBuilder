using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Data.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FormElements",
                table: "FormElements");

            migrationBuilder.RenameTable(
                name: "FormElements",
                newName: "Elements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elements",
                table: "Elements",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_FormDataId",
                table: "Elements",
                column: "FormDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_Forms_FormDataId",
                table: "Elements",
                column: "FormDataId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_Forms_FormDataId",
                table: "Elements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Elements",
                table: "Elements");

            migrationBuilder.DropIndex(
                name: "IX_Elements_FormDataId",
                table: "Elements");

            migrationBuilder.RenameTable(
                name: "Elements",
                newName: "FormElements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormElements",
                table: "FormElements",
                column: "ElementId");
        }
    }
}
