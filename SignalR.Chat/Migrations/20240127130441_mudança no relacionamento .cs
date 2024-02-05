using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.Chat.Migrations
{
    /// <inheritdoc />
    public partial class mudançanorelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Usuarios_UsuarioId",
                table: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_Contato_UsuarioId",
                table: "Contato");

            migrationBuilder.AddColumn<int>(
                name: "DestinatarioId",
                table: "Contato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contato_DestinatarioId",
                table: "Contato",
                column: "DestinatarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Usuarios_DestinatarioId",
                table: "Contato",
                column: "DestinatarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Usuarios_DestinatarioId",
                table: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_Contato_DestinatarioId",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "DestinatarioId",
                table: "Contato");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_UsuarioId",
                table: "Contato",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Usuarios_UsuarioId",
                table: "Contato",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
