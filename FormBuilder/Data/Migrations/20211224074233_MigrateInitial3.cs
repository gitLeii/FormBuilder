using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Data.Migrations
{
    public partial class MigrateInitial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataSets",
                columns: table => new
                {
                    SubmittedDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementLabelData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElementValueData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormDataId = table.Column<int>(type: "int", nullable: false),
                    FormElementElementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSets", x => x.SubmittedDataId);
                    table.ForeignKey(
                        name: "FK_DataSets_Elements_FormElementElementId",
                        column: x => x.FormElementElementId,
                        principalTable: "Elements",
                        principalColumn: "ElementId");
                    table.ForeignKey(
                        name: "FK_DataSets_Forms_FormDataId",
                        column: x => x.FormDataId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_FormDataId",
                table: "DataSets",
                column: "FormDataId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_FormElementElementId",
                table: "DataSets",
                column: "FormElementElementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataSets");
        }
    }
}
