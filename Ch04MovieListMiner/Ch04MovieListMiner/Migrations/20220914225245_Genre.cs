using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;

namespace Ch04MovieListMiner.Migrations
{
    public partial class Genre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<String>(
                name: "GenreId",
                table: "Movies",
                nullable: false, defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                }, constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                
                });
            migrationBuilder.InsertData(table: "Genres", columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    {"A","Action" },
                    {"C","Comedy" },
                    {"D","Drama" },
                    {"H","Horror" },
                    {"M","Musical" },
                    {"R","RomCom" },
                    {"S","SciFi" },
                });
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "GeneratedId",
                value: "D");
            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
