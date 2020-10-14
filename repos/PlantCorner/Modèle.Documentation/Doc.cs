using Modèle.Documentation.Persistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace Modèle.Documentation
{
    /// <summary>
    /// Classe contenant la documentation
    /// </summary>
    public class Doc : INotifyPropertyChanged
    {
        /// <summary>
        /// Choix de la persistance pour le chargement et la sauvegarde des données
        /// </summary>
        private IPersistanceDoc Persistance { get; set; }

        /// <summary>
        /// Fonction assurant le chargement des données avec la méthode de DataContract
        /// </summary>
        public void ChargeDonnées()
        {
            var données = Persistance.ChargeDonnées();//Récupération des données via la persistance en XLM et DataContract
            foreach(var p in données.LesPlantes)
            {
                LesPlantes.Add(p); //Remplissage de la liste de plante de la documentation et de la liste fixé permettant de réinitialiser
                lesPlantesFixé.Add(p);
            }
            foreach (var mp in données.MesPlantes)
            {
                MesPlantes.Add(mp);//Remplissage de la liste personnelle de plante
            }
        }

        /// <summary>
        /// Méthode assurant la sauvegarde des données dans un fichier XML
        /// </summary>
        public void SauvegardeDonnées()
        {
            Persistance.SauvegardeDonnées(LesPlantes, MesPlantes);//Appel de sauvegarde des données en XML via DataContract à chaque modification et à la fermeture de l'application
        }

        /// <summary>
        /// Collection de plante constituant la documentation
        /// </summary>
        private ObservableCollection<Plante> lesPlantes;

        public ObservableCollection<Plante> LesPlantes
        {
            get { return lesPlantes; }
            set
            {
                lesPlantes = value;
                OnPropertyChange(nameof(LesPlantes));
            }
        }

        /// <summary>
        /// Collection de plante fixé permettant la réinitialisation de la documentation en "DeapReadOnlyCollection"
        /// </summary>
        public IEnumerable<IPlante> LesPlantesFixé => lesPlantesFixé;
        private List<Plante> lesPlantesFixé = new List<Plante>();

        /// <summary>
        /// Collection contenant la liste de plantes personnelles
        /// </summary>
        public ObservableCollection<MaPlante> MesPlantes { get; set; }

        /// <summary>
        /// Représente la plante privée actuellement sélectionné dans la vue
        /// </summary>
        private MaPlante maPlanteSélectionnée;
        public MaPlante MaPlanteSelectionnée 
        {
            get => maPlanteSélectionnée;
            set
            {
                if(maPlanteSélectionnée != value)
                {
                    maPlanteSélectionnée = value;
                    OnPropertyChange(nameof(MaPlanteSelectionnée));
                }
            }
        }

        /// <summary>
        /// Représente la plante actuellement sélectionné dans la vue
        /// </summary>
        private Plante planteSélectionnée;
        public Plante PlanteSelectionnée
        {
            get => planteSélectionnée;
            set
            {
                if (planteSélectionnée != value)
                {
                    planteSélectionnée = value;
                    OnPropertyChange(nameof(planteSélectionnée));
                }
            }
        }

        /// <summary>
        /// Méthode permettant d'ajouter une plante privée à la collection personnelle
        /// </summary>
        /// <param name="mp">Plante personnelle à ajouter à la collection</param>
        public void AjouterMaPlante(MaPlante mp)
        {
            if(mp != null)
            {
                NombreDePlantePersonnelle++;
                MesPlantes.Add(mp);
            }
        }

        /// <summary>
        /// Représente le nombre de plante personnelle
        /// </summary>
        private int nombreDePlantePersonnelle;

        public int NombreDePlantePersonnelle
        {
            get { return nombreDePlantePersonnelle; }
            set 
            {
                nombreDePlantePersonnelle = value;
                OnPropertyChange(nameof(nombreDePlantePersonnelle));
            }
        }

        /// <summary>
        /// Ajout des attribut et méthode permettant de notifier
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Méthode permettant d'appliquer les filtres de couleurs à la liste personnelle 
        /// </summary>
        /// <param name="couleurs">Couleur à appliquer au filtre</param>
        public void AppliquerFiltresCouleurs(Couleurs couleurs)
        {
            LesPlantes = new ObservableCollection<Plante>(lesPlantesFixé.Where(plante => plante.Couleur == couleurs).ToList());
        }
        /// <summary>
        /// Méthode permettant d'appliquer les filtres de saison à la liste personnelle 
        /// </summary>
        /// <param name="saisons">Saison à appliquer au filtre</param>
        public void AppliquerFiltresSaisons(Saisons saisons)
        {
            LesPlantes = new ObservableCollection<Plante>(lesPlantesFixé.Where(plante => plante.Saison == saisons).ToList());
        }

        /// <summary>
        /// Constructeur de la documentation à partir de la persistance passée en paramètre
        /// </summary>
        /// <param name="persistance">Choix de persistance pour le chargement et l'enregistrement de la documentation </param>
        public Doc(IPersistanceDoc persistance)
        {
            Persistance = persistance;
            LesPlantes = new ObservableCollection<Plante>();
            MesPlantes = new ObservableCollection<MaPlante>();
            ChargeDonnées();
            NombreDePlantePersonnelle = MesPlantes.Count;
        }
        /// <summary>
        /// Constructeur de la documentation à partir des données fictives (Stub)
        /// </summary>
        public Doc()
        {
            Persistance = new DataContractPers();
            LesPlantes = new ObservableCollection<Plante>(new StubPlanteDataManager().GetAll());
            lesPlantesFixé = new List<Plante>(new StubPlanteDataManager().GetAll());
            MesPlantes = new ObservableCollection<MaPlante>(new StubMesPlanteDataManager().GetAll());
            NombreDePlantePersonnelle = MesPlantes.Count;
        }
        /// <summary>
        /// Méthode permettant de modifier les données d'une plante 
        /// </summary>
        /// <param name="maPlanteSelectionnée">Plante selectionnée dans la vue (oldPlante)</param>
        /// <param name="maPlante">Plante créé à partir de la modification (newPlante)</param>
        /// <returns>Retourne la plante avec ces attributs modifiés</returns>
        public MaPlante ModifierMaPlante(MaPlante maPlanteSelectionnée, MaPlante maPlante)
        {
            if (maPlanteSelectionnée.Equals(maPlante))
            {
                return null;
            }
            Type typeMaPlante = typeof(MaPlante);
            var planteProperties = typeMaPlante.GetProperties();

            foreach(var property in planteProperties.Where(ppty => ppty.CanWrite))
            {
                property.SetValue(maPlanteSelectionnée, property.GetValue(maPlante));
            }
            return maPlanteSelectionnée;
        }

        /// <summary>
        /// Méthode permettant d'ajouter une plante à la documentation  (non implémenté à la vue)
        /// </summary>
        /// <param name="p">Plante à ajouter à la liste</param>
        public void AjouterPlante(Plante p)
        {
            if (LesPlantes.Contains(p))
            {
                return;
            }
            LesPlantes.Add(p);
        }

        /// <summary>
        /// Méthode permettant de supprimer une plante de la liste de la documentation (non implémenté à la vue)
        /// </summary>
        /// <param name="p">Plante à supprimer de la documentation</param>
        /// <returns>Si la plante à bien été supprimé ou non</returns>
        public bool SupprPlante(Plante p)
        {
            if (LesPlantes.Contains(p))
            {
                return LesPlantes.Remove(p);
            }
            return false;
        }

        /// <summary>
        /// Méthode permettant de supprimer une plante de la documentation personnelle
        /// </summary>
        /// <param name="p">Plante personnelle à supprimer</param>
        /// <returns>Si la plante à bien été supprimé ou non</returns>
        public bool SupprMaPlante(MaPlante p)
        {
            if (MesPlantes.Contains(p))
            {
                NombreDePlantePersonnelle--;
                return MesPlantes.Remove(p);
            }
            return false;
            
        }
       
        /// <summary>
        /// Méthode permettant de modifier une plante de la liste
        /// </summary>
        /// <param name="p">Plante à modifier dans la liste</param>
        public Plante ModifPlante(Plante PlanteSelectionnée, Plante Plante)
        {
            if (PlanteSelectionnée.Equals(Plante))
            {
                return null;
            }
            Type typePlante = typeof(Plante);
            var planteProperties = typePlante.GetProperties(); //Récupération des propriétés d'une plante 

            foreach (var property in planteProperties.Where(ppty => ppty.CanWrite)) //Réécriture pour toute les propriété qui peuvent être modifier (setter public)
            {
                property.SetValue(PlanteSelectionnée, property.GetValue(Plante)); //Modification des propriétés de la plante selectionnée avec la propriété de la nouvelle plante créer dans la vue
            }
            return PlanteSelectionnée;
        }


        /// <summary>
        /// Méthode permettant de faire une recherche dans la liste des plante à partir d'une chaîne de caractère, utilise l'algorithme de levenshtein
        /// pour connaître la "distance" entre chaque chaîne de caractères
        /// </summary>
        /// <param name="nom">Chaîne de caractère similaire recherché</param>
        /// <returns>La liste des plantes triées dans l'ordre de ressemble à la chaine de caractère</returns>
        public ObservableCollection<Plante> Recherche(string nom)
        {
            string PlanteRecherché = nom; //Récupération de la chaîne de caractère passé en paramètres

            int distance; //Initialisation du nombre d'opération entre chaque chaîne de caractère

            SortedDictionary<int, List<Plante>> ResultatRecherche = new SortedDictionary<int, List<Plante>>(); //Inititalisation de la variable permettant de stocker l'association clé valeur 
                                                                                                               //de sorte que cela rende une liste rangé de la ressemble la plus élevé à la ressemblance la plus lointaine.

            
            int Levenshtein(String a, String b) //Définition de l'algorithme de levenshtein à fin de l'utiliser plus loin dans la recherche
            {
                if (string.IsNullOrEmpty(a))
                {
                    if (!string.IsNullOrEmpty(b))
                    {
                        return b.Length;
                    }
                    return 0;
                }

                if (string.IsNullOrEmpty(b))
                {
                    if (!string.IsNullOrEmpty(a))
                    {
                        return a.Length;
                    }
                    return 0;
                }

                int cost;
                int[,] d = new int[a.Length + 1, b.Length + 1];
                int min1;
                int min2;
                int min3;

                for (int i = 0; i <= d.GetUpperBound(0); i += 1)
                {
                    d[i, 0] = i;
                }

                for (int i = 0; i <= d.GetUpperBound(1); i += 1)
                {
                    d[0, i] = i;
                }

                for (int i = 1; i <= d.GetUpperBound(0); i += 1)
                {
                    for (int j = 1; j <= d.GetUpperBound(1); j += 1)
                    {
                        cost = Convert.ToInt32(!(a[i - 1] == b[j - 1]));

                        min1 = d[i - 1, j] + 1;
                        min2 = d[i, j - 1] + 1;
                        min3 = d[i - 1, j - 1] + cost;
                        d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                    }
                }

                return d[d.GetUpperBound(0), d.GetUpperBound(1)];

            }

            foreach (Plante p in LesPlantes) 
            {
                List<Plante> lp = new List<Plante>(); //Création d'une liste permettant d'insérer les plante dans la partie valeur du dictionnaire
                distance = Levenshtein(p.Nom, PlanteRecherché); //On établit la distance entre le nom de la plante de la documentation et la chaîne de caractère dans la barre de recherche
                if (ResultatRecherche.ContainsKey(distance)) //Si la distance existe déjà dans le dictionnaire
                {
                    ResultatRecherche.TryGetValue(distance, out lp); // Alors on recupére la liste de plante associé
                    lp.Add(p); // Et on y ajoute la plante correspondant à cette distance
                }
                else // Si la distance n'est pas présente 
                {
                    lp.Add(p); //On ajoute la plante à la liste créé plus haut
                    ResultatRecherche.Add(distance, lp); // On ajoute alors l'association clé valeur au dictionnaire qui sera alors rangé automatiquement
                }


            }

            ObservableCollection<Plante> lesPlantesTrié = new ObservableCollection<Plante>(); //On créer une ObservableCollection permettant de récupérer les valeurs disposé dans le dictionnaire trié

            foreach (KeyValuePair<int, List<Plante>> pair in ResultatRecherche) // J'utilise un foreach sur tout les association clé valeur du dictionnaire
            {
                foreach (Plante p in pair.Value) // On je parcours les liste de plante contenu dans la valeur
                {
                    lesPlantesTrié.Add(p); //Et j'extrait chacune des plantes pour les ajouter dans l'ObservableCollection crée plus haut
                }
            }
            
            return lesPlantesTrié; //Je retourne alors l'ObservableCollection rempli dans l'ordre de ressemblance à la chaîne de caractère passé en paramètre
        }



    }
}
