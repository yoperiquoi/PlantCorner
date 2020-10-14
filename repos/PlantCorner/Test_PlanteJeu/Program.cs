using Modèle.Jeu;
using System;
using System.Net.Mail;
using System.Security.Cryptography;

namespace Test_PlanteJeu
{
    class Program
    {
        static void Main(string[] args)
        {
            //Création d'un jardin fictif
            Jardin j = new Jardin();

          
            //Création d'une plante et d'un accessoire
            PlanteDuJeu rose = new PlanteDuJeu("Rose", 10, "lien", 100, 10,"Je suis une énorme plante");
            Console.WriteLine(rose);

            Accessoire pelle = new Accessoire(10, 15, "lien", "pelle", 15, 14, "je suis un epelle quii sert a creuser");

            //Utilisation de la plante (ajout a la liste de planteplanté)
            j.UtiliserPlante(rose);

            //Affichage de la plante
            Console.WriteLine(rose);

            //Affichage de l'accessoire
            Console.WriteLine(pelle);

            //Utilisation de l'accessoire sur la plante
            rose.BoosterParAccessoire(pelle);

            //Affichage de l'accessoire après le boost par l'accessoire
            Console.WriteLine(rose);



        }

    }
}
