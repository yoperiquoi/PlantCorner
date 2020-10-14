using Modèle.Jeu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;
using System.Timers;

namespace Modèle.Jeu
{
    /// <summary>
    /// Classe définissant une Plante présente dans le jeu
    /// </summary>
    public class PlanteDuJeu : INotifyPropertyChanged
    {
        /// <summary>
        /// Nom de la plante
        /// </summary>
        public string Nom { get;  set; }
        /// <summary>
        /// Prix de la plante
        /// </summary>
        public float Prix { get;  set; }
        /// <summary>
        /// Lien de l'illustration de la plante
        /// </summary>
        public string Img { get;  set; }
        /// <summary>
        /// Gain en expérience de la plante
        /// </summary>
        public int GainEnExpérience { get;  set; }
        /// <summary>
        /// Description de la plante
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gain en argent de la plante
        /// </summary>
        private float gainEnArgent;
        public float GainEnArgent
        {
            get => gainEnArgent;
            set
            {
                gainEnArgent = value;
                OnPropertyChange(nameof(GainEnArgent));
            }
        }

        /// <summary>
        /// Constructeur de la plante du jeu
        /// </summary>
        /// <param name="nom">Nom de la plante</param>
        /// <param name="prix">Prix de la plante</param>
        /// <param name="lien">Lien de l'illustration de la plante</param>
        /// <param name="gainEnArgent">Gain en argent de la plante</param>
        /// <param name="gainEnExpérience">Gain en expérience de la plante</param>
        /// <param name="desc">Description de la plante</param>
        public PlanteDuJeu(string nom, float prix, string lien,int gainEnArgent,int gainEnExpérience, string desc)
        {
            Nom = nom;
            Prix = prix;
            Img = lien;
            GainEnExpérience = gainEnExpérience;
            GainEnArgent = gainEnArgent;
            Description = desc;
        }

        public PlanteDuJeu()
        {
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Méthode permettant de booster la plante à l'aide d'un accessoire
        /// </summary>
        /// <param name="accessoire">Accessoire boostant la plante</param>
        public void BoosterParAccessoire(Accessoire accessoire)
        {
            GainEnArgent += accessoire.Boost;
        }

        /// <summary>
        /// Affiche le contenu succint d'une plante du jeu
        /// </summary>
        /// <returns>Affichage d'une plante du jeu</returns>
        public override string ToString() => $" nom : {Nom} gain d'argent : {GainEnArgent}/s";

    }
}
