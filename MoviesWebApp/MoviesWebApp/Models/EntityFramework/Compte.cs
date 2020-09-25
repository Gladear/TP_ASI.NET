using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models.EntityFramework
{
    [Table("T_E_COMPTE_CPT")]
    public class Compte
    {
        public Compte()
        {
            FavorisCompte = new HashSet<Favori>();
        }

        [Key]
        [Column("CPT_ID")]
        public int CompteId { get; set; }
        [Required]
        [StringLength(50)]
        [Column("CPT_NOM")]
        public string Nom { get; set; }
        [Required]
        [StringLength(50)]
        [Column("CPT_PRENOM")]
        public string Prenom { get; set; }
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Invalid phone number")]
        [Column("CPT_TELPORTABLE", TypeName = "char(10)")]
        public string TelPortable { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Email length must be between 6 and 100")]
        [Column("CPT_MEL")]
        public string Mel { get; set; }
        [StringLength(64)]
        [Column("CPT_PWD")]
        public string Pwd { get; set; }
        [StringLength(200)]
        [Column("CPT_RUE")]
        public string Rue { get; set; }
        [Required]
        [StringLength(5, ErrorMessage = "Invalid postal code")]
        [Column("CPT_CP", TypeName = "char(5)")]
        public string CP { get; set; }
        [StringLength(50)]
        [Column("CPT_VILLE")]
        public string Ville { get; set; }
        [StringLength(50)]
        [Column("CPT_PAYS")]
        public string Pays { get; set; }
        [Column("CPT_LATITUDE")]
        public float? Latitude { get; set; }
        [Column("CPT_LONGITUDE")]
        public float? Longitude { get; set; }
        [Required]
        [Column("CPT_DATECREATION")]
        public DateTime DateCreation { get; set; }
        [InverseProperty("CompteFavori")]
        public virtual ICollection<Favori> FavorisCompte { get; set; }
    }
}
