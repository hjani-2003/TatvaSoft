using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.VCS.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserSkills",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MissionThemes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MissionSkills",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Missions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MissionApplications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Country",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "City",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserSkills");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MissionThemes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MissionSkills");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MissionApplications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "City");
        }
    }
}
