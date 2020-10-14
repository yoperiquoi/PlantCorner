using Modèle.Jeu;
using Modèle.Jeu.Persistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Security.Permissions;
using System.Timers;

namespace Modèle.Jeu
/// <summary>
/// Cette classe représente le jardin de l'utilisateur avec toutes ces plantes acheté.
/// </summary>
{
    public class Jardin : INotifyPropertyChanged
    {
        public IPersistanceJeu Persistance;
        /// <summary>
        /// définit le nombre maximum de plantes que peut contenir un jardin.
        /// </summary>
        private int nbPlaceDispo;
        public int NbPlaceDispo
        {
            get => nbPlaceDispo;
            private set
            {
                nbPlaceDispo = value;
                OnPropertyChange(nameof(NbPlaceDispo));
            }
        }
        /// <summary>
        /// Défini le nombre de plante actuellement présente dans le jardin
        /// </summary>
        private int nbPlante;
        public int NbPlante
        {
            get => nbPlante;
            private set
            {
                nbPlante = value;
                OnPropertyChange(nameof(NbPlante));
            }
        }
        /// <summary>
        /// Utilisateur du jardin
        /// </summary>
        public Utilisateur MonUtilisateur { get; set; }

        /// <summary>
        /// Défini le lien de l'image
        /// </summary>
        public string Img { get; private set; }
        /// <summary>
        /// Plante selectionnée dans le jardin
        /// </summary>
        public PlanteDuJeu PlanteDuJeuSelectionnée { get; set; }
        /// <summary>
        /// Méthode permettant de supprimer une plante dans la liste des plante planté
        /// </summary>
        /// <param name="planteDuJeu">Plante à supprimer</param>
        public void SupprimerPlantePlanté(PlanteDuJeu planteDuJeu)
        {
            timer.Stop(); //On stop et redémarre le chronomètre pour ne pas créer d'exception lorsqu'il essaye d'attibuer de l'argent pour tout les plantes présenter dans la liste des plantes planté
            if (ListePlantesPlanté.Contains(planteDuJeu))
            {
                ListePlantesPlanté.Remove(planteDuJeu);
                NbPlante--;
            }
            timer.Start();
        }

        /// <summary>
        /// Méthode assurant le chargement des données à partir d'une persistance JSON grâce au framework Json.NET de Newtonsoft
        /// </summary>
        public void ChargeDonnées()
        {
            var données = Persistance.ChargeDonnées(); //Chargement des données à partir des données stockées en Json
            if (!(données.LesPlantesPlanté == null))
            {
                foreach (var p in données.LesPlantesPlanté)
                {
                    ListePlantesPlanté.Add(p);
                }
            }
            foreach (var p in données.LesPlantes)
            {
                MaBoutique.ListePlantes.Add(p);
            }
            foreach (var a in données.LesAccessoires)
            {
                MaBoutique.ListeAccessoires.Add(a);
            }
            foreach (var p in données.MesPlantesInv)
            {
                MonInventaire.MesPlantesInv.Add(p);
            }
            foreach (var a in données.MesAccessoiresInv)
            {
                MonInventaire.MesAccessoiresInv.Add(a);
            }

            MonUtilisateur = données.MonUtilisateur;

        }

        /// <summary>
        /// Méthode assurant la sauvegarde des données dans un fichier JSON à l'aide du framework Json.NET de Newtonsoft
        /// </summary>
        public void SauvegardeDonnées()
        {
            Persistance.SauvegardeDonnées(ListePlantesPlanté,MaBoutique,MonInventaire,MonUtilisateur); //Sauvegarde des données dans un fichier Json
        }

        /// <summary>
        /// Liste des plante disposé dans le jardin
        /// </summary>
        private ObservableCollection<PlanteDuJeu> listePlantesPlanté;
        public ObservableCollection<PlanteDuJeu> ListePlantesPlanté
        {
            get => listePlantesPlanté;
            set
            {
                listePlantesPlanté = value;
                OnPropertyChange(nameof(ListePlantesPlanté));
            }
        }
        /// <summary>
        /// Liste des succès présent dans le jardin
        /// </summary>
        public ObservableCollection<Succès> ListeSuccès { get; set; }
        /// <summary>
        /// Timer permettant de faire gagner l'argent et l'expérience
        /// </summary>
        private static System.Timers.Timer timer;
        /// <summary>
        /// Boutique présente dans le jardin
        /// </summary>
        public Boutique MaBoutique { get; set; }
        /// <summary>
        /// Inventaire présente dans la boutique
        /// </summary>
        public Inventaire MonInventaire { get; set; }

        /// <summary>
        /// Argument de l'évenement permettant de scrutter le débloquage des succès
        /// </summary>
        public class SeuilAtteintEventArgs : EventArgs
        {
            public float Argent { get; private set; }

            public SeuilAtteintEventArgs(float argent) => Argent = argent;
        }

        /// <summary>
        /// Délégué pour l'événement s'occupant des succès 
        /// </summary>
        /// <typeparam name="TEventArgs">Type de l'argument</typeparam>
        /// <param name="sender">Element déclanchant l'événement</param>
        /// <param name="args">Argument communiqué via l'événement (ici l'argent)</param>
        public delegate void EventHandler<TEventArgs>(object sender, TEventArgs args) where TEventArgs : EventArgs;

        /// <summary>
        /// EventHandler pour les succès
        /// </summary>
        public event EventHandler<SeuilAtteintEventArgs> SeuilAtteint;

        /// <summary>
        /// Méthode permettant de déclancher l'événement
        /// </summary>
        /// <param name="args">Argument passé via l'événement (ici de l'argent)</param>
        protected void OnSeuilAtteint(SeuilAtteintEventArgs args)
            => SeuilAtteint?.Invoke(this, args);

        /// <summary>
        /// Ajout de l'événement permettant de notifier la vue de changement
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        

        protected virtual void OnPropertyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        /// <summary>
        /// Méthode appelé par l'événement permettant de parcourir la liste des succès présent dans les jardin et attribuer ceux dont les conditions ont été validé 
        /// à l'utilisateur
        /// </summary>
        /// <param name="sender">Type de l'envoyeur de l'événement</param>
        /// <param name="args">Argument passé à travers l'événement (ici de l'argent)</param>


        /// <summary>
        /// Constructeur de la liste des plantes plantés avec un utilisateur fictif
        /// </summary>
        public Jardin()
        {
            Persistance = new PersJSON();
            MonUtilisateur = new Utilisateur("papafayo", "Débutant", 0, 0, "1234", new DateTime(15 / 01 / 2001),"yoann.periquoi@etu.uca.fr", Sexes.Homme, this);
            ListePlantesPlanté = new ObservableCollection<PlanteDuJeu>(new StubPlanteDeLaBoutiqueDataManager().GetAll().ToList());
            ListeSuccès = new ObservableCollection<Succès>(new StubSuccesDataManager().GetAll().ToList());
            nbPlaceDispo = 6;
            InitialiserTimer();
            MaBoutique = new Boutique();
            MonInventaire = new Inventaire();
            NbPlante = ListePlantesPlanté.Count;
        }
        public Jardin(IPersistanceJeu persistance)
        {
            Persistance = persistance;
            ListePlantesPlanté = new ObservableCollection<PlanteDuJeu>();
            ListeSuccès = new ObservableCollection<Succès>(new StubSuccesDataManager().GetAll().ToList());
            nbPlaceDispo = 6;
            MaBoutique = new Boutique();
            MonInventaire = new Inventaire();
            InitialiserTimer();
            ChargeDonnées();
            NbPlante = ListePlantesPlanté.Count;
        }

        /// <summary>
        /// Méthode permettant d'utiliser un accessoire sur la liste de plante planté
        /// </summary>
        /// <param name="accessoires">Accessoire à utiliser sur la liste de plante</param>
        public void UtiliserAccessoire(Accessoire accessoires)
        {
            if (accessoires == null)
            {
                return;
            }
            if (accessoires.NbrUtilisation == 1)
            {
                MonInventaire.MesAccessoiresInv.Remove(accessoires);
            }
            accessoires.NbrUtilisation--;
            foreach (PlanteDuJeu p in ListePlantesPlanté)
            {
                p.BoosterParAccessoire(accessoires);
            }
            SauvegardeDonnées();
        }

        /// <summary>
        /// Méthode permettant d'utiliser une plante et de l'ajouter à la liste des plante planté
        /// </summary>
        /// <param name="plante">Plante à ajouter à la liste des plantes planté</param>
        public void UtiliserPlante(PlanteDuJeu plante)
        {
            timer.Stop();
            if (plante == null || NbPlante >= NbPlaceDispo)
            {
                return;
            }
            ListePlantesPlanté.Add(plante);
            MonInventaire.MesPlantesInv.Remove(plante);
            NbPlante++;
            timer.Start();
            SauvegardeDonnées();
        }
        /// <summary>
        /// Méthode permettant d'initialiser le timer avec les différent paramètres
        /// </summary>

        public void InitialiserTimer()
        {
            timer = new System.Timers.Timer(7000);

            timer.Elapsed += Action;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        /// <summary>
        /// Action réaliser à chaque itération du timer
        /// </summary>
        /// <param name="source">Objet déclancheur de l'événement (ici le timer)</param>
        /// <param name="e">Argument passé (ici vide)</param>
        private void Action(Object source, ElapsedEventArgs e)
        {
            foreach (PlanteDuJeu p in ListePlantesPlanté)
            {
                MonUtilisateur.AjouterArgent(p.GainEnArgent);
                MonUtilisateur.AjouterExpérience(p.GainEnExpérience);
            }
            VérifierSuccès();
        }
        /// <summary>
        /// Méthode appelant l'événement SeuilAtteint permettant de vérifier l'attribution des succès pour le joueur
        /// </summary>
        public void VérifierSuccès()
        {
            OnSeuilAtteint(new SeuilAtteintEventArgs(MonUtilisateur.Argent));
        }

        /// <summary>
        /// Méthode permettant à l'utilisateur d'acheter une plante dans la boutique passant alors dans son inventaire
        /// </summary>
        /// <param name="plante">Plante acheté dans la boutique</param>
        public void AchetePlante(PlanteDuJeu plante)
        {
            if (plante.Prix < MonUtilisateur.Argent)
            {
                MonUtilisateur.RetirerArgent(plante.Prix);
                MonInventaire.MesPlantesInv.Add(plante);
            }
            else
            {
                return;
            }
            SauvegardeDonnées();
        }

        /// <summary>
        ///  Méthode permettant à l'utilisateur d'acheter une accessoire dans la boutique passant alors dans son inventaire
        /// </summary>
        /// <param name="accessoires">Accessoire acheté dans la boutique</param>
        public void AcheteAccessoire(Accessoire accessoires)
        {
            if (accessoires.Prix < MonUtilisateur.Argent || accessoires.NbrFoisAchetable > 0)
            {
                MonUtilisateur.RetirerArgent(accessoires.Prix);
                MonInventaire.MesAccessoiresInv.Add(accessoires);
                Accessoire a = MaBoutique.ListeAccessoires.First(accessoire => accessoire.Nom == accessoires.Nom);
                a.NbrFoisAchetable--;
            }
            else
            {
                return;
            }
            SauvegardeDonnées();
        }
    }
}