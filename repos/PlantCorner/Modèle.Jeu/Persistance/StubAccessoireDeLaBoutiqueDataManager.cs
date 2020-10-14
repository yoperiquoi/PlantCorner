using System;
using System.Collections.Generic;
using System.Text;

namespace Modèle.Jeu.Persistance
{
    /// <summary>
    /// Classe permettant la création de données fictives pour tester le fonction du modèle et des vues. Ici pour les accessoires de la boutique
    /// </summary>
    class StubAccessoireDeLaBoutiqueDataManager : StubDataManager<Accessoire>
    {
        /// <summary>
        /// Constructeur du stub avec différent accessoires
        /// </summary>
        public StubAccessoireDeLaBoutiqueDataManager()
        {
            MyCollection = new List<Accessoire>()
            {
            new Accessoire(30, 0, "../Img/abeille.jpg", "Abeillito", 2, 20,"Petite abeille pas très efficace"),
            new Accessoire(25, 10, "../Img/engrais.jpg", "Engrais", 3, 10,"Permet d'avoir une terre plus nourrissante"),
            new Accessoire(20, 20, "../Img/pelle.jpg", "Pelle", 4, 5,"Creuser des trous plus grand pour une meilleur pousser"),
            new Accessoire(10, 25, "../Img/soleil.jpg", "Soleil", 5, 3,"Ressource vos plantes doucement avec ces rayons"),
            new Accessoire(1, 100, "../Img/abeille.png", "Megabeille", 20, 2,"La méga abeille qui polinise tout sur son passage")
            };
        }

        /// <summary>
        /// Redefinition de la methode permettant de trouver un accessoire grâce à son nom
        /// </summary>
        /// <param name="nom">Nom de l'accessoire</param>
        /// <returns>L'accessoire recherché</returns>
        public override Accessoire GetByName(string nom)
        {
            return MyCollection.Find(accessoire => accessoire.Nom.Equals(nom));
        }
    }
}
