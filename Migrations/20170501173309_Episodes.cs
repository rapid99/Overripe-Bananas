using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OverripeBananas.Migrations
{
    public partial class Episodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BestCharacter = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    EpisodeName = table.Column<string>(nullable: false),
                    EpisodeNumber = table.Column<int>(nullable: false),
                    HumorRating = table.Column<int>(nullable: false),
                    OverallGrade = table.Column<int>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    ShowName = table.Column<string>(nullable: false),
                    StoryRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episodes");
        }
    }
}
