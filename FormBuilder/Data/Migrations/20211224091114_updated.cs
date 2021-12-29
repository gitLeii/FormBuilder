using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Data.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataSets_Forms_FormDataId",
                table: "DataSets");

            migrationBuilder.DropIndex(
                name: "IX_DataSets_FormDataId",
                table: "DataSets");

            migrationBuilder.RenameColumn(
                name: "FormDataId",
                table: "DataSets",
                newName: "FormElementId");

            migrationBuilder.AddColumn<int>(
                name: "SubmittedDataId",
                table: "Elements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elements_SubmittedDataId",
                table: "Elements",
                column: "SubmittedDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_DataSets_SubmittedDataId",
                table: "Elements",
                column: "SubmittedDataId",
                principalTable: "DataSets",
                principalColumn: "SubmittedDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_DataSets_SubmittedDataId",
                table: "Elements");

            migrationBuilder.DropIndex(
                name: "IX_Elements_SubmittedDataId",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "SubmittedDataId",
                table: "Elements");

            migrationBuilder.RenameColumn(
                name: "FormElementId",
                table: "DataSets",
                newName: "FormDataId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_FormDataId",
                table: "DataSets",
                column: "FormDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataSets_Forms_FormDataId",
                table: "DataSets",
                column: "FormDataId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
