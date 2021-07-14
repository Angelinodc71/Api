﻿// <auto-generated />
using System;
using Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Migrations
{
    [DbContext(typeof(MovieInfoContext))]
    [Migration("20210714085830_SampleDataInMovieInfoContext")]
    partial class SampleDataInMovieInfoContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Api.Entities.Cast", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("character")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("movieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("movieId");

                    b.ToTable("Casts");

                    b.HasData(
                        new
                        {
                            id = 1,
                            character = "The Butcher",
                            movieId = 1,
                            name = "Daniel Day-Lewis"
                        },
                        new
                        {
                            id = 2,
                            character = "Amsterdam Vallon",
                            movieId = 1,
                            name = "Leonardo DiCaprio"
                        },
                        new
                        {
                            id = 3,
                            character = "Priest Vallon",
                            movieId = 1,
                            name = "Liam Neeson"
                        },
                        new
                        {
                            id = 4,
                            character = "Forrest Gump",
                            movieId = 2,
                            name = "Tom Hanks"
                        },
                        new
                        {
                            id = 5,
                            character = "Teniente Dan",
                            movieId = 2,
                            name = "Gary Sinise"
                        },
                        new
                        {
                            id = 6,
                            character = "Jenny curran",
                            movieId = 2,
                            name = "Robin Wright"
                        },
                        new
                        {
                            id = 7,
                            character = "Travis Bickle",
                            movieId = 3,
                            name = "Robert De Niro"
                        },
                        new
                        {
                            id = 8,
                            character = "Passenger",
                            movieId = 3,
                            name = "Martin scorsese"
                        },
                        new
                        {
                            id = 9,
                            character = "Iris",
                            movieId = 3,
                            name = "Jodie Foster"
                        });
                });

            modelBuilder.Entity("Api.Entities.Movie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            id = 1,
                            description = "Gangs of New York ye una película histórica del añu 2002 dirixida por Martin Scorsese",
                            name = "Pandillas de nueva york"
                        },
                        new
                        {
                            id = 2,
                            description = "Es un chico que sufre un cierto retraso mental. A pesar de todo, gracias a su tenacidad y a su buen corazón será protagonista de acontecimientos cruciales de su país",
                            name = "Forrest Gump"
                        },
                        new
                        {
                            id = 3,
                            description = "Ambientada en la Nueva York de la década de 1970, poco después de que terminara la guerra de Vietnam, se centra en la vida de Travis Bickle, un excombatiente solitario e inestable que debido a su insomnio crónico comienza a trabajar como taxista,",
                            name = "Taxi Driver"
                        });
                });

            modelBuilder.Entity("Api.Entities.Cast", b =>
                {
                    b.HasOne("Api.Entities.Movie", "Movie")
                        .WithMany("Casts")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Api.Entities.Movie", b =>
                {
                    b.Navigation("Casts");
                });
#pragma warning restore 612, 618
        }
    }
}