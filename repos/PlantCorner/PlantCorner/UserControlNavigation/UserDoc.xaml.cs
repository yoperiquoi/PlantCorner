using Modèle;
using Modèle.Documentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlantCorner
{
    /// <summary>
    /// Logique d'interaction pour UserDoc.xaml. Représente la partie documentation de l'application.
    /// </summary>
    public partial class UserDoc : UserControl
    {
        /// <summary>
        /// Récupération de la documentation instancié dans l'App.xaml
        /// </summary>
        public Doc Doc => (Application.Current as App).Documentation;
        /// <summary>
        /// Récupération du Navigator instancié dans l'App.xaml
        /// </summary
        public Navigator Navigator => (App.Current as App).Navigator;
        /// <summary>
        /// Constructeur du UserDoc
        /// </summary
        public UserDoc()
        {
            InitializeComponent();
            DataContext = Doc; //Définition du DataContext sur la documentation
            Couleur_Combobox.ItemsSource = Enum.GetValues(typeof(Couleurs)); //Récupération des énumérations des couleurs 
            Saison_Combobox.ItemsSource = Enum.GetValues(typeof(Saisons)); //Récupération des énumérations des saisons
        }

        /// <summary>
        /// Evénement de navigation vers la liste de plantes personnelles
        /// </summary>
        public event RoutedEventHandler ButtonClickMesPlantes
        {
            add
            {
                MesPlantes.Click += value;
            }
            remove
            {
                MesPlantes.Click -= value;
            }
        }

        /// <summary>
        /// Méthode définisant le comportement d'événement click du bouton de retour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Back(); //Navigue vers le dernier UserControl visionné
        }

        /// <summary>
        /// Méthode gérant l'événement SelectionChanged de ListBox de plante
        /// </summary>
        /// <param name="sender">ListBox de la liste de plante</param>
        /// <param name="e">List des éléments sélectionné</param>
        private void Plantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                Doc.PlanteSelectionnée = null;
            }
            else
            {
                Doc.PlanteSelectionnée = e.AddedItems[0] as Plante; //Défini le dernier élément de la ListBox sélectionné comme la plante actuellement sélectionné
            }
        }

        /// <summary>
        /// Méthode gérant l'événement SelectionChanged de ComboBox des couleurs 
        /// </summary>
        /// <param name="sender">ComboBox des couleurs</param>
        /// <param name="e">Liste des éléments sélectionné</param>
        private void Couleur_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(Couleur_Combobox.SelectedItem == null)
            {
                return;
            }
            Doc.AppliquerFiltresCouleurs((Couleurs)e.AddedItems[0]); // Applique le filtre sur la liste de la documentation avec la dernière couleur selectionné
        }

        /// <summary>
        /// Méthode gérant l'événement SelectionChanged de ComboBox des saisons 
        /// </summary>
        /// <param name="sender">ComboBox des saisons</param>
        /// <param name="e">Liste des éléments sélectionné</param>
        private void Saison_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Saison_Combobox.SelectedItem == null)
            {
                return;
            }
            Doc.AppliquerFiltresSaisons((Saisons)e.AddedItems[0]); // Applique le filtre sur la liste de la documentation avec la dernière saison selectionné
        }

        /// <summary>
        /// Méthode gérant l'événement click du bouton reinitialisé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reinitialiser_Click(object sender, RoutedEventArgs e)
        {
            Doc.LesPlantes = new ObservableCollection<Plante>(Doc.LesPlantesFixé as IEnumerable<Plante>); //Reinstancie la liste des plante à partir de la liste fixé
            SearchBox.SearchText = ""; //Vide la barre de recherche
            Couleur_Combobox.SelectedValue = -1; //Reinitialise le Combobox
            Saison_Combobox.SelectedValue = -1;  //Reinitialise le Combobox
        }
    }
}
