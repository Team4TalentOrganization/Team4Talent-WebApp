using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyGuidance.Infrastructure.Migrations
{
    public partial class Recruiters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recruiters",
                columns: table => new
                {
                    RecruiterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruiters", x => x.RecruiterId);
                });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "RecruiterId", "Company", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "PXL", "noah.depauw@gmail.com", "Noah", "De Pauw" },
                    { 2, "Bewire", "federico.oliva@gmail.com", "Federico", "Oliva" },
                    { 3, "Team4Talent", "ruben.owsiamicki@gmail.com", "Ruben", "Owsiamicki" },
                    { 4, "Fenego", "mieszko.blazniak@gmail.com", "Mieszko", "Blazniak" },
                    { 5, "Cegeka", "max.valkenburg@gmail.com", "Max", "Valkenburg" },
                    { 6, "ACA", "noah.depauw@gmail.com", "Dries", "Cox" },
                    { 7, "ACA", "luca.hendrickx@gmail.com", "Luca", "Hendrickx" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recruiters");
        }
    }
}
