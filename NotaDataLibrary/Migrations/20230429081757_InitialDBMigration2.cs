using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotaDataLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "header",
                table: "Notes",
                newName: "subject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "subject",
                table: "Notes",
                newName: "header");
        }
    }
}
