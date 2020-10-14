using Modèle.Jeu;
using Modèle.Jeu.Persistance;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Modèle.Jeu
{
    /// <summary>
    /// Classe définissant l'inventaire 
    /// </summary>
    public class Inventaire : INotifyPropertyChanged
    {
        /// <summary>
        /// Liste des accessoires présents dans l'inventaire
        /// </summary>
        public ObservableCollection<Accessoire> MesAccessoiresInv { get; set; }
        /// <summary> 
        /// Liste des plantes présentes dans l'inventaire
        /// </summary>
        public ObservableCollection<PlanteDuJeu> MesPlantesInv { get; set; }
        /// <summary>
        /// Constructeur de l'inventaire à partir de données fictives
        /// </summary>
        public Inventaire()
        {
           MesPlantesInv = new ObservableCollection<PlanteDuJeu>(new StubPlanteDeLaBoutiqueDataManager().GetAll().ToList());
           MesAccessoiresInv = new ObservableCollection<Accessoire>(new StubAccessoireDeLaBoutiqueDataManager().GetAll().ToList());

        }

        /// <summary>
        /// Ajout des propriétés nécessaire à la notification des vues
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}