using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace Modèle.Documentation.Persistance
{
    /// <summary>
    /// Classe définisant les méthode ChargerDonnées et SauvegardeDonnées permettant la persistance de l'application
    /// </summary>
    public class DataContractPers : IPersistanceDoc
    {
        /// <summary>
        /// Chemin d'accès du fichier de persistance, ici XML
        /// </summary>
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..\\XML");

        /// <summary>
        /// Nom du fichier de persistance
        /// </summary>
        public string FileName { get; set; } = "documentation.xml";

        /// <summary>
        /// Combinaison du chemib d'accès et du nom du fichier de persistance pour donner le chemin exact vers le fichier de persistance
        /// </summary>
        public string PersFile => Path.Combine(FilePath, FileName);

        /// <summary>
        /// Liste des plantes de la documentation
        /// </summary>
        internal List<Plante> LesPlantes { get; set; } = new List<Plante>();
        /// <summary>
        /// Liste des plantes personnelles présentes dans la documentation
        /// </summary>
        internal List<MaPlante> MesPlantes { get; set; } = new List<MaPlante>();

        /// <summary>
        /// Définition du type de sérialiseur avec l'ajout de référence en option évitant de recopier plusieurs fois le même object et préservant les référence entre les objets
        /// </summary>
        private DataContractSerializer Serializer { get; set; } = new DataContractSerializer (typeof(DataToPersist), new DataContractSerializerSettings()
        {
            PreserveObjectReferences = true
        }
        );

        /// <summary>
        /// Définition de la méthode de ChargeDonnées permettant le chargement des deux liste de la documentation.
        /// </summary>
        /// <returns>Les deux liste de la documentation (LesPlante et MesPlantes) avec les données présentes dans le dossier de persistance</returns>
        public (IEnumerable<Plante> LesPlantes, IEnumerable<MaPlante> MesPlantes) ChargeDonnées()
        {
            //Vérification de l'existance du dossier de persistance 
            if (!File.Exists(PersFile))
            {
                throw new FileNotFoundException("Le fichier de persistance est introuvable.");
            }

            //Récupération du serialiseur avec le DataToPersist contenant la liste de plante de la documentation ainsi que la liste de plante personnelle
            var serializer = new DataContractSerializer(typeof(DataToPersist));

            //Initialisation de la liste de plante de la documentation ainsi que la liste de plante personnelle
            DataToPersist data;

            //Ouverture du fichier de persistance et lecture de chacun des objet présent. Remplissage des liste de data
            using (Stream s = File.OpenRead(PersFile))
            {
                data = Serializer.ReadObject(s) as DataToPersist;
            }

            //Recopiage des liste obtenu dans le fichier de persistance dans les listes
            LesPlantes = data.LesPlantes.ToPOCOs().ToList();
            MesPlantes = data.MesPlantes.ToPOCOs().ToList();

            //Retourne les liste alors remplie
            return (LesPlantes, MesPlantes);
        }

        /// <summary>
        /// Défintion de la méthode SauvegardeDonnées permettant l'enregistrement des deux listes de la documentation dans un fichier de persistance 
        /// </summary>
        /// <param name="LesPlantes">Liste des plantes de la documentation</param>
        /// <param name="MesPlantes">Liste des plantes personnelles</param>
        public void SauvegardeDonnées(IEnumerable<Plante> LesPlantes, IEnumerable<MaPlante> MesPlantes)
        {
            //Vérification de l'existance du fichier de persistance
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            //Initialisation de la liste de plante de la documentation ainsi que la liste de plante personnelle
            DataToPersist data = new DataToPersist();

            //Remplissage des liste à partir des listes initialement passé en paramètre
            data.LesPlantes.AddRange(LesPlantes.ToDTOs());
            data.MesPlantes.AddRange(MesPlantes.ToDTOs());

            //Définition de l'écriture en XML dans le dossier de persistance avec une indentation automatique pour une lecture plus direct pour l'homme
            var settings = new XmlWriterSettings() { Indent = true };
            //Ouverture et écriture des objet présent dans data vers le fichier de persistance
            using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName)))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    Serializer.WriteObject(writer, data);
                }
            }
            
        }
    }
}
