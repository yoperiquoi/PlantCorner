using Modèle.Jeu;
using Modèle.Jeu.Persistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Modèle.Jeu
{
    /// <summary>
    /// Classe définissant la boutique
    /// </summary>
    public class Boutique
    {
        /// <summary>
        /// Liste des plantes de la boutique
        /// </summary>
        public ObservableCollection<PlanteDuJeu> ListePlantes { get; set; }
        /// <summary>
        /// Liste des accessoires
        /// </summary>
        public ObservableCollection<Accessoire> ListeAccessoires { get; set; }

        /// <summary>
        /// Constructeur de la boutique à partir des données fictives (Stub)
        /// </summary>
        public Boutique()
        {
            ListePlantes = new ObservableCollection<PlanteDuJeu>(new StubPlanteDeLaBoutiqueDataManager().GetAll().ToList());

            ListeAccessoires = new ObservableCollection<Accessoire>(new StubAccessoireDeLaBoutiqueDataManager().GetAll().ToList());
        }
    }
}