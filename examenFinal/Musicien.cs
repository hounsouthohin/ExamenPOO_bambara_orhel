using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenFinal
{
    enum Statut
    {
        debutant,
        intermediaire,
        pro
    }
    internal class Musicien
    {
        public string Nom { set; get; }
        public InstrumentCorde Preference { set; get; }
        public int Niveau { set; get; }
        public int Exp { set; get; }
        public int Montant { set; get; }
        public Statut Statut { set; get; }
        public PieceMusique Piece { set; get; }
        public List<PieceMusique> Pieces { set; get; }

        public Musicien(string nom, InstrumentCorde preference, int niveau, int exp, int montant, Statut statut, PieceMusique piece)
        {
            Nom = nom;
            Preference = preference;
            Niveau = niveau;
            Exp = exp;
            Montant = montant;
            Piece = piece;
            Piece.Diff = Experience.facile;
            Statut = statut;
        }
        public string ObtenirInfoInstru()
        {
            string info = $"Prix:{Preference.Prix}\nInfo Corde:\nResistance:{Preference.Corde.Resistance}\nDurabilite:{Preference.Corde.Durabilite}";
            return info;
        }
        public void ChangerNiveau()
        {
            if (100 * Niveau <= Exp && Statut == Statut.debutant) { Statut = Statut.intermediaire; Niveau = 0; }
            else if (100 * Niveau <= Exp && Statut == Statut.intermediaire)
            {
                Statut = Statut.pro; Niveau = 0;
            }
        }
        public void AcheterPiece(PieceMusique piece) { Pieces.Add(piece); }

        public override string ToString()
        {
            return $"{Nom} ; preference : {Preference}, niveau : {Niveau},experience : {Exp}, statut : {Statut},montant : {Montant},Piece:{Piece}";
        }

    }


}
