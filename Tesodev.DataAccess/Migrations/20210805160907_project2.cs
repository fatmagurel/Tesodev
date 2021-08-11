using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tesodev.DataAccess.Migrations
{
    public partial class project2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_ID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressID",
                table: "Customers",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_AddressID",
                table: "Customers",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressID",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerID",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_ID",
                table: "Customers",
                column: "ID",
                principalTable: "Addresses",
                principalColumn: "ID");
        }
    }
}
