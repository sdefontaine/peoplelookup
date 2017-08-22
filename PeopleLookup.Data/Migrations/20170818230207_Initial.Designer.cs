using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PeopleLookup.Data;

namespace PeopleLookup.Data.Migrations
{
    [DbContext(typeof(PeopleContext))]
    [Migration("20170818230207_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PeopleLookup.Data.Person", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("First")
                        .HasMaxLength(50);

                    b.Property<string>("Last")
                        .HasMaxLength(50);

                    b.Property<string>("MI")
                        .HasMaxLength(1);

                    b.Property<string>("Phone_Number")
                        .HasColumnName("Phone Number")
                        .HasMaxLength(20);

                    b.Property<string>("State")
                        .HasMaxLength(2);

                    b.Property<string>("Street_1")
                        .HasColumnName("Street 1")
                        .HasMaxLength(100);

                    b.Property<string>("Street_2")
                        .HasColumnName("Street 2")
                        .HasMaxLength(100);

                    b.Property<string>("Zip_Code")
                        .HasColumnName("Zip Code")
                        .HasMaxLength(20);

                    b.Property<string>("email_address")
                        .HasColumnName("email address")
                        .HasMaxLength(100);

                    b.Property<string>("gender")
                        .HasMaxLength(50);

                    b.Property<string>("suffix")
                        .HasMaxLength(10);

                    b.Property<string>("title")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.ToTable("Person");
                });
        }
    }
}
