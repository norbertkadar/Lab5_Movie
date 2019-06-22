﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab3Movie.Migrations
{
    public partial class AddOwnerForMovieAndComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_OwnerId",
                table: "Movies",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_OwnerId",
                table: "Comments",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_OwnerId",
                table: "Comments",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Users_OwnerId",
                table: "Movies",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_OwnerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Users_OwnerId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_OwnerId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Comments_OwnerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Comments");
        }
    }
}
