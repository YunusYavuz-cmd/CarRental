using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Data.Migrations
{
    public partial class Car : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarId = table.Column<int>(nullable: false),
                    CarBrand = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    CarColor = table.Column<string>(nullable: true),
                    CarLocation = table.Column<string>(nullable: true),
                    CarYear = table.Column<int>(nullable: false),
                    CarKm = table.Column<int>(nullable: false),
                    CarFuelTypes = table.Column<int>(nullable: false),
                    IsManual = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerEmail = table.Column<string>(nullable: true),
                    CustomerPhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProperties_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProperties_CustomerId",
                table: "CustomerProperties",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CustomerProperties");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
