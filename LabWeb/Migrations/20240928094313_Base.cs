using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabWeb.Migrations
{
    /// <inheritdoc />
    public partial class Base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DatabaseId",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DataBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBase", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tables_DatabaseId",
                table: "Tables",
                column: "DatabaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_DataBase_DatabaseId",
                table: "Tables",
                column: "DatabaseId",
                principalTable: "DataBase",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_DataBase_DatabaseId",
                table: "Tables");

            migrationBuilder.DropTable(
                name: "DataBase");

            migrationBuilder.DropIndex(
                name: "IX_Tables_DatabaseId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "DatabaseId",
                table: "Tables");
        }
    }
}
