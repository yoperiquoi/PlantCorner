using Modèle;
using Modèle.Documentation;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour UserMesPlantes.xaml. Représente la partie des plantes personnelles de l'application.
    /// </summary>
    public partial class UserMesPlantes : UserControl
    {
        /// <summary>
        /// Récupération de la documentation instancié dans l'App.xaml
        /// </summary>
        public Doc Doc => (Application.Current as App).Documentation;

        /// <summary>
        /// Récupération du Navigator instancié dans l'App.xaml
        /// </summary
        public Navigator Navigator => (Application.Current as App).Navigator;

        /// <summary>
        /// Constructeur de UserMesPlantes
        /// </summary>
        public UserMesPlantes()
        {
            InitializeComponent();
            DataContext = Doc; //Définition du DataContext sur la documentation
        }

        /// <summary>
        /// Méthode définisant le comportement d'événement click du bouton de retour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Back();
        }

        /// <summary>
        /// Méthode gérant l'événement SelectionChanged de ListBox de plante
        /// </summary>
        /// <param name="sender">ListBox de la liste de plante</param>
        /// <param name="e">List des éléments sélectionné</param>
        private void Plantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count == 0)
            {
                Doc.MaPlanteSelectionnée = null;
            }
            else
            {
                Doc.MaPlanteSelectionnée = e.AddedItems[0] as MaPlante;
            }
        }

    }
}
