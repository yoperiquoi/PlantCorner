using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Modèle.Documentation
{
    /// <summary>
    /// Classe définissant une plante personnelle héritant d'une plante de la documentation basique avec une note rajouté
    /// </summary>
    public class MaPlante : Plante, INotifyPropertyChanged
    {
        /// <summary>
        /// Note présente uniquement pour les plantes personnelles
        /// </summary>
        [Required]
        public Note Note
        {
            get => note;
            set
            {
                if (note == value) return;
                note = value;  
                OnPropertyChange(nameof(Note));
            }
        }
        private Note note;

        /// <summary>
        /// Constructeur d'une plante personnelle à partir d'une plante déjà créé
        /// </summary>
        /// <param name="n">Note ajouté à une plante basique</param>
        /// <param name="p">Plante basique déjà présente dans la documentation</param>
        public MaPlante(string n, Plante p)
            : base(p)
        {
            Note = new Note(n);
        }


        /// <summary>
        /// Constructeur d'une plante personnelle à partir de rien
        /// </summary>
        /// <param name="n">Note ajouté à la toute nouvelle plante</param>
        /// <param name="nom">Nom de la nouvelle plante</param>
        /// <param name="nomScientifique">Nom scientifique de la nouvelle plante</param>
        /// <param name="illustration">Lien de l'image de la nouvelle plante</param>
        /// <param name="description">Description de la nouvelle plante</param>
        /// <param name="couleur">Couleur principale de cette nouvelle plante</param>
        /// <param name="saison">Saison de fleuraison principal de cette nouvelle plante</param>
        /// <param name="instruction">Intruction d'entretient de la plante</param>
        public MaPlante(string n, string nom, string nomScientifique, string illustration, string description,
            Couleurs couleur,
            Saisons saison,
            string instruction)
            : base(nom, nomScientifique, illustration, description, couleur, saison, instruction)
        {
            Note = new Note(n);
        }

        /// <summary>
        /// Constructeur d'une plante personnelle à partir d'une autre plante personnelle
        /// </summary>
        /// <param name="maPlante">Plante personnelle</param>
        public MaPlante(MaPlante maPlante)
           : base(maPlante.Nom, maPlante.NomScientifique, maPlante.Illustration, maPlante.Description, maPlante.Couleur, maPlante.Saison, maPlante.Instruction)
        {
            Note = new Note(maPlante.Note.Description);
        }

        /// <summary>
        /// Méthode permettant de comparer deux plantes personnelles et définir si elle sont identique
        /// </summary>
        /// <param name="other">Objet à comparer</param>
        /// <returns>Si les deux plante sont identique ou non</returns>
        public bool Equals(MaPlante other)
        {
            return Note.Description.Equals(other.Note.Description) && Nom.Equals(other.Nom);
           
        }

        /// <summary>
        /// Méthode permettant de savoir si une plante personnelle et un object sont équivalents
        /// </summary>
        /// <param name="obj">Object à comparer avec une plante</param>
        /// <returns>Si les objets sont identique ou non</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as MaPlante);
        }

        /// <summary>
        /// Affichage d'une plante personnel (identique à une plante basique mais avec l'affichage de la note)
        /// </summary>
        /// <returns>L'affichage de la plante personnelle</returns>
        public override string ToString()
        {
            return $"{Nom} ou \"{NomScientifique}\" est une plante {Couleur} poussant en {Saison} :\n {Description}\n" +
                   $"Le lien de son illustration est : {Illustration}\n" +
                   $"{Note}\n" +
                   $"Voici les instruction d'entretient {Instruction}";
        }

        /// <summary>
        /// Méthode de validation des attributs
        /// </summary>
        /// <param name="columnName">Attribut à valider</param>
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
