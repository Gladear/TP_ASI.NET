using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Console.Models.EntityFramework
{
    public partial class Film
    {
        public override string ToString()
        {
            return "Film{nom=" + Nom + "}";
        }
    }
}
