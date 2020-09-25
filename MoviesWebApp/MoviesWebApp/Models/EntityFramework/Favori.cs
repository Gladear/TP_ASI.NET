using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesWebApp.Models.EntityFramework
{
    [Table("T_J_FAVORI_FAV")]
    public class Favori
    {
        [Column("CPT_ID")]
        public int CompteId { get; set; }
        [Column("FLM_ID")]
        public int FilmId { get; set; }
        [InverseProperty("FavorisCompte")]
        [ForeignKey("CompteId")]
        [JsonIgnore]
        public virtual Compte CompteFavori { get; set; }
        [InverseProperty("FavorisFilm")]
        [ForeignKey("FilmId")]
        [JsonIgnore]
        public virtual Film FilmFavori { get; set; }
    }
}
