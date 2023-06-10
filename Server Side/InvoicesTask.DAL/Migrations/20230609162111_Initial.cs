using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoicesTask.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceHDRs",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    InvocieDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<bool>(type: "bit", nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHDRs", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "ItemsDTLs",
                columns: table => new
                {
                    ItemCode = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(14,3)", precision: 14, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsDTLs", x => new { x.InvoiceId, x.ItemCode });
                    table.ForeignKey(
                        name: "FK_ItemsDTLs_InvoiceHDRs_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceHDRs",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsDTLs");

            migrationBuilder.DropTable(
                name: "InvoiceHDRs");
        }
    }
}
