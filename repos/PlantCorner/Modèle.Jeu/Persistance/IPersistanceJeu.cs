using System;
using System.Collections.Generic;
using System.Text;

namespace Modèle.Jeu.Persistance
{
    /// <summary>
    /// Interface définissant le comportement des méthodes de sauvegarde et de chargement pour la Persistance du jeu en JSON
    /// </summary>
    public interface IPersistanceJeu
    {
        (IEnumerable<PlanteDuJeu> LesPlantesPlanté, IEnumerable<PlanteDuJeu> MesPlantesInv, IEnumerable<Accessoire> MesAccessoiresInv, IEnumerable<PlanteDuJeu> LesPlantes, IEnumerable<Accessoire> LesAccessoires, Utilisateur MonUtilisateur) ChargeDonnées();
        void SauvegardeDonnées(IEnumerable<PlanteDuJeu> LesPlantesPlanté, Boutique MaBoutique, Inventaire MonInventaire, Utilisateur MonUtilisateur);
    }
}
