using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42567b4b-33et-384r-5778-cg215d990e3c", "2b065a12-4fc4-441f-9e8a-8d25f87413bf", false, "User", "USER" },
                    { "52da7c94-9844-482c-8c09-c5c07bda12f1", "e21f14dc-cbfb-431f-b4a1-00b81326538e", false, "Creator", "CREATOR" },
                    { "64b1793f-2d1f-4e50-8af2-e266e1d78987", "1cab7eae-2dbd-4f46-8dcf-8250ba5ed381", false, "Moderator", "MODERATOR" },
                    { "94522b4b-23eb-344a-2278-cg215d880e3c", "f8ab1d1c-511f-4fc7-bc5f-e8c1b85e6b30", false, "Admin", "ADMIN" }
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "42567b4b-33et-384r-5778-cg215d990e3c", "94570a4b-25ed-454a-8278-ca715d850e5c" },
                    { "94522b4b-23eb-344a-2278-cg215d880e3c", "9a92589c-7415-4f0a-b98r-ad4d0d6iu174" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52da7c94-9844-482c-8c09-c5c07bda12f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b1793f-2d1f-4e50-8af2-e266e1d78987");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "42567b4b-33et-384r-5778-cg215d990e3c", "94570a4b-25ed-454a-8278-ca715d850e5c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94522b4b-23eb-344a-2278-cg215d880e3c", "9a92589c-7415-4f0a-b98r-ad4d0d6iu174" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42567b4b-33et-384r-5778-cg215d990e3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94522b4b-23eb-344a-2278-cg215d880e3c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94570a4b-25ed-454a-8278-ca715d850e5c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f44689b9-26e3-41ef-9f6e-d15151cb3ff7", "AQAAAAEAACcQAAAAEK4if41Ttwgc6Sn9PRKLK//q+RLREOGYcirMSSd1Jwy68Ei9cCgc/4Xy96r4khKkzQ==", "12626f40-925c-4bff-9bf4-51c6be88a2aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a92589c-7415-4f0a-b98r-ad4d0d6iu174",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5beb8954-178f-418d-b8ac-ac0fa59b6895", "AQAAAAEAACcQAAAAED4cTKVxos6iBzd9LmqRPwKUWzJXgVS0rFBUl35aWNURm5TKjDW+9hQszDBNFqF6NQ==", "d005844d-0eb3-4c3b-a3f3-985ced89c060" });
        }
    }
}
