using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(248)", maxLength: 248, nullable: true),
                    SmallDescription = table.Column<string>(type: "nvarchar(248)", maxLength: 248, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42567b4b-33et-384r-5778-cg215d990e3c",
                column: "ConcurrencyStamp",
                value: "f4309d8d-eae8-4527-8c14-ad492a6a0cb6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52da7c94-9844-482c-8c09-c5c07bda12f1",
                column: "ConcurrencyStamp",
                value: "cad478f1-cad2-49ea-8844-f4d3e64b9799");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b1793f-2d1f-4e50-8af2-e266e1d78987",
                column: "ConcurrencyStamp",
                value: "451b2e1c-8806-4fd7-b368-529991b26c38");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94522b4b-23eb-344a-2278-cg215d880e3c",
                column: "ConcurrencyStamp",
                value: "2d898238-67c0-4abe-ac75-1a08704de76b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94570a4b-25ed-454a-8278-ca715d850e5c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f83c26e4-49df-4f1e-b936-d5d38b1035fe", "AQAAAAEAACcQAAAAEDrOSDDQJTunv0INnXMnE1J7UEmRZPTDBQVM/Syif684Kk26rYnlaUypH+9QHFQnXA==", "9a07956c-87cb-4d3d-bda9-bcdf2b3a5a9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a92589c-7415-4f0a-b98r-ad4d0d6iu174",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90ad2b1e-e7ef-4b55-aafa-fb9247d2cf80", "AQAAAAEAACcQAAAAEAw1RDE4ecN1c3xVLdnAAZVwUOZLEyOf8lTs/iST0Gfu3aPsigvMNDCZ9kQSrq9YGA==", "e07e576a-b596-48ac-99b1-a660d2c7c062" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42567b4b-33et-384r-5778-cg215d990e3c",
                column: "ConcurrencyStamp",
                value: "2b065a12-4fc4-441f-9e8a-8d25f87413bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52da7c94-9844-482c-8c09-c5c07bda12f1",
                column: "ConcurrencyStamp",
                value: "e21f14dc-cbfb-431f-b4a1-00b81326538e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b1793f-2d1f-4e50-8af2-e266e1d78987",
                column: "ConcurrencyStamp",
                value: "1cab7eae-2dbd-4f46-8dcf-8250ba5ed381");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94522b4b-23eb-344a-2278-cg215d880e3c",
                column: "ConcurrencyStamp",
                value: "f8ab1d1c-511f-4fc7-bc5f-e8c1b85e6b30");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94570a4b-25ed-454a-8278-ca715d850e5c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9156ac57-c9f3-41a9-9783-69b07c5cf7db", "AQAAAAEAACcQAAAAENSzlfopgshu+Cts+dJ74FS5mmOPcPNR7rXVsRDr43tdtQneOvpmZiTVFRQdBY8KbQ==", "6979e93f-7053-419d-bbd4-ec4ca1675367" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a92589c-7415-4f0a-b98r-ad4d0d6iu174",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd72e324-6823-4a71-a991-10cdbba5ff9c", "AQAAAAEAACcQAAAAEKW5UVr6D3N3cymXp1l01p/hv0wthrzB2XhOYJkuOTNqjIeiBJ+yF+/J4OUUYQiwdA==", "7b99162a-62ad-4e72-926e-30298cae40c4" });
        }
    }
}
