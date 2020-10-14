using System;
using System.Collections.Generic;
using System.Text;

namespace Modèle.Jeu.Persistance
{ 
    /// <summary>
    /// Classe définissant la création de données fictives pour tester le fonction du modèle et des vues.
    /// </summary>
    /// <typeparam name="T">Classe utilisé par le DataManager</typeparam>
    public abstract class StubDataManager<T> : IDataManager<T> where T : class
    {
        /// <summary>
        /// Collection rempli par le stub
        /// </summary>
        protected List<T> MyCollection { get; set; } = new List<T>();

        /// <summary>
        /// Méthode retournant la collection rempli lors de la construction du stub
        /// </summary>
        /// <returns>Retourne la collection rempli lors de la construction du stub</returns>
        public IEnumerable<T> GetAll()
        {
            return MyCollection;
        }

        /// <summary>
        /// Méthode permettant de trouver un objet grâce à son nom
        /// </summary>
        /// <param name="nom">Nom de l'objet</param>
        /// <returns>L'objet recherché</returns>
        public abstract T GetByName(string nom);
    }
}
