using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23f96e4b-6209-40f9-af38-9709d3b7316b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b514772f-310b-4ae3-9d26-9843be578fce"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ee58970c-f1dc-4c3c-a563-bae2b5481488"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("0baf8911-4c0c-4120-bed6-03314880ee4c"), "2a14db8d-8c52-4b82-9771-f983ac9eeebb", "representative", "REPRESENTATIVE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("26572b2f-7aec-4ad4-894e-214e2b51736f"), "68ecd5ed-885e-4f3e-9d1e-e305a3f3920a", "benefactor", "BENEFACTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("32d4865f-f5ec-419a-8cdc-9905fcd765fc"), "37aae2ed-f039-442d-b5e9-7c1f407b1b07", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0baf8911-4c0c-4120-bed6-03314880ee4c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("26572b2f-7aec-4ad4-894e-214e2b51736f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("32d4865f-f5ec-419a-8cdc-9905fcd765fc"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("23f96e4b-6209-40f9-af38-9709d3b7316b"), "f573ca64-7324-499b-8bb5-716e25f25ddd", "representative", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("b514772f-310b-4ae3-9d26-9843be578fce"), "0793fbe1-70e3-4918-b6a2-d213b033a620", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ee58970c-f1dc-4c3c-a563-bae2b5481488"), "d8318dd5-8e84-4ea8-bdbe-8e1a8a321682", "benefactor", null });
        }
    }
}
