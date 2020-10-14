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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlantCorner
{
    /// <summary>
    /// Logique d'interaction pour AffichageMaPlante.xaml
    /// </summary>
    public partial class AffichageMaPlante : UserControl
    {
        /// <summary>
        /// Récupération de la documentation instancié dans l'App.xaml
        /// </summary>
        Doc Doc => (Application.Current as App).Documentation;

        /// <summary>
        /// Gestion de la DependencyProperty pour l'affichage des propriété de la plante personnelle
        /// </summary>
        public static readonly DependencyProperty MaPlanteProperty = DependencyProperty.Register("MaPlante", typeof(MaPlante), typeof(AffichageMaPlante));

        /// <summary>
        /// Constructeur de la plante personnelle pour la vue
        /// </summary>
        public MaPlante MaPlante
        {
            get
            {
                return GetValue(MaPlanteProperty) as MaPlante;
            }
            set
            {
                SetValue(MaPlanteProperty, value);
            }
        }

        /// <summary>
        /// Constructeur de AffichageMaPlante
        /// </summary>
        public AffichageMaPlante()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méthode gérant l'événement click du bouton supprimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            var supprimerWindow = new ValiderSuppressionMaPlante();
            supprimerWindow.ShowDialog();
        }

        /// <summary>
        /// Méthode gérant l'événement click du bouton modifier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            var modifierWindow = new ModifierMaPlante();
            modifierWindow.ShowDialog();
        }

        /// <summary>
        /// Méthode gérant l'événement click du bouton aggrandir la photo de la plante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Aggrandir_Click(object sender, RoutedEventArgs e)
        {
            var aggrandirWindow = new AffichageGrandeImageMaPlante();
            aggrandirWindow.ShowDialog();
        }
    }
}
