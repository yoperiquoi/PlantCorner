using Modèle;
using Modèle.Documentation;
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
    /// Logique d'interaction pour NavigationTest.xaml
    /// </summary>
    public partial class NavigationTest : Window
    {   
        /// <summary>
        /// Récupération de la documentation instancié dans App.xaml
        /// </summary>
        public Doc Doc => (Application.Current as App).Documentation;
        /// <summary>
        /// Récupération de la jardin instancié dans App.xaml
        /// </summary>
        public Jardin Jardin => (Application.Current as App).Jardin;
        /// <summary>
        /// Récupération de la navigator instancié dans App.xaml
        /// </summary>
        public Navigator Navigator => (Application.Current as App).Navigator;

        /// <summary>
        /// Constructeur de NavigationTest
        /// </summary>
        public NavigationTest()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// Méthode assurant la sauvegarde des données avant la fermeture de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Doc.SauvegardeDonnées();
            Jardin.SauvegardeDonnées();
        }
    }
}
