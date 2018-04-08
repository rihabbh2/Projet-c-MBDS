using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Awale
{
    public class Joueur
    {
        public String Nom { get; set; }
        public int Score { get; set; }
        
        public Joueur()
        {
            Score = 0;
        }

        public Joueur(String nom)
        {
            Nom = nom;
            Score = 0;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
