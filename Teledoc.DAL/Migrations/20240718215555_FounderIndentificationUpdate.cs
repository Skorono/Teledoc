using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Teledoc.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FounderIndentificationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientFounder_Founders_FoundersInn",
                table: "ClientFounder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Founders",
                table: "Founders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientFounder",
                table: "ClientFounder");

            migrationBuilder.DropIndex(
                name: "IX_ClientFounder_FoundersInn",
                table: "ClientFounder");

            migrationBuilder.DropColumn(
                name: "FoundersInn",
                table: "ClientFounder");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Founders",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "FoundersId",
                table: "ClientFounder",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Founders",
                table: "Founders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientFounder",
                table: "ClientFounder",
                columns: new[] { "ClientsId", "FoundersId" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFounder_FoundersId",
                table: "ClientFounder",
                column: "FoundersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFounder_Founders_FoundersId",
                table: "ClientFounder",
                column: "FoundersId",
                principalTable: "Founders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientFounder_Founders_FoundersId",
                table: "ClientFounder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Founders",
                table: "Founders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientFounder",
                table: "ClientFounder");

            migrationBuilder.DropIndex(
                name: "IX_ClientFounder_FoundersId",
                table: "ClientFounder");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Founders");

            migrationBuilder.DropColumn(
                name: "FoundersId",
                table: "ClientFounder");

            migrationBuilder.AddColumn<string>(
                name: "FoundersInn",
                table: "ClientFounder",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Founders",
                table: "Founders",
                column: "Inn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientFounder",
                table: "ClientFounder",
                columns: new[] { "ClientsId", "FoundersInn" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFounder_FoundersInn",
                table: "ClientFounder",
                column: "FoundersInn");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFounder_Founders_FoundersInn",
                table: "ClientFounder",
                column: "FoundersInn",
                principalTable: "Founders",
                principalColumn: "Inn",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
