using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace examenFinal
{
    enum Experience
    {
        facile,
        moyen,
        difficile
    }
    internal class PieceMusique
    {
        public string Nom { set; get; }
        public int QtExp { set; get; }
        public int NiveauMin { set; get; }
        public int Prix { set; get; }
        public Experience Diff {  set; get; }
        List<string> noms;
        Random rnd;
        public PieceMusique(int qtExp, int niveauMin, int prix, Experience diff)
        {
            noms = new List<string>()
            {
                "Clair de Lune",
            "Für Elise",
            "Canon en Ré Majeur",
            "La Campanella",
            "Rhapsodie in Blue",
            "Nocturne en mi bémol majeur",
            "Le Boléro",
            "La Marche Turque",
            "Symphonie Fantastique",
            "Le Sacre du Printemps",
            "La Valse d'Amélie",
            "Sonate au clair de lune",
            "Sérénade Nocturne",
            "Le Canon de Pachelbel",
            "Adagio for Strings",
            "Concerto de Aranjuez",
            "Symphonie du Nouveau Monde",
            "La Petite Suite",
            "Concerto pour piano n°2 en do mineur",
            "Marche Slave",
            "Gymnopédie No. 1",
            "Concerto pour violon en ré majeur",
            "La Chevauchée des Walkyries",
            "La Symphonie Pastorale",
            "Carmina Burana",
            "Concerto pour piano n°5 en mi bémol majeur",
            "Pavane pour une infante défunte",
            "La Moldau",
            "Le Carnaval des Animaux",
            "La Truite"
            };
            Nom = noms[rnd.Next(30)];
            QtExp = qtExp;
            NiveauMin = niveauMin;
            Prix = prix;
            Diff = diff;
        }
        public override string ToString()
        {
            return $"{Nom} ; quantite exp : {QtExp}, niveau minimal : {NiveauMin}, prix : {Prix}, difficulte : {Diff}";
        }
    }
}
