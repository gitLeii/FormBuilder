using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Data.Migrations
{
    public partial class RemoveColumnDataset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_DataSets_SubmittedDataId",
                table: "Elements");

            migrationBuilder.DropTable(
                name: "DataSets");

            migrationBuilder.DropIndex(
                name: "IX_Elements_SubmittedDataId",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "SubmittedDataId",
                table: "Elements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubmittedDataId",
                table: "Elements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DataSets",
                columns: table => new
                {
                    SubmittedDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementLabelData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElementValueData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormElementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSets", x => x.SubmittedDataId);
                });

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
    }
}
