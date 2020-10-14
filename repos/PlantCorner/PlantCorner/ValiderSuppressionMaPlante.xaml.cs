using Modèle;
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
    /// Logique d'interaction pour ValiderSuppressionMaPlante.xaml
    /// </summary>
    public partial class ValiderSuppressionMaPlante : Window
    {
        /// <summary>
        /// Récupération de l'instanciation de la documentation de App.xaml
        /// </summary>
        Doc Doc => (Application.Current as App).Documentation;
        /// <summary>
        /// Constructeur de ValiderSuppressionMaPlante
        /// </summary>
        public ValiderSuppressionMaPlante()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Owner = Application.Current.MainWindow;
        }

        /// <summary>
        /// Méthode définissant l'événement click de bouton accepter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accepter_Click(object sender, RoutedEventArgs e)
        {
            MaPlante mp = Doc.MaPlanteSelectionnée;// Récupére la plante selectionnée
            Doc.SupprMaPlante(Doc.MaPlanteSelectionnée); // Supprimer alors la plante de la liste
            Doc.SauvegardeDonnées(); // Sauvegarde les modification
            MessageBox.Show($"La plante \"{mp.Nom}\" a bien été supprimé de votre collection personnelle.");
            Close(); // Affichage d'un message de confirmation dans une message box
        }

        /// <summary>
        ///  Méthode définissant l'événement click de bouton refuser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refuser_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
