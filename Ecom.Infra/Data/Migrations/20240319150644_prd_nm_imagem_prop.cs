using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class prd_nm_imagem_prop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "prd_nm_imagem",
                table: "PRD_Produto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 1,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 2,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 3,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 4,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 5,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 6,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 7,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 8,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 9,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 10,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 11,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 12,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 13,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 14,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 15,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 16,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 17,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 18,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 19,
                column: "prd_nm_imagem",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRD_Produto",
                keyColumn: "id",
                keyValue: 20,
                column: "prd_nm_imagem",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prd_nm_imagem",
                table: "PRD_Produto");
        }
    }
}
