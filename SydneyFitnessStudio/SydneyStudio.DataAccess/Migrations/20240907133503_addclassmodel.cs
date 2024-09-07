using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SydneyStudio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addclassmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Do Pilates to stay healthy for a long time.", "Pilates" },
                    { 2, "Do yoga to be in sync with nature.", "Yoga" },
                    { 3, "Do High Intensity Workout to gain Muscles.", "HIW" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
