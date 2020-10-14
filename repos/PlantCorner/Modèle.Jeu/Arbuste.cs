using System;
using System.Collections.Generic;
using System.Text;

namespace Modèle.Jeu
{
    /// <summary>
    /// Classe définisant un arbuste héritant d'une plante du jeu
    /// </summary>
    public class Arbuste : PlanteDuJeu
    {
        public Arbuste(string nom, float prix, string lien, int pointDeVie, int gainEnArgent,int gainEnExpérience, string desc) : base(nom, prix, lien, gainEnArgent, gainEnExpérience, desc)
        {
            gainEnArgent += 40;
            pointDeVie += 10;
        }
    }
}
