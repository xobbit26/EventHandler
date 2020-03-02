using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EventHandler.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "event_status",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sys_name = table.Column<string>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "resource",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    locale = table.Column<string>(nullable: false),
                    text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resource", x => new { x.id, x.locale });
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(nullable: false),
                    applicant = table.Column<string>(maxLength: 250, nullable: false),
                    applicant_department = table.Column<string>(maxLength: 250, nullable: true),
                    apply_date_time = table.Column<DateTime>(nullable: false),
                    responsible = table.Column<string>(maxLength: 250, nullable: true),
                    resolver = table.Column<string>(maxLength: 250, nullable: true),
                    resolve_date_time = table.Column<DateTime>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    event_status_id = table.Column<long>(nullable: false),
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
                columns: new[] { "id", "sys_name" },
                values: new object[,]
                {
                    { 1L, "pending" },
                    { 2L, "in_progress" },
                    { 3L, "done" }
                });

            migrationBuilder.InsertData(
                table: "resource",
                columns: new[] { "id", "locale", "text" },
                values: new object[,]
                {
                    { "AppBar_Login_Label", "RU", "Логин" },
                    { "AppBar_Create_Event_Label", "RU", "Создать заявку" },
                    { "AppBar_Event_List_Label", "RU", "Список заявок" },
                    { "AppBar_Reports_Label", "RU", "Отчеты" },
                    { "AppBar_Reports_Administration", "RU", "Управление" },
                    { "AppBar_Reports_Settings", "RU", "Настройки" },
                    { "EventsTable_Header_FullName", "RU", "ФИО подавшего заявку" },
                    { "EventsTable_Header_ApplyDateTime", "RU", "Дата и время подачи" },
                    { "EventsTable_Header_Responsible", "RU", "Ответственный" },
                    { "AppName_Label", "RU", "Event Handler" },
                    { "EventsTable_Header_Status", "RU", "Статус" },
                    { "EventsTable_Header_ResolveDateTime", "RU", "Дата и время выполнения" },
                    { "CreateEvent_FullName_Label", "RU", "ФИО" },
                    { "CreateEvent_Department_Label", "RU", "Отдел" },
                    { "CreateEvent_Description_Label", "RU", "Описание" },
                    { "CreateEvent_Submit_Button_Label", "RU", "Отправить" },
                    { "LoginPage_Login_Label", "RU", "Логин" },
                    { "EventsTable_Header_Description", "RU", "Описание" },
                    { "LoginPage_Enter_Label", "EN", "Enter" },
                    { "LoginPage_Password_Label", "EN", "Password" },
                    { "LoginPage_Login_Label", "EN", "Login" },
                    { "AppName_Label", "EN", "Event Handler" },
                    { "AppBar_Login_Label", "EN", "Login" },
                    { "AppBar_Create_Event_Label", "EN", "Create Event" },
                    { "AppBar_Event_List_Label", "EN", "Event List" },
                    { "AppBar_Reports_Label", "EN", "Reports" },
                    { "AppBar_Reports_Administration", "EN", "Administration" },
                    { "AppBar_Reports_Settings", "EN", "Settings" },
                    { "EventsTable_Header_FullName", "EN", "FullName" },
                    { "EventsTable_Header_ApplyDateTime", "EN", "Date Time" },
                    { "EventsTable_Header_Description", "EN", "Description" },
                    { "EventsTable_Header_Responsible", "EN", "Responsible" },
                    { "EventsTable_Header_Status", "EN", "Status" },
                    { "EventsTable_Header_ResolveDateTime", "EN", "Resolving Date Time" },
                    { "CreateEvent_FullName_Label", "EN", "Full Name" },
                    { "CreateEvent_Department_Label", "EN", "Department" },
                    { "CreateEvent_Description_Label", "EN", "Description" },
                    { "CreateEvent_Submit_Button_Label", "EN", "Submit" },
                    { "LoginPage_Password_Label", "RU", "Пароль" },
                    { "LoginPage_Enter_Label", "RU", "Войти" }
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

            migrationBuilder.CreateIndex(
                name: "IX_resource_id_locale",
                table: "resource",
                columns: new[] { "id", "locale" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "resource");

            migrationBuilder.DropTable(
                name: "event_status");
        }
    }
}
