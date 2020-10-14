Yoann PERIQUOI, Thomas BLANC Groupe 5 DUT INFORMATIQUE de Clermont-Ferrand

Merci de consulter le document ContextePC.docx se trouvant dans le dossier Documents du repository.
C'est dans ce document que l'on retrouve l'architecture du projet ainsi qu'un développement plus poussé sur les parties personnelles ajoutées au projet.
Par ailleurs, tout les documents demandés sont retrouvables dans les fichiers Conception et Documents du repository. 


Note d’utilisation de l’application :

Lors du démarrage de l’application via visual studio nous vous conseillons de restaurer les paquages NuGet MaterialDesign et Newtonsoft nécessaires à la vue et à la persistance.
Des fichiers de persistance ont été placés dans les fichiers de l'application afin de permettre à l'utilisateur d'avoir des données dès le démarrage de l'application.
Normalement aucune manipulation n'est nécessaire pour exploiter l'application.

Vous pouvez par ailleurs réinitialiser ou ajouter des données à partir des données du stub en suivant la procédure suivante :

Pour la Documentation :

Modifier les données du stub des plantes personnelles et des plantes de la documentation à votre convenance.
Lancer le Test_DataContract.
Aller chercher le fichier « documentation.xml » se trouvant au bout du chemin suivant : « ./repos/PlantCorner/Test_DataContract/bin/Debug/XML/documentation.xml »
Déplacer ce fichier dans le dossier suivant : « ./repos/PlantCorner/PlantCorner/bin/Debug/XML » 
Les données de la documentation sont maintenant réinitialisées avec les votres.

Pour le Jeu :

Modifier les données du stubs des plantes du jeu et des accessoires du jeu à votre convenance.
Lancer le Test_JeuJSON.
Aller chercher les différents fichiers « *.json » se trouvant au bout du chemin suivant : « ./repos/PlantCorner/Test_DataContract/bin/Debug/JSON»
Déplacer ces fichiers dans le dossier suivant : « ./repos/PlantCorner/PlantCorner/bin/Debug/JSON » 
Les données du jeu sont maintenant réinitialisées avec les votres.
Ces données peuvent aussi être modifiées à la main directement dans les fichiers de persistance.

Des fichiers bin sont enregistrés avec le projet car dedans sont stockées les données nécessaires au fonctionnement de l’application où vont s’inscrire les données de l’utilisateur après utilisation.

Eléments personnels ajoutés :

	- Une partie jeu avec un jeu basique ayant des ressemblances au jeu "Cookie Clicker" où le joueur est invité à acheter des plantes et des accessoires avec une monnaie fictive pour
	  acheer d'autres plantes et accessoires afin de remporter le plus d'argent possible et tout les succès du jeu.	

	- L’algorithme de recherche basé sur l’algorithme des « distances » de Levenshtein, celui-ci donne la distance entre deux chaînes de caractères. 
	  Il nous permet de mettre en place une recherche qui affiche la plante qui se rapproche le plus de la chaîne de caractère tapé dans la barre de recherche.

	- L’utilisation de multibinding et de converters dans la vue afin d’avoir des rendus plus personnalisés.

	- La mise en place d’une encapsulation profonde via une « DeepReadOnlyCollection » que l’on retrouve dans la liste de plantes fixées de la documentation.

 	- La mise en place d’événements C# comme d’un chargement fictif et de l’attribution automatique des succès à l’utilisateur.

Ces ajouts sont détaillés dans le code à l’aide de commentaire.

Par ailleurs pour vous faciliter à trouver certains bouts de codes intéressants, voici leurs emplacements :
	- Rechercher : Modèle.Documentation dans la classe Doc
	- Multibinding : PlantCorner dans AffichagePlante
	- Encapsulation profonde : Modèle.Documentation dans la classe Doc, sur la liste ListePlanteFixé
	- Evénement C# : UserChargement avec le classe Chargement dans PlantCorner
			 Modèle.Jeu avec la gestion des succès avec l'événement SeuilAtteint
	- Utilisation de LINQ : Modèle.Documentation dans la classe Doc, Filtrage par couleurs et saisons

Voici les emplacements des différentes productions demandées dans les modules :

Les tests se trouvent tous dans le fichier Tests associé à la solution.
La vidéo de présentation se trouve dans le fichier Video du repository.
Les différents diagrammes se trouvent dans le fichier Conception du repository et sont décrits dans ContextePC.docx présent dans le fichier Documents.
Le code est commenté afin de décrire ce que nous voulions faire pour chaque fonctions assez compléxes.
Les documents relatifs à la documentation du module Interface Homme-Machine se trouvent tous dans le fichier Documents du repository.
Les vues et l'application se retrouvent dans le dossier repos du repository, leur fonctionnement est détaillé dans le code avec des commentaires.
Les diagrammes relatifs aux ajouts personnels et à la persistance se situent tous dans le fichier Conception du repository et sont détaillés dans le fichier ContextePC.docx se
trouvant dans le dossier Documents du repository.
L'essaie de déploiement se trouve dans le fichier PlantCorner.exe. Celui ci s'intalle correctement mais une exception est levé lors du démarrage de celui-ci.



Commentaires personnels du groupe :
Il était prévu dans l’application la mise en place d’une base de données et d’un système d’authentification. Faute de temps, dû à des événements (personnels) indépendants du projet,
nous avons abandonné ces idées là et nous avons décidé de peaufiner un peu plus le jeu et les connaissances que nous devions intégrer sur les bases du c#, XAML, DataBinding…
Tout les éléments relatifs à la mise en place d'un système d'authentification n'ont donc pas pu être implémentés et les classes Arbuste et Arbre n'ont pas été exploitées. Nous nous excusons pour cela.
Nous imaginons reprendre ce projet dans le futur pour finir certaines parties inachevées. 

Remerciements à Monsieur RAYMOND et Monsieur CHEVALDONNE pour leur aide tout au long de la réalisation du projet.
