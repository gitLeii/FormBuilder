using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Data.Migrations
{
    public partial class deleteddatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataSets_Elements_FormElementElementId",
                table: "DataSets");

            migrationBuilder.DropIndex(
                name: "IX_DataSets_FormElementElementId",
                table: "DataSets");

            migrationBuilder.DropColumn(
                name: "FormElementElementId",
                table: "DataSets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormElementElementId",
                table: "DataSets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_FormElementElementId",
                table: "DataSets",
                column: "FormElementElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataSets_Elements_FormElementElementId",
                table: "DataSets",
                column: "FormElementElementId",
                principalTable: "Elements",
                principalColumn: "ElementId");
        }
    }
}
