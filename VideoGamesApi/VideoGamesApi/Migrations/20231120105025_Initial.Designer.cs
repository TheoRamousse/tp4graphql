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
    [Migration("20231120105025_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("EditorGame", b =>
                {
                    b.Property<int>("EditorsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EditorsId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("EditorGame");
                });

            modelBuilder.Entity("GameStudio", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudiosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GamesId", "StudiosId");

                    b.HasIndex("StudiosId");

                    b.ToTable("GameStudio");
                });

            modelBuilder.Entity("VideoGamesApi.Models.Editor", b =>
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

            modelBuilder.Entity("VideoGamesApi.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("VideoGamesApi.Models.StringEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("String")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("GameId1");

                    b.ToTable("StringEntity");
                });

            modelBuilder.Entity("VideoGamesApi.Models.Studio", b =>
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

            modelBuilder.Entity("EditorGame", b =>
                {
                    b.HasOne("VideoGamesApi.Models.Editor", null)
                        .WithMany()
                        .HasForeignKey("EditorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoGamesApi.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameStudio", b =>
                {
                    b.HasOne("VideoGamesApi.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoGamesApi.Models.Studio", null)
                        .WithMany()
                        .HasForeignKey("StudiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VideoGamesApi.Models.StringEntity", b =>
                {
                    b.HasOne("VideoGamesApi.Models.Game", null)
                        .WithMany("Genres")
                        .HasForeignKey("GameId");

                    b.HasOne("VideoGamesApi.Models.Game", null)
                        .WithMany("Platforms")
                        .HasForeignKey("GameId1");
                });

            modelBuilder.Entity("VideoGamesApi.Models.Game", b =>
                {
                    b.Navigation("Genres");

                    b.Navigation("Platforms");
                });
#pragma warning restore 612, 618
        }
    }
}