using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointOfSaleSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_EstablishmentProduct_fkEstablishmentProduct",
                table: "Order");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_EstablishmentProduct_fkEstablishmentProduct",
                table: "Order",
                column: "fkEstablishmentProduct",
                principalTable: "EstablishmentProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_EstablishmentProduct_fkEstablishmentProduct",
                table: "Order");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_EstablishmentProduct_fkEstablishmentProduct",
                table: "Order",
                column: "fkEstablishmentProduct",
                principalTable: "EstablishmentProduct",
                principalColumn: "Id");
        }
    }
}
