using System;
using System.Collections.Generic;
using System.Text;

namespace Modèle.Documentation.Persistance
{ 
    /// <summary>
    /// Classe permettant la création de données fictives pour tester le fonction du modèle et des vues. Ici pour les plantes personnelles de la documentation
    /// </summary>
    public class StubMesPlanteDataManager : StubDataManager<MaPlante>
    {
        /// <summary>
        /// Constructeur du stub avec différent plantes personnelles
        /// </summary>
        public StubMesPlanteDataManager()
        {
            MyCollection = new List<MaPlante>()
            {
                 new MaPlante("Insérer une note","Violette", "Viola odorata", 
                 "../Img/violette.jpg","La Violette odorante (Viola odorata) est une petite plante vivace de la famille des Violaceae formant des colonies plus ou moins étendues, aux tiges formant des stolons, aux feuilles ovales, en cœur à la base, munies d'un long pétiole et aux fleurs odorantes, au bout d'une mince tige, fleurissant de février à mai, formées de cinq pétales violet dont l'inférieur est muni d'un éperon qui sont stériles (alors que de petites fleurs verdâtres et tardives forment des graines).Elle colonise les prés, les bois et les haies.",
                Couleurs.Violet, Saisons.Printemps,"La violette ne réclame que peu d’entretien sauf, peut-être, d’être arrosée si le sol s’assèche. Vous pourrez supprimer les fleurs fanées au fur et à mesure afin de stimuler l’apparition de nouveaux boutons floraux."),

                new MaPlante("Insérer une note","Jacinthe", "Hyacinthus", "../Img/jacinthe.jpg",
                "Hyacinthus est un genre de plantes bulbeuses, anciennement classées dans la famille des Liliaceae et qui désigne les véritables espèces de jacinthes (pour les distinguer des espèces de scilles). Ce genre fait désormais partie de la famille des Asparagaceae. Le nom vient de la mythologie grecque : Hyacinthe fut tué accidentellement par le dieu Apollon, celui-ci transforma alors les gouttes de sang en fleurs.Ces plantes sont originaires d'Asie du sud-ouest (Iran, Turkménistan).La floraison, très décorative et parfumée, intervient au cours du printemps. Les bulbes peuvent être forcés en serre (traitement thermique des bulbes) de telle sorte que la floraison intervient alors pour les fêtes de Noël. Les bulbes sont alors très affaiblis et produisent nettement moins de fleurs l'année suivante.Les feuilles sont à nervures parallèles, l'inflorescence indéfinie est de type grappe, la fleur est actinomorphe, les 6 étamines sont soudées aux tépales, l'ovaire n'est pas soudé au périgone gamotépale, le style est court, on distingue 3 carpelles, l'ovaire est supère et la placentation est axile.",
                Couleurs.Violet, Saisons.Hiver,"Arrosez légèrement, car un excès d'humidité peut faire pourrir le bulbe. Pendant la floraison de la jacinthe en pot, tant que la plante a des feuilles, maintenez le terreau humide et apportez de l'engrais. La jacinthe en pleine terre apprécie un apport de fumier bien décomposé en fin d'hiver."),

        };
        }

        /// <summary>
        /// Redefinition de la methode permettant de trouver une plante personnelle grâce à son nom
        /// </summary>
        /// <param name="nom">Nom de la plante personnelle</param>
        /// <returns>La plante personnelle recherché</returns>
        public override MaPlante GetByName(string nom)
        {
            return MyCollection.Find(plante => plante.Couleur.Equals(nom));
        }
    }
}
