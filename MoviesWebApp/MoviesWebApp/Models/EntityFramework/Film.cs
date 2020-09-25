using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models.EntityFramework
{
    [Table("T_E_FILM_FLM")]
    public class Film
    {
        public Film()
        {
            FavorisFilm = new HashSet<Favori>();
        }

        [Key]
        [Column("FLM_ID")]
        public int FilmId { get; set; }

        [Required]
        [Column("FLM_TITRE")]
        public string Titre { get; set; }
        [Column("FLM_SYNOPSIS")]
        public string Synopsis { get; set; }
        [Required]
        [Column("FLM_DATEPARUTION")]
        public DateTime DateParution { get; set; }
        [Required]
        [Column("FLM_DUREE")]
        public long Duree { get; set; }
        [Required]
        [Column("FLM_GENRE")]
        public string Genre { get; set; }
        [Column("FLM_URLPHOTO")]
        public string UrlPhoto { get; set; }
        [InverseProperty("FilmFavori")]
        public virtual ICollection<Favori> FavorisFilm { get; set; }
    }
}
