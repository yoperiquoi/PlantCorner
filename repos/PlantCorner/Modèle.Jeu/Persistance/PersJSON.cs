using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Modèle.Jeu.Persistance
{
    /// <summary>
    /// Classe définissant la persistance en Json défini pour la partie Jeu avec la défini du comportement de la méthode de chargement et de sauvegarde dans l'interface implémenté
    /// </summary>
    public class PersJSON : IPersistanceJeu
    {
        /// <summary>
        /// Chemin d'accès du fichier de persistance, ici JSON
        /// </summary>
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..\\JSON");

        /// <summary>
        /// Méthode permettant de charger les données de la partie jeu à partir de données stockées dans des fichier Json à l'aide du framework Json.NET de Newtonsoft
        /// </summary>
        /// <returns></returns>
        (IEnumerable<PlanteDuJeu> LesPlantesPlanté, IEnumerable<PlanteDuJeu> MesPlantesInv, IEnumerable<Accessoire> MesAccessoiresInv, IEnumerable<PlanteDuJeu> LesPlantes, IEnumerable<Accessoire> LesAccessoires, Utilisateur MonUtilisateur) IPersistanceJeu.ChargeDonnées()
        {
            //Initialisation des différente liste à retourner
            IEnumerable<PlanteDuJeu> LesPlantesPlanté;
            IEnumerable<PlanteDuJeu> MesPlantesInv;
            IEnumerable<Accessoire> MesAccessoiresInv;
            IEnumerable<PlanteDuJeu> LesPlantes;
            IEnumerable<Accessoire> LesAccessoires;
            Utilisateur MonUtilisateur;
               
            //Instanciation du serializer permettant de déserialiser les objet stocké dans les fichiers Json
            JsonSerializer serializer = new JsonSerializer();

            //Remplissage des liste instancié plus haut à l'aide de la méthode de désérialisation du framework Json.NET de Newtonsoft
            using (StreamReader PlantesPlanté = File.OpenText(Path.Combine(FilePath, "PlantesPlanté.json")))
            {
                LesPlantesPlanté = (IEnumerable<PlanteDuJeu>)serializer.Deserialize(PlantesPlanté, typeof(IEnumerable<PlanteDuJeu>));
            }
            using(StreamReader PlantesInv = File.OpenText(Path.Combine(FilePath, "PlantesInv.json")))
            {
                MesPlantesInv = (IEnumerable<PlanteDuJeu>)serializer.Deserialize(PlantesInv, typeof(IEnumerable<PlanteDuJeu>));
            }
            using(StreamReader AccessoiresInv = File.OpenText(Path.Combine(FilePath, "AccessoiresInv.json")))
            {
                MesAccessoiresInv = (IEnumerable<Accessoire>)serializer.Deserialize(AccessoiresInv, typeof(IEnumerable<Accessoire>));
            }
            using(StreamReader PlantesBou = File.OpenText(Path.Combine(FilePath, "PlantesBou.json")))
            {
                LesPlantes = (IEnumerable<PlanteDuJeu>)serializer.Deserialize(PlantesBou, typeof(IEnumerable<PlanteDuJeu>));
            }
            using (StreamReader AccessoiresBou = File.OpenText(Path.Combine(FilePath, "AccessoireBou.json")))
            {
                LesAccessoires = (IEnumerable<Accessoire>)serializer.Deserialize(AccessoiresBou, typeof(IEnumerable<Accessoire>));
            }
            using (StreamReader Utilisateur = File.OpenText(Path.Combine(FilePath, "Utilisateur.json")))
            {
                MonUtilisateur = (Utilisateur)serializer.Deserialize(Utilisateur, typeof(Utilisateur));
            }                

            //On retourne alors toutes les liste remplies à partir de la persistance en Json
            return (LesPlantesPlanté,MesPlantesInv, MesAccessoiresInv, LesPlantes,LesAccessoires, MonUtilisateur);


        }

        /// <summary>
        /// Méthode permettant de sauvegarder les données dans des fichier de persistance en Json à l'aide du framework Json.NET de Newtonsoft
        /// </summary>
        /// <param name="LesPlantesPlanté">Liste des plante planté dans le jeu</param>
        /// <param name="MaBoutique">Boutique du jeu</param>
        /// <param name="MonInventaire">Inventaire du jeu</param>
        /// <param name="MonUtilisateur">Utilisateur à qui appartient le jardin</param>
        public void SauvegardeDonnées(IEnumerable<PlanteDuJeu> LesPlantesPlanté, Boutique MaBoutique, Inventaire MonInventaire, Utilisateur MonUtilisateur)
        {
            
            //Instanciation du sérializer
            JsonSerializer serializer = new JsonSerializer();

            //Si le fichier n'existe pas il créer alors un nouveau fichier avec le chemin donné
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            //Sauvegarde des différentes listes grâce à la méthode de sérialisation du sérializer du framework Json.NET de Newtonsoft dans des fichier Json
            using (StreamWriter PlantePlanté = File.CreateText(Path.Combine(FilePath, "PlantesPlanté.json")))
            {
                serializer.Serialize(PlantePlanté, LesPlantesPlanté);
            }
            using (StreamWriter PlantesInv = File.CreateText(Path.Combine(FilePath, "PlantesInv.json")))
            {
                serializer.Serialize(PlantesInv, MonInventaire.MesPlantesInv);
            }
            using (StreamWriter AccessoireInv = File.CreateText(Path.Combine(FilePath, "AccessoiresInv.json"))) 
            { 
                serializer.Serialize(AccessoireInv, MonInventaire.MesAccessoiresInv);
            }
            using (StreamWriter PlantesBou = File.CreateText(Path.Combine(FilePath, "PlantesBou.json")))
            {
                serializer.Serialize(PlantesBou, MaBoutique.ListePlantes);
            }
            using (StreamWriter AccessoireBou = File.CreateText(Path.Combine(FilePath, "AccessoireBou.json")))
            {
                serializer.Serialize(AccessoireBou, MaBoutique.ListeAccessoires);
            }
            using (StreamWriter Utilisateur = File.CreateText(Path.Combine(FilePath, "Utilisateur.json")))
            {
                serializer.Serialize(Utilisateur, MonUtilisateur);
            }


        }

        
    }
}
