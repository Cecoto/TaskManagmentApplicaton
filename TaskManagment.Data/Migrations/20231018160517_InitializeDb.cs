using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagment.Data.Migrations
{
    public partial class InitializeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Globaly unique identifier"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Title of the the task"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Information about the task"),
                    TaskTypeId = table.Column<int>(type: "int", nullable: false, comment: "Type of the task"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, comment: "Property for soft delete."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time user creted the task")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskTypes");
        }
    }
}
