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
using System.Windows.Shapes;

namespace PlantCorner
{
    /// <summary>
    /// Logique d'interaction pour ModifierMaPlante.xaml
    /// </summary>
    public partial class ModifierMaPlante : Window
    {
        /// <summary>
        /// Récupération de la documentation instancié dans l'App.xaml
        /// </summary>
        Doc Doc => (Application.Current as App).Documentation;

        /// <summary>
        /// Instanciation d'une plante pour la modification
        /// </summary>
        public MaPlante MaPlante { get; set; }
        /// <summary>
        /// Construction de la fenêtre modifier plante
        /// </summary>
        public ModifierMaPlante()
        {
            InitializeComponent();
            var mp = Doc.MaPlanteSelectionnée;
            MaPlante = new MaPlante(mp.Note.Description, mp.Nom, mp.NomScientifique, mp.Illustration, mp.Description,mp.Couleur, mp.Saison, mp.Instruction);
            DataContext = MaPlante;
        }

        /// <summary>
        /// Méthode gérant l'événement click du bouton annuler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Méthode gérant l'événement click du bouton modifier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            Doc.ModifierMaPlante(Doc.MaPlanteSelectionnée, MaPlante);
            Doc.SauvegardeDonnées();
            Close();
        }
    }
}
