using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PlantCorner
{
    /// <summary>
    /// Classe définissant un chargement fictif pour l'application
    /// </summary>
    public class Chargement
    {
        /// <summary>
        /// Récupération du Navigator instancié dans l'App.xaml
        /// </summary
        public Navigator Navigator => (Application.Current as App).Navigator;
        /// <summary>
        /// Instanciation de l'EventHandler pour la barre de progression
        /// </summary>
        public event EventHandler<ProgressionNotifiedEventArgs> NotificationProgression;

        protected virtual void OnProgressionNotified(ProgressionNotifiedEventArgs args)
            => NotificationProgression?.Invoke(this, args);

        /// <summary>
        /// Méthode représentant un chargement fictif avec des Sleep répétitif.
        /// </summary>
        public void ChargementFictif()
        {
            for(int i=1; i<=100; i++)
            {
                System.Threading.Thread.Sleep(50);
                if (i == 30)
                {
                    System.Threading.Thread.Sleep(200);
                }
                if (i == 60)
                {
                    System.Threading.Thread.Sleep(150);
                }
                OnProgressionNotified(new ProgressionNotifiedEventArgs(i));
            }
            Navigator.NavigateTo("SelectionMode"); // A la fin on se dirige avec la selection du mode
        }
    }
}
