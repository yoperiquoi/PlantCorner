using System;

namespace PlantCorner
{
    /// <summary>
    /// Classe définissant l'EventArgs de la protection
    /// </summary>
    public class ProgressionNotifiedEventArgs : EventArgs
    {
        /// <summary>
        /// Pourcentage de complétion du chargement fictif
        /// </summary>
        public int Pourcentage { get; private set; }

        public ProgressionNotifiedEventArgs(int pourcentage) => Pourcentage = pourcentage;
    }
}