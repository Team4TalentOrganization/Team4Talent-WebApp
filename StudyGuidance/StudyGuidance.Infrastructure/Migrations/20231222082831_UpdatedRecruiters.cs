using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyGuidance.Infrastructure.Migrations
{
    public partial class UpdatedRecruiters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 7);

            migrationBuilder.AddColumn<string>(
                name: "_company",
                table: "Recruiters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_email",
                table: "Recruiters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_firstName",
                table: "Recruiters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_lastName",
                table: "Recruiters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "RecruiterId", "Company", "Email", "FirstName", "LastName", "_company", "_email", "_firstName", "_lastName" },
                values: new object[,]
                {
                    { 1, "PXL", "noah.depauw@gmail.com", "Noah", "De Pauw", "PXL", "noah.depauw@gmail.com", "Noah", "De Pauw" },
                    { 2, "Bewire", "federico.oliva@gmail.com", "Federico", "Oliva", "Bewire", "federico.oliva@gmail.com", "Federico", "Oliva" },
                    { 3, "Team4Talent", "ruben.owsiamicki@gmail.com", "Ruben", "Owsiamicki", "Team4Talent", "ruben.owsiamicki@gmail.com", "Ruben", "Owsiamicki" },
                    { 4, "Fenego", "mieszko.blazniak@gmail.com", "Mieszko", "Blazniak", "Fenego", "mieszko.blazniak@gmail.com", "Mieszko", "Blazniak" },
                    { 5, "Cegeka", "max.valkenburg@gmail.com", "Max", "Valkenburg", "Cegeka", "max.valkenburg@gmail.com", "Max", "Valkenburg" },
                    { 6, "ACA", "noah.depauw@gmail.com", "Dries", "Cox", "ACA", "noah.depauw@gmail.com", "Dries", "Cox" },
                    { 7, "ACA", "luca.hendrickx@gmail.com", "Luca", "Hendrickx", "ACA", "luca.hendrickx@gmail.com", "Luca", "Hendrickx" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "RecruiterId",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "_company",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "_email",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "_firstName",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "_lastName",
                table: "Recruiters");

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
    }
}
