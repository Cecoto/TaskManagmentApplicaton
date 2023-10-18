using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagment.Data.Migrations
{
    public partial class SetDefaultValuesForTaskProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tasks",
                type: "bit",
                nullable: true,
                defaultValue: true,
                comment: "Property for soft delete.",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldComment: "Property for soft delete.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time user creted the task",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time user creted the task");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tasks",
                type: "bit",
                nullable: true,
                comment: "Property for soft delete.",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true,
                oldComment: "Property for soft delete.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                comment: "Date and time user creted the task",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time user creted the task");
        }
    }
}
