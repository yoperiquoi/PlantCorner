using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace Modèle.Documentation
{
    /// <summary>
    /// Interface permettant la mise en place d'une "DeepReadOnlyCollection" en rendant les attribut en lecture seule
    /// </summary>
    public interface IPlante
    {
        /// <summary>
        /// Nom de la plante en lecture seule
        /// </summary>
        string Nom { get; }
        /// <summary>
        /// Nom scientifique en lecture seule
        /// </summary>
        string NomScientifique { get; }
        /// <summary>
        /// Lien de l'illustration de la plante en lecture seule
        /// </summary>
        string Illustration { get; }
        /// <summary>
        /// Description de la plante en lecture seule
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Instruction d'entretient de la plante en lecture seule
        /// </summary>
        string Instruction { get; }
        /// <summary>
        /// Couleur de la plante en lecture seule
        /// </summary>
        Couleurs Couleur { get; }
        /// <summary>
        /// Saison de la plante en lecture seule
        /// </summary>
        Saisons Saison { get; }
    }

    /// <summary>
    /// Classe définissant une plante basique de la documentation
    /// </summary>
    public class Plante : INotifyPropertyChanged, IDataErrorInfo,IPlante
{
        /// <summary>
        /// Nom de la plante obligatoire avec minimum 3 caractères
        /// </summary>

        private string nom;
        [Required(ErrorMessage = "Le nom de votre plante est obligatoire")]
        [MinLength(3, ErrorMessage = "Le nom de la plante doit faire plus de 3 caractères")]
        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
                OnPropertyChange(nameof(nom));
            }
        }

        /// <summary>
        /// Nom scientifique de la plante obligatoire
        /// </summary>
        [Required(ErrorMessage = "Le nom scientifique d'une plante est obligatoire")]
        public string NomScientifique { get; private set; }

        /// <summary>
        /// Lien de l'illustration de la plante obligatoire
        /// </summary>
        [Required(ErrorMessage = "L'illustration d'une plante est obligatoire")]
        public string Illustration { get; private set; }

        /// <summary>
        /// Description de la plante en obligatoire
        /// </summary>
        [Required(ErrorMessage = "La description d'une plante est obligatoire")]
        public string Description { get; private set; }

        /// <summary>
        /// Instruction d'instruction de la plante obligatoire
        /// </summary>
        [Required(ErrorMessage = "Les instruction d'une plante est obligatoire")]
        public string Instruction { get; private set; }
        /// <summary>
        /// Couleur de la plante obligatoire
        /// </summary>
        [Required(ErrorMessage = "La couleur d'une plante est obligatoire")]
        public Couleurs Couleur { get; private set; }
        /// <summary>
        /// Saison de la plante obligatoire
        /// </summary>
        [Required(ErrorMessage = "La saison de floraison d'une plante est obligatoire")]
        public Saisons Saison { get; private set; }
        /// <summary>
        /// Message d'erreur du validatoire
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// Ajout des méthode permettant de notifier les changement à la vue
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        /// <summary>
        /// Constructeur d'une plante
        /// </summary>
        /// <param name="nom">Nom de la plante</param>
        /// <param name="nomScientifique">Nom scientifique de la plante</param>
        /// <param name="illustration">Lien vers l'image de la plante</param>
        /// <param name="description">Description de le plante</param>
        /// <param name="couleur">Couleur principal de la plante</param>
        /// <param name="saison">Saison de floraison de la plante</param>
        /// <param name="instruction">Instruction d'entretient de la plante</param>
        public Plante(string nom, string nomScientifique, string illustration, string description, Couleurs couleur,
            Saisons saison, string instruction)
        {
            Nom = nom;
            NomScientifique = nomScientifique;
            Illustration = illustration;
            Description = description;
            Instruction = instruction;
            Couleur = couleur;
            Saison = saison;
        }

        /// <summary>
        /// Constructeur d'une plante à partir d'une autre plante déjà existante
        /// </summary>
        /// <param name="p">Plante déjà existante</param>
        public Plante(Plante p)
        {
            Nom = p.Nom;
            NomScientifique = p.NomScientifique;
            Illustration = p.Illustration;
            Description = p.Description;
            Couleur = p.Couleur;
            Saison = p.Saison;
            Instruction = p.Instruction;
        }

        /// <summary>
        /// Affichage d'une plante
        /// </summary>
        /// <returns>L'affichage d'une plante</returns>
        public override string ToString()
        {
            return $"{Nom} ou \"{NomScientifique}\" est une plante {Couleur} poussant en {Saison} : {Description}" +
                   $"Le lien de son illustration est : {Illustration}" +
                   $"Voici mes instructions de d'entretient : {Instruction}";

        }

        /// <summary>
        /// Méthode d'équivalence permettant de savoir si deux plantes sont identique
        /// </summary>
        /// <param name="other">Plante à comparer avec la plante actuelle</param>
        /// <returns>Si la plante est équivalente ou non</returns>
        public bool Equals(Plante other)
        {
            return Nom.Equals(other.Nom) && NomScientifique.Equals(other.NomScientifique) && Description.Equals(other.Description);

        }
        /// <summary>
        /// Méthode de comparation entre la plante et un objet
        /// </summary>
        /// <param name="obj">Objet à comparer</param>
        /// <returns>Si l'objet et équivalent ou non</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Plante);
        }

        /// <summary>
        /// Validateur des attributs de la plante
        /// </summary>
        /// <param name="columnName">Attribut de la plante</param>
        /// <returns>Le message d'erreur</returns>
        public string this[string columnName]
        {
            get
            {

                var validationResults = new List<ValidationResult>();

                if (Validator.TryValidateProperty(
                    GetType().GetProperty(columnName).GetValue(this)
                    , new ValidationContext(this)
                    {
                        MemberName = columnName
                    }
                    , validationResults))
                    return null;

                return validationResults.First().ErrorMessage;
            }
        }
    }
}
