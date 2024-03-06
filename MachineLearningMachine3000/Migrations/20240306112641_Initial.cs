using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineLearningMachine3000.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DP_FC_156");

            migrationBuilder.CreateTable(
                name: "Fact_Cases",
                schema: "DP_FC_156",
                columns: table => new
                {
                    DateId = table.Column<int>(type: "int", nullable: false),
                    ServiceID_ID = table.Column<int>(type: "int", nullable: false),
                    Summe_von_Eingang_Neu = table.Column<int>(type: "int", nullable: false),
                    Summe_von_Eingang_Aktiv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Fact_Cases_Forecast",
                schema: "DP_FC_156",
                columns: table => new
                {
                    DateId = table.Column<int>(type: "int", nullable: false),
                    Summe_von_Eingang_Neu_Forecast = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fact_Cases",
                schema: "DP_FC_156");

            migrationBuilder.DropTable(
                name: "Fact_Cases_Forecast",
                schema: "DP_FC_156");
        }
    }
}
