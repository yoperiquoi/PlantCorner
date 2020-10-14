using Modèle.Jeu;
using Modèle.Jeu;
using System;

namespace Test_Boutique_Accessoire
{
    class Program
    {
        /// <summary>
        /// test le fonctionnemment général de la boutique et de l'inventaire
        /// </summary>C:\Users\Yoann\Desktop\DUT INFO\ProjetPc\repos\PlantCorner\Test_Boutique_Accessoire\Program.cs
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var jardin = new Jardin();

            /// <summary>
            /// test des plantes qui se trouve dans la boutique
            /// </summary>
            foreach (PlanteDuJeu pj in jardin.MaBoutique.ListePlantes)
            {
                Console.WriteLine(pj);
            }

            /// <summary>
            /// test des accessoires qui se trouve dans la boutique
            /// </summary>
            foreach (Accessoire a in jardin.MaBoutique.ListeAccessoires)
            {
                Console.WriteLine(a);
            }

            /// <summary>
            /// test des accessoires qui se trouve dans la boutique
            /// </summary>
            foreach (PlanteDuJeu pj in jardin.MonInventaire.MesPlantesInv)
            {
                Console.WriteLine(pj);
            }

            /// <summary>
            /// test des accessoires qui se trouve dans la boutique
            /// </summary>
            foreach (Accessoire a in jardin.MonInventaire.MesAccessoiresInv)
            {
                Console.WriteLine(a);
            }
        }
    }
}
