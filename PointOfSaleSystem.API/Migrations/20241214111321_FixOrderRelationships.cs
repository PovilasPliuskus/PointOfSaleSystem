using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointOfSaleSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fkCreatedByEmployee = table.Column<Guid>(type: "uuid", nullable: true),
                    fkModifiedByEmployee = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlcoholicBeverage = table.Column<bool>(type: "boolean", nullable: false),
                    fkCompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fkCreatedByEmployee = table.Column<Guid>(type: "uuid", nullable: true),
                    fkModifiedByEmployee = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProduct_Company_fkCompanyId",
                        column: x => x.fkCompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    fkCompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fkCreatedByEmployee = table.Column<Guid>(type: "uuid", nullable: true),
                    fkModifiedByEmployee = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyService_Company_fkCompanyId",
                        column: x => x.fkCompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Surname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Salary = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    fkEstablishmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginUsername = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LoginPasswordHashed = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fkCreatedByEmployee = table.Column<Guid>(type: "uuid", nullable: true),
                    fkModifiedByEmployee = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_fkCreatedByEmployee",
                        column: x => x.fkCreatedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Employee_fkModifiedByEmployee",
                        column: x => x.fkModifiedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Establishment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    fkCompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fkCreatedByEmployee = table.Column<Guid>(type: "uuid", nullable: true),
                    fkModifiedByEmployee = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Establishment_Company_fkCompanyId",
                        column: x => x.fkCompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Establishment_Employee_fkCreatedByEmployee",
                        column: x => x.fkCreatedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Establishment_Employee_fkModifiedByEmployee",
                        column: x => x.fkModifiedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FullOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tip = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fkCreatedByEmployee = table.Column<Guid>(type: "uuid", nullable: true),
                    fkModifiedByEmployee = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullOrder_Employee_fkCreatedByEmployee",
                        column: x => x.fkCreatedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FullOrder_Employee_fkModifiedByEmployee",
                        column: x => x.fkModifiedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EstablishmentProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    AmountInStock = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    fkEstablishmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fkCreatedByEmployee = table.Column<Guid>(type: "uuid", nullable: true),
                    fkModifiedByEmployee = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstablishmentProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstablishmentProduct_Employee_fkCreatedByEmployee",
                        column: x => x.fkCreatedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EstablishmentProduct_Employee_fkModifiedByEmployee",
                        column: x => x.fkModifiedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EstablishmentProduct_Establishment_fkEstablishmentId",
                        column: x => x.fkEstablishmentId,
                        principalTable: "Establishment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstablishmentService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    fkEstablishmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fkCreatedByEmployee = table.Column<Guid>(type: "uuid", nullable: true),
                    fkModifiedByEmployee = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstablishmentService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstablishmentService_Employee_fkCreatedByEmployee",
                        column: x => x.fkCreatedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EstablishmentService_Employee_fkModifiedByEmployee",
                        column: x => x.fkModifiedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EstablishmentService_Establishment_fkEstablishmentId",
                        column: x => x.fkEstablishmentId,
                        principalTable: "Establishment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    fkEstablishmentProduct = table.Column<Guid>(type: "uuid", nullable: true),
                    fkEstablishmentService = table.Column<Guid>(type: "uuid", nullable: true),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    fkFullOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fkCreatedByEmployee = table.Column<Guid>(type: "uuid", nullable: true),
                    fkModifiedByEmployee = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Employee_fkCreatedByEmployee",
                        column: x => x.fkCreatedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Employee_fkModifiedByEmployee",
                        column: x => x.fkModifiedByEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_EstablishmentProduct_fkEstablishmentProduct",
                        column: x => x.fkEstablishmentProduct,
                        principalTable: "EstablishmentProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_EstablishmentService_fkEstablishmentService",
                        column: x => x.fkEstablishmentService,
                        principalTable: "EstablishmentService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_FullOrder_fkFullOrderId",
                        column: x => x.fkFullOrderId,
                        principalTable: "FullOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_fkCreatedByEmployee",
                table: "Company",
                column: "fkCreatedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Company_fkModifiedByEmployee",
                table: "Company",
                column: "fkModifiedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProduct_fkCompanyId",
                table: "CompanyProduct",
                column: "fkCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProduct_fkCreatedByEmployee",
                table: "CompanyProduct",
                column: "fkCreatedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProduct_fkModifiedByEmployee",
                table: "CompanyProduct",
                column: "fkModifiedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyService_fkCompanyId",
                table: "CompanyService",
                column: "fkCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyService_fkCreatedByEmployee",
                table: "CompanyService",
                column: "fkCreatedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyService_fkModifiedByEmployee",
                table: "CompanyService",
                column: "fkModifiedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fkCreatedByEmployee",
                table: "Employee",
                column: "fkCreatedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fkEstablishmentId",
                table: "Employee",
                column: "fkEstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fkModifiedByEmployee",
                table: "Employee",
                column: "fkModifiedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Establishment_fkCompanyId",
                table: "Establishment",
                column: "fkCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Establishment_fkCreatedByEmployee",
                table: "Establishment",
                column: "fkCreatedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Establishment_fkModifiedByEmployee",
                table: "Establishment",
                column: "fkModifiedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_EstablishmentProduct_fkCreatedByEmployee",
                table: "EstablishmentProduct",
                column: "fkCreatedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_EstablishmentProduct_fkEstablishmentId",
                table: "EstablishmentProduct",
                column: "fkEstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EstablishmentProduct_fkModifiedByEmployee",
                table: "EstablishmentProduct",
                column: "fkModifiedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_EstablishmentService_fkCreatedByEmployee",
                table: "EstablishmentService",
                column: "fkCreatedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_EstablishmentService_fkEstablishmentId",
                table: "EstablishmentService",
                column: "fkEstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EstablishmentService_fkModifiedByEmployee",
                table: "EstablishmentService",
                column: "fkModifiedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_FullOrder_fkCreatedByEmployee",
                table: "FullOrder",
                column: "fkCreatedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_FullOrder_fkModifiedByEmployee",
                table: "FullOrder",
                column: "fkModifiedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Order_fkCreatedByEmployee",
                table: "Order",
                column: "fkCreatedByEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Order_fkEstablishmentProduct",
                table: "Order",
                column: "fkEstablishmentProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Order_fkEstablishmentService",
                table: "Order",
                column: "fkEstablishmentService");

            migrationBuilder.CreateIndex(
                name: "IX_Order_fkFullOrderId",
                table: "Order",
                column: "fkFullOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_fkModifiedByEmployee",
                table: "Order",
                column: "fkModifiedByEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Employee_fkCreatedByEmployee",
                table: "Company",
                column: "fkCreatedByEmployee",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Employee_fkModifiedByEmployee",
                table: "Company",
                column: "fkModifiedByEmployee",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProduct_Employee_fkCreatedByEmployee",
                table: "CompanyProduct",
                column: "fkCreatedByEmployee",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProduct_Employee_fkModifiedByEmployee",
                table: "CompanyProduct",
                column: "fkModifiedByEmployee",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyService_Employee_fkCreatedByEmployee",
                table: "CompanyService",
                column: "fkCreatedByEmployee",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyService_Employee_fkModifiedByEmployee",
                table: "CompanyService",
                column: "fkModifiedByEmployee",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Establishment_fkEstablishmentId",
                table: "Employee",
                column: "fkEstablishmentId",
                principalTable: "Establishment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Employee_fkCreatedByEmployee",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Employee_fkModifiedByEmployee",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Establishment_Employee_fkCreatedByEmployee",
                table: "Establishment");

            migrationBuilder.DropForeignKey(
                name: "FK_Establishment_Employee_fkModifiedByEmployee",
                table: "Establishment");

            migrationBuilder.DropTable(
                name: "CompanyProduct");

            migrationBuilder.DropTable(
                name: "CompanyService");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "EstablishmentProduct");

            migrationBuilder.DropTable(
                name: "EstablishmentService");

            migrationBuilder.DropTable(
                name: "FullOrder");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Establishment");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
