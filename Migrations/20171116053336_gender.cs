using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NewApplication.Migrations
{
    public partial class gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GenderId",
                schema: "MST",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "MST",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gender",
                schema: "MST",
                columns: table => new
                {
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GenderId",
                schema: "MST",
                table: "Employee",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Gender_GenderId",
                schema: "MST",
                table: "Employee",
                column: "GenderId",
                principalSchema: "MST",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Gender_GenderId",
                schema: "MST",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "MST");

            migrationBuilder.DropIndex(
                name: "IX_Employee_GenderId",
                schema: "MST",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "GenderId",
                schema: "MST",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "MST",
                table: "Employee");
        }
    }
}
