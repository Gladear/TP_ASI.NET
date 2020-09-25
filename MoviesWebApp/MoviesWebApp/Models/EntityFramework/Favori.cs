using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models.EntityFramework
{
    [Table("T_J_FAVORI_FAV")]
    public class Favori
    {
        [Key]
        [Column("CPT_ID")]
        public int CompteId { get; set; }
        [Key]
        [Column("FLM_ID")]
        public int FilmId { get; set; }
        [ForeignKey(nameof(Compte))]
        [InverseProperty("FavorisCompte")]
        public virtual Compte CompteFavori { get; set; }
        [ForeignKey(nameof(Film))]
        [InverseProperty("FavorisFilm")]
        public virtual Film FilmFavori { get; set; }
    }
}
