using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PeopleLookup.Data;

namespace PeopleLookup.Data.Migrations
{
    [DbContext(typeof(PeopleContext))]
    [Migration("20170821150641_v1")]
    partial class v1
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

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<int>("Age");

                    b.Property<string>("First")
                        .HasMaxLength(50);

                    b.Property<string>("Interests")
                        .HasMaxLength(200);

                    b.Property<string>("Last")
                        .HasMaxLength(50);

                    b.Property<string>("Picture")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Person");
                });
        }
    }
}
