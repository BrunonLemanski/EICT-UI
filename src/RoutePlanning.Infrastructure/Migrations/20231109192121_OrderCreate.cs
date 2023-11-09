using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoutePlanning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Package_OrderId",
                table: "Package",
                column: "OrderId");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    FromLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.UniqueConstraint("AK_Order_PackageId", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_Order_Location_FromLocationId",
                        column: x => x.FromLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Order_Location_ToLocationId",
                        column: x => x.ToLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_FromLocationId",
                table: "Order",
                column: "FromLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ToLocationId",
                table: "Order",
                column: "ToLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Order_OrderId",
                table: "Package",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_Order_OrderId",
                table: "Package");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Package_OrderId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Package");
        }
    }
}
