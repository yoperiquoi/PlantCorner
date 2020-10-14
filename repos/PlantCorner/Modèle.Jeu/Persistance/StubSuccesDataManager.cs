using System;
using System.Collections.Generic;
using System.Text;

namespace Modèle.Jeu.Persistance
{
    /// <summary>
    /// Classe permettant la création de données fictives pour tester le fonction du modèle et des vues. Ici pour les succès.
    /// </summary>
    class StubSuccesDataManager : StubDataManager<Succès>
    {
        /// <summary>
        /// Constructeur du stub avec différent succès
        /// </summary>
        public StubSuccesDataManager()
        {
            MyCollection = new List<Succès>()
            {
           new Succès("Débutant","Vous êtes un tout petit jardinier",50,10,0,"../Img/LogoPC.png"),
           new Succès("Intermédiaire","Vous êtes un  jardinier intermédiaire",100,20,500,"../Img/medaille5.png"),
           new Succès("Expert","Vous êtes un jardinier expert",150,30,1500,"../Img/medaille3.jpg"),
           new Succès("Paysagiste","Vous êtes un des meilleurs jardinier",200,40,3000,"../Img/medaille2.jpg"),
           new Succès("Megagiste","Vous êtes le meilleur jardinier!!!",300,60,5000,"../Img/medaille1.jpg")
            };
        }

        /// <summary>
        /// Redefinition de la methode permettant de trouver un succès grâce à son nom
        /// </summary>
        /// <param name="nom">Nom du succès</param>
        /// <returns>Succès recherché</returns>
        public override Succès GetByName(string nom)
        {
            return MyCollection.Find(succes => succes.Nom.Equals(nom));
        }
    }
}

