using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenFinal
{
    enum typeG
    {
        Acoustique,
        Basse,
        Electrique
    }
    internal class Guitare : InstrumentCorde
    {
        public int NbCordes { get; set; }
        public typeG TypeG { get; set; }

        public Guitare(typeG typeG, string nom, Corde corde, int nbCordes = 6) : base (nom,nbCordes)
        {
            NbCordes = nbCordes;
            TypeG = typeG;
        }
        public override string ToString()
        {
            return $"Nombre de cordes : {NbCordes} ;  Nom : {Nom}";
        }
    }
}
