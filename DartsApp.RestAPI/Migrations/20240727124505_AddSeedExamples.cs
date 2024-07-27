using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DartsApp.RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedExamples : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Ranking",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "City", "ContactEmail", "ContactNumber", "Name", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Gdańsk", "kielich@gmail.com", "123456789", "Pub Kielich", "80-120", "Grunwaldzka 3" },
                    { 2, "Wrocław", "red@red.com", "987654321", "Red Pub", "20-120", "Kościuszki 4" },
                    { 3, "Bydgoszcz", "pobite_gary@gmail.com", "123456789", "Pobite gary", "10-120", "Toruńska 5" },
                    { 4, "Toruń", "elo@disco.com", "123456789", "Elo Disco", "80-130", "Jasna 6" },
                    { 5, "Piaseczno", "pub@gmail.com", "987654321", "Pub", "50-125", "Geodetów 8" },
                    { 6, "Kowale", "dart_pub@gmail.com", "123456789", "Dart pub", "80-135", "Starowiejska 1" },
                    { 7, "Wejherowo", "Pubik@Pubik.com", "666888999", "Pubik", "00-110", "Kaszubska 8" },
                    { 8, "Malbork", "melina@gmail.com", "123456789", "Melina", "10-120", "Tczewska 3" },
                    { 9, "Warszawa", "tarasy@gmail.com'", "123456789", "PTarasy", "30-320", "Fajna 666" },
                    { 10, "Poznań", "pod.kozłami@gmail.com", "666888999", "Pub Pod Kozłami", "10-000", "Pyry 3" },
                    { 11, "Katowice", "podkrasnalem@gmail.com", "123456789", "Pod krasnalem", "50-420", "Krakowska 3" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthdayDate", "ContactEmail", "ContactNumber", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(2000, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam.nowak@example.com", "888000111", "Adam", "Nowak" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthdayDate", "ContactEmail", "ContactNumber", "FirstName", "LastName", "Ranking" },
                values: new object[,]
                {
                    { 2, new DateTime(2002, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ewa.kowalska@example.com", "222333444", "Ewa", "Kowalska", 170 },
                    { 3, new DateTime(1989, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "pawel.wisniewski@example.com", "333444555", "Paweł", "Wiśniewski", 180 },
                    { 4, new DateTime(1984, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "magdalena.wojcik@example.com", "444555666", "Magdalena", "Wójcik", 160 },
                    { 5, new DateTime(2006, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "michal.lewandowski@example.com", "555666777", "Michał", "Lewandowski", 190 },
                    { 6, new DateTime(1999, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "katarzyna.kaminska@example.com", "666777888", "Katarzyna", "Kamińska", 200 },
                    { 7, new DateTime(1979, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jan.zielinski@example.com", "777888999", "Jan", "Zieliński", 140 },
                    { 8, new DateTime(1994, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "anna.szymanska@example.com", "888999000", "Anna", "Szymańska", 210 },
                    { 9, new DateTime(1969, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "tomasz.wozniak@example.com", "999000111", "Tomasz", "Woźniak", 130 },
                    { 10, new DateTime(2004, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "agnieszka.dabrowska@example.com", "000111222", "Agnieszka", "Dąbrowska", 220 }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Name", "PlaceId", "TournamentDate" },
                values: new object[,]
                {
                    { 1, "Turniej Zielony Pub", 1, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Turniej Kielicha", 2, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Turniej Czerwony Pub", 3, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Turniej Pobitych Garów", 4, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Turniej Disco", 5, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Turniej Pubu", 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Turniej Dart Pub", 7, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Turniej Pubiku", 8, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Turniej Meliny", 9, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Turniej Tarasów", 10, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Turniej Krasnala", 11, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Turniej Zielonego Pubu", 10, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Turniej Kielicha II", 2, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Turniej Czerwonego Pubu II", 3, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Turniej Pobitych Garów II", 9, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Brand", "Model", "TournamentId", "Type" },
                values: new object[,]
                {
                    { 1, "Winmau", "Blade6", 1, "sizylowa" },
                    { 2, "Winmau", "Blade5", 1, "sizylowa" },
                    { 3, "Winmau", "Blade4", 2, "sizylowa" },
                    { 4, "Winmau", "Blade3", 3, "sizylowa" },
                    { 5, "Koto", "Tournament", 4, "sizylowa" },
                    { 6, "Koto", "King Pro", 1, "sizylowa" },
                    { 7, "Koto", "King Classic", 2, "sizylowa" },
                    { 8, "Unicorn", "Eclipse Pro", 3, "sizylowa" },
                    { 9, "Unicorn", "Contender", 4, "sizylowa" },
                    { 10, "Unicorn", "Eclipse Ultra", 5, "sizylowa" }
                });

            migrationBuilder.InsertData(
                table: "PlayerTournaments",
                columns: new[] { "Id", "PlayerId", "PlayerPoints", "PlayerStatistics", "TournamentId" },
                values: new object[,]
                {
                    { 1, 1, 15, "5 wygranych, 3 przegrane", 1 },
                    { 2, 2, 12, "4 wygrane, 4 przegrane", 1 },
                    { 3, 3, 18, "6 wygranych, 2 przegrane", 2 },
                    { 4, 4, 9, "3 wygrane, 5 przegranych", 2 },
                    { 5, 5, 21, "7 wygranych, 1 przegrana", 3 },
                    { 6, 6, 6, "2 wygrane, 6 przegranych", 3 },
                    { 7, 7, 24, "8 wygranych, 0 przegranych", 4 },
                    { 8, 8, 3, "1 wygrana, 7 przegranych", 4 },
                    { 9, 9, 15, "5 wygranych, 3 przegrane", 5 },
                    { 10, 10, 12, "4 wygrane, 4 przegrane", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PlayerTournaments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlayerTournaments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlayerTournaments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlayerTournaments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlayerTournaments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PlayerTournaments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PlayerTournaments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PlayerTournaments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PlayerTournaments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PlayerTournaments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "Ranking",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);
        }
    }
}
