using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedYear = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.K. Rowling" },
                    { 2, new DateTime(1903, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Orwell" },
                    { 3, new DateTime(1775, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Austen" },
                    { 4, new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephen King" },
                    { 5, new DateTime(1890, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agatha Christie" },
                    { 6, new DateTime(1892, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.R.R. Tolkien" },
                    { 7, new DateTime(1899, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ernest Hemingway" },
                    { 8, new DateTime(1896, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "F. Scott Fitzgerald" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1997, "Harry Potter and the Philosopher's Stone" },
                    { 2, 1, 1998, "Harry Potter and the Chamber of Secrets" },
                    { 3, 1, 1999, "Harry Potter and the Prisoner of Azkaban" },
                    { 4, 1, 2000, "Harry Potter and the Goblet of Fire" },
                    { 5, 1, 2012, "The Casual Vacancy" },
                    { 6, 2, 1949, "1984" },
                    { 7, 2, 1945, "Animal Farm" },
                    { 8, 2, 1938, "Homage to Catalonia" },
                    { 9, 3, 1813, "Pride and Prejudice" },
                    { 10, 3, 1811, "Sense and Sensibility" },
                    { 11, 3, 1815, "Emma" },
                    { 12, 3, 1814, "Mansfield Park" },
                    { 13, 4, 1977, "The Shining" },
                    { 14, 4, 1986, "It" },
                    { 15, 4, 1978, "The Stand" },
                    { 16, 4, 1974, "Carrie" },
                    { 17, 4, 1987, "Misery" },
                    { 18, 5, 1934, "Murder on the Orient Express" },
                    { 19, 5, 1937, "Death on the Nile" },
                    { 20, 5, 1926, "The Murder of Roger Ackroyd" },
                    { 21, 5, 1939, "And Then There Were None" },
                    { 22, 6, 1937, "The Hobbit" },
                    { 23, 6, 1954, "The Fellowship of the Ring" },
                    { 24, 6, 1954, "The Two Towers" },
                    { 25, 6, 1955, "The Return of the King" },
                    { 26, 7, 1952, "The Old Man and the Sea" },
                    { 27, 7, 1929, "A Farewell to Arms" },
                    { 28, 7, 1940, "For Whom the Bell Tolls" },
                    { 29, 8, 1925, "The Great Gatsby" },
                    { 30, 8, 1934, "Tender Is the Night" },
                    { 31, 8, 1920, "This Side of Paradise" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
