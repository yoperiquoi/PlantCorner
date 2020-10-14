using Modèle;
using Modèle.Jeu;
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
    /// Logique d'interaction pour ValiderSuppressionPlanteDuJeu.xaml
    /// </summary>
    public partial class ValiderSuppressionPlanteDuJeu : Window
    {
        /// <summary>
        /// Récupération de l'instanciation du jardin de App.xaml
        /// </summary>
        Jardin LeJardin => (Application.Current as App).Jardin;

        /// <summary>
        /// Constructeur de ValiderSuppressionPlanteDuJeu
        /// </summary>
        public ValiderSuppressionPlanteDuJeu()
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

            LeJardin.SupprimerPlantePlanté(LeJardin.PlanteDuJeuSelectionnée); //Supprime la plante selectionnée
            //LeJardin.SauvegardeDonnées(); // Sauvegarde des modification
            MessageBox.Show($"La plante a bien été supprimé de votre jardin"); //Affichage de la message box de confirmation
            Close();
        }

        /// <summary>
        /// Méthode définissant l'événement click de bouton Refuser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refuser_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
