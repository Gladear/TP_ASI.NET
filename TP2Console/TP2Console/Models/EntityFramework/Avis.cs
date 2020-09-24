using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2Console.Models.EntityFramework
{
    [Table("avis")]
    public partial class Avis
    {
        [Key]
        [Column("film")]
        public int Film { get; set; }
        [Key]
        [Column("utilisateur")]
        public int Utilisateur { get; set; }
        [Column("avis")]
        public string Avis1 { get; set; }
        [Column("note", TypeName = "numeric")]
        public decimal Note { get; set; }

        [ForeignKey(nameof(Film))]
        [InverseProperty("Avis")]
        public virtual Film FilmNavigation { get; set; }
        [ForeignKey(nameof(Utilisateur))]
        [InverseProperty("Avis")]
        public virtual Utilisateur UtilisateurNavigation { get; set; }
    }
}
