using Modèle.Jeu;
using System.ComponentModel;

namespace Modèle.Jeu
{
    /// <summary>
    /// Classe définissant un succès du jeu
    /// </summary>
    public class Succès 
    {
        /// <summary>
        /// Nom du succès
        /// </summary>
        public string Nom { get;  set; }
       
        /// <summary>
        /// Description du succès
        /// </summary>
        public string Description { get;  set; }
       
        /// <summary>
        /// Lien vers l'illustration du succès
        /// </summary>
        public string  Img { get; set; }
       
        /// <summary>
        /// Argent attribué pour le gain de ce succès
        /// </summary>
        public float ArgentGagné { get;  set; }
        
        /// <summary>
        /// Expérience gagné pour le gain de ce succès
        /// </summary>
        public int ExpérienceGagné { get;  set; }
        
        /// <summary>
        /// Condition d'obtention de ce succès
        /// </summary>
        public int Condition { get;  set; }
        
        /// <summary>
        /// Constructeur du succès
        /// </summary>
        /// <param name="nom">Nom du succès</param>
        /// <param name="description">Description du succès</param>
        /// <param name="argentGagné">Argent gagné pour le gain de ce succès</param>
        /// <param name="expérienceGagné">Expérience gagné pour le gain de ce succès</param>
        /// <param name="condition">Condition d'obtention de ce succès</param>
        /// <param name="image">Lien vers l'illustration du succès</param>
        public Succès (string nom, string description, float argentGagné, int expérienceGagné, int condition, string image)
        {
            this.Nom = nom;
            this.Description = description;
            this.ArgentGagné = argentGagné;
            this.ExpérienceGagné = expérienceGagné;
            this.Condition = condition;
            Img = image;
        }

        public Succès()
        {
        }
    }
}