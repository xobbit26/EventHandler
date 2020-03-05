using Microsoft.EntityFrameworkCore.Migrations;

namespace EventHandler.DAL.Migrations
{
    public partial class addnewresource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "resource",
                columns: new[] { "id", "locale", "text" },
                values: new object[,]
                {
                    { "ErrorMessage_InternalServer", "EN", "Internal Server Error!" },
                    { "ErrorMessage_InternalServer", "RU", "Внутренняя ошибка сервера!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "resource",
                keyColumns: new[] { "id", "locale" },
                keyValues: new object[] { "ErrorMessage_InternalServer", "EN" });

            migrationBuilder.DeleteData(
                table: "resource",
                keyColumns: new[] { "id", "locale" },
                keyValues: new object[] { "ErrorMessage_InternalServer", "RU" });
        }
    }
}
