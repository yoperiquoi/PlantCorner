using Modèle.Jeu;
using System;


namespace Test_Accessoire
{
    class Program
    {
        /// <summary>
        /// Test très rapide du gain d'xp d'un utilisateur avec un accessoire
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Accessoire pelle = new Accessoire(10, 15, "lien", "pelle", 15, 14, "je suis un epelle quii sert a creuser");
            Console.WriteLine(pelle);

            Utilisateur bob = new Utilisateur("papafayo", "Débutant", 0, 0, "1234", new DateTime(15 / 01 / 2001), "yoann.periquoi@etu.uca.fr", Sexes.Homme, null);
            Console.WriteLine(bob);

            pelle.GagnerExp(pelle, bob);

            Console.WriteLine(bob);
        }
    }
}
