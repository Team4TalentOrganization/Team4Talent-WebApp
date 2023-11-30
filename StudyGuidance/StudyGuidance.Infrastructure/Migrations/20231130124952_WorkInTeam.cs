using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyGuidance.Infrastructure.Migrations
{
    public partial class WorkInTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "Content", "IsChecked", "OptionRelation", "QuestionId" },
                values: new object[,]
                {
                    { 26, "Ja", false, 0, 3 },
                    { 27, "Nee", false, 0, 3 },
                    { 28, "Ja", false, 0, 4 },
                    { 29, "Nee", false, 0, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 29);
        }
    }
}
