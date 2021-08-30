﻿// <auto-generated />
using System;
using Grader.Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

namespace Grader.Api.Data.Migrations
{
    [DbContext(typeof(GraderDbContext))]
    [Migration("20210829115115_media")]
    partial class media
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Grader.Api.Data.Model.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("ImageId")
                        .HasColumnType("bigint")
                        .HasColumnName("image_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<NpgsqlTsVector>("SearchText")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tsvector")
                        .HasColumnName("search_text");

                    b.HasKey("Id")
                        .HasName("pk_category");

                    b.HasIndex("ImageId")
                        .HasDatabaseName("ix_category_image_id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("Grader.Api.Data.Model.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("ActiveFrom")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("active_from");

                    b.Property<DateTime>("ActiveTo")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("active_to");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)")
                        .HasColumnName("description");

                    b.Property<int>("MaxParticipants")
                        .HasColumnType("integer")
                        .HasColumnName("max_participants");

                    b.Property<int>("MinParticipants")
                        .HasColumnType("integer")
                        .HasColumnName("min_participants");

                    b.Property<DateTime>("RegistrationFrom")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registration_from");

                    b.Property<DateTime>("RegistrationTo")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registration_to");

                    b.Property<NpgsqlTsVector>("SearchText")
                        .HasColumnType("tsvector")
                        .HasColumnName("search_text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_course");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_course_category_id");

                    b.ToTable("course");
                });

            modelBuilder.Entity("Grader.Api.Data.Model.Lesson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint")
                        .HasColumnName("course_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)")
                        .HasColumnName("description");

                    b.Property<NpgsqlTsVector>("SearchText")
                        .HasColumnType("tsvector")
                        .HasColumnName("search_text");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("topic");

                    b.HasKey("Id")
                        .HasName("pk_lesson");

                    b.HasIndex("CourseId")
                        .HasDatabaseName("ix_lesson_course_id");

                    b.ToTable("lesson");
                });

            modelBuilder.Entity("Grader.Api.Data.Model.Media", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("Content")
                        .HasColumnType("bytea")
                        .HasColumnName("content");

                    b.Property<string>("Key")
                        .HasColumnType("text")
                        .HasColumnName("key");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Type")
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_media");

                    b.ToTable("media");
                });

            modelBuilder.Entity("Grader.Api.Data.Model.Category", b =>
                {
                    b.HasOne("Grader.Api.Data.Model.Media", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .HasConstraintName("fk_category_media_image_id");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Grader.Api.Data.Model.Course", b =>
                {
                    b.HasOne("Grader.Api.Data.Model.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_course_category_category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Grader.Api.Data.Model.Lesson", b =>
                {
                    b.HasOne("Grader.Api.Data.Model.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("fk_lesson_course_course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Grader.Api.Data.Model.Category", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Grader.Api.Data.Model.Course", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
