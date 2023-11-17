using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cbc3ca8-d5a1-4a3e-88b0-b335fa3b2a7a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7331402c-22f8-43fe-bff3-607952cd8c7a");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "75c515b1-00cf-4101-aa43-038fd1b0dc26", null, "Admin", "admin" },
                    { "fdf90c33-2086-4967-85ab-d2e836204306", null, "Student", "student" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Departments",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "Description", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b0"), "75a6ff65-8b01-4981-9ca6-c550919d62b1", new DateTime(2023, 11, 16, 16, 10, 18, 211, DateTimeKind.Local).AddTicks(8415), null, "Description", null, "CS" },
                    { new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b2"), "75a6ff65-8b01-4981-9ca6-c550919d62b1", new DateTime(2023, 11, 16, 16, 10, 18, 211, DateTimeKind.Local).AddTicks(8492), null, "Description", null, "IT" },
                    { new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b3"), "75a6ff65-8b01-4981-9ca6-c550919d62b1", new DateTime(2023, 11, 16, 16, 10, 18, 211, DateTimeKind.Local).AddTicks(8521), null, "Description", null, "IS" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Students",
                columns: new[] { "Id", "Age", "CreatedBy", "DateCreated", "DateModified", "DepartmentId", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b4"), 19, "75a6ff65-8b01-4981-9ca6-c550919d62b1", new DateTime(2023, 11, 16, 16, 10, 18, 213, DateTimeKind.Local).AddTicks(3567), null, new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b0"), null, "محمد احمد موسى" },
                    { new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b5"), 0, "75a6ff65-8b01-4981-9ca6-c550919d62b1", new DateTime(2023, 11, 16, 16, 10, 18, 213, DateTimeKind.Local).AddTicks(3631), null, new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b0"), null, "صلاح محمود على" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b2"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b3"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b4"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b5"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b0"));

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cbc3ca8-d5a1-4a3e-88b0-b335fa3b2a7a", null, "Student", "student" },
                    { "7331402c-22f8-43fe-bff3-607952cd8c7a", null, "Admin", "admin" }
                });
        }
    }
}
