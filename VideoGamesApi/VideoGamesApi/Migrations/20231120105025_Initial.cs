using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGamesApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EditorGame",
                columns: table => new
                {
                    EditorsId = table.Column<int>(type: "INTEGER", nullable: false),
                    GamesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorGame", x => new { x.EditorsId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_EditorGame_Editor_EditorsId",
                        column: x => x.EditorsId,
                        principalTable: "Editor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditorGame_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StringEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    String = table.Column<string>(type: "TEXT", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: true),
                    GameId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StringEntity_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StringEntity_Game_GameId1",
                        column: x => x.GameId1,
                        principalTable: "Game",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameStudio",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudiosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStudio", x => new { x.GamesId, x.StudiosId });
                    table.ForeignKey(
                        name: "FK_GameStudio_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameStudio_Studio_StudiosId",
                        column: x => x.StudiosId,
                        principalTable: "Studio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EditorGame_GamesId",
                table: "EditorGame",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameStudio_StudiosId",
                table: "GameStudio",
                column: "StudiosId");

            migrationBuilder.CreateIndex(
                name: "IX_StringEntity_GameId",
                table: "StringEntity",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_StringEntity_GameId1",
                table: "StringEntity",
                column: "GameId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditorGame");

            migrationBuilder.DropTable(
                name: "GameStudio");

            migrationBuilder.DropTable(
                name: "StringEntity");

            migrationBuilder.DropTable(
                name: "Editor");

            migrationBuilder.DropTable(
                name: "Studio");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
