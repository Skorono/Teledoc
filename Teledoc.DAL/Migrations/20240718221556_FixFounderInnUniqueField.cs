using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teledoc.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixFounderInnUniqueField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Founders_Inn",
                table: "Founders",
                column: "Inn",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Founders_Inn",
                table: "Founders");
        }
    }
}
