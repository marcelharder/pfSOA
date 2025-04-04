using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pfSOA.Migrations
{
    /// <inheritdoc />
    public partial class procedureId_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcedureId",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcedureId",
                table: "Photos");
        }
    }
}
