using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabWeb.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_DataBase_DatabaseId",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataBase",
                table: "DataBase");

            migrationBuilder.RenameTable(
                name: "DataBase",
                newName: "DataBases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataBases",
                table: "DataBases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_DataBases_DatabaseId",
                table: "Tables",
                column: "DatabaseId",
                principalTable: "DataBases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_DataBases_DatabaseId",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataBases",
                table: "DataBases");

            migrationBuilder.RenameTable(
                name: "DataBases",
                newName: "DataBase");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataBase",
                table: "DataBase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_DataBase_DatabaseId",
                table: "Tables",
                column: "DatabaseId",
                principalTable: "DataBase",
                principalColumn: "Id");
        }
    }
}
