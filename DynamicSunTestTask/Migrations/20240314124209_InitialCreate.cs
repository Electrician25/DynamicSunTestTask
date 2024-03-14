using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DynamicSunTestTask.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WheatherColumnsEntitis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<int>(type: "integer", nullable: false),
                    MoskowTime = table.Column<string>(type: "text", nullable: false),
                    Temperature = table.Column<double>(type: "double precision", nullable: false),
                    AirHumidity = table.Column<double>(type: "double precision", nullable: false),
                    DewPoint = table.Column<double>(type: "double precision", nullable: false),
                    Pressure = table.Column<int>(type: "integer", nullable: false),
                    DirectionOfTheWind = table.Column<string>(type: "text", nullable: true),
                    WindSpeed = table.Column<string>(type: "text", nullable: true),
                    Cloudy = table.Column<int>(type: "integer", nullable: false),
                    lowerCloudLimit = table.Column<int>(type: "integer", nullable: false),
                    HorizontalVisibility = table.Column<int>(type: "integer", nullable: false),
                    WeatherConditions = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheatherColumnsEntitis", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WheatherColumnsEntitis");
        }
    }
}
