using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyGuidance.Infrastructure.Migrations
{
    public partial class updateTestamonials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Testamonials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Testamonials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Testamonials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Testamonials",
                keyColumn: "Id",
                keyValue: 4,
                column: "JobId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Testamonials",
                keyColumn: "Id",
                keyValue: 5,
                column: "JobId",
                value: 5);

            migrationBuilder.InsertData(
                table: "Testamonials",
                columns: new[] { "Id", "Description", "JobId", "JobTitel", "Name" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", 1, "QA Enigneer consultant", "Luca Hendrickx" },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. As a QA Engineer, I've had the opportunity to work on challenging projects and collaborate with a talented team.", 2, "QA Engineer", "QA Engineer 1" },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Working as a Business Analyst, I've been involved in critical analysis and decision-making, contributing to the success of the organization.", 3, "Business Analyst", "Business Analyst 1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Testamonials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Testamonials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Testamonials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Testamonials",
                keyColumn: "Id",
                keyValue: 4,
                column: "JobId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Testamonials",
                keyColumn: "Id",
                keyValue: 5,
                column: "JobId",
                value: 3);
        }
    }
}
