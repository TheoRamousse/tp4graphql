﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoGamesApi.Data;

#nullable disable

namespace VideoGamesApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231120152644_ChangeListOfStringEntitiesBystring")]
    partial class ChangeListOfStringEntitiesBystring
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("EditorEntityGameEntity", b =>
                {
                    b.Property<int>("EditorsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EditorsId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("EditorEntityGameEntity");
                });

            modelBuilder.Entity("GameEntityStudioEntity", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudiosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GamesId", "StudiosId");

                    b.HasIndex("StudiosId");

                    b.ToTable("GameEntityStudioEntity");
                });

            modelBuilder.Entity("VideoGamesApi.Entities.EditorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Editor");
                });

            modelBuilder.Entity("VideoGamesApi.Entities.GameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Platforms")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("VideoGamesApi.Entities.StudioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Studio");
                });

            modelBuilder.Entity("EditorEntityGameEntity", b =>
                {
                    b.HasOne("VideoGamesApi.Entities.EditorEntity", null)
                        .WithMany()
                        .HasForeignKey("EditorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoGamesApi.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameEntityStudioEntity", b =>
                {
                    b.HasOne("VideoGamesApi.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoGamesApi.Entities.StudioEntity", null)
                        .WithMany()
                        .HasForeignKey("StudiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}