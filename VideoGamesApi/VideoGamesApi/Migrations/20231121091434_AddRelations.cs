using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGamesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditorEntityGameEntity");

            migrationBuilder.DropTable(
                name: "GameEntityStudioEntity");

            migrationBuilder.CreateTable(
                name: "EditorGameRelation",
                columns: table => new
                {
                    EditorId = table.Column<int>(type: "INTEGER", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorGameRelation", x => new { x.EditorId, x.GameId });
                    table.ForeignKey(
                        name: "FK_EditorGameRelation_Editor_EditorId",
                        column: x => x.EditorId,
                        principalTable: "Editor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditorGameRelation_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudioGameRelation",
                columns: table => new
                {
                    StudioId = table.Column<int>(type: "INTEGER", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudioGameRelation", x => new { x.StudioId, x.GameId });
                    table.ForeignKey(
                        name: "FK_StudioGameRelation_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudioGameRelation_Studio_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EditorGameRelation_GameId",
                table: "EditorGameRelation",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_StudioGameRelation_GameId",
                table: "StudioGameRelation",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditorGameRelation");

            migrationBuilder.DropTable(
                name: "StudioGameRelation");

            migrationBuilder.CreateTable(
                name: "EditorEntityGameEntity",
                columns: table => new
                {
                    EditorsId = table.Column<int>(type: "INTEGER", nullable: false),
                    GamesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorEntityGameEntity", x => new { x.EditorsId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_EditorEntityGameEntity_Editor_EditorsId",
                        column: x => x.EditorsId,
                        principalTable: "Editor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditorEntityGameEntity_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameEntityStudioEntity",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudiosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEntityStudioEntity", x => new { x.GamesId, x.StudiosId });
                    table.ForeignKey(
                        name: "FK_GameEntityStudioEntity_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameEntityStudioEntity_Studio_StudiosId",
                        column: x => x.StudiosId,
                        principalTable: "Studio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EditorEntityGameEntity_GamesId",
                table: "EditorEntityGameEntity",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameEntityStudioEntity_StudiosId",
                table: "GameEntityStudioEntity",
                column: "StudiosId");
        }
    }
}
