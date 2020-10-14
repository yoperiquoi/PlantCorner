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
    /// Logique d'interaction pour AffichagePlante.xaml
    /// </summary>
    public partial class AffichagePlante : UserControl
    {
        /// <summary>
        /// Récupération de la documentation instancié dans l'App.xaml
        /// </summary>
        Doc Doc => (Application.Current as App).Documentation;
        
        /// <summary>
        /// Gestion de la DependencyProperty pour l'affichage des propriété de la plante personnelle
        /// </summary>
        public static readonly DependencyProperty PlanteProperty = DependencyProperty.Register("Plante", typeof(Plante), typeof(AffichagePlante));

        /// <summary>
        /// Constructeur de la plante personnelle pour la vue
        /// </summary>
        public Plante Plante
        {
            get
            {
                return GetValue(PlanteProperty) as Plante;
            }
            set
            {
                SetValue(PlanteProperty, value);
            }
        }

        /// <summary>
        /// Constructeur de AffichageMaPlante
        /// </summary>
        public AffichagePlante()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méthode gérant l'événement click du bouton aggrandir la photo de la plante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Aggrandir_Click(object sender, RoutedEventArgs e)
        {
            var aggrandirWindow = new AffichageGrandeImagePlante();
            aggrandirWindow.ShowDialog();
        }

        /// <summary>
        /// Méthode gérant l'événement click du bouton ajouter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {   
            MaPlante mp = new MaPlante("ceci est la description de base", Doc.PlanteSelectionnée);
            Doc.AjouterMaPlante(mp);
            Doc.SauvegardeDonnées();
            MessageBox.Show($"La plante \"{mp.Nom}\" a bien été ajouté à votre collection personnelle.");
        }
    }
}
