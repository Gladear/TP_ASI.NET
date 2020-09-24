using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TP2Console.Models.EntityFramework;

namespace TP2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new FilmsDBContext())
            {
                //Chargement de la catégorie Action
                Categorie categorieAction = ctx.Categorie.First(c => c.Nom == "Action");
                Console.WriteLine("Categorie : " + categorieAction);
                Console.WriteLine("Films : ");
                //Chargement des films de la catégorie Action.
                foreach (var film in categorieAction.Film) // lazy loading initiated
                {
                    Console.WriteLine(film);
                }
            }
        }
    }
}
