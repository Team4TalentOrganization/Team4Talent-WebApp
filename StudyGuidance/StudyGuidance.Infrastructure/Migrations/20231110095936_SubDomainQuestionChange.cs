using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyGuidance.Infrastructure.Migrations
{
    public partial class SubDomainQuestionChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OptionRelation",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 8,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "AI Robotics", 1 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 9,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Machine Learning", 1 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 10,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Computer Vision", 1 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 11,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Fullstack", 2 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 12,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Frontend", 2 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 13,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Backend", 2 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 14,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Project Management", 3 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 15,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Software analysis", 3 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 16,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Automation", 4 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 17,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Security", 4 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 18,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Networking", 4 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 19,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Elektronica-ICT", 5 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 20,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Internet of Things", 5 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 21,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Elektromechanica", 5 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 22,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Analyst", 6 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 23,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "Data AI", 6 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 24,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "VR", 7 });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 25,
                columns: new[] { "Content", "OptionRelation" },
                values: new object[] { "AR", 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionRelation",
                table: "Options");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 8,
                column: "Content",
                value: "Backend");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 9,
                column: "Content",
                value: "AI Robotics");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 10,
                column: "Content",
                value: "Machine Learning");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 11,
                column: "Content",
                value: "Computer Vision");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 12,
                column: "Content",
                value: "Project Management");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 13,
                column: "Content",
                value: "Software analysis");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 14,
                column: "Content",
                value: "Automation");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 15,
                column: "Content",
                value: "Security");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 16,
                column: "Content",
                value: "Networking");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 17,
                column: "Content",
                value: "Elektronica-ICT");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 18,
                column: "Content",
                value: "Internet of Things");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 19,
                column: "Content",
                value: "Elektromechanica");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 20,
                column: "Content",
                value: "Analyst");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 21,
                column: "Content",
                value: "Data AI");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 22,
                column: "Content",
                value: "VR");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 23,
                column: "Content",
                value: "AR");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 24,
                column: "Content",
                value: "Fullstack");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 25,
                column: "Content",
                value: "Frontend");
        }
    }
}
