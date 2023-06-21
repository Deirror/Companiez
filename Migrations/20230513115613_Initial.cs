using Microsoft.EntityFrameworkCore.Migrations;

namespace CompaniesProjectz.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TickerSymbol = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MarketCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutTheCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionalInvestors",
                columns: table => new
                {
                    InvestorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionalInvestors", x => x.InvestorId);
                });

            migrationBuilder.CreateTable(
                name: "IndividualInvestors",
                columns: table => new
                {
                    InvestorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SharesInProcents = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTsCompany = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualInvestors", x => x.InvestorId);
                    table.ForeignKey(
                        name: "FK_IndividualInvestors_Companies_IdTsCompany",
                        column: x => x.IdTsCompany,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owners_Companies_CEO",
                        column: x => x.CEO,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    StatsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTsCompany = table.Column<int>(type: "int", nullable: false),
                    Alltimelows = table.Column<float>(type: "real", nullable: false),
                    Alltimehighs = table.Column<float>(type: "real", nullable: false),
                    BuyOrSell = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatsId);
                    table.ForeignKey(
                        name: "FK_Statistics_Companies_IdTsCompany",
                        column: x => x.IdTsCompany,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompaniesInstInvestors",
                columns: table => new
                {
                    IdTsCompany = table.Column<int>(type: "int", nullable: false),
                    IdInstinvestorName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesInstInvestors", x => new { x.IdTsCompany, x.IdInstinvestorName });
                    table.ForeignKey(
                        name: "FK_CompaniesInstInvestors_Companies_IdTsCompany",
                        column: x => x.IdTsCompany,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompaniesInstInvestors_InstitutionalInvestors_IdInstinvestorName",
                        column: x => x.IdInstinvestorName,
                        principalTable: "InstitutionalInvestors",
                        principalColumn: "InvestorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_TickerSymbol",
                table: "Companies",
                column: "TickerSymbol",
                unique: true,
                filter: "[TickerSymbol] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesInstInvestors_IdInstinvestorName",
                table: "CompaniesInstInvestors",
                column: "IdInstinvestorName");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualInvestors_IdTsCompany",
                table: "IndividualInvestors",
                column: "IdTsCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_CEO",
                table: "Owners",
                column: "CEO");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_IdTsCompany",
                table: "Statistics",
                column: "IdTsCompany");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompaniesInstInvestors");

            migrationBuilder.DropTable(
                name: "IndividualInvestors");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "InstitutionalInvestors");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
