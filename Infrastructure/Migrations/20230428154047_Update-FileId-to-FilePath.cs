using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFileIdtoFilePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileID",
                table: "Tasks",
                newName: "FilePath");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42567b4b-33et-384r-5778-cg215d990e3c",
                column: "ConcurrencyStamp",
                value: "b8c4a108-74e4-44fa-b393-e6185a3b23ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52da7c94-9844-482c-8c09-c5c07bda12f1",
                column: "ConcurrencyStamp",
                value: "ab7c3a93-f3b5-4fc5-b4cb-65b93ec98b4a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b1793f-2d1f-4e50-8af2-e266e1d78987",
                column: "ConcurrencyStamp",
                value: "3eab20e0-ea0d-4bb7-bd23-169da1e9af08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94522b4b-23eb-344a-2278-cg215d880e3c",
                column: "ConcurrencyStamp",
                value: "22f7e896-fba7-4b22-8673-6c9ae5edd232");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94570a4b-25ed-454a-8278-ca715d850e5c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd9f5c55-2c74-4adb-a48d-685f7b3e893f", "AQAAAAEAACcQAAAAED6IKD2AEG7DF8BTeIOT+17e3bpGvV0N2fnZST+BhAskAhc4c+37JCJmGkRRuWN2/A==", "bc8f7881-3524-4348-9012-827f3a585322" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a92589c-7415-4f0a-b98r-ad4d0d6iu174",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c0f2bf9-7c11-494a-acb6-808246d98187", "AQAAAAEAACcQAAAAEDeBg73/u2IJ4bDwqdbz26dNHy4n967Itltp+9ayRUc+ss48s/bcbfPaDIgvqVbzTw==", "dacf3cff-d529-478a-bc81-4e67b51edce5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Tasks",
                newName: "FileID");

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
    }
}
