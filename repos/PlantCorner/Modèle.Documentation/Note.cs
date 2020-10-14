using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace Modèle.Documentation
{
    /// <summary>
    /// Cette classe représente la note que l'utilisateur peut ajouter à sa fleur présente dans sa liste personnelle. Avec une gestion de la persistance directement avec le DataContract
    /// </summary>
    [DataContract]
    public class Note
    {
        /// <summary>
        /// Description contenant dans la note. Est obligatoire et peut faire une longueur de 1000 caractère maximal
        /// </summary>
        [DataMember]
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        /// <summary>
        /// Message d'erreur donné par le validateur
        /// </summary>
        public string Error { get; }


        /// <summary>
        ///Constructeur de la note.
        /// </summary>
        /// <param name="note">Contenu de la note (ne doit pas être vide et doit contenir plus de 3 caractères.</param>

        public Note(string note)
        {
            Description = note;
        }

        /// <summary>
        /// Définition de l'affichage de la note
        /// </summary>
        /// <returns>Contenu de la note</returns>
        public override string ToString()
        {
            return $"Note personnelle : {Description}"; ;
        }


        /// <summary>
        /// Validateur des différents attribut de la note
        /// </summary>
        /// <param name="columnName">Attribut à valider</param>
        /// <returns>Le message d'erreur à afficher la vue</returns>
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

