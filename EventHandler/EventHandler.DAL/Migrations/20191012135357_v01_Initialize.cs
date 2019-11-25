using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EventHandler.DAL.Migrations
{
    public partial class v01_Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "events",
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
                    status = table.Column<string>(maxLength: 250, nullable: true),
                    is_deleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_events_id",
                table: "events",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "events");
        }
    }
}
