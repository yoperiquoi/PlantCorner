using Modèle.Documentation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlantCorner
{
    /// <summary>
    /// Logique d'interaction pour AffichageGrandeImageMaPlante.xaml
    /// </summary>
    public partial class AffichageGrandeImageMaPlante : Window
    {
        /// <summary>
        /// Récupération de la documentation instancié dans l'App.xaml
        /// </summary>
        Doc Doc => (Application.Current as App).Documentation;

        /// <summary>
        /// Constructeur de AffichageGrandeImageMaPlante
        /// </summary>
        public AffichageGrandeImageMaPlante()
        {
            InitializeComponent();
            DataContext = Doc.MaPlanteSelectionnée; //Définition du DataContext sur la plante selectionnée de la documentation
            WindowStartupLocation = WindowStartupLocation.CenterOwner; // Affichage de la fenêtre au centre du user parent
            Owner = Application.Current.MainWindow; //Définition du parent comme l'application actuelle
        }

        /// <summary>
        /// Méthode définisant le comportement d'événement click du bouton de retour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
