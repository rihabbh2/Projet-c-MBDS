using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Awale
{
    public class Hole1
    {
        public int NbrBilles { get; set; }

        public Hole1()
        {
            NbrBilles = 4;
        }

        public Hole1(int nbr)
        {
            NbrBilles = nbr;
        }
        public void Ajoutbille()
        {
            NbrBilles= NbrBilles + 1;
        }

        public void Viderbilles()
        {
            NbrBilles =0;
        }

        public override string ToString()
        {
            return NbrBilles.ToString() ;
        }
    }


}
