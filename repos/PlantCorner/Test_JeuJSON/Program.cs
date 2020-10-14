using Modèle.Jeu;
using Modèle.Jeu.Persistance;
using System;

namespace Test_JeuJSON
{
    class Program
    {
        /// <summary>
        /// Programme permettant la création des fichier JSON à partir des données fictive pour le remplissage des données du jeu
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Sauvegarde pour créer les fichers avec données
            Jardin Jardin = new Jardin(new PersJSON());
            Jardin.SauvegardeDonnées();

            //Test de chargement
            Jardin Jardin1 = new Jardin(new PersJSON());

            Jardin1.ChargeDonnées();

            //Test de l'affichage d'un des élément de la persistance pour prouver l'intégritée des données
            Console.WriteLine(Jardin1.MonUtilisateur);
        }
    }
}
