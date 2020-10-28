using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace PremiumChannelSubscription.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(nullable: true),
                    CustomerCare = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "PremiumServices",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(nullable: true),
                    StartingPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premium", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSubscriptions",
                columns: table => new
                {
                    CustomerSubscriptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceID = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    Amount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSubscriptions", x => x.CustomerSubscriptionID);
                    table.ForeignKey(
                        name: "FK_PremiumServices_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "PremiumServices",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSubscriptions_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSubscriptions_ServiceID",
                table: "CustomerSubscriptions",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSubscriptions_CustomerID",
                table: "CustomerSubscriptions",
                column: "CustomerID");

            var sqlFile = Path.Combine(".\\Scripts", @"datascripts.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "CustomerSubscriptions");

            migrationBuilder.DropTable(
                name: "PremiumServices");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
