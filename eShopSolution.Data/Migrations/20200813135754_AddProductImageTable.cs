using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class AddProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "order_date",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 13, 15, 34, 16, 634, DateTimeKind.Local).AddTicks(6631));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(nullable: false),
                    image_path = table.Column<string>(maxLength: 200, nullable: false),
                    caption = table.Column<string>(maxLength: 200, nullable: true),
                    is_default = table.Column<bool>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    sort_order = table.Column<int>(nullable: false),
                    file_size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_product_id",
                table: "ProductImages",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "order_date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 13, 15, 34, 16, 634, DateTimeKind.Local).AddTicks(6631),
                oldClrType: typeof(DateTime));

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
    }
}
