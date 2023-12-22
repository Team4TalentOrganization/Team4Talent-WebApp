using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyGuidance.Infrastructure.Migrations
{
    public partial class updatejobsstudycourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyCourseRelation",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudyCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Study = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiplomaType = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    JobRelation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyCourses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 4,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 5,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 6,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 7,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 8,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 9,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 10,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 11,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 12,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 13,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 14,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 15,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 16,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 17,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 18,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 19,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 20,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 21,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 22,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 23,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 24,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 25,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 26,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 27,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 28,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 29,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 30,
                column: "StudyCourseRelation",
                value: 1);

            migrationBuilder.InsertData(
                table: "StudyCourses",
                columns: new[] { "Id", "DiplomaType", "JobRelation", "Location", "School", "Study" },
                values: new object[,]
                {
                    { 1, 0, 0, 0, "Syntra", "Switch2It" },
                    { 2, 0, 0, 0, "Hogeschool PXL", "Toegpaste Informatica" },
                    { 3, 1, 0, 0, "Hogeschool PXL", "Elektronica-ICT" },
                    { 4, 2, 0, 1, "Leuven", "Master: Toegepaste Informatica" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyCourses");

            migrationBuilder.DropColumn(
                name: "StudyCourseRelation",
                table: "Jobs");
        }
    }
}
