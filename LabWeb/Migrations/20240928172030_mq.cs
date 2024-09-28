using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabWeb.Migrations
{
    /// <inheritdoc />
    public partial class mq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Tables_TableId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_Rows_Tables_TableId",
                table: "Rows");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Tables_TableId",
                table: "Fields",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rows_Tables_TableId",
                table: "Rows",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Tables_TableId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_Rows_Tables_TableId",
                table: "Rows");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Tables_TableId",
                table: "Fields",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rows_Tables_TableId",
                table: "Rows",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id");
        }
    }
}
