using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoutePlanning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Connection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Distance_Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connection_Location_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Connection_Location_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PackageTypePackage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PackageTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageTypePackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageTypePackage_PackageType_PackageTypeId",
                        column: x => x.PackageTypeId,
                        principalTable: "PackageType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PackageTypePackage_PackageType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PackageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageTypePackage_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageTypePackage_Package_PackageId1",
                        column: x => x.PackageId1,
                        principalTable: "Package",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connection_DestinationId",
                table: "Connection",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_SourceId",
                table: "Connection",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageTypePackage_PackageId",
                table: "PackageTypePackage",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageTypePackage_PackageId1",
                table: "PackageTypePackage",
                column: "PackageId1");

            migrationBuilder.CreateIndex(
                name: "IX_PackageTypePackage_PackageTypeId",
                table: "PackageTypePackage",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageTypePackage_TypeId",
                table: "PackageTypePackage",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connection");

            migrationBuilder.DropTable(
                name: "PackageTypePackage");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "PackageType");

            migrationBuilder.DropTable(
                name: "Package");
        }
    }
}
