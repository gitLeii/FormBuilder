using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Data.Migrations
{
    public partial class migrationa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Datas",
                columns: table => new
                {
                    FormSubmittedDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementLabelData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElementValueData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.FormSubmittedDataId);
                    table.ForeignKey(
                        name: "FK_Datas_Forms_FormDataId",
                        column: x => x.FormDataId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Datas_FormDataId",
                table: "Datas",
                column: "FormDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datas");
        }
    }
}
