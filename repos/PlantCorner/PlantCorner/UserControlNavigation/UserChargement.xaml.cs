using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PlantCorner.UserControlNavigation
{
    /// <summary>
    /// Logique d'interaction pour UserChargement.xaml représentant un chargement fictif au démarrage de l'application
    /// </summary>
    public partial class UserChargement : UserControl
    {
        /// <summary>
        /// Timer permettant de déclancher le chargement fictif du côté du modèle
        /// </summary>
        private static System.Timers.Timer Timer;

        /// <summary>
        /// Déclaration du chargement fictif
        /// </summary>
        public Chargement Chargement { get; set; } = new Chargement();

        /// <summary>
        /// Récupération du navigator à partir de l'App.xaml
        /// </summary>
        public Navigator Navigator => (Application.Current as App).Navigator;

        /// <summary>
        /// Constructeur de UserChargement
        /// </summary>
        public UserChargement()
        {
            InitializeComponent();
            Chargement.NotificationProgression += MiseAJourProgression; //Abonnement à la méthode de mise à jour de la progression de la barre de chargement
            InitialiserTimer(); //Initiation du timer pour l'appel du chargement fictif
        }

        /// <summary>
        /// Méthode assurant la mise à jour de la barre de progression dans la vue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Valeur i du chargement fictif</param>
        private void MiseAJourProgression(object sender, ProgressionNotifiedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                progressBar.Value = e.Pourcentage; // Attribution de la valeur de la progress bar à l'aide du dispatcher
            }, DispatcherPriority.Render);
        }

        /// <summary>
        /// Méthode d'initialisation du timer
        /// </summary>
        public void InitialiserTimer()
        {
            Timer = new System.Timers.Timer(100); //Déclaration d'un interval de 100 ms

            Timer.Elapsed += Action; // Abonnement à la fonction Action déclanchant le chargement fictif
            Timer.AutoReset = false; // Le timer ne se réinitialise pas
            Timer.Enabled = true; // Il est activé
        }

        /// <summary>
        /// Méthode exécuté par le timer : déclanche le chargement fictif du côté logique
        /// </summary>
        /// <param name="source">Timer</param>
        /// <param name="e">Aucun paramètre</param>
        private void Action(Object source, ElapsedEventArgs e)
        {
            Chargement.ChargementFictif();
        }
    }
}

