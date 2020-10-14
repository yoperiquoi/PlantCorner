using Modèle;
using Modèle.Documentation;
using System;

namespace Test_DataContract
{
    class Program
    {
        /// <summary>
        /// Programme me permettant de créer un fichier XML pour la Persistance des données à partir de donnée du stub
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Doc Doc  = new Doc();//Créer une documentaion à partir des données fictive créé dans le stub
            Doc.SauvegardeDonnées();//Sauvegarde ces données que je peux ensuite déplacer dans le fichier de l'application WPF pour exploiter les données

          
            //Affichage des plantes pour vérifier l'intégriter des données du stub
            foreach(Plante p in Doc.LesPlantes)
            {
                Console.WriteLine(p);
            }

            foreach (MaPlante mp in Doc.MesPlantes)
            {
                Console.WriteLine(mp);
            }
        }
    }
}
