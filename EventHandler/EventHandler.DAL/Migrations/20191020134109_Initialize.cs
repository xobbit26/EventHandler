using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EventHandler.DAL.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "event_status",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sys_name = table.Column<string>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(nullable: false),
                    applicant = table.Column<string>(maxLength: 250, nullable: false),
                    apply_date_time = table.Column<DateTime>(nullable: false),
                    responsible = table.Column<string>(maxLength: 250, nullable: true),
                    resolver = table.Column<string>(maxLength: 250, nullable: true),
                    resolve_date_time = table.Column<DateTime>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    event_status_id = table.Column<int>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.id);
                    table.ForeignKey(
                        name: "FK_event_event_status_event_status_id",
                        column: x => x.event_status_id,
                        principalTable: "event_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "event_status",
                columns: new[] { "id", "is_deleted", "sys_name" },
                values: new object[,]
                {
                    { 1, false, "pending" },
                    { 2, false, "in_progress" },
                    { 3, false, "done" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_event_event_status_id",
                table: "event",
                column: "event_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_id",
                table: "event",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_event_status_id",
                table: "event_status",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "event_status");
        }
    }
}
