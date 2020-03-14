using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Temalab_Fitness.Data.Migrations
{
    public partial class FirstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Difficulty = table.Column<int>(nullable: false),
                    Set = table.Column<int>(nullable: false),
                    Reps = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MileStone",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Goal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MileStone", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MileStone_Connection",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileID = table.Column<int>(nullable: true),
                    MileStone_IDID = table.Column<int>(nullable: true),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MileStone_Connection", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MileStone_Connection_MileStone_MileStone_IDID",
                        column: x => x.MileStone_IDID,
                        principalTable: "MileStone",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MileStone_Connection_Profile_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workout_Connection",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profile_IDID = table.Column<int>(nullable: true),
                    Workout_IDID = table.Column<int>(nullable: true),
                    ExerciseID = table.Column<int>(nullable: true),
                    Counter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout_Connection", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Workout_Connection_Exercise_ExerciseID",
                        column: x => x.ExerciseID,
                        principalTable: "Exercise",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workout_Connection_Profile_Profile_IDID",
                        column: x => x.Profile_IDID,
                        principalTable: "Profile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workout_Connection_Workout_Workout_IDID",
                        column: x => x.Workout_IDID,
                        principalTable: "Workout",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MileStone_Connection_MileStone_IDID",
                table: "MileStone_Connection",
                column: "MileStone_IDID");

            migrationBuilder.CreateIndex(
                name: "IX_MileStone_Connection_ProfileID",
                table: "MileStone_Connection",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_Connection_ExerciseID",
                table: "Workout_Connection",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_Connection_Profile_IDID",
                table: "Workout_Connection",
                column: "Profile_IDID");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_Connection_Workout_IDID",
                table: "Workout_Connection",
                column: "Workout_IDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MileStone_Connection");

            migrationBuilder.DropTable(
                name: "Workout_Connection");

            migrationBuilder.DropTable(
                name: "MileStone");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Workout");
        }
    }
}
