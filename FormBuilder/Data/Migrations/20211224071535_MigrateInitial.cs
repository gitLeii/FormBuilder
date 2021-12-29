using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Data.Migrations
{
    public partial class MigrateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Forms_FormDataId",
                table: "Datas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Datas",
                table: "Datas");

            migrationBuilder.RenameTable(
                name: "Datas",
                newName: "DataSets");

            migrationBuilder.RenameIndex(
                name: "IX_Datas_FormDataId",
                table: "DataSets",
                newName: "IX_DataSets_FormDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataSets",
                table: "DataSets",
                column: "FormSubmittedDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataSets_Forms_FormDataId",
                table: "DataSets",
                column: "FormDataId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataSets_Forms_FormDataId",
                table: "DataSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataSets",
                table: "DataSets");

            migrationBuilder.RenameTable(
                name: "DataSets",
                newName: "Datas");

            migrationBuilder.RenameIndex(
                name: "IX_DataSets_FormDataId",
                table: "Datas",
                newName: "IX_Datas_FormDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Datas",
                table: "Datas",
                column: "FormSubmittedDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Forms_FormDataId",
                table: "Datas",
                column: "FormDataId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
