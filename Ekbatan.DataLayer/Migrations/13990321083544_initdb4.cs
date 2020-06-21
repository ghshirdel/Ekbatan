using Microsoft.EntityFrameworkCore.Migrations;

namespace Ekbatan.DataLayer.Migrations
{
    public partial class initdb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contract_ID",
                table: "Melks",
                newName: "MContractContract_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Melks_MContractContract_ID",
                table: "Melks",
                column: "MContractContract_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Melks_MContracts_MContractContract_ID",
                table: "Melks",
                column: "MContractContract_ID",
                principalTable: "MContracts",
                principalColumn: "Contract_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Melks_MContracts_MContractContract_ID",
                table: "Melks");

            migrationBuilder.DropIndex(
                name: "IX_Melks_MContractContract_ID",
                table: "Melks");

            migrationBuilder.RenameColumn(
                name: "MContractContract_ID",
                table: "Melks",
                newName: "Contract_ID");
        }
    }
}
