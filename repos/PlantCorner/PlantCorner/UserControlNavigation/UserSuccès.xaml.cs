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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlantCorner.UserControlNavigation
{
    /// <summary>
    /// Logique d'interaction pour UserSuccès.xaml
    /// </summary>
    public partial class UserSuccès : UserControl
    {
        /// <summary>
        /// Récupération du Jardin instancié dans l'App.xaml
        /// </summary
        Jardin LeJardin => (Application.Current as App).Jardin;
        /// <summary>
        /// Récupération du Navigator instancié dans l'App.xaml
        /// </summary
        Navigator Navigator => (Application.Current as App).Navigator;

        /// <summary>
        /// Constructeur de UserSuccès
        /// </summary>
        public UserSuccès()
        {
            InitializeComponent();
            DataContext = LeJardin;
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
    }
}
