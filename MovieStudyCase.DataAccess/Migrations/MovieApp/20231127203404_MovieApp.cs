using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStudyCase.DataAccess.Migrations.MovieApp
{
    public partial class MovieApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "admin"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(7973)),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Premier = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "admin"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8664)),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "DirectorId", "CreateDate", "CreateUser", "IsDeleted", "Name", "UpdateDate", "UpdateUser" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8256), "MustafaKocatepe", false, "Director 1", null, "MustafaKocatepe" },
                    { 2, new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8260), "MustafaKocatepe", false, "Director 2", null, "MustafaKocatepe" },
                    { 3, new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8262), "MustafaKocatepe", false, "Director 3", null, "MustafaKocatepe" },
                    { 4, new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8263), "MustafaKocatepe", false, "Director 4", null, "MustafaKocatepe" },
                    { 5, new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8264), "MustafaKocatepe", false, "Director 5", null, "MustafaKocatepe" },
                    { 6, new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8266), "MustafaKocatepe", false, "Director 6", null, "MustafaKocatepe" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "CreateDate", "CreateUser", "Description", "DirectorId", "Genre", "Name", "Premier", "UpdateDate", "UpdateUser" },
                values: new object[] { 1, new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8982), "MustafaKocatepe", "Test Desc", 1, 0, "Test Movie 1", new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8981), null, "MustafaKocatepe" });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
