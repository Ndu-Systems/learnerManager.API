using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnerManager.API.Migrations
{
    public partial class tablesModifyLearnerParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentName",
                table: "learner",
                newName: "Section");

            migrationBuilder.RenameColumn(
                name: "ParentContactNumber",
                table: "learner",
                newName: "SchoolName");

            migrationBuilder.AddColumn<string>(
                name: "IDNumber",
                table: "Parents",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Parents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateOfBirth",
                table: "learner",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "learner",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "learner",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDNumber",
                table: "learner",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "learner",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDNumber",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "learner");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "learner");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "learner");

            migrationBuilder.DropColumn(
                name: "IDNumber",
                table: "learner");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "learner");

            migrationBuilder.RenameColumn(
                name: "Section",
                table: "learner",
                newName: "ParentName");

            migrationBuilder.RenameColumn(
                name: "SchoolName",
                table: "learner",
                newName: "ParentContactNumber");
        }
    }
}
