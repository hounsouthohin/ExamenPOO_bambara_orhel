using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenFinal
{
    enum TypeVilon
    {
        Guarneri,
        Stradivarius,
        Amati,
        Giuseppe
    }
    internal class Violon : InstrumentCorde
    {
        public string Nom { set; get; }
        public Violon(string nom, Corde corde, int nbCordes) : base (nom,nbCordes)
        {
            Nom = "Violon" + nom;
        }
        public override string ToString()
        {
            return $"{Nom}";
        }
    }
}
