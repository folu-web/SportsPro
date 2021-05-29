using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsPro.Migrations
{
    public partial class Registration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "ID", "ProductID", "Name", "CustomerID", "FirstName", "LastName" },
                values: new object[] { 1, 1, "Draft Manager 1.0", 1002, "Ania", "Irvin" });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "ID", "ProductID", "Name", "CustomerID", "FirstName", "LastName" },
                values: new object[] { 2, 3, "League Scheduler 1.0", 1002, "Ania", "Irvin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");
        }
    }       
}
