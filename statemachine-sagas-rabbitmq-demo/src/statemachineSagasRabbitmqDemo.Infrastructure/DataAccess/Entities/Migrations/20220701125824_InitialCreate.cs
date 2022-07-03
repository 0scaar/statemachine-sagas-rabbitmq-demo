using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace statemachineSagasRabbitmqDemo.Infrastructure.DataAccess.Entities.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SagaDemo");

            migrationBuilder.CreateTable(
                name: "File",
                schema: "SagaDemo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileDetail",
                schema: "SagaDemo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileDetail_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "SagaDemo",
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileLog",
                schema: "SagaDemo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateLog = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Message = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Error = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileLog_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "SagaDemo",
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileDetail_FileId",
                schema: "SagaDemo",
                table: "FileDetail",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileLog_FileId",
                schema: "SagaDemo",
                table: "FileLog",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDetail",
                schema: "SagaDemo");

            migrationBuilder.DropTable(
                name: "FileLog",
                schema: "SagaDemo");

            migrationBuilder.DropTable(
                name: "File",
                schema: "SagaDemo");
        }
    }
}
