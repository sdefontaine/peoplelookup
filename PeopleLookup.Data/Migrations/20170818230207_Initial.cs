using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PeopleLookup.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    First = table.Column<string>(maxLength: 50, nullable: true),
                    Last = table.Column<string>(maxLength: 50, nullable: true),
                    MI = table.Column<string>(maxLength: 1, nullable: true),
                    PhoneNumber = table.Column<string>(name: "Phone Number", maxLength: 20, nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    Street1 = table.Column<string>(name: "Street 1", maxLength: 100, nullable: true),
                    Street2 = table.Column<string>(name: "Street 2", maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(name: "Zip Code", maxLength: 20, nullable: true),
                    emailaddress = table.Column<string>(name: "email address", maxLength: 100, nullable: true),
                    gender = table.Column<string>(maxLength: 50, nullable: true),
                    suffix = table.Column<string>(maxLength: 10, nullable: true),
                    title = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
