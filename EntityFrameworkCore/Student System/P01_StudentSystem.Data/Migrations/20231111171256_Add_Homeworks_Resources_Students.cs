using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P01_StudentSystem.Data.Migrations
{
    public partial class Add_Homeworks_Resources_Students : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Student_StudentsStudentId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Homework_Courses_CourseId",
                table: "Homework");

            migrationBuilder.DropForeignKey(
                name: "FK_Homework_Student_StudentId",
                table: "Homework");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_Courses_CourseId",
                table: "Resource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resource",
                table: "Resource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Homework",
                table: "Homework");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Resource",
                newName: "Resources");

            migrationBuilder.RenameTable(
                name: "Homework",
                newName: "Homeworks");

            migrationBuilder.RenameIndex(
                name: "IX_Resource_CourseId",
                table: "Resources",
                newName: "IX_Resources_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Homework_StudentId",
                table: "Homeworks",
                newName: "IX_Homeworks_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Homework_CourseId",
                table: "Homeworks",
                newName: "IX_Homeworks_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resources",
                table: "Resources",
                column: "ResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Homeworks",
                table: "Homeworks",
                column: "HomeworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentsStudentId",
                table: "CourseStudent",
                column: "StudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Courses_CourseId",
                table: "Homeworks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Students_StudentId",
                table: "Homeworks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Courses_CourseId",
                table: "Resources",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentsStudentId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Courses_CourseId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Students_StudentId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Courses_CourseId",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resources",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Homeworks",
                table: "Homeworks");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Resources",
                newName: "Resource");

            migrationBuilder.RenameTable(
                name: "Homeworks",
                newName: "Homework");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_CourseId",
                table: "Resource",
                newName: "IX_Resource_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Homeworks_StudentId",
                table: "Homework",
                newName: "IX_Homework_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Homeworks_CourseId",
                table: "Homework",
                newName: "IX_Homework_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resource",
                table: "Resource",
                column: "ResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Homework",
                table: "Homework",
                column: "HomeworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Student_StudentsStudentId",
                table: "CourseStudent",
                column: "StudentsStudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homework_Courses_CourseId",
                table: "Homework",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homework_Student_StudentId",
                table: "Homework",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Courses_CourseId",
                table: "Resource",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
