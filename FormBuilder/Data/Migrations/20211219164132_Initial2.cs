using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormElements",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElementValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormElements", x => x.ElementId);
                    table.ForeignKey(
                        name: "FK_FormElements_Forms_FormDataId",
                        column: x => x.FormDataId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormElements_FormDataId",
                table: "FormElements",
                column: "FormDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormElements");
        }
    }
}
