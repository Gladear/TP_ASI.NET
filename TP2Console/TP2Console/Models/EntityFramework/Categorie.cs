using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2Console.Models.EntityFramework
{
    [Table("categorie")]
    public partial class Categorie
    {
        //private ILazyLoader _lazyLoader;

        public Categorie()
        {
            Film = new HashSet<Film>();
        }

        //public Categorie(ILazyLoader lazyLoader)
        //{
        //    _lazyLoader = lazyLoader;
        //}

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nom")]
        [StringLength(50)]
        public string Nom { get; set; }
        [Column("description")]
        public string Description { get; set; }

        //private ICollection<Film> film;
        [InverseProperty("CategorieNavigation")]
        public virtual ICollection<Film> Film
        {
            get;
            set;
        }
        //{
        //    get { return _lazyLoader.Load(this, ref film); }
        //    set { film = value; }
        //}
    }
}
