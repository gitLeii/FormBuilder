using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Data.Migrations
{
    public partial class MigrateInitial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataSets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataSets",
                columns: table => new
                {
                    FormSubmittedDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormDataId = table.Column<int>(type: "int", nullable: false),
                    ElementLabelData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElementValueData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSets", x => x.FormSubmittedDataId);
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
        }
    }
}
