using Modèle.Jeu;
using System;
using System.ComponentModel;
using System.Reflection;

namespace Modèle.Jeu
{
    /// <summary>
    /// Classe de définissant un accessoire
    /// </summary>
    public class Accessoire : IGenerateurExp<Accessoire>, INotifyPropertyChanged
    {
        /// <summary>
        /// Nombre d'utilisation possible de l'accessoire
        /// </summary>
        private int nbrUtilisation;

        public int NbrUtilisation 
        { 
            get => nbrUtilisation;

            set
            {
                nbrUtilisation = value;
                OnPropertyChange(nameof(NbrUtilisation));
            } 
        }
        /// <summary>
        /// Nombre de fois que l'objet peut être acheté
        /// </summary>
        private int nbrFoisAchetable;
        public int NbrFoisAchetable
        {
            get => nbrFoisAchetable;
            set
            {
                nbrFoisAchetable = value;
                OnPropertyChange(nameof(NbrFoisAchetable));
            }
        }
        /// <summary>
        /// Prix de la plante
        /// </summary>
        public float Prix { get; set; }
        /// <summary>
        /// Lien de l'image de plante
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// Nom de l'accessoire
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Valeur du boost de l'accessoire
        /// </summary>
        public int Boost { get; set; }
        /// <summary>
        /// Défini si l'objet est acheté ou non
        /// </summary>
        public bool Acheté { get; set; }
        /// <summary>
        /// Description de l'accessoire
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Constructeur de l'accessoire
        /// </summary>
        /// <param name="nbrUtilisation">Nombre d'utilisation de l'accessoire</param>
        /// <param name="prix">Prix de l'accessoire</param>
        /// <param name="img">Lien de l'image de l'accessoire</param>
        /// <param name="nom">Nom de l'accessoire</param>
        /// <param name="boost">Boost de l'accessoire</param>
        /// <param name="NbrFoisAchetable">Nombre de fois qu'on peut achetre cette accessoire</param>
        /// <param name="Desc">Description de l'accessoire</param>
        public Accessoire(int nbrUtilisation, float prix, string img, string nom, int boost, int NbrFoisAchetable, string Desc)
        {
            NbrUtilisation = nbrUtilisation;
            Prix = prix;
            Img = img;
            Nom = nom;
            Boost = boost;
            Description = Desc;
            this.NbrFoisAchetable = NbrFoisAchetable;
            Acheté = true;
        }

        public Accessoire()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Méthode permettant de faire de gagner de l'expérience à l'utilisateur
        /// </summary>
        /// <param name="accessoires">Accessoire faisant gagner de l'expérience</param>
        /// <param name="bob">Utilisateur qui gagne de l'expérience</param>
        public void GagnerExp(Accessoire accessoires, Utilisateur bob)
        {
            if (accessoires.Acheté)
            {
                bob.AjouterExpérience(100);
            }
        }

     
        /// <summary>
        /// Affichage de l'accessoire
        /// </summary>
        /// <returns>Affichage de la plante</returns>
        public override string ToString() => $" nom : {Nom} Nombre d'utilisation : {NbrUtilisation} nombre de fois achetable : {NbrFoisAchetable}";

    }
}