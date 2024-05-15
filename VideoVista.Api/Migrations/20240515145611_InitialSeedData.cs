using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoVista.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VideoMetadatas",
                columns: new[] { "Id", "BlobPath", "CreatedDate", "Discription", "ThubNail", "Title", "UpdatedDate" },
                values: new object[] { new Guid("47729a8b-e359-493e-a982-e7c818cd1220"), "path", new DateTimeOffset(new DateTime(2024, 5, 15, 19, 56, 10, 58, DateTimeKind.Unspecified).AddTicks(5563), new TimeSpan(0, 5, 0, 0, 0)), "FirstDiscription", "thubnail", "Title", new DateTimeOffset(new DateTime(2024, 5, 15, 19, 56, 10, 58, DateTimeKind.Unspecified).AddTicks(5591), new TimeSpan(0, 5, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VideoMetadatas",
                keyColumn: "Id",
                keyValue: new Guid("47729a8b-e359-493e-a982-e7c818cd1220"));
        }
    }
}
