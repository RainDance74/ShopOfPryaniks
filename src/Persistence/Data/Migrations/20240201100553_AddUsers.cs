using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShopOfPryaniks.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "client_phone",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "client_phone",
                table: "carts");

            migrationBuilder.AddColumn<int>(
                name: "owner_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "owner_id",
                table: "carts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employee", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_orders_owner_id",
                table: "orders",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_carts_owner_id",
                table: "carts",
                column: "owner_id");

            migrationBuilder.AddForeignKey(
                name: "fk_carts_customer_owner_id",
                table: "carts",
                column: "owner_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orders_customer_owner_id",
                table: "orders",
                column: "owner_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_carts_customer_owner_id",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "fk_orders_customer_owner_id",
                table: "orders");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropIndex(
                name: "ix_orders_owner_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "ix_carts_owner_id",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "owner_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "owner_id",
                table: "carts");

            migrationBuilder.AddColumn<string>(
                name: "client_phone",
                table: "orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "client_phone",
                table: "carts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
