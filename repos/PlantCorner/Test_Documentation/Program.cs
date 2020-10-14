using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Modèle;
using Modèle.Documentation;

namespace Test_Documentation
{
    class Program
    {
        /// <summary>
        /// Test pour trie de la liste de plante à partir d'une chaîne de caractères avec l'utilisation de l'algorithme de levenshtein.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Initialisation de la documentation avec la liste de plante de la documentation et personnelle
            Doc Documentation = new Doc();


            //Test pour la fonction de recherche sur la documentation avec l'algorithme de Levenstein
            //Création d'une liste pour récupérer le résultat du trie
            ObservableCollection<Plante> RésultatRecherche = new ObservableCollection<Plante>();

            //Plante recherché (normalement noté dans la barre de recherche
            string PlanteRecherché = "Roseau";

            //Appel de la fonction de recherche avec récupération du résultat dans la liste instancié avant
            RésultatRecherche = Documentation.Recherche(PlanteRecherché);

            //Affichage de la liste dans la console
            foreach (Plante p in RésultatRecherche)
            {
                Console.WriteLine(p);
            }




            //Test pour la modification d'une plante personnelle
            //Création d'une nouvelle plante avec quelques propriétés modifié
            Console.WriteLine($"===========================");
            Console.WriteLine($"Test pour la modification d'une plante personnelle");
            Console.WriteLine($"===========================");

            MaPlante mp1 = new MaPlante("Ceci est un test de modification ", "Rose bleue", "Rosa", "../Img/LogoPC.png",
               "La rose est la fleur des rosiers, arbustes du genre Rosa. La rose des jardins se caractérise avant tout par la multiplication de ses pétales imbriqués qui lui donne sa forme caractéristique.",
               Couleurs.Rouge, Saisons.Ete,"Instruction");
            //Création d'un nouvelle plante personnelle pour récupérer la modification
            MaPlante planteModifié;
            //Affichage plante que l'on va modifier
            Console.WriteLine($"Plante de départ : {Documentation.MesPlantes.ElementAt(1)}");
            //Appel de la fonction de modification et récupération dans la plante créé plus haut
            planteModifié = Documentation.ModifierMaPlante(Documentation.MesPlantes.ElementAt(1), mp1);
            //Affichage de la plante modifié
            Console.WriteLine($"Plante après modification : {planteModifié}");

            //Test la "DeapReadOnlyCollection" pour la liste de plante qui est fixé.

            foreach (var plante in Documentation.LesPlantesFixé)
            {
                Console.WriteLine($"Plante en lecture seule {plante}");
            }

            //Impossible d'indexer la list
            //Documentation.LesPlantesFixé[0] = new Plante("Rose", "Rosa", "../Img/LogoPC.png","La rose est la fleur des rosiers, arbustes du genre Rosa et de la famille des Rosaceae. La rose des jardins se caractérise avant tout par la multiplication de ses pétales imbriqués qui lui donne sa forme caractéristique.",Couleurs.Rouge, Saisons.Ete, "Ceci est les instruction d'entretient de la plante");

            //Impossible de caster la liste pour ensuite la modifier ( rend null )
            //List<IPlante> test = (Documentation.LesPlantesFixé as List<IPlante>);
            //foreach (var plante in test)
            //{
            //    Console.WriteLine(plante);
            //}

            //La liste de plante fixé est donc inaccessible
        }
    }
}
