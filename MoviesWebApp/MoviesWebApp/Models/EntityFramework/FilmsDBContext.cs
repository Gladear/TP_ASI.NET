using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApp.Models.EntityFramework
{
    public partial class FilmsDBContext : DbContext
    {
        public FilmsDBContext()
        {

        }

        public FilmsDBContext(DbContextOptions<FilmsDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Compte> Compte { get; set; }
        public virtual DbSet<Favori> Favori { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=FilmsDBTP3; uid=postgres; password=postgres;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compte>(entity =>
            {
                entity.HasIndex(c => c.Mel)
                    .IsUnique()
                    .HasName("uq_cpt_mel");

                entity.Property(c => c.Pays)
                    .HasDefaultValue("France");

                entity.Property(c => c.DateCreation)
                    .HasDefaultValueSql("current_date");
            });

            modelBuilder.Entity<Favori>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.CompteId })
                    .HasName("pk_fav");

                entity.HasOne(f => f.FilmFavori)
                    .WithMany(f => f.FavorisFilm)
                    .HasForeignKey(f => f.FilmId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_fav_flm");

                entity.HasOne(f => f.CompteFavori)
                    .WithMany(c => c.FavorisCompte)
                    .HasForeignKey(f => f.CompteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_fav_cpt");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
