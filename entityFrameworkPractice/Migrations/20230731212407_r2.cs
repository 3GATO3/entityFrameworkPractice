using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace entityFrameworkPractice.Migrations
{
    /// <inheritdoc />
    public partial class r2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "BirthDate", "Fortune", "Name" },
                values: new object[,]
                {
                    { 2, new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000m, "Samuel L. Jackson" },
                    { 3, new DateTime(1988, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000m, "Henry Cavill" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "InTheaters", "Premiere", "Title" },
                values: new object[] { 5, "true", new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Justice League" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "ItIsRecommended", "MovieId" },
                values: new object[] { 6, "blah blah blah", true, 5 });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenresId", "MoviesId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "MoviesActors",
                columns: new[] { "ActorId", "MovieId", "Character", "Order" },
                values: new object[] { 3, 5, "Super Man", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
