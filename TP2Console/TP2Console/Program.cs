using Microsoft.EntityFrameworkCore;
using Npgsql.TypeHandlers.GeometricHandlers;
using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using TP2Console.Models.EntityFramework;

namespace TP2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new FilmsDBContext();
            //Exo2Q1(ctx);
            //Exo2Q2(ctx);
            //Exo2Q3(ctx);
            //Exo2Q4(ctx);
            //Exo2Q5(ctx);
            //Exo2Q6(ctx);
            //Exo2Q7(ctx);
            //Exo2Q8(ctx);
            Exo2Q9(ctx);
            Console.ReadKey();
        }

        public static void Exo2Q1(FilmsDBContext ctx)
        {
            foreach (var film in ctx.Film)
            {
                Console.WriteLine(film.ToString());
            }
        }

        public static void Exo2Q2(FilmsDBContext ctx)
        {
            foreach (var u in ctx.Utilisateur)
            {
                Console.WriteLine(u.Email);
            }
        }

        public static void Exo2Q3(FilmsDBContext ctx)
        {
            foreach (var u in ctx.Utilisateur.OrderBy(u => u.Login))
            {
                Console.WriteLine(u);
            }
        }

        public static void Exo2Q4(FilmsDBContext ctx)
        {
            foreach (var f in ctx.Film.Where(f => f.CategorieNavigation.Nom == "Action"))
            {
                Console.WriteLine(f.Id + " : " + f.Nom);
            }
        }

        public static void Exo2Q5(FilmsDBContext ctx)
        {
            Console.WriteLine(ctx.Categorie.Count());
        }

        public static void Exo2Q6(FilmsDBContext ctx)
        {
            Console.WriteLine(ctx.Avis.Min(a => a.Note));
        }

        public static void Exo2Q7(FilmsDBContext ctx)
        {
            foreach (var f in ctx.Film.Where(f => f.Nom.ToUpper().StartsWith("LE")))
            {
                Console.WriteLine(f);
            }
        }

        public static void Exo2Q8(FilmsDBContext ctx)
        {
            Console.WriteLine(ctx.Avis.Where(a => a.FilmNavigation.Nom.ToUpper().Equals("PULP FICTION")).Average(a => a.Note));
        }

        public static void Exo2Q9(FilmsDBContext ctx)
        {
            Console.WriteLine(ctx.Avis.OrderByDescending(a => a.Note).First().UtilisateurNavigation);
        }
    }
}
