using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "file_size",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "389c5dc7-342c-4c76-86d3-c5c0bfa4c177");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 1,
                column: "status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 2,
                column: "status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1,
                column: "date_created",
                value: new DateTime(2020, 8, 13, 21, 57, 35, 471, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5a40f45f-1614-40a7-aa8c-48be2a0b59a7", "AQAAAAEAACcQAAAAEEWRDs93HRjsAZXaZlWoLYK3TaQJHkCIYdXXieBZrWZRHVckyKrTzu4Iq8HABLOhCg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "file_size",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "99a03eb0-cc2d-47a7-9248-1e1276813fb8");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 1,
                column: "status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 2,
                column: "status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1,
                column: "date_created",
                value: new DateTime(2020, 8, 13, 20, 57, 53, 798, DateTimeKind.Local).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4aca6ee-7bd5-492e-937f-fce8e233668e", "AQAAAAEAACcQAAAAEP/aF6kkop+kefzmcSTfQ238WUud03q6rtm/LtxjyxublNv4hzDake8gJCqismqjOA==" });
        }
    }
}
