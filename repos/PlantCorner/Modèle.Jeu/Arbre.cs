using System;
using System.Collections.Generic;
using System.Text;

namespace Modèle.Jeu
{
    /// <summary>
    /// Classe définisant un arbre héritant d'une plante du jeu
    /// </summary>
    public class Arbre : PlanteDuJeu
    {
        public Arbre(string nom, float prix, string lien, int pointDeVie, int gainEnArgent,int gainEnExpérience, string desc) : base(nom, prix, lien, gainEnArgent,gainEnExpérience, desc)
        {
            gainEnArgent += 50;
            pointDeVie +=20;
        }

        public void BoosterParArbre(int boost,PlanteDuJeu plante)
        {
            GainEnArgent += boost;
        }
    }
}
