using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenFinal
{
    internal class Corde
    {
        public int Resistance { get; set; }
        public int Durabilite { get; set; }

        Random rnd;
        public Corde()
        {
            rnd = new Random();
            Resistance = rnd.Next(1, 11);
            Durabilite = Resistance * 2;


        }
        public static bool operator <(Corde a, Corde b) { return a.Resistance < b.Resistance; }
        public static bool operator >(Corde a, Corde b) { return a.Resistance < b.Resistance; }
        public override string ToString()
        {
            return $"Resistance : {Resistance}";
        }
    }
}
