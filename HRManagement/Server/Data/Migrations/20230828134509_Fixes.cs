using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Provincie",
            //    table: "Provincie");

            //migrationBuilder.RenameTable(
            //    name: "Provincie",
            //    newName: "Provincia");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Provincia",
            //    table: "Provincia",
            //    column: "ProvinciaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Provincia",
            //    table: "Provincia");

            //migrationBuilder.RenameTable(
            //    name: "Provincia",
            //    newName: "Provincie");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Provincie",
            //    table: "Provincie",
            //    column: "ProvinciaId");
        }
    }
}
