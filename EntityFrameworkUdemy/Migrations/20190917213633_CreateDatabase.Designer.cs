﻿// <auto-generated />
using System;
using EntityFrameworkUdemy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkUdemy.Migrations
{
    [DbContext(typeof(PlutoContext))]
    [Migration("20190917213633_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkUdemy.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("EntityFrameworkUdemy.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId");

                    b.Property<string>("Description");

                    b.Property<float>("FullPrice");

                    b.Property<int>("Level");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EntityFrameworkUdemy.CourseTag", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("TagId");

                    b.HasKey("CourseId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("CourseTag");
                });

            modelBuilder.Entity("EntityFrameworkUdemy.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("EntityFrameworkUdemy.Course", b =>
                {
                    b.HasOne("EntityFrameworkUdemy.Author", "Author")
                        .WithMany("Courses")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("EntityFrameworkUdemy.CourseTag", b =>
                {
                    b.HasOne("EntityFrameworkUdemy.Course", "Course")
                        .WithMany("CourseTags")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EntityFrameworkUdemy.Tag", "Tag")
                        .WithMany("CourseTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
