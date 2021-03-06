﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesWebApp.Models.EntityFramework;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MoviesWebApp.Migrations
{
    [DbContext(typeof(FilmsDBContext))]
    partial class FilmsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MoviesWebApp.Models.EntityFramework.Compte", b =>
                {
                    b.Property<int>("CompteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CPT_ID")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CP")
                        .IsRequired()
                        .HasColumnName("CPT_CP")
                        .HasColumnType("char(5)");

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CPT_DATECREATION")
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("current_date");

                    b.Property<float?>("Latitude")
                        .HasColumnName("CPT_LATITUDE")
                        .HasColumnType("real");

                    b.Property<float?>("Longitude")
                        .HasColumnName("CPT_LONGITUDE")
                        .HasColumnType("real");

                    b.Property<string>("Mel")
                        .IsRequired()
                        .HasColumnName("CPT_MEL")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("CPT_NOM")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Pays")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CPT_PAYS")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50)
                        .HasDefaultValue("France");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnName("CPT_PRENOM")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Pwd")
                        .HasColumnName("CPT_PWD")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Rue")
                        .HasColumnName("CPT_RUE")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("TelPortable")
                        .HasColumnName("CPT_TELPORTABLE")
                        .HasColumnType("char(10)");

                    b.Property<string>("Ville")
                        .HasColumnName("CPT_VILLE")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("CompteId");

                    b.HasIndex("Mel")
                        .IsUnique()
                        .HasName("uq_cpt_mel");

                    b.ToTable("T_E_COMPTE_CPT");
                });

            modelBuilder.Entity("MoviesWebApp.Models.EntityFramework.Favori", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnName("FLM_ID")
                        .HasColumnType("integer");

                    b.Property<int>("CompteId")
                        .HasColumnName("CPT_ID")
                        .HasColumnType("integer");

                    b.HasKey("FilmId", "CompteId")
                        .HasName("pk_fav");

                    b.HasIndex("CompteId");

                    b.ToTable("T_J_FAVORI_FAV");
                });

            modelBuilder.Entity("MoviesWebApp.Models.EntityFramework.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FLM_ID")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateParution")
                        .HasColumnName("FLM_DATEPARUTION")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Duree")
                        .HasColumnName("FLM_DUREE")
                        .HasColumnType("bigint");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnName("FLM_GENRE")
                        .HasColumnType("text");

                    b.Property<string>("Synopsis")
                        .HasColumnName("FLM_SYNOPSIS")
                        .HasColumnType("text");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnName("FLM_TITRE")
                        .HasColumnType("text");

                    b.Property<string>("UrlPhoto")
                        .HasColumnName("FLM_URLPHOTO")
                        .HasColumnType("text");

                    b.HasKey("FilmId");

                    b.ToTable("T_E_FILM_FLM");
                });

            modelBuilder.Entity("MoviesWebApp.Models.EntityFramework.Favori", b =>
                {
                    b.HasOne("MoviesWebApp.Models.EntityFramework.Compte", "CompteFavori")
                        .WithMany("FavorisCompte")
                        .HasForeignKey("CompteId")
                        .HasConstraintName("fk_fav_cpt")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesWebApp.Models.EntityFramework.Film", "FilmFavori")
                        .WithMany("FavorisFilm")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("fk_fav_flm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
