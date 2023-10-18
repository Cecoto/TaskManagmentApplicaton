using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagment.Data.Migrations
{
    public partial class AddTaskTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Personal" },
                    { 2, "Professional" },
                    { 3, "Education & Learning" },
                    { 4, "Organization & Planning" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
