using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class UpdateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "seo_alias",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "order_date",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 13, 15, 34, 16, 634, DateTimeKind.Local).AddTicks(6631),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 13, 14, 15, 21, 595, DateTimeKind.Local).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "bc461b49-baea-42d8-b2a4-a8de94223fbe");

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
                value: new DateTime(2020, 8, 13, 15, 34, 16, 653, DateTimeKind.Local).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2dfd67a7-4939-40c8-bbd4-8bedded8746f", "AQAAAAEAACcQAAAAEBwq4YuR1r1wq2kH3xf5SeGOLkAqMi2VnQZvmDjgAlQgoppR3AaACL58YH4edr0meg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "seo_alias",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "order_date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 13, 14, 15, 21, 595, DateTimeKind.Local).AddTicks(8727),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 13, 15, 34, 16, 634, DateTimeKind.Local).AddTicks(6631));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c517b792-78cf-486b-8fd8-d15852e5657a");

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
                value: new DateTime(2020, 8, 13, 14, 15, 21, 614, DateTimeKind.Local).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63522f1d-c6d5-446e-a3d9-42f764dedcf4", "AQAAAAEAACcQAAAAECrvqWutrB7CZS0OuCqMS7Z7IlI5NZiJMV7UL47JI89S+UUDqHTY4D0nRKnsAmtn7g==" });
        }
    }
}
