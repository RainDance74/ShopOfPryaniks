using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShopOfPryaniks.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class CreateIdentityScheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    user_code = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    device_code = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    subject_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    session_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    client_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    creation_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false)
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
                    version = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    use = table.Column<string>(type: "text", nullable: true),
                    algorithm = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    is_x509certificate = table.Column<bool>(type: "boolean", nullable: false),
                    data_protected = table.Column<bool>(type: "boolean", nullable: false),
                    data = table.Column<string>(type: "text", nullable: false)
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
                    type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    subject_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    session_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    client_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    creation_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    consumed_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persisted_grants", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    provider_key = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    login_provider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
