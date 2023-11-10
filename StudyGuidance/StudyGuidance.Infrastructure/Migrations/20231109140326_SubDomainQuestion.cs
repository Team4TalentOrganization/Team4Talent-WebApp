using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyGuidance.Infrastructure.Migrations
{
    public partial class SubDomainQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 3,
                column: "Content",
                value: "Software Management");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 5,
                column: "Content",
                value: "Elektronica");

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "Content", "IsChecked", "QuestionId" },
                values: new object[,]
                {
                    { 6, "Data", false, 1 },
                    { 7, "VR & AR", false, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "Phrase",
                value: "In welk domein heb je interesse?");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "Phrase" },
                values: new object[] { 2, "In welk subdomein heb je interesse?" });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "Content", "IsChecked", "QuestionId" },
                values: new object[,]
                {
                    { 8, "Backend", false, 2 },
                    { 9, "AI Robotics", false, 2 },
                    { 10, "Machine Learning", false, 2 },
                    { 11, "Computer Vision", false, 2 },
                    { 12, "Project Management", false, 2 },
                    { 13, "Software analysis", false, 2 },
                    { 14, "Automation", false, 2 },
                    { 15, "Security", false, 2 },
                    { 16, "Networking", false, 2 },
                    { 17, "Elektronica-ICT", false, 2 },
                    { 18, "Internet of Things", false, 2 },
                    { 19, "Elektromechanica", false, 2 },
                    { 20, "Analyst", false, 2 },
                    { 21, "Data AI", false, 2 },
                    { 22, "VR", false, 2 },
                    { 23, "AR", false, 2 },
                    { 24, "Fullstack", false, 2 },
                    { 25, "Frontend", false, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 3,
                column: "Content",
                value: "Software Engineering");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 5,
                column: "Content",
                value: "Data");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "Phrase",
                value: "In welk domein interesseer je je?");
        }
    }
}
