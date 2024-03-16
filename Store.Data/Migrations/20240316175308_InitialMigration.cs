using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Identity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "StoreId", "StoreName" },
                values: new object[,]
                {
                    { "513f3677-0f9c-44a5-a9db-0439e74c356e", "add1be20-51a3-4a73-bc7b-be9509795ec0", "StoreB" },
                    { "a1e1e197-6306-4426-b0a8-cc09df953e32", "3602aee8-d325-4ca6-8390-395302b09a0f", "StoreA" },
                    { "a519ad44-cc1b-4ee6-acda-3509b7786584", "0d3f7b07-d26e-431f-b92c-7e1eeec96900", "StoreC" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Identity",
                table: "Stores",
                column: "Identity")
                .Annotation("SqlServer:Clustered", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
