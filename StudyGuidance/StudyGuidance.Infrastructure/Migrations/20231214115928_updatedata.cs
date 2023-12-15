using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyGuidance.Infrastructure.Migrations
{
    public partial class updatedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                column: "StudyCourseRelation",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                column: "StudyCourseRelation",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 4,
                column: "StudyCourseRelation",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 5,
                column: "StudyCourseRelation",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 6,
                column: "StudyCourseRelation",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 7,
                column: "StudyCourseRelation",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 8,
                column: "StudyCourseRelation",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 9,
                column: "StudyCourseRelation",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 10,
                column: "StudyCourseRelation",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 11,
                column: "StudyCourseRelation",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 12,
                column: "StudyCourseRelation",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 13,
                column: "StudyCourseRelation",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 14,
                column: "StudyCourseRelation",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 15,
                column: "StudyCourseRelation",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 16,
                column: "StudyCourseRelation",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 18,
                column: "StudyCourseRelation",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 19,
                column: "StudyCourseRelation",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 20,
                column: "StudyCourseRelation",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 21,
                column: "StudyCourseRelation",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 22,
                column: "StudyCourseRelation",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 23,
                column: "StudyCourseRelation",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 24,
                column: "StudyCourseRelation",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 25,
                column: "StudyCourseRelation",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 26,
                column: "StudyCourseRelation",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 27,
                column: "StudyCourseRelation",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 28,
                column: "StudyCourseRelation",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 29,
                column: "StudyCourseRelation",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 30,
                column: "StudyCourseRelation",
                value: 14);

            migrationBuilder.UpdateData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "JobRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "JobRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "JobRelation",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "JobRelation", "School" },
                values: new object[] { 1, "KU Leuven" });

            migrationBuilder.InsertData(
                table: "StudyCourses",
                columns: new[] { "Id", "DiplomaType", "JobRelation", "Location", "School", "Study" },
                values: new object[,]
                {
                    { 5, 1, 2, 1, "KU Leuven", "Biomedische Wetenschappen" },
                    { 6, 2, 3, 2, "VUB", "Master in Business Administration" },
                    { 7, 0, 3, 3, "Artesis Plantijn Hogeschool", "Marketing Management" },
                    { 8, 1, 4, 4, "UGent", "Communication Sciences" },
                    { 9, 2, 4, 5, "Howest", "Master in Environmental Sciences" },
                    { 10, 1, 4, 6, "Université de Liège", "Computer Science" },
                    { 11, 2, 5, 7, "Université de Namur", "Master in Physics" },
                    { 12, 0, 5, 8, "Haute École Louvain en Hainaut", "Multimedia Production" },
                    { 13, 1, 6, 9, "Université de Mons", "Industrial Engineering" },
                    { 14, 2, 7, 10, "Hogeschool Odisee", "Master in Artificial Intelligence" }
                });

            migrationBuilder.InsertData(
                table: "StudyCourses",
                columns: new[] { "Id", "DiplomaType", "JobRelation", "Location", "School", "Study" },
                values: new object[,]
                {
                    { 15, 0, 8, 11, "C-Mine Crib", "Digital Marketing" },
                    { 16, 1, 9, 12, "Howest", "Product Design" },
                    { 17, 2, 9, 13, "VIVES University College", "Master in Marine Biology" },
                    { 18, 0, 9, 14, "HoGent", "Web Development" },
                    { 19, 1, 9, 15, "Thomas More", "International Business" },
                    { 20, 2, 9, 16, "Haute École de la Province de Hainaut Condorcet", "Master in Environmental Engineering" },
                    { 21, 1, 10, 17, "Hogeschool Gent", "Applied Mathematics" },
                    { 22, 2, 10, 18, "Howest", "Master in Industrial Design" },
                    { 23, 1, 11, 19, "Haute École de la Province de Liège", "Electrical Engineering" },
                    { 24, 0, 12, 20, "Thomas More", "Graphic Design" },
                    { 25, 1, 12, 21, "HEPH-Condorcet", "Industrial Automation" },
                    { 26, 2, 12, 22, "Université catholique de Louvain", "Master in Civil Engineering" },
                    { 27, 1, 13, 23, "Hogeschool VIVES", "Tourism and Leisure Management" },
                    { 28, 2, 14, 24, "Vrije Universiteit Brussel", "Master in Neuroscience" },
                    { 29, 1, 14, 25, "Erasmushogeschool Brussel", "Culinary Arts" },
                    { 30, 2, 15, 26, "Hogeschool PXL", "Master in Archaeology" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 30);

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

            migrationBuilder.UpdateData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "JobRelation",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "JobRelation",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "JobRelation",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudyCourses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "JobRelation", "School" },
                values: new object[] { 0, "Leuven" });
        }
    }
}
