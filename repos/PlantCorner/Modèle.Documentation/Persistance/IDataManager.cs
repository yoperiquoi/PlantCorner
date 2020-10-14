using System;
using System.Collections.Generic;
using System.Text;

namespace Modèle.Documentation.Persistance
{
    /// <summary>
    /// Interface définissant les méthode obligatoirement contenu dans les stubs/data manager
    /// </summary>
    /// <typeparam name="T">Classe à laquel sera appliquer le data manager</typeparam>
    public interface IDataManager<T> where T : class
    {
        /// <summary>
        /// Méthode permettant de récupérer tout les éléments de la liste
        /// </summary>
        /// <returns>Retourne tout les éléments de la liste</returns>
         IEnumerable<T> GetAll();
        
        /// <summary>
        /// Permet de récupérer un élément de la liste à partir de son nom
        /// </summary>
        /// <param name="nom">Nom de l'élément recherché</param>
        /// <returns>L'élément recherché ou rien si l'élément n'existe pas</returns>
         T GetByName(string nom);
    }
}
