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
    /// Logique d'interaction pour UserSelectionMode.xaml.
    /// </summary>
    public partial class UserSelectionMode : UserControl
    {
        /// <summary>
        /// Récupération du Navigator instancié dans l'App.xaml
        /// </summary
        public Navigator Navigator => (Application.Current as App).Navigator;
        
        public UserSelectionMode()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evénement de navigation vers le jeu
        /// </summary>
        public event RoutedEventHandler ButtonClickJeu
        {
            add
            {
                ToJeu.Click += value;
            }
            remove
            {
                ToJeu.Click += value;
            }
        }

        /// <summary>
        /// Evénement de navigation vers la documentation
        /// </summary>
        public event RoutedEventHandler ButtonClickDoc
        {
            add
            {
                ToDoc.Click += value;
            }
            remove
            {
                ToDoc.Click -= value;
            }
        }
    }
}
