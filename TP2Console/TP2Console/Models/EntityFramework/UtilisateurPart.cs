using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Console.Models.EntityFramework
{
    public partial class Utilisateur
    {
        public override string ToString()
        {
            return "Utilisateur{login=" + Login + ";email=" + Email + "}";
        }
    }
}
