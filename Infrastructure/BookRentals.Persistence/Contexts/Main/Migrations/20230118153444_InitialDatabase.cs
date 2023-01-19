using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookRentals.Persistence.Contexts.Main.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isbn = table.Column<double>(type: "float", nullable: false),
                    Rented = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookTransactions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTransactions_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Isbn", "Name", "Rented" },
                values: new object[,]
                {
                    { new Guid("04faa393-8bea-4196-9e37-ddf1c5382da1"), "Khaled Hosseini", 9.1999999999999993, "Uçurtma Avcısı", false },
                    { new Guid("51036971-8a19-43a4-ae77-b250b488838f"), "Kahraman Tazeoğlu", 7.4000000000000004, "Yalnızım Çünkü Sen Varsın", true },
                    { new Guid("57fd2c45-4343-4a3b-b702-88b94e691d25"), "Madeline Miller", 8.1999999999999993, "Ben Kirke", true },
                    { new Guid("659056f9-6bef-4a9a-8b98-906babd4179c"), "Jose Mauro De Vasconcelos", 9.3000000000000007, "Şeker Portakalı", false },
                    { new Guid("b24161c4-32e7-4208-96ae-a3a3d68bca16"), "James Wallman", 7.9000000000000004, "İstif Çağı", false },
                    { new Guid("b9548607-acb9-444b-9dae-8330199e420b"), "Fyodor Mihailoviç Dostoyevski", 9.5, "Suç ve Ceza", true },
                    { new Guid("cdb1d571-d693-4dc5-aeca-d0a8f036ef6e"), "Sabahattin Ali", 9.0999999999999996, "Kürk Mantolu Madonna", true },
                    { new Guid("dbae6962-99ed-430d-a16e-43fd36c069e4"), "Mustafa Kemal Atatürk", 9.0999999999999996, "Nutuk", false },
                    { new Guid("df532ae2-e6cc-494f-9472-e78a6d72705e"), "Zülfü Livaneli", 8.5, "Balıkçı ve Oğlu", true },
                    { new Guid("e14159be-759f-4e4f-9b69-8ac738a86891"), "Fyodor Mihailoviç Dostoyevski", 7.0, "Amcamın Rüyası", false }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "FirstName", "IdentityNumber", "LastName" },
                values: new object[,]
                {
                    { new Guid("06500dc8-f77b-417d-bb5d-0d6ac7e3661a"), "Hasan", "2", "Usta" },
                    { new Guid("0d3818c5-7c5e-4e12-ba06-7fb3b391c933"), "Mehmet", "4", "Taşçı" },
                    { new Guid("284e5ea4-32da-4643-84b9-b7a889f9fe78"), "Elif", "3", "Gül" },
                    { new Guid("5b5aba2c-068c-4850-86ab-a4e2eca325ed"), "Ahmet", "1", "Ünlü" },
                    { new Guid("5e9b7161-3bb9-4e02-bc5b-788925450042"), "Melike", "5", "Gezer" }
                });

            migrationBuilder.InsertData(
                table: "BookTransactions",
                columns: new[] { "Id", "BookId", "MemberId", "RentDate", "ReturnDate" },
                values: new object[,]
                {
                    { new Guid("2f8e4e94-8ef1-4ab3-afc9-963c600817b3"), new Guid("b9548607-acb9-444b-9dae-8330199e420b"), new Guid("284e5ea4-32da-4643-84b9-b7a889f9fe78"), new DateTime(2023, 1, 25, 18, 34, 44, 712, DateTimeKind.Local).AddTicks(2379), new DateTime(2023, 2, 20, 18, 34, 44, 712, DateTimeKind.Local).AddTicks(2379) },
                    { new Guid("3ae4fff7-9b5b-43bd-9238-1ed332c42025"), new Guid("57fd2c45-4343-4a3b-b702-88b94e691d25"), new Guid("06500dc8-f77b-417d-bb5d-0d6ac7e3661a"), new DateTime(2023, 1, 24, 18, 34, 44, 712, DateTimeKind.Local).AddTicks(2374), new DateTime(2023, 1, 16, 18, 34, 44, 712, DateTimeKind.Local).AddTicks(2375) },
                    { new Guid("4d2950e5-8377-434c-95ec-0bd9f259ff99"), new Guid("cdb1d571-d693-4dc5-aeca-d0a8f036ef6e"), new Guid("0d3818c5-7c5e-4e12-ba06-7fb3b391c933"), new DateTime(2023, 1, 26, 18, 34, 44, 712, DateTimeKind.Local).AddTicks(2385), new DateTime(2023, 2, 20, 18, 34, 44, 712, DateTimeKind.Local).AddTicks(2386) },
                    { new Guid("d7f57332-284a-4657-aaf9-b9facb65648d"), new Guid("51036971-8a19-43a4-ae77-b250b488838f"), new Guid("5e9b7161-3bb9-4e02-bc5b-788925450042"), new DateTime(2023, 1, 27, 18, 34, 44, 712, DateTimeKind.Local).AddTicks(2389), new DateTime(2023, 2, 20, 18, 34, 44, 712, DateTimeKind.Local).AddTicks(2389) },
                    { new Guid("db3fbf6c-33e3-4dbf-b683-8b8739f3213d"), new Guid("df532ae2-e6cc-494f-9472-e78a6d72705e"), new Guid("5b5aba2c-068c-4850-86ab-a4e2eca325ed"), new DateTime(2022, 12, 14, 18, 34, 44, 712, DateTimeKind.Local).AddTicks(2358), new DateTime(2023, 1, 17, 18, 34, 44, 712, DateTimeKind.Local).AddTicks(2367) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_BookId",
                table: "BookTransactions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_MemberId",
                table: "BookTransactions",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTransactions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
