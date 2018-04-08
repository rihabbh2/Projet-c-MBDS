using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Projet_Awale
{
    class Gestion
    {

        private static Gestion instance;
        public static Gestion getInstance()
        {
            if (instance == null)
                instance = new Gestion();
            return instance;
        }
        public Joueur Joueur1 { get; set; }
        public Joueur Joueur2 { get; set; }




        Gestion()
        {
           
            
        }


        public void setJoueur1(Joueur j )
        {
            Joueur1 = j; 
        }


        public void setJoueur2(Joueur j)
        {
            Joueur2 = j;
        }

    }
}

