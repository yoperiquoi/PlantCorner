using Modèle.Jeu.Persistance;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;


namespace Modèle.Jeu
{
    /// <summary>
    /// Classe définissant un utilisateur du jeu
    /// </summary>
    public class Utilisateur : INotifyPropertyChanged
    {
        /// <summary>
        /// Pseudo de l'utilisateur
        /// </summary>
        public string Pseudo { get;  set; }

        /// <summary>
        /// Titre de l'utilisateur
        /// </summary>
        private string titre;
        public string Titre
        {
            get => titre;
            set
            {
                titre = value;
                OnPropertyChange(nameof(Titre));
            }
        }

        /// <summary>
        /// Argent de l'utilisateur
        /// </summary>
        private float argent;
        public float Argent
        {
            get => argent;
            set
            {
                argent = value;
                OnPropertyChange(nameof(Argent));
            }
        }

        /// <summary>
        /// Expérience de l'utilisateur
        /// </summary>
        private int expérience;
        public int Expérience
        {
            get => expérience;
            set
            {
                expérience = value;
                OnPropertyChange(nameof(Expérience));
            }
        }
        
        /// <summary>
        /// Mot de passe de l'utilisateur
        /// </summary>
        public string MotDePasse { get;  set; }
        
        /// <summary>
        /// Date de naissance de l'utilisateur
        /// </summary>
        public DateTime DateDeNaissance { get;  set; }

        /// <summary>
        /// Mail de l'utilisateur
        /// </summary>
        public string Mail { get;  set; }

        /// <summary>
        /// Genre de l'utilisateur
        /// </summary>
        public Sexes Sexe { get;  set; }

        /// <summary>
        /// Jardin de l'utilisteur
        /// </summary>
        [JsonIgnore]
        public Jardin MonJardin { get; }

        /// <summary>
        /// Liste des succès obtenu par l'utilisateur
        /// </summary>
        public ObservableCollection<Succès> MesSuccès { get; set; } = new ObservableCollection<Succès>();

        /// <summary>
        /// Lien vers l'illustration de l'utilisateur (défini par défaut)
        /// </summary>
        public string Illustration { get; set; } = "../Img/LogoPC.png";

        /// <summary>
        /// Ajout des propriété nécessaire pour la notification de la vue
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Constructeur de l'utilisateur
        /// </summary>
        /// <param name="pseudo">Pseudo de l'utilisateur</param>
        /// <param name="titre">Titre de l'utilisateur</param>
        /// <param name="argent">Argent de l'utilisateur</param>
        /// <param name="expérience">Expérience de l'utilisateur</param>
        /// <param name="motDePasse">Mot de passe de l'utilisateur</param>
        /// <param name="dateDeNaissance">Date de naissance de l'utilisateur</param>
        /// <param name="mail">Mail de l'utilisateur</param>
        /// <param name="sexe">Genre de l'utilisateur</param>
        /// <param name="monJardin">Jardin de l'utilisateur</param>
        public Utilisateur(string pseudo, string titre, float argent, int expérience, string motDePasse, DateTime dateDeNaissance, string mail, Sexes sexe, Jardin monJardin)
        {
            Pseudo = pseudo;
            Titre = titre;
            Argent = argent;
            Expérience = expérience;
            MotDePasse = motDePasse;
            DateDeNaissance = dateDeNaissance;
            Mail = mail;
            Sexe = sexe;
            MonJardin = monJardin;
        }


        /// <summary>
        /// Constructeur de l'utilisateur à partir d'un utilisateur déjà existant
        /// </summary>
        /// <param name="utilisateur">Utilisateur déjà existant</param>
        public Utilisateur(Utilisateur utilisateur)
        {
            Pseudo = utilisateur.Pseudo;
            Titre = utilisateur.Titre;
            Argent = utilisateur.Argent;
            Expérience = utilisateur.Expérience;
            MotDePasse = utilisateur.MotDePasse;
            DateDeNaissance = utilisateur.DateDeNaissance;
            Mail = utilisateur.Mail;
            Sexe = utilisateur.Sexe;
            MonJardin = utilisateur.MonJardin;
        }

        public Utilisateur()
        {
        }

        /// <summary>
        /// Méthode permettant de modifier le titre de l'utilisateur
        /// </summary>
        /// <param name="titre">Nouveau titre</param>
        public void ModifierTitre(string titre)
        {
            Titre = titre;
        }

        /// <summary>
        /// Méthode permettant d'ajouter de l'expérience à l'utilisateur
        /// </summary>
        /// <param name="expérience">Expérience rajouté</param>
        public void AjouterExpérience(int expérience)
        {
            Expérience += expérience;
        }

        /// <summary>
        /// Méthode permettant de retirer de l'argent à l'utilisateur notamment lors d'achat
        /// </summary>
        /// <param name="argent">Argent à retirer</param>
        public void RetirerArgent(float argent)
        {
            if(argent > Argent)
            {
                return;
            }
            Argent -= argent;
        }

        /// <summary>
        /// Méthode permettant d'ajouter de l'argent à l'utilisateur
        /// </summary>
        /// <param name="argent">Argent à ajouter</param>
        public void AjouterArgent(float argent)
        {
            Argent += argent;
        }

        /// <summary>
        /// Méthode permettant d'ajouter un succès à la liste de succès de l'utilisateur
        /// </summary>
        /// <param name="succès">Succès à ajouter à la liste de l'utilisateur</param>
        public void AjouterSuccès(Succès succès)
        {
            if(succès == null)
            {
                return;
            }
            MesSuccès.Add(succès);
            Titre = succès.Nom;
            Argent += succès.ArgentGagné;
            Expérience += succès.ExpérienceGagné;
        }

        /// <summary>
        /// Méthode permettant d'afficher quelque détails d'un joueur
        /// </summary>
        /// <returns>Affichage d'un joueur</returns>
        public override string ToString() => $"{Pseudo} \n {Expérience} \n {Argent} ";

    }
}
