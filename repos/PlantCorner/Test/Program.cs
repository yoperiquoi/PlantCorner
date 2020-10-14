using System;
using Modèle.Documentation;

namespace Test
{
    class Program
    {
        /// <summary>
        /// Test de la création d'une plante et de l'affichage de celle-ci
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine($"Test pour la création d'une plante");

            Plante p1 = new Plante("Rose", "Rosa", "Lien image",
                "La rose est la fleur des rosiers, arbustes du genre Rosa et de la famille des Rosaceae. La rose des jardins se caractérise avant tout par la multiplication de ses pétales imbriqués qui lui donne sa forme caractéristique.",
                Couleurs.Rouge, Saisons.Ete,"etdsdhheduizedz");
            Console.WriteLine(p1);

            Plante p2 = new Plante(p1);

            Console.WriteLine(p2);
        }
    }
}
