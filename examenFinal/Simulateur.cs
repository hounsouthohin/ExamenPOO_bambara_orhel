using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace examenFinal
{
    internal class Simulateur
    {
        const string STATUT = "S";
        const string PRATIQUER = "";
        const string REPARATION = "R";
        const string Achat = "A";
        const string JOUER = "J";
        
        public Musicien Musicien { get; set; }
        public InstrumentCorde Meilleurinstrument { get; set; }
        List<InstrumentCorde> instruments;
        List<PieceMusique> Pieces { get; set; }
        Random rnd;
        int choix;
        public Simulateur(Musicien musicien)
        {
            instruments = new List<InstrumentCorde>()
            {
                new Violon("vlx",new Corde(),8),
                new Violon("xls",new Corde(),5),
                new Guitare(typeG.Electrique,"rock",new Corde(),12),
                 new Guitare(typeG.Acoustique,"guitare",new Corde(),11),
                  new Guitare(typeG.Basse,"rocky",new Corde(),15),
            };
            Pieces = new List<PieceMusique>()
            {
                new PieceMusique(45, 150, 5000, Experience.moyen),
                new PieceMusique(40, 180, 5500, Experience.difficile),
                new PieceMusique(60, 90, 4500, Experience.facile),
                new PieceMusique(55, 140, 6200, Experience.moyen),
                new PieceMusique(35, 200, 5300, Experience.difficile),
                new PieceMusique(65, 100, 4000, Experience.facile),
                new PieceMusique(52, 130, 6100, Experience.moyen),
                new PieceMusique(38, 170, 5600, Experience.difficile)
            };
            Musicien = musicien;
            rnd = new Random();
            choix = rnd.Next(Pieces.Count());
        }
        public InstrumentCorde DeterminerMeilleurIntru()
        {
            foreach (InstrumentCorde instr in instruments) { Console.WriteLine(instr); }

            InstrumentCorde meilleur = instruments[0];
            for (int i = 1; i < instruments.Count(); i++)
            {
                if (meilleur.Corde < instruments[i].Corde) { meilleur = instruments[i]; }
            }
            Console.WriteLine($"Meilleur instrument :{meilleur}");
            return meilleur;
        }
        public void AfficherMusicien() { Console.WriteLine(Musicien); }
        public void Pratiquer()
        {
            InstrumentCorde instru = DeterminerMeilleurIntru();
            Console.WriteLine();
            Console.WriteLine("Les pieces disponibles");
            foreach (PieceMusique piece in Pieces) { Console.WriteLine(piece); }
            PieceMusique pieceChoisie = Pieces[choix];
            Musicien.Exp += pieceChoisie.QtExp;
            while (instru.Corde.Durabilite < 0) { instru.Corde.Durabilite -= 10; }
            throw new Exception("La corde n'a plus de durabilite");

        }
        public void ReparerInstru()
        {
            InstrumentCorde instru = DeterminerMeilleurIntru();
            instru.Corde.Durabilite = instru.Corde.Resistance * 2;
        }
        public void AcheterPiece()
        {
            List<PieceMusique> nouvellesPieces = new List<PieceMusique>()
            {
                new PieceMusique(42, 110, 5900, Experience.facile),
                new PieceMusique(48, 150, 5800, Experience.moyen),
                new PieceMusique(37, 160, 5400, Experience.difficile),
            };
            foreach (PieceMusique piece in nouvellesPieces)
            {
                if (Musicien.Montant > piece.Prix)
                {
                    Musicien.AcheterPiece(piece);
                    Musicien.Montant -= piece.Prix;
                    Console.WriteLine($"piece achetee : {piece}");
                }
                else
                {
                    Console.WriteLine("Pas assez d'argent");
                }
                Console.WriteLine(piece);
            }
            Console.WriteLine();
        }
        public void Jouer()
        {
            InstrumentCorde instru = DeterminerMeilleurIntru();
            Console.WriteLine();
            Console.WriteLine("Les pieces disponibles");
            foreach (PieceMusique piece in Pieces) { Console.WriteLine(piece); }
            PieceMusique pieceChoisie = Pieces[choix];
            Musicien.Exp += pieceChoisie.QtExp;
            if (pieceChoisie.Diff == Experience.moyen)
            {
                Musicien.Montant += pieceChoisie.NiveauMin * Musicien.Montant;
            }
            while (instru.Corde.Durabilite < 0) { instru.Corde.Durabilite -= 10; }
            throw new Exception("La corde n'a plus de durabilite");

        }
        public void Menu()
        {
            Console.WriteLine(
                    $"********************************************" + Environment.NewLine +
                    $"* Quelle statistique voulez vous obtenir?  *" + Environment.NewLine +
                    $"* [{STATUT}] Statut                  *" + Environment.NewLine +
                    $"* [{PRATIQUER}] Pratiquer instru              *" + Environment.NewLine +
                    $"* [{REPARATION}] Reparation instru                *" + Environment.NewLine +
                    $"* [{Achat}] Acheter Piece                     *" + Environment.NewLine +
                    $"* [{JOUER}] JOUER                   *" + Environment.NewLine +
                    $"********************************************");
            string choix = Console.ReadLine() ?? "";
            Console.WriteLine();
            switch (choix.ToUpper())
            {
                case STATUT:
                    AfficherMusicien();
                    break;

                case PRATIQUER:
                    Pratiquer();
                    break;

                case REPARATION:
                    ReparerInstru();
                    break;

                case Achat:
                    AcheterPiece();
                    break;
                case JOUER:
                    Jouer();
                    break;

            }
            Console.WriteLine($"Nom : {Musicien.Nom}\nStatut:{Musicien.Statut}\nMontant:{Musicien.Montant}\nInstrument:{Musicien.Preference}\n{Musicien.ObtenirInfoInstru()}");

        }

    }
}
