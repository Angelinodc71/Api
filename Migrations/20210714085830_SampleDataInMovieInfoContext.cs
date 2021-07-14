using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class SampleDataInMovieInfoContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 1, "Gangs of New York ye una película histórica del añu 2002 dirixida por Martin Scorsese", "Pandillas de nueva york" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 2, "Es un chico que sufre un cierto retraso mental. A pesar de todo, gracias a su tenacidad y a su buen corazón será protagonista de acontecimientos cruciales de su país", "Forrest Gump" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 3, "Ambientada en la Nueva York de la década de 1970, poco después de que terminara la guerra de Vietnam, se centra en la vida de Travis Bickle, un excombatiente solitario e inestable que debido a su insomnio crónico comienza a trabajar como taxista,", "Taxi Driver" });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "id", "age", "character", "movieId", "name" },
                values: new object[] { 1, null, "The Butcher", 1, "Daniel Day-Lewis" });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "id", "age", "character", "movieId", "name" },
                values: new object[] { 2, null, "Amsterdam Vallon", 1, "Leonardo DiCaprio" });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "id", "age", "character", "movieId", "name" },
                values: new object[] { 3, null, "Priest Vallon", 1, "Liam Neeson" });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "id", "age", "character", "movieId", "name" },
                values: new object[] { 4, null, "Forrest Gump", 2, "Tom Hanks" });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "id", "age", "character", "movieId", "name" },
                values: new object[] { 5, null, "Teniente Dan", 2, "Gary Sinise" });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "id", "age", "character", "movieId", "name" },
                values: new object[] { 6, null, "Jenny curran", 2, "Robin Wright" });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "id", "age", "character", "movieId", "name" },
                values: new object[] { 7, null, "Travis Bickle", 3, "Robert De Niro" });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "id", "age", "character", "movieId", "name" },
                values: new object[] { 8, null, "Passenger", 3, "Martin scorsese" });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "id", "age", "character", "movieId", "name" },
                values: new object[] { 9, null, "Iris", 3, "Jodie Foster" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
