using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreAPI.Migrations
{
    public partial class generatecustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "Produtos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CustomerId",
                table: "Produtos",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Clientes_CustomerId",
                table: "Produtos",
                column: "CustomerId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Clientes_CustomerId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CustomerId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Produtos");
        }
    }
}
