using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modèle.Documentation.Persistance { 
    /// <summary>
    /// Classe permettant la création de données fictives pour tester le fonction du modèle et des vues. Ici pour les plantes de la documentation
    /// </summary>
    public class StubPlanteDataManager : StubDataManager<Plante>
    {
        /// <summary>
        /// Constructeur du stub avec différent plantes personnelles
        /// </summary>
        public StubPlanteDataManager()
        {
            MyCollection = new List<Plante>()
            {
                new Plante("Rose", "Rosa", "../Img/rose.jpg",
                "La rose est la fleur des rosiers, arbustes du genre Rosa et de la famille des Rosaceae. La rose des jardins se caractérise avant tout par la multiplication de ses pétales imbriqués qui lui donne sa forme caractéristique.",
                Couleurs.Rouge, Saisons.Ete,"Il faut les fournir abondamment en eau, et surtout en eau propre. Le vase qui accueille des roses coupées doit non seulement être propre, mais aussi largement rempli, au moins à la moitié de la hauteur des tiges. L'eau du vase doit être changée très régulièrement, et même quotidiennement si possible."),
               
                new Plante("Tulipe", "Tulipa", "../Img/tulipe.jpg",
                "Les tulipes forment un genre (Tulipa) de plantes herbacées de la famille des Liliacées, qui compte une centaine d'espèces originaires des régions tempérées chaudes de l'Ancien monde. Plusieurs espèces sont largement cultivées comme plantes ornementales et ont donné lieu à la création de plusieurs milliers de variétés.",
                Couleurs.Violet, Saisons.Automne,"Ce sont des plantes qui apprécient le plein soleil et les endroits protégés du vent pour épanouir vers mars-avril leurs fleurs en forme de coupe. Le bulbe apprécie les sols légers et bien drainés, sinon il dépérit. Les tulipes se plantent en automne (plutôt entre octobre et novembre, l'extrême limite étant mi-décembre) dans un sol léger, sableux, drainé, riche, de préférence à l'abri du vent. La floraison a lieu au printemps, de fin mars à mai, parfois en février suivant les conditions."),  
               
                new Plante("Tournesol", "Hélianthe", "../Img/tournesol.jpg",
                "Le tournesol', ou anciennement Hélianthe ou Soleil (Helianthus annuus), est une grande plante annuelle, appartenant à la famille des Astéracées (Composées), dont les fleurs sont groupées en capitules de grandes dimensions. Le genre Helianthus comprend une cinquantaine d'espèces, toutes originaires d'Amérique du Nord, dont le topinambour (Helianthus tuberosus L.).",
                Couleurs.Jaune, Saisons.Ete,"Le tournesol affectionne des climats chauds et secs. C'est une culture de printemps, il se sème dès la mi-mars et sa récolte débute mi-août. L’écartement optimum se situe à 45 cm inter-rangs et 30 cm inter-plants avec un objectif de 60 à 80 000 pieds/ ha et permet un gain de rendement de près de 6 q/ha par rapport à un écartement de 80 cm."),   
               
                new Plante("Dahlia", "Cocoxochitl", "../Img/dahlia.jpg",
                "Le dahlia est originaire des régions chaudes du Mexique, d'Amérique centrale ainsi que de la Colombie. Les Aztèques l'appelaient Cocoxochitl (traduit approximativement en « canne d'eau » en raison de sa tige creuse) et utilisaient quotidiennement ses feuilles, pourtant amères, et leurs tubercules pour nourrir leurs animaux mais aussi pour leurs supposées vertus diurétiques ou anti-épileptiques. Ainsi que le décrit en 1570 Francisco Hernández, les Aztèques le cultivent aussi comme plante ornementale.",
                Couleurs.Rouge, Saisons.Printemps,"L'espèce la plus connue est le Dahlia pinnata largement cultivé et à l'origine de nombreux hybrides3. Le dahlia fleurit de juillet (pour les plus précoces) jusqu'aux gelées. Il prospère bien en zone climatique 7 et 84, mais le dahlia craint le gel. Dans les régions où il gèle, il faut donc déplanter les tubercules pour les mettre à l'abri l'hiver. On le plante en début de printemps quand les risques de gels sont passés (mise en culture sous abri possible un mois avant)."),   
                
                new Plante("Geranium", "Geranium", "../Img/geranium.jpg",
                "Les espèces du genre Geranium sont des plantes herbacées annuelles ou pérennes et parfois des sous-arbrisseaux1. Les feuilles stipulées sont opposées ou alternes ; le limbe est palmé avec des divisions allant jusqu'au milieu du limbe (palmatifide) ou presque jusqu'au pétiole(palmatiséqué). Les segments peuvent être entiers ou lobés. Diagramme floral de Geranium pratense. Fruit de Geranium rotundifolium. L'inflorescence est une cyme pauciflore (à 1-3 fleurs). La fleur actinomorphe (à symétrie radiale), sauf pour G. arboreum qui est zygomorphe. Les 5 sépales verts, libres et souvent poilus ont toujours une pointe saillante. Les 5 pétales libres sont blancs à pourpres. Les 10 étamines aux bords poilus sont réparties sur deux verticilles de 5 ; elles sont toutes fertiles et connées à la base. Les 5 nectaires sont disposées entre les étamines extérieures. L'ovaire a 5 loges avec 2 ovules par loge.Le fruit comporte un bec(axe central) et 5 méricarpes à 1 seule graine, portée par un filet s'enroulant à maturité. La graine ellipsoïdale est éjectée à distance, expulsion mécanique appelée autochorie. Cette dispersion des semences qui restent à proximité du plant mère où les conditions sont propices à la germination, concerne de nombreuses espèces pionnières.",
                Couleurs.Rouge, Saisons.Printemps,"L'entretien du géranium est simple : il faut lui apporter régulièrement de l'engrais et le placer dans un endroit lumineux. Quand apparaissent des fleurs fanées, il est important de les retirer au fur et à mesure pour que le géranium ne s'épuise pas. Si vous partez en vacances, retirez toutes les fleurs."),  
                
                new Plante("Pivoine", "Paeonia", "../Img/pivoine.jpg",
                "Les pivoines sont connues par une quarantaine d'espèces de plantes vivaces, herbacées, ou arbustives. Les feuilles sont vert tendre ou foncé, quelquefois argentées. Les fleurs peuvent être parfumées, dressées et solitaires ou en forme de coupe ou de boule.On distingue les pivoines herbacées et les pivoines arbustives, ou pivoines en arbre.Les pivoines herbacées disparaissent chaque hiver pour réapparaître au printemps. Elles sont de culture facile, très rustiques. L’espèce la plus courante est Paeonia lactiflora, parfois appelée pivoine de Chine. Elle se décline en un grand nombre de variétés. Les fleurs sont de forme simple, semi-double ou double. En Europe, il existe plusieurs espèces sauvages, les plus connues en Europe occidentale étant la pivoine officinale Paeonia officinalis et la pivoine mâle Paeonia mascula, tandis que Paeonia tenuifolia est caractéristique de la steppe pontique et des Balkans.",
                Couleurs.Rouge, Saisons.Printemps,"Plantées correctement, une pivoine herbacée ne réclame pas de soins particuliers. Ôter les fleurs une fois fanées pour supprimer la formation de graines en préservant le feuillage, dont le bulbe a besoin pour reconstituer ses réserves. Ne couper les tiges feuillées qu'en automne, une fois qu'il sera sec."),
                
                new Plante("Petunia", "Petunia", "../Img/petunia.jpg",
                "Le botaniste Antoine-Laurent de Jussieu établit le genre Petunia sur la base de deux plantes récoltées par Commerson en Uruguay3. Il observe que « La corolle, attachée sous l'ovaire, est monopétale, tubulée, rétrécie dans son milieu, évasée par le haut, et à peine divisée en cinq lobes inégaux...Le nombre de cinq étamines les rapproche davantage des Solanées, et on reconnut bientôt qu'elles doivent être placées à côté du Tabac, Nicotiana. Mais leurs fleurs sont solitaires, axillaires, et non en épis terminaux comme dans ce genre...Nous avons cru ces diverses considérations suffisantes pour réunir ces plantes sous un genre nouveau que nous nommerons Petunia, à cause de son affinité avec le tabac, qui est le Petun des Brésiliens. » Et il plaça ce genre dans la famille des Solanées [Solanacées]. Il décrit et dénomme ensuite les deux plantes de l'herbier Commerson : Petunia parviflora a « une corolle très petite, débordant à peine le calice » et Petunia nyctaginiflora a une « corolle environ quatre fois plus longue que le calice, assez semblable pour la forme à cette partie que la plupart des auteurs nomment corolle dans le Nyctage ou Belle-de-nuit ».",
                Couleurs.Violet, Saisons.Printemps,"Retirez simplement les fleurs fanées au fur et à mesure afin de favoriser l'apparition de nouvelles fleurs. Supprimez les mauvaises herbes qui poussent au pied du pétunia. Arrosage et engrais chez le pétunia : Durant les fortes chaleurs, n'hésitez pas à arroser le soir afin d'éviter que vos pétunias se dessèchent."),
                
                new Plante("Violette", "Viola odorata", "../Img/violette.jpg",
                "La Violette odorante (Viola odorata) est une petite plante vivace de la famille des Violaceae formant des colonies plus ou moins étendues, aux tiges formant des stolons, aux feuilles ovales, en cœur à la base, munies d'un long pétiole et aux fleurs odorantes, au bout d'une mince tige, fleurissant de février à mai, formées de cinq pétales violet dont l'inférieur est muni d'un éperon qui sont stériles (alors que de petites fleurs verdâtres et tardives forment des graines).Elle colonise les prés, les bois et les haies.",
                Couleurs.Violet, Saisons.Printemps,"La violette ne réclame que peu d’entretien sauf, peut-être, d’être arrosée si le sol s’assèche. Vous pourrez supprimer les fleurs fanées au fur et à mesure afin de stimuler l’apparition de nouveaux boutons floraux."), 
                
                new Plante("Jacinthe", "Hyacinthus", "../Img/jacinthe.jpg",
                "Hyacinthus est un genre de plantes bulbeuses, anciennement classées dans la famille des Liliaceae et qui désigne les véritables espèces de jacinthes (pour les distinguer des espèces de scilles). Ce genre fait désormais partie de la famille des Asparagaceae. Le nom vient de la mythologie grecque : Hyacinthe fut tué accidentellement par le dieu Apollon, celui-ci transforma alors les gouttes de sang en fleurs.Ces plantes sont originaires d'Asie du sud-ouest (Iran, Turkménistan).La floraison, très décorative et parfumée, intervient au cours du printemps. Les bulbes peuvent être forcés en serre (traitement thermique des bulbes) de telle sorte que la floraison intervient alors pour les fêtes de Noël. Les bulbes sont alors très affaiblis et produisent nettement moins de fleurs l'année suivante.Les feuilles sont à nervures parallèles, l'inflorescence indéfinie est de type grappe, la fleur est actinomorphe, les 6 étamines sont soudées aux tépales, l'ovaire n'est pas soudé au périgone gamotépale, le style est court, on distingue 3 carpelles, l'ovaire est supère et la placentation est axile.",
                Couleurs.Violet, Saisons.Hiver,"Arrosez légèrement, car un excès d'humidité peut faire pourrir le bulbe. Pendant la floraison de la jacinthe en pot, tant que la plante a des feuilles, maintenez le terreau humide et apportez de l'engrais. La jacinthe en pleine terre apprécie un apport de fumier bien décomposé en fin d'hiver."),
               
            };
        }

        /// <summary>
        /// Redefinition de la methode permettant de trouver une plante grâce à son nom
        /// </summary>
        /// <param name="nom">Nom de la plante </param>
        /// <returns>La plante recherché</returns>
        public override Plante GetByName(string nom)
        {
            return MyCollection.Find(plante => plante.Couleur.Equals(nom));
        }
    }
}
