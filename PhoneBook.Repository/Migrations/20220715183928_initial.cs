using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBook.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "CreatedDate", "Email", "FirstName", "LastName", "NickName", "Profession", "UpdatedDate", "WebAddress" },
                values: new object[] { 1, "Üsküdar/İstanbul", new DateTime(2022, 7, 15, 21, 39, 28, 643, DateTimeKind.Local).AddTicks(8264), "mustafa@outlook.com", "Mustafa", "Hatipoğlu", "mustafa", "Student", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.api.com" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "CreatedDate", "Email", "FirstName", "LastName", "NickName", "Profession", "UpdatedDate", "WebAddress" },
                values: new object[] { 2, "Ümraniye/İstanbul", new DateTime(2022, 7, 15, 21, 39, 28, 643, DateTimeKind.Local).AddTicks(8278), "ahmet@gmail.com", "Ahmet", "Yılmaz", "ahmet", "Student", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.google.com" });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "ContactId", "CreatedDate", "PhoneNo", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 7, 15, 21, 39, 28, 643, DateTimeKind.Local).AddTicks(8569), "05386221584", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2022, 7, 15, 21, 39, 28, 643, DateTimeKind.Local).AddTicks(8573), "05384332199", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2022, 7, 15, 21, 39, 28, 643, DateTimeKind.Local).AddTicks(8574), "05406004030", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2022, 7, 15, 21, 39, 28, 643, DateTimeKind.Local).AddTicks(8575), "05332221036", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_ContactId",
                table: "PhoneNumbers",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
