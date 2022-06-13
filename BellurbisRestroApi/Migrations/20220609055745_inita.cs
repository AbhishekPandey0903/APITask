using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BellurbisRestroApi.Migrations
{
    public partial class inita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkRAP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestroId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkRAP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayersTab",
                columns: table => new
                {
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerDOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerPrimaryAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerAlternateAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerOfficeAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerMobNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerDL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerPassport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerPostal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersTab", x => x.PlayersId);
                });

            migrationBuilder.CreateTable(
                name: "Restrotab",
                columns: table => new
                {
                    RestroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestroName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestroAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestroContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestroTiming = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restrotab", x => x.RestroId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkRAP");

            migrationBuilder.DropTable(
                name: "PlayersTab");

            migrationBuilder.DropTable(
                name: "Restrotab");
        }
    }
}
