using System;
using System.Collections.Generic;
using System.Text;

namespace Modèle.Documentation.Persistance
{
    /// <summary>
    /// Interface définissant le comportement du DataContractPers et de ses méthode de chargement et de sauvegarde pour la Documentation
    /// </summary>
    public interface IPersistanceDoc
    {
        /// <summary>
        /// Méthode permettant de récupérer des données à partir d'un fichier de persistance
        /// </summary>
        /// <returns>Les liste de la documentation remplies</returns>
        (IEnumerable<Plante> LesPlantes, IEnumerable<MaPlante> MesPlantes) ChargeDonnées();
        
        /// <summary>
        ///Méthode permettant de sauvegarder tout les élément des liste passer en paramètre dans un fichier de persistance 
        /// </summary>
        /// <param name="LesPlantes">Liste de plante de la documentation</param>
        /// <param name="MesPlantes">Liste de plante personnelle de la documentation</param>
        void SauvegardeDonnées(IEnumerable<Plante> LesPlantes, IEnumerable<MaPlante> MesPlantes);
    }
}
