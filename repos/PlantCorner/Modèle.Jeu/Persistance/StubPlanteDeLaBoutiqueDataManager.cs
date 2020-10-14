using System;
using System.Collections.Generic;
using System.Text;

namespace Modèle.Jeu.Persistance
{
    /// <summary>
    /// Classe permettant la création de données fictives pour tester le fonction du modèle et des vues. Ici pour les plantes de la boutique de la boutique
    /// réutilisé dans l'inventaire et dans la liste des plantes planté
    /// </summary>
    class StubPlanteDeLaBoutiqueDataManager : StubDataManager<PlanteDuJeu>
    {
        /// <summary>
        /// Constructeur du stub avec différentes plantes du jeu
        /// </summary>
        public StubPlanteDeLaBoutiqueDataManager()
        {
            MyCollection = new List<PlanteDuJeu>()
            {
                new PlanteDuJeu("Plantito",0,"../Img/plante1.jfif",1,2, "Je suis un petit cactus"),
                new PlanteDuJeu("Fleurdo",3,"../Img/plante2.jpg",2,4, "Je suis une plante carnivore"),
                new PlanteDuJeu("Feuillas",5,"../Img/plante3.jpg",3,5, "Je suis une plante exotique rare"),
                new PlanteDuJeu("Pistilus",10,"../Img/plante4.jpg",4,10, "Je viens d'une autre planète!!! "),
                new PlanteDuJeu("Bulbizarre",20,"../Img/plante5.jpg",5,15, "Je suis bicolore une plante extrement rare qui rapporte beaucoups"),
                new PlanteDuJeu("Megapotdefleur",50,"../Img/plante7.jfif",10,20, "Je suis la meilleurs des plantes j'écrase tout le monde autour de moi")
            };
        }

        /// <summary>
        /// Redefinition de la methode permettant de trouver une plante du jeu grâce à son nom
        /// </summary>
        /// <param name="nom">Nom de la plante du jeu</param>
        /// <returns>La plante du jeu recherché</returns>
        public override PlanteDuJeu GetByName(string nom)
        {
            return MyCollection.Find(plante => plante.Nom.Equals(nom));
        }
    }
}
