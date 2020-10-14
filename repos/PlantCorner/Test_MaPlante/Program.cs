using System;
using Modèle.Documentation;

namespace Test_MaPlante
{
    class Program
    {
        /// <summary>
        /// Test pour la création d'un plante personnelle avec les deux méthodes possible
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine($"Test pour la création d'une plante personnelle\n");
            Doc Doc = new Doc();

            Plante p1 = new Plante("Rose", "Rosa", "Lien image",
                "La rose est la fleur des rosiers, arbustes du genre Rosa et de la famille des Rosaceae. La rose des jardins se caractérise avant tout par la multiplication de ses pétales imbriqués qui lui donne sa forme caractéristique.",
                Couleurs.Rouge, Saisons.Ete,"ddqzdqzdqzd");
            string n = "Ceci est une note personnelle que l'on peut rajouter sur une plante";

            MaPlante mp1 = new MaPlante(n, p1);

            MaPlante mp2 = new MaPlante("Ceci est la note de la plante mp2", "Rose", "Rosa", "Lien image",
                "La rose est la fleur des rosiers, arbustes du genre Rosa et de la famille des Rosaceae. La rose des jardins se caractérise avant tout par la multiplication de ses pétales imbriqués qui lui donne sa forme caractéristique.",
                Couleurs.Rouge, Saisons.Ete,"feffsefsfse");
            Console.WriteLine($"mp1 : {mp1} \n\n");
            Console.WriteLine($"mp2 :{mp2}\n\n");

            Console.WriteLine("Modification de la plante mp1 pour qu'elle soit identique à la plante mp2\n");

            Doc.ModifierMaPlante(mp1, mp2);//Modification de la note de la plante

            Console.WriteLine($"mp1 : {mp1}\n\n");
            Console.WriteLine($"mp2 :{mp2}\n\n");

            Console.WriteLine($"On remarque que la note de mp1 est bien celle de mp2");
        }
    }
}
