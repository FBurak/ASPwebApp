using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPwebApp.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentAppId",
                table: "Makeapms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Makeapms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Makeapms_AppointmentAppId",
                table: "Makeapms",
                column: "AppointmentAppId");

            migrationBuilder.CreateIndex(
                name: "IX_Makeapms_UserId",
                table: "Makeapms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Makeapms_Appointments_AppointmentAppId",
                table: "Makeapms",
                column: "AppointmentAppId",
                principalTable: "Appointments",
                principalColumn: "AppId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Makeapms_Users_UserId",
                table: "Makeapms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makeapms_Appointments_AppointmentAppId",
                table: "Makeapms");

            migrationBuilder.DropForeignKey(
                name: "FK_Makeapms_Users_UserId",
                table: "Makeapms");

            migrationBuilder.DropIndex(
                name: "IX_Makeapms_AppointmentAppId",
                table: "Makeapms");

            migrationBuilder.DropIndex(
                name: "IX_Makeapms_UserId",
                table: "Makeapms");

            migrationBuilder.DropColumn(
                name: "AppointmentAppId",
                table: "Makeapms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Makeapms");
        }
    }
}
