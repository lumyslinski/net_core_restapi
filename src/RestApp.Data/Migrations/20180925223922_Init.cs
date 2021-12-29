using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApp.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterFriend",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    FriendId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFriend", x => new { x.CharacterId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_CharacterFriend_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterFriend_Character_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterEpisode",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    EpisodeId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterEpisode", x => new { x.CharacterId, x.EpisodeId });
                    table.ForeignKey(
                        name: "FK_CharacterEpisode_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterEpisode_Episode_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Luke Skywalker" });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Darth Vader" });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Han Solo" });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Leia Organa" });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Wilhuff Tarkin" });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "C-3PO" });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "R2-D2" });

            migrationBuilder.InsertData(
                table: "Episode",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "NEWHOPE" });

            migrationBuilder.InsertData(
                table: "Episode",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "EMPIRE" });

            migrationBuilder.InsertData(
                table: "Episode",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "JEDI" });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 7, 3, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 2, 1, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 3, 1, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 4, 1, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 5, 1, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 6, 1, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 7, 1, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 1, 2, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 1, 1, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 2, 2, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 4, 2, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 6, 2, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 7, 2, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 1, 3, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 2, 3, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 3, 3, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 4, 3, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 3, 2, null });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId", "RowVersion" },
                values: new object[] { 6, 3, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 7, 4, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 7, 1, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 3, 1, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 1, 4, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 3, 4, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 4, 1, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 4, 3, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 2, 5, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 5, 2, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 7, 3, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 1, 6, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 6, 1, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 6, 3, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 6, 4, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 1, 7, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 3, 7, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 4, 7, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 6, 7, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 4, 6, null });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId", "RowVersion" },
                values: new object[] { 1, 3, null });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEpisode_EpisodeId",
                table: "CharacterEpisode",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFriend_FriendId",
                table: "CharacterFriend",
                column: "FriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterEpisode");

            migrationBuilder.DropTable(
                name: "CharacterFriend");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}
