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
    /// Logique d'interaction pour UserJeu.xaml. Représente la partie du jeu de l'application;
    /// </summary>
    public partial class UserJeu : UserControl
    {
        /// <summary>
        /// Récupération du jardin instancié dans l'App.xaml
        /// </summary>
        public Jardin LeJardin => (Application.Current as App).Jardin;

        /// <summary>
        /// Récupération du Navigator instancié dans l'App.xaml
        /// </summary
        public Navigator Navigator => (Application.Current as App).Navigator;

        /// <summary>
        /// Dependency property permettant de mettre à jour la vue
        /// </summary>
        public static readonly DependencyProperty UtilisateurProperty = DependencyProperty.Register("Utilisateur", typeof(Utilisateur), typeof(UserJeu));

        /// <summary>
        /// Constructeur de l'utilisateur de la vue
        /// </summary>
        public Utilisateur Utilisateur
        {
            get
            {
                return GetValue(UtilisateurProperty) as Utilisateur;
            }
            set
            {
                SetValue(UtilisateurProperty, value);
            }
        }

        /// <summary>
        /// Constructeur du UserJeu
        /// </summary>
        public UserJeu()
        {
            InitializeComponent();
            DataContext = LeJardin; //Définition du DataContext sur le Jardin
        }

        /// <summary>
        /// Evénement de navigation vers la liste des succès de l'utilisateur
        /// </summary>
        public event RoutedEventHandler ButtonClickSuccès
        {
            add
            {
                Succes.Click += value;
            }
            remove
            {
                Succes.Click -= value;
            }
        }

        /// <summary>
        /// Méthode définisant le comportement d'événement click du bouton pour ajouter une plante à l'inventaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterPlanteBoutique_Click(object sender, RoutedEventArgs e)
        {
            LeJardin.AchetePlante(((Button)sender).DataContext as PlanteDuJeu);
        }

        /// <summary>
        ///  Méthode définisant le comportement d'événement click du bouton pour ajouter un accessoire à l'inventaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterAccessoireBoutique_Click(object sender, RoutedEventArgs e)
        {
            LeJardin.AcheteAccessoire(((Button)sender).DataContext as Accessoire);
        }

        /// <summary>
        ///  Méthode définisant le comportement d'événement click du bouton pour utiliser un accessoires sur les plantes planté
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UtiliserAccessoireInventaire_Click(object sender, RoutedEventArgs e)
        {
            LeJardin.UtiliserAccessoire(((Button)sender).DataContext as Accessoire);
        }

        /// <summary>
        ///  Méthode définisant le comportement d'événement click du bouton pour ajouter une plante dans la liste des plante planté
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UtiliserPlanteInventaire_Click(object sender, RoutedEventArgs e)
        {
            LeJardin.UtiliserPlante(((Button)sender).DataContext as PlanteDuJeu);
        }

        /// <summary>
        ///  Méthode définisant le comportement d'événement click du bouton pour supprimer une plante de la liste de plante planté
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupprimerPlante_Click(object sender, RoutedEventArgs e)
        {
            LeJardin.PlanteDuJeuSelectionnée = ((Button)sender).DataContext as PlanteDuJeu; //Récupére la plante correspondant au bouton supprimer
            var validationWindow = new ValiderSuppressionPlanteDuJeu(); 
            validationWindow.ShowDialog(); //Ouvre alors la validation de suppressions pour valider le choix 
        }
    }
}
