using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.Chat.Migrations
{
    /// <inheritdoc />
    public partial class Modificadocontato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Mensagem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Mensagem");
        }
    }
}
