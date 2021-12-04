using Microsoft.EntityFrameworkCore.Migrations;

namespace PokéBase.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pokemonSet",
                columns: table => new
                {
                    pokeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dexNum = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    originalTrainer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemonSet", x => x.pokeID);
                });

            migrationBuilder.CreateTable(
                name: "trainerSet",
                columns: table => new
                {
                    trainerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    trainerClass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainerSet", x => x.trainerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pokemonSet");

            migrationBuilder.DropTable(
                name: "trainerSet");
        }
    }
}
