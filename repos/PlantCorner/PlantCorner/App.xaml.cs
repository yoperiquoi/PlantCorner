using Modèle;
using Modèle.Documentation;
using Modèle.Documentation.Persistance;
using Modèle.Jeu;
using Modèle.Jeu.Persistance;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PlantCorner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Instanciation de la documentation avec la persistance XML
        /// </summary>
        public Doc Documentation { get; set; } = new Doc(new DataContractPers());
        /// <summary>
        /// Instanciation du jardin avec le stub
        /// </summary>
        public Jardin Jardin { get; set; } = new Jardin(new PersJSON());
        /// <summary>
        /// Instanciation du Jardin
        /// </summary>
        public Navigator Navigator { get; set; }

    public App()
        {
            Navigator = new Navigator();
            Jardin.SeuilAtteint += Jardin_SeuilAtteint;
        }

        private void Jardin_SeuilAtteint(object sender, Jardin.SeuilAtteintEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                if (Jardin.ListeSuccès.Count > 0)
            {
                Jardin.MonUtilisateur.AjouterSuccès(Jardin.ListeSuccès.Where(succès => succès.Condition < args.Argent).FirstOrDefault());
                if (Jardin.ListeSuccès.Contains(Jardin.ListeSuccès.Where(succès => succès.Condition < args.Argent).FirstOrDefault()))
                {
                    Jardin.ListeSuccès.Remove(Jardin.ListeSuccès.Where(succès => succès.Condition < args.Argent).FirstOrDefault());
                }
                    Jardin.SauvegardeDonnées();
                }
           
            });
            
        }
    }
}
