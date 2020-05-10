using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Temalab_Fitness.Data.Migrations
{
    public partial class finaldb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MileStone_Connection_Profile_ProfileID",
                table: "MileStone_Connection");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_Connection_Profile_Profile_IDID",
                table: "Workout_Connection");

            migrationBuilder.RenameColumn(
                name: "Profile_IDID",
                table: "Workout_Connection",
                newName: "Profile_IDId");

            migrationBuilder.RenameIndex(
                name: "IX_Workout_Connection_Profile_IDID",
                table: "Workout_Connection",
                newName: "IX_Workout_Connection_Profile_IDId");

            migrationBuilder.RenameColumn(
                name: "ProfileID",
                table: "MileStone_Connection",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_MileStone_Connection_ProfileID",
                table: "MileStone_Connection",
                newName: "IX_MileStone_Connection_ProfileId");

            migrationBuilder.AlterColumn<string>(
                name: "Profile_IDId",
                table: "Workout_Connection",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfileId",
                table: "MileStone_Connection",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MileStone_Connection_AspNetUsers_ProfileId",
                table: "MileStone_Connection",
                column: "ProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_Connection_AspNetUsers_Profile_IDId",
                table: "Workout_Connection",
                column: "Profile_IDId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MileStone_Connection_AspNetUsers_ProfileId",
                table: "MileStone_Connection");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_Connection_AspNetUsers_Profile_IDId",
                table: "Workout_Connection");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Profile_IDId",
                table: "Workout_Connection",
                newName: "Profile_IDID");

            migrationBuilder.RenameIndex(
                name: "IX_Workout_Connection_Profile_IDId",
                table: "Workout_Connection",
                newName: "IX_Workout_Connection_Profile_IDID");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "MileStone_Connection",
                newName: "ProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_MileStone_Connection_ProfileId",
                table: "MileStone_Connection",
                newName: "IX_MileStone_Connection_ProfileID");

            migrationBuilder.AlterColumn<int>(
                name: "Profile_IDID",
                table: "Workout_Connection",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfileID",
                table: "MileStone_Connection",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MileStone_Connection_Profile_ProfileID",
                table: "MileStone_Connection",
                column: "ProfileID",
                principalTable: "Profile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_Connection_Profile_Profile_IDID",
                table: "Workout_Connection",
                column: "Profile_IDID",
                principalTable: "Profile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
