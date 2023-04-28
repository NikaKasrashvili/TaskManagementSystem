using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Dropcolumnfromtasktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42567b4b-33et-384r-5778-cg215d990e3c",
                column: "ConcurrencyStamp",
                value: "34011801-431f-4155-90d5-046deae61539");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52da7c94-9844-482c-8c09-c5c07bda12f1",
                column: "ConcurrencyStamp",
                value: "61fc080a-1758-4a13-b6f2-e522cbeb458b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b1793f-2d1f-4e50-8af2-e266e1d78987",
                column: "ConcurrencyStamp",
                value: "d2098ba9-7fe2-4936-b4e8-0933504f7c71");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94522b4b-23eb-344a-2278-cg215d880e3c",
                column: "ConcurrencyStamp",
                value: "7ebf40cf-b810-46ba-b68f-4a5486802e32");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94570a4b-25ed-454a-8278-ca715d850e5c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f734f93b-984c-49e9-bdb6-28d30abf94a7", "AQAAAAEAACcQAAAAEG92KyHUBqBm1HDuzet3g6ohS8N6Z7lgzxciDr2ezHejBSqMxblAt2dGZYvCTjZ76w==", "8c7e5fd6-6961-4b30-b57f-3076b886ffbd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a92589c-7415-4f0a-b98r-ad4d0d6iu174",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08d155fe-55ad-4cfa-b46e-3ced3f144a2d", "AQAAAAEAACcQAAAAEG9TXBPt/i+/KcHdO8gJr73I6Mkx+cIebgvPFoo80EXXKrH8Ns0j05fdPAofkwP/tQ==", "eadca36d-6695-4492-87bf-7aa4d9ab6a42" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
