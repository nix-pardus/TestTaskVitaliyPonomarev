using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoginTime",
                table: "UserStatistics",
                newName: "SignInTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "StatisticRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "StatisticRequests");

            migrationBuilder.RenameColumn(
                name: "SignInTime",
                table: "UserStatistics",
                newName: "LoginTime");
        }
    }
}
