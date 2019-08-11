using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnerManager.API.Migrations
{
    public partial class addParentLearnerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParentLearners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LearnerId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentLearners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParentLearners");
        }
    }
}
