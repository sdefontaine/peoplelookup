using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleLookup.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MI",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Phone Number",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Street 1",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Street 2",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Zip Code",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "suffix",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Person",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "email address",
                table: "Person",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Person",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "Person",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Person",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Person",
                newName: "email address");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Person",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MI",
                table: "Person",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone Number",
                table: "Person",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Person",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street 1",
                table: "Person",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street 2",
                table: "Person",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip Code",
                table: "Person",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "suffix",
                table: "Person",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Person",
                maxLength: 10,
                nullable: true);
        }
    }
}
