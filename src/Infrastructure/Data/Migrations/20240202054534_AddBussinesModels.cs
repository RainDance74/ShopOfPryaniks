using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShopOfPryaniks.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBussinesModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "login_provider",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "provider_key",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "login_provider",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    owner_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_carts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    owner_id = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    discount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    cart_id = table.Column<int>(type: "integer", nullable: true),
                    order_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_positions", x => x.id);
                    table.ForeignKey(
                        name: "fk_positions_carts_cart_id",
                        column: x => x.cart_id,
                        principalTable: "carts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_positions_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_positions_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_positions_cart_id",
                table: "positions",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "ix_positions_order_id",
                table: "positions",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_positions_product_id",
                table: "positions",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "AspNetUserTokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "login_provider",
                table: "AspNetUserTokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "provider_key",
                table: "AspNetUserLogins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "login_provider",
                table: "AspNetUserLogins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    user_code = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    client_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    creation_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    device_code = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    session_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    subject_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_codes", x => x.user_code);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    algorithm = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<string>(type: "text", nullable: false),
                    data_protected = table.Column<bool>(type: "boolean", nullable: false),
                    is_x509certificate = table.Column<bool>(type: "boolean", nullable: false),
                    use = table.Column<string>(type: "text", nullable: true),
                    version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_keys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    key = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    client_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    consumed_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    creation_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    session_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    subject_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persisted_grants", x => x.key);
                });

            migrationBuilder.CreateIndex(
                name: "ix_device_codes_device_code",
                table: "DeviceCodes",
                column: "device_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_device_codes_expiration",
                table: "DeviceCodes",
                column: "expiration");

            migrationBuilder.CreateIndex(
                name: "ix_keys_use",
                table: "Keys",
                column: "use");

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_consumed_time",
                table: "PersistedGrants",
                column: "consumed_time");

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_expiration",
                table: "PersistedGrants",
                column: "expiration");

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_subject_id_client_id_type",
                table: "PersistedGrants",
                columns: new[] { "subject_id", "client_id", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_subject_id_session_id_type",
                table: "PersistedGrants",
                columns: new[] { "subject_id", "session_id", "type" });
        }
    }
}
