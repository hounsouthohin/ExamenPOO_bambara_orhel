using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenFinal
{
    internal class InstrumentCorde
    {
        public string Nom { get; set; }
        public int Prix { get; set; }
        public Corde Corde { get; set; }
        public int NbCordes { get; set; }
        

        public InstrumentCorde(string nom,int nbCordes)
        {
            Nom = nom;
            Corde = new Corde();
            Prix = Corde.Resistance * 200;
            NbCordes = nbCordes;
        }
        
        
        public override string ToString()
        {
            return $"{Nom}, Prix achat : {Prix}, corde :{Corde} ";

        }
    }
}
