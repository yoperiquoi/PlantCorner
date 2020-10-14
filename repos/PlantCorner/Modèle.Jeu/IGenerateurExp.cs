using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Modèle.Jeu
{
    /// <summary>
    /// Interface avec les méthodes nécessaire pour le gain d'expérience de l'utilisateur
    /// </summary>
    interface IGenerateurExp<T>
    {
        /// <summary>
        /// Méthode pour faire gagner de l'expérience à un joueur
        /// </summary>
        /// <param name="objet">Objet responsable de l'ajout d'expérience de l'utilisateur</param>
        /// <param name="utilisateur">Utilisateur gagnant de l'expérience</param>
        void GagnerExp(T objet, Utilisateur utilisateur);
    }


}
