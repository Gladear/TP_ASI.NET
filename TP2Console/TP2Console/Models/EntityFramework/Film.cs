using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2Console.Models.EntityFramework
{
    [Table("film")]
    public partial class Film
    {
        public Film()
        {
            Avis = new HashSet<Avis>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nom")]
        [StringLength(50)]
        public string Nom { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("categorie")]
        public int Categorie { get; set; }

        [ForeignKey(nameof(Categorie))]
        [InverseProperty("Film")]
        public virtual Categorie CategorieNavigation { get; set; }
        [InverseProperty("FilmNavigation")]
        public virtual ICollection<Avis> Avis { get; set; }
    }
}
