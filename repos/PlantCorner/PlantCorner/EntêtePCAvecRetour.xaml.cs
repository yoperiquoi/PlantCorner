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

namespace PlantCorner
{
    /// <summary>
    /// Logique d'interaction pour EntêtePCAvecRetour.xaml
    /// </summary>
    public partial class EntêtePCAvecRetour : UserControl
    {
        /// <summary>
        /// Récupération du Navigator instancié dans l'App.xaml
        /// </summary
        Navigator Navigator => (App.Current as App).Navigator;
        public EntêtePCAvecRetour()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méthode gérant l'événement click du bouton de retour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Back();
        }
    }
}
