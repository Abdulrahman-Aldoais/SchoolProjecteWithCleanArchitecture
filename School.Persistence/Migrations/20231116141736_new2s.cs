using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class new2s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75c515b1-00cf-4101-aa43-038fd1b0dc26");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdf90c33-2086-4967-85ab-d2e836204306");

            migrationBuilder.AddColumn<bool>(
                name: "RememberMe",
                schema: "Identity",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f9567dc-b564-4182-8c5e-4848bee0c1e6", null, "Admin", "admin" },
                    { "70e48ffa-1dc2-4fdf-87ad-2a6e73dfab9e", null, "Student", "student" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b0"),
                column: "DateCreated",
                value: new DateTime(2023, 11, 16, 17, 17, 36, 444, DateTimeKind.Local).AddTicks(9874));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b2"),
                column: "DateCreated",
                value: new DateTime(2023, 11, 16, 17, 17, 36, 444, DateTimeKind.Local).AddTicks(9910));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b3"),
                column: "DateCreated",
                value: new DateTime(2023, 11, 16, 17, 17, 36, 444, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b4"),
                column: "DateCreated",
                value: new DateTime(2023, 11, 16, 17, 17, 36, 445, DateTimeKind.Local).AddTicks(8203));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b5"),
                column: "DateCreated",
                value: new DateTime(2023, 11, 16, 17, 17, 36, 445, DateTimeKind.Local).AddTicks(8236));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f9567dc-b564-4182-8c5e-4848bee0c1e6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70e48ffa-1dc2-4fdf-87ad-2a6e73dfab9e");

            migrationBuilder.DropColumn(
                name: "RememberMe",
                schema: "Identity",
                table: "User");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "75c515b1-00cf-4101-aa43-038fd1b0dc26", null, "Admin", "admin" },
                    { "fdf90c33-2086-4967-85ab-d2e836204306", null, "Student", "student" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b0"),
                column: "DateCreated",
                value: new DateTime(2023, 11, 16, 16, 10, 18, 211, DateTimeKind.Local).AddTicks(8415));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b2"),
                column: "DateCreated",
                value: new DateTime(2023, 11, 16, 16, 10, 18, 211, DateTimeKind.Local).AddTicks(8492));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b3"),
                column: "DateCreated",
                value: new DateTime(2023, 11, 16, 16, 10, 18, 211, DateTimeKind.Local).AddTicks(8521));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b4"),
                column: "DateCreated",
                value: new DateTime(2023, 11, 16, 16, 10, 18, 213, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b5"),
                column: "DateCreated",
                value: new DateTime(2023, 11, 16, 16, 10, 18, 213, DateTimeKind.Local).AddTicks(3631));
        }
    }
}
