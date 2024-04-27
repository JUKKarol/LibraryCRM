using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCRM.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Authors",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Authors", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Clients",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Clients", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Libraries",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Libraries", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Books",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                LibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Books", x => x.Id);
                table.ForeignKey(
                    name: "FK_Books_Authors_AuthorId",
                    column: x => x.AuthorId,
                    principalTable: "Authors",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Books_Libraries_LibraryId",
                    column: x => x.LibraryId,
                    principalTable: "Libraries",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "RentHistories",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                RentStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                RentEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                LibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RentHistories", x => x.Id);
                table.ForeignKey(
                    name: "FK_RentHistories_Books_BookId",
                    column: x => x.BookId,
                    principalTable: "Books",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_RentHistories_Clients_ClientId",
                    column: x => x.ClientId,
                    principalTable: "Clients",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_RentHistories_Libraries_LibraryId",
                    column: x => x.LibraryId,
                    principalTable: "Libraries",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Books_AuthorId",
            table: "Books",
            column: "AuthorId");

        migrationBuilder.CreateIndex(
            name: "IX_Books_LibraryId",
            table: "Books",
            column: "LibraryId");

        migrationBuilder.CreateIndex(
            name: "IX_RentHistories_BookId",
            table: "RentHistories",
            column: "BookId");

        migrationBuilder.CreateIndex(
            name: "IX_RentHistories_ClientId",
            table: "RentHistories",
            column: "ClientId");

        migrationBuilder.CreateIndex(
            name: "IX_RentHistories_LibraryId",
            table: "RentHistories",
            column: "LibraryId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "RentHistories");

        migrationBuilder.DropTable(
            name: "Books");

        migrationBuilder.DropTable(
            name: "Clients");

        migrationBuilder.DropTable(
            name: "Authors");

        migrationBuilder.DropTable(
            name: "Libraries");
    }
}
