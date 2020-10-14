using Modèle.Jeu;
using System;
using System.Linq;

namespace Test_Jardin
{
    class Program
    {
        /// <summary>
        /// Test du fonctionnement du Timer du jardin
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Jardin Jardin = new Jardin(); // Créer le jardin et l'initie avec des plantes
            Console.WriteLine("Affichage argent de l'utilisateur avant une itération du timer");
            Console.WriteLine(Jardin.MonUtilisateur.Argent);//Affiche une première fois l'argent de l'utilisateur

            System.Threading.Thread.Sleep(7000);//Attend une itération du timer

            Console.WriteLine("Affichage argent de l'utilisateur après une itération du timer");
            Console.WriteLine(Jardin.MonUtilisateur.Argent);//Réaffiche l'argent de l'utilisateur

        }
    }
}
