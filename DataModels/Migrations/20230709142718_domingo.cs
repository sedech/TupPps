using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataModels.Migrations
{
    /// <inheritdoc />
    public partial class domingo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "Admin", "ADMIN" },
                    { "601f0ede-374e-45f0-9373-50cba7a8183e", "601f0ede-374e-45f0-9373-50cba7a8183e", "Cliente", "CLIENTE" },
                    { "65450c8a-1e5b-11ee-be56-0242ac120002", "65450c8a-1e5b-11ee-be56-0242ac120002", "Vendedor", "VENDEDOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole");
        }
    }
}
