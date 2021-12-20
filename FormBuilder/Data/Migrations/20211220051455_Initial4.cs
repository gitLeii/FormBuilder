using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Data.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormElements_Forms_FormDataId",
                table: "FormElements");

            migrationBuilder.DropIndex(
                name: "IX_FormElements_FormDataId",
                table: "FormElements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FormElements_FormDataId",
                table: "FormElements",
                column: "FormDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormElements_Forms_FormDataId",
                table: "FormElements",
                column: "FormDataId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
