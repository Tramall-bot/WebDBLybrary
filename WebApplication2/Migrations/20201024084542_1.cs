using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenName = table.Column<string>(nullable: true),
                    GenDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosName = table.Column<string>(nullable: true),
                    PosSalary = table.Column<long>(nullable: false),
                    PosDuties = table.Column<string>(nullable: true),
                    PosRequirements = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PubName = table.Column<string>(nullable: true),
                    PubCity = table.Column<string>(nullable: true),
                    PubAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reader",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RdFullName = table.Column<string>(nullable: true),
                    RdBdDate = table.Column<DateTime>(nullable: false),
                    RdSex = table.Column<string>(nullable: true),
                    RdAddress = table.Column<string>(nullable: true),
                    RdPhoneNumber = table.Column<string>(nullable: true),
                    RdPassportData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpFullName = table.Column<string>(nullable: true),
                    EmpAge = table.Column<long>(nullable: false),
                    EmpSex = table.Column<string>(nullable: true),
                    EmpAddress = table.Column<string>(nullable: true),
                    EmpPhoneNumber = table.Column<string>(nullable: true),
                    EmpPassportData = table.Column<string>(nullable: true),
                    PosID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_Position_PosID",
                        column: x => x.PosID,
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BkName = table.Column<string>(nullable: true),
                    BkAuthor = table.Column<string>(nullable: true),
                    BkRealiseDate = table.Column<DateTime>(nullable: false),
                    PublisherID = table.Column<long>(nullable: true),
                    GenreId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Book_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publisher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReturnedBook",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RbReturnDate = table.Column<DateTime>(nullable: false),
                    RbGiveOutDate = table.Column<DateTime>(nullable: false),
                    RbReturnFlag = table.Column<bool>(nullable: false),
                    BkId = table.Column<long>(nullable: false),
                    RdId = table.Column<long>(nullable: false),
                    EmpId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnedBook", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReturnedBook_Book_BkId",
                        column: x => x.BkId,
                        principalTable: "Book",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnedBook_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnedBook_Reader_RdId",
                        column: x => x.RdId,
                        principalTable: "Reader",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_GenreId",
                table: "Book",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherID",
                table: "Book",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PosID",
                table: "Employee",
                column: "PosID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedBook_BkId",
                table: "ReturnedBook",
                column: "BkId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedBook_EmpId",
                table: "ReturnedBook",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedBook_RdId",
                table: "ReturnedBook",
                column: "RdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturnedBook");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Reader");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
