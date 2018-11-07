using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace t1708ENewWeb.Migrations
{
    public partial class AddCon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "StudentsRollNumber", "SubjectMark", "SubjectName", "SubjectRollNumber" },
                values: new object[,]
                {
                    { 1, null, 100, "php", "123" },
                    { 2, null, 100, "Asp.net", "123" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreateAt", "Email", "FirstName", "LastName", "Status", "UpdateAt" },
                values: new object[,]
                {
                    { "123", new DateTime(2018, 11, 6, 19, 1, 5, 353, DateTimeKind.Local), "binhaibin123@gmail.com", "hai", "hai", 1, new DateTime(2018, 11, 6, 19, 1, 5, 354, DateTimeKind.Local) },
                    { "124", new DateTime(2018, 11, 6, 19, 1, 5, 354, DateTimeKind.Local), "anhanh@gmail.com", "anh", "anh", 1, new DateTime(2018, 11, 6, 19, 1, 5, 354, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "RollNumber",
                keyValue: "123");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "RollNumber",
                keyValue: "124");
        }
    }
}
