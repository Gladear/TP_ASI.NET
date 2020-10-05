using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models.EntityFramework
{
    public class Favori
    {
        public int CompteId { get; set; }
        [Column("FLM_ID")]
        public int FilmId { get; set; }
        public virtual Compte CompteFavori { get; set; }
        public virtual Film FilmFavori { get; set; }
    }
}
