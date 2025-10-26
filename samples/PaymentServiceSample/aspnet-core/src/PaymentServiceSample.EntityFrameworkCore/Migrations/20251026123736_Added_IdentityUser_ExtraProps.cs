using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentServiceSample.Migrations
{
    /// <inheritdoc />
    public partial class Added_IdentityUser_ExtraProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "AbpUsers",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AbpUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "AbpUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdCode",
                table: "AbpUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "AbpUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "AbpUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "AbpUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_NationalCode_TenantId",
                table: "AbpUsers",
                columns: new[] { "NationalCode", "TenantId" },
                unique: true,
                filter: "[NationalCode] IS NOT NULL AND [TenantId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_NationalCode_TenantId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "IdCode",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "AbpUsers");
        }
    }
}
