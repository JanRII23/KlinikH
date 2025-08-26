using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlinikH.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateAppUserDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "AspNetUsers",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "lastLogin",
                table: "AspNetUsers",
                newName: "LastLogin");

            migrationBuilder.RenameColumn(
                name: "isLockedOut",
                table: "AspNetUsers",
                newName: "IsLockedOut");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "AspNetUsers",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "createdOn",
                table: "AspNetUsers",
                newName: "CreatedOn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "AspNetUsers",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "LastLogin",
                table: "AspNetUsers",
                newName: "lastLogin");

            migrationBuilder.RenameColumn(
                name: "IsLockedOut",
                table: "AspNetUsers",
                newName: "isLockedOut");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "AspNetUsers",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "AspNetUsers",
                newName: "createdOn");
        }
    }
}
