﻿// <auto-generated />
using System;
using Lesson29.HomeWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lesson29.HomeWork.Migrations
{
    [DbContext(typeof(FilmCatalogDbContext))]
    [Migration("20230215231542_Table_roles_fixed_field")]
    partial class Table_roles_fixed_field
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ActorFilm", b =>
                {
                    b.Property<int>("ActorsId")
                        .HasColumnType("integer");

                    b.Property<int>("FilmsId")
                        .HasColumnType("integer");

                    b.HasKey("ActorsId", "FilmsId");

                    b.HasIndex("FilmsId");

                    b.ToTable("ActorFilm", "public");
                });

            modelBuilder.Entity("Lesson29.HomeWork.DTO.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthday");

                    b.Property<DateTime?>("DateDeath")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_death");

                    b.Property<char>("Gender")
                        .HasColumnType("character(1)")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("last_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("actors", "public");
                });

            modelBuilder.Entity("Lesson29.HomeWork.DTO.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Budget")
                        .HasColumnType("numeric")
                        .HasColumnName("budget");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("name");

                    b.Property<int>("ProductionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductionId");

                    b.ToTable("films", "public");
                });

            modelBuilder.Entity("Lesson29.HomeWork.DTO.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("FilmId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("genres", "public");
                });

            modelBuilder.Entity("Lesson29.HomeWork.DTO.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("name_production");

                    b.Property<DateTime>("YearOfCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("year_of_created");

                    b.HasKey("Id");

                    b.ToTable("production", "public");
                });

            modelBuilder.Entity("Lesson29.HomeWork.DTO.ProductionAndFilm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FilmId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.HasIndex("ProductionId");

                    b.ToTable("production_film", "public");
                });

            modelBuilder.Entity("Lesson29.HomeWork.DTO.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ActorId")
                        .HasColumnType("integer");

                    b.Property<int>("FilmId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("FilmId");

                    b.ToTable("roles", "public");
                });

            modelBuilder.Entity("ActorFilm", b =>
                {
                    b.HasOne("Lesson29.HomeWork.DTO.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lesson29.HomeWork.DTO.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lesson29.HomeWork.DTO.Film", b =>
                {
                    b.HasOne("Lesson29.HomeWork.DTO.Production", "Production")
                        .WithMany("Films")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Production");
                });

            modelBuilder.Entity("Lesson29.HomeWork.DTO.Genre", b =>
                {
                    b.HasOne("Lesson29.HomeWork.DTO.Film", null)
                        .WithMany("Genres")
                        .HasForeignKey("FilmId");
                });

            modelBuilder.Entity("Lesson29.HomeWork.DTO.ProductionAndFilm", b =>
                {
                    b.HasOne("Lesson29.HomeWork.DTO.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lesson29.HomeWork.DTO.Production", "Production")
                        .WithMany()
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Production");
                });

            modelBuilder.Entity("Lesson29.HomeWork.DTO.Role", b =>
                {
                    b.HasOne("Lesson29.HomeWork.DTO.Actor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lesson29.HomeWork.DTO.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("Lesson29.HomeWork.DTO.Film", b =>
                {
                    b.Navigation("Genres");
                });

            modelBuilder.Entity("Lesson29.HomeWork.DTO.Production", b =>
                {
                    b.Navigation("Films");
                });
#pragma warning restore 612, 618
        }
    }
}
