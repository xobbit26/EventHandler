using Microsoft.EntityFrameworkCore.Migrations;

namespace EventHandler.DAL.Migrations
{
    public partial class addnewtranslation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "resource",
                columns: new[] { "id", "locale", "text" },
                values: new object[,]
                {
                    { "SuccessMessage_EventCreated", "EN", "Event Successfully Created!" },
                    { "SuccessMessage_EventCreated", "RU", "Заявка успешно создана!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "resource",
                keyColumns: new[] { "id", "locale" },
                keyValues: new object[] { "SuccessMessage_EventCreated", "EN" });

            migrationBuilder.DeleteData(
                table: "resource",
                keyColumns: new[] { "id", "locale" },
                keyValues: new object[] { "SuccessMessage_EventCreated", "RU" });
        }
    }
}
