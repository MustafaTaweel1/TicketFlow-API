using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs.Migrations
{
    /// <inheritdoc />
    public partial class addtablepasswordreset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "password_resets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_password_resets", x => x.id);
                });

			migrationBuilder.CreateTable(
				name: "users",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					email = table.Column<string>(type: "nvarchar(max)", nullable: false),
					name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_users", x => x.id);
				});
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "password_resets");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
