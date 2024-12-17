using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointOfSaleSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class taxandgift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiftCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    currency = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fkCreatedByEmployee = table.Column<Guid>(type: "uuid", nullable: true),
                    fkModifiedByEmployee = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiftCard_Employee_fkCreatedByEmployee",
                        column: x => x.fkCreatedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiftCard_Employee_fkModifiedByEmployee",
                        column: x => x.fkModifiedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tax",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fkCreatedByEmployee = table.Column<Guid>(type: "uuid", nullable: true),
                    fkModifiedByEmployee = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tax_Employee_fkCreatedByEmployee",
                        column: x => x.fkCreatedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tax_Employee_fkModifiedByEmployee",
                        column: x => x.fkModifiedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiftCard_fkCreatedByEmployee",
                table: "GiftCard",
                column: "fkCreatedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_GiftCard_fkModifiedByEmployee",
                table: "GiftCard",
                column: "fkModifiedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Tax_fkCreatedByEmployee",
                table: "Tax",
                column: "fkCreatedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Tax_fkModifiedByEmployee",
                table: "Tax",
                column: "fkModifiedByEmployee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiftCard");

            migrationBuilder.DropTable(
                name: "Tax");
        }
    }
}
